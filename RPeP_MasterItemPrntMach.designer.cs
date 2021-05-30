namespace ePacker1
{
    partial class RPeP_MasterItemPrntMach
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterItemPrntMach));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.txtPrntMach_Size = new System.Windows.Forms.TextBox();
            this.txtPrntMach_Printg = new System.Windows.Forms.TextBox();
            this.txtPrntMach_PlateSgl = new System.Windows.Forms.TextBox();
            this.txtPrntMach_PlateSgl2 = new System.Windows.Forms.TextBox();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtPrntMach_ID = new System.Windows.Forms.TextBox();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlPrntMach_Active = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGrp_Name_Search = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.dgwItem_PrntMach_Master = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItem_PrntMach_Master)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(200, 19);
            this.ddlGrp_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(160, 24);
            this.ddlGrp_ID.TabIndex = 0;
            this.toolTip1.SetToolTip(this.ddlGrp_ID, "Select Group Name");
            this.ddlGrp_ID.Visible = false;
            // 
            // txtPrntMach_Size
            // 
            this.txtPrntMach_Size.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrntMach_Size.Location = new System.Drawing.Point(200, 75);
            this.txtPrntMach_Size.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrntMach_Size.MaxLength = 25;
            this.txtPrntMach_Size.Name = "txtPrntMach_Size";
            this.txtPrntMach_Size.Size = new System.Drawing.Size(195, 28);
            this.txtPrntMach_Size.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtPrntMach_Size, "Insert Size");
            this.txtPrntMach_Size.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrntMach_Size_KeyPress);
            // 
            // txtPrntMach_Printg
            // 
            this.txtPrntMach_Printg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrntMach_Printg.Location = new System.Drawing.Point(200, 134);
            this.txtPrntMach_Printg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrntMach_Printg.MaxLength = 3;
            this.txtPrntMach_Printg.Name = "txtPrntMach_Printg";
            this.txtPrntMach_Printg.Size = new System.Drawing.Size(195, 28);
            this.txtPrntMach_Printg.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtPrntMach_Printg, "Insert Value");
            this.txtPrntMach_Printg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrntMach_Printg_KeyPress);
            // 
            // txtPrntMach_PlateSgl
            // 
            this.txtPrntMach_PlateSgl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrntMach_PlateSgl.Location = new System.Drawing.Point(200, 193);
            this.txtPrntMach_PlateSgl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrntMach_PlateSgl.MaxLength = 3;
            this.txtPrntMach_PlateSgl.Name = "txtPrntMach_PlateSgl";
            this.txtPrntMach_PlateSgl.Size = new System.Drawing.Size(195, 28);
            this.txtPrntMach_PlateSgl.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtPrntMach_PlateSgl, "Insert Plate Single");
            this.txtPrntMach_PlateSgl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrntMach_PlateSgl_KeyPress);
            // 
            // txtPrntMach_PlateSgl2
            // 
            this.txtPrntMach_PlateSgl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrntMach_PlateSgl2.Location = new System.Drawing.Point(200, 247);
            this.txtPrntMach_PlateSgl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrntMach_PlateSgl2.MaxLength = 3;
            this.txtPrntMach_PlateSgl2.Name = "txtPrntMach_PlateSgl2";
            this.txtPrntMach_PlateSgl2.Size = new System.Drawing.Size(195, 28);
            this.txtPrntMach_PlateSgl2.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtPrntMach_PlateSgl2, "Insert Plate Double");
            this.txtPrntMach_PlateSgl2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrntMach_PlateSgl2_KeyPress);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSubmit.BackgroundImage")));
            this.cmdSubmit.Location = new System.Drawing.Point(8, 378);
            this.cmdSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(75, 75);
            this.cmdSubmit.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cmdSubmit, "Submit");
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.BackgroundImage")));
            this.cmdRefresh.Location = new System.Drawing.Point(218, 378);
            this.cmdRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(75, 75);
            this.cmdRefresh.TabIndex = 7;
            this.toolTip1.SetToolTip(this.cmdRefresh, "Refresh");
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.txtPrntMach_ID);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ddlPrntMach_Active);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.txtPrntMach_Size);
            this.panel1.Controls.Add(this.txtPrntMach_Printg);
            this.panel1.Controls.Add(this.txtPrntMach_PlateSgl);
            this.panel1.Controls.Add(this.txtPrntMach_PlateSgl2);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Location = new System.Drawing.Point(63, 73);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 486);
            this.panel1.TabIndex = 12;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCancel.BackgroundImage")));
            this.cmdCancel.Location = new System.Drawing.Point(320, 378);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 75);
            this.cmdCancel.TabIndex = 16;
            this.toolTip1.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtPrntMach_ID
            // 
            this.txtPrntMach_ID.Location = new System.Drawing.Point(255, 4);
            this.txtPrntMach_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrntMach_ID.Name = "txtPrntMach_ID";
            this.txtPrntMach_ID.Size = new System.Drawing.Size(132, 22);
            this.txtPrntMach_ID.TabIndex = 15;
            this.txtPrntMach_ID.Visible = false;
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdEdit.BackgroundImage")));
            this.cmdEdit.Location = new System.Drawing.Point(111, 378);
            this.cmdEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 75);
            this.cmdEdit.TabIndex = 14;
            this.toolTip1.SetToolTip(this.cmdEdit, "Update");
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Honeydew;
            this.label7.Location = new System.Drawing.Point(4, 302);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 24);
            this.label7.TabIndex = 13;
            this.label7.Text = "Active *";
            // 
            // ddlPrntMach_Active
            // 
            this.ddlPrntMach_Active.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPrntMach_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPrntMach_Active.FormattingEnabled = true;
            this.ddlPrntMach_Active.Location = new System.Drawing.Point(200, 301);
            this.ddlPrntMach_Active.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlPrntMach_Active.Name = "ddlPrntMach_Active";
            this.ddlPrntMach_Active.Size = new System.Drawing.Size(195, 30);
            this.ddlPrntMach_Active.TabIndex = 5;
            this.toolTip1.SetToolTip(this.ddlPrntMach_Active, "Select Active");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(4, 194);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Plate Single Exp *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(4, 248);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Plate Double Exp *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(4, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Printing *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(4, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Machine Size *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(4, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Group *";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(149, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(572, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Item – Printing Machine Management";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Honeydew;
            this.label8.Location = new System.Drawing.Point(687, 116);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Group *";
            // 
            // txtGrp_Name_Search
            // 
            this.txtGrp_Name_Search.Location = new System.Drawing.Point(771, 115);
            this.txtGrp_Name_Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGrp_Name_Search.Name = "txtGrp_Name_Search";
            this.txtGrp_Name_Search.Size = new System.Drawing.Size(160, 22);
            this.txtGrp_Name_Search.TabIndex = 16;
            this.toolTip1.SetToolTip(this.txtGrp_Name_Search, "Enter Group Name");
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.cmdSearch.Location = new System.Drawing.Point(956, 77);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(67, 63);
            this.cmdSearch.TabIndex = 17;
            this.toolTip1.SetToolTip(this.cmdSearch, "Search");
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dgwItem_PrntMach_Master
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwItem_PrntMach_Master.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwItem_PrntMach_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwItem_PrntMach_Master.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwItem_PrntMach_Master.Location = new System.Drawing.Point(515, 150);
            this.dgwItem_PrntMach_Master.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgwItem_PrntMach_Master.Name = "dgwItem_PrntMach_Master";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwItem_PrntMach_Master.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwItem_PrntMach_Master.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwItem_PrntMach_Master.Size = new System.Drawing.Size(775, 409);
            this.dgwItem_PrntMach_Master.TabIndex = 18;
            this.dgwItem_PrntMach_Master.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwItem_PrntMach_Master_RowHeaderMouseClick);
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdExcelReport.BackgroundImage")));
            this.cmdExcelReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExcelReport.Location = new System.Drawing.Point(1215, 62);
            this.cmdExcelReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(75, 75);
            this.cmdExcelReport.TabIndex = 19;
            this.cmdExcelReport.UseVisualStyleBackColor = true;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // RPeP_MasterItemPrntMach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(200, 200);
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1753, 711);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.dgwItem_PrntMach_Master);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtGrp_Name_Search);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RPeP_MasterItemPrntMach";
            this.Text = "RPeP_MasterItemPrntMach";
            this.Load += new System.EventHandler(this.RPeP_MasterItemPrntMach_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItem_PrntMach_Master)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.TextBox txtPrntMach_Size;
        private System.Windows.Forms.TextBox txtPrntMach_Printg;
        private System.Windows.Forms.TextBox txtPrntMach_PlateSgl;
        private System.Windows.Forms.TextBox txtPrntMach_PlateSgl2;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddlPrntMach_Active;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGrp_Name_Search;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.DataGridView dgwItem_PrntMach_Master;
        private System.Windows.Forms.TextBox txtPrntMach_ID;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdExcelReport;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}