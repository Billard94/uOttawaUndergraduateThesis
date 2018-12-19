using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OSCS
{
    public partial class Mastermain : System.Web.UI.MasterPage
    {

        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        String cmdtxt;
        MySqlDataReader reader;
        DataTable dt;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIsIDValied_Click(object sender, EventArgs e)
        {

            bool contains = false;
            ds = new DataSet();
            if (connection.connection.State == ConnectionState.Closed) { connection.openconnection(); }
            cmd.Connection = connection.connection;
            cmd.CommandText = "Select hospitalpatientID from hospitalpatient";
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            connection.closeconnection();

            string Hospital_ID = HospitalID.Text;

            contains = dt.AsEnumerable().Any(row => Hospital_ID == row.Field<string>("hospitalpatientID"));

            if (contains == true)
            {
                Globel.hospitalpatientID = HospitalID.Text;
                Response.Redirect("Questionnaire_1.aspx");
            }
            else
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('" + "There is no hospitalID matching this.....returning to homepage" + "');");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                //Response.Redirect("~/index.aspx");
            }

        }



        protected void btnQwithoutRGO_Click(object sender, EventArgs e)
        {
            Response.Redirect("Questionnaire_1.aspx");
        }

        protected void btnQwithoutRRE_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}