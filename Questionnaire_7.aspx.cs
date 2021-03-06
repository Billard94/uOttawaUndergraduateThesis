﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;


namespace OSCS
{
    public partial class Questionnaire_7 : System.Web.UI.Page
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
                RadioGrid2();
                RadioGrid3();
                RadioGrid4();
                RadioGrid5();
                RadioGrid6();
                RadioGrid7();
                RadioGrid8();
                RadioGrid9();
                RadioGrid10();
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Disability' and questiongroup = '2' and questionorder = 95";
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Disability' and questiongroup = '2' and questionorder = 96";
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Disability' and questiongroup = '2' and questionorder = 97";
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Disability' and questiongroup = '2' and questionorder = 98";
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

                CheckBoxList myCBL5 = (selectedRow.FindControl("cbloption5") as CheckBoxList);
                myCBL5.Items[0].Selected = false;

                CheckBoxList myCBL6 = (selectedRow.FindControl("cbloption6") as CheckBoxList);
                myCBL6.Items[0].Selected = false;


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

        protected void radio4grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            radio4grid.PageIndex = e.NewPageIndex;
            RadioGrid4();
        }

        private void RadioGrid5()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Disability' and questiongroup = '2' and questionorder = 99";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.radio5grid.DataSource = dt;
                radio5grid.DataBind();
                connection.closeconnection();
                if (radio5grid.Rows.Count > 0)
                {
                    Globel.array_radio5 = new int[radio5grid.Rows.Count];
                    radio5Div.Visible = true;
                }

                else
                {
                    radio5Div.Visible = false;
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

        protected void OnRowCreatedradio5(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , Hidradio5.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedradio5(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.Hidradio5.Value);

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


                if (Globel.array_radio5[rowIndex] == selectedCellIndex)
                {
                    Globel.array_radio5[rowIndex] = 0;
                }

                else
                {

                    Globel.array_radio5[rowIndex] = selectedCellIndex;


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

        protected void radio5grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            radio5grid.PageIndex = e.NewPageIndex;
            RadioGrid5();
        }


        private void RadioGrid6()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Disability' and questiongroup = '2' and questionorder = 100";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.radio6grid.DataSource = dt;
                radio6grid.DataBind();
                connection.closeconnection();
                if (radio6grid.Rows.Count > 0)
                {
                    Globel.array_radio6 = new int[radio6grid.Rows.Count];
                    radio6Div.Visible = true;
                }

                else
                {
                    radio6Div.Visible = false;
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

        protected void OnRowCreatedradio6(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , Hidradio6.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedradio6(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.Hidradio6.Value);

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


                if (Globel.array_radio6[rowIndex] == selectedCellIndex)
                {
                    Globel.array_radio6[rowIndex] = 0;
                }

                else
                {

                    Globel.array_radio6[rowIndex] = selectedCellIndex;


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

        protected void radio6grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            radio6grid.PageIndex = e.NewPageIndex;
            RadioGrid6();
        }


        private void RadioGrid7()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Disability' and questiongroup = '2' and questionorder = 101";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.radio7grid.DataSource = dt;
                radio7grid.DataBind();
                connection.closeconnection();
                if (radio7grid.Rows.Count > 0)
                {
                    Globel.array_radio7 = new int[radio7grid.Rows.Count];
                    radio7Div.Visible = true;
                }

                else
                {
                    radio7Div.Visible = false;
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

        protected void OnRowCreatedradio7(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , Hidradio7.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedradio7(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.Hidradio7.Value);

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


                if (Globel.array_radio7[rowIndex] == selectedCellIndex)
                {
                    Globel.array_radio7[rowIndex] = 0;
                }

                else
                {

                    Globel.array_radio7[rowIndex] = selectedCellIndex;


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

        protected void radio7grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            radio7grid.PageIndex = e.NewPageIndex;
            RadioGrid7();
        }

        private void RadioGrid8()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Disability' and questiongroup = '2' and questionorder = 102";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.radio8grid.DataSource = dt;
                radio8grid.DataBind();
                connection.closeconnection();
                if (radio8grid.Rows.Count > 0)
                {
                    Globel.array_radio8 = new int[radio8grid.Rows.Count];
                    radio8Div.Visible = true;
                }

                else
                {
                    radio8Div.Visible = false;
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

        protected void OnRowCreatedradio8(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , Hidradio8.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedradio8(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.Hidradio8.Value);

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


                if (Globel.array_radio8[rowIndex] == selectedCellIndex)
                {
                    Globel.array_radio8[rowIndex] = 0;
                }

                else
                {

                    Globel.array_radio8[rowIndex] = selectedCellIndex;


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

        protected void radio8grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            radio8grid.PageIndex = e.NewPageIndex;
            RadioGrid8();
        }

        private void RadioGrid9()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Disability' and questiongroup = '2' and questionorder = 103";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.radio9grid.DataSource = dt;
                radio9grid.DataBind();
                connection.closeconnection();
                if (radio9grid.Rows.Count > 0)
                {
                    Globel.array_radio9 = new int[radio9grid.Rows.Count];
                    radio9Div.Visible = true;
                }

                else
                {
                    radio9Div.Visible = false;
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

        protected void OnRowCreatedradio9(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , Hidradio9.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedradio9(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.Hidradio9.Value);

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


                if (Globel.array_radio9[rowIndex] == selectedCellIndex)
                {
                    Globel.array_radio9[rowIndex] = 0;
                }

                else
                {

                    Globel.array_radio9[rowIndex] = selectedCellIndex;


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

        protected void radio9grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            radio9grid.PageIndex = e.NewPageIndex;
            RadioGrid9();
        }

        private void RadioGrid10()
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
                cmd.CommandText = "Select questionid, questiondescription from questions where questiontype = 'Disability' and questiongroup = '2' and questionorder = 104";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.radio10grid.DataSource = dt;
                radio10grid.DataBind();
                connection.closeconnection();
                if (radio10grid.Rows.Count > 0)
                {
                    Globel.array_radio10 = new int[radio10grid.Rows.Count];
                    radio10Div.Visible = true;
                }

                else
                {
                    radio10Div.Visible = false;
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

        protected void OnRowCreatedradio10(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , Hidradio10.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void SelectedIndexChangedradio10(Object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.Hidradio10.Value);

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


                if (Globel.array_radio10[rowIndex] == selectedCellIndex)
                {
                    Globel.array_radio10[rowIndex] = 0;
                }

                else
                {

                    Globel.array_radio10[rowIndex] = selectedCellIndex;


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

        protected void radio10grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            radio10grid.PageIndex = e.NewPageIndex;
            RadioGrid10();
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
                string Anwser = "";
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

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Anwser = myCBL4.Items[0].Value;
                    }

                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Anwser = myCBL5.Items[0].Value;
                    }

                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Anwser = myCBL6.Items[0].Value;
                    }

                    id = Convert.ToInt32(radio1grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }

                foreach (GridViewRow row in radio2grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);

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

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Anwser = myCBL4.Items[0].Value;
                    }

                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Anwser = myCBL5.Items[0].Value;
                    }

                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Anwser = myCBL6.Items[0].Value;
                    }

                    id = Convert.ToInt32(radio2grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }

                foreach (GridViewRow row in radio3grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);

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

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Anwser = myCBL4.Items[0].Value;
                    }

                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Anwser = myCBL5.Items[0].Value;
                    }

                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Anwser = myCBL6.Items[0].Value;
                    }

                    id = Convert.ToInt32(radio3grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }

                foreach (GridViewRow row in radio4grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);

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

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Anwser = myCBL4.Items[0].Value;
                    }

                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Anwser = myCBL5.Items[0].Value;
                    }

                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Anwser = myCBL6.Items[0].Value;
                    }

                    id = Convert.ToInt32(radio4grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }

                foreach (GridViewRow row in radio5grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);

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

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Anwser = myCBL4.Items[0].Value;
                    }

                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Anwser = myCBL5.Items[0].Value;
                    }

                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Anwser = myCBL6.Items[0].Value;
                    }

                    id = Convert.ToInt32(radio5grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }

                foreach (GridViewRow row in radio6grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);

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

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Anwser = myCBL4.Items[0].Value;
                    }

                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Anwser = myCBL5.Items[0].Value;
                    }

                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Anwser = myCBL6.Items[0].Value;
                    }

                    id = Convert.ToInt32(radio6grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }

                foreach (GridViewRow row in radio7grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);

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

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Anwser = myCBL4.Items[0].Value;
                    }

                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Anwser = myCBL5.Items[0].Value;
                    }

                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Anwser = myCBL6.Items[0].Value;
                    }

                    id = Convert.ToInt32(radio7grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }

                foreach (GridViewRow row in radio8grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);

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

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Anwser = myCBL4.Items[0].Value;
                    }

                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Anwser = myCBL5.Items[0].Value;
                    }

                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Anwser = myCBL6.Items[0].Value;
                    }

                    id = Convert.ToInt32(radio8grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }

                foreach (GridViewRow row in radio9grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);

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

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Anwser = myCBL4.Items[0].Value;
                    }

                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Anwser = myCBL5.Items[0].Value;
                    }

                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Anwser = myCBL6.Items[0].Value;
                    }

                    id = Convert.ToInt32(radio9grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }

                foreach (GridViewRow row in radio10grid.Rows)
                {
                    myCBL1 = (row.FindControl("cbloption1") as CheckBoxList);
                    myCBL2 = (row.FindControl("cbloption2") as CheckBoxList);
                    myCBL3 = (row.FindControl("cbloption3") as CheckBoxList);
                    myCBL4 = (row.FindControl("cbloption4") as CheckBoxList);
                    myCBL5 = (row.FindControl("cbloption5") as CheckBoxList);
                    myCBL6 = (row.FindControl("cbloption6") as CheckBoxList);

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

                    else if (myCBL4.Items[0].Selected == true)
                    {
                        Anwser = myCBL4.Items[0].Value;
                    }

                    else if (myCBL5.Items[0].Selected == true)
                    {
                        Anwser = myCBL5.Items[0].Value;
                    }

                    else if (myCBL6.Items[0].Selected == true)
                    {
                        Anwser = myCBL6.Items[0].Value;
                    }

                    id = Convert.ToInt32(radio10grid.DataKeys[row.RowIndex]["questionid"]);

                    Insert.Answers(id, Anwser);

                }

                

                Response.Redirect("Questionnaire_8.aspx");


            }
            catch (Exception ex)
            {
                lblerrormain.Text = ex.Message;
                lblerrormain.Visible = true;

            }

        }

    }
}