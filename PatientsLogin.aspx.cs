using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;


namespace OSCS
{
    public partial class PatientsLogin : System.Web.UI.Page
    {

        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        String cmdtxt;
        MySqlDataReader reader;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Globel.hospitalpatientID == "0" && Globel.registeredpatientID == 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('" + "You do not have access to this page... redirected to homepage." + "');");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);


                System.Threading.Thread.Sleep(5000);
                Response.Redirect("~/index.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    fillgrid();
                }
            }
        }

        private void fillgrid()
        {
            try
            {
                lblerrormain.Visible = false;

                DataSet ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed)
                {
                    connection.openconnection();
                }

                cmd.Connection = connection.connection;
                cmd.CommandText = "Select q.questionid, q.QuestionType, q.questiondescription, a.answer " +
                                  "from answers a, questions q " +
                                  "where q.questionid = a.questionid " + "AND (a.HospitalPatientID = '" + Globel.hospitalpatientID + "' OR a.RegisteredPatientID = " + Globel.registeredpatientID + ") " +
                                  "order by q.questionid ASC";



                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.GridView1.DataSource = dt;
                GridView1.DataBind();
                connection.closeconnection();

                if (GridView1.Rows.Count > 0)
                {
                    maindiv.Visible = true;
                }
                else
                {
                    maindiv.Visible = false;
                }
            }

            catch (MySqlException ex)
            {
                lblerrormain.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerrormain.Visible = true;
            }
            catch (Exception ex)
            {
                lblerrormain.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerrormain.Visible = true;
            }
        }

        private void MsgBox(String msg)
        {
            string message = msg;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('" + message + "');");
            sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", sb.ToString(), false);
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                lblerrormain.Visible = false;
                txtsearch.Text = txtsearch.Text.Replace("'", "''");
                DataSet ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed)
                {
                    connection.openconnection();
                }
                cmd.Connection = connection.connection;
                cmd.CommandText = "Select q.questionid, q.QuestionType, q.questiondescription, a.answer " +
                                  "from answers a, questions q " +
                                  "where a.questionid = q.questionid AND CONCAT_WS('|',`QuestionType`,`questiondescription`,`answer`) LIKE '%" + txtsearch.Text + "%' " + "AND(a.HospitalPatientID = '" + Globel.hospitalpatientID + "' OR a.RegisteredPatientID = '" + Globel.registeredpatientID + "') " +
                                  "order by q.questionid ASC";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.GridView1.DataSource = dt;
                GridView1.DataBind();
                connection.closeconnection();
                if (GridView1.Rows.Count > 0)
                {
                    maindiv.Visible = true;
                }
                else
                {
                    maindiv.Visible = false;
                }
            }

            catch (MySqlException ex)
            {
                lblerrormain.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerrormain.Visible = true;
            }
            catch (Exception ex)
            {
                lblerrormain.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerrormain.Visible = true;
            }
        }

        protected void btnquestionnaire_Click(object sender, EventArgs e)
        {
            Response.Redirect("Questionnaire_1.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName != "Sort")
                {
                    int index = ((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex;
                    if (e.CommandName.Equals("editRecord"))
                    {
                        GridViewRow gvrow = GridView1.Rows[index];
;

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();

                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#editModal').modal('show');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                    }

                    else if (e.CommandName.Equals("deleteRecord"))
                    {
                        string code = GridView1.DataKeys[index].Value.ToString();
                        // hfCode.Value = code;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#deleteModal').modal('show');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MsgBox(ex.Message);
            }
            catch (Exception ex)
            {
                MsgBox(ex.Message);
            }
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            fillgrid();
        }

        private string GetSortDirection(string column)
        {
            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["MAINSORTING"] as DataTable;

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridView1.DataSource = Session["MAINSORTING"];
                GridView1.DataBind();
            }
        }
    }
}