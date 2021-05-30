namespace ePacker1
{
    partial class RPeP_MasterPurchaseItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterPurchaseItem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSI_ID = new System.Windows.Forms.TextBox();
            this.txtSI_ExcDesc = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.txtSI_Name = new System.Windows.Forms.TextBox();
            this.txtSI_CuStock = new System.Windows.Forms.TextBox();
            this.txtSI_MinLev = new System.Windows.Forms.TextBox();
            this.txtSI_ExcCode = new System.Windows.Forms.TextBox();
            this.txtSI_Procesg = new System.Windows.Forms.TextBox();
            this.txtSI_ChapTarNo = new System.Windows.Forms.TextBox();
            this.ddlSI_UOM = new System.Windows.Forms.ComboBox();
            this.ddlSI_Active = new System.Windows.Forms.ComboBox();
            this.ddlSI_Cate = new System.Windows.Forms.ComboBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtSI_ID);
            this.panel1.Controls.Add(this.txtSI_ExcDesc);
            this.panel1.Controls.Add(this.cmdClose);
            this.panel1.Controls.Add(this.cmdUpdate);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.txtSI_Name);
            this.panel1.Controls.Add(this.txtSI_CuStock);
            this.panel1.Controls.Add(this.txtSI_MinLev);
            this.panel1.Controls.Add(this.txtSI_ExcCode);
            this.panel1.Controls.Add(this.txtSI_Procesg);
            this.panel1.Controls.Add(this.txtSI_ChapTarNo);
            this.panel1.Controls.Add(this.ddlSI_UOM);
            this.panel1.Controls.Add(this.ddlSI_Active);
            this.panel1.Controls.Add(this.ddlSI_Cate);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(29, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 388);
            this.panel1.TabIndex = 0;
            // 
            // txtSI_ID
            // 
            this.txtSI_ID.Location = new System.Drawing.Point(664, 1);
            this.txtSI_ID.Name = "txtSI_ID";
            this.txtSI_ID.Size = new System.Drawing.Size(140, 20);
            this.txtSI_ID.TabIndex = 27;
            // 
            // txtSI_ExcDesc
            // 
            this.txtSI_ExcDesc.Location = new System.Drawing.Point(110, 183);
            this.txtSI_ExcDesc.Name = "txtSI_ExcDesc";
            this.txtSI_ExcDesc.Size = new System.Drawing.Size(279, 20);
            this.txtSI_ExcDesc.TabIndex = 8;
            this.txtSI_ExcDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSI_ExcDesc_KeyPress);
            // 
            // cmdClose
            // 
            this.cmdClose.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdClose.Location = new System.Drawing.Point(323, 315);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(53, 52);
            this.cmdClose.TabIndex = 15;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdUpdate.Location = new System.Drawing.Point(247, 315);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(53, 52);
            this.cmdUpdate.TabIndex = 14;
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdRefresh.Location = new System.Drawing.Point(174, 315);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(54, 52);
            this.cmdRefresh.TabIndex = 13;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackColor = System.Drawing.Color.LightGray;
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.Location = new System.Drawing.Point(107, 315);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 52);
            this.cmdSubmit.TabIndex = 12;
            this.cmdSubmit.UseVisualStyleBackColor = false;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // txtSI_Name
            // 
            this.txtSI_Name.Location = new System.Drawing.Point(111, 27);
            this.txtSI_Name.Name = "txtSI_Name";
            this.txtSI_Name.Size = new System.Drawing.Size(279, 20);
            this.txtSI_Name.TabIndex = 2;
            this.txtSI_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSI_Name_KeyPress);
            // 
            // txtSI_CuStock
            // 
            this.txtSI_CuStock.Location = new System.Drawing.Point(111, 65);
            this.txtSI_CuStock.Name = "txtSI_CuStock";
            this.txtSI_CuStock.Size = new System.Drawing.Size(151, 20);
            this.txtSI_CuStock.TabIndex = 3;
            this.txtSI_CuStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSI_CuStock_KeyPress);
            // 
            // txtSI_MinLev
            // 
            this.txtSI_MinLev.Location = new System.Drawing.Point(375, 65);
            this.txtSI_MinLev.Name = "txtSI_MinLev";
            this.txtSI_MinLev.Size = new System.Drawing.Size(140, 20);
            this.txtSI_MinLev.TabIndex = 4;
            this.txtSI_MinLev.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSI_MinLev_KeyPress);
            // 
            // txtSI_ExcCode
            // 
            this.txtSI_ExcCode.Location = new System.Drawing.Point(522, 149);
            this.txtSI_ExcCode.Name = "txtSI_ExcCode";
            this.txtSI_ExcCode.Size = new System.Drawing.Size(233, 20);
            this.txtSI_ExcCode.TabIndex = 7;
            this.txtSI_ExcCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSI_ExcCode_KeyPress);
            // 
            // txtSI_Procesg
            // 
            this.txtSI_Procesg.Location = new System.Drawing.Point(111, 219);
            this.txtSI_Procesg.Name = "txtSI_Procesg";
            this.txtSI_Procesg.Size = new System.Drawing.Size(279, 20);
            this.txtSI_Procesg.TabIndex = 10;
            this.txtSI_Procesg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSI_Procesg_KeyPress);
            // 
            // txtSI_ChapTarNo
            // 
            this.txtSI_ChapTarNo.Location = new System.Drawing.Point(522, 176);
            this.txtSI_ChapTarNo.Name = "txtSI_ChapTarNo";
            this.txtSI_ChapTarNo.Size = new System.Drawing.Size(233, 20);
            this.txtSI_ChapTarNo.TabIndex = 9;
            this.txtSI_ChapTarNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSI_ChapTarNo_KeyPress);
            // 
            // ddlSI_UOM
            // 
            this.ddlSI_UOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSI_UOM.FormattingEnabled = true;
            this.ddlSI_UOM.Location = new System.Drawing.Point(111, 104);
            this.ddlSI_UOM.Name = "ddlSI_UOM";
            this.ddlSI_UOM.Size = new System.Drawing.Size(279, 21);
            this.ddlSI_UOM.TabIndex = 5;
            // 
            // ddlSI_Active
            // 
            this.ddlSI_Active.FormattingEnabled = true;
            this.ddlSI_Active.Location = new System.Drawing.Point(111, 259);
            this.ddlSI_Active.Name = "ddlSI_Active";
            this.ddlSI_Active.Size = new System.Drawing.Size(279, 21);
            this.ddlSI_Active.TabIndex = 11;
            // 
            // ddlSI_Cate
            // 
            this.ddlSI_Cate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSI_Cate.FormattingEnabled = true;
            this.ddlSI_Cate.Location = new System.Drawing.Point(111, 149);
            this.ddlSI_Cate.Name = "ddlSI_Cate";
            this.ddlSI_Cate.Size = new System.Drawing.Size(279, 21);
            this.ddlSI_Cate.TabIndex = 6;
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(85, 1);
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(279, 21);
            this.ddlGrp_ID.TabIndex = 1;
            this.ddlGrp_ID.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Honeydew;
            this.label11.Location = new System.Drawing.Point(28, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Name *";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Honeydew;
            this.label10.Location = new System.Drawing.Point(28, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Current Stock *";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Honeydew;
            this.label9.Location = new System.Drawing.Point(28, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Processing";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Honeydew;
            this.label8.Location = new System.Drawing.Point(420, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Chapter / Tariff No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Honeydew;
            this.label7.Location = new System.Drawing.Point(28, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Excise Desc *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(431, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Excise Code *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(28, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Active *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(28, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Category *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(288, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Min. Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(28, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "UOM *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group *";
            this.label1.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Orange;
            this.label13.Location = new System.Drawing.Point(260, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(367, 31);
            this.label13.TabIndex = 2;
            this.label13.Text = "Purchases Item Management";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(98, 520);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(639, 108);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Honeydew;
            this.label12.Location = new System.Drawing.Point(144, 475);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Name *";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(203, 472);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(279, 20);
            this.txtSearch.TabIndex = 16;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.button5.Location = new System.Drawing.Point(515, 458);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(53, 52);
            this.button5.TabIndex = 17;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackgroundImage = global::ePacker1.Properties.Resources.Excel_Icon;
            this.cmdExcelReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExcelReport.Location = new System.Drawing.Point(575, 458);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(52, 51);
            this.cmdExcelReport.TabIndex = 29;
            this.cmdExcelReport.UseVisualStyleBackColor = true;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // RPeP_MasterPurchaseItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(854, 746);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_MasterPurchaseItem";
            this.Text = "RPeP_MasterPurchaseItem";
            this.Load += new System.EventHandler(this.RPeP_MasterPurchaseItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlSI_UOM;
        private System.Windows.Forms.ComboBox ddlSI_Active;
        private System.Windows.Forms.ComboBox ddlSI_Cate;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.TextBox txtSI_Name;
        private System.Windows.Forms.TextBox txtSI_CuStock;
        private System.Windows.Forms.TextBox txtSI_MinLev;
        private System.Windows.Forms.TextBox txtSI_ExcCode;
        private System.Windows.Forms.TextBox txtSI_Procesg;
        private System.Windows.Forms.TextBox txtSI_ChapTarNo;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSI_ExcDesc;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSI_ID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button cmdExcelReport;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}