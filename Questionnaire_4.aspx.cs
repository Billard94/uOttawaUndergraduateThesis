using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;


namespace OSCS{
    public partial class Questionnaire_4 : System.Web.UI.Page{

        InsertIntoDatabase Insert = new InsertIntoDatabase();

        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        String cmdtxt;
        MySqlDataReader reader;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e){
            if (!IsPostBack){
                Fillgrid();
                FillgridTwo();
            }
        }



        private void Fillgrid(){
            try{
                lblerrormain.Visible = false;

                DataSet ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed){
                    connection.openconnection();
                }

                cmd.Connection = connection.connection;
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Keele' and questiongroup = '1'";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.gvphq9.DataSource = dt;
                gvphq9.DataBind();
                connection.closeconnection();
                if (gvphq9.Rows.Count > 0)
                {
                    Globel.array_radio1 = new int[gvphq9.Rows.Count];

                    maindiv.Visible = true;
                }
                else{
                    maindiv.Visible = false;
                }
            }

            catch (MySqlException ex){
                lblerrormain.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerrormain.Visible = true;
            }

            catch (Exception ex){
                lblerrormain.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerrormain.Visible = true;
            }
        }

        private void FillgridTwo(){
            try{
                lblerrormain.Visible = false;

                DataSet ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed){
                    connection.openconnection();
                }

                cmd.Connection = connection.connection;
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Keele' and questiongroup = '2'";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.GvSec.DataSource = dt;
                GvSec.DataBind();
                connection.closeconnection();
                if (GvSec.Rows.Count > 0){
                    Globel.array_radio2 = new int[GvSec.Rows.Count];
                    DivS.Visible = true;
                }

                else{
                    DivS.Visible = false;
                }
            }

            catch (MySqlException ex){
                lblerrormain.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerrormain.Visible = true;
            }
            catch (Exception ex){
                lblerrormain.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerrormain.Visible = true;
            }
        }

        private string GetSortDirection(string column){

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null){
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column){
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC")){
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void gvphq9_PageIndexChanging(object sender, GridViewPageEventArgs e){
            gvphq9.PageIndex = e.NewPageIndex;
            Fillgrid();
        }
        protected void gvphq9_Sorting(object sender, GridViewSortEventArgs e){
            DataTable dt = Session["MAINSORTING"] as DataTable;
            if (dt != null){
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvphq9.DataSource = Session["MAINSORTING"];
                gvphq9.DataBind();
            }
        }


        protected void OnRowCreated(object sender, GridViewRowEventArgs e){
            if (e.Row.RowType == DataControlRowType.DataRow){
                for (int i = 0; i < e.Row.Cells.Count; i++){
                    TableCell cell = e.Row.Cells[i];
                    //cell.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    //cell.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    ////cell.ToolTip = "You can click this cell";
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , SelectedGridCellIndex.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChanged(Object sender, EventArgs e){
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndex.Value);

            if (selectedCellIndex > 1){
                CheckBoxList myCBL2 = (selectedRow.FindControl("cbloption2") as CheckBoxList);
                myCBL2.Items[0].Selected = false;

                CheckBoxList myCBL1 = (selectedRow.FindControl("cbloption1") as CheckBoxList);
                myCBL1.Items[0].Selected = false;

                if (Globel.array_radio1[rowIndex] == selectedCellIndex){
                    Globel.array_radio1[rowIndex] = 0;
                }

                else{
                    Globel.array_radio1[rowIndex] = selectedCellIndex;

                    if (selectedCellIndex == 2){
                        myCBL1.Items[0].Selected = true;
                    }
                    else if (selectedCellIndex == 3){
                        myCBL2.Items[0].Selected = true;
                    }
                }
            }
        }

        protected void OnRowCreatedS(object sender, GridViewRowEventArgs e){
            if (e.Row.RowType == DataControlRowType.DataRow){
                for (int i = 0; i < e.Row.Cells.Count; i++){
                    TableCell cell = e.Row.Cells[i];
                    //cell.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    //cell.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    ////cell.ToolTip = "You can click this cell";
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , Hidsec.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedS(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.Hidsec.Value);

            if (selectedCellIndex > 1){
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

                if (Globel.array_radio2[rowIndex] == selectedCellIndex){
                    Globel.array_radio2[rowIndex] = 0;
                }

                else{

                    Globel.array_radio2[rowIndex] = selectedCellIndex;


                    if (selectedCellIndex == 2){
                        myCBL1.Items[0].Selected = true;
                    }
                    else if (selectedCellIndex == 3){
                        myCBL2.Items[0].Selected = true;
                    }

                    else if (selectedCellIndex == 4){
                        myCBL3.Items[0].Selected = true;
                    }
                    else if (selectedCellIndex == 5){
                        myCBL4.Items[0].Selected = true;
                    }

                    else if (selectedCellIndex == 6){
                        myCBL5.Items[0].Selected = true;
                    }
                }
            }
        }

        protected void GvSec_PageIndexChanging(object sender, GridViewPageEventArgs e){
            GvSec.PageIndex = e.NewPageIndex;
            FillgridTwo();
        }

        protected void btnAdd_Click(object sender, EventArgs e){
            try{
                int id = 0;
                int score = 0;
                CheckBoxList myCBL1;
                CheckBoxList myCBL2;
                CheckBoxList myCBL3;
                CheckBoxList myCBL4;
                CheckBoxList myCBL5;
                foreach (GridViewRow row in gvphq9.Rows){
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);

                    
                    string Sname = "";
                    if (myCBL1.Items[0].Selected == true){
                        score = score + Convert.ToInt32(myCBL1.Items[0].Value);
                        Sname = "Disagree";
                    }
                    else if (myCBL2.Items[0].Selected == true){
                        score = score + Convert.ToInt32(myCBL2.Items[0].Value);
                        Sname = "Agree";
                    }
                   
                    id = Convert.ToInt32(gvphq9.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Keele(id, score, Sname);

                    Insert.Answers(id, Sname);

                }

                score = 0;
                foreach (GridViewRow row in GvSec.Rows){
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);

                    string Sname = "";
                    if (myCBL1.Items[0].Selected == true){
                        score = Convert.ToInt32(myCBL1.Items[0].Value);
                        Sname = "Not at all";
                    }
                    else if (myCBL2.Items[0].Selected == true){
                        score = Convert.ToInt32(myCBL2.Items[0].Value);
                        Sname = "Slightly";
                    }

                    else if (myCBL3.Items[0].Selected == true){
                        score = Convert.ToInt32(myCBL3.Items[0].Value);
                        Sname = "Moderately";
                    }

                    else if (myCBL4.Items[0].Selected == true){
                        score = Convert.ToInt32(myCBL4.Items[0].Value);
                        Sname = "Very much";
                    }

                    else if (myCBL5.Items[0].Selected == true){
                        score = Convert.ToInt32(myCBL5.Items[0].Value);
                        Sname = "Extremely";
                    }

                    id = Convert.ToInt32(GvSec.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Keele(id, score, Sname);

                    Insert.Answers(id, Sname);

                }
                Response.Redirect("Questionnaire_5.aspx");


            }
            catch (Exception ex)
            {
                lblerrormain.Text = ex.Message;
                lblerrormain.Visible = true;

            }

        }

    }
}