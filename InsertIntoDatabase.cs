using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;

namespace OSCS{
    public class InsertIntoDatabase{
        BTDBCLASS connection = new BTDBCLASS();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = null;
        String cmdtxt;
        DataTable dt;

        int question_count = 0;

        public InsertIntoDatabase()
        {
            DataSet ds = new DataSet();
            if (connection.connection.State == ConnectionState.Closed) { connection.openconnection(); }

            cmd.Connection = connection.connection;
            cmd.CommandText = "Select count(*) from Questions";
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            connection.closeconnection();

            question_count = (Convert.ToInt32(dt.Rows[0][0]));
            Globel.answers = new string[question_count];
        }

        bool contains = false;
        //int hospitalpatientID = 0;
        string name = "";
        string username;
        string email;
        string decbirth;
        string postal;
        string gender;
        string password;
        int mailID = 0;


        public void Patient(string name, string username, string email, string decbirth, string postal, string gender, string password){
            this.name = name;
            this.username = username;
            this.email = email;
            this.decbirth = decbirth;
            this.postal = postal;
            this.gender = gender;
            this.password = password;


            DataSet ds = new DataSet();
            if (connection.connection.State == ConnectionState.Closed) { connection.openconnection(); }

            cmd.Connection = connection.connection;
            cmd.CommandText = "Select RegisteredPatientID from registeredpatient order by RegisterDate DESC";
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            connection.closeconnection();

           
            if (dt.Rows.Count == 0) { Globel.registeredpatientID = 1; }
            else{
                Globel.registeredpatientID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                //var test = (int)dt.Rows[0][0];
                //System.Diagnostics.Debug.WriteLine((int.Parse(dt.Rows[0][0].ToString())+1).GetType());

                //System.Diagnostics.Debug.WriteLine("PatientID");
                //System.Diagnostics.Debug.WriteLine(dt.Rows[0][0].GetType());
                //System.Diagnostics.Debug.WriteLine(dt.Rows[0][0]);

                System.Diagnostics.Debug.WriteLine(Globel.registeredpatientID);

                //patientID = (int)dt.Rows[0][0] + 1;

                //patientID = (int.Parse(dt.Rows[0][0].ToString().Trim())) + 1);

                //patientID = int.Parse(dt.Rows[0][0].ToString()) + 1;
                //patientID = 1000;
                ds = new DataSet();
                if (connection.connection.State == ConnectionState.Closed) { connection.openconnection(); }
                cmd.Connection = connection.connection;
                cmd.CommandText = "Select username from registeredpatient";
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                connection.closeconnection();

                contains = dt.AsEnumerable().Any(row => username == row.Field<String>("username"));
            }

            ds = new DataSet();
            if (connection.connection.State == ConnectionState.Closed) { connection.openconnection(); }

            cmd.Connection = connection.connection;
            cmd.CommandText = "Select mailID from mail order by mailID";
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            connection.closeconnection();

            if (dt.Rows.Count == 0) { mailID = 1; }
            else
            {
                //System.Diagnostics.Debug.WriteLine(int.Parse(dt.Rows[0][0].ToString()) + 1);
                //System.Diagnostics.Debug.WriteLine("MailID");
                mailID = Convert.ToInt32(dt.Rows[0][0]) + 1;

                System.Diagnostics.Debug.WriteLine(mailID);
                // mailID = int.Parse(dt.Rows[0][0].ToString()) + 1;

                //mailID = int.Parse(dt.Rows[0][0].ToString().Trim()) + 1;
                //mailID = 1000;
            }

            if (contains)
            {
                //resend email for confirmation

                cmdtxt = "update registeredpatient " +
                         "set registeredpatientID = '" + Globel.registeredpatientID + "', mailID = '" + mailID + "', gender = '" + gender + "', VerificationStatus = 'DISABLE'" +
                           ", password = '" + Globel.Encrypt(password) + "', DecadeOfBirth = '" + decbirth + "', postalCodeHome = '" + postal + "', registerDate = now() " +
                         " where username = '" + username + "'";

            }
            else
            {
                cmdtxt = "insert into registeredpatient Values ('" + username + "', '" +
                                                                     Globel.registeredpatientID + "', '" +
                                                                     mailID + "', '" + //mailID
                                                                     gender + "', '" +
                                                                     "DISABLE', '" +
                                                                     Globel.Encrypt(password) + "', '" +
                                                                     decbirth + "', '" +
                                                                     postal + "', " +
                                                                     "now(), " +
                                                                     "NULL, " + //RequiresSurgery?
                                                                     "NULL" + //DoctorAgrees?
                                                                     " )";
            }

            System.Diagnostics.Debug.WriteLine(cmdtxt);
            //if (connection.AUD(cmdtxt)) { }


            if (connection.AUD(cmdtxt) == true)
            {
                string act = "http://localhost:50162/Activate.aspx?token=" + Guid.NewGuid();
                cmdtxt = "insert into Verify(Username, VerificationCode, VerificationDate) values ('" + username + "', '" + act + "', now())";
                System.Diagnostics.Debug.WriteLine(cmdtxt);
                if (connection.AUD(cmdtxt) == true)
                {
                    SendMail(email, "Please Click at the link below: \n\n " + act, " Verification OSCS Mail", mailID);
                    
                }
            }
        }

