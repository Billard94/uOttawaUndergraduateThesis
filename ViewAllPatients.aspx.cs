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
    public partial class ViewAllPatients : System.Web.UI.Page
    {

        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        String cmdtxt;
        MySqlDataReader reader;
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
                    fillgrid();
                    fillgrid2();
                }
            }
        }

        private void fillgrid()
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
                cmd.CommandText = "Select r.username, r.registeredpatientid, m.to, r.gender, r.DecadeOfBirth, r.PostalCodeHome, r.RegisterDate, r.requiresurgery, r.doctoragrees " + 
                                  "from registeredpatient r, mail m " +
                                  "where m.MailID = r.MailID AND r.VerificationStatus = 'enable'";



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
            sb.Append("$('#addModal').modal('hide');");
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
                cmd.CommandText = "Select r.username, r.registeredpatientid, m.to, r.gender, r.DecadeOfBirth, r.PostalCodeHome, r.RegisterDate, r.requiresurgery, r.doctoragrees " +
                                  "from registeredpatient r, mail m " +
                                  "where m.MailID = r.MailID AND r.VerificationStatus = 'enable' AND CONCAT_WS('|',`username`,`registeredpatientid`,`to`, `gender`, `DecadeOfBirth`, `PostalCodeHome`, `RegisterDate`, `requiresurgery`, `doctoragrees`) LIKE '%" + txtsearch.Text + "%' ";
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
                        GridViewRow gvrow = GridView1.Rows[index];
                        //txtuid.Text = GridView1.DataKeys[index].Value.ToString();
                        //txtucode.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text).ToString();

                        //ddlutype.ClearSelection(); //making sure the previous selection has been cleared
                        //ddlutype.Items.FindByText(HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString()).Selected = true;

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();

                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#editModal').modal('show');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                    }

                    else if (e.CommandName.Equals("deleteRecord"))
                    {
                        string code = GridView1.DataKeys[index].Value.ToString();
                        // hfCode.Value = code;
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


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            fillgrid();
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






























        private void fillgrid2()
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
                cmd.CommandText = "select h.hospitalpatientid, m.to, h.requiresurgery, h.doctoragrees " + 
                                  "from hospitalpatient h, mail m " +
                                  "where h.mailid = m.mailid ";



                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.Gridview2.DataSource = dt;
                Gridview2.DataBind();
                connection.closeconnection();

                if (Gridview2.Rows.Count > 0)
                {
                    maindiv2.Visible = true;
                }
                else
                {
                    maindiv2.Visible = false;
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

        private void MsgBox1(String msg)
        {
            string message = msg;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('" + message + "');");
            sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", sb.ToString(), false);
        }

        protected void btnsearch2_Click(object sender, EventArgs e)
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
                cmd.CommandText = "select h.hospitalpatientid, m.to, h.requiresurgery, h.doctoragrees " +
                                  "from hospitalpatient h, mail m " +
                                  "where h.mailid = m.mailid AND CONCAT_WS('|',`hospitalpatientid`,`to`, `requiresurgery`, `doctoragrees`) LIKE '%" + txtsearch.Text + "%' ";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                Session["MAINSORTING"] = dt;
                this.Gridview2.DataSource = dt;
                Gridview2.DataBind();
                connection.closeconnection();
                if (Gridview2.Rows.Count > 0)
                {
                    maindiv2.Visible = true;
                }
                else
                {
                    maindiv2.Visible = false;
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

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName != "Sort")
                {
                    int index = ((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex;
                    if (e.CommandName.Equals("editRecord"))
                    {
                        GridViewRow gvrow = Gridview2.Rows[index];
                     

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();

                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#editModal').modal('show');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                    }

                    else if (e.CommandName.Equals("deleteRecord"))
                    {
                        string code = Gridview2.DataKeys[index].Value.ToString();
                        // hfCode.Value = code;
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


        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridview2.PageIndex = e.NewPageIndex;
            fillgrid2();
        }

       
        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["MAINSORTING"] as DataTable;

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                Gridview2.DataSource = Session["MAINSORTING"];
                Gridview2.DataBind();
            }
        }
    }
}
