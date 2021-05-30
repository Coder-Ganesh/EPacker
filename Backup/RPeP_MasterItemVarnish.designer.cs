namespace ePacker1
{
    partial class RPeP_MasterItemVarnish
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterItemVarnish));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtVarnish_ID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.txtarnish_AddnlIn = new System.Windows.Forms.TextBox();
            this.txtVarnish_100In = new System.Windows.Forms.TextBox();
            this.txtVarnish_Type = new System.Windows.Forms.TextBox();
            this.ddlVarnish_Active = new System.Windows.Forms.ComboBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGrp_Name_Search = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.dgwItem_Varnish_Master = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItem_Varnish_Master)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(171, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item - Varnish Management";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.txtVarnish_ID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.txtarnish_AddnlIn);
            this.panel1.Controls.Add(this.txtVarnish_100In);
            this.panel1.Controls.Add(this.txtVarnish_Type);
            this.panel1.Controls.Add(this.ddlVarnish_Active);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Location = new System.Drawing.Point(24, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 349);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdCancel.Location = new System.Drawing.Point(498, 279);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 14;
            this.toolTip1.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtVarnish_ID
            // 
            this.txtVarnish_ID.Location = new System.Drawing.Point(163, 3);
            this.txtVarnish_ID.Name = "txtVarnish_ID";
            this.txtVarnish_ID.Size = new System.Drawing.Size(100, 20);
            this.txtVarnish_ID.TabIndex = 13;
            this.txtVarnish_ID.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(44, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Active *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(44, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Additional Inch *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(44, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "First 100 Inches *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(44, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Type *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(44, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Group *";
            this.label2.Visible = false;
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdEdit.Location = new System.Drawing.Point(442, 279);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(50, 51);
            this.cmdEdit.TabIndex = 7;
            this.toolTip1.SetToolTip(this.cmdEdit, "Update");
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdReset.Location = new System.Drawing.Point(385, 279);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(50, 51);
            this.cmdReset.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cmdReset, "Refresh");
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSubmit.Location = new System.Drawing.Point(329, 279);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cmdSubmit, "Submit");
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // txtarnish_AddnlIn
            // 
            this.txtarnish_AddnlIn.Location = new System.Drawing.Point(163, 177);
            this.txtarnish_AddnlIn.Name = "txtarnish_AddnlIn";
            this.txtarnish_AddnlIn.Size = new System.Drawing.Size(100, 20);
            this.txtarnish_AddnlIn.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtarnish_AddnlIn, "Insert Inches");
            this.txtarnish_AddnlIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtarnish_AddnlIn_KeyPress);
            // 
            // txtVarnish_100In
            // 
            this.txtVarnish_100In.Location = new System.Drawing.Point(163, 133);
            this.txtVarnish_100In.Name = "txtVarnish_100In";
            this.txtVarnish_100In.Size = new System.Drawing.Size(100, 20);
            this.txtVarnish_100In.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtVarnish_100In, "Insert Inches");
            this.txtVarnish_100In.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVarnish_100In_KeyPress);
            // 
            // txtVarnish_Type
            // 
            this.txtVarnish_Type.Location = new System.Drawing.Point(163, 87);
            this.txtVarnish_Type.Name = "txtVarnish_Type";
            this.txtVarnish_Type.Size = new System.Drawing.Size(100, 20);
            this.txtVarnish_Type.TabIndex = 1;
            this.txtVarnish_Type.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVarnish_Type_KeyPress);
            // 
            // ddlVarnish_Active
            // 
            this.ddlVarnish_Active.FormattingEnabled = true;
            this.ddlVarnish_Active.Location = new System.Drawing.Point(163, 219);
            this.ddlVarnish_Active.Name = "ddlVarnish_Active";
            this.ddlVarnish_Active.Size = new System.Drawing.Size(121, 21);
            this.ddlVarnish_Active.TabIndex = 4;
            this.toolTip1.SetToolTip(this.ddlVarnish_Active, "Select Active");
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(163, 43);
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(121, 21);
            this.ddlGrp_ID.TabIndex = 0;
            this.toolTip1.SetToolTip(this.ddlGrp_ID, "Select Group");
            this.ddlGrp_ID.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Honeydew;
            this.label7.Location = new System.Drawing.Point(111, 459);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Group *";
            // 
            // txtGrp_Name_Search
            // 
            this.txtGrp_Name_Search.Location = new System.Drawing.Point(170, 458);
            this.txtGrp_Name_Search.Name = "txtGrp_Name_Search";
            this.txtGrp_Name_Search.Size = new System.Drawing.Size(100, 20);
            this.txtGrp_Name_Search.TabIndex = 14;
            this.toolTip1.SetToolTip(this.txtGrp_Name_Search, "Insert Group");
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.cmdSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSearch.Location = new System.Drawing.Point(285, 427);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(50, 51);
            this.cmdSearch.TabIndex = 15;
            this.toolTip1.SetToolTip(this.cmdSearch, "Search");
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dgwItem_Varnish_Master
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwItem_Varnish_Master.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwItem_Varnish_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwItem_Varnish_Master.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwItem_Varnish_Master.Location = new System.Drawing.Point(24, 496);
            this.dgwItem_Varnish_Master.Name = "dgwItem_Varnish_Master";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwItem_Varnish_Master.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwItem_Varnish_Master.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwItem_Varnish_Master.Size = new System.Drawing.Size(574, 113);
            this.dgwItem_Varnish_Master.TabIndex = 16;
            this.dgwItem_Varnish_Master.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwItem_Varnish_Master_RowHeaderMouseClick);
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackgroundImage = global::ePacker1.Properties.Resources.Excel_Icon;
            this.cmdExcelReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExcelReport.Location = new System.Drawing.Point(363, 427);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(52, 51);
            this.cmdExcelReport.TabIndex = 17;
            this.cmdExcelReport.UseVisualStyleBackColor = true;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // RPeP_MasterItemVarnish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(200, 200);
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(781, 578);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.dgwItem_Varnish_Master);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtGrp_Name_Search);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_MasterItemVarnish";
            this.Text = "RPeP_MasterItemVarnish";
            this.Load += new System.EventHandler(this.RPeP_MasterItemVarnish_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItem_Varnish_Master)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.TextBox txtarnish_AddnlIn;
        private System.Windows.Forms.TextBox txtVarnish_100In;
        private System.Windows.Forms.TextBox txtVarnish_Type;
        private System.Windows.Forms.ComboBox ddlVarnish_Active;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGrp_Name_Search;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.DataGridView dgwItem_Varnish_Master;
        private System.Windows.Forms.TextBox txtVarnish_ID;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdExcelReport;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}