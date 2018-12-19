using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace OSCS
{
    public class Globel{
        
        public static int[] array_text;
        public static int[] array_yesno;
        public static int[] array_radio1;
        public static int[] array_radio2;
        public static int[] array_radio3;
        public static int[] array_radio4;
        public static int[] array_radio5;
        public static int[] array_radio6;
        public static int[] array_radio7;
        public static int[] array_radio8;
        public static int[] array_radio9;
        public static int[] array_radio10;
        public static int[] array_radio11;

        public static int[] array_checkbox1;
        public static int[] array_checkbox2;
        public static int[] array_checkbox3;
        public static int[] array_checkbox4;

        public static string[] answers;

        public static int registeredpatientID = 0;
        public static string hospitalpatientID = "0";

        public static int administrator = 0;


        public static string errormessage;

        public static string clname;


        public static System.DateTime dt = System.DateTime.Today;

        public static int EQMobility = 0;
        public static int EQPain = 0;

        public static int MoreInLegs = 0;

        public static int LeftLegPainScale = 0;
        public static int RightLegPainScale = 0;
        public static int LegPainScale = 0;
        public static int BackPainScale = 0;

        public static int PreferLegTreat = 0;

        public static int ManyLegAnswers = 0;

        public static int NotImprovingWorse = 0;

        public static int walkstandpain = 0;

        public static int sitbendpain = 0;



        ///''''''''''''''''''+++++ For Sending Mail Purpose+++++++++++++++'''''''''''''


        public static string MTO;

        public static string MFROM = "btf@protiviti.com";

        public static string Subject;

        public static string body;

        public static string ATT1;

        public static string CC;
        public static string Stat;

        //Fill Main Page Emp
        public static bool EmailAddressCheck(string emailAddress){
            bool functionReturnValue = false;
            string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            Match emailAddressMatch = Regex.Match(emailAddress, pattern);
            if (emailAddressMatch.Success)
            {
                functionReturnValue = true;
            }
            else
            {
                functionReturnValue = false;
            }
            return functionReturnValue;
        }


        public static bool IsDouble(string text)
        {
            Double num = 0;
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            isDouble = Double.TryParse(text, out num);

            return isDouble;
        }

        public static bool IsInteger(object Expression)
        {

            // RegexOptions options = (RegexOptions.Multiline | RegexOptions.IgnoreCase);

            //Dim pNumericRegex As New Regex("^(-|[0-9])[0-9]{" & Expression.ToString.Length - 1 & "}")
            Regex pNumericRegex = new Regex("^[0-9]*[.]?[0-9]+$");

            Match m = pNumericRegex.Match(Expression.ToString());

            if (m.Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }



        public static Int16 getMonthDayGlo(Int16 mo)
        {

            try
            {
                if (mo == 1)
                {
                    return 31;
                }
                else if (mo == 2)
                {

                    Int16 dyr = Convert.ToInt16(dt.Year);
                    if ((dyr / 4) == 0)
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }
                }
                else if (mo == 3)
                {
                    return 31;
                }
                else if (mo == 4)
                {
                    return 30;
                }
                else if (mo == 5)
                {
                    return 31;
                }
                else if (mo == 6)
                {
                    return 30;
                }
                else if (mo == 7)
                {
                    return 31;
                }
                else if (mo == 8)
                {
                    return 31;

                }
                else if (mo == 9)
                {
                    return 30;
                }
                else if (mo == 10)
                {
                    return 31;
                }
                else if (mo == 11)
                {
                    return 30;
                }
                else if (mo == 12)
                {
                    return 31;
                }

                else
                    return 0;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }



        public Globel()
        {
            //
            // TODO: Add constructor logic here
            //
        }




    }

}