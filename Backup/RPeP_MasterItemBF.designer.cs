namespace ePacker1
{
    partial class RPeP_MasterItemBF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterItemBF));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.ddlBF_Active = new System.Windows.Forms.ComboBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.txtBF_Value = new System.Windows.Forms.TextBox();
            this.txtBF_ID = new System.Windows.Forms.TextBox();
            this.lblBF_Active = new System.Windows.Forms.Label();
            this.lblBF_Value = new System.Windows.Forms.Label();
            this.lblGrp_ID = new System.Windows.Forms.Label();
            this.lbltxtGrp_Name_Search = new System.Windows.Forms.Label();
            this.txtGrp_Name_Search = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.dgwItem_BF_Master = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItem_BF_Master)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(230, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item - BF Management";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.ddlBF_Active);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.txtBF_Value);
            this.panel1.Controls.Add(this.txtBF_ID);
            this.panel1.Controls.Add(this.lblBF_Active);
            this.panel1.Controls.Add(this.lblBF_Value);
            this.panel1.Controls.Add(this.lblGrp_ID);
            this.panel1.Location = new System.Drawing.Point(180, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 220);
            this.panel1.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.Location = new System.Drawing.Point(308, 148);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 48);
            this.cmdCancel.TabIndex = 13;
            this.toolTip1.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdEdit.Location = new System.Drawing.Point(252, 148);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(50, 48);
            this.cmdEdit.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cmdEdit, "Edit");
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdReset.Location = new System.Drawing.Point(196, 148);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(50, 48);
            this.cmdReset.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cmdReset, "Reset");
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.Location = new System.Drawing.Point(140, 148);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 48);
            this.cmdSubmit.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmdSubmit, "Submit");
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // ddlBF_Active
            // 
            this.ddlBF_Active.FormattingEnabled = true;
            this.ddlBF_Active.Location = new System.Drawing.Point(90, 92);
            this.ddlBF_Active.Name = "ddlBF_Active";
            this.ddlBF_Active.Size = new System.Drawing.Size(100, 21);
            this.ddlBF_Active.TabIndex = 9;
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(265, 32);
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(100, 21);
            this.ddlGrp_ID.TabIndex = 1;
            this.toolTip1.SetToolTip(this.ddlGrp_ID, "Select Group Name");
            this.ddlGrp_ID.Visible = false;
            // 
            // txtBF_Value
            // 
            this.txtBF_Value.Location = new System.Drawing.Point(90, 55);
            this.txtBF_Value.MaxLength = 7;
            this.txtBF_Value.Name = "txtBF_Value";
            this.txtBF_Value.Size = new System.Drawing.Size(100, 20);
            this.txtBF_Value.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtBF_Value, "Enter Value");
            this.txtBF_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBF_Value_KeyPress);
            // 
            // txtBF_ID
            // 
            this.txtBF_ID.Location = new System.Drawing.Point(90, 29);
            this.txtBF_ID.Name = "txtBF_ID";
            this.txtBF_ID.Size = new System.Drawing.Size(100, 20);
            this.txtBF_ID.TabIndex = 6;
            // 
            // lblBF_Active
            // 
            this.lblBF_Active.AutoSize = true;
            this.lblBF_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBF_Active.ForeColor = System.Drawing.Color.Honeydew;
            this.lblBF_Active.Location = new System.Drawing.Point(21, 93);
            this.lblBF_Active.Name = "lblBF_Active";
            this.lblBF_Active.Size = new System.Drawing.Size(53, 16);
            this.lblBF_Active.TabIndex = 5;
            this.lblBF_Active.Text = "Active *";
            // 
            // lblBF_Value
            // 
            this.lblBF_Value.AutoSize = true;
            this.lblBF_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBF_Value.ForeColor = System.Drawing.Color.Honeydew;
            this.lblBF_Value.Location = new System.Drawing.Point(21, 56);
            this.lblBF_Value.Name = "lblBF_Value";
            this.lblBF_Value.Size = new System.Drawing.Size(51, 16);
            this.lblBF_Value.TabIndex = 4;
            this.lblBF_Value.Text = "Value *";
            // 
            // lblGrp_ID
            // 
            this.lblGrp_ID.AutoSize = true;
            this.lblGrp_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrp_ID.ForeColor = System.Drawing.Color.Honeydew;
            this.lblGrp_ID.Location = new System.Drawing.Point(196, 33);
            this.lblGrp_ID.Name = "lblGrp_ID";
            this.lblGrp_ID.Size = new System.Drawing.Size(53, 16);
            this.lblGrp_ID.TabIndex = 3;
            this.lblGrp_ID.Text = "Group *";
            this.lblGrp_ID.Visible = false;
            // 
            // lbltxtGrp_Name_Search
            // 
            this.lbltxtGrp_Name_Search.AutoSize = true;
            this.lbltxtGrp_Name_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltxtGrp_Name_Search.ForeColor = System.Drawing.Color.Honeydew;
            this.lbltxtGrp_Name_Search.Location = new System.Drawing.Point(202, 334);
            this.lbltxtGrp_Name_Search.Name = "lbltxtGrp_Name_Search";
            this.lbltxtGrp_Name_Search.Size = new System.Drawing.Size(53, 16);
            this.lbltxtGrp_Name_Search.TabIndex = 13;
            this.lbltxtGrp_Name_Search.Text = "Group *";
            // 
            // txtGrp_Name_Search
            // 
            this.txtGrp_Name_Search.Location = new System.Drawing.Point(271, 333);
            this.txtGrp_Name_Search.Name = "txtGrp_Name_Search";
            this.txtGrp_Name_Search.Size = new System.Drawing.Size(100, 20);
            this.txtGrp_Name_Search.TabIndex = 13;
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.cmdSearch.Location = new System.Drawing.Point(377, 305);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(50, 48);
            this.cmdSearch.TabIndex = 14;
            this.toolTip1.SetToolTip(this.cmdSearch, "Search");
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dgwItem_BF_Master
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwItem_BF_Master.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwItem_BF_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwItem_BF_Master.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwItem_BF_Master.Location = new System.Drawing.Point(180, 368);
            this.dgwItem_BF_Master.Name = "dgwItem_BF_Master";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwItem_BF_Master.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwItem_BF_Master.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwItem_BF_Master.Size = new System.Drawing.Size(381, 98);
            this.dgwItem_BF_Master.TabIndex = 15;
            this.dgwItem_BF_Master.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwItem_BF_Master_RowHeaderMouseClick);
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackColor = System.Drawing.Color.Black;
            this.cmdExcelReport.BackgroundImage = global::ePacker1.Properties.Resources.Excel_Icon;
            this.cmdExcelReport.Location = new System.Drawing.Point(433, 305);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(50, 45);
            this.cmdExcelReport.TabIndex = 16;
            this.cmdExcelReport.UseVisualStyleBackColor = false;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // RPeP_MasterItemBF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.dgwItem_BF_Master);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtGrp_Name_Search);
            this.Controls.Add(this.lbltxtGrp_Name_Search);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_MasterItemBF";
            this.Text = "RPeP_MasterItemBF";
            this.Load += new System.EventHandler(this.RPeP_MasterItemBF_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItem_BF_Master)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBF_Value;
        private System.Windows.Forms.Label lblGrp_ID;
        private System.Windows.Forms.ComboBox ddlBF_Active;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.TextBox txtBF_Value;
        private System.Windows.Forms.TextBox txtBF_ID;
        private System.Windows.Forms.Label lblBF_Active;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Label lbltxtGrp_Name_Search;
        private System.Windows.Forms.TextBox txtGrp_Name_Search;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.DataGridView dgwItem_BF_Master;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button cmdExcelReport;
    }
}