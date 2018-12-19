using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OSCS
{
    public partial class Administrator : System.Web.UI.Page
    {
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

        }

        protected void btnQuestion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Questions.aspx");
        }



        protected void btnOption_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuesOption.aspx");
        }

        protected void btnPatients_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllPatients.aspx");
        }

        protected void btnAnswers_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAllAnswers.aspx");
        }

    }
}