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
    public partial class RPeP_DispForm404 : Form
    {   
        string session, strSQL, Group_ID, Sr_No;
        string P_Name, P_ID, P_PONo, P_PODt, Box_Qty, PQ_ID;
        string griOrder_ID, griPartyPono, griPartoPoDt, griP_Name, strOpenDoc, Grp_Name;
        private FunctionLib funclib;
        public RPeP_DispForm404()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_DispForm404_Load(object sender, EventArgs e)
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
            monthCalendar2.Visible = false;
            monthCalendar3.Visible = false;

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            Sr_No = funclib.I_ID("E", con, "select [404_No]  from Dispatch_Form404 order by [404_No]   desc");
           txt404_No.Text = Sr_No;


           ddlSearch.Items.Add("");
           ddlSearch.Items.Add("Sr.No.");
           ddlSearch.Items.Add("Form 404 Dt");
        

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txt404_No.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("404 No Cannot be Blank");
                txt404_No.Focus();
            }

            else if (txt404_Date.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txt404_Date.Focus();
            }
            else if (txt404_Place.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txt404_Place.Focus();

            }
            else if (txt404_Time.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txt404_Time.Focus();
            }
            else if (txtBefore_Date.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtBefore_Date.Focus();
            }
            else if (txtVeh_No.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtVeh_No.Focus();
            }
            else if (txtBy_Time.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtBy_Time.Focus();
            }
            else if (txtCkPost_Name.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtCkPost_Name.Focus();
            }
            else if (txtFrom_State.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtFrom_State.Focus();
            }
            else if (txtFrom_State2.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtFrom_State2.Focus();
            }
            else if (txtOwner_Addr.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtOwner_Addr.Focus();
            }
            else if (txtSon_Of.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtSon_Of.Focus();
            }
            else if (txtTo_State.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtTo_State.Focus();
            }
            else if (txtTransp_Addr.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtTransp_Addr.Focus();
            }
            
            else if (ddlActive.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlActive.Focus();
            }




            else
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strcon);
                SqlConnection con = new SqlConnection(strcon);


                //Inserting records 

                SqlCommand cmdPositive = new SqlCommand("insert into Dispatch_Form404([404_No],[404_Dt],Grp_ID,CkPost_Name,Son_Of,Owner_Addr,Veh_No,Transp_Name,Transp_Addr,From_State,To_State,Before_Date,By_Time,[404_Place],[404_Time],[404_Active],Add_By,Add_ByNode,Add_On) values('" + txt404_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txt404_Date.Text.Trim().Replace("'", "''").ToString() + "',103),'" + Group_ID + "','" + txtCkPost_Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtSon_Of.Text.Trim().Replace("'", "''").ToString() + "','" + txtOwner_Addr.Text.Trim().Replace("'", "''").ToString() + "','" + txtVeh_No.Text.Trim().Replace("'", "''").ToString() + "','" + txtTransp_Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtTransp_Addr.Text.Trim().Replace("'", "''").ToString() + "','" + txtFrom_State.Text.Trim().Replace("'", "''").ToString() + "','" + txtTo_State.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txtBefore_Date.Text.Trim().Replace("'", "''").ToString() + "',103),'" + txtBy_Time.Text.Trim().Replace("'", "''").ToString() + "','" + txt404_Place.Text.Trim().Replace("'", "''").ToString() + "','" + txt404_Time.Text.Trim().Replace("'", "''").ToString() + "','" + ddlActive.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
                con.Open();
                int Positive = cmdPositive.ExecuteNonQuery();
                MessageBox.Show("Record Inserted");
                con.Close();
                pdfGenerate();
                ClearAll();
                if (strOpenDoc != "" & strOpenDoc != null)
                {
                    Process.Start(strOpenDoc);
                }
                strOpenDoc = "";


            }
        }
        protected void ClearAll()
        {
            
            ddlSearch.Text = "";
            txt404_Date.Text = "";
            txt404_No.Text = "";
            txt404_Place.Text = "";
            txt404_Time.Text = "";
            txtBefore_Date.Text = "";
            txtBy_Time.Text = "";
            txtCkPost_Name.Text = "";
            txtFrom_State.Text = "";
            txtFrom_State2.Text = "";
            txtOwner_Addr.Text = "";
            txtSon_Of.Text = "";
            txtTo_State.Text = "";
            txtTransp_Addr.Text = "";
            txtTransp_Name.Text = "";
            txtVeh_No.Text = "";

            ddlActive.Text = "Yes";
            cmdPrint.Visible = false;
            ddlActive.Enabled = false;


            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);


            Sr_No = funclib.I_ID("E", con, "select [404_No]  from Dispatch_Form404 order by [404_No]   desc");
            txt404_No.Text = Sr_No;



            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            txt_Search.Enabled = true;
            txt404_Date.Enabled = true;
            txt404_No.Enabled = true;
            txt404_Place.Enabled = true;
            txt404_Time.Enabled = true;
            txtBy_Time.Enabled = true;
            txtCkPost_Name.Enabled = true;
            txtFrom_State.Enabled = true;
            txtFrom_State2.Enabled = true;
            txtOwner_Addr.Enabled = true;
            txtSon_Of.Enabled = true;
            txtTo_State.Enabled = true;
            txtTransp_Name.Enabled = true;
            txtVeh_No.Enabled = true;
            txtTransp_Addr.Enabled = true;
            txtBefore_Date.Enabled = true;

         


        }
        private void cmdReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Dispatch_Form404 set [404_Active] ='" + ddlActive.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where [404_No]  ='" + txt404_No.Text.Trim().Replace("'", "''").ToString() + "'", con);

                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");

                ClearAll();
            }
        }

        private void CmdSearch_Click(object sender, EventArgs e)
        {
          
           

            if (ddlSearch.Text == "Sr.No.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select [404_No] as 'Sr.No.',convert (varchar(20),[404_Dt],103) as 'Form 404 Dt.' from Dispatch_Form404 where [404_No] like '%" + txt_Search.Text.ToString() + "%'  order by [404_No]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
             
            }
            else if (ddlSearch.Text == "Form 404 Dt")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select [404_No] as 'Sr.No.',convert (varchar(20),[404_Dt],103) as 'Form 404 Dt.' from Dispatch_Form404 where [404_Dt] =Convert(datetime,'" + txt_Search.Text + "',103) order by [404_No]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select [404_No] as 'Sr.No.',convert (varchar(20),[404_Dt],103) as 'Form 404 Dt.' from Dispatch_Form404  order by [404_No]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
 
            }

        }

       

        private void GridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;

            cmdPrint.Visible = true;

            ddlActive.Enabled = true;
            txt_Search.Enabled = false;
            txt404_Date.Enabled = false;
            txt404_No.Enabled = false;
            txt404_Place.Enabled = false;
            txt404_Time.Enabled = false;
            txtBy_Time.Enabled = false;
            txtCkPost_Name.Enabled = false;
            txtFrom_State.Enabled = false;
            txtFrom_State2.Enabled = false;
            txtOwner_Addr.Enabled = false;
            txtSon_Of.Enabled = false;
            txtTo_State.Enabled = false;
            txtTransp_Name.Enabled = false;
            txtVeh_No.Enabled = false;
            txtTransp_Addr.Enabled = false;
            txtBefore_Date.Enabled = false;


            txt404_No.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //ddlOrder_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt404_Date.Text = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        




            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select CkPost_Name,Son_Of,Owner_Addr,Veh_No,Transp_Name,Transp_Addr,From_State,To_State,convert(varchar(20),Before_Date,103) as 'Before_Date',By_Time,[404_Place] as 'Place',[404_Time] as 'Time',[404_Active] as 'Active' from dbo.Dispatch_Form404 where [404_No] ='" + txt404_No.Text + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtCkPost_Name.Text = Convert.ToString(dr1["CkPost_Name"]);
                txtSon_Of.Text = Convert.ToString(dr1["Son_Of"]);
                txtOwner_Addr.Text = Convert.ToString(dr1["Owner_Addr"]);
                txtVeh_No.Text = Convert.ToString(dr1["Veh_No"]);
                txtTransp_Name.Text = Convert.ToString(dr1["Transp_Name"]);
                txtTransp_Addr.Text = Convert.ToString(dr1["Transp_Addr"]);
                txtFrom_State.Text = Convert.ToString(dr1["From_State"]);
                txtFrom_State2.Text = txtFrom_State.Text;

                txtTo_State.Text = Convert.ToString(dr1["To_State"]);
                txtBefore_Date.Text = Convert.ToString(dr1["Before_Date"]);
                txtBy_Time.Text = Convert.ToString(dr1["By_Time"]);

                txt404_Place.Text = Convert.ToString(dr1["Place"]);
                txt404_Time.Text = Convert.ToString(dr1["Time"]);
                ddlActive.Text = Convert.ToString(dr1["Active"]);
              

            }
            dr1.Close();
            con1.Close();









        }

        private void txtSon_Of_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtFrom_State2_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtFrom_State_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtTo_State_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtBy_Time_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnColun(e);
        }

        private void txt404_Place_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txt404_Time_KeyPress(object sender, KeyPressEventArgs e)
       {
           funclib = new FunctionLib();
           funclib.onlyNumbersnColun(e);
        }

        private void txtBefore_Date_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtBefore_Date.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtBefore_Date.Focus();

        }

        private void txt404_Date_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar3.Visible = true;
        }

        private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        {
            txt404_Date.Text = monthCalendar3.SelectionStart.ToShortDateString();
            monthCalendar3.Visible = false;
            txt404_Date.Focus();
        }

        private void txtBefore_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txt404_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txt_Search_MouseClick(object sender, MouseEventArgs e)
        {
            if (ddlSearch.Text == "Form 404 Dt")
            {
                monthCalendar2.Visible = true;
            }
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txt_Search.Text = monthCalendar2.SelectionStart.ToShortDateString();
            monthCalendar2.Visible = false;
            txt_Search.Focus();
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
            sfd.FileName = "Form No 404.pdf";
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


                    var bigFontbold = FontFactory.GetFont("NewFont", 14,1);
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


                    Chunk chunk = new Chunk("Dispatch : Invoice Copy" + '\n', titleFont);
                    chunk.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaTitle = new Paragraph(chunk);
                    ParaTitle.SpacingBefore = 5f;
                    ParaTitle.SpacingAfter = 5f;




                    var phrase2 = new Phrase();
                    phrase2.Add(new Chunk("Gujrat Value Added Tax Rules, 2006", underline));
                    Paragraph pf1 = new Paragraph(phrase2);
                    pf1.Alignment = 1;


                   var phrase77 = new Phrase();
                    phrase77.Add(new Chunk("Form No. 404", bigFontbold));
                    Paragraph pf4_4 = new Paragraph(phrase77);
                    pf4_4.Alignment = 1;



                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("(See Sub-Rule (1) of Rule 52)", underline));
                    Paragraph pf7 = new Paragraph(phrase8);
                    pf7.Alignment = 1;
                    // pf4.SpacingBefore = 5f;


                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("APPLICATION FOR ISSUE OF TRANSIT PASS UNDER SUB-SECTION (1) OF SECTION – 69", underline));
                    Paragraph pf8 = new Paragraph(phraseIns);
                    pf8.Alignment = 1;

                    var phraseChall = new Phrase();
                    phraseChall.Add(new Chunk("OF THE GUJRAT VALUE ADDED TAX ACT, 2003.", underline));
                    Paragraph pf8_1 = new Paragraph(phraseChall);
                    pf8_1.Alignment = 1;



                    var phraseIns2 = new Phrase();
                    phraseIns2.Add(new Chunk("ORIGINAL", smallfont));
                    Paragraph pf8_8 = new Paragraph(phraseIns2);
                    pf8_8.Alignment = 2;


                    var phraseIns23 = new Phrase();
                    phraseIns23.Add(new Chunk("DUPLICATE", smallfont));
                    Paragraph pf8_99 = new Paragraph(phraseIns23);
                    pf8_99.Alignment = 2;

                    var phrase15 = new Phrase();
                    phrase15.Add(new Chunk("TRIPLICATE", smallfont));
                    Paragraph pf9 = new Paragraph(phrase15);
                    pf9.Alignment = 2;

                    var phrase16 = new Phrase();
                    phrase16.Add(new Chunk("The Officer in Charge,", underline));
                    Paragraph pf10 = new Paragraph(phrase16);

                    var phrase17 = new Phrase();
                    phrase17.Add(new Chunk(txtCkPost_Name.Text, underline));
                    Paragraph pf11 = new Paragraph(phrase17);
                    pf11.SpacingAfter = 5f;

                    var phrase18 = new Phrase();
                    phrase18.Add(new Chunk("Sir,", underline));
                    Paragraph pf12 = new Paragraph(phrase18);
                    pf12.SpacingAfter = 7f;

                    var phrase19 = new Phrase();
                    phrase19.Add(new Chunk("1.    I son of Shri.  "+txtSon_Of.Text.ToString(), underline));
                    Paragraph pf13 = new Paragraph(phrase19);

                    var phrase20 = new Phrase();
                    phrase20.Add(new Chunk("      resident of      " + txtOwner_Addr.Text.ToString(), underline));
                    Paragraph pf14 = new Paragraph(phrase20);

                    var phrase21 = new Phrase();
                    phrase21.Add(new Chunk("      hereby declare that I am the owner or driver of the vehicle / truck No.  " + txtVeh_No.Text.ToString(), underline));
                    Paragraph pf15 = new Paragraph(phrase21);

                    var phrase22 = new Phrase();
                    phrase22.Add(new Chunk("      belonging to  " + txtTransp_Name.Text.ToString(), underline));
                    Paragraph pf16 = new Paragraph(phrase22);

                    var phrase23 = new Phrase();
                    phrase23.Add(new Chunk("      " + txtTransp_Addr.Text.ToString(), underline));
                    Paragraph pf17 = new Paragraph(phrase23);
                    pf17.SpacingAfter = 7f;

                    var phrase24 = new Phrase();
                    phrase24.Add(new Chunk("       (Name and Address of the owner or transporting agency)", smallfont));
                    Paragraph pf18 = new Paragraph(phrase24);
                    pf18.SpacingAfter = 7f;


                    var phrase25 = new Phrase();
                    phrase25.Add(new Chunk("2.    I hereby declare that the consignment mentioned in the Annexure annexed hereto being carried by", underline));
                    Paragraph pf19 = new Paragraph(phrase25);

                    var phrase26 = new Phrase();
                    phrase26.Add(new Chunk("      the above mentioned vehicle is meant for destination to the other State. It will not be unloaded or", underline));
                    Paragraph pf20 = new Paragraph(phrase26);

                    var phrase27 = new Phrase();
                    phrase27.Add(new Chunk("      delivered any where in the State of  " + txtFrom_State2.Text.ToString(), underline));
                    Paragraph pf21 = new Paragraph(phrase27);
                    pf21.SpacingAfter = 7f;

                    var phrase28 = new Phrase();
                    phrase28.Add(new Chunk("3.    I may be issued a transit pass for the said purpose.", underline));
                    Paragraph pf22 = new Paragraph(phrase28);
                    pf22.SpacingAfter = 7f;


                    var phrase29 = new Phrase();
                    phrase29.Add(new Chunk("4.    My vehicle / truck will cross the  " + txtFrom_State.Text.ToString() + " State and enter into "+txtTo_State.Text+" State", underline));
                    Paragraph pf23 = new Paragraph(phrase29);


                    var phrase30 = new Phrase();
                    phrase30.Add(new Chunk("      border at Check Post / Barrier on or before  " + txtBefore_Date.Text.ToString() + " date by " + txtBy_Time.Text + " hours (time).", underline));
                    Paragraph pf24 = new Paragraph(phrase30);
                    pf24.SpacingAfter = 7f;

                    var phrase31 = new Phrase();
                    phrase31.Add(new Chunk("    Place  " + txt404_Place.Text.ToString() , underline));
                    Paragraph pf25 = new Paragraph(phrase31);

                    var phrase32 = new Phrase();
                    phrase32.Add(new Chunk("    Date   " + txt404_Date.Text.ToString(), underline));
                    Paragraph pf26 = new Paragraph(phrase32);

                    var phrase33 = new Phrase();
                    phrase33.Add(new Chunk("    Time   " + txt404_Time.Text.ToString(), underline));
                    Paragraph pf27 = new Paragraph(phrase33);
                    pf27.SpacingAfter = 12f;

                    Paragraph pf27_1 = new Paragraph("  ");
                    Paragraph pf27_12 = new Paragraph("  ");


                    var phrase34 = new Phrase();
                    phrase34.Add(new Chunk("(Signature of the applicant)", underline));
                    Paragraph pf28 = new Paragraph(phrase34);
                    pf28.Alignment = 2;
                    pf28.SpacingBefore = 5f;



                    //doc.Add(MainTitle);

                    //doc.Add(ParaTitle);
                    doc.Add(pf1);

                    LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line3));


                    doc.Add(pf4_4);
                    doc.Add(pf7);
                    doc.Add(pf8);
                    doc.Add(pf8_1);
                    doc.Add(pf8_8);
                    doc.Add(pf8_99);
                    doc.Add(pf9);

                    LineSeparator line4 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line4));


                    doc.Add(pf10);
                    doc.Add(pf11);
                    doc.Add(pf12);
                    doc.Add(pf13);
                    doc.Add(pf14);
                    doc.Add(pf15);
                    doc.Add(pf16);
                    doc.Add(pf17);
                    doc.Add(pf18);
                    doc.Add(pf19);
                    doc.Add(pf20);
                    doc.Add(pf21);
                    doc.Add(pf22);
                    doc.Add(pf23);
                    doc.Add(pf24);
                    doc.Add(pf25);
                    doc.Add(pf26);
                    doc.Add(pf27);
                    doc.Add(pf27_1);
                    doc.Add(pf27_12);
                    doc.Add(pf28);
                  



                


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

        private void cmdPrint_Click(object sender, EventArgs e)
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
            sfd.FileName = "Copyof Form No 404.pdf";
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


                    Chunk chunk = new Chunk("Dispatch : Invoice Copy" + '\n', titleFont);
                    chunk.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaTitle = new Paragraph(chunk);
                    ParaTitle.SpacingBefore = 5f;
                    ParaTitle.SpacingAfter = 5f;




                    var phrase2 = new Phrase();
                    phrase2.Add(new Chunk("Gujrat Value Added Tax Rules, 2006", underline));
                    Paragraph pf1 = new Paragraph(phrase2);
                    pf1.Alignment = 1;


                    var phrase77 = new Phrase();
                    phrase77.Add(new Chunk("Form No. 404", bigFontbold));
                    Paragraph pf4_4 = new Paragraph(phrase77);
                    pf4_4.Alignment = 1;



                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("(See Sub-Rule (1) of Rule 52)", underline));
                    Paragraph pf7 = new Paragraph(phrase8);
                    pf7.Alignment = 1;
                    // pf4.SpacingBefore = 5f;


                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("APPLICATION FOR ISSUE OF TRANSIT PASS UNDER SUB-SECTION (1) OF SECTION – 69", underline));
                    Paragraph pf8 = new Paragraph(phraseIns);
                    pf8.Alignment = 1;

                    var phraseChall = new Phrase();
                    phraseChall.Add(new Chunk("OF THE GUJRAT VALUE ADDED TAX ACT, 2003.", underline));
                    Paragraph pf8_1 = new Paragraph(phraseChall);
                    pf8_1.Alignment = 1;



                    var phraseIns2 = new Phrase();
                    phraseIns2.Add(new Chunk("ORIGINAL", smallfont));
                    Paragraph pf8_8 = new Paragraph(phraseIns2);
                    pf8_8.Alignment = 2;


                    var phraseIns23 = new Phrase();
                    phraseIns23.Add(new Chunk("DUPLICATE", smallfont));
                    Paragraph pf8_99 = new Paragraph(phraseIns23);
                    pf8_99.Alignment = 2;

                    var phrase15 = new Phrase();
                    phrase15.Add(new Chunk("TRIPLICATE", smallfont));
                    Paragraph pf9 = new Paragraph(phrase15);
                    pf9.Alignment = 2;

                    var phrase16 = new Phrase();
                    phrase16.Add(new Chunk("The Officer in Charge,", underline));
                    Paragraph pf10 = new Paragraph(phrase16);

                    var phrase17 = new Phrase();
                    phrase17.Add(new Chunk(txtCkPost_Name.Text, underline));
                    Paragraph pf11 = new Paragraph(phrase17);
                    pf11.SpacingAfter = 5f;

                    var phrase18 = new Phrase();
                    phrase18.Add(new Chunk("Sir,", underline));
                    Paragraph pf12 = new Paragraph(phrase18);
                    pf12.SpacingAfter = 7f;

                    var phrase19 = new Phrase();
                    phrase19.Add(new Chunk("1.    I son of Shri.  " + txtSon_Of.Text.ToString(), underline));
                    Paragraph pf13 = new Paragraph(phrase19);

                    var phrase20 = new Phrase();
                    phrase20.Add(new Chunk("      resident of      " + txtOwner_Addr.Text.ToString(), underline));
                    Paragraph pf14 = new Paragraph(phrase20);

                    var phrase21 = new Phrase();
                    phrase21.Add(new Chunk("      hereby declare that I am the owner or driver of the vehicle / truck No.  " + txtVeh_No.Text.ToString(), underline));
                    Paragraph pf15 = new Paragraph(phrase21);

                    var phrase22 = new Phrase();
                    phrase22.Add(new Chunk("      belonging to  " + txtTransp_Name.Text.ToString(), underline));
                    Paragraph pf16 = new Paragraph(phrase22);

                    var phrase23 = new Phrase();
                    phrase23.Add(new Chunk("      " + txtTransp_Addr.Text.ToString(), underline));
                    Paragraph pf17 = new Paragraph(phrase23);
                    pf17.SpacingAfter = 7f;

                    var phrase24 = new Phrase();
                    phrase24.Add(new Chunk("       (Name and Address of the owner or transporting agency)", smallfont));
                    Paragraph pf18 = new Paragraph(phrase24);
                    pf18.SpacingAfter = 7f;


                    var phrase25 = new Phrase();
                    phrase25.Add(new Chunk("2.    I hereby declare that the consignment mentioned in the Annexure annexed hereto being carried by", underline));
                    Paragraph pf19 = new Paragraph(phrase25);

                    var phrase26 = new Phrase();
                    phrase26.Add(new Chunk("      the above mentioned vehicle is meant for destination to the other State. It will not be unloaded or", underline));
                    Paragraph pf20 = new Paragraph(phrase26);

                    var phrase27 = new Phrase();
                    phrase27.Add(new Chunk("      delivered any where in the State of  " + txtFrom_State2.Text.ToString(), underline));
                    Paragraph pf21 = new Paragraph(phrase27);
                    pf21.SpacingAfter = 7f;

                    var phrase28 = new Phrase();
                    phrase28.Add(new Chunk("3.    I may be issued a transit pass for the said purpose.", underline));
                    Paragraph pf22 = new Paragraph(phrase28);
                    pf22.SpacingAfter = 7f;


                    var phrase29 = new Phrase();
                    phrase29.Add(new Chunk("4.    My vehicle / truck will cross the  " + txtFrom_State.Text.ToString() + " State and enter into " + txtTo_State.Text + " State", underline));
                    Paragraph pf23 = new Paragraph(phrase29);


                    var phrase30 = new Phrase();
                    phrase30.Add(new Chunk("      border at Check Post / Barrier on or before  " + txtBefore_Date.Text.ToString() + " date by " + txtBy_Time.Text + " hours (time).", underline));
                    Paragraph pf24 = new Paragraph(phrase30);
                    pf24.SpacingAfter = 7f;

                    var phrase31 = new Phrase();
                    phrase31.Add(new Chunk("    Place  " + txt404_Place.Text.ToString(), underline));
                    Paragraph pf25 = new Paragraph(phrase31);

                    var phrase32 = new Phrase();
                    phrase32.Add(new Chunk("    Date   " + txt404_Date.Text.ToString(), underline));
                    Paragraph pf26 = new Paragraph(phrase32);

                    var phrase33 = new Phrase();
                    phrase33.Add(new Chunk("    Time   " + txt404_Time.Text.ToString(), underline));
                    Paragraph pf27 = new Paragraph(phrase33);
                    pf27.SpacingAfter = 12f;

                    Paragraph pf27_1 = new Paragraph("  ");
                    Paragraph pf27_12 = new Paragraph("  ");

                    var phrase34 = new Phrase();
                    phrase34.Add(new Chunk("(Signature of the applicant)", underline));
                    Paragraph pf28 = new Paragraph(phrase34);
                    pf28.Alignment = 2;

                    pf28.SpacingAfter = 2f;




                    //doc.Add(MainTitle);

                    //doc.Add(ParaTitle);
                    doc.Add(pf1);

                    LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line3));


                    doc.Add(pf4_4);
                    doc.Add(pf7);
                    doc.Add(pf8);
                    doc.Add(pf8_1);
                    doc.Add(pf8_8);
                    doc.Add(pf8_99);
                    doc.Add(pf9);

                    LineSeparator line4 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line4));


                    doc.Add(pf10);
                    doc.Add(pf11);
                    doc.Add(pf12);
                    doc.Add(pf13);
                    doc.Add(pf14);
                    doc.Add(pf15);
                    doc.Add(pf16);
                    doc.Add(pf17);
                    doc.Add(pf18);
                    doc.Add(pf19);
                    doc.Add(pf20);
                    doc.Add(pf21);
                    doc.Add(pf22);
                    doc.Add(pf23);
                    doc.Add(pf24);
                    doc.Add(pf25);
                    doc.Add(pf26);
                    doc.Add(pf27);
                    doc.Add(pf27_1);
                    doc.Add(pf27_12);
                    doc.Add(pf28);







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
