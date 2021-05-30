namespace ePacker1
{
    partial class RPeP_MasterRegion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterRegion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtRg_ID = new System.Windows.Forms.TextBox();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.txtRg_Name = new System.Windows.Forms.TextBox();
            this.ddlRg_Active = new System.Windows.Forms.ComboBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.lblRg_Active = new System.Windows.Forms.Label();
            this.lblRg_Name = new System.Windows.Forms.Label();
            this.lblGroup_ID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.txtRg_Name_Search = new System.Windows.Forms.TextBox();
            this.dgwMasterRegion = new System.Windows.Forms.DataGridView();
            this.cmdRg_Name_Search = new System.Windows.Forms.Button();
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMasterRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.txtRg_ID);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.txtRg_Name);
            this.panel1.Controls.Add(this.ddlRg_Active);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.lblRg_Active);
            this.panel1.Controls.Add(this.lblRg_Name);
            this.panel1.Controls.Add(this.lblGroup_ID);
            this.panel1.Location = new System.Drawing.Point(61, 106);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 343);
            this.panel1.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCancel.BackgroundImage")));
            this.cmdCancel.Location = new System.Drawing.Point(376, 257);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(70, 75);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtRg_ID
            // 
            this.txtRg_ID.Location = new System.Drawing.Point(175, 17);
            this.txtRg_ID.Margin = new System.Windows.Forms.Padding(4);
            this.txtRg_ID.Name = "txtRg_ID";
            this.txtRg_ID.Size = new System.Drawing.Size(132, 22);
            this.txtRg_ID.TabIndex = 12;
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdEdit.BackgroundImage")));
            this.cmdEdit.Location = new System.Drawing.Point(125, 257);
            this.cmdEdit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(70, 75);
            this.cmdEdit.TabIndex = 11;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdReset.BackgroundImage")));
            this.cmdReset.Location = new System.Drawing.Point(290, 257);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(4);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(70, 75);
            this.cmdReset.TabIndex = 7;
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSubmit.BackgroundImage")));
            this.cmdSubmit.Location = new System.Drawing.Point(37, 257);
            this.cmdSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(70, 75);
            this.cmdSubmit.TabIndex = 4;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // txtRg_Name
            // 
            this.txtRg_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRg_Name.Location = new System.Drawing.Point(175, 128);
            this.txtRg_Name.Margin = new System.Windows.Forms.Padding(4);
            this.txtRg_Name.Name = "txtRg_Name";
            this.txtRg_Name.Size = new System.Drawing.Size(271, 28);
            this.txtRg_Name.TabIndex = 2;
            this.txtRg_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRg_Name_KeyPress);
            // 
            // ddlRg_Active
            // 
            this.ddlRg_Active.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRg_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlRg_Active.FormattingEnabled = true;
            this.ddlRg_Active.Location = new System.Drawing.Point(175, 180);
            this.ddlRg_Active.Margin = new System.Windows.Forms.Padding(4);
            this.ddlRg_Active.Name = "ddlRg_Active";
            this.ddlRg_Active.Size = new System.Drawing.Size(271, 30);
            this.ddlRg_Active.TabIndex = 3;
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(175, 71);
            this.ddlGrp_ID.Margin = new System.Windows.Forms.Padding(4);
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(271, 30);
            this.ddlGrp_ID.TabIndex = 1;
            this.ddlGrp_ID.Visible = false;
            // 
            // lblRg_Active
            // 
            this.lblRg_Active.AutoSize = true;
            this.lblRg_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRg_Active.ForeColor = System.Drawing.Color.Honeydew;
            this.lblRg_Active.Location = new System.Drawing.Point(33, 181);
            this.lblRg_Active.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRg_Active.Name = "lblRg_Active";
            this.lblRg_Active.Size = new System.Drawing.Size(73, 24);
            this.lblRg_Active.TabIndex = 12;
            this.lblRg_Active.Text = "Active *";
            // 
            // lblRg_Name
            // 
            this.lblRg_Name.AutoSize = true;
            this.lblRg_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRg_Name.ForeColor = System.Drawing.Color.Honeydew;
            this.lblRg_Name.Location = new System.Drawing.Point(33, 129);
            this.lblRg_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRg_Name.Name = "lblRg_Name";
            this.lblRg_Name.Size = new System.Drawing.Size(139, 24);
            this.lblRg_Name.TabIndex = 11;
            this.lblRg_Name.Text = "Region Name *";
            // 
            // lblGroup_ID
            // 
            this.lblGroup_ID.AutoSize = true;
            this.lblGroup_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup_ID.ForeColor = System.Drawing.Color.Honeydew;
            this.lblGroup_ID.Location = new System.Drawing.Point(33, 73);
            this.lblGroup_ID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroup_ID.Name = "lblGroup_ID";
            this.lblGroup_ID.Size = new System.Drawing.Size(75, 24);
            this.lblGroup_ID.TabIndex = 0;
            this.lblGroup_ID.Text = "Group *";
            this.lblGroup_ID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(445, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Region Management";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Honeydew;
            this.lbl.Location = new System.Drawing.Point(644, 126);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(83, 24);
            this.lbl.TabIndex = 8;
            this.lbl.Text = "Region *";
            // 
            // txtRg_Name_Search
            // 
            this.txtRg_Name_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRg_Name_Search.Location = new System.Drawing.Point(748, 125);
            this.txtRg_Name_Search.Margin = new System.Windows.Forms.Padding(4);
            this.txtRg_Name_Search.Name = "txtRg_Name_Search";
            this.txtRg_Name_Search.Size = new System.Drawing.Size(183, 28);
            this.txtRg_Name_Search.TabIndex = 9;
            // 
            // dgwMasterRegion
            // 
            this.dgwMasterRegion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMasterRegion.Location = new System.Drawing.Point(648, 178);
            this.dgwMasterRegion.Margin = new System.Windows.Forms.Padding(4);
            this.dgwMasterRegion.Name = "dgwMasterRegion";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwMasterRegion.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgwMasterRegion.Size = new System.Drawing.Size(773, 362);
            this.dgwMasterRegion.TabIndex = 10;
            this.dgwMasterRegion.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwMasterRegion_RowHeaderMouseClick);
            // 
            // cmdRg_Name_Search
            // 
            this.cmdRg_Name_Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdRg_Name_Search.BackgroundImage")));
            this.cmdRg_Name_Search.Location = new System.Drawing.Point(953, 86);
            this.cmdRg_Name_Search.Margin = new System.Windows.Forms.Padding(4);
            this.cmdRg_Name_Search.Name = "cmdRg_Name_Search";
            this.cmdRg_Name_Search.Size = new System.Drawing.Size(70, 75);
            this.cmdRg_Name_Search.TabIndex = 8;
            this.cmdRg_Name_Search.UseVisualStyleBackColor = true;
            this.cmdRg_Name_Search.Click += new System.EventHandler(this.cmdRg_Name_Search_Click);
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdExcelReport.BackgroundImage")));
            this.cmdExcelReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExcelReport.Location = new System.Drawing.Point(1053, 86);
            this.cmdExcelReport.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(70, 75);
            this.cmdExcelReport.TabIndex = 11;
            this.cmdExcelReport.UseVisualStyleBackColor = true;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(203, 257);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 75);
            this.btnDelete.TabIndex = 89;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // RPeP_MasterRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1482, 711);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.dgwMasterRegion);
            this.Controls.Add(this.cmdRg_Name_Search);
            this.Controls.Add(this.txtRg_Name_Search);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RPeP_MasterRegion";
            this.Text = "RPeP_MasterRegion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPeP_MasterRegion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMasterRegion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRg_Active;
        private System.Windows.Forms.Label lblRg_Name;
        private System.Windows.Forms.Label lblGroup_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.TextBox txtRg_Name;
        private System.Windows.Forms.ComboBox ddlRg_Active;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtRg_Name_Search;
        private System.Windows.Forms.Button cmdRg_Name_Search;
        private System.Windows.Forms.DataGridView dgwMasterRegion;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.TextBox txtRg_ID;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdExcelReport;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button btnDelete;
    }
}