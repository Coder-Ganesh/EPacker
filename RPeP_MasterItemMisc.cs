using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ePacker1.App_Code;

namespace ePacker1
{
    public partial class RPeP_MasterItemMisc : Form
    {
        //Page Developed by Shirish Phadnis on
        string session, Group_ID;  
        private FunctionLib funclib;

        public RPeP_MasterItemMisc()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_MasterItemMisc_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            cmdEdit.Visible = false;
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);           
            con1.Open();
            SqlCommand cmdForm = new SqlCommand("select Pasting_Rate,Waxing_Rate,Punch_Rate,JtPasting_Rate,Pin_Rate,LBPasting_Rate,Roll_Length,Roll_Width,Roll_Cost,Fixing_Charge,Scanning_PSI,PosNeg_PSI,Proofing_PSI,NFlute_PKg,EFlute_PKg,BFlute_PKg,Fluting_Cent,Print_MinQty from Item_Misc_Master where Grp_ID='" + Group_ID + "'", con1);
            SqlDataReader drForm = cmdForm.ExecuteReader();
            if (drForm.Read())
            {
                txtPasting_Rate.Text = drForm[0].ToString();
                txtWaxing_Rate.Text = drForm[1].ToString();
                txtPunch_Rate.Text = drForm[2].ToString();
                txtJtPasting_Rate.Text = drForm[3].ToString();
                txtPin_Rate.Text = drForm[4].ToString();
                txtLBPasting_Rate.Text = drForm[5].ToString();
                txtRoll_Length.Text = drForm[6].ToString();
                txtRoll_Width.Text = drForm[7].ToString();
                txtRoll_Cost.Text = drForm[8].ToString();
                txtFixing_Charge.Text = drForm[9].ToString();
                txtScanning_PSI.Text = drForm[10].ToString();
                txtPosNeg_PSI.Text = drForm[11].ToString();
                txtProofing_PSI1.Text = drForm[12].ToString();
                txtNFlute_PKg.Text = drForm[13].ToString();
                txtEFlute_PKg.Text = drForm[14].ToString();
                txtBFlute_PKg.Text = drForm[15].ToString();
                txtFluting_Cent.Text = drForm[16].ToString();
                txtPrint_MinQty.Text = drForm[17].ToString();
            }
            con1.Close();
            drForm.Close();      
        }

        private void txtRoll_Length_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtRoll_Length Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRoll_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtRoll_Width Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRoll_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtRoll_Cost Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtFixing_Charge_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtFixing_Charge Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPasting_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPasting_Rate Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txWaxing_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txWaxing_Rate Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPunch_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPunch_Rate Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtJtPasting_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtJtPasting_Rate Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPin_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPin_Rate Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtLBPasting_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating LBPasting Rate
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtScanning_PSI_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Scanning PSI
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPosNeg_PSI_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating PosNeg PSI
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtProofing_PSI1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Proofing PSI
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtNFlute_PKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating NFlute
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtEFlute_PKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating EFlute
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtBFlute_PKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating BFlute
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtFluting_Cent_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Fluting Percent
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPrint_MinQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Print Minimum Qty
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPasting_Rate.Text))
                {
                    MessageBox.Show("Please Enter Pasting Rate");
                    txtPasting_Rate.Focus();
                }
                else if (string.IsNullOrEmpty(txtWaxing_Rate.Text))
                {
                    MessageBox.Show("Please Enter Waxing Rate");
                    txtWaxing_Rate.Focus();
                }
                else if (string.IsNullOrEmpty(txtPunch_Rate.Text))
                {
                    MessageBox.Show("Please Enter Punch Rate");
                    txtPunch_Rate.Focus();
                }
                else if (string.IsNullOrEmpty(txtJtPasting_Rate.Text))
                {
                    MessageBox.Show("Please Enter Joint Pasting Rate");
                    txtJtPasting_Rate.Focus();
                }
                else if (string.IsNullOrEmpty(txtPin_Rate.Text))
                {
                    MessageBox.Show("Please Enter Pin Rate");
                    txtPin_Rate.Focus();
                }
                else if (string.IsNullOrEmpty(txtLBPasting_Rate.Text))
                {
                    MessageBox.Show("Please Enter Lock Bottom Pasting Rate");
                    txtLBPasting_Rate.Focus();
                }
                else if (string.IsNullOrEmpty(txtRoll_Length.Text))
                {
                    MessageBox.Show("Please Enter Roll Length");
                    txtRoll_Length.Focus();
                }
                else if (string.IsNullOrEmpty(txtRoll_Width.Text))
                {
                    MessageBox.Show("Please Enter Roll Width");
                    txtRoll_Width.Focus();
                }
                else if (string.IsNullOrEmpty(txtRoll_Cost.Text))
                {
                    MessageBox.Show("Please Enter Roll cost");
                    txtRoll_Cost.Focus();
                }
                if (string.IsNullOrEmpty(txtFixing_Charge.Text))
                {
                    MessageBox.Show("Please Enter Fixing Charge");
                    txtFixing_Charge.Focus();
                }
                else if (string.IsNullOrEmpty(txtScanning_PSI.Text))
                {
                    MessageBox.Show("Please Enter Scanning PSI");
                    txtScanning_PSI.Focus();
                }
                else if (string.IsNullOrEmpty(txtPosNeg_PSI.Text))
                {
                    MessageBox.Show("Please Enter Positive PSI");
                    txtPosNeg_PSI.Focus();
                }
                else if (string.IsNullOrEmpty(txtProofing_PSI1.Text))
                {
                    MessageBox.Show("Please Enter Proofing PSI");
                    txtProofing_PSI1.Focus();
                }
                else if (string.IsNullOrEmpty(txtNFlute_PKg.Text))
                {
                    MessageBox.Show("Please Enter N Flute");
                    txtNFlute_PKg.Focus();
                }
                else if (string.IsNullOrEmpty(txtEFlute_PKg.Text))
                {
                    MessageBox.Show("Please Enter E Flute");
                    txtEFlute_PKg.Focus();
                }
                else if (string.IsNullOrEmpty(txtBFlute_PKg.Text))
                {
                    MessageBox.Show("Please Enter B Flute");
                    txtBFlute_PKg.Focus();
                }
                else if (string.IsNullOrEmpty(txtFluting_Cent.Text))
                {
                    MessageBox.Show("Please Enter Fluting %");
                    txtFluting_Cent.Focus();
                }
                else if (string.IsNullOrEmpty(txtPrint_MinQty.Text))
                {
                    MessageBox.Show("Please Enter Minimum Qty");
                    txtPrint_MinQty.Focus();
                }
                else
                {
                    //Inserting details into Table Item_Misc_Master 
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string msid = funclib.AutoKey1("MS", con, "select Misc_ID from Item_Misc_Master order by Misc_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Item_Misc_Master values('" + msid + "','" + Group_ID + "','" + txtPasting_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + txtWaxing_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + txtPunch_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + txtJtPasting_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + txtPin_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + txtLBPasting_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + txtRoll_Length.Text.Trim().Replace("'", "''").ToString() + "','" + txtRoll_Width.Text.Trim().Replace("'", "''").ToString() + "','" + txtRoll_Cost.Text.Trim().Replace("'", "''").ToString() + "','" + txtFixing_Charge.Text.Trim().Replace("'", "''").ToString() + "','" + txtScanning_PSI.Text.Trim().Replace("'", "''").ToString() + "','" + txtPosNeg_PSI.Text.Trim().Replace("'", "''").ToString() + "','" + txtProofing_PSI1.Text.Trim().Replace("'", "''").ToString() + "','" + txtNFlute_PKg.Text.Trim().Replace("'", "''").ToString() + "','" + txtEFlute_PKg.Text.Trim().Replace("'", "''").ToString() + "','" + txtBFlute_PKg.Text.Trim().Replace("'", "''").ToString() + "','" + txtFluting_Cent.Text.Trim().Replace("'", "''").ToString() + "','" + txtPrint_MinQty.Text.Trim().Replace("'", "''").ToString() + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        //filldata();
                        clearAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error " + ex.Message);
            }            
        }

        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {          
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            ddlGrp_ID.Text = "";
            txtPasting_Rate.Clear();
            txtWaxing_Rate.Clear();
            txtPunch_Rate.Clear();
            txtJtPasting_Rate.Clear();
            txtPin_Rate.Clear();
            txtLBPasting_Rate.Clear();
            txtRoll_Length.Clear();
            txtRoll_Width.Clear();
            txtRoll_Cost.Clear();
            txtFixing_Charge.Clear();
            txtScanning_PSI.Clear();
            txtPosNeg_PSI.Clear();
            txtProofing_PSI1.Clear();
            txtProofing_PSI1.Clear();
            txtNFlute_PKg.Clear();
            txtEFlute_PKg.Clear();
            txtBFlute_PKg.Clear();
            txtFluting_Cent.Clear();
            txtPrint_MinQty.Clear();                
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table Item_Misc_Master 
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Item_Misc_Master set Grp_ID ='" + Group_ID + "',Pasting_Rate ='" + txtPasting_Rate.Text.Trim().Replace("'", "''").ToString() + "',Waxing_Rate  ='" + txtWaxing_Rate.Text.Trim().Replace("'", "''").ToString() + "',Punch_Rate  ='" + txtPunch_Rate.Text + "',JtPasting_Rate ='" + txtJtPasting_Rate.Text + "',Pin_Rate='" + txtPin_Rate.Text + "',LBPasting_Rate='" + txtLBPasting_Rate.Text + "',Roll_Length='" + txtRoll_Length.Text + "',Roll_Width='" + txtRoll_Width.Text + "',Roll_Cost='" + txtRoll_Cost.Text + "',Fixing_Charge='" + txtFixing_Charge.Text + "',Scanning_PSI='" + txtScanning_PSI.Text + "',PosNeg_PSI='" + txtPosNeg_PSI.Text + "',Proofing_PSI='" + txtProofing_PSI1.Text + "',NFlute_PKg='" + txtNFlute_PKg.Text + "',EFlute_PKg='" + txtEFlute_PKg.Text + "',BFlute_PKg='" + txtBFlute_PKg.Text + "',Fluting_Cent='" + txtFluting_Cent.Text + "',Print_MinQty='" + txtPrint_MinQty.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Misc_ID ='" + txtMisc_ID.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                clearAll();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Code to close MasterItemMisc form temporarily.
            this.Close();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterItemMisc form
            clearAll();
        }
        
    }
}
