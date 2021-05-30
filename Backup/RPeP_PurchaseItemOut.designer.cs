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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseItemOut));
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.labeldt = new System.Windows.Forms.Label();
            this.monthCalendar3 = new System.Windows.Forms.MonthCalendar();
            this.cmdReset = new System.Windows.Forms.Button();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtDateTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDateFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPurchaseItemOut = new System.Windows.Forms.DataGridView();
            this.cmdSearch = new System.Windows.Forms.Button();
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
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseItemOut)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseItemOut_Temp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Controls.Add(this.labeldt);
            this.panel1.Controls.Add(this.monthCalendar3);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.monthCalendar2);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.txtDateTo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDateFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dgvPurchaseItemOut);
            this.panel1.Controls.Add(this.cmdSearch);
            this.panel1.Controls.Add(this.txtSIOut_Dt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSIOut_ID);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 604);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(647, -6);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 53;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.LightSlateGray;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // labeldt
            // 
            this.labeldt.ForeColor = System.Drawing.Color.Yellow;
            this.labeldt.Location = new System.Drawing.Point(657, 21);
            this.labeldt.Name = "labeldt";
            this.labeldt.Size = new System.Drawing.Size(99, 21);
            this.labeldt.TabIndex = 75;
            this.labeldt.Text = "DD/MM/YYYY";
            // 
            // monthCalendar3
            // 
            this.monthCalendar3.Location = new System.Drawing.Point(578, 372);
            this.monthCalendar3.Name = "monthCalendar3";
            this.monthCalendar3.TabIndex = 60;
            this.monthCalendar3.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar3_DateSelected);
            this.monthCalendar3.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar3_DateChanged);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdReset.Location = new System.Drawing.Point(337, 258);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(50, 51);
            this.cmdReset.TabIndex = 46;
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(578, 374);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 59;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            this.monthCalendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateChanged);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSubmit.Location = new System.Drawing.Point(281, 258);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 45;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancel.Location = new System.Drawing.Point(393, 258);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 47;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtDateTo
            // 
            this.txtDateTo.Location = new System.Drawing.Point(404, 341);
            this.txtDateTo.MaxLength = 50;
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(129, 20);
            this.txtDateTo.TabIndex = 58;
            this.txtDateTo.Click += new System.EventHandler(this.txtDateTo_Click);
            this.txtDateTo.Leave += new System.EventHandler(this.txtDateTo_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(356, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "and";
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Location = new System.Drawing.Point(221, 339);
            this.txtDateFrom.MaxLength = 50;
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(129, 20);
            this.txtDateFrom.TabIndex = 55;
            this.txtDateFrom.Click += new System.EventHandler(this.txtDateFrom_Click);
            this.txtDateFrom.Leave += new System.EventHandler(this.txtDateFrom_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(63, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "Outward Date Between *";
            // 
            // dgvPurchaseItemOut
            // 
            this.dgvPurchaseItemOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseItemOut.Location = new System.Drawing.Point(33, 366);
            this.dgvPurchaseItemOut.Name = "dgvPurchaseItemOut";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgvPurchaseItemOut.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchaseItemOut.Size = new System.Drawing.Size(542, 137);
            this.dgvPurchaseItemOut.TabIndex = 49;
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.cmdSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSearch.Location = new System.Drawing.Point(552, 310);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(50, 51);
            this.cmdSearch.TabIndex = 51;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // txtSIOut_Dt
            // 
            this.txtSIOut_Dt.Location = new System.Drawing.Point(499, 22);
            this.txtSIOut_Dt.MaxLength = 10;
            this.txtSIOut_Dt.Name = "txtSIOut_Dt";
            this.txtSIOut_Dt.Size = new System.Drawing.Size(140, 20);
            this.txtSIOut_Dt.TabIndex = 35;
            this.txtSIOut_Dt.Leave += new System.EventHandler(this.txtSIOut_Dt_Leave);
            this.txtSIOut_Dt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSIOut_Dt_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(378, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Outward  Dt. *";
            // 
            // txtSIOut_ID
            // 
            this.txtSIOut_ID.Location = new System.Drawing.Point(660, 22);
            this.txtSIOut_ID.Name = "txtSIOut_ID";
            this.txtSIOut_ID.Size = new System.Drawing.Size(55, 20);
            this.txtSIOut_ID.TabIndex = 34;
            this.txtSIOut_ID.Visible = false;
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(155, 21);
            this.ddlGrp_ID.MaxLength = 50;
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(206, 21);
            this.ddlGrp_ID.TabIndex = 33;
            this.ddlGrp_ID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
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
            this.panel2.Location = new System.Drawing.Point(19, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(737, 154);
            this.panel2.TabIndex = 54;
            // 
            // cmddelTemp
            // 
            this.cmddelTemp.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmddelTemp.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmddelTemp.Location = new System.Drawing.Point(261, 75);
            this.cmddelTemp.Name = "cmddelTemp";
            this.cmddelTemp.Size = new System.Drawing.Size(50, 23);
            this.cmddelTemp.TabIndex = 49;
            this.cmddelTemp.Text = "Delete";
            this.cmddelTemp.UseVisualStyleBackColor = false;
            this.cmddelTemp.Click += new System.EventHandler(this.cmddelTemp_Click);
            // 
            // cmdTemp_Submit
            // 
            this.cmdTemp_Submit.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.cmdTemp_Submit.Location = new System.Drawing.Point(266, 46);
            this.cmdTemp_Submit.Name = "cmdTemp_Submit";
            this.cmdTemp_Submit.Size = new System.Drawing.Size(44, 23);
            this.cmdTemp_Submit.TabIndex = 48;
            this.cmdTemp_Submit.Text = ">>>";
            this.cmdTemp_Submit.UseVisualStyleBackColor = true;
            this.cmdTemp_Submit.Click += new System.EventHandler(this.cmdTemp_Submit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Purchase Item *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(3, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "Out Put Qty.  *";
            // 
            // txtSI_OutQty
            // 
            this.txtSI_OutQty.Location = new System.Drawing.Point(110, 78);
            this.txtSI_OutQty.MaxLength = 10;
            this.txtSI_OutQty.Name = "txtSI_OutQty";
            this.txtSI_OutQty.Size = new System.Drawing.Size(150, 20);
            this.txtSI_OutQty.TabIndex = 41;
            // 
            // ddlSI_ID
            // 
            this.ddlSI_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSI_ID.FormattingEnabled = true;
            this.ddlSI_ID.ItemHeight = 13;
            this.ddlSI_ID.Location = new System.Drawing.Point(110, 27);
            this.ddlSI_ID.MaxDropDownItems = 100;
            this.ddlSI_ID.MaxLength = 50;
            this.ddlSI_ID.Name = "ddlSI_ID";
            this.ddlSI_ID.Size = new System.Drawing.Size(150, 21);
            this.ddlSI_ID.TabIndex = 37;
            this.ddlSI_ID.SelectedIndexChanged += new System.EventHandler(this.ddlSI_ID_SelectedIndexChanged);
            // 
            // PurchaseItemOut_Temp
            // 
            this.PurchaseItemOut_Temp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PurchaseItemOut_Temp.Location = new System.Drawing.Point(313, 14);
            this.PurchaseItemOut_Temp.Name = "PurchaseItemOut_Temp";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            this.PurchaseItemOut_Temp.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.PurchaseItemOut_Temp.Size = new System.Drawing.Size(403, 116);
            this.PurchaseItemOut_Temp.TabIndex = 0;
            this.PurchaseItemOut_Temp.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PurchaseItemOut_Temp_RowHeaderMouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(241, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(328, 31);
            this.label7.TabIndex = 4;
            this.label7.Text = "Purchases Item : Outward";
            // 
            // PurchaseItemOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PurchaseItemOut";
            this.Text = "RPeP_PurchaseItemOut";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PurchaseItemOut_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseItemOut)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseItemOut_Temp)).EndInit();
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