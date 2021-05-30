using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;

namespace ePacker1
{
    public partial class RPeP_CityMaster : Form
    {
        string session;
        //Page Developed by Ashish on(4/3/2011)
        private FunctionLib funcLib;
        public RPeP_CityMaster()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;

        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            funcLib = new FunctionLib();
            string strcon=funcLib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Checking for duplicate values
                double flag = funcLib.isThere(con, "select City_Name from City_Master where City_Name='" + txtCity_Name.Text + "' ");
                if (flag == 1)
                {
                    MessageBox.Show("Cannot add this record as duplication of City Name is not allowed");
                }
                else
                {
                    txtCity_Name.Text = funcLib.FirstCap(txtCity_Name.Text);
                    //Inserting values in table City_Master
                    SqlCommand cmd = new SqlCommand("insert into City_Master values('"+txtCity_Name.Text+"')",con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                    FillData();
                    clearAll();
                }
            }
            else
            {
                txtCity_Name.Focus();
            }

        }
        private void FillData()
        {
            //to fill the Datagridview with user details named dgWCityDetails
            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select distinct * from City_Master" , con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgWCityDetails.DataSource = dt;
          
            

        }

        private void RPeP_CityMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            FillData();
        }



        private void clearAll()
        {
            //Code for Clearing all form fields.
            txtCity_Name.Clear();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Code to close CityMaster form temporarily.
            this.Close();
        }

        private void txtCity_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtCity_Name Text Field

            funcLib = new FunctionLib();
            funcLib.onlyCharacterPress(e);


        }

    }
}