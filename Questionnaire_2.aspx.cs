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
    public partial class Questionnaire_2 : System.Web.UI.Page
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
                YesNoGrid1();
                TextGrid1();
            }
            
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Treatment' and questiongroup = '1' and questionorder >= 9 and questionorder <=35 order by questionorder asc";

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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Treatment' and questiongroup = '3' order by questionorder ASC";

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
                Response.Redirect("Questionnaire_3.aspx");
  
            }
            catch (Exception ex)
            {
                lblerrormain.Text = ex.Message;
                lblerrormain.Visible = true;

            }

        }
    }

}