        private void SendMail(string email, string body, string subject, int mailID){
        
                MailMessage mail =
               new MailMessage(
                   "OSCS_CSI4900@hotmail.com",
                   email,
                   subject,
                   body);

                // DEFINE HOTMAIL SMTP MAIL SERVER ALONG WITH A PORT (587 IN THIS CASE)
                // USING SmtpClient() CLASS.
                SmtpClient client = new SmtpClient("smtp.live.com", 587);
                client.UseDefaultCredentials = true;

                // NETWORK CREADENTIALS. 
                // YOUR HOTMAIL ID ALONG WITH THE PASSWORD. 
                // NOTE: CHANGE THE STRING "your_hotmail_password" 
                // WITH A VALID HOTMAIL PASSWORD.
                NetworkCredential credentials =
                    new NetworkCredential("OSCS_CSI4900@hotmail.com", "OSCSCSI4900!");

                client.Credentials = credentials;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                cmdtxt = "insert into mail " +
                               " Values ('" + mailID + "', '" + //mailID
                                             "OSCS_CSI4900@hotmail.com', '" +
                                             email + "', '" +
                                             subject + "', '" +
                                             body + "', '" +
                                             "NULL" + "', '" +
                                             "Delivered'," +
                                             "now()" +
                                             ")";
            System.Diagnostics.Debug.WriteLine(cmdtxt);
            if (connection.AUD(cmdtxt)) { }

            client.Send(mail);          // FINALLY, SEND THE MAIL.
        }
        //CREATE A MONSTER ARRAY THAT WOULD ESSENTIALLY HOLD ALL ANSWERS
        //Globel.answers = new string[SIZE OF THE COUNT OF ALL questions]; CREATE IN CONSTRUCTOR; maybe a dictionarry would be good have the questionid as the keys

        
        public void HospitalID(string H_ID)
        {
            Globel.hospitalpatientID = H_ID;
            Globel.registeredpatientID = 0;
            System.Diagnostics.Debug.WriteLine("registeredpatientID=" + Globel.registeredpatientID + ",  hospitalpatientID= " + Globel.hospitalpatientID);


        }

        //Dictionary<int, string> dict = new Dictionary<int, string>();
        int i = 0;
        public void Answers(int questionid, string Answers)
        {
            System.Diagnostics.Debug.WriteLine(questionid +", " + Answers);
            //dict.Add(new KeyValuePair<int, string>(questionid, Answers));
            //dict.Add(questionid, Answers);

            //System.Diagnostics.Debug.WriteLine(questionid + ", " + Answers);

            System.Diagnostics.Debug.WriteLine(Globel.registeredpatientID);
            System.Diagnostics.Debug.WriteLine(Globel.hospitalpatientID);
            if (Globel.registeredpatientID != 0){
                cmdtxt = "INSERT INTO Answers (RegisteredPatientID, HospitalPatientID, QuestionID, Answer, AnswerDate) VALUES (" + Globel.registeredpatientID +",NULL,"+questionid + ",'"+ Answers+"', now())";
            }
            else if (Globel.hospitalpatientID != "0"){
                cmdtxt = "INSERT INTO Answers (RegisteredPatientID, HospitalPatientID, QuestionID, Answer, AnswerDate) VALUES (NULL, '" + Globel.hospitalpatientID + "'," + questionid + ",'" + Answers + "', now())";
            }
            else if (Globel.hospitalpatientID == "0" && Globel.registeredpatientID == 0)
            {
                Globel.answers[questionid - 1] = Answers;
            }

            System.Diagnostics.Debug.WriteLine(cmdtxt);
            if (connection.AUD(cmdtxt)) { }    
        }

