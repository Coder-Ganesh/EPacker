﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;


namespace ePacker1
{
    public partial class RPeP_MasterUOM : Form
    {
        string session;
        private FunctionLib funclib;
        public RPeP_MasterUOM()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            filldata();
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtUOM_ID.Visible = false;
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUOM_Name.Text))
                {
                    MessageBox.Show("Please enter UOM ");
                }
                else if (ddlUOM_Active.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Active ");
                }
                else
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //Checking for duplicate values
                        double flag = funclib.isThere(con, "select UOM_Name from UOM_Master where UOM_Name='" + txtUOM_Name.Text + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Shift is not allowed");
                        }
                        else
                        {
                            txtUOM_Name.Text = funclib.FirstCap(txtUOM_Name.Text);
                            //Inserting Details into table
                            string uid = funclib.AutoKey("U", con, "select UOM_ID from UOM_Master order by UOM_ID desc");
                            SqlCommand cmd = new SqlCommand("insert into UOM_Master values('" + uid + "','" + txtUOM_Name.Text.Trim().Replace("'", "''").ToString() + "','" + ddlUOM_Active.Text + "','" + session + "',convert(datetime,getdate(),103),'','')", con);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Inserted");
                            filldata();
                            clearAll();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while adding record " + ex.Message);
            }
          
        }

        private void clearAll()
        {
            //Clearing form data
            txtUOM_Name.Clear();
            ddlUOM_Active.Text = "";
            ddlUOM_Active.SelectedIndex = 0;
            ddlUOM_Active.Enabled = true;
            txtUOM_Name.Enabled = true;
            txtUOM_Name.Focus();
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
        }

        private void RPeP_MasterUOM_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Displaying Active Values
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlUOM_Active.DataSource = dtActive;
            ddlUOM_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlUOM_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void txtUOM_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating UOM_Name Text Field
            funclib = new FunctionLib();
            funclib.charNumber(e);
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void filldata()
        {
            try
            {
                //to fill the grid with user details
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                con4.Open();
                SqlDataAdapter da = new SqlDataAdapter("select UOM_ID as UOMID,UOM_Name as UOM,UOM_Active as Active,Add_By,Add_On,Mod_By,Mod_On from UOM_Master", con4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgwUOM_Master.DataSource = dt;
                this.dgwUOM_Master.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading grid " + ex.Message);
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Update  this record", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(txtUOM_Name.Text))
                    {
                        MessageBox.Show("Please enter UOM ");
                    }
                    else if (ddlUOM_Active.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please Select Active ");
                    }
                    else
                    {
                        txtUOM_Name.Text = funclib.FirstCap(txtUOM_Name.Text);
                        //Update data in table
                        string strcon = funclib.setConnection();
                        SqlConnection con = new SqlConnection(strcon);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("update UOM_Master set UOM_Name='" + txtUOM_Name.Text + "',UOM_Active='" + ddlUOM_Active.SelectedValue + "',Mod_By='" + session + "',Mod_On= convert(datetime,getdate(),103) where UOM_ID='" + txtUOM_ID.Text + "'", con);
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Updated");
                        filldata();
                        clearAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while updating data " + ex.Message);
            }
        }

        private void dgwUOM_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview

            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlUOM_Active.Enabled = true;
            txtUOM_Name.Enabled = false;
            txtUOM_ID.Text = dgwUOM_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUOM_Name.Text = dgwUOM_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlUOM_Active.Text = dgwUOM_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete  this record", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from UOM_Master where UOM_ID='" + txtUOM_ID.Text + "'", con);
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
