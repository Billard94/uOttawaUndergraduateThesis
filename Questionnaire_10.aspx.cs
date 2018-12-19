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
    public partial class Questionnaire_10 : System.Web.UI.Page
    {

        InsertIntoDatabase Insert = new InsertIntoDatabase();

        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        String cmdtxt;
        MySqlDataReader reader;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                yesnoGrid1();
                TextGrid1();
            }
        }
        private void yesnoGrid1()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiongroup = '1' and questionorder >= 157";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.yesno1grid.DataSource = dt;
                yesno1grid.DataBind();
                connection.closeconnection();
                if (yesno1grid.Rows.Count > 0)
                {
                    Globel.array_yesno = new int[yesno1grid.Rows.Count];
                    yesno1Div.Visible = true;
                }

                else
                {
                    yesno1Div.Visible = false;
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

        protected void OnRowCreatedyesno1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , Hidyesno1.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedyesno1(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.Hidyesno1.Value);

            if (selectedCellIndex > 1)
            {

                CheckBoxList myCBL2 = (selectedRow.FindControl("cbloption2") as CheckBoxList);
                myCBL2.Items[0].Selected = false;
                

                CheckBoxList myCBL1 = (selectedRow.FindControl("cbloption1") as CheckBoxList);
                myCBL1.Items[0].Selected = false;



                if (Globel.array_yesno[rowIndex] == selectedCellIndex)
                {
                    Globel.array_yesno[rowIndex] = 0;
                }

                else
                {

                    Globel.array_yesno[rowIndex] = selectedCellIndex;


                    if (selectedCellIndex == 2)
                    {
                        myCBL1.Items[0].Selected = true;
                    }
                    else if (selectedCellIndex == 3)
                    {
                        myCBL2.Items[0].Selected = true;
                    }

                  


                }
            }
        }

        protected void yesno1grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            yesno1grid.PageIndex = e.NewPageIndex;
            yesnoGrid1();
        }

        private void TextGrid1()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questionorder >=157 and questiongroup = '3'";

                //cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'General' and questiongroup = '3'";

                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.Stringquestions1.DataSource = dt;
                Stringquestions1.DataBind();
                connection.closeconnection();
                if (Stringquestions1.Rows.Count > 0)
                {
                    Globel.array_text = new int[Stringquestions1.Rows.Count];

                    textdiv1.Visible = true;
                }
                else
                {
                    textdiv1.Visible = false;
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
















        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                CheckBoxList myCBL1;
                CheckBoxList myCBL2;
                CheckBoxList myCBL3;
                CheckBoxList myCBL4;



                foreach (GridViewRow row in yesno1grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);


                    string Sname = "";
                    if (myCBL1.Items[0].Selected == true)
                    {
                        Sname = myCBL1.Items[0].Value;
                    }
                    else if (myCBL2.Items[0].Selected == true)
                    {
                        Sname = myCBL2.Items[0].Value;
                    }

                    else if (myCBL3.Items[0].Selected == true)
                    {
                        Sname = myCBL3.Items[0].Value;
                    }

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Sname = myCBL4.Items[0].Value;
                    }

                    id = Convert.ToInt32(yesno1grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Sname);

                }

                TextBox mytextbox1;
                foreach (GridViewRow row in Stringquestions1.Rows)
                {
                    mytextbox1 = (row.FindControl("Stringquestions1") as TextBox);
                    id = Convert.ToInt32(Stringquestions1.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, mytextbox1.Text);
                }








                ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Thank you for completing the questionnaire, you will now be prompt to your results');", true);
                Response.Redirect("Results.aspx");


            }
            catch (Exception ex)
            {
                lblerrormain.Text = ex.Message;
                lblerrormain.Visible = true;

            }

        }

    }
}