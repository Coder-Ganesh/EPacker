using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace ePacker1
{
    public partial class RPeP_MasterItemGSM : Form
    {
        //Page developed by Shirish Phadnis on(18/4/2011)
        private FunctionLib funclib;
        string session, strSQL, Group_ID;   

       public RPeP_MasterItemGSM()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;            
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtGSM_ID.Visible = false;
            filldata();
        }

        private void RPeP_MasterItemGSM_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            //Displaying value in Activecombo field            
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlGSM_Active.DataSource = dtActive;
            ddlGSM_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlGSM_Active.ValueMember = dtActive.Columns[0].ToString();
        }
        
        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGSM_Value.Text == "")//Checking for blank GSM Value text field.
                {
                    MessageBox.Show("Enter GSM Value");
                }
                else if (ddlGSM_Active.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Active");
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
                        double flag = funclib.isThere(con, "select Grp_ID,GSM_Value from Item_GSM_Master where Grp_ID='" + Group_ID + "' and GSM_Value='" + txtGSM_Value.Text + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Group and GSM Value is not allowed");
                        }
                        else
                        {
                            //Inserting Details into table Item_GSM_Master.
                            con.Close();
                            string gid = funclib.AutoKey1("GS", con, "select GSM_ID from Item_GSM_Master order by GSM_ID desc");
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into Item_GSM_Master values('" + gid + "','" + Group_ID + "','" + txtGSM_Value.Text.Trim().Replace("'", "''").ToString() + "','" + ddlGSM_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
                MessageBox.Show("There was an error while inserting data " + ex.Message);
            }
        }

        private void txtGSM_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtGSM_Value Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void filldata()
        {
            //to fill the Datagridview with user details named dgwItem_GSM_Master. 
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.GSM_ID as GSMID,b.Grp_Name,a.GSM_Value as Value,a.GSM_Active,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On as Mod_On from Item_GSM_Master a,Group_Master b where b.Grp_ID=a.Grp_ID and a.Grp_ID = '"+Group_ID+"'  ", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_GSM_Master.DataSource = dt;
            this.dgwItem_GSM_Master.Columns[0].Visible = false;
        }

        private void dgwItem_GSM_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview named dgwItem_GSM_Master. 
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            //btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlGSM_Active.Enabled = true;
            txtGSM_ID.Text = dgwItem_GSM_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtGSM_Value.Text = dgwItem_GSM_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlGSM_Active.Text = dgwItem_GSM_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGSM_Value.Text == "")//Checking for blank GSM Value text field.
                {
                    MessageBox.Show("Enter GSM Value");
                }
                else if (ddlGSM_Active.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Active");
                }
                else
                {
                    //Update Records in table Item_GSM_Master.
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    if (MessageBox.Show("Do you wish to Edit this record", "UpdateConfirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand("update Item_GSM_Master set GSM_Value ='" + txtGSM_Value.Text + "',GSM_Active='" + ddlGSM_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where GSM_ID='" + txtGSM_ID.Text + "'", con);
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Updated");
                        filldata();
                        clearAll();
                    }
                    else
                    {
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while updating error " + ex.Message);
            }           
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterItemGSM  form
            clearAll();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.            
            txtGSM_Value.Clear();
            ddlGSM_Active.Enabled = true;
            ddlGSM_Active.SelectedIndex = 0;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            cmdEdit.Visible = false;
            cmdEdit.Enabled = false;
            btnDelete.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Update Records in table Item_GSM_Master.
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to Delete this record", "UpdateConfirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("Delete from Item_GSM_Master  where GSM_ID='" + txtGSM_ID.Text + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted");
                    filldata();
                    clearAll();
                }
                else
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while deleting " + ex.Message);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {            
            //Code to close MasterItemGSM form temporarily.
            this.Close();
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            try
            {
                saveFileDialog1.InitialDirectory = "C:";
                saveFileDialog1.Title = "Save as Excel file";
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "Excel Files(2003) |*.xls|Excel Files(2007) |*.xlsx";
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        System.Data.DataTable table = dgwItem_GSM_Master.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Item GSM Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwItem_GSM_Master.Columns.Count])
                        {
                            rng.Style.Font.Bold = true;
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }
                        FileInfo excelFile = new FileInfo(saveFileDialog1.FileName);
                        pck.SaveAs(excelFile);
                    }
                    MessageBox.Show("Data Exported Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while exporting excel  " + ex.Message);
            }
        }
        
    }
}
