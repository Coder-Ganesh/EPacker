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
    public partial class RPeP_MasterItemBF : Form
    {
        //Page developed by Ashwin Prabhu on(18/4/2011)

        private FunctionLib funclib;
        string session, Group_ID, strSQL; 

        public RPeP_MasterItemBF()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtBF_ID.Visible = false;
           filldata();           
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {           
            if (txtBF_Value.Text == "")//Checking for blank BF Value text field.
            {
                MessageBox.Show("Enter BF Value");
            }
            else if (ddlBF_Active.SelectedIndex == 0)
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
                    double flag = funclib.isThere(con, "select Grp_ID,BF_Value  from Item_BF_Master where Grp_ID='" + Group_ID + "' and BF_Value='" + txtBF_Value.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group and BF Value is not allowed");
                    }
                    else
                    {
                        //Inserting details into the table Item_BF_Master.
                        con.Close();
                        string fid = funclib.AutoKey1("BF", con, "select BF_ID from Item_BF_Master order by BF_ID desc");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Item_BF_Master values('" + fid + "','" + Group_ID + "','" + txtBF_Value.Text.Trim().Replace("'", "''").ToString() + "','" + ddlBF_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        filldata();
                        clearAll();
                    }
                }
            }
        }

        private void RPeP_MasterItemBF_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;            
            //Displaying value in Activecombo field            
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlBF_Active.DataSource = dtActive;
            ddlBF_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlBF_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void txtBF_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtBF_Value Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void filldata()
        {
            //to fill the Datagridview with user details named dgwItem_BF_Master. 
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.BF_ID as BFID,b.Grp_Name,a.BF_Value as Value,a.BF_Active as Active,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On from Item_BF_Master a,Group_Master b where b.Grp_ID=a.Grp_ID  and a.Grp_ID = '" + Group_ID + "'  ", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_BF_Master.DataSource = dt;
            this.dgwItem_BF_Master.Columns[0].Visible = false;
        }

        private void dgwItem_BF_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview named dgwItem_BF_Master. 
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            //btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            txtBF_ID.Text = dgwItem_BF_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBF_Value.Text = dgwItem_BF_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlBF_Active.Text = dgwItem_BF_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update Records in table Item_BF_Master.
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            if (MessageBox.Show("Do you wish to Edit this record", "UpdateConfirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("update Item_BF_Master set BF_Value ='" + txtBF_Value.Text + "',BF_Active='" + ddlBF_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where BF_ID='" + txtBF_ID.Text + "'", con);
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

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterItemBF form
            clearAll();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            ddlGrp_ID.Text = "";
            txtBF_Value.Clear();
            ddlBF_Active.SelectedIndex = 0;
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
                    SqlCommand cmd = new SqlCommand("Delete from Item_BF_Master  where BF_ID ='" + txtBF_ID.Text + "'", con);
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
            //Code to close MasterItemBF form temporarily.
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
                        System.Data.DataTable table = dgwItem_BF_Master.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Item BF Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwItem_BF_Master.Columns.Count])
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
