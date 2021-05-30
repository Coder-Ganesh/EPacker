namespace ePacker1
{
    partial class PurchaseItemOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseItemOut));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.labeldt = new System.Windows.Forms.Label();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtSIOut_Dt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSIOut_ID = new System.Windows.Forms.TextBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmddelTemp = new System.Windows.Forms.Button();
            this.cmdTemp_Submit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSI_OutQty = new System.Windows.Forms.TextBox();
            this.ddlSI_ID = new System.Windows.Forms.ComboBox();
            this.PurchaseItemOut_Temp = new System.Windows.Forms.DataGridView();
            this.monthCalendar3 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.txtDateTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDateFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPurchaseItemOut = new System.Windows.Forms.DataGridView();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseItemOut_Temp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseItemOut)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Controls.Add(this.labeldt);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.txtSIOut_Dt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSIOut_ID);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(16, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 619);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(343, 43);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 53;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.LightSlateGray;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // labeldt
            // 
            this.labeldt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldt.ForeColor = System.Drawing.Color.Yellow;
            this.labeldt.Location = new System.Drawing.Point(13, 12);
            this.labeldt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeldt.Name = "labeldt";
            this.labeldt.Size = new System.Drawing.Size(132, 26);
            this.labeldt.TabIndex = 75;
            this.labeldt.Text = "DD/MM/YYYY";
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdReset.BackgroundImage")));
            this.cmdReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdReset.Location = new System.Drawing.Point(212, 494);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(4);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 75);
            this.cmdReset.TabIndex = 46;
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSubmit.BackgroundImage")));
            this.cmdSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSubmit.Location = new System.Drawing.Point(17, 494);
            this.cmdSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(75, 75);
            this.cmdSubmit.TabIndex = 45;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCancel.BackgroundImage")));
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancel.Location = new System.Drawing.Point(394, 494);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 75);
            this.cmdCancel.TabIndex = 47;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtSIOut_Dt
            // 
            this.txtSIOut_Dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSIOut_Dt.Location = new System.Drawing.Point(142, 42);
            this.txtSIOut_Dt.Margin = new System.Windows.Forms.Padding(4);
            this.txtSIOut_Dt.MaxLength = 10;
            this.txtSIOut_Dt.Name = "txtSIOut_Dt";
            this.txtSIOut_Dt.Size = new System.Drawing.Size(185, 28);
            this.txtSIOut_Dt.TabIndex = 35;
            this.txtSIOut_Dt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSIOut_Dt_MouseClick);
            this.txtSIOut_Dt.Leave += new System.EventHandler(this.txtSIOut_Dt_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(9, 43);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 24);
            this.label6.TabIndex = 36;
            this.label6.Text = "Outward  Dt. *";
            // 
            // txtSIOut_ID
            // 
            this.txtSIOut_ID.Location = new System.Drawing.Point(482, 6);
            this.txtSIOut_ID.Margin = new System.Windows.Forms.Padding(4);
            this.txtSIOut_ID.Name = "txtSIOut_ID";
            this.txtSIOut_ID.Size = new System.Drawing.Size(72, 22);
            this.txtSIOut_ID.TabIndex = 34;
            this.txtSIOut_ID.Visible = false;
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(180, 4);
            this.ddlGrp_ID.Margin = new System.Windows.Forms.Padding(4);
            this.ddlGrp_ID.MaxLength = 50;
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(273, 24);
            this.ddlGrp_ID.TabIndex = 33;
            this.ddlGrp_ID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(13, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Group *";
            this.label1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmddelTemp);
            this.panel2.Controls.Add(this.cmdTemp_Submit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtSI_OutQty);
            this.panel2.Controls.Add(this.ddlSI_ID);
            this.panel2.Controls.Add(this.PurchaseItemOut_Temp);
            this.panel2.Location = new System.Drawing.Point(4, 95);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(708, 376);
            this.panel2.TabIndex = 54;
            // 
            // cmddelTemp
            // 
            this.cmddelTemp.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmddelTemp.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmddelTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmddelTemp.Location = new System.Drawing.Point(234, 92);
            this.cmddelTemp.Margin = new System.Windows.Forms.Padding(4);
            this.cmddelTemp.Name = "cmddelTemp";
            this.cmddelTemp.Size = new System.Drawing.Size(88, 28);
            this.cmddelTemp.TabIndex = 49;
            this.cmddelTemp.Text = "Delete";
            this.cmddelTemp.UseVisualStyleBackColor = false;
            this.cmddelTemp.Click += new System.EventHandler(this.cmddelTemp_Click);
            // 
            // cmdTemp_Submit
            // 
            this.cmdTemp_Submit.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.cmdTemp_Submit.Location = new System.Drawing.Point(147, 92);
            this.cmdTemp_Submit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdTemp_Submit.Name = "cmdTemp_Submit";
            this.cmdTemp_Submit.Size = new System.Drawing.Size(59, 28);
            this.cmdTemp_Submit.TabIndex = 48;
            this.cmdTemp_Submit.Text = ">>>";
            this.cmdTemp_Submit.UseVisualStyleBackColor = true;
            this.cmdTemp_Submit.Click += new System.EventHandler(this.cmdTemp_Submit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 24);
            this.label2.TabIndex = 38;
            this.label2.Text = "Purchase Item *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(354, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 24);
            this.label4.TabIndex = 42;
            this.label4.Text = "Out Put Qty.  *";
            // 
            // txtSI_OutQty
            // 
            this.txtSI_OutQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSI_OutQty.Location = new System.Drawing.Point(497, 33);
            this.txtSI_OutQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtSI_OutQty.MaxLength = 10;
            this.txtSI_OutQty.Name = "txtSI_OutQty";
            this.txtSI_OutQty.Size = new System.Drawing.Size(199, 28);
            this.txtSI_OutQty.TabIndex = 41;
            // 
            // ddlSI_ID
            // 
            this.ddlSI_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSI_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSI_ID.FormattingEnabled = true;
            this.ddlSI_ID.ItemHeight = 22;
            this.ddlSI_ID.Location = new System.Drawing.Point(154, 33);
            this.ddlSI_ID.Margin = new System.Windows.Forms.Padding(4);
            this.ddlSI_ID.MaxDropDownItems = 100;
            this.ddlSI_ID.MaxLength = 50;
            this.ddlSI_ID.Name = "ddlSI_ID";
            this.ddlSI_ID.Size = new System.Drawing.Size(192, 30);
            this.ddlSI_ID.TabIndex = 37;
            this.ddlSI_ID.SelectedIndexChanged += new System.EventHandler(this.ddlSI_ID_SelectedIndexChanged);
            // 
            // PurchaseItemOut_Temp
            // 
            this.PurchaseItemOut_Temp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PurchaseItemOut_Temp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PurchaseItemOut_Temp.Location = new System.Drawing.Point(12, 145);
            this.PurchaseItemOut_Temp.Margin = new System.Windows.Forms.Padding(4);
            this.PurchaseItemOut_Temp.Name = "PurchaseItemOut_Temp";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Orange;
            this.PurchaseItemOut_Temp.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.PurchaseItemOut_Temp.Size = new System.Drawing.Size(684, 222);
            this.PurchaseItemOut_Temp.TabIndex = 0;
            this.PurchaseItemOut_Temp.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PurchaseItemOut_Temp_RowHeaderMouseClick);
            // 
            // monthCalendar3
            // 
            this.monthCalendar3.Location = new System.Drawing.Point(1212, 155);
            this.monthCalendar3.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monthCalendar3.Name = "monthCalendar3";
            this.monthCalendar3.TabIndex = 60;
            this.monthCalendar3.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar3_DateChanged);
            this.monthCalendar3.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar3_DateSelected);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(891, 155);
            this.monthCalendar2.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 59;
            this.monthCalendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateChanged);
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            // 
            // txtDateTo
            // 
            this.txtDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTo.Location = new System.Drawing.Point(1212, 123);
            this.txtDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDateTo.MaxLength = 50;
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(154, 28);
            this.txtDateTo.TabIndex = 58;
            this.txtDateTo.Click += new System.EventHandler(this.txtDateTo_Click);
            this.txtDateTo.Leave += new System.EventHandler(this.txtDateTo_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(1162, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 24);
            this.label5.TabIndex = 57;
            this.label5.Text = "and";
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateFrom.Location = new System.Drawing.Point(999, 122);
            this.txtDateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.txtDateFrom.MaxLength = 50;
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(154, 28);
            this.txtDateFrom.TabIndex = 55;
            this.txtDateFrom.Click += new System.EventHandler(this.txtDateFrom_Click);
            this.txtDateFrom.Leave += new System.EventHandler(this.txtDateFrom_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(771, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 24);
            this.label3.TabIndex = 56;
            this.label3.Text = "Outward Date Between*";
            // 
            // dgvPurchaseItemOut
            // 
            this.dgvPurchaseItemOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseItemOut.Location = new System.Drawing.Point(775, 178);
            this.dgvPurchaseItemOut.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPurchaseItemOut.Name = "dgvPurchaseItemOut";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgvPurchaseItemOut.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPurchaseItemOut.Size = new System.Drawing.Size(707, 321);
            this.dgvPurchaseItemOut.TabIndex = 49;
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSearch.BackgroundImage")));
            this.cmdSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSearch.Location = new System.Drawing.Point(1390, 75);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 75);
            this.cmdSearch.TabIndex = 51;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(321, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(408, 39);
            this.label7.TabIndex = 4;
            this.label7.Text = "Purchases Item : Outward";
            // 
            // PurchaseItemOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1803, 711);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.monthCalendar3);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.dgvPurchaseItemOut);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDateFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDateTo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PurchaseItemOut";
            this.Text = "RPeP_PurchaseItemOut";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PurchaseItemOut_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseItemOut_Temp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseItemOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DataGridView dgvPurchaseItemOut;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.TextBox txtSI_OutQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlSI_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSIOut_Dt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSIOut_ID;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView PurchaseItemOut_Temp;
        private System.Windows.Forms.TextBox txtDateTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDateFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdTemp_Submit;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.MonthCalendar monthCalendar3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmddelTemp;
        private System.Windows.Forms.Label labeldt;
    }
}