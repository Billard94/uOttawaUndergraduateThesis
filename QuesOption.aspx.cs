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
    public partial class QuesOption : System.Web.UI.Page
    {
        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        String cmdtxt;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Globel.administrator == 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('" + "You do not have access to this page... redirected to homepage." + "');");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                Response.Redirect("~/index.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    Fillgrid();
                    Fillquestions();
                }
            }
            
        }



        private void Fillgrid()
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
                cmd.CommandText = "Select questionsoption.optionid, questionsoption.optiondescription, questions.questiondescription from questionsoption, questions where questionsoption.questionid = questions.questionid";
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
                cmd.CommandText = "Select questionsoption.optionid, questionsoption.optiondescription, questions.questiondescription from questionsoption, questions where questionsoption.questionid = questions.questionid and  CONCAT_WS('|',`optiondescription`,`questiondescription`) LIKE '%" + txtsearch.Text + "%' ";
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try

            {
                if (e.CommandName != "Sort")
                {
                    int index = ((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex;


                    if (e.CommandName.Equals("editRecord"))
                    {

                        fillUpdateLocation();
                        GridViewRow gvrow = GridView1.Rows[index];
                        txtuid.Text = GridView1.DataKeys[index].Value.ToString();
                        txtuoption.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
                        Globel.clname = txtuoption.Text;

                        ddluquestions.ClearSelection(); //making sure the previous selection has been cleared
                        ddluquestions.Items.FindByText(HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString()).Selected = true;

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();

                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#editModal').modal('show');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                    }

                    else if (e.CommandName.Equals("deleteRecord"))
                    {
                        string code = GridView1.DataKeys[index].Value.ToString();
                        hfCode.Value = code;
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                lbldelete.Visible = false;

                string code = hfCode.Value;

                if (code == "")
                {
                    MsgBox("Are You Sure Delete Option");
                }
                else
                {

                    cmdtxt = "Delete from questionsoption where optionid = '" + code + "'";

                    if (connection.AUD(cmdtxt) == true)
                    {

                        Fillgrid();

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#deleteModal').modal('hide');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                    }

                    else
                    {

                        lbldelete.Text = Globel.errormessage + ", Please Contact System Administrator!!";
                        lbldelete.Visible = true;

                    }
                }
            }
            catch (MySqlException ex)
            {


                lbldelete.Text = ex.Message + ", Please Contact System Administrator!!";
                lbldelete.Visible = true;
            }

            catch (Exception ex)
            {

                lbldelete.Text = ex.Message + ", Please Contact System Administrator!!";
                lbldelete.Visible = true;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //fillLocation();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#addModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
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
            Fillgrid();
        }

        private void Fillquestions()
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
                cmd.CommandText = "select questionid, questiondescription from questions";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                ddlquestions.DataSource = dt;
                ddlquestions.DataTextField = "questiondescription";
                ddlquestions.DataValueField = "questionid";

                ddlquestions.DataBind();
                ddlquestions.Items.Insert(0, new ListItem("questions", "0"));

                connection.closeconnection();



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



        private void fillUpdateLocation()
        {
            try
            {
                lblResult.Visible = false;

                DataSet ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed)
                {
                    connection.openconnection();

                }


                cmd.Connection = connection.connection;
                cmd.CommandText = "select questionid, questiondescription from questions ";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                ddluquestions.DataSource = dt;
                ddluquestions.DataTextField = "questiondescription";
                ddluquestions.DataValueField = "questionid";

             

                ddluquestions.DataBind();

                connection.closeconnection();
                ddluquestions.Items.Insert(0, new ListItem("questions", "0"));


            }

            catch (MySqlException ex)
            {

                lblResult.Text = ex.Message + ", Please Contact System Administrator!!";
                lblResult.Visible = true;
            }
            catch (Exception ex)
            {

                lblResult.Text = ex.Message + ", Please Contact System Administrator!!";
                lblResult.Visible = true;
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                lblResult.Visible = false;

                if (CheckUP() == false) { }


                else
                {

                    txtuoption.Text = txtuoption.Text.Replace("'", "''");


                    cmdtxt = "Update questionsoption set optiondescription = '" + txtuoption.Text + "', questionid='" + ddluquestions.SelectedValue + "' where optionid = " + txtuid.Text + "";

                    if (connection.AUD(cmdtxt) == true)
                    {

                        Fillgrid();





                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#editModal').modal('hide');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
                    }
                    else
                    {

                        lblResult.Text = Globel.errormessage + ", Please Contact System Administrator!!";
                        lblResult.Visible = true;
                    }
                }
            }

            catch (MySqlException ex)
            {

                lblResult.Text = ex.Message + ", Please Contact System Administrator!!";
                lblResult.Visible = true;
            }

            catch (Exception ex)
            {
                lblResult.Text = ex.Message + ", Please Contact System Administrator!!";
                lblResult.Visible = true;
            }
        }

        protected void btnAddRecord_Click(object sender, EventArgs e)
        {
            try
            {

                lblerror.Visible = false;

                Globel.clname = "ADD";

                if (CheckUP() == false) { }


                else
                {

                    txtcdesc.Text = txtcdesc.Text.Replace("'", "''");





                    cmdtxt = "insert into questionsoption (optiondescription, questionid) Values('" + txtcdesc.Text + "', '" + ddlquestions.SelectedValue + "')";

                    if (connection.AUD(cmdtxt) == true)
                    {

                        Fillgrid();


                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#addModal').modal('hide');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
                    }

                    else
                    {
                        lblerror.Text = Globel.errormessage + ", Please Contact System Administrator!!";
                        lblerror.Visible = true;

                    }
                }
            }

            catch (MySqlException ex)
            {

                lblerror.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerror.Visible = true;
            }

            catch (Exception ex)
            {
                lblerror.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerror.Visible = true;
            }
        }

        private bool CheckUP()

        {
            try
            {
                if (Globel.clname == "ADD")
                {

                    if ((txtcdesc.Text == ""))
                    {
                        MsgBox("Please Enter Option ");
                        return false;
                    }


                    else if (ddlquestions.SelectedIndex == 0)
                    {
                        MsgBox("Please Select questions for Option");
                        return false;
                    }

                }
                else
                {
                    if ((txtuoption.Text == ""))
                    {
                        MsgBox("Please Enter Option For questions");
                        return false;
                    }

                    else if (ddluquestions.SelectedIndex == 0)
                    {
                        MsgBox("Please Select questions");
                        return false;
                    }
                }

                String chkname = "";
                if (Globel.clname == "ADD")
                {
                    chkname = txtcdesc.Text;
                }
                else { chkname = txtuoption.Text; }
                if ((Globel.clname == "ADD") || (Globel.clname != txtuoption.Text))
                {
                   if( Globel.clname == "ADD")
                    {
                        cmdtxt = "Select optiondescription from questionsoption where optiondescription = '" + chkname + "' and questionid = '" + ddlquestions.SelectedValue + "'";
                    }
else
                    {
                        cmdtxt = "Select optiondescription from questionsoption where optiondescription = '" + chkname + "'  and questionid = '" + ddluquestions.SelectedValue + "'";

                    }


                    String userid = connection.getString(cmdtxt);

                    if (userid != "NO12@")
                    {

                        MsgBox("Option Already Exists");

                        return false;


                    }

                    else
                    {

                        return true;
                    }

                }
                else
                {
                    return true;
                }
            }

            catch (MySqlException ex)
            {

                return false;
            }
            catch (Exception ex)
            {

                return false;
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