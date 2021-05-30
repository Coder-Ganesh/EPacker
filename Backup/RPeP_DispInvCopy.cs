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
    public partial class RPeP_DispInvCopy : Form
    {
        string session, strSQL, Group_ID, Invoice_No;
        string P_Name, P_ID, P_PONo, P_PODt, Box_Qty, Desp_Det, Inv_Type;
        string griOrder_ID, griChallan_No;
        string strOpenDoc, Grp_Name;
        private FunctionLib funclib;
        public RPeP_DispInvCopy()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_DispInvCopy_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Displaying Active Values
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;
            ddlActive.Enabled = false;
            ddlActive.Items.Add("Yes");
            ddlActive.Items.Add("No");
            ddlActive.Text = "Yes";


            ddlInv_Type.Items.Add("");
            ddlInv_Type.Items.Add("G (Green)");
            ddlInv_Type.Items.Add("W (White)");
            monthCalendar1.Visible = false;
            monthCalendar2.Visible = false;


            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            Invoice_No = funclib.I_ID("I", con, "select Inv_No  from Dispatch_InvCopy order by Inv_No  desc");
            txtInv_No.Text = Invoice_No;

            ddlSearch.Items.Add("");
            ddlSearch.Items.Add("Inv.No.");
            ddlSearch.Items.Add("Inv.Dt.");
            ddlSearch.Items.Add("Party");
            ddlSearch.Items.Add("Order No.");
            ddlSearch.Items.Add("Challan No.");
            ddlSearch.Items.Add("Amt.");
            ddlSearch.Items.Add("Type");
           
                     

        }

        private void txtInv_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtInv_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtInv_Dt.Focus();
        }

        private void cmdOrderSearch_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' and b.P_Name like '%" + txtOrderSearch.Text.Trim().ToString() + "%' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlOrder_ID.DataSource = dt;
            ddlOrder_ID.DisplayMember = dt.Columns[0].ToString();
            ddlOrder_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void ddlOrder_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select b.P_Name,a.P_ID,a.P_PONo,convert (varchar(20),a.P_PODt,103) as 'P_PODt',a.Box_Qty from Item_Order as a,Party_Master as b where a.P_ID=b.P_ID and a.Order_ID ='" + ddlOrder_ID.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                P_Name = Convert.ToString(dr1["P_Name"]);
                P_ID = Convert.ToString(dr1["P_ID"]);
                P_PONo = Convert.ToString(dr1["P_PONo"]);
                P_PODt = Convert.ToString(dr1["P_PODt"]);
                Box_Qty = Convert.ToString(dr1["Box_Qty"]);
            }
            dr1.Close();
            con1.Close();


            txtP_ID.Text = P_Name;
            txtPoandDate.Text = P_PONo + "  " + P_PODt;
            txtOrder_Qty.Text = Box_Qty;


            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Challan_No UNION select  Challan_No from Dispatch_Challan as a where Challan_Active='Yes'  and a.Order_ID ='"+ddlOrder_ID.SelectedValue.ToString()+"' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlChallan_No.DataSource = dt;
            ddlChallan_No.DisplayMember = dt.Columns[0].ToString();
            ddlChallan_No.ValueMember = dt.Columns[0].ToString();
            con.Close();




        }

        private void ddlChallan_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select Grand_Amt  from Dispatch_Challan where Challan_No ='" + ddlChallan_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtGrand_Amt.Text = Convert.ToString(dr1["Grand_Amt"]);
           
            }
            dr1.Close();
            con1.Close();



        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtInv_No.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Invoice No Cannot be Blank");
                txtInv_No.Focus();
            }

            else if (txtInv_Dt.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtInv_Dt.Focus();
            }
            else if (ddlOrder_ID.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlOrder_ID.Focus();

            }
            else if (txtP_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtP_ID.Focus();
            }
            else if (txtOrder_Qty.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtOrder_Qty.Focus();
            }
            else if (ddlChallan_No.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlChallan_No.Focus();
            }
            else if (txtGrand_Amt.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtGrand_Amt.Focus();
            }
            else if (ddlInv_Type.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlInv_Type.Focus();
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


                string strInvType = ddlInv_Type.Text;
                string Type = strInvType.Substring(0, 1);

                Inv_Type = Type;

                double flag = funclib.isThere(con, "select *  from Dispatch_InvCopy where Order_ID='" + ddlOrder_ID.SelectedValue.ToString() + "' and Challan_No='" + ddlChallan_No.SelectedValue.ToString() + "' and Inv_Type='" + Inv_Type + "'");
                 if (flag == 1)
                 {
                     MessageBox.Show("Cannot add this record as duplication of Order No,Challan No & Invoice Type are not allowed");

                 }
                 else
                 {
                     //Inserting records 

                     SqlCommand cmdPositive = new SqlCommand("insert into Dispatch_InvCopy(Inv_No,Inv_Dt,Grp_ID,Order_ID,Challan_No,Grand_Amt,Inv_Type,Inv_Active,Add_By,Add_ByNode,Add_On) values('" + txtInv_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txtInv_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + Group_ID + "','" + ddlOrder_ID.SelectedValue.ToString() + "','" + ddlChallan_No.SelectedValue.ToString() + "','" + txtGrand_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + Inv_Type + "','" + ddlActive.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
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
        }
        protected void ClearAll()
        {

            ddlOrder_ID.Text = "";
            txt_Search.Text = "";
            txtGrand_Amt.Text = "";
            txtInv_No.Text = "";
            txtOrder_Qty.Text = "";
            txtP_ID.Text = "";
            txtPoandDate.Text = "";
            txtOrderSearch.Text = "";
            txtInv_Dt.Text = "";
            ddlChallan_No.Text = "";
            ddlInv_Type.Text = "";
            ddlOrder_ID.Text = "";
            ddlSearch.Text = "";

            ddlOrder_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlChallan_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlActive.Text = "Yes";
            cmdPrint.Visible = false;
            ddlActive.Enabled = false;


            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            Invoice_No = funclib.I_ID("I", con, "select Inv_No  from Dispatch_InvCopy order by Inv_No  desc");
            txtInv_No.Text = Invoice_No;

            txtInv_Dt.Enabled = true;
            ddlOrder_ID.Enabled = true;
            txtOrderSearch.Enabled = true;
            ddlChallan_No.Enabled = true;
            ddlInv_Type.Enabled = true;

            ddlActive.Enabled = false;
           

            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;


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
        {  //Update data in table
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Dispatch_InvCopy set Inv_Active  ='" + ddlActive.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Inv_No ='" + txtInv_No.Text.Trim().Replace("'", "''").ToString() + "'", con);

                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");

                ClearAll();
            }

        }

        private void CmdSearch_Click(object sender, EventArgs e)
        {   
         
            if (ddlSearch.Text == "Inv.No.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Inv_No as 'Inv.No.',convert (varchar(20),a.Inv_Dt,103) as 'Inv.Dt.',c.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',a.Challan_No as 'Challan No.',a.Grand_Amt as 'Amt.',a.Inv_Type as 'Type',a.Inv_Active from Dispatch_InvCopy as a,Dispatch_Challan as b,Party_Master as c,Item_Order as d where a.Challan_No=b.Challan_No and b.P_ID=c.P_ID and a.Order_ID=d.Order_ID and a.Inv_No like '%" + txt_Search.Text.ToString() + "%'  order by a.Inv_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.Columns[8].Visible = false;
            }
            else if (ddlSearch.Text == "Inv.Dt.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Inv_No as 'Inv.No.',convert (varchar(20),a.Inv_Dt,103) as 'Inv.Dt.',c.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',a.Challan_No as 'Challan No.',a.Grand_Amt as 'Amt.',a.Inv_Type as 'Type',a.Inv_Active from Dispatch_InvCopy as a,Dispatch_Challan as b,Party_Master as c,Item_Order as d where a.Challan_No=b.Challan_No and b.P_ID=c.P_ID and a.Order_ID=d.Order_ID and a.Inv_Dt = convert(datetime,'"+txt_Search.Text+"',103) order by a.Inv_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.Columns[8].Visible = false;
            }
            else if (ddlSearch.Text == "Party")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Inv_No as 'Inv.No.',convert (varchar(20),a.Inv_Dt,103) as 'Inv.Dt.',c.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',a.Challan_No as 'Challan No.',a.Grand_Amt as 'Amt.',a.Inv_Type as 'Type',a.Inv_Active from Dispatch_InvCopy as a,Dispatch_Challan as b,Party_Master as c,Item_Order as d where a.Challan_No=b.Challan_No and b.P_ID=c.P_ID and a.Order_ID=d.Order_ID and c.P_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.Inv_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.Columns[8].Visible = false;
            }
            else if (ddlSearch.Text == "Order No.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Inv_No as 'Inv.No.',convert (varchar(20),a.Inv_Dt,103) as 'Inv.Dt.',c.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',a.Challan_No as 'Challan No.',a.Grand_Amt as 'Amt.',a.Inv_Type as 'Type',a.Inv_Active from Dispatch_InvCopy as a,Dispatch_Challan as b,Party_Master as c,Item_Order as d where a.Challan_No=b.Challan_No and b.P_ID=c.P_ID and a.Order_ID=d.Order_ID and a.Order_ID like '%" + txt_Search.Text.ToString() + "%'  order by a.Inv_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.Columns[8].Visible = false;
            }
            else if (ddlSearch.Text == "Challan No.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Inv_No as 'Inv.No.',convert (varchar(20),a.Inv_Dt,103) as 'Inv.Dt.',c.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',a.Challan_No as 'Challan No.',a.Grand_Amt as 'Amt.',a.Inv_Type as 'Type',a.Inv_Active from Dispatch_InvCopy as a,Dispatch_Challan as b,Party_Master as c,Item_Order as d where a.Challan_No=b.Challan_No and b.P_ID=c.P_ID and a.Order_ID=d.Order_ID and a.Challan_No like '%" + txt_Search.Text.ToString() + "%'  order by a.Inv_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.Columns[8].Visible = false;
            }
            else if (ddlSearch.Text == "Amt.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Inv_No as 'Inv.No.',convert (varchar(20),a.Inv_Dt,103) as 'Inv.Dt.',c.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',a.Challan_No as 'Challan No.',a.Grand_Amt as 'Amt.',a.Inv_Type as 'Type',a.Inv_Active from Dispatch_InvCopy as a,Dispatch_Challan as b,Party_Master as c,Item_Order as d where a.Challan_No=b.Challan_No and b.P_ID=c.P_ID and a.Order_ID=d.Order_ID and a.Grand_Amt like '%" + txt_Search.Text.ToString() + "%'  order by a.Inv_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.Columns[8].Visible = false;
            }
            else if (ddlSearch.Text == "Type")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Inv_No as 'Inv.No.',convert (varchar(20),a.Inv_Dt,103) as 'Inv.Dt.',c.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',a.Challan_No as 'Challan No.',a.Grand_Amt as 'Amt.',a.Inv_Type as 'Type',a.Inv_Active from Dispatch_InvCopy as a,Dispatch_Challan as b,Party_Master as c,Item_Order as d where a.Challan_No=b.Challan_No and b.P_ID=c.P_ID and a.Order_ID=d.Order_ID and a.Inv_Type like '%" + txt_Search.Text.ToString() + "%'  order by a.Inv_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.Columns[8].Visible = false;
            }
            else
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Inv_No as 'Inv.No.',convert (varchar(20),a.Inv_Dt,103) as 'Inv.Dt.',c.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',a.Challan_No as 'Challan No.',a.Grand_Amt as 'Amt.',a.Inv_Type as 'Type',a.Inv_Active from Dispatch_InvCopy as a,Dispatch_Challan as b,Party_Master as c,Item_Order as d where a.Challan_No=b.Challan_No and b.P_ID=c.P_ID and a.Order_ID=d.Order_ID order by a.Inv_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.Columns[8].Visible = false;
            }
        }

       

        private void GridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;

            cmdPrint.Visible = true;

            ddlActive.Enabled = true;
            txtInv_Dt.Enabled = false;
            ddlOrder_ID.Enabled = false;
            txtOrderSearch.Enabled = false;
            ddlChallan_No.Enabled = false;
            ddlInv_Type.Enabled = false;


            txtInv_No.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //ddlOrder_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtInv_Dt.Text = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtP_ID.Text = GridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
            ddlOrder_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlOrder_ID.Text = GridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            griOrder_ID = GridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
            ddlChallan_No.DropDownStyle = ComboBoxStyle.Simple;
            ddlChallan_No.Text = GridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            griChallan_No = GridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            txtGrand_Amt.Text = GridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            
            string strType = GridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
          
            if (strType == "G")
            {
                ddlInv_Type.Text = "G (Green)";
            }
            else if (strType == "W")
            {
                ddlInv_Type.Text = "W (White)";
            }
            
            ddlActive.Text = GridView1.Rows[e.RowIndex].Cells[8].Value.ToString();


            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select b.P_Name,a.P_ID,a.P_PONo,convert (varchar(20),a.P_PODt,103) as 'P_PODt',a.Box_Qty from Item_Order as a,Party_Master as b where a.P_ID=b.P_ID and a.Order_ID ='" + griOrder_ID + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                P_Name = Convert.ToString(dr1["P_Name"]);
                P_ID = Convert.ToString(dr1["P_ID"]);
                P_PONo = Convert.ToString(dr1["P_PONo"]);
                P_PODt = Convert.ToString(dr1["P_PODt"]);
                Box_Qty = Convert.ToString(dr1["Box_Qty"]);
            }
            dr1.Close();
            con1.Close();


            txtP_ID.Text = P_Name;
            txtPoandDate.Text = P_PONo + "  " + P_PODt;
            txtOrder_Qty.Text = Box_Qty;

            SqlCommand cmd4 = new SqlCommand("select Grand_Amt  from Dispatch_Challan where Challan_No ='" + griChallan_No + "'", con1);
            con1.Open();
            SqlDataReader dr4 = cmd4.ExecuteReader();
            if (dr4.Read())
            {

                txtGrand_Amt.Text = Convert.ToString(dr4["Grand_Amt"]);

            }
            dr4.Close();
            con1.Close();


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
            sfd.FileName = "Dispatch Invoice Copy.pdf";
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


                    var titleFont = FontFactory.GetFont("NewFont", 14);
                    var subTitleFont = FontFactory.GetFont("NewFont", 14);
                    var boldTableFont = FontFactory.GetFont("NewFont", 12);
                    var endingMessageFont = FontFactory.GetFont("NewFont", 12);
                    var bodyFont = FontFactory.GetFont("NewFont", 12);
                    var underline = FontFactory.GetFont("BodyFont", 10);
                    var underlinBold = FontFactory.GetFont("NewFont", 9);
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
                    phrase2.Add(new Chunk("Invoice No. : ", underline));
                    Chunk c2 = new Chunk(txtInv_No.Text.Trim().ToString(), underline);
                    c2.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c2);

                    phrase2.Add(new Chunk("        "));

                    phrase2.Add(new Chunk("Invoice Dt. : ", underline));
                    Chunk c3 = new Chunk(txtInv_Dt.Text.Trim().ToString() + '\n', underline);
                    c3.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c3);

                    Paragraph pf1 = new Paragraph(phrase2);

                                     

                
                    var phrase77 = new Phrase();
                    phrase77.Add(new Chunk("Order No. : ", underline));
                    Chunk cadd77 = new Chunk(ddlOrder_ID.Text + '\n', underline);
                    cadd77.SetUnderline(0.5f, -1.5f);
                    phrase77.Add(cadd77);

                    Paragraph pf4_4 = new Paragraph(phrase77);



                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("Party : ", underline));
                    Chunk c81 = new Chunk(txtP_ID.Text.Trim().ToString(), underline);
                    c81.SetUnderline(0.5f, -1.5f);
                    phrase8.Add(c81);

                    Paragraph pf7 = new Paragraph(phrase8);
                    // pf4.SpacingBefore = 5f;


                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("Party PO No. & Dt :  ", underline));
                    Chunk cins = new Chunk(txtPoandDate.Text.Trim().ToString(), underline);
                    cins.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(cins);


                    phraseIns.Add(new Chunk("      "));

                    phraseIns.Add(new Chunk("Order Qty. : ", underline));
                    Chunk c83 = new Chunk(txtOrder_Qty.Text.Trim().ToString(), underline);
                    c83.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(c83);

                    Paragraph pf8 = new Paragraph(phraseIns);

                    var phraseChall = new Phrase();
                    phraseChall.Add(new Chunk("Challan No. :  ", underline));
                    Chunk cChall = new Chunk(ddlChallan_No.Text.Trim().ToString(), underline);
                    cChall.SetUnderline(0.5f, -1.5f);
                    phraseChall.Add(cChall);




                    Paragraph pf8_1 = new Paragraph(phraseChall);



                    var phraseIns2 = new Phrase();
                    phraseIns2.Add(new Chunk("Amount  : ", underline));
                    Chunk cins2 = new Chunk(txtGrand_Amt.Text.Trim().ToString(), underline);
                    cins2.SetUnderline(0.5f, -1.5f);
                    phraseIns2.Add(cins2);
                    
                    Paragraph pf8_8 = new Paragraph(phraseIns2);


                    var phraseIns23 = new Phrase();
                    phraseIns23.Add(new Chunk("Invoice Type  : ", underline));
                    Chunk cins23 = new Chunk(ddlInv_Type.Text.Trim().ToString(), underline);
                    cins23.SetUnderline(0.5f, -1.5f);
                    phraseIns23.Add(cins23);


                
                    Paragraph pf8_99 = new Paragraph(phraseIns23);

                   


                    doc.Add(MainTitle);

                    doc.Add(ParaTitle);
                    doc.Add(pf1);
                    doc.Add(pf4_4);
                    doc.Add(pf7);
                    doc.Add(pf8);
                    doc.Add(pf8_1);
                    doc.Add(pf8_8);
                    doc.Add(pf8_99);
                   


                    LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line3));


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
            sfd.FileName = "CopyOfDispatch Invoice Copy.pdf";
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


                    var titleFont = FontFactory.GetFont("NewFont", 14);
                    var subTitleFont = FontFactory.GetFont("NewFont", 14);
                    var boldTableFont = FontFactory.GetFont("NewFont", 12);
                    var endingMessageFont = FontFactory.GetFont("NewFont", 12);
                    var bodyFont = FontFactory.GetFont("NewFont", 12);
                    var underline = FontFactory.GetFont("BodyFont", 10);
                    var underlinBold = FontFactory.GetFont("NewFont", 9);
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


                    Chunk chunk = new Chunk("Dispatch : Invoice Copy (Copy)" + '\n', titleFont);
                    chunk.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaTitle = new Paragraph(chunk);
                    ParaTitle.SpacingBefore = 5f;
                    ParaTitle.SpacingAfter = 5f;




                    var phrase2 = new Phrase();
                    phrase2.Add(new Chunk("Invoice No. : ", underline));
                    Chunk c2 = new Chunk(txtInv_No.Text.Trim().ToString(), underline);
                    c2.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c2);

                    phrase2.Add(new Chunk("        "));

                    phrase2.Add(new Chunk("Invoice Dt. : ", underline));
                    Chunk c3 = new Chunk(txtInv_Dt.Text.Trim().ToString() + '\n', underline);
                    c3.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c3);

                    Paragraph pf1 = new Paragraph(phrase2);




                    var phrase77 = new Phrase();
                    phrase77.Add(new Chunk("Order No. : ", underline));
                    Chunk cadd77 = new Chunk(ddlOrder_ID.Text + '\n', underline);
                    cadd77.SetUnderline(0.5f, -1.5f);
                    phrase77.Add(cadd77);

                    Paragraph pf4_4 = new Paragraph(phrase77);



                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("Party : ", underline));
                    Chunk c81 = new Chunk(txtP_ID.Text.Trim().ToString(), underline);
                    c81.SetUnderline(0.5f, -1.5f);
                    phrase8.Add(c81);

                    Paragraph pf7 = new Paragraph(phrase8);
                    // pf4.SpacingBefore = 5f;


                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("Party PO No. & Dt :  ", underline));
                    Chunk cins = new Chunk(txtPoandDate.Text.Trim().ToString(), underline);
                    cins.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(cins);


                    phraseIns.Add(new Chunk("      "));

                    phraseIns.Add(new Chunk("Order Qty. : ", underline));
                    Chunk c83 = new Chunk(txtOrder_Qty.Text.Trim().ToString(), underline);
                    c83.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(c83);

                    Paragraph pf8 = new Paragraph(phraseIns);

                    var phraseChall = new Phrase();
                    phraseChall.Add(new Chunk("Challan No. :  ", underline));
                    Chunk cChall = new Chunk(ddlChallan_No.Text.Trim().ToString(), underline);
                    cChall.SetUnderline(0.5f, -1.5f);
                    phraseChall.Add(cChall);




                    Paragraph pf8_1 = new Paragraph(phraseChall);



                    var phraseIns2 = new Phrase();
                    phraseIns2.Add(new Chunk("Amount  : ", underline));
                    Chunk cins2 = new Chunk(txtGrand_Amt.Text.Trim().ToString(), underline);
                    cins2.SetUnderline(0.5f, -1.5f);
                    phraseIns2.Add(cins2);

                    Paragraph pf8_8 = new Paragraph(phraseIns2);


                    var phraseIns23 = new Phrase();
                    phraseIns23.Add(new Chunk("Invoice Type  : ", underline));
                    Chunk cins23 = new Chunk(ddlInv_Type.Text.Trim().ToString(), underline);
                    cins23.SetUnderline(0.5f, -1.5f);
                    phraseIns23.Add(cins23);



                    Paragraph pf8_99 = new Paragraph(phraseIns23);




                    doc.Add(MainTitle);

                    doc.Add(ParaTitle);
                    doc.Add(pf1);
                    doc.Add(pf4_4);
                    doc.Add(pf7);
                    doc.Add(pf8);
                    doc.Add(pf8_1);
                    doc.Add(pf8_8);
                    doc.Add(pf8_99);



                    LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line3));


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
