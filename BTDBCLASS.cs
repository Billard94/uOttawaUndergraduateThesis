using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace OSCS{
    public class BTDBCLASS{
        public MySqlConnection connection = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        public void closeconnection(){
            try{
                connection.Close();
            }
            catch (System.Exception ex){
                Globel.errormessage = ex.Message;
            }
        }

        public void openconnection(){
            try{
                connection.ConnectionString = "server=localhost;user id=root;password=P@ssw0rd;database=oscs";
                connection.Open();
            }
            catch (Exception ex){
                Globel.errormessage = ex.Message;
            }
        }

        public bool AUD(string cmdtxt){
            try{
                if (connection.State == ConnectionState.Closed){
                    openconnection();
                }
                cmd.Connection = connection;
                cmd.CommandText = cmdtxt;
                cmd.ExecuteNonQuery();
                closeconnection();
                return true;
            }
            catch (MySqlException ex){
                Globel.errormessage = ex.Message;
                return false;
            }
            catch (Exception ex){
                Globel.errormessage = ex.Message;
                return false;
            }
        }
          
        public string getString(string cmdtxt){
            try{
                string id = "";
                if (connection.State == ConnectionState.Closed){
                    openconnection();
                }
                cmd.Connection = connection;
                cmd.CommandText = cmdtxt;
                object obj = cmd.ExecuteScalar();

                if (obj != null && DBNull.Value != obj){
                    id = Convert.ToString(cmd.ExecuteScalar());
                }
                else{
                    id = "NO12@";
                }
                return id;
            }
            catch (MySqlException ex){
                Globel.errormessage = ex.Message;
                return "NO12@";
            }
            catch (Exception ex){
                Globel.errormessage = ex.Message;
                return "NO12@";
            }
        }

        public BTDBCLASS(){
            //
            // TODO: Add constructor logic here
            //

        }

        public DataTable SqlDataTable(string sql, IDictionary<string, object> values){
            using (MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = P@ssw0rd; database = tsf"))
            using (MySqlCommand cmd = conn.CreateCommand()){
                conn.Open();
                cmd.CommandText = sql;
                foreach (KeyValuePair<string, object> item in values){
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                DataTable table = new DataTable();
                using (var reader = cmd.ExecuteReader()){
                    table.Load(reader);
                    return table;
                }
            }
        }
    }
}