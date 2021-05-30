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
using System.IO;
using System.Windows;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using System.Diagnostics;
using iTextSharp.text.pdf.draw;

namespace ePacker1
{
    public partial class RPeP_POCraftPaperReel : Form
    {
        string session, strSQL, Group_ID, POR_No, SubOrder,Grp_Name, SubItem_Of, strOpenDoc;
        private FunctionLib funclib;
        public RPeP_POCraftPaperReel()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_POCraftPaperReel_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Displaying Active Values 
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            ddlActive.Enabled = false;
            ddlActive.Items.Add("Yes");
            ddlActive.Items.Add("No");
            ddlActive.Text = "Yes";
            monthCalendar1.Visible = false;
         

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as A_ID, '' as A_Name UNION select  A_ID,A_Name from Agent_Master  where Grp_ID = '" + Group_ID + "' and A_Active='Yes'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlA_ID.DataSource = dt;
            ddlA_ID.DisplayMember = dt.Columns[1].ToString();
            ddlA_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();



            SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as PQ_ID, '' as PQ_Desc UNION select  PQ_ID,PQ_Desc from PQuality_Master  where Grp_ID = '" + Group_ID + "' and PQ_Active='Yes'", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Open();
            ddlPQ_ID.DataSource = dt2;
            ddlPQ_ID.DisplayMember = dt2.Columns[1].ToString();
            ddlPQ_ID.ValueMember = dt2.Columns[0].ToString();
            con.Close();



            SqlDataAdapter da3 = new SqlDataAdapter("SELECT '' as R_Size UNION select  R_Size from Reel_Stock", con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Open();
            ddlPOR_Size.DataSource = dt3;
            ddlPOR_Size.DisplayMember = dt3.Columns[0].ToString();
            ddlPOR_Size.ValueMember = dt3.Columns[0].ToString();
            con.Close();



            POR_No = funclib.I_ID("R", con, "select POR_No  from PO_Reel order by POR_No  desc");
            txtPOR_No.Text = POR_No;

            ddlSearch.Items.Add("");
            ddlSearch.Items.Add("PO No");
            ddlSearch.Items.Add("Agent");
            ddlSearch.Items.Add("Mill");
         
        }

