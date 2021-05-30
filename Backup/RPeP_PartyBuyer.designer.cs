namespace ePacker1
{
    partial class RPeP_PartyBuyer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_PartyBuyer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.txtPB_ID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlPB_Active = new System.Windows.Forms.ComboBox();
            this.txtPB_Phone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPB_Name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPB_Mobile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPB_Email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlP_ID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgwPartyBuyer = new System.Windows.Forms.DataGridView();
            this.cmd_PB_Name_Search = new System.Windows.Forms.Button();
            this.txtPB_Name_Search = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.ddlP_ID_Search = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPartyBuyer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.txtPB_ID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ddlPB_Active);
            this.panel1.Controls.Add(this.txtPB_Phone);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPB_Name);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPB_Mobile);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPB_Email);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ddlP_ID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(48, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 317);
            this.panel1.TabIndex = 2;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.Location = new System.Drawing.Point(337, 248);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 10;
            this.toolTip1.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdEdit.Location = new System.Drawing.Point(393, 248);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(50, 51);
            this.cmdEdit.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cmdEdit, "Edit");
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdReset.Location = new System.Drawing.Point(281, 248);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(50, 51);
            this.cmdReset.TabIndex = 9;
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.Location = new System.Drawing.Point(225, 248);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 8;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // txtPB_ID
            // 
            this.txtPB_ID.Location = new System.Drawing.Point(512, -1);
            this.txtPB_ID.Name = "txtPB_ID";
            this.txtPB_ID.Size = new System.Drawing.Size(109, 20);
            this.txtPB_ID.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Honeydew;
            this.label7.Location = new System.Drawing.Point(79, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Active *";
            // 
            // ddlPB_Active
            // 
            this.ddlPB_Active.FormattingEnabled = true;
            this.ddlPB_Active.Location = new System.Drawing.Point(225, 188);
            this.ddlPB_Active.MaxLength = 3;
            this.ddlPB_Active.Name = "ddlPB_Active";
            this.ddlPB_Active.Size = new System.Drawing.Size(206, 21);
            this.ddlPB_Active.TabIndex = 7;
            // 
            // txtPB_Phone
            // 
            this.txtPB_Phone.Location = new System.Drawing.Point(223, 89);
            this.txtPB_Phone.MaxLength = 50;
            this.txtPB_Phone.Name = "txtPB_Phone";
            this.txtPB_Phone.Size = new System.Drawing.Size(206, 20);
            this.txtPB_Phone.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(77, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Phone *";
            // 
            // txtPB_Name
            // 
            this.txtPB_Name.Location = new System.Drawing.Point(221, 57);
            this.txtPB_Name.MaxLength = 50;
            this.txtPB_Name.Name = "txtPB_Name";
            this.txtPB_Name.Size = new System.Drawing.Size(206, 20);
            this.txtPB_Name.TabIndex = 3;
            this.txtPB_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPB_Name_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(75, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Name *";
            // 
            // txtPB_Mobile
            // 
            this.txtPB_Mobile.Location = new System.Drawing.Point(223, 122);
            this.txtPB_Mobile.MaxLength = 50;
            this.txtPB_Mobile.Name = "txtPB_Mobile";
            this.txtPB_Mobile.Size = new System.Drawing.Size(206, 20);
            this.txtPB_Mobile.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(77, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Mobile ";
            // 
            // txtPB_Email
            // 
            this.txtPB_Email.Location = new System.Drawing.Point(223, 155);
            this.txtPB_Email.MaxLength = 20;
            this.txtPB_Email.Name = "txtPB_Email";
            this.txtPB_Email.Size = new System.Drawing.Size(206, 20);
            this.txtPB_Email.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(77, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Email ";
            // 
            // ddlP_ID
            // 
            this.ddlP_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlP_ID.FormattingEnabled = true;
            this.ddlP_ID.Location = new System.Drawing.Point(221, 24);
            this.ddlP_ID.MaxLength = 50;
            this.ddlP_ID.Name = "ddlP_ID";
            this.ddlP_ID.Size = new System.Drawing.Size(206, 21);
            this.ddlP_ID.TabIndex = 2;
            this.toolTip1.SetToolTip(this.ddlP_ID, "Select Party ");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(77, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Party *";
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(62, -1);
            this.ddlGrp_ID.MaxLength = 50;
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(67, 21);
            this.ddlGrp_ID.TabIndex = 1;
            this.toolTip1.SetToolTip(this.ddlGrp_ID, "Select Group");
            this.ddlGrp_ID.Visible = false;
            this.ddlGrp_ID.SelectedIndexChanged += new System.EventHandler(this.ddlGrp_ID_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group *";
            this.label1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOrange;
            this.label8.Location = new System.Drawing.Point(285, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 31);
            this.label8.TabIndex = 7;
            this.label8.Text = "Party Buyer";
            // 
            // dgwPartyBuyer
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwPartyBuyer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwPartyBuyer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwPartyBuyer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwPartyBuyer.Location = new System.Drawing.Point(98, 448);
            this.dgwPartyBuyer.Name = "dgwPartyBuyer";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwPartyBuyer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwPartyBuyer.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwPartyBuyer.Size = new System.Drawing.Size(580, 127);
            this.dgwPartyBuyer.TabIndex = 15;
            this.dgwPartyBuyer.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwPartyBuyer_RowHeaderMouseClick);
            // 
            // cmd_PB_Name_Search
            // 
            this.cmd_PB_Name_Search.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.cmd_PB_Name_Search.Location = new System.Drawing.Point(570, 385);
            this.cmd_PB_Name_Search.Name = "cmd_PB_Name_Search";
            this.cmd_PB_Name_Search.Size = new System.Drawing.Size(50, 51);
            this.cmd_PB_Name_Search.TabIndex = 14;
            this.cmd_PB_Name_Search.UseVisualStyleBackColor = true;
            this.cmd_PB_Name_Search.Click += new System.EventHandler(this.cmd_PB_Name_Search_Click);
            // 
            // txtPB_Name_Search
            // 
            this.txtPB_Name_Search.Location = new System.Drawing.Point(415, 416);
            this.txtPB_Name_Search.Name = "txtPB_Name_Search";
            this.txtPB_Name_Search.Size = new System.Drawing.Size(138, 20);
            this.txtPB_Name_Search.TabIndex = 13;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Honeydew;
            this.lbl.Location = new System.Drawing.Point(106, 420);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(47, 16);
            this.lbl.TabIndex = 11;
            this.lbl.Text = "Party *";
            // 
            // ddlP_ID_Search
            // 
            this.ddlP_ID_Search.FormattingEnabled = true;
            this.ddlP_ID_Search.Location = new System.Drawing.Point(159, 415);
            this.ddlP_ID_Search.MaxLength = 3;
            this.ddlP_ID_Search.Name = "ddlP_ID_Search";
            this.ddlP_ID_Search.Size = new System.Drawing.Size(163, 21);
            this.ddlP_ID_Search.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Honeydew;
            this.label9.Location = new System.Drawing.Point(356, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "Name *";
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackgroundImage = global::ePacker1.Properties.Resources.Excel_Icon;
            this.cmdExcelReport.Location = new System.Drawing.Point(626, 385);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(52, 51);
            this.cmdExcelReport.TabIndex = 28;
            this.cmdExcelReport.UseVisualStyleBackColor = true;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // RPeP_PartyBuyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(5, 100);
            this.AutoScrollMinSize = new System.Drawing.Size(5, 100);
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ddlP_ID_Search);
            this.Controls.Add(this.dgwPartyBuyer);
            this.Controls.Add(this.cmd_PB_Name_Search);
            this.Controls.Add(this.txtPB_Name_Search);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_PartyBuyer";
            this.Text = "RPeP_PartyBuyer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPeP_PartyBuyer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPartyBuyer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.ComboBox ddlP_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPB_Phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPB_Name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPB_Mobile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPB_Email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddlPB_Active;
        private System.Windows.Forms.TextBox txtPB_ID;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.DataGridView dgwPartyBuyer;
        private System.Windows.Forms.Button cmd_PB_Name_Search;
        private System.Windows.Forms.TextBox txtPB_Name_Search;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox ddlP_ID_Search;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdExcelReport;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}