﻿namespace ePacker1
{
    partial class RPeP_MasterItemStdPaper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterItemStdPaper));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtStdPaper_ID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.ddlStdPaper_Active = new System.Windows.Forms.ComboBox();
            this.txtStdPaper_Width = new System.Windows.Forms.TextBox();
            this.txtStdPaper_Length = new System.Windows.Forms.TextBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGrp_Name_Search = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.dgwItem_StdPaper_Master = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItem_StdPaper_Master)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(92, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(556, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item – Standard Paper Management";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.txtStdPaper_ID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdUpdate);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.ddlStdPaper_Active);
            this.panel1.Controls.Add(this.txtStdPaper_Width);
            this.panel1.Controls.Add(this.txtStdPaper_Length);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Location = new System.Drawing.Point(33, 75);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 452);
            this.panel1.TabIndex = 2;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCancel.BackgroundImage")));
            this.cmdCancel.Location = new System.Drawing.Point(328, 320);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 75);
            this.cmdCancel.TabIndex = 16;
            this.toolTip1.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtStdPaper_ID
            // 
            this.txtStdPaper_ID.Location = new System.Drawing.Point(169, 4);
            this.txtStdPaper_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStdPaper_ID.Name = "txtStdPaper_ID";
            this.txtStdPaper_ID.Size = new System.Drawing.Size(132, 22);
            this.txtStdPaper_ID.TabIndex = 15;
            this.txtStdPaper_ID.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(56, 229);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Active *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(56, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Width *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(56, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Length *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(56, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Group *";
            this.label2.Visible = false;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdUpdate.BackgroundImage")));
            this.cmdUpdate.Location = new System.Drawing.Point(117, 320);
            this.cmdUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(75, 75);
            this.cmdUpdate.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cmdUpdate, "Update");
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.BackgroundImage")));
            this.cmdRefresh.Location = new System.Drawing.Point(220, 320);
            this.cmdRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(75, 75);
            this.cmdRefresh.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cmdRefresh, "Refresh");
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSubmit.BackgroundImage")));
            this.cmdSubmit.Location = new System.Drawing.Point(19, 320);
            this.cmdSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(75, 75);
            this.cmdSubmit.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cmdSubmit, "Submit");
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // ddlStdPaper_Active
            // 
            this.ddlStdPaper_Active.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStdPaper_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlStdPaper_Active.FormattingEnabled = true;
            this.ddlStdPaper_Active.Location = new System.Drawing.Point(169, 228);
            this.ddlStdPaper_Active.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlStdPaper_Active.Name = "ddlStdPaper_Active";
            this.ddlStdPaper_Active.Size = new System.Drawing.Size(193, 30);
            this.ddlStdPaper_Active.TabIndex = 3;
            this.toolTip1.SetToolTip(this.ddlStdPaper_Active, "Select Active");
            // 
            // txtStdPaper_Width
            // 
            this.txtStdPaper_Width.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStdPaper_Width.Location = new System.Drawing.Point(169, 171);
            this.txtStdPaper_Width.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStdPaper_Width.MaxLength = 7;
            this.txtStdPaper_Width.Name = "txtStdPaper_Width";
            this.txtStdPaper_Width.Size = new System.Drawing.Size(193, 28);
            this.txtStdPaper_Width.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtStdPaper_Width, "Insert Width");
            this.txtStdPaper_Width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStdPaper_Width_KeyPress);
            // 
            // txtStdPaper_Length
            // 
            this.txtStdPaper_Length.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStdPaper_Length.Location = new System.Drawing.Point(169, 117);
            this.txtStdPaper_Length.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStdPaper_Length.MaxLength = 7;
            this.txtStdPaper_Length.Name = "txtStdPaper_Length";
            this.txtStdPaper_Length.Size = new System.Drawing.Size(193, 28);
            this.txtStdPaper_Length.TabIndex = 1;
            this.txtStdPaper_Length.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStdPaper_Length_KeyPress);
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(169, 57);
            this.ddlGrp_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(193, 24);
            this.ddlGrp_ID.TabIndex = 0;
            this.toolTip1.SetToolTip(this.ddlGrp_ID, "Select Group Name");
            this.ddlGrp_ID.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(614, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Group *";
            this.label6.Visible = false;
            // 
            // txtGrp_Name_Search
            // 
            this.txtGrp_Name_Search.Location = new System.Drawing.Point(699, 98);
            this.txtGrp_Name_Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGrp_Name_Search.Name = "txtGrp_Name_Search";
            this.txtGrp_Name_Search.Size = new System.Drawing.Size(160, 22);
            this.txtGrp_Name_Search.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtGrp_Name_Search, "Insert Group Name");
            this.txtGrp_Name_Search.Visible = false;
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.cmdSearch.Location = new System.Drawing.Point(883, 60);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(67, 63);
            this.cmdSearch.TabIndex = 13;
            this.toolTip1.SetToolTip(this.cmdSearch, "Search");
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Visible = false;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dgwItem_StdPaper_Master
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwItem_StdPaper_Master.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwItem_StdPaper_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwItem_StdPaper_Master.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwItem_StdPaper_Master.Location = new System.Drawing.Point(534, 193);
            this.dgwItem_StdPaper_Master.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgwItem_StdPaper_Master.Name = "dgwItem_StdPaper_Master";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwItem_StdPaper_Master.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwItem_StdPaper_Master.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwItem_StdPaper_Master.Size = new System.Drawing.Size(920, 334);
            this.dgwItem_StdPaper_Master.TabIndex = 14;
            this.dgwItem_StdPaper_Master.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwItem_StdPaper_Master_RowHeaderMouseClick);
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdExcelReport.BackgroundImage")));
            this.cmdExcelReport.Location = new System.Drawing.Point(999, 100);
            this.cmdExcelReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(75, 75);
            this.cmdExcelReport.TabIndex = 15;
            this.cmdExcelReport.UseVisualStyleBackColor = true;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // RPeP_MasterItemStdPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(200, 200);
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1747, 711);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.dgwItem_StdPaper_Master);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtGrp_Name_Search);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RPeP_MasterItemStdPaper";
            this.Text = "RPeP_MasterItemStdPaper";
            this.Load += new System.EventHandler(this.RPeP_MasterItemStdPaper_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItem_StdPaper_Master)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.ComboBox ddlStdPaper_Active;
        private System.Windows.Forms.TextBox txtStdPaper_Width;
        private System.Windows.Forms.TextBox txtStdPaper_Length;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGrp_Name_Search;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.DataGridView dgwItem_StdPaper_Master;
        private System.Windows.Forms.TextBox txtStdPaper_ID;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdExcelReport;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}