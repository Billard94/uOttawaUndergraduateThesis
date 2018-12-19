﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OSCS
{
    public partial class index : System.Web.UI.Page
    {
        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        DataTable dt;
        InsertIntoDatabase Insert = new InsertIntoDatabase();
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            Globel.administrator = 0;
            Globel.registeredpatientID = 0;
            Globel.hospitalpatientID = "0";

        }
        protected void btnQwithR_Click(object sender, EventArgs e){
            Response.Redirect("Patient.aspx");
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

            if (contains == true){
                Insert.HospitalID(HospitalID.Text);
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("LoginCredentials.aspx");


        }
    }
}