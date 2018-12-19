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
    public partial class Questionnaire_6 : System.Web.UI.Page
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
                TextGrid1();
                RadioGrid2();
                RadioGrid3();
                RadioGrid4();
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'PainHistory' and questiongroup = '2' and questionorder >= 82 and questionorder <= 87";
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
                myCBL5.Items[0].Selected = false;


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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'PainHistory' and questiongroup = '3'";

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
                    Globel.array_text= new int[Stringquestions1.Rows.Count];

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

      
        private void RadioGrid2()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'PainHistory' and questiongroup = '2' and questionorder = 92";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.radio2grid.DataSource = dt;
                radio2grid.DataBind();
                connection.closeconnection();
                if (radio2grid.Rows.Count > 0)
                {
                    Globel.array_radio2 = new int[radio2grid.Rows.Count];
                    radio2Div.Visible = true;
                }

                else
                {
                    radio2Div.Visible = false;
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

        protected void OnRowCreatedradio2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , Hidradio2.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedradio2(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.Hidradio2.Value);

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

                CheckBoxList myCBL7 = (selectedRow.FindControl("cbloption7") as CheckBoxList);
                myCBL7.Items[0].Selected = false;


                if (Globel.array_radio2[rowIndex] == selectedCellIndex)
                {
                    Globel.array_radio2[rowIndex] = 0;
                }

                else
                {

                    Globel.array_radio2[rowIndex] = selectedCellIndex;


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

                    else if (selectedCellIndex == 8)
                    {
                        myCBL7.Items[0].Selected = true;
                    }
                }
            }
        }

        protected void radio2grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            radio2grid.PageIndex = e.NewPageIndex;
            RadioGrid2();
        }

        private void RadioGrid3()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'PainHistory' and questiongroup = '2' and questionorder = 93";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.radio3grid.DataSource = dt;
                radio3grid.DataBind();
                connection.closeconnection();
                if (radio3grid.Rows.Count > 0)
                {
                    Globel.array_radio3 = new int[radio3grid.Rows.Count];
                    radio3Div.Visible = true;
                }

                else
                {
                    radio3Div.Visible = false;
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

        protected void OnRowCreatedradio3(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , Hidradio3.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedradio3(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.Hidradio3.Value);

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

                CheckBoxList myCBL7 = (selectedRow.FindControl("cbloption7") as CheckBoxList);
                myCBL7.Items[0].Selected = false;


                if (Globel.array_radio3[rowIndex] == selectedCellIndex)
                {
                    Globel.array_radio3[rowIndex] = 0;
                }

                else
                {

                    Globel.array_radio3[rowIndex] = selectedCellIndex;


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
                    else if (selectedCellIndex == 8)
                    {
                        myCBL7.Items[0].Selected = true;
                    }
                }
            }
        }

        protected void radio3grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            radio3grid.PageIndex = e.NewPageIndex;
            RadioGrid3();
        }



        private void RadioGrid4()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'PainHistory' and questiongroup = '2' and questionorder = 94";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.radio4grid.DataSource = dt;
                radio4grid.DataBind();
                connection.closeconnection();
                if (radio4grid.Rows.Count > 0)
                {
                    Globel.array_radio4 = new int[radio4grid.Rows.Count];
                    radio4Div.Visible = true;
                }

                else
                {
                    radio4Div.Visible = false;
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

        protected void OnRowCreatedradio4(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , Hidradio4.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedradio4(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.Hidradio4.Value);

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



                if (Globel.array_radio4[rowIndex] == selectedCellIndex)
                {
                    Globel.array_radio4[rowIndex] = 0;
                }

                else
                {

                    Globel.array_radio4[rowIndex] = selectedCellIndex;


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

        protected void radio4grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            radio4grid.PageIndex = e.NewPageIndex;
            RadioGrid4();
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
                CheckBoxList myCBL5;
                CheckBoxList myCBL6;


                foreach (GridViewRow row in radio1grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);

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

                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Sname = myCBL5.Items[0].Value;
                    }

                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Sname = myCBL6.Items[0].Value;
                    }

                    id = Convert.ToInt32(radio1grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Sname);

                }
                TextBox mytextbox1;
                foreach (GridViewRow row in Stringquestions1.Rows)
                {
                    mytextbox1 = (row.FindControl("Stringquestions1") as TextBox);
                    id = Convert.ToInt32(Stringquestions1.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, mytextbox1.Text);
                }
                CheckBoxList myCBL7;
                foreach (GridViewRow row in radio2grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);
                    myCBL7 = (row.FindControl("cbloption7") as CheckBoxList);

                    string Answer = "";
                    if (myCBL1.Items[0].Selected == true)
                    {
                        Answer = myCBL1.Items[0].Value;
                    }
                    else if (myCBL2.Items[0].Selected == true)
                    {
                        Answer = myCBL2.Items[0].Value;
                    }
                    else if (myCBL3.Items[0].Selected == true)
                    {
                        Answer = myCBL3.Items[0].Value;
                    }
                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Answer = myCBL4.Items[0].Value;
                    }
                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Answer = myCBL5.Items[0].Value;
                    }
                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Answer = myCBL6.Items[0].Value;
                    }
                    else if (myCBL7.Items[0].Selected == true)
                    {
                        Answer = myCBL7.Items[0].Value;
                    }
                    id = Convert.ToInt32(radio2grid.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, Answer);
                }

                foreach (GridViewRow row in radio3grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);
                    myCBL7 = (row.FindControl("cbloption7") as CheckBoxList);

                    string Answer = "";
                    if (myCBL1.Items[0].Selected == true)
                    {
                        Answer = myCBL1.Items[0].Value;
                    }
                    else if (myCBL2.Items[0].Selected == true)
                    {
                        Answer = myCBL2.Items[0].Value;
                    }
                    else if (myCBL3.Items[0].Selected == true)
                    {
                        Answer = myCBL3.Items[0].Value;
                    }
                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Answer = myCBL4.Items[0].Value;
                    }
                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Answer = myCBL5.Items[0].Value;
                        Globel.MoreInLegs = 1;
                    }
                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Answer = myCBL6.Items[0].Value;
                        Globel.MoreInLegs = 1;
                    }
                    else if (myCBL7.Items[0].Selected == true)
                    {
                        Answer = myCBL7.Items[0].Value;
                        Globel.MoreInLegs = 1;
                    }
                    id = Convert.ToInt32(radio3grid.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, Answer);
                }

                foreach (GridViewRow row in radio4grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);

                    string Answer = "";
                    if (myCBL1.Items[0].Selected == true)
                    {
                        Answer = myCBL1.Items[0].Value;
                    }
                    else if (myCBL2.Items[0].Selected == true)
                    {
                        Answer = myCBL2.Items[0].Value;
                    }
                    else if (myCBL3.Items[0].Selected == true)
                    {
                        Answer = myCBL3.Items[0].Value;
                    }

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Answer = myCBL4.Items[0].Value;
                        Globel.PreferLegTreat = 1;
                    }

                    id = Convert.ToInt32(radio4grid.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, Answer);
                }










                Response.Redirect("Questionnaire_7.aspx");


            }
            catch (Exception ex)
            {
                lblerrormain.Text = ex.Message;
                lblerrormain.Visible = true;

            }

        }

    }
}