        public void printDict()
        {
            
            foreach(string item in Globel.answers)
            {
                System.Diagnostics.Debug.WriteLine( i + ":" + Globel.answers[i]);
                i++;
            }
        }


        public void Keele(int id, int score, string sname){

            System.Diagnostics.Debug.WriteLine(id + ", " + score + "',now() ,'" + sname );
        }

        public void PHQ9(int id, int score, string sname)
        {
            System.Diagnostics.Debug.WriteLine(id + ", " + score + "',now() ,'" + sname);
        }

        public void UpdatePatient()
        {
            if (Globel.EQMobility == 1 && Globel.EQPain == 1)
            {
                if (Globel.LegPainScale > Globel.BackPainScale && Globel.PreferLegTreat == 1 && Globel.NotImprovingWorse == 1)
                {

                    if (Globel.registeredpatientID != 0)
                    {
                        cmdtxt = "update registeredpatient set RequireSurgery = 1 where RegisteredPatientID = '" + Globel.registeredpatientID + "'";
                    }
                    else if (Globel.hospitalpatientID != "0")
                    {
                        cmdtxt = "update hospitalpatient set RequireSurgery = 1 where HospitalPatientID = '" + Globel.hospitalpatientID + "'";
                    }

                    System.Diagnostics.Debug.WriteLine(cmdtxt);
                    if (connection.AUD(cmdtxt)) { }

                    System.Diagnostics.Debug.WriteLine("GETTING SURGERY");

                }
                else if (Globel.MoreInLegs == 1 && Globel.PreferLegTreat == 1 && Globel.NotImprovingWorse == 1)
                {
                    if (Globel.registeredpatientID != 0)
                    {
                        cmdtxt = "update registeredpatient set RequireSurgery = 1 where RegisteredPatientID = '" + Globel.registeredpatientID + "'";
                    }
                    else if (Globel.hospitalpatientID != "0")
                    {
                        cmdtxt = "update hospitalpatient set RequireSurgery = 1 where HospitalPatientID = '" + Globel.hospitalpatientID + "'";
                    }

                    System.Diagnostics.Debug.WriteLine(cmdtxt);
                    if (connection.AUD(cmdtxt)) { }

                    System.Diagnostics.Debug.WriteLine("GETTING SURGERY");
                }
                else if (Globel.MoreInLegs == 1 && Globel.LegPainScale > Globel.BackPainScale && Globel.NotImprovingWorse == 1)
                {
                     if (Globel.registeredpatientID != 0)
                    {
                        cmdtxt = "update registeredpatient set RequireSurgery = 1 where RegisteredPatientID = '" + Globel.registeredpatientID + "'";
                    }
                    else if (Globel.hospitalpatientID != "0")
                    {
                        cmdtxt = "update hospitalpatient set RequireSurgery = 1 where HospitalPatientID = '" + Globel.hospitalpatientID + "'";
                    }

                    System.Diagnostics.Debug.WriteLine(cmdtxt);
                    if (connection.AUD(cmdtxt)) { }

                    System.Diagnostics.Debug.WriteLine("GETTING SURGERY");
                }

                

                else
                {
                    if (Globel.registeredpatientID != 0)
                    {
                        cmdtxt = "update registeredpatient set RequireSurgery = 0 where RegisteredPatientID = '" + Globel.registeredpatientID + "'";
                    }
                    else if (Globel.hospitalpatientID != "0")
                    {
                        cmdtxt = "update hospitalpatient set RequireSurgery = 0 where HospitalPatientID = '" + Globel.hospitalpatientID + "'";
                    }

                    System.Diagnostics.Debug.WriteLine(cmdtxt);
                    if (connection.AUD(cmdtxt)) { }

                    System.Diagnostics.Debug.WriteLine("NOT GETTING SURGERY");
                }
            }
            else
            {
                if (Globel.registeredpatientID != 0)
                {
                    cmdtxt = "update registeredpatient set RequireSurgery = 0 where RegisteredPatientID = '" + Globel.registeredpatientID + "'";
                }
                else if (Globel.hospitalpatientID != "0")
                {
                    cmdtxt = "update hospitalpatient set RequireSurgery = 0 where HospitalPatientID = '" + Globel.hospitalpatientID + "'";
                }

                System.Diagnostics.Debug.WriteLine(cmdtxt);
                if (connection.AUD(cmdtxt)) { }

                System.Diagnostics.Debug.WriteLine("NOT GETTING SURGERY");
            }
        }



        }
    }