using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ePacker1.App_Code
{
    class FunctionLib
    {
        //Page developed by Ashish And Avinash on(25/2/2011)
     

        //Function to check character Only   
        public void onlyCharacterPress(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Invalid Input");
                e.Handled = true;
            }
        }

        //Function to check Numeric Values
        public void onlyNumbers(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 32 || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 47 || e.KeyChar == 45)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Enter Number only");
                e.Handled = true;
            }
        }

        public void onlyNumbersnDot(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 32 || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {

                MessageBox.Show("Enter Number only");
                e.Handled = true;
            }
        }

        public void onlyNumbersnColun(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 32 || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 58)
            {
                e.Handled = false;
            }
            else
            {

                MessageBox.Show("Enter Number only");
                e.Handled = true;
            }
        }

        // only numeric no decimal
        public void onlyNumbers2(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {

                MessageBox.Show("Enter Number only");
                e.Handled = true;
            }
        }

        //Function to check Email Validation
        public bool emailValidation(string txtdata)
        {
            //str store textbox data
            string str = txtdata;
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                                                   //                      
            if (!rEmail.IsMatch(str))
            {
                MessageBox.Show("E-mail Expected", "Error", MessageBoxButtons.OK);
                return false;
                
            }
            else
            {
                return true;
            }

        }

        //Function to check Character,Special Char & numeric entry
        public void checkNumericChar(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8 || e.KeyChar == 40 || e.KeyChar == 41 || e.KeyChar == 47 || e.KeyChar == 35 || e.KeyChar == 63 || e.KeyChar == 61 || e.KeyChar == 38 || e.KeyChar == 44 || e.KeyChar == 45 || e.KeyChar == 58 || e.KeyChar == 46 || e.KeyChar == 95 || e.KeyChar == 60 || e.KeyChar == 62 || e.KeyChar == 34)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Invalid Input");
                e.Handled = true;
            }
           


        }

        //Function allow Char & Numeric value
        public void charNumber(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Invalid Input");
                e.Handled = true;
            }
        }

        //Function to check blank field
        public void checkBlank(string txtdata,CancelEventArgs e)
        {
            if (txtdata == "")
            {
                
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

        }

        //Function For Connecting to Database
        public string  setConnection()
        {
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            return strcon;
        }

        //Function for AutoKey Generation
        public string AutoKey(string var,SqlConnection con,string sqlquery)
        {
            string gids = "";
            int ctr = 0;
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            //retriving last Group Id
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            //AutoGenerating GroupId
            if (dr.Read())
            {
                string gid = dr[0].ToString();
                string sgid = (gid.Substring(1, 3));
                ctr = int.Parse(sgid);
            }
            if (ctr >= 1 && ctr < 9)
            {
                ctr = ctr + 1;
                gids= var + "00" + ctr;
            }
            else if (ctr >= 9 && ctr < 99)
            {
                ctr = ctr + 1;
                gids = var + "0" + ctr;
            }
            else if(ctr>=99 && ctr<999)
            {
                ctr=ctr+1;
                gids=var+ctr;
            }
            else if(ctr>=999 && ctr<9999)
            {
                ctr=ctr+1;
                gids=var+ctr;
            }
            else if(ctr==0)
            {
                gids=var+"001";
            }
            dr.Close();
            con.Close();
            return gids;

        }

        public string RowID(string var, SqlConnection con, string sqlquery)
        {
            string gids = "";
            int ctr = 0;
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            //retriving last Group Id
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            //AutoGenerating GroupId
            if (dr.Read())
            {
                string gid = dr[0].ToString();
                string sgid = (gid.Substring(1, 2));
                ctr = int.Parse(sgid);
            }
            if (ctr >= 1 && ctr < 9)
            {
                ctr = ctr + 1;
                gids = var + "0" + ctr;
            }
            else if (ctr >= 9 && ctr < 99)
            {
                ctr = ctr + 1;
                gids = var + ctr;
            }
            
            else if (ctr == 0)
            {
                gids = var + "01";
            }
            dr.Close();
            con.Close();
            return gids;

        }

        //Function for AutoKey Generation for Positive,Regiog ID
        public string AutoKey1(string var, SqlConnection con, string sqlquery)
        {
            string gids = "";
            int ctr = 0;
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            //retriving last Positive Id
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            //AutoGenerating Positive Id
            if (dr.Read())
            {
                string gid = dr[0].ToString();
                string sgid = (gid.Substring(2, 3));
                ctr = int.Parse(sgid);
            }
            if (ctr >= 1 && ctr < 9)
            {
                ctr = ctr + 1;
                gids = var + "00" + ctr;
            }
            else if (ctr >= 9 && ctr < 99)
            {
                ctr = ctr + 1;
                gids = var + "0" + ctr;
            }
            else if (ctr >= 99 && ctr < 999)
            {
                ctr = ctr + 1;
                gids = var + ctr;
            }
            else if (ctr >= 999 && ctr < 9999)
            {
                ctr = ctr + 1;
                gids = var +  ctr;
            }
            else if (ctr == 0)
            {
                gids = var + "001";
            }
            dr.Close();
            con.Close();
            return gids;

        }

        //Encrypting Password
        public string encryptData(string pdata)
        {
            byte[] encdata = new byte[pdata.Length];
            encdata=System.Text.Encoding.UTF8.GetBytes(pdata);
            string encodingdata=Convert.ToBase64String(encdata);
            return encodingdata;

        }

        //Function to Check for Duplicate values
        public double isThere(SqlConnection con, string sqlstr)
        {
            double flag = 0;
            if (con.State == ConnectionState.Open) con.Close();

            SqlCommand com = new SqlCommand(sqlstr, con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                flag = 1;
            }
            else
            {
                flag = 0;
            }
           dr.Close();
            con.Close();

            return flag;
        }

        //Counting charcter in field
        public int countChar(KeyPressEventArgs e,string strAddress)
        {
            char ch = e.KeyChar;
            int length = strAddress.Length;
            int c = length;
            if (c >= 200)
            {
                MessageBox.Show("Max Range is 200");
            }
            return c;
            

            
        }

        public string TopPaper(string var, SqlConnection con, string sqlstr)
        {
            string BIDs = "";
            double ctr = 0;
            // if(con.State == ConnectionState.Open)
            con.Open();
            SqlCommand com1 = new SqlCommand(sqlstr, con);
            // retrieving the last client ID
            SqlDataReader dr11;
            dr11 = com1.ExecuteReader();

            // AutoGenerating Client ID
            if (dr11.Read())
            {
                string Sid = dr11[0].ToString();
                string subSid = (Sid.Substring(2));

                ctr = double.Parse(subSid);
            }

            if (ctr >= 1 && ctr < 9)
            {
                ctr = ctr + 1;
                BIDs = var + "00000" + ctr;
            }
            else if (ctr >= 9 && ctr < 99)
            {
                ctr = ctr + 1;
                BIDs = var + "0000" + ctr;
            }
            else if (ctr >= 99 && ctr < 999)
            {
                ctr = ctr + 1;
                BIDs = var + "000" + ctr;
            }
            else if (ctr >= 999 && ctr < 9999)
            {
                ctr = ctr + 1;
                BIDs = var + "00" + ctr;
            }
            else if (ctr >= 9999 && ctr < 99999)
            {
                ctr = ctr + 1;
                BIDs = var + "00" + ctr;
            }
            else if (ctr >= 99999 && ctr < 999999)
            {
                ctr = ctr + 1;
                BIDs = var + ctr;
            }

            else if (ctr < 1)
            {
                BIDs = var + "000001";
            }

            dr11.Close();
            con.Close();

            return BIDs;
        }

        //Autokey generation for year id
        public string Year_ID(string var, SqlConnection con, string sqlstr)
        {
            string BIDs = "";
            double ctr = 0;
            // if(con.State == ConnectionState.Open)
            con.Open();
            SqlCommand com1 = new SqlCommand(sqlstr, con);
            // retrieving the last client ID
            SqlDataReader dr11;
            dr11 = com1.ExecuteReader();

            // AutoGenerating Client ID
            if (dr11.Read())
            {
                string Sid = dr11[0].ToString();
                string subSid = (Sid.Substring(8, 6));

                ctr = double.Parse(subSid);
            }

            if (ctr >= 1 && ctr < 9)
            {
                ctr = ctr + 1;
                BIDs = var + "00000" + ctr;
            }
            else if (ctr >= 9 && ctr < 99)
            {
                ctr = ctr + 1;
                BIDs = var + "0000" + ctr;
            }
            else if (ctr >= 99 && ctr < 999)
            {
                ctr = ctr + 1;
                BIDs = var + "000" + ctr;
            }
            else if (ctr >= 999 && ctr < 9999)
            {
                ctr = ctr + 1;
                BIDs = var + "00" + ctr;
            }
            else if (ctr >= 9999 && ctr < 99999)
            {
                ctr = ctr + 1;
                BIDs = var + "00" + ctr;
            }
            else if (ctr >= 99999 && ctr < 999999)
            {
                ctr = ctr + 1;
                BIDs = var + ctr;
            }

            else if (ctr < 1)
            {
                BIDs = var + "000001";
            }

            dr11.Close();
            con.Close();

            return BIDs;
        }

        //SI id
        public string SI_ID(string var, SqlConnection con, string sqlstr)
        {
            string BIDs = "";
            double ctr = 0;
            // if(con.State == ConnectionState.Open)
            con.Open();
            SqlCommand com1 = new SqlCommand(sqlstr, con);
            // retrieving the last client ID
            SqlDataReader dr11;
            dr11 = com1.ExecuteReader();

            // AutoGenerating Client ID
            if (dr11.Read())
            {
                string Sid = dr11[0].ToString();
                string subSid = (Sid.Substring(2, 8));

                ctr = double.Parse(subSid);
            }

            if (ctr >= 1 && ctr < 9)
            {
                ctr = ctr + 1;
                BIDs = var + "0000000" + ctr;
            }
            else if (ctr >= 9 && ctr < 99)
            {
                ctr = ctr + 1;
                BIDs = var + "000000" + ctr;
            }
            else if (ctr >= 99 && ctr < 999)
            {
                ctr = ctr + 1;
                BIDs = var + "00000" + ctr;
            }
            else if (ctr >= 999 && ctr < 9999)
            {
                ctr = ctr + 1;
                BIDs = var + "0000" + ctr;
            }
            else if (ctr >= 9999 && ctr < 99999)
            {
                ctr = ctr + 1;
                BIDs = var + "000" + ctr;
            }

            else if (ctr >= 99999 && ctr < 999999)
            {
                ctr = ctr + 1;
                BIDs = var + "00" + ctr;
            }

            else if (ctr >= 999999 && ctr < 9999999)
            {
                ctr = ctr + 1;
                BIDs = var + ctr;
            }

            else if (ctr < 1)
            {
                BIDs = var + "00000001";
            }

            dr11.Close();
            con.Close();

            return BIDs;
        }

        //I_ID      
        public string I_ID(string var, SqlConnection con, string sqlstr)
        {
            string BIDs = "";
            double ctr = 0;
            // if(con.State == ConnectionState.Open)
            con.Open();
            SqlCommand com1 = new SqlCommand(sqlstr, con);
            // retrieving the last client ID
            SqlDataReader dr11;
            dr11 = com1.ExecuteReader();

            // AutoGenerating Client ID
            if (dr11.Read())
            {
                string Sid = dr11[0].ToString();
                string subSid = (Sid.Substring(1, 9));

                ctr = double.Parse(subSid);
            }

            if (ctr >= 1 && ctr < 9)
            {
                ctr = ctr + 1;
                BIDs = var + "00000000" + ctr;
            }
            else if (ctr >= 9 && ctr < 99)
            {
                ctr = ctr + 1;
                BIDs = var + "0000000" + ctr;
            }
            else if (ctr >= 99 && ctr < 999)
            {
                ctr = ctr + 1;
                BIDs = var + "000000" + ctr;
            }
            else if (ctr >= 999 && ctr < 9999)
            {
                ctr = ctr + 1;
                BIDs = var + "00000" + ctr;
            }
            else if (ctr >= 9999 && ctr < 99999)
            {
                ctr = ctr + 1;
                BIDs = var + "0000" + ctr;
            }

            else if (ctr >= 99999 && ctr < 999999)
            {
                ctr = ctr + 1;
                BIDs = var + "000" + ctr;
            }
            else if (ctr >= 999999 && ctr < 9999999)
            {
                ctr = ctr + 1;
                BIDs = var + "00" + ctr;
            }

            else if (ctr >= 9999999 && ctr < 99999999)
            {
                ctr = ctr + 1;
                BIDs = var + ctr;
            }

            else if (ctr < 1)
            {
                BIDs = var + "000000001";
            }

            dr11.Close();
            con.Close();

            return BIDs;
        }

        public string PSPI_ID(string var, SqlConnection con, string sqlstr)
        {
            string BIDs = "";
            double ctr = 0;
            // if(con.State == ConnectionState.Open)
            con.Open();
            SqlCommand com1 = new SqlCommand(sqlstr, con);
            // retrieving the last client ID
            SqlDataReader dr11;
            dr11 = com1.ExecuteReader();

            // AutoGenerating Client ID
            if (dr11.Read())
            {
                string Sid = dr11[0].ToString();
                string subSid = (Sid.Substring(4, 9));

                ctr = double.Parse(subSid);
            }

            if (ctr >= 1 && ctr < 9)
            {
                ctr = ctr + 1;
                BIDs = var + "00000000" + ctr;
            }
            else if (ctr >= 9 && ctr < 99)
            {
                ctr = ctr + 1;
                BIDs = var + "0000000" + ctr;
            }
            else if (ctr >= 99 && ctr < 999)
            {
                ctr = ctr + 1;
                BIDs = var + "000000" + ctr;
            }
            else if (ctr >= 999 && ctr < 9999)
            {
                ctr = ctr + 1;
                BIDs = var + "00000" + ctr;
            }
            else if (ctr >= 9999 && ctr < 99999)
            {
                ctr = ctr + 1;
                BIDs = var + "0000" + ctr;
            }

            else if (ctr >= 99999 && ctr < 999999)
            {
                ctr = ctr + 1;
                BIDs = var + "000" + ctr;
            }
            else if (ctr >= 999999 && ctr < 9999999)
            {
                ctr = ctr + 1;
                BIDs = var + "00" + ctr;
            }

            else if (ctr >= 9999999 && ctr < 99999999)
            {
                ctr = ctr + 1;
                BIDs = var + ctr;
            }

            else if (ctr < 1)
            {
                BIDs = var + "000000001";
            }

            dr11.Close();
            con.Close();

            return BIDs;
        }

        public string Challan_ID(string var, SqlConnection con, string sqlstr)
        {
            string BIDs = "";
            double ctr = 0;
            // if(con.State == ConnectionState.Open)
            con.Open();
            SqlCommand com1 = new SqlCommand(sqlstr, con);
            // retrieving the last client ID
            SqlDataReader dr11;
            dr11 = com1.ExecuteReader();

            // AutoGenerating Client ID
            if (dr11.Read())
            {
                string Sid = dr11[0].ToString();
                string subSid = (Sid.Substring(2, 9));

                ctr = double.Parse(subSid);
            }

            if (ctr >= 1 && ctr < 9)
            {
                ctr = ctr + 1;
                BIDs = var + "00000000" + ctr;
            }
            else if (ctr >= 9 && ctr < 99)
            {
                ctr = ctr + 1;
                BIDs = var + "0000000" + ctr;
            }
            else if (ctr >= 99 && ctr < 999)
            {
                ctr = ctr + 1;
                BIDs = var + "000000" + ctr;
            }
            else if (ctr >= 999 && ctr < 9999)
            {
                ctr = ctr + 1;
                BIDs = var + "00000" + ctr;
            }
            else if (ctr >= 9999 && ctr < 99999)
            {
                ctr = ctr + 1;
                BIDs = var + "0000" + ctr;
            }

            else if (ctr >= 99999 && ctr < 999999)
            {
                ctr = ctr + 1;
                BIDs = var + "000" + ctr;
            }
            else if (ctr >= 999999 && ctr < 9999999)
            {
                ctr = ctr + 1;
                BIDs = var + "00" + ctr;
            }

            else if (ctr >= 9999999 && ctr < 99999999)
            {
                ctr = ctr + 1;
                BIDs = var + ctr;
            }

            else if (ctr < 1)
            {
                BIDs = var + "000000001";
            }

            dr11.Close();
            con.Close();

            return BIDs;
        }

        public string SR_No(string var, SqlConnection con, string sqlstr)
        {
            string BIDs = "";
            double ctr = 0;
            // if(con.State == ConnectionState.Open)
            con.Open();
            SqlCommand com1 = new SqlCommand(sqlstr, con);
            // retrieving the last client ID
            SqlDataReader dr11;
            dr11 = com1.ExecuteReader();

            // AutoGenerating Client ID
            if (dr11.Read())
            {
                string Sid = dr11[0].ToString();
                string subSid = (Sid.Substring(3, 9));

                ctr = double.Parse(subSid);
            }

            if (ctr >= 1 && ctr < 9)
            {
                ctr = ctr + 1;
                BIDs = var + "00000000" + ctr;
            }
            else if (ctr >= 9 && ctr < 99)
            {
                ctr = ctr + 1;
                BIDs = var + "0000000" + ctr;
            }
            else if (ctr >= 99 && ctr < 999)
            {
                ctr = ctr + 1;
                BIDs = var + "000000" + ctr;
            }
            else if (ctr >= 999 && ctr < 9999)
            {
                ctr = ctr + 1;
                BIDs = var + "00000" + ctr;
            }
            else if (ctr >= 9999 && ctr < 99999)
            {
                ctr = ctr + 1;
                BIDs = var + "0000" + ctr;
            }

            else if (ctr >= 99999 && ctr < 999999)
            {
                ctr = ctr + 1;
                BIDs = var + "000" + ctr;
            }
            else if (ctr >= 999999 && ctr < 9999999)
            {
                ctr = ctr + 1;
                BIDs = var + "00" + ctr;
            }

            else if (ctr >= 9999999 && ctr < 99999999)
            {
                ctr = ctr + 1;
                BIDs = var + ctr;
            }

            else if (ctr < 1)
            {
                BIDs = var + "000000001";
            }

            dr11.Close();
            con.Close();

            return BIDs;
        }

        public  string NextLetter(string letter)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (!string.IsNullOrEmpty(letter))
            {
                char lastLetterInString = letter[letter.Length - 1];

                // if the last letter in the string is the last letter of the alphabet
                if (alphabet.IndexOf(lastLetterInString) == alphabet.Length - 1)
                {
                    //replace the last letter in the string with the first leter of the alphbat and get the next letter for the rest of the string
                    return NextLetter(letter.Substring(0, letter.Length - 1)) + alphabet[0];
                }
                else
                {
                    // replace the last letter in the string with the proceeding letter of the alphabet
                    return letter.Remove(letter.Length - 1).Insert(letter.Length - 1, (alphabet[alphabet.IndexOf(letter[letter.Length - 1]) + 1]).ToString());
                }
            }
            //return the first letter of the alphabet
            return alphabet[0].ToString();
        }

        //Purchase Year ID
        public string PurchYear(string var, SqlConnection con, string sqlstr)
        {
            string BIDs = "";
            double ctr = 0;
            // if(con.State == ConnectionState.Open)
            con.Open();
            SqlCommand com1 = new SqlCommand(sqlstr, con);
            // retrieving the last client ID
            SqlDataReader dr11;
            dr11 = com1.ExecuteReader();

            // AutoGenerating Client ID
            if (dr11.Read())
            {
                string Sid = dr11[0].ToString();
                string subSid = (Sid.Substring(7, 8));

                ctr = double.Parse(subSid);
            }

            if (ctr >= 1 && ctr < 9)
            {
                ctr = ctr + 1;
                BIDs = var + "0000000" + ctr;
            }
            else if (ctr >= 9 && ctr < 99)
            {
                ctr = ctr + 1;
                BIDs = var + "000000" + ctr;
            }
            else if (ctr >= 99 && ctr < 999)
            {
                ctr = ctr + 1;
                BIDs = var + "00000" + ctr;
            }
            else if (ctr >= 999 && ctr < 9999)
            {
                ctr = ctr + 1;
                BIDs = var + "0000" + ctr;
            }
            else if (ctr >= 9999 && ctr < 99999)
            {
                ctr = ctr + 1;
                BIDs = var + "000" + ctr;
            }

            else if (ctr >= 99999 && ctr < 999999)
            {
                ctr = ctr + 1;
                BIDs = var + "00" + ctr;
            }

            else if (ctr >= 999999 && ctr < 9999999)
            {
                ctr = ctr + 1;
                BIDs = var + ctr;
            }

            else if (ctr < 1)
            {
                BIDs = var + "00000001";
            }

            dr11.Close();
            con.Close();

            return BIDs;
        }

        //To make first letter caps
        public string FirstCap(string strFirst)
        {
            if (strFirst.Equals("") == true)
            {
            }
            else
            {

                string str = strFirst;
                string cap = str.Substring(0, 1);
                string rem = str.Substring(1);
                strFirst = cap.ToUpper() + rem.ToLower();
                return strFirst;
            }
            return strFirst;




        }

 }
}
