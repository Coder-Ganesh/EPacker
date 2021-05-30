namespace ePacker1
{
    partial class RPeP_TopPaperParty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_TopPaperParty));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdPaperSearch = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtTP_OrdId = new System.Windows.Forms.TextBox();
            this.ddlTPP_Active = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdReset = new System.Windows.Forms.Button();
            this.txtPartyMainSearch = new System.Windows.Forms.TextBox();
            this.cmdPartySearch = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.txtRQty = new System.Windows.Forms.TextBox();
            this.txCloseStock = new System.Windows.Forms.TextBox();
            this.txtOpenStock = new System.Windows.Forms.TextBox();
            this.txtReOrderLevel = new System.Windows.Forms.TextBox();
            this.ddlP_ID = new System.Windows.Forms.ComboBox();
            this.ddlPM_ID = new System.Windows.Forms.ComboBox();
            this.ddlTP_ID = new System.Windows.Forms.ComboBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgwTopPaper_Party = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTopPaper_Party)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdPaperSearch);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.txtTP_OrdId);
            this.panel1.Controls.Add(this.ddlTPP_Active);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.txtPartyMainSearch);
            this.panel1.Controls.Add(this.cmdPartySearch);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.txtNameSearch);
            this.panel1.Controls.Add(this.txtRQty);
            this.panel1.Controls.Add(this.txCloseStock);
            this.panel1.Controls.Add(this.txtOpenStock);
            this.panel1.Controls.Add(this.txtReOrderLevel);
            this.panel1.Controls.Add(this.ddlP_ID);
            this.panel1.Controls.Add(this.ddlPM_ID);
            this.panel1.Controls.Add(this.ddlTP_ID);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(25, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 358);
            this.panel1.TabIndex = 0;
            // 
            // cmdPaperSearch
            // 
            this.cmdPaperSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search1;
            this.cmdPaperSearch.Location = new System.Drawing.Point(715, 14);
            this.cmdPaperSearch.Name = "cmdPaperSearch";
            this.cmdPaperSearch.Size = new System.Drawing.Size(56, 43);
            this.cmdPaperSearch.TabIndex = 11;
            this.cmdPaperSearch.UseVisualStyleBackColor = true;
            this.cmdPaperSearch.Click += new System.EventHandler(this.cmdPaperSearch_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.Location = new System.Drawing.Point(538, 274);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 28;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtTP_OrdId
            // 
            this.txtTP_OrdId.Location = new System.Drawing.Point(573, 3);
            this.txtTP_OrdId.MaxLength = 15;
            this.txtTP_OrdId.Name = "txtTP_OrdId";
            this.txtTP_OrdId.Size = new System.Drawing.Size(100, 20);
            this.txtTP_OrdId.TabIndex = 27;
            // 
            // ddlTPP_Active
            // 
            this.ddlTPP_Active.FormattingEnabled = true;
            this.ddlTPP_Active.Location = new System.Drawing.Point(146, 233);
            this.ddlTPP_Active.MaxLength = 3;
            this.ddlTPP_Active.Name = "ddlTPP_Active";
            this.ddlTPP_Active.Size = new System.Drawing.Size(121, 21);
            this.ddlTPP_Active.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Honeydew;
            this.label10.Location = new System.Drawing.Point(35, 235);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Active*";
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdReset.Location = new System.Drawing.Point(426, 274);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(50, 51);
            this.cmdReset.TabIndex = 23;
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // txtPartyMainSearch
            // 
            this.txtPartyMainSearch.Location = new System.Drawing.Point(609, 118);
            this.txtPartyMainSearch.Name = "txtPartyMainSearch";
            this.txtPartyMainSearch.Size = new System.Drawing.Size(100, 20);
            this.txtPartyMainSearch.TabIndex = 16;
            // 
            // cmdPartySearch
            // 
            this.cmdPartySearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search1;
            this.cmdPartySearch.Location = new System.Drawing.Point(715, 91);
            this.cmdPartySearch.Name = "cmdPartySearch";
            this.cmdPartySearch.Size = new System.Drawing.Size(56, 47);
            this.cmdPartySearch.TabIndex = 17;
            this.cmdPartySearch.UseVisualStyleBackColor = true;
            this.cmdPartySearch.Click += new System.EventHandler(this.cmdPartySearch_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdEdit.Location = new System.Drawing.Point(482, 274);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(50, 51);
            this.cmdEdit.TabIndex = 24;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.Location = new System.Drawing.Point(370, 274);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 22;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Location = new System.Drawing.Point(609, 37);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(100, 20);
            this.txtNameSearch.TabIndex = 10;
            // 
            // txtRQty
            // 
            this.txtRQty.Location = new System.Drawing.Point(146, 197);
            this.txtRQty.MaxLength = 10;
            this.txtRQty.Name = "txtRQty";
            this.txtRQty.Size = new System.Drawing.Size(100, 20);
            this.txtRQty.TabIndex = 20;
            // 
            // txCloseStock
            // 
            this.txCloseStock.Enabled = false;
            this.txCloseStock.Location = new System.Drawing.Point(370, 78);
            this.txCloseStock.Name = "txCloseStock";
            this.txCloseStock.Size = new System.Drawing.Size(100, 20);
            this.txCloseStock.TabIndex = 14;
            // 
            // txtOpenStock
            // 
            this.txtOpenStock.Enabled = false;
            this.txtOpenStock.Location = new System.Drawing.Point(146, 78);
            this.txtOpenStock.Name = "txtOpenStock";
            this.txtOpenStock.Size = new System.Drawing.Size(100, 20);
            this.txtOpenStock.TabIndex = 13;
            // 
            // txtReOrderLevel
            // 
            this.txtReOrderLevel.Enabled = false;
            this.txtReOrderLevel.Location = new System.Drawing.Point(609, 78);
            this.txtReOrderLevel.Name = "txtReOrderLevel";
            this.txtReOrderLevel.Size = new System.Drawing.Size(100, 20);
            this.txtReOrderLevel.TabIndex = 15;
            // 
            // ddlP_ID
            // 
            this.ddlP_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlP_ID.FormattingEnabled = true;
            this.ddlP_ID.Location = new System.Drawing.Point(146, 156);
            this.ddlP_ID.MaxLength = 6;
            this.ddlP_ID.Name = "ddlP_ID";
            this.ddlP_ID.Size = new System.Drawing.Size(398, 21);
            this.ddlP_ID.TabIndex = 19;
            // 
            // ddlPM_ID
            // 
            this.ddlPM_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPM_ID.FormattingEnabled = true;
            this.ddlPM_ID.Location = new System.Drawing.Point(146, 116);
            this.ddlPM_ID.MaxLength = 6;
            this.ddlPM_ID.Name = "ddlPM_ID";
            this.ddlPM_ID.Size = new System.Drawing.Size(398, 21);
            this.ddlPM_ID.TabIndex = 18;
            // 
            // ddlTP_ID
            // 
            this.ddlTP_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTP_ID.FormattingEnabled = true;
            this.ddlTP_ID.Location = new System.Drawing.Point(146, 36);
            this.ddlTP_ID.Name = "ddlTP_ID";
            this.ddlTP_ID.Size = new System.Drawing.Size(398, 21);
            this.ddlTP_ID.TabIndex = 12;
            this.ddlTP_ID.SelectedIndexChanged += new System.EventHandler(this.ddlTP_ID_SelectedIndexChanged);
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(146, 4);
            this.ddlGrp_ID.MaxLength = 5;
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(398, 21);
            this.ddlGrp_ID.TabIndex = 9;
            this.ddlGrp_ID.Visible = false;
            this.ddlGrp_ID.SelectedValueChanged += new System.EventHandler(this.ddlGrp_ID_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Honeydew;
            this.label9.Location = new System.Drawing.Point(487, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Re. Ord. Level *";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Honeydew;
            this.label8.Location = new System.Drawing.Point(262, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Close. Stock *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(35, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "R.eq. Qty *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(35, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Party *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(35, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Party Main *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(35, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Open. Stock *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(35, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(35, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group *";
            this.label1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(298, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(373, 31);
            this.label7.TabIndex = 8;
            this.label7.Text = "Top Paper Party Requirement";
            // 
            // dgwTopPaper_Party
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwTopPaper_Party.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwTopPaper_Party.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwTopPaper_Party.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwTopPaper_Party.Location = new System.Drawing.Point(156, 450);
            this.dgwTopPaper_Party.Name = "dgwTopPaper_Party";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwTopPaper_Party.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwTopPaper_Party.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwTopPaper_Party.Size = new System.Drawing.Size(530, 150);
            this.dgwTopPaper_Party.TabIndex = 26;
            this.dgwTopPaper_Party.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwTopPaper_Party_RowHeaderMouseClick);
            // 
            // RPeP_TopPaperParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(900, 578);
            this.Controls.Add(this.dgwTopPaper_Party);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_TopPaperParty";
            this.Text = "RPeP_TopPaperParty";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPeP_TopPaperParty_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTopPaper_Party)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRQty;
        private System.Windows.Forms.TextBox txCloseStock;
        private System.Windows.Forms.TextBox txtOpenStock;
        private System.Windows.Forms.TextBox txtReOrderLevel;
        private System.Windows.Forms.ComboBox ddlP_ID;
        private System.Windows.Forms.ComboBox ddlPM_ID;
        private System.Windows.Forms.ComboBox ddlTP_ID;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.TextBox txtPartyMainSearch;
        private System.Windows.Forms.Button cmdPartySearch;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Button cmdPaperSearch;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddlTPP_Active;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgwTopPaper_Party;
        private System.Windows.Forms.TextBox txtTP_OrdId;
        private System.Windows.Forms.Button cmdCancel;
    }
}