        private void txtPOR_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;

        } 
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtPOR_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtPOR_Dt.Focus();
        }

        private void ddlA_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as M_ID, '' as M_Name UNION select a.M_ID,b.M_Name from AgentMill_Link as a,Mill_Master as b where a.M_ID=b.M_ID and a.A_ID='"+ddlA_ID.SelectedValue.ToString()+"' and b.M_Active='Yes'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlM_ID.DataSource = dt;
            ddlM_ID.DisplayMember = dt.Columns[1].ToString();
            ddlM_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void txtCr_Dy_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtDelv_Days_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtDelv_Place_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtPOR_BF_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtPOR_GSM_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtPOR_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);

        }

        private void txtPOR_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtPOR_No.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("POR No Cannot be Blank");
                txtPOR_No.Focus();
            }

            else if (txtPOR_Dt.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPOR_Dt.Focus();
            }
            else if (ddlA_ID.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlA_ID.Focus();

            }
            else if (ddlM_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlM_ID.Focus();
            }
            else if (txtCr_Dy.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtCr_Dy.Focus();
            }
            else if (txtDelv_Days.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtDelv_Days.Focus();
            }
            else if (txtDelv_Place.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtDelv_Place.Focus();
            }
            else if (ddlActive.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlActive.Focus();
            }
       
                
            else
            {


                funclib = new FunctionLib();
                //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);


                //Inserting records 


                SqlCommand cmdPositive = new SqlCommand("insert into PO_Reel(POR_No,POR_Dt,Grp_ID,A_ID,M_ID,Cr_Dy,Delv_Days,Delv_Place,POR_Active,Add_By,Add_ByNode,Add_On) values('" + txtPOR_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txtPOR_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + Group_ID + "','" + ddlA_ID.SelectedValue.ToString() + "','" + ddlM_ID.SelectedValue.ToString() + "','" + txtCr_Dy.Text.Trim().Replace("'", "''").ToString() + "','" + txtDelv_Days.Text.Trim().Replace("'", "''").ToString() + "','" + txtDelv_Place.Text.Trim().Replace("'", "''").ToString() + "','" + ddlActive.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
                con.Open();
                int Positive = cmdPositive.ExecuteNonQuery();
                MessageBox.Show("Record Inserted");
                con.Close();
                enableDisable(false);
                panel2.Enabled = true;
                cmdAddDetail.Enabled = true;


                
              
            }
        }
        protected void enableDisable(Boolean yes)
        {
            txtCr_Dy.Enabled = yes;
            txtDelv_Days.Enabled = yes;
            txtDelv_Place.Enabled = yes;
            txtPOR_Dt.Enabled = yes;
            ddlA_ID.Enabled = yes;
            ddlM_ID.Enabled = yes;

        }
        private void ddlPQ_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);


            // Reading Value For Displaying
            SqlCommand cmd3 = new SqlCommand("select a.BF_Value,b.GSM_Value,c.PQ_Rate from Item_BF_Master as a,Item_GSM_Master as b,PQuality_Master as c where a.BF_ID=c.BF_ID and b.GSM_ID=c.GSM_ID and c.Grp_ID='"+Group_ID+"' and c.PQ_Active='Yes' and c.PQ_ID='"+ddlPQ_ID.SelectedValue.ToString()+"'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtPOR_BF.Text = Convert.ToString(dr1["BF_Value"]);
                txtPOR_GSM.Text = Convert.ToString(dr1["GSM_Value"]);
                txtPOR_Rate.Text = Convert.ToString(dr1["PQ_Rate"]);
            }
            dr1.Close();
            con1.Close();






        }
        private void ddlPOR_Size_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);

            // Reading For Balance Quantity
            SqlCommand cmd4 = new SqlCommand("select R_StkInHand from Reel_Stock where R_Size='" + ddlPOR_Size.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr2 = cmd4.ExecuteReader();
            if (dr2.Read())
            {

                txtPOR_Bal.Text = Convert.ToString(dr2["R_StkInHand"]);

            }
            dr2.Close();
            con1.Close();
        }
        private void cmdAddDetail_Click(object sender, EventArgs e)
        {
            if (ddlPOR_Size.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Field Cannot be Blank");
                ddlPOR_Size.Focus();
            }

            else if (ddlPQ_ID.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlPQ_ID.Focus();
            }
            else if (txtPOR_Bal.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPOR_Bal.Focus();

            }
            else if (txtPOR_BF.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPOR_BF.Focus();
            }
            else if (txtPOR_GSM.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPOR_GSM.Focus();
            }
            else if (txtPOR_Rate.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPOR_Rate.Focus();
            }
            else if (txtPOR_Qty.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPOR_Qty.Focus();
            }
         
            else
            {
                double Balance = Convert.ToDouble(txtPOR_Bal.Text);
                double QtyEntered = Convert.ToDouble(txtPOR_Qty.Text);

                //Balance Quantity Must Be Graeter Than Enterd Quantity
                if (Balance >= QtyEntered)
                {

                    funclib = new FunctionLib();
                    //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);


                    //Inserting records 


                    SqlCommand cmdPositive = new SqlCommand("insert into PO_ReelDetail(POR_No,POR_Size,PQ_ID,POR_BF,POR_GSM,POR_Rate,POR_Qty,POR_Bal) values('" + txtPOR_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddlPOR_Size.SelectedValue.ToString() + "','" + ddlPQ_ID.SelectedValue.ToString() + "','" + txtPOR_BF.Text.Trim().Replace("'", "''").ToString() + "','" + txtPOR_GSM.Text.Trim().Replace("'", "''").ToString() + "','" + txtPOR_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + txtPOR_Qty.Text.Trim().Replace("'", "''").ToString() + "','" + txtPOR_Bal.Text.Trim().Replace("'", "''").ToString() + "')", con);
                    con.Open();
                    int Positive = cmdPositive.ExecuteNonQuery();
                    con.Close();
                    ClearDetail();

                    SqlDataAdapter da = new SqlDataAdapter(" select POR_Size as 'Size',b.PQ_Desc as 'Quality',POR_BF as 'BF',POR_GSM as 'GSM',POR_Rate as 'Rate',POR_Qty as 'Quantity',POR_Bal as 'Balance'  from PO_ReelDetail as a,PQuality_Master as b where a.PQ_ID=b.PQ_ID and a.POR_No='" + txtPOR_No.Text + "'  order by POR_No desc", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridViewAddDetails.DataSource = dt;
                    cmdPrintPO.Enabled = true;


                }
                else
                {
                    MessageBox.Show("Quantity Enterd Should be less than Balance Quantity");
                    txtPOR_Qty.Focus();
                }



            }
        }
        protected void ClearDetail()
        {
            txtPOR_Bal.Text = "";
            txtPOR_BF.Text = "";
            txtPOR_GSM.Text = "";
            txtPOR_Qty.Text = "";
            txtPOR_Rate.Text = "";
            ddlPOR_Size.Text = "";
            ddlPQ_ID.Text = "";
         
        }
        private void cmdReset_Click(object sender, EventArgs e)
        {
            enableDisable(true);
            ClearDetail();
            txtCr_Dy.Text = "";
            txtDelv_Days.Text = "";
            txtDelv_Place.Text = "";
            txtPOR_Dt.Text = "";
            ddlA_ID.Text = "";
            ddlM_ID.Text = "";
            ddlActive.Text = "Yes";
            ddlActive.Enabled = false;
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            ddlA_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlM_ID.DropDownStyle = ComboBoxStyle.DropDownList;

            GridView1.DataSource = null;
            GridViewAddDetails.DataSource = null;
            GridviewDetails.DataSource = null;

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            POR_No = funclib.I_ID("R", con, "select POR_No  from PO_Reel order by POR_No  desc");
            txtPOR_No.Text = POR_No;
            cmdPrintPO.Enabled = false;
            cmdPrintPO2.Enabled = false;
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("update PO_Reel set POR_Active  ='" + ddlActive.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where POR_No ='" + txtPOR_No.Text.Trim().Replace("'", "''").ToString() + "'", con);

                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                con.Close();

                enableDisable(true);
                ClearDetail();
                txtCr_Dy.Text = "";
                txtDelv_Days.Text = "";
                txtDelv_Place.Text = "";
                txtPOR_Dt.Text = "";
                ddlA_ID.Text = "";
                ddlM_ID.Text = "";
                ddlActive.Text = "Yes";
                ddlActive.Enabled = false;
                cmdEdit.Enabled = false;
                cmdSubmit.Enabled = true;

                ddlA_ID.DropDownStyle = ComboBoxStyle.DropDownList;
                ddlM_ID.DropDownStyle = ComboBoxStyle.DropDownList;

                GridView1.DataSource = null;
                GridViewAddDetails.DataSource = null;
                GridviewDetails.DataSource = null;

             
                POR_No = funclib.I_ID("R", con, "select POR_No  from PO_Reel order by POR_No  desc");
                txtPOR_No.Text = POR_No;
                cmdPrintPO.Enabled = false;
                cmdPrintPO2.Enabled = false;
            }
        }

        private void CmdSearch_Click(object sender, EventArgs e)
        {
            //ddlSearch.Items.Add("PO No");
            //ddlSearch.Items.Add("Agent");
            //ddlSearch.Items.Add("Mill");

            if (ddlSearch.Text == "PO No")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select POR_No as 'PO No',b.A_Name as 'Agent',c.M_Name as 'Mill' from PO_Reel as a,Agent_Master as b,Mill_Master as c where a.A_ID=b.A_ID and a.M_ID=c.M_ID and a.POR_No like '%" + txt_Search.Text.ToString() + "%'  order by a.POR_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
             
            }
            else if (ddlSearch.Text == "Agent")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select POR_No as 'PO No',b.A_Name as 'Agent',c.M_Name as 'Mill' from PO_Reel as a,Agent_Master as b,Mill_Master as c where a.A_ID=b.A_ID and a.M_ID=c.M_ID and b.A_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.POR_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else if (ddlSearch.Text == "Agent")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select POR_No as 'PO No',b.A_Name as 'Agent',c.M_Name as 'Mill' from PO_Reel as a,Agent_Master as b,Mill_Master as c where a.A_ID=b.A_ID and a.M_ID=c.M_ID and c.M_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.POR_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select POR_No as 'PO No',b.A_Name as 'Agent',c.M_Name as 'Mill' from PO_Reel as a,Agent_Master as b,Mill_Master as c where a.A_ID=b.A_ID and a.M_ID=c.M_ID order by a.POR_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }

        }

        private void GridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlActive.Enabled = true;
            enableDisable(false);
            cmdPrintPO2.Enabled = true;
            txtPOR_No.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            ddlA_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlA_ID.Text = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlM_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlM_ID.Text = GridView1.Rows[e.RowIndex].Cells[2].Value.ToString();


            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select convert(varchar(20),POR_Dt,103) as 'POR_Dt',Cr_Dy,Delv_Days,Delv_Place,POR_Active from PO_Reel where POR_No='" + txtPOR_No.Text.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtPOR_Dt.Text = Convert.ToString(dr1["POR_Dt"]);
                txtCr_Dy.Text = Convert.ToString(dr1["Cr_Dy"]);
                txtDelv_Days.Text = Convert.ToString(dr1["Delv_Days"]);
                txtDelv_Place.Text = Convert.ToString(dr1["Delv_Place"]);
                ddlActive.Text = Convert.ToString(dr1["POR_Active"]);
            }
            dr1.Close();
            con1.Close();


            SqlDataAdapter da = new SqlDataAdapter(" select POR_Size as 'Size',b.PQ_Desc as 'Quality',POR_BF as 'BF',POR_GSM as 'GSM',POR_Rate as 'Rate',POR_Qty as 'Quantity',POR_Bal as 'Balance'  from PO_ReelDetail as a,PQuality_Master as b where a.PQ_ID=b.PQ_ID and a.POR_No='"+txtPOR_No.Text+"'  order by POR_No", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridviewDetails.DataSource = dt;
          

        }



        protected void pdfGenerate()
        {

            funclib = new FunctionLib();
            string strCon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strCon);
            SqlConnection con4 = new SqlConnection(strCon);



            string strsql5 = "select  Grp_Name from Group_Master  where Grp_Active='Yes' and Grp_ID = '" + Group_ID + "'";
            SqlCommand cmd5 = new SqlCommand(strsql5, con);
            con.Open();
            SqlDataReader dr = cmd5.ExecuteReader();
            if (dr.Read())
            {


                Grp_Name = Convert.ToString(dr["Grp_Name"]);



            }
            dr.Close();
            con.Close();

          
          

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Pdf Documents (*.pdf)|*.pdf";
            sfd.FileName = "PO Craft PaperReel.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                strOpenDoc = sfd.FileName;

                //Create Document class obejct and set its size to letter and give space left, right, Top, Bottom Margin
                Document doc = new Document(iTextSharp.text.PageSize.A4, 50, 35, 42, 35);
                try
                {
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    //Open Document to write
                    doc.Open();



                    //var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    //var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                    string fontCAMBRIAB = Path.Combine(Application.StartupPath, "CAMBRIAB.TTF");
                    string fontArial = Path.Combine(Application.StartupPath, "arial.ttf");

                    FontFactory.Register(fontArial, "NewFont");
                    iTextSharp.text.Font myBoldFont = FontFactory.GetFont("NewFont");

                    FontFactory.Register(fontArial, "BodyFont");
                    iTextSharp.text.Font myBoldFont2 = FontFactory.GetFont("BodyFont");


                    var bigFontbold = FontFactory.GetFont("NewFont", 14, 1);
                    var titleFont = FontFactory.GetFont("NewFont", 14);
                    var subTitleFont = FontFactory.GetFont("NewFont", 14);
                    var boldTableFont = FontFactory.GetFont("NewFont", 12);
                    var endingMessageFont = FontFactory.GetFont("NewFont", 12);
                    var bodyFont = FontFactory.GetFont("NewFont", 12);
                    var underline = FontFactory.GetFont("BodyFont", 10);
                    var underlinBold = FontFactory.GetFont("NewFont", 9);
                    var smallfont = FontFactory.GetFont("NewFont", 8);
                    var underlinBoldfont = FontFactory.GetFont("NewFont", 10, 1);
                    var underline2 = FontFactory.GetFont("NewFont", 9);
                    var footerfont = FontFactory.GetFont("NewFont", 5);


                    //string rptPath = Path.Combine(Application.StartupPath, "OPSM_02.jpg");
                    //var logo = iTextSharp.text.Image.GetInstance(rptPath);



                    //logo.ScaleAbsoluteHeight(45);
                    ////logo.ScaleAbsoluteHeight(35);
                    //logo.ScaleAbsoluteWidth(120);
                    //logo.Alignment = Element.ALIGN_RIGHT;
                    //logo.SetAbsolutePosition(400, 760);





                    //Chunk footer = new Chunk("LifeLine Doctor - www.ropras.com" + '\n', footerfont);
                    //Paragraph Parafooter = new Paragraph(doc.Bottom,footer);
                    //Parafooter.Alignment = Element.ALIGN_RIGHT;

                    //tbl footer
                    PdfPTable footerTbl = new PdfPTable(1);
                    footerTbl.TotalWidth = doc.PageSize.Width;

                    footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
                    PdfPCell cell = new PdfPCell(new Phrase("ePacker - www.ropras.com", footerfont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Border = 0;
                    footerTbl.AddCell(cell);
                    footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin + 20), wri.DirectContent);



                    //doc.Add(logo);
                    //doc.Add(new Paragraph("" + '\n'));
                    //doc.Add(new Paragraph("" + '\n'));



                    Chunk MainTitle = new Chunk(Grp_Name + '\n', boldTableFont);
                    MainTitle.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaMainTitle = new Paragraph(MainTitle);
                    //ParaMainTitle.SpacingBefore = 5f;
                    //ParaMainTitle.SpacingAfter = 5f;


                    Chunk chunk = new Chunk("Purchase Order – Craft Paper / Reel" + '\n', titleFont);
                    chunk.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaTitle = new Paragraph(chunk);
                    ParaTitle.SpacingBefore = 5f;
                    ParaTitle.SpacingAfter = 5f;





                    var phrase2 = new Phrase();
                    phrase2.Add(new Chunk("PO No. : ", underline));
                    Chunk c2 = new Chunk(txtPOR_No.Text.Trim().ToString(), underline);
                    c2.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c2);

                    phrase2.Add(new Chunk("        "));

                    phrase2.Add(new Chunk("PO Dt. : ", underline));
                    Chunk c3 = new Chunk(txtPOR_Dt.Text.Trim().ToString() + '\n', underline);
                    c3.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c3);

                    Paragraph pf1 = new Paragraph(phrase2);




                    var phrase77 = new Phrase();
                    phrase77.Add(new Chunk("Agent    : ", underline));
                    Chunk cadd77 = new Chunk(ddlA_ID.Text + '\n', underline);
                    cadd77.SetUnderline(0.5f, -1.5f);
                    phrase77.Add(cadd77);

                    Paragraph pf4_4 = new Paragraph(phrase77);



                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("Mill        : ", underline));
                    Chunk c81 = new Chunk(ddlM_ID.Text.Trim().ToString(), underline);
                    c81.SetUnderline(0.5f, -1.5f);
                    phrase8.Add(c81);

                    Paragraph pf7 = new Paragraph(phrase8);
                    // pf4.SpacingBefore = 5f;


                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("Credit Days  :  ", underline));
                    Chunk cins = new Chunk(txtCr_Dy.Text.Trim().ToString(), underline);
                    cins.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(cins);


                    phraseIns.Add(new Chunk("               "));

                    phraseIns.Add(new Chunk("Delivery Days : ", underline));
                    Chunk c83 = new Chunk(txtDelv_Days.Text.Trim().ToString(), underline);
                    c83.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(c83);

                    Paragraph pf8 = new Paragraph(phraseIns);

                    var phraseChall = new Phrase();
                    phraseChall.Add(new Chunk("Delivery Place :  ", underline));
                    Chunk cChall = new Chunk(txtDelv_Place.Text.Trim().ToString(), underline);
                    cChall.SetUnderline(0.5f, -1.5f);
                    phraseChall.Add(cChall);
                    
                    Paragraph pf8_1 = new Paragraph(phraseChall);
                    pf8_1.SpacingAfter = 20f;
                                  





                    doc.Add(MainTitle);

                    doc.Add(ParaTitle);
                    doc.Add(pf1);
                    doc.Add(pf4_4);
                    doc.Add(pf7);
                    doc.Add(pf8);
                    doc.Add(pf8_1);


                    //Itemg Grid6

                    PdfPTable t7 = new PdfPTable(7);
                    //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                    //t3.SetWidths(widthst3);
                    t7.DefaultCell.BorderWidth = 1;
                    //t7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                   // t7.DefaultCell.BorderColor = BaseColor.WHITE;
                    t7.WidthPercentage = 100;
                    // t4.SpacingAfter = 4f;
                    //t1.HorizontalAlignment = Element.ALIGN_RIGHT;


                    //SqlDataAdapter da = new SqlDataAdapter(" select POR_Size as 'Size',b.PQ_Desc as 'Quality',POR_BF as 'BF',POR_GSM as 'GSM',POR_Rate as 'Rate',POR_Qty as 'Quantity',POR_Bal as 'Balance'  from PO_ReelDetail as a,PQuality_Master as b where a.PQ_ID=b.PQ_ID and a.POR_No='" + txtPOR_No.Text + "'  order by POR_No desc", con);

                    PdfPCell Art_Dt = new PdfPCell(new Phrase("Size", underlinBold));
                    PdfPCell Speci_Code = new PdfPCell(new Phrase("Quality", underlinBold));
                    PdfPCell For_Pedilite = new PdfPCell(new Phrase("BF", underlinBold));
                    PdfPCell Pedilite_GSM = new PdfPCell(new Phrase("GSM", underlinBold));
                    PdfPCell Pedilite_WtBox = new PdfPCell(new Phrase("Rate", underlinBold));
                    PdfPCell Pedilite_PReq = new PdfPCell(new Phrase("Quantity", underlinBold));
                    PdfPCell I_Lock = new PdfPCell(new Phrase("Balance", underlinBold));

                                 



                    t7.AddCell(Art_Dt);
                    t7.AddCell(Speci_Code);
                    t7.AddCell(For_Pedilite);
                   t7.AddCell(Pedilite_GSM);
                    t7.AddCell(Pedilite_WtBox);
                    t7.AddCell(Pedilite_PReq);
                    t7.AddCell(I_Lock);




                    foreach (DataGridViewRow rows in GridViewAddDetails.Rows)
                    {

                        //'',,,,,,,
                        string Length_MMstr = GridViewAddDetails.Rows[rows.Index].Cells["Size"].Value.ToString();
                        string Width_MMstr = GridViewAddDetails.Rows[rows.Index].Cells["Quality"].Value.ToString();

                        string Height_MMstr = GridViewAddDetails.Rows[rows.Index].Cells["BF"].Value.ToString();
                        string Dimn_Optstr = GridViewAddDetails.Rows[rows.Index].Cells["GSM"].Value.ToString();
                        string Length_MM_Convstr = GridViewAddDetails.Rows[rows.Index].Cells["Rate"].Value.ToString();
                        string Width_MM_Convstr = GridViewAddDetails.Rows[rows.Index].Cells["Quantity"].Value.ToString();
                        string Width_MM_Convstr2 = GridViewAddDetails.Rows[rows.Index].Cells["Balance"].Value.ToString();
                      


                        PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                        PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                        PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                        PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                        PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                        PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                        PdfPCell c35_5 = new PdfPCell(new Phrase(Width_MM_Convstr2, underlinBold));
                 





                        t7.AddCell(c1_1);
                        t7.AddCell(c1);
                        t7.AddCell(c32);
                        t7.AddCell(c33);
                        t7.AddCell(c34);
                        t7.AddCell(c35);
                        t7.AddCell(c35_5);





                       

                     
                       
                    }
                    doc.Add(t7);
                    //LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    //doc.Add(new Chunk(line3));








                    //Itemg Grid2






                }
                catch (DocumentException dex)
                {


                    //Handle document exception
                }
                catch (IOException ioex)
                {
                    //Handle IO exception
                }
                catch (Exception ex)
                {
                    //Handle Other Exception
                }
                finally
                {
                    doc.Close(); //Close document
                }
            }
        }

        private void cmdPrintPO_Click(object sender, EventArgs e)
        {
            pdfGenerate();
            if (strOpenDoc != "" & strOpenDoc != null)
            {
                Process.Start(strOpenDoc);
            }
            strOpenDoc = "";

        }

        private void cmdPrintPO2_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strCon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strCon);
            SqlConnection con4 = new SqlConnection(strCon);



            string strsql5 = "select  Grp_Name from Group_Master  where Grp_Active='Yes' and Grp_ID = '" + Group_ID + "'";
            SqlCommand cmd5 = new SqlCommand(strsql5, con);
            con.Open();
            SqlDataReader dr = cmd5.ExecuteReader();
            if (dr.Read())
            {


                Grp_Name = Convert.ToString(dr["Grp_Name"]);



            }
            dr.Close();
            con.Close();




            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Pdf Documents (*.pdf)|*.pdf";
            sfd.FileName = "Copy Of PO Craft PaperReel.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                strOpenDoc = sfd.FileName;

                //Create Document class obejct and set its size to letter and give space left, right, Top, Bottom Margin
                Document doc = new Document(iTextSharp.text.PageSize.A4, 50, 35, 42, 35);
                try
                {
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    //Open Document to write
                    doc.Open();



                    //var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    //var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                    string fontCAMBRIAB = Path.Combine(Application.StartupPath, "CAMBRIAB.TTF");
                    string fontArial = Path.Combine(Application.StartupPath, "arial.ttf");

                    FontFactory.Register(fontArial, "NewFont");
                    iTextSharp.text.Font myBoldFont = FontFactory.GetFont("NewFont");

                    FontFactory.Register(fontArial, "BodyFont");
                    iTextSharp.text.Font myBoldFont2 = FontFactory.GetFont("BodyFont");


                    var bigFontbold = FontFactory.GetFont("NewFont", 14, 1);
                    var titleFont = FontFactory.GetFont("NewFont", 14);
                    var subTitleFont = FontFactory.GetFont("NewFont", 14);
                    var boldTableFont = FontFactory.GetFont("NewFont", 12);
                    var endingMessageFont = FontFactory.GetFont("NewFont", 12);
                    var bodyFont = FontFactory.GetFont("NewFont", 12);
                    var underline = FontFactory.GetFont("BodyFont", 10);
                    var underlinBold = FontFactory.GetFont("NewFont", 9);
                    var smallfont = FontFactory.GetFont("NewFont", 8);
                    var underlinBoldfont = FontFactory.GetFont("NewFont", 10, 1);
                    var underline2 = FontFactory.GetFont("NewFont", 9);
                    var footerfont = FontFactory.GetFont("NewFont", 5);


                    //string rptPath = Path.Combine(Application.StartupPath, "OPSM_02.jpg");
                    //var logo = iTextSharp.text.Image.GetInstance(rptPath);



                    //logo.ScaleAbsoluteHeight(45);
                    ////logo.ScaleAbsoluteHeight(35);
                    //logo.ScaleAbsoluteWidth(120);
                    //logo.Alignment = Element.ALIGN_RIGHT;
                    //logo.SetAbsolutePosition(400, 760);





                    //Chunk footer = new Chunk("LifeLine Doctor - www.ropras.com" + '\n', footerfont);
                    //Paragraph Parafooter = new Paragraph(doc.Bottom,footer);
                    //Parafooter.Alignment = Element.ALIGN_RIGHT;

                    //tbl footer
                    PdfPTable footerTbl = new PdfPTable(1);
                    footerTbl.TotalWidth = doc.PageSize.Width;

                    footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
                    PdfPCell cell = new PdfPCell(new Phrase("ePacker - www.ropras.com", footerfont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Border = 0;
                    footerTbl.AddCell(cell);
                    footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin + 20), wri.DirectContent);



                    //doc.Add(logo);
                    //doc.Add(new Paragraph("" + '\n'));
                    //doc.Add(new Paragraph("" + '\n'));



                    Chunk MainTitle = new Chunk(Grp_Name + '\n', boldTableFont);
                    MainTitle.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaMainTitle = new Paragraph(MainTitle);
                    //ParaMainTitle.SpacingBefore = 5f;
                    //ParaMainTitle.SpacingAfter = 5f;


                    Chunk chunk = new Chunk("Purchase Order – Craft Paper / Reel" + '\n', titleFont);
                    chunk.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaTitle = new Paragraph(chunk);
                    ParaTitle.SpacingBefore = 5f;
                    ParaTitle.SpacingAfter = 5f;





                    var phrase2 = new Phrase();
                    phrase2.Add(new Chunk("PO No. : ", underline));
                    Chunk c2 = new Chunk(txtPOR_No.Text.Trim().ToString(), underline);
                    c2.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c2);

                    phrase2.Add(new Chunk("        "));

                    phrase2.Add(new Chunk("PO Dt. : ", underline));
                    Chunk c3 = new Chunk(txtPOR_Dt.Text.Trim().ToString() + '\n', underline);
                    c3.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c3);

                    Paragraph pf1 = new Paragraph(phrase2);




                    var phrase77 = new Phrase();
                    phrase77.Add(new Chunk("Agent    : ", underline));
                    Chunk cadd77 = new Chunk(ddlA_ID.Text + '\n', underline);
                    cadd77.SetUnderline(0.5f, -1.5f);
                    phrase77.Add(cadd77);

                    Paragraph pf4_4 = new Paragraph(phrase77);



                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("Mill        : ", underline));
                    Chunk c81 = new Chunk(ddlM_ID.Text.Trim().ToString(), underline);
                    c81.SetUnderline(0.5f, -1.5f);
                    phrase8.Add(c81);

                    Paragraph pf7 = new Paragraph(phrase8);
                    // pf4.SpacingBefore = 5f;


                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("Credit Days  :  ", underline));
                    Chunk cins = new Chunk(txtCr_Dy.Text.Trim().ToString(), underline);
                    cins.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(cins);


                    phraseIns.Add(new Chunk("               "));

                    phraseIns.Add(new Chunk("Delivery Days : ", underline));
                    Chunk c83 = new Chunk(txtDelv_Days.Text.Trim().ToString(), underline);
                    c83.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(c83);

                    Paragraph pf8 = new Paragraph(phraseIns);

                    var phraseChall = new Phrase();
                    phraseChall.Add(new Chunk("Delivery Place :  ", underline));
                    Chunk cChall = new Chunk(txtDelv_Place.Text.Trim().ToString(), underline);
                    cChall.SetUnderline(0.5f, -1.5f);
                    phraseChall.Add(cChall);

                    Paragraph pf8_1 = new Paragraph(phraseChall);
                    pf8_1.SpacingAfter = 20f;






                    doc.Add(MainTitle);

                    doc.Add(ParaTitle);
                    doc.Add(pf1);
                    doc.Add(pf4_4);
                    doc.Add(pf7);
                    doc.Add(pf8);
                    doc.Add(pf8_1);


                    //Itemg Grid6

                    PdfPTable t7 = new PdfPTable(7);
                    //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                    //t3.SetWidths(widthst3);
                    t7.DefaultCell.BorderWidth = 1;
                    //t7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // t7.DefaultCell.BorderColor = BaseColor.WHITE;
                    t7.WidthPercentage = 100;
                    // t4.SpacingAfter = 4f;
                    //t1.HorizontalAlignment = Element.ALIGN_RIGHT;


                    //SqlDataAdapter da = new SqlDataAdapter(" select POR_Size as 'Size',b.PQ_Desc as 'Quality',POR_BF as 'BF',POR_GSM as 'GSM',POR_Rate as 'Rate',POR_Qty as 'Quantity',POR_Bal as 'Balance'  from PO_ReelDetail as a,PQuality_Master as b where a.PQ_ID=b.PQ_ID and a.POR_No='" + txtPOR_No.Text + "'  order by POR_No desc", con);

                    PdfPCell Art_Dt = new PdfPCell(new Phrase("Size", underlinBold));
                    PdfPCell Speci_Code = new PdfPCell(new Phrase("Quality", underlinBold));
                    PdfPCell For_Pedilite = new PdfPCell(new Phrase("BF", underlinBold));
                    PdfPCell Pedilite_GSM = new PdfPCell(new Phrase("GSM", underlinBold));
                    PdfPCell Pedilite_WtBox = new PdfPCell(new Phrase("Rate", underlinBold));
                    PdfPCell Pedilite_PReq = new PdfPCell(new Phrase("Quantity", underlinBold));
                    PdfPCell I_Lock = new PdfPCell(new Phrase("Balance", underlinBold));





                    t7.AddCell(Art_Dt);
                    t7.AddCell(Speci_Code);
                    t7.AddCell(For_Pedilite);
                    t7.AddCell(Pedilite_GSM);
                    t7.AddCell(Pedilite_WtBox);
                    t7.AddCell(Pedilite_PReq);
                    t7.AddCell(I_Lock);




                    foreach (DataGridViewRow rows in GridviewDetails.Rows)
                    {

                        //'',,,,,,,
                        string Length_MMstr = GridviewDetails.Rows[rows.Index].Cells["Size"].Value.ToString();
                        string Width_MMstr = GridviewDetails.Rows[rows.Index].Cells["Quality"].Value.ToString();

                        string Height_MMstr = GridviewDetails.Rows[rows.Index].Cells["BF"].Value.ToString();
                        string Dimn_Optstr = GridviewDetails.Rows[rows.Index].Cells["GSM"].Value.ToString();
                        string Length_MM_Convstr = GridviewDetails.Rows[rows.Index].Cells["Rate"].Value.ToString();
                        string Width_MM_Convstr = GridviewDetails.Rows[rows.Index].Cells["Quantity"].Value.ToString();
                        string Width_MM_Convstr2 = GridviewDetails.Rows[rows.Index].Cells["Balance"].Value.ToString();



                        PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                        PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                        PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                        PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                        PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                        PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                        PdfPCell c35_5 = new PdfPCell(new Phrase(Width_MM_Convstr2, underlinBold));






                        t7.AddCell(c1_1);
                        t7.AddCell(c1);
                        t7.AddCell(c32);
                        t7.AddCell(c33);
                        t7.AddCell(c34);
                        t7.AddCell(c35);
                        t7.AddCell(c35_5);









                    }
                    doc.Add(t7);
                    //LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    //doc.Add(new Chunk(line3));








                    //Itemg Grid2






                }
                catch (DocumentException dex)
                {


                    //Handle document exception
                }
                catch (IOException ioex)
                {
                    //Handle IO exception
                }
                catch (Exception ex)
                {
                    //Handle Other Exception
                }
                finally
                {
                    doc.Close(); //Close document
                }
            }
          
            if (strOpenDoc != "" & strOpenDoc != null)
            {
                Process.Start(strOpenDoc);
            }
            strOpenDoc = "";

        }

      
      
    }
}
