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
    public partial class RPeP_MasterShift : Form
    {
        string session; 
        private FunctionLib funclib;

        public RPeP_MasterShift()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            filldata();
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtS_ID.Visible = false;
        }

        private void RPeP_MasterShift_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Displaying Active Values         
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlS_Active.DataSource = dtActive;
            ddlS_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlS_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void txtS_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating S_Name Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Checking for duplicate values
                    double flag = funclib.isThere(con, "select S_Name from Shift_Master where S_Name='" + txtS_Name.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Shift is not allowed");
                    }
                    else
                    {
                        txtS_Name.Text = funclib.FirstCap(txtS_Name.Text);
                        //Inserting Details into table
                        string sid = funclib.AutoKey1("SF", con, "select S_ID from Shift_Master order by S_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Shift_Master values('" + sid + "','" + txtS_Name.Text.Trim().Replace("'", "''").ToString() + "','" + ddlS_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        filldata();
                        clearAll();
                    }
                }
                else
                {
                    cmdSubmit.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Inserting Data " + ex.Message);
            }
        }

        private void filldata()
        {
            try
            {
                //to fill the grid with user details
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select S_ID as ShiftID,S_Name as ShiftName,S_Active as Active,Add_By,Add_On,Mod_By,Mod_On from Shift_Master", con4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgwShift_Master.DataSource = dt;
                this.dgwShift_Master.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while data to Grid " + ex.Message);
            }           
        }

        private void dgwShift_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = true;
            ddlS_Active.Enabled = true;
            txtS_Name.Enabled = false;
            txtS_ID.Text = dgwShift_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtS_Name.Text = dgwShift_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlS_Active.Text = dgwShift_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtS_Name.Text = funclib.FirstCap(txtS_Name.Text);
                    //Update data in table
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Shift_Master set S_Name='" + txtS_Name.Text + "',S_Active='" + ddlS_Active.SelectedItem.ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where S_ID='" + txtS_ID.Text + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                    filldata();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Updating data " + ex.Message);
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            //Clearing form data
            txtS_Name.Clear();            
            txtS_Name.Enabled = true;
            txtS_Name.Focus();
            ddlS_Active.SelectedIndex = 0;          
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = false;
       }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtS_Name.Text = funclib.FirstCap(txtS_Name.Text);
                    //Update data in table
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from Shift_Master  where S_ID='" + txtS_ID.Text + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted");
                    filldata();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Deleting data " + ex.Message);
            }
        }

    }
}
