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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ePacker1.Business_Logic;

namespace ePacker1
{
    public partial class RPeP_MasterItemStyle : Form
    {
        private FunctionLib funclib;
        private string imagename;
        string session, strSQL, Group_ID, strSheetLocation, strBoxLocation;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterItemStyle()
        {            
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            filldata();
        }

        private void RPeP_MasterItemStyle_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);

            //Displaying value in Active field
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlStyle_Active.DataSource = dtActive;
            ddlStyle_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlStyle_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void txtRS_Length_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Length of RS
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRS_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Width of RS
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRS_Height_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Height of RS
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRS_Pinning_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Pinning of RS
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRS_Param1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating RS Param_1
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRS_Param2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating RS Param_2
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRS_Param3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating RS Param_3
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Length_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Length
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Width
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Height_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Height
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Pinning_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Printing
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Param1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Param1
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Param2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Param2
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Param3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Param3
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtStyle_No.Text == "")//checking for blank Group_ID combo field 
            {
                MessageBox.Show("Please Enter Style No");
                txtStyle_No.Focus();
            }
            else if (txtImage_Sheet.Text == "")//checking for Image Sheet
            {
                MessageBox.Show("Please select Sheet Image");
                txtImage_Sheet.Focus();
            }
            else if (txtImage_Box.Text == "")//checking for Image Box 
            {
                MessageBox.Show("Please select Box Image");
                txtImage_Box.Focus();
            }
            else if (ddlStyle_Active.SelectedIndex == 0)//checking for blank Group_ID combo field 
            {
                MessageBox.Show("Please select Active");
                ddlStyle_Active.Focus();
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
                    double flag = funclib.isThere(con, "select Grp_ID,Style_No from Item_Style_Master where Grp_ID='" + Group_ID + "'and Style_No='" + txtStyle_No.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group and Style No combination is not allowed");
                    }
                    else
                    {
                        //Inserting Details into table Item_Style_Master                        
                        string sid = funclib.AutoKey1("ST", con, "select Style_ID from Item_Style_Master order by Style_ID desc");
                        bool result = AddEditDeleteItemStyleData("A", sid);
                        if (result)
                        {
                            MessageBox.Show("Record Inserted Sucessfully");
                            if (!string.IsNullOrEmpty(strSheetLocation))
                            {
                                string filePath = Application.StartupPath + "\\SavedImages\\";
                                if (!Directory.Exists(filePath))
                                {
                                    Directory.CreateDirectory(filePath);
                                }
                                File.Copy(strSheetLocation, filePath + txtImage_Sheet.Text, true);
                            }
                            if (!string.IsNullOrEmpty(strBoxLocation))
                            {
                                string filePath = Application.StartupPath + "\\SavedImages\\";
                                if (!Directory.Exists(filePath))
                                {
                                    Directory.CreateDirectory(filePath);
                                }
                                File.Copy(strBoxLocation, filePath + txtImage_Box.Text, true);
                            }
                        }
                        else
                        { MessageBox.Show("There was an error while inserting data"); }
                        filldata();
                        clearAll();
                    }
                }
            }
        }

        private void cmdImage_Sheet_Click(object sender, EventArgs e)
        {           
            //Browse the Sheet Image        
            OpenFileDialog ofn1 = new OpenFileDialog();
            ofn1.InitialDirectory = "C:";
            ofn1.Title = "Save as Image file";
            ofn1.FileName = "";
            ofn1.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (ofn1.ShowDialog() == DialogResult.OK)
            {
                FileStream fstr;
                try
                {
                    fstr = new FileStream(ofn1.FileName, FileMode.Open, FileAccess.Read);
                    txtImage_Sheet.Text = ofn1.SafeFileName;
                    strSheetLocation = ofn1.FileName;
                    //pBFile1.Visible = true;
                    //pBFile1.ImageLocation = strFile1Location;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error " + ex.Message);
                }
            }
        }

        private void filldata()
        {
            //to fill the Datagridview with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select a.Style_ID,a.Style_No as StyleNo,a.Param_1 as Parameter1,a.Param_2 as Parameter2,a.Param_3 as Parameter3,a.RS_Length as ReelLength,a.RS_Width as ReelWidth,a.RS_Height as ReelHeight,a.RS_Pinning as ReelPrinting,a.RS_Param1 as ReelParameter1,a.RS_Param2 as ReelParameter2,a.RS_Param3 as ReelParameter3,a.CS_Length as CutLength,a.CS_Width  as CutWidth,a.CS_Height as CutHeight,a.CS_Pinning as Printing,a.CS_Param1 as Parameter1,a.CS_Param2 as Parameter2,a.CS_Param3 as Parameter3,a.Image_Sheet as SheetImage,a.Image_Box as BoxImage,a.Style_Active,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On from Item_Style_Master a,Group_Master b where a.Grp_ID=b.Grp_ID  and a.Grp_ID = '" + Group_ID + "'  ", con);
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da.Fill(dt);
            bindingSource1.DataSource = dt;
            //dgwMasterItemStyle.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dgwMasterItemStyle.DataSource = bindingSource1;
            this.dgwMasterItemStyle.Columns[0].Visible = false;            
        }

        private void cmdBox_Image_Click(object sender, EventArgs e)
        {
            //Browse the Box Image
            OpenFileDialog ofn1 = new OpenFileDialog();
            ofn1.InitialDirectory = "C:";
            ofn1.Title = "Save as Image file";
            ofn1.FileName = "";
            ofn1.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (ofn1.ShowDialog() == DialogResult.OK)
            {
                FileStream fstr;
                try
                {
                    fstr = new FileStream(ofn1.FileName, FileMode.Open, FileAccess.Read);
                    txtImage_Box.Text = ofn1.SafeFileName;
                    strBoxLocation = ofn1.FileName;
                    //pBFile1.Visible = true;
                    //pBFile1.ImageLocation = strFile1Location;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error " + ex.Message);
                }
            }
        }

        private void dgwMasterItemStyle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //MessageBox.Show(e.Context.ToString());
             if (e.Context == DataGridViewDataErrorContexts.Commit) 
            {
                MessageBox.Show("Commit error");
            }
            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                 MessageBox.Show("parsing error");
            }
            if (e.Context==DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }
        }

        private void dgwMasterItemStyle_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview named dgwMasterItemStyle
            txtStyle_No.Enabled = false;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Visible = false;
            ddlStyle_Active.Enabled = true; 
            txtStyle_ID.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtStyle_No.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtParam_1.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtParam_2.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtParam_3.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[4].Value.ToString();

            txtRS_Length.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtRS_Width.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtRS_Height.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtRS_Pinning.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtRS_Param1.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtRS_Param2.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtRS_Param3.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[11].Value.ToString();

            txtCS_Length.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtCS_Width.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtCS_Height.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtCS_Pinning.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtCS_Param1.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[16].Value.ToString();
            txtCS_Param2.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtCS_Param3.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[18].Value.ToString();

            txtImage_Sheet.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[19].Value.ToString();
            if (!string.IsNullOrEmpty(txtImage_Sheet.Text))
            {
                //pBFile1.Visible = true;
                //pBFile1.ImageLocation = dgvMasterPositive.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtImage_Sheet.Text = Path.GetFileName(txtImage_Sheet.Text);
            }
            txtImage_Box.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[20].Value.ToString();
            if (!string.IsNullOrEmpty(txtImage_Box.Text))
            {
                txtImage_Box.Text = Path.GetFileName(txtImage_Box.Text);
            }
            ddlStyle_Active.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[21].Value.ToString();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {                                
                    if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool result = AddEditDeleteItemStyleData("E", txtStyle_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        filldata();
                        clearAll();
                    }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while Editing Values " + ex.Message);
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterItemStyle form
            clearAll();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            ddlGrp_ID.Text = "";
            txtStyle_ID.Clear();
            txtStyle_No.Clear();
            txtParam_1.Clear();
            txtParam_2.Clear();
            txtParam_3.Clear();
            txtRS_Length.Clear();
            txtRS_Width.Clear();
            txtRS_Height.Clear();
            txtRS_Pinning.Clear();
            txtRS_Param1.Clear();
            txtRS_Param2.Clear();
            txtRS_Param3.Clear();
            txtCS_Length.Clear();
            txtCS_Width.Clear();
            txtCS_Height.Clear();
            txtCS_Pinning.Clear();
            txtCS_Param1.Clear();
            txtCS_Param2.Clear();
            txtCS_Param3.Clear();
            txtImage_Sheet.Clear();
            txtImage_Box.Clear();
            txtStyle_No.Enabled = true;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            cmdSubmit.Visible = true;
            ddlStyle_Active.SelectedIndex = 0;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.Style_ID,a.Style_No as StyleNo,a.Param_1 as Parameter1,a.Param_2 as Parameter2,a.Param_3 as Parameter3,a.RS_Length as ReelLength,a.RS_Width as ReelWidth,a.RS_Height as ReelHeight,a.RS_Pinning as ReelPrinting,a.RS_Param1 as ReelParameter1,a.RS_Param2 as ReelParameter2,a.RS_Param3 as ReelParameter3,a.CS_Length as CutLength,a.CS_Width  as CutWidth,a.CS_Height as CutHeight,a.CS_Pinning as Printing,a.CS_Param1 as Parameter1,a.CS_Param2 as Parameter2,a.CS_Param3 as Parameter3,a.Image_Sheet as SheetImage,a.Image_Box as BoxImage,a.Style_Active,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On from Item_Style_Master a,Group_Master b where a.Grp_ID=b.Grp_ID  and a.Grp_ID = '" + Group_ID + "'  ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bindingSource1.DataSource = dt;
            dgwMasterItemStyle.DataSource = bindingSource1;
            if (dgwMasterItemStyle.Rows.Count == 0)
            {
                cmdExcelReport.Visible = false;
            }
            else
            {
                cmdExcelReport.Visible = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Code to close MasterItemStyle form temporarily.
            this.Close();
        }        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = AddEditDeleteItemStyleData("D", txtStyle_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    filldata();
                    clearAll();
                }
                else
                {
                    cmdSubmit.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while deleting data  " + ex.Message);
            }
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
                        System.Data.DataTable table = dgwMasterItemStyle.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Item Style Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwMasterItemStyle.Columns.Count])
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

        private bool AddEditDeleteItemStyleData(string action, string StyleId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("StyleId", StyleId);
                dictionaryInstance.Add("StyleNo", funclib.FirstCap(txtStyle_No.Text));
                dictionaryInstance.Add("Param1", txtParam_1.Text);
                dictionaryInstance.Add("Param2", txtParam_2.Text);
                dictionaryInstance.Add("Param3", txtParam_3.Text);

                dictionaryInstance.Add("RSLength", txtRS_Length.Text);
                dictionaryInstance.Add("RSWidth", txtRS_Width.Text);
                dictionaryInstance.Add("RSHeight", txtRS_Height.Text);
                dictionaryInstance.Add("RSPinning", txtRS_Pinning.Text);
                dictionaryInstance.Add("RSParam1", txtRS_Param1.Text);
                dictionaryInstance.Add("RSParam2", txtRS_Param2.Text);
                dictionaryInstance.Add("RSParam3", txtRS_Param3.Text);

                dictionaryInstance.Add("CSLength", txtCS_Length.Text);
                dictionaryInstance.Add("CSWidth", txtCS_Width.Text);
                dictionaryInstance.Add("CSHeight", txtCS_Height.Text);
                dictionaryInstance.Add("CSPinning", txtCS_Pinning.Text);
                dictionaryInstance.Add("CSParam1", txtCS_Param1.Text);
                dictionaryInstance.Add("CSParam2", txtCS_Param2.Text);
                dictionaryInstance.Add("CSParam3", txtCS_Param3.Text);

                if (string.IsNullOrEmpty(txtImage_Sheet.Text))
                {
                    dictionaryInstance.Add("ImageSheet", "");
                }
                else
                {
                    dictionaryInstance.Add("ImageSheet", Application.StartupPath + "\\SavedImages\\" + txtImage_Sheet.Text);
                }
                if (string.IsNullOrEmpty(txtImage_Box.Text))
                {
                    dictionaryInstance.Add("ImageBox", "");
                }
                else
                {
                    dictionaryInstance.Add("ImageBox", Application.StartupPath + "\\SavedImages\\" + txtImage_Box.Text);
                }      
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlStyle_Active.SelectedValue));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeleteItemStyleMasterData(dictionaryInstance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

    }
}
