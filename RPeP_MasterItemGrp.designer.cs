namespace ePacker1
{
    partial class RPeP_MasterItemGrp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterItemGrp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.ListName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lstI_ID = new System.Windows.Forms.ListBox();
            this.dgwPartyBuyer = new System.Windows.Forms.DataGridView();
            this.cmd_PB_Name_Search = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPB_Name_Search = new System.Windows.Forms.TextBox();
            this.ddlPB_ID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.txtIG_ID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlIG_Active = new System.Windows.Forms.ComboBox();
            this.txtIG_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlP_ID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPartyBuyer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.ListName);
            this.panel1.Controls.Add(this.lstI_ID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ddlPB_ID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.txtIG_ID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ddlIG_Active);
            this.panel1.Controls.Add(this.txtIG_Name);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ddlP_ID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(13, 134);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 552);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdExcelReport.BackgroundImage")));
            this.cmdExcelReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExcelReport.Location = new System.Drawing.Point(1643, 146);
            this.cmdExcelReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(75, 75);
            this.cmdExcelReport.TabIndex = 47;
            this.cmdExcelReport.UseVisualStyleBackColor = true;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // ListName
            // 
            this.ListName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListName.Location = new System.Drawing.Point(520, 74);
            this.ListName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListName.Name = "ListName";
            this.ListName.Size = new System.Drawing.Size(144, 28);
            this.ListName.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Honeydew;
            this.label9.Location = new System.Drawing.Point(778, 188);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 24);
            this.label9.TabIndex = 31;
            this.label9.Text = "Item Group *";
            // 
            // lstI_ID
            // 
            this.lstI_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstI_ID.FormattingEnabled = true;
            this.lstI_ID.ItemHeight = 22;
            this.lstI_ID.Location = new System.Drawing.Point(126, 160);
            this.lstI_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstI_ID.Name = "lstI_ID";
            this.lstI_ID.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstI_ID.Size = new System.Drawing.Size(273, 114);
            this.lstI_ID.TabIndex = 45;
            // 
            // dgwPartyBuyer
            // 
            this.dgwPartyBuyer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwPartyBuyer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwPartyBuyer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwPartyBuyer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwPartyBuyer.Location = new System.Drawing.Point(782, 229);
            this.dgwPartyBuyer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgwPartyBuyer.Name = "dgwPartyBuyer";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwPartyBuyer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwPartyBuyer.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwPartyBuyer.Size = new System.Drawing.Size(936, 457);
            this.dgwPartyBuyer.TabIndex = 30;
            this.dgwPartyBuyer.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwPartyBuyer_RowHeaderMouseClick);
            // 
            // cmd_PB_Name_Search
            // 
            this.cmd_PB_Name_Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmd_PB_Name_Search.BackgroundImage")));
            this.cmd_PB_Name_Search.Location = new System.Drawing.Point(1100, 146);
            this.cmd_PB_Name_Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmd_PB_Name_Search.Name = "cmd_PB_Name_Search";
            this.cmd_PB_Name_Search.Size = new System.Drawing.Size(75, 75);
            this.cmd_PB_Name_Search.TabIndex = 28;
            this.cmd_PB_Name_Search.UseVisualStyleBackColor = true;
            this.cmd_PB_Name_Search.Click += new System.EventHandler(this.cmd_PB_Name_Search_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(2, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 24);
            this.label5.TabIndex = 42;
            this.label5.Text = "Item *";
            // 
            // txtPB_Name_Search
            // 
            this.txtPB_Name_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPB_Name_Search.Location = new System.Drawing.Point(908, 184);
            this.txtPB_Name_Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPB_Name_Search.Name = "txtPB_Name_Search";
            this.txtPB_Name_Search.Size = new System.Drawing.Size(184, 28);
            this.txtPB_Name_Search.TabIndex = 29;
            // 
            // ddlPB_ID
            // 
            this.ddlPB_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPB_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPB_ID.FormattingEnabled = true;
            this.ddlPB_ID.Location = new System.Drawing.Point(126, 72);
            this.ddlPB_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlPB_ID.MaxLength = 50;
            this.ddlPB_ID.Name = "ddlPB_ID";
            this.ddlPB_ID.Size = new System.Drawing.Size(352, 30);
            this.ddlPB_ID.TabIndex = 40;
            this.ddlPB_ID.SelectedIndexChanged += new System.EventHandler(this.ddlPB_ID_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(5, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 24);
            this.label6.TabIndex = 41;
            this.label6.Text = "Party Buyer *";
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCancel.BackgroundImage")));
            this.cmdCancel.Location = new System.Drawing.Point(403, 394);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 75);
            this.cmdCancel.TabIndex = 39;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdEdit.BackgroundImage")));
            this.cmdEdit.Location = new System.Drawing.Point(109, 395);
            this.cmdEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 75);
            this.cmdEdit.TabIndex = 38;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdReset.BackgroundImage")));
            this.cmdReset.Location = new System.Drawing.Point(211, 396);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 75);
            this.cmdReset.TabIndex = 33;
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSubmit.BackgroundImage")));
            this.cmdSubmit.Location = new System.Drawing.Point(9, 395);
            this.cmdSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(75, 75);
            this.cmdSubmit.TabIndex = 32;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // txtIG_ID
            // 
            this.txtIG_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIG_ID.Location = new System.Drawing.Point(520, 27);
            this.txtIG_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIG_ID.Name = "txtIG_ID";
            this.txtIG_ID.Size = new System.Drawing.Size(144, 28);
            this.txtIG_ID.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Honeydew;
            this.label7.Location = new System.Drawing.Point(2, 296);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 24);
            this.label7.TabIndex = 30;
            this.label7.Text = "Active *";
            // 
            // ddlIG_Active
            // 
            this.ddlIG_Active.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlIG_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlIG_Active.FormattingEnabled = true;
            this.ddlIG_Active.Location = new System.Drawing.Point(126, 296);
            this.ddlIG_Active.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlIG_Active.MaxLength = 3;
            this.ddlIG_Active.Name = "ddlIG_Active";
            this.ddlIG_Active.Size = new System.Drawing.Size(273, 30);
            this.ddlIG_Active.TabIndex = 29;
            // 
            // txtIG_Name
            // 
            this.txtIG_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIG_Name.Location = new System.Drawing.Point(126, 115);
            this.txtIG_Name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIG_Name.MaxLength = 100;
            this.txtIG_Name.Name = "txtIG_Name";
            this.txtIG_Name.Size = new System.Drawing.Size(273, 28);
            this.txtIG_Name.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(2, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "Item Group *";
            // 
            // ddlP_ID
            // 
            this.ddlP_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlP_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlP_ID.FormattingEnabled = true;
            this.ddlP_ID.Location = new System.Drawing.Point(126, 29);
            this.ddlP_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlP_ID.MaxLength = 50;
            this.ddlP_ID.Name = "ddlP_ID";
            this.ddlP_ID.Size = new System.Drawing.Size(352, 30);
            this.ddlP_ID.TabIndex = 2;
            this.ddlP_ID.SelectedIndexChanged += new System.EventHandler(this.ddlP_ID_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(5, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Party *";
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(712, 92);
            this.ddlGrp_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlGrp_ID.MaxLength = 50;
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(273, 24);
            this.ddlGrp_ID.TabIndex = 1;
            this.ddlGrp_ID.Visible = false;
            this.ddlGrp_ID.SelectedIndexChanged += new System.EventHandler(this.ddlGrp_ID_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(517, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group *";
            this.label1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOrange;
            this.label8.Location = new System.Drawing.Point(397, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(393, 39);
            this.label8.TabIndex = 8;
            this.label8.Text = "Item Group Management";
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(309, 396);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 75);
            this.btnDelete.TabIndex = 89;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // RPeP_MasterItemGrp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(5, 100);
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1752, 711);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwPartyBuyer);
            this.Controls.Add(this.ddlGrp_ID);
            this.Controls.Add(this.cmd_PB_Name_Search);
            this.Controls.Add(this.txtPB_Name_Search);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RPeP_MasterItemGrp";
            this.Text = "RPeP_MasterItemGrp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPeP_MasterItemGrp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPartyBuyer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.TextBox txtIG_ID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddlIG_Active;
        private System.Windows.Forms.TextBox txtIG_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlP_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlPB_ID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstI_ID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgwPartyBuyer;
        private System.Windows.Forms.Button cmd_PB_Name_Search;
        private System.Windows.Forms.TextBox txtPB_Name_Search;
        private System.Windows.Forms.TextBox ListName;
        private System.Windows.Forms.Button cmdExcelReport;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button btnDelete;
    }
}