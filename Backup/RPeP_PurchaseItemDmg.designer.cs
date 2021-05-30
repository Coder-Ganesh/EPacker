namespace ePacker1
{
    partial class RPeP_PurchaseItemDmg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_PurchaseItemDmg));
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.labeldt = new System.Windows.Forms.Label();
            this.ddlItemSearch = new System.Windows.Forms.ComboBox();
            this.dgwRPeP_MasterParty = new System.Windows.Forms.DataGridView();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.lblP_Name1 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.txtSI_CuStock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSI_DmgQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSI_DmgNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlSI_ID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSIDmg_Dt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSIDmg_ID = new System.Windows.Forms.TextBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRPeP_MasterParty)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Controls.Add(this.labeldt);
            this.panel1.Controls.Add(this.ddlItemSearch);
            this.panel1.Controls.Add(this.dgwRPeP_MasterParty);
            this.panel1.Controls.Add(this.cmdSearch);
            this.panel1.Controls.Add(this.lblP_Name1);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.txtSI_CuStock);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSI_DmgQty);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSI_DmgNote);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ddlSI_ID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSIDmg_Dt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSIDmg_ID);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(74, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 626);
            this.panel1.TabIndex = 2;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(437, 25);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 53;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.LightSlateGray;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // labeldt
            // 
            this.labeldt.ForeColor = System.Drawing.Color.Yellow;
            this.labeldt.Location = new System.Drawing.Point(450, 66);
            this.labeldt.Name = "labeldt";
            this.labeldt.Size = new System.Drawing.Size(99, 21);
            this.labeldt.TabIndex = 75;
            this.labeldt.Text = "DD/MM/YYYY";
            // 
            // ddlItemSearch
            // 
            this.ddlItemSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlItemSearch.FormattingEnabled = true;
            this.ddlItemSearch.Location = new System.Drawing.Point(213, 309);
            this.ddlItemSearch.Name = "ddlItemSearch";
            this.ddlItemSearch.Size = new System.Drawing.Size(137, 21);
            this.ddlItemSearch.TabIndex = 52;
            // 
            // dgwRPeP_MasterParty
            // 
            this.dgwRPeP_MasterParty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwRPeP_MasterParty.Location = new System.Drawing.Point(78, 353);
            this.dgwRPeP_MasterParty.Name = "dgwRPeP_MasterParty";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwRPeP_MasterParty.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwRPeP_MasterParty.Size = new System.Drawing.Size(497, 137);
            this.dgwRPeP_MasterParty.TabIndex = 49;
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.cmdSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSearch.Location = new System.Drawing.Point(381, 296);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(50, 51);
            this.cmdSearch.TabIndex = 51;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // lblP_Name1
            // 
            this.lblP_Name1.AutoSize = true;
            this.lblP_Name1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP_Name1.ForeColor = System.Drawing.Color.Honeydew;
            this.lblP_Name1.Location = new System.Drawing.Point(152, 314);
            this.lblP_Name1.Name = "lblP_Name1";
            this.lblP_Name1.Size = new System.Drawing.Size(41, 16);
            this.lblP_Name1.TabIndex = 48;
            this.lblP_Name1.Text = "Item *";
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.Location = new System.Drawing.Point(347, 214);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 47;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdReset.Location = new System.Drawing.Point(291, 214);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(50, 51);
            this.cmdReset.TabIndex = 46;
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.Location = new System.Drawing.Point(235, 214);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 45;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // txtSI_CuStock
            // 
            this.txtSI_CuStock.Location = new System.Drawing.Point(213, 104);
            this.txtSI_CuStock.MaxLength = 10;
            this.txtSI_CuStock.Name = "txtSI_CuStock";
            this.txtSI_CuStock.Size = new System.Drawing.Size(206, 20);
            this.txtSI_CuStock.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(75, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 44;
            this.label5.Text = "Cu. Stock";
            // 
            // txtSI_DmgQty
            // 
            this.txtSI_DmgQty.Location = new System.Drawing.Point(213, 138);
            this.txtSI_DmgQty.MaxLength = 10;
            this.txtSI_DmgQty.Name = "txtSI_DmgQty";
            this.txtSI_DmgQty.Size = new System.Drawing.Size(206, 20);
            this.txtSI_DmgQty.TabIndex = 41;
            this.txtSI_DmgQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSI_DmgQty_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(75, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "Damaged Qty.  *";
            // 
            // txtSI_DmgNote
            // 
            this.txtSI_DmgNote.Location = new System.Drawing.Point(213, 172);
            this.txtSI_DmgNote.MaxLength = 50;
            this.txtSI_DmgNote.Name = "txtSI_DmgNote";
            this.txtSI_DmgNote.Size = new System.Drawing.Size(206, 20);
            this.txtSI_DmgNote.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(75, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Note *";
            // 
            // ddlSI_ID
            // 
            this.ddlSI_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSI_ID.FormattingEnabled = true;
            this.ddlSI_ID.ItemHeight = 13;
            this.ddlSI_ID.Location = new System.Drawing.Point(213, 70);
            this.ddlSI_ID.MaxDropDownItems = 100;
            this.ddlSI_ID.MaxLength = 50;
            this.ddlSI_ID.Name = "ddlSI_ID";
            this.ddlSI_ID.Size = new System.Drawing.Size(206, 21);
            this.ddlSI_ID.TabIndex = 37;
            this.ddlSI_ID.SelectedIndexChanged += new System.EventHandler(this.ddlSI_ID_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(75, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Item *";
            // 
            // txtSIDmg_Dt
            // 
            this.txtSIDmg_Dt.Location = new System.Drawing.Point(213, 34);
            this.txtSIDmg_Dt.MaxLength = 50;
            this.txtSIDmg_Dt.Name = "txtSIDmg_Dt";
            this.txtSIDmg_Dt.Size = new System.Drawing.Size(206, 20);
            this.txtSIDmg_Dt.TabIndex = 35;
            this.txtSIDmg_Dt.Leave += new System.EventHandler(this.txtSIDmg_Dt_Leave);
            this.txtSIDmg_Dt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSIDmg_Dt_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(75, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Damage Dt. *";
            // 
            // txtSIDmg_ID
            // 
            this.txtSIDmg_ID.Location = new System.Drawing.Point(466, 4);
            this.txtSIDmg_ID.Name = "txtSIDmg_ID";
            this.txtSIDmg_ID.Size = new System.Drawing.Size(109, 20);
            this.txtSIDmg_ID.TabIndex = 34;
            this.txtSIDmg_ID.Visible = false;
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(213, 3);
            this.ddlGrp_ID.MaxLength = 50;
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(206, 21);
            this.ddlGrp_ID.TabIndex = 33;
            this.ddlGrp_ID.Visible = false;
            this.ddlGrp_ID.SelectedIndexChanged += new System.EventHandler(this.ddlGrp_ID_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(75, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Group *";
            this.label1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOrange;
            this.label8.Location = new System.Drawing.Point(260, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(306, 31);
            this.label8.TabIndex = 8;
            this.label8.Text = "Purchase Item :Damage";
            // 
            // RPeP_PurchaseItemDmg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(5, 100);
            this.AutoScrollMinSize = new System.Drawing.Size(5, 100);
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_PurchaseItemDmg";
            this.Text = "Purchases Item : Damage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPeP_PurchaseItemDmg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRPeP_MasterParty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSIDmg_ID;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSIDmg_Dt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlSI_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSI_CuStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSI_DmgQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSI_DmgNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.DataGridView dgwRPeP_MasterParty;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label lblP_Name1;
        private System.Windows.Forms.ComboBox ddlItemSearch;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label labeldt;
    }
}