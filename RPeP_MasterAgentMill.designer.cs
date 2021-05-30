namespace ePacker1
{
    partial class RPeP_MasterAgentMill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterAgentMill));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdMillSearch = new System.Windows.Forms.Button();
            this.cmdAgentSearch = new System.Windows.Forms.Button();
            this.txtMill_Search = new System.Windows.Forms.TextBox();
            this.txtAgent_Search = new System.Windows.Forms.TextBox();
            this.ddlA_Active = new System.Windows.Forms.ComboBox();
            this.ddlM_ID = new System.Windows.Forms.ComboBox();
            this.ddlA_ID = new System.Windows.Forms.ComboBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtA_Name_Search = new System.Windows.Forms.TextBox();
            this.dgwAgentMill_Link = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAgentMill_Link)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(449, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agent Mill Link Management";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(19, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Group *";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(7, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Agent *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(7, 185);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mill *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(7, 254);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 24);
            this.label5.TabIndex = 40;
            this.label5.Text = "Active *";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdMillSearch);
            this.panel1.Controls.Add(this.cmdAgentSearch);
            this.panel1.Controls.Add(this.txtMill_Search);
            this.panel1.Controls.Add(this.txtAgent_Search);
            this.panel1.Controls.Add(this.ddlA_Active);
            this.panel1.Controls.Add(this.ddlM_ID);
            this.panel1.Controls.Add(this.ddlA_ID);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(39, 92);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 372);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmdMillSearch
            // 
            this.cmdMillSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search1;
            this.cmdMillSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdMillSearch.Location = new System.Drawing.Point(629, 165);
            this.cmdMillSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cmdMillSearch.Name = "cmdMillSearch";
            this.cmdMillSearch.Size = new System.Drawing.Size(70, 75);
            this.cmdMillSearch.TabIndex = 9;
            this.toolTip1.SetToolTip(this.cmdMillSearch, "Search Mill");
            this.cmdMillSearch.UseVisualStyleBackColor = true;
            this.cmdMillSearch.Click += new System.EventHandler(this.cmdMillSearch_Click);
            // 
            // cmdAgentSearch
            // 
            this.cmdAgentSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search1;
            this.cmdAgentSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdAgentSearch.Location = new System.Drawing.Point(629, 91);
            this.cmdAgentSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAgentSearch.Name = "cmdAgentSearch";
            this.cmdAgentSearch.Size = new System.Drawing.Size(70, 75);
            this.cmdAgentSearch.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cmdAgentSearch, "Search Agent");
            this.cmdAgentSearch.UseVisualStyleBackColor = true;
            this.cmdAgentSearch.Click += new System.EventHandler(this.cmdAgentSearch_Click);
            // 
            // txtMill_Search
            // 
            this.txtMill_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMill_Search.Location = new System.Drawing.Point(406, 185);
            this.txtMill_Search.Margin = new System.Windows.Forms.Padding(4);
            this.txtMill_Search.Name = "txtMill_Search";
            this.txtMill_Search.Size = new System.Drawing.Size(197, 28);
            this.txtMill_Search.TabIndex = 8;
            // 
            // txtAgent_Search
            // 
            this.txtAgent_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgent_Search.Location = new System.Drawing.Point(406, 110);
            this.txtAgent_Search.Margin = new System.Windows.Forms.Padding(4);
            this.txtAgent_Search.Name = "txtAgent_Search";
            this.txtAgent_Search.Size = new System.Drawing.Size(197, 28);
            this.txtAgent_Search.TabIndex = 5;
            this.txtAgent_Search.TextChanged += new System.EventHandler(this.txtAgent_Search_TextChanged);
            // 
            // ddlA_Active
            // 
            this.ddlA_Active.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlA_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlA_Active.FormattingEnabled = true;
            this.ddlA_Active.Location = new System.Drawing.Point(101, 252);
            this.ddlA_Active.Margin = new System.Windows.Forms.Padding(4);
            this.ddlA_Active.MaxLength = 5;
            this.ddlA_Active.Name = "ddlA_Active";
            this.ddlA_Active.Size = new System.Drawing.Size(281, 30);
            this.ddlA_Active.TabIndex = 11;
            this.toolTip1.SetToolTip(this.ddlA_Active, "Select Agent");
            // 
            // ddlM_ID
            // 
            this.ddlM_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlM_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlM_ID.FormattingEnabled = true;
            this.ddlM_ID.Location = new System.Drawing.Point(101, 183);
            this.ddlM_ID.Margin = new System.Windows.Forms.Padding(4);
            this.ddlM_ID.MaxLength = 5;
            this.ddlM_ID.Name = "ddlM_ID";
            this.ddlM_ID.Size = new System.Drawing.Size(281, 30);
            this.ddlM_ID.TabIndex = 10;
            this.toolTip1.SetToolTip(this.ddlM_ID, "Select MillMaster");
            // 
            // ddlA_ID
            // 
            this.ddlA_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlA_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlA_ID.FormattingEnabled = true;
            this.ddlA_ID.Location = new System.Drawing.Point(101, 110);
            this.ddlA_ID.Margin = new System.Windows.Forms.Padding(4);
            this.ddlA_ID.MaxLength = 5;
            this.ddlA_ID.Name = "ddlA_ID";
            this.ddlA_ID.Size = new System.Drawing.Size(281, 30);
            this.ddlA_ID.TabIndex = 7;
            this.toolTip1.SetToolTip(this.ddlA_ID, "Select Agent Name");
            this.ddlA_ID.SelectedIndexChanged += new System.EventHandler(this.ddlA_ID_SelectedIndexChanged);
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(113, 37);
            this.ddlGrp_ID.Margin = new System.Windows.Forms.Padding(4);
            this.ddlGrp_ID.MaxLength = 5;
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(281, 24);
            this.ddlGrp_ID.TabIndex = 4;
            this.toolTip1.SetToolTip(this.ddlGrp_ID, "Select Group Name");
            this.ddlGrp_ID.Visible = false;
            this.ddlGrp_ID.SelectedValueChanged += new System.EventHandler(this.ddlGrp_ID_SelectedValueChanged);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCancel.BackgroundImage")));
            this.cmdCancel.Location = new System.Drawing.Point(587, 485);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(70, 75);
            this.cmdCancel.TabIndex = 41;
            this.toolTip1.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdReset.BackgroundImage")));
            this.cmdReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReset.Location = new System.Drawing.Point(352, 485);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(4);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(70, 75);
            this.cmdReset.TabIndex = 13;
            this.toolTip1.SetToolTip(this.cmdReset, "Reset");
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSubmit.BackgroundImage")));
            this.cmdSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSubmit.Location = new System.Drawing.Point(235, 485);
            this.cmdSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(70, 75);
            this.cmdSubmit.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cmdSubmit, "Submit");
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(864, 115);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 24);
            this.label6.TabIndex = 7;
            this.label6.Text = "Agent *";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtA_Name_Search
            // 
            this.txtA_Name_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA_Name_Search.Location = new System.Drawing.Point(940, 113);
            this.txtA_Name_Search.Margin = new System.Windows.Forms.Padding(4);
            this.txtA_Name_Search.Name = "txtA_Name_Search";
            this.txtA_Name_Search.Size = new System.Drawing.Size(208, 28);
            this.txtA_Name_Search.TabIndex = 8;
            // 
            // dgwAgentMill_Link
            // 
            this.dgwAgentMill_Link.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwAgentMill_Link.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwAgentMill_Link.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwAgentMill_Link.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwAgentMill_Link.Location = new System.Drawing.Point(804, 161);
            this.dgwAgentMill_Link.Margin = new System.Windows.Forms.Padding(4);
            this.dgwAgentMill_Link.Name = "dgwAgentMill_Link";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwAgentMill_Link.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwAgentMill_Link.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwAgentMill_Link.Size = new System.Drawing.Size(823, 303);
            this.dgwAgentMill_Link.TabIndex = 9;
            this.dgwAgentMill_Link.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAgentMill_Link_CellContentClick);
            this.dgwAgentMill_Link.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwAgentMill_Link_RowHeaderMouseClick);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(467, 485);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 70);
            this.btnDelete.TabIndex = 88;
            this.toolTip1.SetToolTip(this.btnDelete, "Delete");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSearch.BackgroundImage")));
            this.cmdSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdSearch.Location = new System.Drawing.Point(1156, 79);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(70, 75);
            this.cmdSearch.TabIndex = 6;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdExcelReport.BackgroundImage")));
            this.cmdExcelReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExcelReport.Location = new System.Drawing.Point(1251, 79);
            this.cmdExcelReport.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(70, 75);
            this.cmdExcelReport.TabIndex = 10;
            this.cmdExcelReport.UseVisualStyleBackColor = true;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // RPeP_MasterAgentMill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1776, 711);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.dgwAgentMill_Link);
            this.Controls.Add(this.txtA_Name_Search);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RPeP_MasterAgentMill";
            this.Text = "RPeP_MasterAgentMill";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPeP_MasterAgentMill_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAgentMill_Link)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ddlA_Active;
        private System.Windows.Forms.ComboBox ddlM_ID;
        private System.Windows.Forms.ComboBox ddlA_ID;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtA_Name_Search;
        private System.Windows.Forms.DataGridView dgwAgentMill_Link;
        private System.Windows.Forms.TextBox txtMill_Search;
        private System.Windows.Forms.TextBox txtAgent_Search;
        private System.Windows.Forms.Button cmdMillSearch;
        private System.Windows.Forms.Button cmdAgentSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdExcelReport;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}