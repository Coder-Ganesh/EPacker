namespace ePacker1
{
    partial class RPeP_MasterItemPunchMach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterItemPunchMach));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtPunchMach_ID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.ddlPunchMach_Active = new System.Windows.Forms.ComboBox();
            this.txtPunchMach_Rate = new System.Windows.Forms.TextBox();
            this.txtPunchMach_Size = new System.Windows.Forms.TextBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGrp_Name_Search = new System.Windows.Forms.TextBox();
            this.dgwItem_PunchMach_Master = new System.Windows.Forms.DataGridView();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItem_PunchMach_Master)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(95, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(599, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item – Punching Machine Management";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.txtPunchMach_ID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdUpdate);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.ddlPunchMach_Active);
            this.panel1.Controls.Add(this.txtPunchMach_Rate);
            this.panel1.Controls.Add(this.txtPunchMach_Size);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Location = new System.Drawing.Point(44, 70);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 438);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCancel.BackgroundImage")));
            this.cmdCancel.Location = new System.Drawing.Point(344, 314);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 75);
            this.cmdCancel.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtPunchMach_ID
            // 
            this.txtPunchMach_ID.Location = new System.Drawing.Point(211, 17);
            this.txtPunchMach_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPunchMach_ID.Name = "txtPunchMach_ID";
            this.txtPunchMach_ID.Size = new System.Drawing.Size(132, 22);
            this.txtPunchMach_ID.TabIndex = 11;
            this.txtPunchMach_ID.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(4, 190);
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
            this.label4.Location = new System.Drawing.Point(4, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Punching Rate *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(4, 86);
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
            this.label2.Location = new System.Drawing.Point(15, 5);
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
            this.cmdUpdate.Location = new System.Drawing.Point(119, 314);
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
            this.cmdRefresh.Location = new System.Drawing.Point(231, 314);
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
            this.cmdSubmit.Location = new System.Drawing.Point(8, 314);
            this.cmdSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(75, 75);
            this.cmdSubmit.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cmdSubmit, "Submit");
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // ddlPunchMach_Active
            // 
            this.ddlPunchMach_Active.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPunchMach_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPunchMach_Active.FormattingEnabled = true;
            this.ddlPunchMach_Active.Location = new System.Drawing.Point(159, 189);
            this.ddlPunchMach_Active.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlPunchMach_Active.Name = "ddlPunchMach_Active";
            this.ddlPunchMach_Active.Size = new System.Drawing.Size(260, 30);
            this.ddlPunchMach_Active.TabIndex = 3;
            this.toolTip1.SetToolTip(this.ddlPunchMach_Active, "Select Active");
            // 
            // txtPunchMach_Rate
            // 
            this.txtPunchMach_Rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPunchMach_Rate.Location = new System.Drawing.Point(159, 140);
            this.txtPunchMach_Rate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPunchMach_Rate.Name = "txtPunchMach_Rate";
            this.txtPunchMach_Rate.Size = new System.Drawing.Size(260, 28);
            this.txtPunchMach_Rate.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtPunchMach_Rate, "Insert Amount");
            this.txtPunchMach_Rate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPunchMach_Rate_KeyPress);
            // 
            // txtPunchMach_Size
            // 
            this.txtPunchMach_Size.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPunchMach_Size.Location = new System.Drawing.Point(159, 85);
            this.txtPunchMach_Size.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPunchMach_Size.Name = "txtPunchMach_Size";
            this.txtPunchMach_Size.Size = new System.Drawing.Size(260, 28);
            this.txtPunchMach_Size.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtPunchMach_Size, "Insert Size");
            this.txtPunchMach_Size.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPunchMach_Size_KeyPress);
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(170, 4);
            this.ddlGrp_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(160, 24);
            this.ddlGrp_ID.TabIndex = 0;
            this.toolTip1.SetToolTip(this.ddlGrp_ID, "Select Group");
            this.ddlGrp_ID.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(911, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Group *";
            this.label6.Visible = false;
            // 
            // txtGrp_Name_Search
            // 
            this.txtGrp_Name_Search.Location = new System.Drawing.Point(999, 117);
            this.txtGrp_Name_Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGrp_Name_Search.Name = "txtGrp_Name_Search";
            this.txtGrp_Name_Search.Size = new System.Drawing.Size(160, 22);
            this.txtGrp_Name_Search.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtGrp_Name_Search, "Enter Name");
            this.txtGrp_Name_Search.Visible = false;
            // 
            // dgwItem_PunchMach_Master
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwItem_PunchMach_Master.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgwItem_PunchMach_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwItem_PunchMach_Master.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgwItem_PunchMach_Master.Location = new System.Drawing.Point(523, 156);
            this.dgwItem_PunchMach_Master.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgwItem_PunchMach_Master.Name = "dgwItem_PunchMach_Master";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwItem_PunchMach_Master.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwItem_PunchMach_Master.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgwItem_PunchMach_Master.Size = new System.Drawing.Size(823, 352);
            this.dgwItem_PunchMach_Master.TabIndex = 13;
            this.dgwItem_PunchMach_Master.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwItem_PunchMach_Master_RowHeaderMouseClick);
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.cmdSearch.Location = new System.Drawing.Point(1180, 78);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(67, 63);
            this.cmdSearch.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cmdSearch, "Search");
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Visible = false;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdExcelReport.BackgroundImage")));
            this.cmdExcelReport.Location = new System.Drawing.Point(1271, 75);
            this.cmdExcelReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(75, 75);
            this.cmdExcelReport.TabIndex = 14;
            this.cmdExcelReport.UseVisualStyleBackColor = true;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // RPeP_MasterItemPunchMach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(200, 200);
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1756, 711);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.dgwItem_PunchMach_Master);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtGrp_Name_Search);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RPeP_MasterItemPunchMach";
            this.Text = "RPeP_MasterItemPunchMach";
            this.Load += new System.EventHandler(this.RPeP_MasterItemPunchMach_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItem_PunchMach_Master)).EndInit();
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
        private System.Windows.Forms.ComboBox ddlPunchMach_Active;
        private System.Windows.Forms.TextBox txtPunchMach_Rate;
        private System.Windows.Forms.TextBox txtPunchMach_Size;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGrp_Name_Search;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.DataGridView dgwItem_PunchMach_Master;
        private System.Windows.Forms.TextBox txtPunchMach_ID;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button cmdExcelReport;
    }
}