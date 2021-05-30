using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ePacker1.App_Code;


namespace ePacker1
{
    public partial class RPeP_StateMaster : Form
    {
        string session; 
        //Page developed by Avinash on(4/3/2011)
        private FunctionLib funcLib;
        public RPeP_StateMaster()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
        }

        private void RPeP_StateMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            fillData();
        }

        private void txtStateDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtStateDetails Text Field

            funcLib = new FunctionLib();
            funcLib.onlyCharacterPress(e);

        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Checking for duplicate values
                double flag = funcLib.isThere(con, "select State_Name from State_Master where State_Name='" + txtStateDetails.Text + "' ");
                if (flag == 1)
                {
                    MessageBox.Show("Cannot add this record as duplication of City Name is not allowed");
                }
                else
                {
                    txtStateDetails.Text = funcLib.FirstCap(txtStateDetails.Text);
                    SqlCommand cmd = new SqlCommand("insert into State_Master values('" + txtStateDetails.Text + "')", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                    fillData();
                    clearAll();
                }
            }
            else
            {
                txtStateDetails.Focus();
            }
        }
        private void fillData()
        {
            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter("select distinct * from State_Master", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStateDetails.DataSource = dt;
        }

        private void clearAll()
        {
            txtStateDetails.Clear();
        }



        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
            

}