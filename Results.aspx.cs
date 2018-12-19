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
    public partial class Results : System.Web.UI.Page
    {
        InsertIntoDatabase insert = new InsertIntoDatabase();
        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        String cmdtxt;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e){
            DataSet ds = new DataSet();
            if (connection.connection.State == ConnectionState.Closed)
            {
                connection.openconnection();
            }

            cmd.Connection = connection.connection;
            cmd.CommandText = "Select a.Answer, a.AnswerDate " +
                              "from questions q, answers a " +
                              "where a.questionid = q.questionid AND CONCAT_WS('|',`questiondescription`,`answer`) LIKE '%Smoke%' " +
                              "order by a.Answerdate DESC; ";
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
                   
            connection.closeconnection();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "Yes")
                {
                    smokes.Visible = true;
                }
                smokes.Visible = false;
            }
            else
            {
                smokes.Visible = false;
            }

            ds = new DataSet();
            if (connection.connection.State == ConnectionState.Closed)
            {
                connection.openconnection();
            }

            cmd.Connection = connection.connection;
            cmd.CommandText = "Select a.Answer " +
                              "from questions q, answers a " +
                              "where a.questionid = q.questionid and questiondescription = 'Right leg pain scale' " +
                              "order by a.Answerdate DESC; ";
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];

            connection.closeconnection();

            if (dt.Rows[0][0].ToString() == "None")
            {
                Globel.RightLegPainScale = 0;
            }
            else if (dt.Rows[0][0].ToString() == "Very Mild")
            {
                Globel.RightLegPainScale = 1;
            }
            else if (dt.Rows[0][0].ToString() == "Mild")
            {
                Globel.RightLegPainScale = 2;
            }
            else if (dt.Rows[0][0].ToString() == "Moderate")
            {
                Globel.RightLegPainScale = 3;
            }
            else if (dt.Rows[0][0].ToString() == "Severe")
            {
                Globel.RightLegPainScale = 4;
            }
            else if (dt.Rows[0][0].ToString() == "Very Severe")
            {
                Globel.RightLegPainScale = 5;
            }






            ds = new DataSet();
            if (connection.connection.State == ConnectionState.Closed)
            {
                connection.openconnection();
            }

            cmd.Connection = connection.connection;
            cmd.CommandText = "Select a.Answer " +
                              "from questions q, answers a " +
                              "where a.questionid = q.questionid and questiondescription = 'Left leg pain scale' " +
                              "order by a.Answerdate DESC; ";
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];

            connection.closeconnection();

            if (dt.Rows[0][0].ToString() == "None")
            {
                Globel.LeftLegPainScale = 0;
            }
            else if (dt.Rows[0][0].ToString() == "Very Mild")
            {
                Globel.LeftLegPainScale = 1;
            }
            else if (dt.Rows[0][0].ToString() == "Mild")
            {
                Globel.LeftLegPainScale = 2;
            }
            else if (dt.Rows[0][0].ToString() == "Moderate")
            {
                Globel.LeftLegPainScale = 3;
            }
            else if (dt.Rows[0][0].ToString() == "Severe")
            {
                Globel.LeftLegPainScale = 4;
            }
            else if (dt.Rows[0][0].ToString() == "Very Severe")
            {
                Globel.LeftLegPainScale = 5;
            }

            if (Globel.LeftLegPainScale > Globel.RightLegPainScale)
            {
                Globel.LegPainScale = Globel.LeftLegPainScale;
            }
            else
            {
                Globel.LegPainScale = Globel.RightLegPainScale;
            }

            ds = new DataSet();
            if (connection.connection.State == ConnectionState.Closed)
            {
                connection.openconnection();
            }

            cmd.Connection = connection.connection;
            cmd.CommandText = "Select a.Answer " +
                              "from questions q, answers a " +
                              "where a.questionid = q.questionid and questiondescription = 'Back pain scale' " +
                              "order by a.Answerdate DESC; ";
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];

            connection.closeconnection();

            if (dt.Rows[0][0].ToString() == "None")
            {
                Globel.BackPainScale = 0;
            }
            else if (dt.Rows[0][0].ToString() == "Very Mild")
            {
                Globel.BackPainScale = 1;
            }
            else if (dt.Rows[0][0].ToString() == "Mild")
            {
                Globel.BackPainScale = 2;
            }
            else if (dt.Rows[0][0].ToString() == "Moderate")
            {
                Globel.BackPainScale = 3;
            }
            else if (dt.Rows[0][0].ToString() == "Severe")
            {
                Globel.BackPainScale = 4;
            }
            else if (dt.Rows[0][0].ToString() == "Very Severe")
            {
                Globel.BackPainScale = 5;
            }

            ds = new DataSet();
            if (connection.connection.State == ConnectionState.Closed)
            {
                connection.openconnection();
            }

            cmd.Connection = connection.connection;
            cmd.CommandText = "Select a.Answer " +
                              "from questions q, answers a " + 
                              "where a.questionid = q.questionid AND q.questionid = 6 AND(CONCAT_WS('|',`answer`) LIKE '%Standing%' OR CONCAT_WS('|',`answer`) LIKE '%Walking%') AND(a.HospitalPatientID = '"+ Globel.hospitalpatientID+ "' OR a.RegisteredPatientID = '" + Globel.registeredpatientID + "')";
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                Globel.walkstandpain = 1;
            }

            ds = new DataSet();
            if (connection.connection.State == ConnectionState.Closed)
            {
                connection.openconnection();
            }

            cmd.Connection = connection.connection;
            cmd.CommandText = "Select a.Answer " +
                              "from questions q, answers a " +
                              "where a.questionid = q.questionid AND q.questionid = 6 AND(CONCAT_WS('|',`answer`) LIKE '%Bending%' OR CONCAT_WS('|',`answer`) LIKE '%Sitting%') AND(a.HospitalPatientID = '" + Globel.hospitalpatientID + "' OR a.RegisteredPatientID = '" + Globel.registeredpatientID + "')";
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                Globel.sitbendpain = 1;
            }


            if (Globel.walkstandpain == 1)
            {
                WalkingStanding.Visible = true;
            }

            if (Globel.sitbendpain == 1)
            {
                SittingBendingForward.Visible = true;
            }

            insert.UpdatePatient();

        }
    }
}
