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
    public partial class questions : System.Web.UI.Page
    {

        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        String cmdtxt;
        MySqlDataReader reader;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e){
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
                    fillgrid();
                }
            }
        }

        private void fillgrid(){
            try{
                lblerrormain.Visible = false;

                DataSet ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed){
                    connection.openconnection();
                }

                cmd.Connection = connection.connection;
                cmd.CommandText = "Select questionid, questiondescription, questiontype, questiongroup, questionorder from questions ";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.GridView1.DataSource = dt;
                GridView1.DataBind();
                connection.closeconnection();

                if (GridView1.Rows.Count > 0){
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

        private void MsgBox(String msg){
            string message = msg;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('" + message + "');");
            sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", sb.ToString(), false);
        }

        protected void btnsearch_Click(object sender, EventArgs e){
            try{
                lblerrormain.Visible = false;
                txtsearch.Text = txtsearch.Text.Replace("'", "''");
                DataSet ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed){
                    connection.openconnection();
                }
                cmd.Connection = connection.connection;
                cmd.CommandText = "Select questionid, questiondescription, questiontype, questiongroup, questionorder from questions where   CONCAT_WS('|',`questiondescription`,`questiontype`,`questionid`) LIKE '%" + txtsearch.Text + "%' ";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.GridView1.DataSource = dt;
                GridView1.DataBind();
                connection.closeconnection();
                if (GridView1.Rows.Count > 0){
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e){
            try{
                if (e.CommandName != "Sort"){
                    int index = ((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex;
                    if (e.CommandName.Equals("editRecord")){
                        GridViewRow gvrow = GridView1.Rows[index];
                        txtuid.Text = GridView1.DataKeys[index].Value.ToString();
                        txtucode.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();
                       
                        ddlutype.ClearSelection(); //making sure the previous selection has been cleared
                        ddlutype.Items.FindByText(HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString()).Selected = true;

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();

                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#editModal').modal('show');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                    }

                    else if (e.CommandName.Equals("deleteRecord")){
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

            catch (MySqlException ex){
                MsgBox(ex.Message);
            }
            catch (Exception ex){
                MsgBox(ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e){
            try{
                lbldelete.Visible = false;
                string code = hfCode.Value;
                if (code == ""){
                    MsgBox("Are you sure you want to delete this questions?");
                }
                else{
                    cmdtxt = "Delete from questions where questionid = '" + code + "'";
                    if (connection.AUD(cmdtxt) == true){
                        fillgrid();
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#deleteModal').modal('hide');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
                    }

                    else{
                        lbldelete.Text = Globel.errormessage + ", Please Contact System Administrator!!";
                        lbldelete.Visible = true;
                    }
                }
            }
            catch (MySqlException ex){
                lbldelete.Text = ex.Message + ", Please Contact System Administrator!!";
                lbldelete.Visible = true;
            }

            catch (Exception ex){
                lbldelete.Text = ex.Message + ", Please Contact System Administrator!!";
                lbldelete.Visible = true;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e){
            try{
                //fillLocation();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#addModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

                //Response.Redirect("~/AddUsers.aspx");
            }

            catch (MySqlException ex){
                MsgBox(ex.Message);
            }

            catch (Exception ex){
                MsgBox(ex.Message);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e){
            GridView1.PageIndex = e.NewPageIndex;
            fillgrid();
        }

        protected void btnSave_Click(object sender, EventArgs e){
            try{
                lblResult.Visible = false;

                if (CheckUP() == false) { }

                else{
                    txtucode.Text = txtucode.Text.Replace("'", "''");
                    cmdtxt = "Update questions set questiondescription = '" + txtucode.Text + "', questiontype='" + ddlutype.Text + "' where questionid = " + txtuid.Text + "";
                    if (connection.AUD(cmdtxt) == true){
                        fillgrid();
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#editModal').modal('hide');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
                    }
                    else{
                        lblResult.Text = Globel.errormessage + ", Please Contact System Administrator!!";
                        lblResult.Visible = true;
                    }
                }
            }

            catch (MySqlException ex){
                lblResult.Text = ex.Message + ", Please Contact System Administrator!!";
                lblResult.Visible = true;
            }

            catch (Exception ex){ 
                lblResult.Text = ex.Message + ", Please Contact System Administrator!!";
                lblResult.Visible = true;
            }
        }

        protected void btnAddRecord_Click(object sender, EventArgs e){
            try{
                lblerror.Visible = false;
                Globel.clname = "ADD";
                if (CheckUP() == false) { }

                else{
                    txtccode.Text = txtccode.Text.Replace("'", "''");
                    txtorder.Text = txtorder.Text.Replace("'", "''");
                   
                    cmdtxt = "insert into questions (questiondescription, questiontype, questiongroup, questionorder) Values('" + txtccode.Text + "','" + ddltype.Text + "','" + ddlgroup.Text + "','" + txtorder.Text + "')";

                    if (connection.AUD(cmdtxt) == true){
                        fillgrid();

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#addModal').modal('hide');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
                    }

                    else{
                        lblerror.Text = Globel.errormessage + ", Please Contact System Administrator!!";
                        lblerror.Visible = true;
                    }
                }
            }

            catch (MySqlException ex){
                lblerror.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerror.Visible = true;
            }

            catch (Exception ex){
                lblerror.Text = ex.Message + ", Please Contact System Administrator!!";
                lblerror.Visible = true;
            }
        }

        private bool CheckUP(){
            try{
                if (Globel.clname == "ADD"){
                    if ((txtccode.Text == "")){
                        MsgBox("Please Enter questions");
                        return false;
                    }
                    else if (ddltype.SelectedIndex == 0){
                        MsgBox("Please Select Type");
                        return false;
                    }
                }
                else{
                    if ((txtucode.Text == "")){
                        MsgBox("Please Enter questions");
                        return false;
                    }
                    else if (ddlutype.SelectedIndex == 0){
                        MsgBox("Please Select Type");
                        return false;
                    }
                }

                String chkname = "";
                if (Globel.clname == "ADD"){
                    chkname = txtccode.Text;
                }
                else { chkname = txtucode.Text; }
                if ((Globel.clname == "ADD") || (Globel.clname != txtucode.Text)){
                    cmdtxt = "Select questiondescription from questions where questiondescription = '" + chkname + "'";
                    String userid = connection.getString(cmdtxt);
                    if (userid != "NO12@"){
                        
                        MsgBox("questions Already Exists");
                        return false;
                    }
                    else{
                        return true;
                    }
                }
                else{
                    return true;
                }
            }

            catch (MySqlException ex){
                return false;
            }
            catch (Exception ex){
                return false;
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

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e){
            DataTable dt = Session["MAINSORTING"] as DataTable;

            if (dt != null){
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridView1.DataSource = Session["MAINSORTING"];
                GridView1.DataBind();
            }
        }
    }
}