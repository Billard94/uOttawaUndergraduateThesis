using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace OSCS
{
    public partial class Activate : System.Web.UI.Page
    {
        private string url = HttpContext.Current.Request.Url.AbsoluteUri;
        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        String cmdtxt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cmdtxt = "Update registeredpatient t, verify V set t.verificationstatus  = 'Enable' where t.username = v.username and V.verificationcode = '" + url + "' ";
                if (connection.AUD(cmdtxt))
                {


                    System.Threading.Thread.Sleep(5000);
                    lblerrormain.Text = "Thank You for Verification, you will be redirected to the questionnaire";
                    lblerrormain.Visible = true;
                    Response.Redirect("~/Questionnaire_1.aspx");

                }



            }
        }
    }
}