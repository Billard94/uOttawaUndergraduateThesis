using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace OSCS{
    public partial class LoginCredentials : System.Web.UI.Page{

        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        String cmdtxt;
        DataTable dt;


        protected void Page_Load(object sender, EventArgs e){

            if (!IsPostBack)
            {
                if (Request.Cookies["UNAME"] != null && Request.Cookies["PWD"] != null)
                {
                    txtusername.Text = Request.Cookies["UNAME"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["PWD"].Value;

                }

            }

        }


        private void MsgBox(String msg)
        {
            string message = msg;



            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('" + message + "');");
            //sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", sb.ToString(), false);
        }



        protected void btncheck_Click(object sender, EventArgs e)
        {
            try
            {
                bool usernameExist = false;
                bool passwordExist = false;

                DataSet ds = new DataSet();

                ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed) { connection.openconnection(); }
                cmd.Connection = connection.connection;
                cmd.CommandText = "Select username from registeredpatient";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                connection.closeconnection();

                usernameExist = dt.AsEnumerable().Any(row => Globel.Encrypt(txtusername.Text) == row.Field<String>("Username"));

                ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed) { connection.openconnection(); }
                cmd.Connection = connection.connection;
                cmd.CommandText = "Select password from registeredpatient where username = '" + txtusername.Text + "'" ;
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                connection.closeconnection();

                passwordExist = dt.AsEnumerable().Any(row => Globel.Encrypt(txtPassword.Text) == row.Field<String>("Password"));
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //if superuser, go to superuser info

                if (txtusername.Text == "Administrator" && txtPassword.Text == "P@ssw0rd")
                {
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("alert('" + "Hello Administrator" + "');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", sb.ToString(), false);
                    Globel.administrator = 1;
                    Response.Redirect("~/Administrator.aspx");
                }

                //if patient username and password exist, see their answers

                else if (usernameExist && passwordExist)
                {
                    ds = new DataSet();
                    if (connection.connection.State == ConnectionState.Closed) { connection.openconnection(); }
                    cmd.Connection = connection.connection;
                    cmd.CommandText = "Select registeredPatientID from registeredpatient where username = '" + txtusername.Text +"'";
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    connection.closeconnection();


                    Globel.registeredpatientID = (Convert.ToInt32(dt.Rows[0][0]));

                    Response.Redirect("~/PatientsLogin.aspx");
                }

                else
                {
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("alert('" + "Either there is a mistake in the Username and/or password or you have yet to register" + "');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", sb.ToString(), false);

                }


                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('" + txtusername.Text + " " + txtPassword.Text + "');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", sb.ToString(), false);
            }
            catch (Exception ex){
                lblerrormain.Text = Globel.errormessage;
                lblerrormain.Visible = true;
            }
        
        }

        protected void btncheckHospitalD_Click(object sender, EventArgs e)
        {
            try
            {

               

                DataSet ds = new DataSet();

                ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed) { connection.openconnection(); }
                cmd.Connection = connection.connection;
                cmd.CommandText = "Select HospitalPatientID from HospitalPatient";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                connection.closeconnection();

                bool hospitalIDExist = false;

                hospitalIDExist = dt.AsEnumerable().Any(row => txtHospitalID.Text == row.Field<String>("HospitalPatientID"));

                System.Diagnostics.Debug.WriteLine(hospitalIDExist);
                if (hospitalIDExist){
                    Globel.hospitalpatientID = (dt.Rows[0][0]).ToString();

                    Response.Redirect("~/PatientsLogin.aspx");
                }

            }

            catch (Exception ex)
            {
                lblerrormain.Text = Globel.errormessage;
                lblerrormain.Visible = true;
            }
        }
    }
}