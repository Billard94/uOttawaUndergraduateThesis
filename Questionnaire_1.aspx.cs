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
    public partial class Questionnaire_1 : System.Web.UI.Page
    {
        InsertIntoDatabase Insert = new InsertIntoDatabase();

        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e){
            if (!IsPostBack) {
                TextGrid1();
                YesNoGrid1();
                TextGrid2();
                RadioGrid1();
                CheckBoxGrid1();
                YesNoGrid2();
            }
        }

        // FIND TEXT INPUT questions
        private void TextGrid1(){
            try{
                lblerrormain.Visible = false;

                DataSet ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed) { connection.openconnection();   }
                cmd.Connection = connection.connection;
                cmd.CommandText = "Select questionid, questiondescription " + 
                                  "from questions " + 
                                  "where questiontype = 'General' and questiongroup = '3' and questionorder <=2";
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

            if (selectedCellIndex > 1){
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

        //cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'General' and questiongroup = '1' and questionorder = 3";

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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'General' and questiongroup = '1' and questionorder = 3";
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
                CheckBoxList myCBL1 = (selectedRow.FindControl("cbloption1") as CheckBoxList);
                myCBL1.Items[0].Selected = false;

                CheckBoxList myCBL2 = (selectedRow.FindControl("cbloption2") as CheckBoxList);
                myCBL2.Items[0].Selected = false;


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
            YesNoGrid1();
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'General' and questiongroup = '3' and questionorder = 4";


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

                    textdiv2.Visible = true;
                }
                else
                {
                    textdiv2.Visible = false;
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

        protected void OnRowCreatedText2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                  
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , SelectedGridCellIndexText2.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedText2(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndexText2.Value);

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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'General' and questiongroup = '2' and questionorder = 5";
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
                }
            }
        }

        protected void Radio1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Radio1.PageIndex = e.NewPageIndex;
            RadioGrid1();
        }










        private void CheckBoxGrid1()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'General' and questiongroup = '4' and questionorder >= '6' AND questionorder <= '7';";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.CheckBox1.DataSource = dt;
                CheckBox1.DataBind();
                connection.closeconnection();
                if (CheckBox1.Rows.Count > 0)
                {
                    Globel.array_checkbox1 = new int[CheckBox1.Rows.Count];
                    CheckBoxdiv1.Visible = true;
                }

                else
                {
                    CheckBoxdiv1.Visible = false;
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

        protected void CheckBox1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["MAINSORTING"] as DataTable;
            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                CheckBox1.DataSource = Session["MAINSORTING"];
                CheckBox1.DataBind();
            }
        }


        protected void OnRowCreatedCheckBox1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , SelectedGridCellIndexCheckBox1.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedCheckBox1(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndexCheckBox1.Value);

            if (selectedCellIndex > 1)
            {
                CheckBoxList myCBL7 = (selectedRow.FindControl("cbloption7") as CheckBoxList);
                myCBL7.Items[0].Selected = false;

                CheckBoxList myCBL6 = (selectedRow.FindControl("cbloption6") as CheckBoxList);
                myCBL6.Items[0].Selected = false;

                CheckBoxList myCBL5 = (selectedRow.FindControl("cbloption5") as CheckBoxList);
                myCBL5.Items[0].Selected = false;

                CheckBoxList myCBL4 = (selectedRow.FindControl("cbloption4") as CheckBoxList);
                myCBL4.Items[0].Selected = false;

                CheckBoxList myCBL3 = (selectedRow.FindControl("cbloption3") as CheckBoxList);
                myCBL3.Items[0].Selected = false;

                CheckBoxList myCBL2 = (selectedRow.FindControl("cbloption2") as CheckBoxList);
                myCBL2.Items[0].Selected = false;

                CheckBoxList myCBL1 = (selectedRow.FindControl("cbloption1") as CheckBoxList);
                myCBL1.Items[0].Selected = false;



                if (Globel.array_checkbox1[rowIndex] == selectedCellIndex)
                {
                    Globel.array_checkbox1[rowIndex] = 0;
                }

                else
                {

                    Globel.array_checkbox1[rowIndex] = selectedCellIndex;


                    if (selectedCellIndex == 2)
                    {
                        myCBL1.Items[0].Selected = true;

                    }
                    if (selectedCellIndex == 3)
                    {
                        myCBL2.Items[0].Selected = true;
                    }

                    if (selectedCellIndex == 4)
                    {
                        myCBL3.Items[0].Selected = true;
                    }
                    if (selectedCellIndex == 5)
                    {
                        myCBL4.Items[0].Selected = true;
                    }

                    if (selectedCellIndex == 6)
                    {
                        myCBL5.Items[0].Selected = true;
                    }

                    if (selectedCellIndex == 7)
                    {
                        myCBL6.Items[0].Selected = true;
                    }

                    if (selectedCellIndex == 8)
                    {
                        myCBL7.Items[0].Selected = true;
                    }
                }
            }
        }

        protected void CheckBox1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CheckBox1.PageIndex = e.NewPageIndex;
            CheckBoxGrid1();
        }

        // FIND YesNo2 
        private void YesNoGrid2()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'General' and questiongroup = '1' and questionorder = 8";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.YesNo2.DataSource = dt;
                YesNo2.DataBind();
                connection.closeconnection();
                if (YesNo2.Rows.Count > 0)
                {
                    Globel.array_yesno = new int[YesNo2.Rows.Count];
                    YesNodiv2.Visible = true;
                }

                else
                {
                    YesNodiv2.Visible = false;
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
        protected void OnRowCreatedYesNo2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , SelectedGridCellIndexYesNo2.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedYesNo2(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndexYesNo2.Value);

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

        protected void YesNo2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            YesNo2.PageIndex = e.NewPageIndex;
            YesNoGrid2();
        }

























        private string GetSortDirection(string column){

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
            try{
                int id;
                TextBox mytextbox1;
                foreach (GridViewRow row in Stringquestions1.Rows){
                    mytextbox1 = (row.FindControl("Stringquestions1") as TextBox);
                    id = Convert.ToInt32(Stringquestions1.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, mytextbox1.Text);
                }
                CheckBoxList myCBL1;
                CheckBoxList myCBL2;
                foreach (GridViewRow row in yesno1grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);


                    string Anwser = "";
                    if (myCBL1.Items[0].Selected == true)
                    {
                        Anwser = myCBL1.Items[0].Value;
                    }
                    else if (myCBL2.Items[0].Selected == true)
                    {
                        Anwser = myCBL2.Items[0].Value;
                    }

                   

                    id = Convert.ToInt32(yesno1grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }
                TextBox mytextbox2;
                foreach (GridViewRow row in Stringquestions2.Rows)
                {
                    mytextbox2 = (row.FindControl("Stringquestions2") as TextBox);
                    id = Convert.ToInt32(Stringquestions2.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, mytextbox2.Text);
                }

                CheckBoxList myCBL3;
                foreach (GridViewRow row in Radio1.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);

                    int score = 0;
                    string Answer = "";
                    if (myCBL1.Items[0].Selected == true)
                    {
                        score = Convert.ToInt32(myCBL1.Items[0].Value);
                        Answer = "Better";
                    }
                    else if (myCBL2.Items[0].Selected == true)
                    {
                        score = Convert.ToInt32(myCBL2.Items[0].Value);
                        Answer = "Worse";
                        Globel.NotImprovingWorse = 1;
                    }
                    else if (myCBL3.Items[0].Selected == true)
                    {
                        score = Convert.ToInt32(myCBL3.Items[0].Value);
                        Answer = "Not Improving";
                        Globel.NotImprovingWorse = 1;
                    }
                    id = Convert.ToInt32(Radio1.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, Answer);
                }

                CheckBoxList myCBL4;
                CheckBoxList myCBL5;
                CheckBoxList myCBL6;
                CheckBoxList myCBL7;
                string var1 = "";
                string var2 = "";
                string var3 = "";
                string var4 = "";
                string var5 = "";
                string var6 = "";
                string var7 = "";

                foreach (GridViewRow row in CheckBox1.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);
                    myCBL7 = (row.FindControl("cbloption7") as CheckBoxList);

                    var1 = "";
                    var2 = "";
                    var3 = "";
                    var4 = "";
                    var5 = "";
                    var6 = "";
                    var7 = "";

                    if (myCBL1.Items[0].Selected == true)
                    {
                        var1 = "Sitting";
                    }
                    if (myCBL2.Items[0].Selected == true)
                    {
                        var2 = "Standing";
                    }
                    if (myCBL3.Items[0].Selected == true)
                    {
                        var3 = "Walking";
                    }
                    if (myCBL4.Items[0].Selected == true)
                    {
                        var4 = "Lying down";
                    }
                    if (myCBL5.Items[0].Selected == true)
                    {
                        var5 = "Bending forward";
                    }
                    if (myCBL6.Items[0].Selected == true)
                    {
                        var6 = "Other";
                    }
                    if (myCBL7.Items[0].Selected == true)
                    {
                        var7 = "Nothing";
                    }

                    if (var7 == "Nothing") {
                        var1 = "";
                        var2 = "";
                        var3 = "";
                        var4 = "";
                        var5 = "";
                        var6 = "";
                    }
                    id = Convert.ToInt32(CheckBox1.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, var1+", "+var2 + ", " + var3 + ", " + var4 + ", " + var5 + ", " + var5 + ", " + var6 + ", " + var7);
                }

                foreach (GridViewRow row in YesNo2.Rows)
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
                    id = Convert.ToInt32(YesNo2.DataKeys[row.RowIndex]["questionid"]);
                    Insert.Answers(id, Answer);
                }
                //Insert.printDict();
                Response.Redirect("Questionnaire_2.aspx");

            }
            catch (Exception ex)
            {
                lblerrormain.Text = ex.Message;
                lblerrormain.Visible = true;

            }

        }
    }
}