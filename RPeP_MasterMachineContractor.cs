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
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using ePacker1.Business_Logic;

namespace ePacker1
{
    public partial class RPeP_MasterMachineContractor : Form
    {
        private FunctionLib funclib;
        string session, strSQL, Group_ID;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterMachineContractor()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
        }

        private void RPeP_MasterMachineContractor_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strcon);
                con1.Open();
                //Display value in Machine
                SqlDataAdapter daMach = new SqlDataAdapter("select a.M_ID,(a.M_Name+'('+a.M_Type+')') from Machine_Master a,MachType_Master b  where a.Grp_ID='" + Group_ID + "' and a.M_Type=b.M_Type and a.M_Active = 'Yes'  ", con1);
                DataTable dtMach = new DataTable();
                daMach.Fill(dtMach);
                GlobalFunctions.AddPleaseSelect(ref dtMach);
                ddlM_ID.DataSource = dtMach;
                ddlM_ID.DisplayMember = dtMach.Columns[1].ToString();
                ddlM_ID.ValueMember = dtMach.Columns[0].ToString();
                con1.Close();
                //displaying Value in Contractor
                SqlConnection con2 = new SqlConnection(strcon);
                SqlDataAdapter daContra = new SqlDataAdapter("select C_ID,(C_Name+'('+C_City+')') from Contractor_Master   where Grp_ID='" + Group_ID + "'", con2);
                DataTable dtContra = new DataTable();
                daContra.Fill(dtContra);
                GlobalFunctions.AddPleaseSelect(ref dtContra);
                ddlC_ID.DataSource = dtContra;
                ddlC_ID.DisplayMember = dtContra.Columns[1].ToString();
                ddlC_ID.ValueMember = dtContra.Columns[0].ToString();
                con2.Close();
                //Display value in Active
                DataTable dtActive = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActive);
                ddlMC_Active.DataSource = dtActive;
                ddlMC_Active.DisplayMember = dtActive.Columns[0].ToString();
                ddlMC_Active.ValueMember = dtActive.Columns[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading form " + ex.Message);
            }           
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlC_ID.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Contractor");
                    ddlC_ID.Focus();
                }
                else if (ddlM_ID.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Machine Name");
                    ddlM_ID.Focus();
                }
                else if (ddlMC_Active.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Active");
                    ddlM_ID.Focus();
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
                        double flag = funclib.isThere(con, "select Grp_ID,M_ID,C_ID from MachContractor_Link where  Grp_ID='" + Group_ID + "' and M_ID='" + ddlM_ID.SelectedValue.ToString() + "' and C_ID='" + ddlC_ID.SelectedValue.ToString() + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Group, Machine and Contractor is not allowed");
                        }
                        else
                        {
                            //Insert details in table
                            SqlCommand cmdMachContra = new SqlCommand("insert into MachContractor_Link values('" + Group_ID + "','" + ddlM_ID.SelectedValue.ToString() + "','" + ddlC_ID.SelectedValue.ToString() + "','" + ddlMC_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                            con.Open();
                            int i = cmdMachContra.ExecuteNonQuery();
                            MessageBox.Show("Record Inserted");
                            con.Close();
                            clearAll();
                            filldata();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while adding record " + ex.Message);
            }          
        }

        private void filldata()
        {
            try
            {
                //to fill the grid with MachContractor
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select d.M_ID,d.C_ID,a.Grp_Name as GroupName,b.M_Name as Machinename,c.C_Name as Contractor, d.MC_Active as Active,d.Add_By,d.Add_On,d.Mod_By,d.Mod_On  from Group_Master a,Machine_Master b,Contractor_Master c,MachContractor_Link d where a.Grp_ID=d.Grp_ID and b.M_ID=d.M_ID and c.C_ID=d.C_ID", con4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgwMachContractor_Link.DataSource = dt;
                this.dgwMachContractor_Link.Columns[0].Visible = false;
                this.dgwMachContractor_Link.Columns[1].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading data to grid " + ex.Message);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Search data from table
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select d.M_ID,d.C_ID,a.Grp_Name as GroupName,b.M_Name as Machinename,c.C_Name as Contractor,d.Add_By,d.Add_On,d.Mod_By,d.Mod_On from Group_Master a,Machine_Master b,Contractor_Master c,MachContractor_Link d where a.Grp_ID=d.Grp_ID and b.M_ID=d.M_ID and c.C_ID=d.C_ID and  b.M_Name like '%" + txtM_Name_Search.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgwMachContractor_Link.DataSource = dt;
                this.dgwMachContractor_Link.Columns[0].Visible = false;
                this.dgwMachContractor_Link.Columns[1].Visible = false;
                if (dgwMachContractor_Link.Rows.Count == 0)
                {
                    cmdExcelReport.Visible = false;
                }
                else
                {
                    cmdExcelReport.Visible = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        private void cmdSearchMach_Click(object sender, EventArgs e)
        {
            try
            {
                //Search Machine 
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select a.M_ID,(a.M_Name+'('+a.M_Type+')') from Machine_Master a,MachType_Master b  where a.Grp_ID='" + Group_ID + "' and a.M_Type=b.M_Type and a.M_Active = 'Yes' and a.M_Name like '" + txtMachSearch.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (string.IsNullOrEmpty(txtMachSearch.Text))
                {
                    GlobalFunctions.AddPleaseSelect(ref dt);
                }
                ddlM_ID.DataSource = dt;
                ddlM_ID.DisplayMember = dt.Columns[1].ToString();
                ddlM_ID.ValueMember = dt.Columns[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error " + ex.Message);
            }          
        }

        private void cmdSearchContra_Click(object sender, EventArgs e)
        {
            try
            {
                //Search Machine 
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                
                SqlDataAdapter da = new SqlDataAdapter("select C_ID,(C_Name+'('+C_City+')') from Contractor_Master where Grp_ID='" + Group_ID + "' and C_Active = 'Yes' and C_Name like '" + txtContraSearch.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (string.IsNullOrEmpty(txtContraSearch.Text))
                {
                    GlobalFunctions.AddPleaseSelect(ref dt);
                }
                ddlC_ID.DataSource = dt;
                ddlC_ID.DisplayMember = dt.Columns[1].ToString();
                ddlC_ID.ValueMember = dt.Columns[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error " + ex.Message);
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            ddlGrp_ID.Text = "";
            ddlM_ID.Text = "";
            ddlC_ID.Text = "";
            ddlMC_Active.SelectedIndex = 0;        
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            ddlM_ID.Enabled = true;
            ddlM_ID.SelectedIndex = 0;
            ddlC_ID.Enabled = true;
            ddlC_ID.SelectedIndex = 0;
            ddlGrp_ID.Enabled = true;
        }

        private void dgwMachContractor_Link_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cmdEdit.Enabled = true;
                cmdEdit.Visible = true;
                btnDelete.Visible = true;
                cmdSubmit.Visible = false;
                cmdSubmit.Enabled = false;              
                ddlGrp_ID.Enabled = false;
                ddlMC_Active.Enabled = true;
                //ddlGrp_ID.Text = dgwMachContractor_Link.Rows[e.RowIndex].Cells[0].Value.ToString();
                ddlM_ID.SelectedValue = dgwMachContractor_Link.Rows[e.RowIndex].Cells[0].Value.ToString();
                ddlC_ID.SelectedValue = dgwMachContractor_Link.Rows[e.RowIndex].Cells[1].Value.ToString();
                ddlMC_Active.Text = dgwMachContractor_Link.Rows[e.RowIndex].Cells[5].Value.ToString();
                ddlM_ID.Enabled = false;
                ddlC_ID.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error " + ex.Message);
            }           
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Update this record", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string strCon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strCon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update MachContractor_Link set MC_Active='" + ddlMC_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where M_ID ='" + ddlM_ID.SelectedValue + "' and C_ID ='" + ddlC_ID.SelectedValue + "' and Grp_ID ='" + Group_ID + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                    filldata();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while Editing Values " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this record", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string strCon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strCon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from MachContractor_Link where M_ID ='" + ddlM_ID.SelectedValue + "' and C_ID ='" + ddlC_ID.SelectedValue + "' and Grp_ID ='" + Group_ID + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted");
                    filldata();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while Deleting Values " + ex.Message);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
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
                        System.Data.DataTable table = dgwMachContractor_Link.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Machine Contractor Link Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwMachContractor_Link.Columns.Count])
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
