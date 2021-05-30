namespace ePacker1
{
    partial class RPeP_MasterPartyMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterPartyMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblName_Descr = new System.Windows.Forms.Label();
            this.txtPM_ID = new System.Windows.Forms.TextBox();
            this.lblName_Desc = new System.Windows.Forms.Label();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.ddlPM_Active = new System.Windows.Forms.ComboBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.txtPM_Name = new System.Windows.Forms.TextBox();
            this.lblPM_Active = new System.Windows.Forms.Label();
            this.lblGrp_ID = new System.Windows.Forms.Label();
            this.lblPM_Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgwRPeP_MasterPartyMain = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRPeP_MasterPartyMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScrollMargin = new System.Drawing.Size(200, 200);
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.lblName_Descr);
            this.panel1.Controls.Add(this.txtPM_ID);
            this.panel1.Controls.Add(this.lblName_Desc);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.ddlPM_Active);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.txtPM_Name);
            this.panel1.Controls.Add(this.lblPM_Active);
            this.panel1.Controls.Add(this.lblGrp_ID);
            this.panel1.Controls.Add(this.lblPM_Name);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 290);
            this.panel1.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdCancel.Location = new System.Drawing.Point(612, 212);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblName_Descr
            // 
            this.lblName_Descr.AutoSize = true;
            this.lblName_Descr.Location = new System.Drawing.Point(288, 111);
            this.lblName_Descr.Name = "lblName_Descr";
            this.lblName_Descr.Size = new System.Drawing.Size(0, 13);
            this.lblName_Descr.TabIndex = 11;
            // 
            // txtPM_ID
            // 
            this.txtPM_ID.Location = new System.Drawing.Point(187, 17);
            this.txtPM_ID.Name = "txtPM_ID";
            this.txtPM_ID.Size = new System.Drawing.Size(100, 20);
            this.txtPM_ID.TabIndex = 10;
            // 
            // lblName_Desc
            // 
            this.lblName_Desc.AutoSize = true;
            this.lblName_Desc.ForeColor = System.Drawing.Color.Yellow;
            this.lblName_Desc.Location = new System.Drawing.Point(318, 85);
            this.lblName_Desc.Name = "lblName_Desc";
            this.lblName_Desc.Size = new System.Drawing.Size(35, 13);
            this.lblName_Desc.TabIndex = 9;
            this.lblName_Desc.Text = "Name";
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdEdit.Location = new System.Drawing.Point(556, 212);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(50, 51);
            this.cmdEdit.TabIndex = 8;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.Location = new System.Drawing.Point(500, 212);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(50, 51);
            this.cmdRefresh.TabIndex = 7;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSubmit.Location = new System.Drawing.Point(444, 212);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 6;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // ddlPM_Active
            // 
            this.ddlPM_Active.FormattingEnabled = true;
            this.ddlPM_Active.Location = new System.Drawing.Point(187, 119);
            this.ddlPM_Active.MaxLength = 3;
            this.ddlPM_Active.Name = "ddlPM_Active";
            this.ddlPM_Active.Size = new System.Drawing.Size(242, 21);
            this.ddlPM_Active.TabIndex = 5;
            this.toolTip1.SetToolTip(this.ddlPM_Active, "Select GroupActive");
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(187, 172);
            this.ddlGrp_ID.MaxLength = 3;
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(242, 21);
            this.ddlGrp_ID.TabIndex = 4;
            this.toolTip1.SetToolTip(this.ddlGrp_ID, "Select GroupName");
            this.ddlGrp_ID.Visible = false;
            // 
            // txtPM_Name
            // 
            this.txtPM_Name.Location = new System.Drawing.Point(187, 60);
            this.txtPM_Name.MaxLength = 50;
            this.txtPM_Name.Multiline = true;
            this.txtPM_Name.Name = "txtPM_Name";
            this.txtPM_Name.Size = new System.Drawing.Size(242, 22);
            this.txtPM_Name.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtPM_Name, "Enter Party Name");
            this.txtPM_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttxtPM_Name_KeyPress);
            // 
            // lblPM_Active
            // 
            this.lblPM_Active.AutoSize = true;
            this.lblPM_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPM_Active.ForeColor = System.Drawing.Color.Honeydew;
            this.lblPM_Active.Location = new System.Drawing.Point(89, 124);
            this.lblPM_Active.Name = "lblPM_Active";
            this.lblPM_Active.Size = new System.Drawing.Size(50, 16);
            this.lblPM_Active.TabIndex = 2;
            this.lblPM_Active.Text = "Active*";
            // 
            // lblGrp_ID
            // 
            this.lblGrp_ID.AutoSize = true;
            this.lblGrp_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrp_ID.ForeColor = System.Drawing.Color.Honeydew;
            this.lblGrp_ID.Location = new System.Drawing.Point(89, 177);
            this.lblGrp_ID.Name = "lblGrp_ID";
            this.lblGrp_ID.Size = new System.Drawing.Size(50, 16);
            this.lblGrp_ID.TabIndex = 1;
            this.lblGrp_ID.Text = "Group*";
            this.lblGrp_ID.Visible = false;
            // 
            // lblPM_Name
            // 
            this.lblPM_Name.AutoSize = true;
            this.lblPM_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPM_Name.ForeColor = System.Drawing.Color.Honeydew;
            this.lblPM_Name.Location = new System.Drawing.Point(89, 61);
            this.lblPM_Name.Name = "lblPM_Name";
            this.lblPM_Name.Size = new System.Drawing.Size(50, 16);
            this.lblPM_Name.TabIndex = 0;
            this.lblPM_Name.Text = "Name*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(197, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Party (Main) Management";
            // 
            // dgwRPeP_MasterPartyMain
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwRPeP_MasterPartyMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwRPeP_MasterPartyMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwRPeP_MasterPartyMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwRPeP_MasterPartyMain.Location = new System.Drawing.Point(105, 423);
            this.dgwRPeP_MasterPartyMain.Name = "dgwRPeP_MasterPartyMain";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwRPeP_MasterPartyMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwRPeP_MasterPartyMain.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwRPeP_MasterPartyMain.Size = new System.Drawing.Size(514, 150);
            this.dgwRPeP_MasterPartyMain.TabIndex = 9;
            this.dgwRPeP_MasterPartyMain.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwRPeP_MasterPartyMain_RowHeaderMouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(157, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name";
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Location = new System.Drawing.Point(208, 394);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(145, 20);
            this.txtNameSearch.TabIndex = 12;
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.cmdSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSearch.Location = new System.Drawing.Point(359, 363);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(50, 51);
            this.cmdSearch.TabIndex = 11;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackgroundImage = global::ePacker1.Properties.Resources.Excel_Icon;
            this.cmdExcelReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExcelReport.Location = new System.Drawing.Point(432, 363);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(50, 48);
            this.cmdExcelReport.TabIndex = 13;
            this.cmdExcelReport.UseVisualStyleBackColor = true;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // RPeP_MasterPartyMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(804, 594);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.txtNameSearch);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgwRPeP_MasterPartyMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_MasterPartyMain";
            this.Text = "RPeP_MasterPartyMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPeP_MasterPartyMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRPeP_MasterPartyMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ddlPM_Active;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.TextBox txtPM_Name;
        private System.Windows.Forms.Label lblPM_Active;
        private System.Windows.Forms.Label lblGrp_ID;
        private System.Windows.Forms.Label lblPM_Name;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgwRPeP_MasterPartyMain;
        private System.Windows.Forms.Label lblName_Desc;
        private System.Windows.Forms.TextBox txtPM_ID;
        private System.Windows.Forms.Label lblName_Descr;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdExcelReport;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}