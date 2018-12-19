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
    public partial class Questionnaire_3 : System.Web.UI.Page
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
                RadioGrid1();
                YesNoGrid1();
                TextGrid1();
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'General' and questiongroup = '2' and questionorder = 36";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.Radio1.DataSource = dt;
                Radio1.DataBind();
                connection.closeconnection();
                if (Radio1.Rows.Count > 0)
                {
                    Globel.array_radio1 = new int[Radio1.Rows.Count];
                    Radiodiv1.Visible = true;
                }

                else
                {
                    Radiodiv1.Visible = false;
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

        protected void Radio1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["MAINSORTING"] as DataTable;
            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                Radio1.DataSource = Session["MAINSORTING"];
                Radio1.DataBind();
            }
        }


        protected void OnRowCreatedRadio1(object sender, GridViewRowEventArgs e)
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
                       , SelectedGridCellIndexRadio1.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedRadio1(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndexRadio1.Value);

            if (selectedCellIndex > 1)
            {

                CheckBoxList myCBL4 = (selectedRow.FindControl("cbloption4") as CheckBoxList);
                myCBL4.Items[0].Selected = false;

                CheckBoxList myCBL3 = (selectedRow.FindControl("cbloption3") as CheckBoxList);
                myCBL3.Items[0].Selected = false;

                CheckBoxList myCBL2 = (selectedRow.FindControl("cbloption2") as CheckBoxList);
                myCBL2.Items[0].Selected = false;

                CheckBoxList myCBL1 = (selectedRow.FindControl("cbloption1") as CheckBoxList);
                myCBL1.Items[0].Selected = false;



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
                }
            }
        }

        protected void Radio1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Radio1.PageIndex = e.NewPageIndex;
            RadioGrid1();
        }

        // FIND YesNo1 
        private void YesNoGrid1()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'General' and questiongroup = '1' and questionorder >= 36 and questionorder <=61 order by questionorder asc";

                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.YesNo1.DataSource = dt;
                YesNo1.DataBind();
                connection.closeconnection();
                if (YesNo1.Rows.Count > 0)
                {
                    Globel.array_yesno = new int[YesNo1.Rows.Count];
                    YesNodiv1.Visible = true;
                }

                else
                {
                    YesNodiv1.Visible = false;
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
        protected void OnRowCreatedYesNo1(object sender, GridViewRowEventArgs e)
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
                       , SelectedGridCellIndexYesNo1.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedYesNo1(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndexYesNo1.Value);

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

        protected void YesNo1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            YesNo1.PageIndex = e.NewPageIndex;
            YesNoGrid1();
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'General' and questiongroup = '3' and questionorder >= 39 and questionorder <= 61 order by questionorder ASC";

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
                foreach (GridViewRow row in Radio1.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);

                    int score = 0;
                    string Answer = "";
                    if (myCBL1.Items[0].Selected == true)
                    {
                        score = Convert.ToInt32(myCBL1.Items[0].Value);
                        Answer = "No emotional stress";
                    }
                    else if (myCBL2.Items[0].Selected == true)
                    {
                        score = Convert.ToInt32(myCBL2.Items[0].Value);
                        Answer = "A little stress";
                    }
                    else if (myCBL3.Items[0].Selected == true)
                    {
                        score = Convert.ToInt32(myCBL3.Items[0].Value);
                        Answer = "Moderate stress";
                    }
                    else if (myCBL4.Items[0].Selected == true)
                    {
                        score = Convert.ToInt32(myCBL4.Items[0].Value);
                        Answer = "A lot of emotional stress";
                    }
                    id = Convert.ToInt32(Radio1.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, Answer);
                }

                foreach (GridViewRow row in YesNo1.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);

                    int score = 0;
                    string Answer = "";
                    if (myCBL1.Items[0].Selected == true)
                    {
                        score = Convert.ToInt32(myCBL1.Items[0].Value);
                        Answer = "Yes";
                    }
                    else if (myCBL2.Items[0].Selected == true)
                    {
                        score = Convert.ToInt32(myCBL2.Items[0].Value);
                        Answer = "No";
                    }
                    id = Convert.ToInt32(YesNo1.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, Answer);
                }



                TextBox mytextbox1;
                foreach (GridViewRow row in Stringquestions1.Rows)
                {
                    mytextbox1 = (row.FindControl("Stringquestions1") as TextBox);
                    id = Convert.ToInt32(Stringquestions1.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, mytextbox1.Text);
                }
                Response.Redirect("Questionnaire_4.aspx");

            }
            catch (Exception ex)
            {
                lblerrormain.Text = ex.Message;
                lblerrormain.Visible = true;

            }

        }

    }

}