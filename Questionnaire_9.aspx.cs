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
    public partial class Questionnaire_9 : System.Web.UI.Page
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
                TextGrid1();
                TextGrid2();
                RadioGrid1();
            }

        }

        // FIND TEXT INPUT questions
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'GodinShepard' and questiongroup = '3' and questionorder >= 112 and questionorder <= 114";

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

        protected void OnRowCreatedText1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    //cell.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    //cell.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    ////cell.ToolTip = "You can click this cell";
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , SelectedGridCellIndexText1.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedText1(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndexText1.Value);

            if (selectedCellIndex > 1)
            {
                TextBox mytxtBox = (selectedRow.FindControl("Stringquestions1") as TextBox);

                if (Globel.array_text[rowIndex] == selectedCellIndex)
                {
                    Globel.array_text[rowIndex] = 0;
                }

                else
                {
                    Globel.array_text[rowIndex] = selectedCellIndex;
                }
            }
        }

        protected void Stringquestions1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Stringquestions1.PageIndex = e.NewPageIndex;
            TextGrid1();
        }
        protected void Stringquestions1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["MAINSORTING"] as DataTable;
            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                Stringquestions1.DataSource = Session["MAINSORTING"];
                Stringquestions1.DataBind();
            }
        }


        // FIND TEXT INPUT questions
        private void TextGrid2()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'GodinShepard' and questiongroup = '3' and questionorder >= 115 and questionorder <= 116";

                //cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'General' and questiongroup = '3'";

                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.Stringquestions2.DataSource = dt;
                Stringquestions2.DataBind();
                connection.closeconnection();
                if (Stringquestions2.Rows.Count > 0)
                {
                    Globel.array_text = new int[Stringquestions2.Rows.Count];

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

        protected void OnRowCreatedText2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    //cell.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    //cell.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    ////cell.ToolTip = "You can click this cell";
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , SelectedGridCellIndexText1.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedText2(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndexText1.Value);

            if (selectedCellIndex > 1)
            {
                TextBox mytxtBox = (selectedRow.FindControl("Stringquestions2") as TextBox);

                if (Globel.array_text[rowIndex] == selectedCellIndex)
                {
                    Globel.array_text[rowIndex] = 0;
                }

                else
                {
                    Globel.array_text[rowIndex] = selectedCellIndex;
                }
            }
        }

        protected void Stringquestions2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Stringquestions2.PageIndex = e.NewPageIndex;
            TextGrid2();
        }
        protected void Stringquestions2_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["MAINSORTING"] as DataTable;
            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                Stringquestions2.DataSource = Session["MAINSORTING"];
                Stringquestions2.DataBind();
            }
        }

        private void RadioGrid1()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'GodinShepard' and questiongroup = '2' and questionorder = 117";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.radio1grid.DataSource = dt;
                radio1grid.DataBind();
                connection.closeconnection();
                if (radio1grid.Rows.Count > 0)
                {
                    Globel.array_radio1 = new int[radio1grid.Rows.Count];
                    radio1Div.Visible = true;
                }

                else
                {
                    radio1Div.Visible = false;
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

        protected void OnRowCreatedRadio1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , HidRadio1.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedRadio1(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.HidRadio1.Value);

            if (selectedCellIndex > 1)
            {
                CheckBoxList myCBL1 = (selectedRow.FindControl("cbloption1") as CheckBoxList);
                myCBL1.Items[0].Selected = false;

                CheckBoxList myCBL2 = (selectedRow.FindControl("cbloption2") as CheckBoxList);
                myCBL2.Items[0].Selected = false;

                CheckBoxList myCBL3 = (selectedRow.FindControl("cbloption3") as CheckBoxList);
                myCBL3.Items[0].Selected = false;

                CheckBoxList myCBL4 = (selectedRow.FindControl("cbloption4") as CheckBoxList);
                myCBL4.Items[0].Selected = false;

                CheckBoxList myCBL5 = (selectedRow.FindControl("cbloption5") as CheckBoxList);
                myCBL5.Items[0].Selected = false;

                CheckBoxList myCBL6 = (selectedRow.FindControl("cbloption6") as CheckBoxList);
                myCBL6.Items[0].Selected = false;


                if (Globel.array_radio1[rowIndex] == selectedCellIndex)
                {
                    Globel.array_radio1[rowIndex] = 0;
                }

                else
                {

                    Globel.array_radio1[rowIndex] = selectedCellIndex;


                    if (selectedCellIndex == 2)
                    {
                        myCBL1.Items[0].Selected = true;
                    }
                    else if (selectedCellIndex == 3)
                    {
                        myCBL2.Items[0].Selected = true;
                    }

                    else if (selectedCellIndex == 4)
                    {
                        myCBL3.Items[0].Selected = true;
                    }
                    else if (selectedCellIndex == 5)
                    {
                        myCBL4.Items[0].Selected = true;
                    }

                    else if (selectedCellIndex == 6)
                    {
                        myCBL5.Items[0].Selected = true;
                    }

                    else if (selectedCellIndex == 7)
                    {
                        myCBL6.Items[0].Selected = true;
                    }
                }
            }
        }

        protected void radio1grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            radio1grid.PageIndex = e.NewPageIndex;
            RadioGrid1();
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
                

                TextBox mytextbox1;
                foreach (GridViewRow row in Stringquestions1.Rows)
                {
                    mytextbox1 = (row.FindControl("Stringquestions1") as TextBox);
                    id = Convert.ToInt32(Stringquestions1.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, mytextbox1.Text);
                }

                TextBox mytextbox2;
                foreach (GridViewRow row in Stringquestions2.Rows)
                {
                    mytextbox2 = (row.FindControl("Stringquestions2") as TextBox);
                    id = Convert.ToInt32(Stringquestions2.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, mytextbox2.Text);
                }

                string Anwser = "";
                CheckBoxList myCBL1;
                CheckBoxList myCBL2;
                CheckBoxList myCBL3;


                foreach (GridViewRow row in radio1grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);

                    if (myCBL1.Items[0].Selected == true)
                    {
                        Anwser = myCBL1.Items[0].Value;
                    }
                    else if (myCBL2.Items[0].Selected == true)
                    {
                        Anwser = myCBL2.Items[0].Value;
                    }

                    else if (myCBL3.Items[0].Selected == true)
                    {
                        Anwser = myCBL3.Items[0].Value;
                    }



                    id = Convert.ToInt32(radio1grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }

                Response.Redirect("Questionnaire_10.aspx");

            }
            catch (Exception ex)
            {
                lblerrormain.Text = ex.Message;
                lblerrormain.Visible = true;

            }

        }
    }

}