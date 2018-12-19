using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace OSCS{
    public partial class Patient : System.Web.UI.Page{

        InsertIntoDatabase Insert = new InsertIntoDatabase();

        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();

        protected void Page_Load(object sender, EventArgs e){
            if(!IsPostBack){
               txtusername.Attributes.Add("onblur", "checkIDAvailability();");
            }
        }


        public string CheckUserName(string IDVal){
            string result = string.Empty;

            DataTable dt = connection.SqlDataTable("Select username from registeredpatient where username = @username and status= 'Enable'", new Dictionary<string, object>{
                { "username", IDVal.Trim() },
            }   );

            if (dt.Rows.Count > 0){
                result = "ID already in use and has been activated";
            }

            else{
                result = "ID is available, you can use it";
            }

            return result;
        }

        protected void btnSubmit_Click(object sender, EventArgs e){
            try{
                lblerrormain.Visible = false;
                Insert.Patient(txtname.Text, txtusername.Text, txtemail.Text, decbirth.SelectedValue, postal.Text, ddlgender.SelectedValue, txtpassword.Text);

                //    string act = "http://localhost:50162/Activate.aspx?token=" + Guid.NewGuid();
                //    cmdtxt = "insert into Verify(Username, VerificationCode, VerificationDate) values ('" + txtusername.Text + "', '" + act + "', now())";
                //    if(connection.AUD(cmdtxt)==true){
                //        SendMail(txtemail.Text, "Please Click at the link below <Br /> " + act, "Verification OSCS Mail");
                //        ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('To Activiate Your Account, Verification Email sent to your mailbox');", true);
                //        Response.Redirect("~/index.aspx");
                //    }
                Response.Redirect("~/index.aspx");
                }
            catch(Exception ex){
                lblerrormain.Text = ex.Message;
                lblerrormain.Visible = true;
            }
        }

        //private void SendMail(string email, string body, string subject ){
        //    try{
        //        //MailMessage objeto_mail = new MailMessage();
        //        //SmtpClient client = new SmtpClient();
        //        //client.Port = 587;
        //        //client.Host = "mail.shabakkat.com";
        //        //client.Timeout = 10000;
        //        //client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        //client.UseDefaultCredentials = false;
        //        //client.Credentials = new System.Net.NetworkCredential("ahuda", "Al!81Nouf");
        //        //objeto_mail.From = new MailAddress("Ali.Huda@Shabakkat.com");
        //        //objeto_mail.To.Add(new MailAddress(email));
        //        //objeto_mail.Subject =subject;
        //        //objeto_mail.Body = body;
        //        //client.Send(objeto_mail);

        //        MailMessage mail =
        //       new MailMessage(
        //           "OSCS_CSI4900@hotmail.com",
        //           email,
        //           subject,
        //           body);

        //        // DEFINE HOTMAIL SMTP MAIL SERVER ALONG WITH A PORT (587 IN THIS CASE)
        //        // USING SmtpClient() CLASS.
        //        SmtpClient client = new SmtpClient("smtp.live.com", 587);
        //        client.UseDefaultCredentials = true;

        //        // NETWORK CREADENTIALS. 
        //        // YOUR HOTMAIL ID ALONG WITH THE PASSWORD. 
        //        // NOTE: CHANGE THE STRING "your_hotmail_password" 
        //        // WITH A VALID HOTMAIL PASSWORD.
        //        NetworkCredential credentials =
        //            new NetworkCredential("OSCS_CSI4900@hotmail.com", "OSCSCSI4900!");

        //        client.Credentials = credentials;
        //        client.EnableSsl = true;
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        //        client.Send(mail);          // FINALLY, SEND THE MAIL.
        //    }

        //    catch (Exception ex){
        //        lblerrormain.Text = ex.Message;
        //        lblerrormain.Visible = true;
        //    }
        //}
    }
}