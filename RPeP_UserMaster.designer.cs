namespace ePacker1
{
    partial class RPeP_UserMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_UserMaster));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.ddlUser_Active = new System.Windows.Forms.ComboBox();
            this.ddlUser_Level = new System.Windows.Forms.ComboBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.txtUser_Passwd = new System.Windows.Forms.TextBox();
            this.txtUser_Name = new System.Windows.Forms.TextBox();
            this.txtUser_ID = new System.Windows.Forms.TextBox();
            this.lblUser_Active = new System.Windows.Forms.Label();
            this.lblUser_Level = new System.Windows.Forms.Label();
            this.lblGrp_ID = new System.Windows.Forms.Label();
            this.lblUser_Passwd = new System.Windows.Forms.Label();
            this.lblUser_Name = new System.Windows.Forms.Label();
            this.lblUser_ID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ttlTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.ddlUser_Active);
            this.panel1.Controls.Add(this.ddlUser_Level);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.txtUser_Passwd);
            this.panel1.Controls.Add(this.txtUser_Name);
            this.panel1.Controls.Add(this.txtUser_ID);
            this.panel1.Controls.Add(this.lblUser_Active);
            this.panel1.Controls.Add(this.lblUser_Level);
            this.panel1.Controls.Add(this.lblGrp_ID);
            this.panel1.Controls.Add(this.lblUser_Passwd);
            this.panel1.Controls.Add(this.lblUser_Name);
            this.panel1.Controls.Add(this.lblUser_ID);
            this.panel1.ForeColor = System.Drawing.Color.Honeydew;
            this.panel1.Location = new System.Drawing.Point(95, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 401);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.Location = new System.Drawing.Point(575, 336);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 14;
            this.ttlTooltip.SetToolTip(this.cmdCancel, "Close");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdEdit.Location = new System.Drawing.Point(519, 336);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(50, 51);
            this.cmdEdit.TabIndex = 3;
            this.ttlTooltip.SetToolTip(this.cmdEdit, "Edit");
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReset.Location = new System.Drawing.Point(463, 335);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(50, 51);
            this.cmdReset.TabIndex = 13;
            this.ttlTooltip.SetToolTip(this.cmdReset, "Reset");
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSubmit.Location = new System.Drawing.Point(407, 335);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 12;
            this.ttlTooltip.SetToolTip(this.cmdSubmit, "Submit");
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // ddlUser_Active
            // 
            this.ddlUser_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUser_Active.FormattingEnabled = true;
            this.ddlUser_Active.Location = new System.Drawing.Point(172, 237);
            this.ddlUser_Active.MaxLength = 3;
            this.ddlUser_Active.Name = "ddlUser_Active";
            this.ddlUser_Active.Size = new System.Drawing.Size(173, 24);
            this.ddlUser_Active.TabIndex = 11;
            this.ttlTooltip.SetToolTip(this.ddlUser_Active, "Select User Active");
            // 
            // ddlUser_Level
            // 
            this.ddlUser_Level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUser_Level.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUser_Level.FormattingEnabled = true;
            this.ddlUser_Level.Location = new System.Drawing.Point(172, 184);
            this.ddlUser_Level.MaxLength = 5;
            this.ddlUser_Level.Name = "ddlUser_Level";
            this.ddlUser_Level.Size = new System.Drawing.Size(173, 24);
            this.ddlUser_Level.TabIndex = 10;
            this.ttlTooltip.SetToolTip(this.ddlUser_Level, "Select User Level");
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(477, 41);
            this.ddlGrp_ID.MaxLength = 50;
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(173, 24);
            this.ddlGrp_ID.TabIndex = 9;
            this.ttlTooltip.SetToolTip(this.ddlGrp_ID, "Select Group Name");
            this.ddlGrp_ID.Visible = false;
            // 
            // txtUser_Passwd
            // 
            this.txtUser_Passwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser_Passwd.Location = new System.Drawing.Point(172, 141);
            this.txtUser_Passwd.MaxLength = 10;
            this.txtUser_Passwd.Name = "txtUser_Passwd";
            this.txtUser_Passwd.PasswordChar = '*';
            this.txtUser_Passwd.Size = new System.Drawing.Size(173, 23);
            this.txtUser_Passwd.TabIndex = 8;
            this.ttlTooltip.SetToolTip(this.txtUser_Passwd, "Enter Password");
            // 
            // txtUser_Name
            // 
            this.txtUser_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser_Name.Location = new System.Drawing.Point(172, 90);
            this.txtUser_Name.MaxLength = 20;
            this.txtUser_Name.Name = "txtUser_Name";
            this.txtUser_Name.Size = new System.Drawing.Size(173, 23);
            this.txtUser_Name.TabIndex = 7;
            this.ttlTooltip.SetToolTip(this.txtUser_Name, "Enter User Name");
            this.txtUser_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_Name_KeyPress);
            // 
            // txtUser_ID
            // 
            this.txtUser_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser_ID.Location = new System.Drawing.Point(172, 41);
            this.txtUser_ID.MaxLength = 10;
            this.txtUser_ID.Name = "txtUser_ID";
            this.txtUser_ID.Size = new System.Drawing.Size(173, 23);
            this.txtUser_ID.TabIndex = 6;
            this.ttlTooltip.SetToolTip(this.txtUser_ID, "Enter User Id");
            this.txtUser_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_ID_KeyPress);
            // 
            // lblUser_Active
            // 
            this.lblUser_Active.AutoSize = true;
            this.lblUser_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser_Active.ForeColor = System.Drawing.Color.Honeydew;
            this.lblUser_Active.Location = new System.Drawing.Point(77, 240);
            this.lblUser_Active.Name = "lblUser_Active";
            this.lblUser_Active.Size = new System.Drawing.Size(53, 16);
            this.lblUser_Active.TabIndex = 5;
            this.lblUser_Active.Text = "Active *";
            // 
            // lblUser_Level
            // 
            this.lblUser_Level.AutoSize = true;
            this.lblUser_Level.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser_Level.ForeColor = System.Drawing.Color.Honeydew;
            this.lblUser_Level.Location = new System.Drawing.Point(77, 187);
            this.lblUser_Level.Name = "lblUser_Level";
            this.lblUser_Level.Size = new System.Drawing.Size(49, 16);
            this.lblUser_Level.TabIndex = 4;
            this.lblUser_Level.Text = "Level *";
            // 
            // lblGrp_ID
            // 
            this.lblGrp_ID.AutoSize = true;
            this.lblGrp_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrp_ID.ForeColor = System.Drawing.Color.Honeydew;
            this.lblGrp_ID.Location = new System.Drawing.Point(382, 44);
            this.lblGrp_ID.Name = "lblGrp_ID";
            this.lblGrp_ID.Size = new System.Drawing.Size(53, 16);
            this.lblGrp_ID.TabIndex = 3;
            this.lblGrp_ID.Text = "Group *";
            this.lblGrp_ID.Visible = false;
            // 
            // lblUser_Passwd
            // 
            this.lblUser_Passwd.AutoSize = true;
            this.lblUser_Passwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser_Passwd.ForeColor = System.Drawing.Color.Honeydew;
            this.lblUser_Passwd.Location = new System.Drawing.Point(77, 144);
            this.lblUser_Passwd.Name = "lblUser_Passwd";
            this.lblUser_Passwd.Size = new System.Drawing.Size(76, 16);
            this.lblUser_Passwd.TabIndex = 2;
            this.lblUser_Passwd.Text = "Password *";
            // 
            // lblUser_Name
            // 
            this.lblUser_Name.AutoSize = true;
            this.lblUser_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser_Name.ForeColor = System.Drawing.Color.Honeydew;
            this.lblUser_Name.Location = new System.Drawing.Point(77, 93);
            this.lblUser_Name.Name = "lblUser_Name";
            this.lblUser_Name.Size = new System.Drawing.Size(53, 16);
            this.lblUser_Name.TabIndex = 1;
            this.lblUser_Name.Text = "Name *";
            // 
            // lblUser_ID
            // 
            this.lblUser_ID.AutoSize = true;
            this.lblUser_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser_ID.ForeColor = System.Drawing.Color.Honeydew;
            this.lblUser_ID.Location = new System.Drawing.Point(77, 44);
            this.lblUser_ID.Name = "lblUser_ID";
            this.lblUser_ID.Size = new System.Drawing.Size(61, 16);
            this.lblUser_ID.TabIndex = 0;
            this.lblUser_ID.Text = "User ID *";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(262, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(356, 31);
            this.label7.TabIndex = 1;
            this.label7.Text = "System User Management";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(101, 499);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkOrange;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(660, 116);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RPeP_UserMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(200, 200);
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(804, 656);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Tomato;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_UserMaster";
            this.Text = "RPeP_UserMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPeP_UserMaster_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtUser_Passwd;
        private System.Windows.Forms.TextBox txtUser_Name;
        private System.Windows.Forms.TextBox txtUser_ID;
        private System.Windows.Forms.Label lblUser_Active;
        private System.Windows.Forms.Label lblUser_Level;
        private System.Windows.Forms.Label lblGrp_ID;
        private System.Windows.Forms.Label lblUser_Passwd;
        private System.Windows.Forms.Label lblUser_Name;
        private System.Windows.Forms.Label lblUser_ID;
        private System.Windows.Forms.ComboBox ddlUser_Active;
        private System.Windows.Forms.ComboBox ddlUser_Level;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.ToolTip ttlTooltip;
        private System.Windows.Forms.Button cmdCancel;
    }
}