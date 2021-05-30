namespace ePacker1
{
    partial class RPeP_MasterPQuality
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterPQuality));
            this.lblGoupMgt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.ddlGSM_ID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlBF_ID = new System.Windows.Forms.ComboBox();
            this.txtPQ_ID = new System.Windows.Forms.TextBox();
            this.lblDesc_Char = new System.Windows.Forms.Label();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.ddlPQ_Active = new System.Windows.Forms.ComboBox();
            this.PQ_Active = new System.Windows.Forms.Label();
            this.txtPQ_Rate = new System.Windows.Forms.TextBox();
            this.lblPQ_Rate = new System.Windows.Forms.Label();
            this.lblBF = new System.Windows.Forms.Label();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.lblGrp_ID = new System.Windows.Forms.Label();
            this.txtPQ_Desc = new System.Windows.Forms.TextBox();
            this.lblPQ_Desc = new System.Windows.Forms.Label();
            this.ttlToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dgwPQuality_Master = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPQuality_Master)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGoupMgt
            // 
            this.lblGoupMgt.AutoSize = true;
            this.lblGoupMgt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoupMgt.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblGoupMgt.Location = new System.Drawing.Point(235, 9);
            this.lblGoupMgt.Name = "lblGoupMgt";
            this.lblGoupMgt.Size = new System.Drawing.Size(342, 31);
            this.lblGoupMgt.TabIndex = 1;
            this.lblGoupMgt.Text = "Paper Quality Management";
            this.lblGoupMgt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.ddlGSM_ID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ddlBF_ID);
            this.panel1.Controls.Add(this.txtPQ_ID);
            this.panel1.Controls.Add(this.lblDesc_Char);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.ddlPQ_Active);
            this.panel1.Controls.Add(this.PQ_Active);
            this.panel1.Controls.Add(this.txtPQ_Rate);
            this.panel1.Controls.Add(this.lblPQ_Rate);
            this.panel1.Controls.Add(this.lblBF);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.lblGrp_ID);
            this.panel1.Controls.Add(this.txtPQ_Desc);
            this.panel1.Controls.Add(this.lblPQ_Desc);
            this.panel1.Location = new System.Drawing.Point(30, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 357);
            this.panel1.TabIndex = 2;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdCancel.Location = new System.Drawing.Point(574, 293);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 82;
            this.ttlToolTip.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // ddlGSM_ID
            // 
            this.ddlGSM_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGSM_ID.FormattingEnabled = true;
            this.ddlGSM_ID.Location = new System.Drawing.Point(462, 107);
            this.ddlGSM_ID.Name = "ddlGSM_ID";
            this.ddlGSM_ID.Size = new System.Drawing.Size(153, 21);
            this.ddlGSM_ID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(400, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "GSM *";
            // 
            // ddlBF_ID
            // 
            this.ddlBF_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBF_ID.FormattingEnabled = true;
            this.ddlBF_ID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ddlBF_ID.Location = new System.Drawing.Point(148, 107);
            this.ddlBF_ID.Name = "ddlBF_ID";
            this.ddlBF_ID.Size = new System.Drawing.Size(121, 21);
            this.ddlBF_ID.TabIndex = 2;
            // 
            // txtPQ_ID
            // 
            this.txtPQ_ID.Location = new System.Drawing.Point(148, 13);
            this.txtPQ_ID.Name = "txtPQ_ID";
            this.txtPQ_ID.Size = new System.Drawing.Size(100, 20);
            this.txtPQ_ID.TabIndex = 14;
            // 
            // lblDesc_Char
            // 
            this.lblDesc_Char.AutoSize = true;
            this.lblDesc_Char.BackColor = System.Drawing.Color.LightSlateGray;
            this.lblDesc_Char.ForeColor = System.Drawing.Color.Yellow;
            this.lblDesc_Char.Location = new System.Drawing.Point(255, 73);
            this.lblDesc_Char.Name = "lblDesc_Char";
            this.lblDesc_Char.Size = new System.Drawing.Size(47, 13);
            this.lblDesc_Char.TabIndex = 13;
            this.lblDesc_Char.Text = "Charcter";
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdEdit.Location = new System.Drawing.Point(518, 293);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(50, 51);
            this.cmdEdit.TabIndex = 12;
            this.ttlToolTip.SetToolTip(this.cmdEdit, "Edit");
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.Location = new System.Drawing.Point(462, 293);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(50, 51);
            this.cmdRefresh.TabIndex = 11;
            this.ttlToolTip.SetToolTip(this.cmdRefresh, "Refresh");
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click_1);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSubmit.Location = new System.Drawing.Point(403, 293);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 10;
            this.ttlToolTip.SetToolTip(this.cmdSubmit, "Submit");
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // ddlPQ_Active
            // 
            this.ddlPQ_Active.FormattingEnabled = true;
            this.ddlPQ_Active.Location = new System.Drawing.Point(148, 214);
            this.ddlPQ_Active.MaxLength = 3;
            this.ddlPQ_Active.Name = "ddlPQ_Active";
            this.ddlPQ_Active.Size = new System.Drawing.Size(235, 21);
            this.ddlPQ_Active.TabIndex = 4;
            this.ttlToolTip.SetToolTip(this.ddlPQ_Active, "Select Group Active");
            // 
            // PQ_Active
            // 
            this.PQ_Active.AutoSize = true;
            this.PQ_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQ_Active.ForeColor = System.Drawing.Color.Honeydew;
            this.PQ_Active.Location = new System.Drawing.Point(41, 215);
            this.PQ_Active.Name = "PQ_Active";
            this.PQ_Active.Size = new System.Drawing.Size(53, 16);
            this.PQ_Active.TabIndex = 81;
            this.PQ_Active.Text = "Active *";
            // 
            // txtPQ_Rate
            // 
            this.txtPQ_Rate.Location = new System.Drawing.Point(148, 164);
            this.txtPQ_Rate.MaxLength = 7;
            this.txtPQ_Rate.Name = "txtPQ_Rate";
            this.txtPQ_Rate.Size = new System.Drawing.Size(235, 20);
            this.txtPQ_Rate.TabIndex = 7;
            this.txtPQ_Rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ttlToolTip.SetToolTip(this.txtPQ_Rate, "Enter Paper Rate");
            this.txtPQ_Rate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPQ_Rate_KeyPress);
            // 
            // lblPQ_Rate
            // 
            this.lblPQ_Rate.AutoSize = true;
            this.lblPQ_Rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPQ_Rate.ForeColor = System.Drawing.Color.Honeydew;
            this.lblPQ_Rate.Location = new System.Drawing.Point(41, 165);
            this.lblPQ_Rate.Name = "lblPQ_Rate";
            this.lblPQ_Rate.Size = new System.Drawing.Size(45, 16);
            this.lblPQ_Rate.TabIndex = 61;
            this.lblPQ_Rate.Text = "Rate *";
            // 
            // lblBF
            // 
            this.lblBF.AutoSize = true;
            this.lblBF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBF.ForeColor = System.Drawing.Color.Honeydew;
            this.lblBF.Location = new System.Drawing.Point(41, 108);
            this.lblBF.Name = "lblBF";
            this.lblBF.Size = new System.Drawing.Size(33, 16);
            this.lblBF.TabIndex = 41;
            this.lblBF.Text = "BF *";
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(399, 12);
            this.ddlGrp_ID.MaxLength = 5;
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(235, 21);
            this.ddlGrp_ID.TabIndex = 1;
            this.ttlToolTip.SetToolTip(this.ddlGrp_ID, "Select GroupID");
            this.ddlGrp_ID.Visible = false;
            // 
            // lblGrp_ID
            // 
            this.lblGrp_ID.AutoSize = true;
            this.lblGrp_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrp_ID.ForeColor = System.Drawing.Color.Honeydew;
            this.lblGrp_ID.Location = new System.Drawing.Point(292, 13);
            this.lblGrp_ID.Name = "lblGrp_ID";
            this.lblGrp_ID.Size = new System.Drawing.Size(53, 16);
            this.lblGrp_ID.TabIndex = 21;
            this.lblGrp_ID.Text = "Group *";
            this.lblGrp_ID.Visible = false;
            // 
            // txtPQ_Desc
            // 
            this.txtPQ_Desc.Location = new System.Drawing.Point(148, 50);
            this.txtPQ_Desc.MaxLength = 100;
            this.txtPQ_Desc.Multiline = true;
            this.txtPQ_Desc.Name = "txtPQ_Desc";
            this.txtPQ_Desc.Size = new System.Drawing.Size(235, 20);
            this.txtPQ_Desc.TabIndex = 0;
            this.ttlToolTip.SetToolTip(this.txtPQ_Desc, "Enter Paper Quality Description");
            this.txtPQ_Desc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPQ_Desc_KeyPress);
            // 
            // lblPQ_Desc
            // 
            this.lblPQ_Desc.AutoSize = true;
            this.lblPQ_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPQ_Desc.ForeColor = System.Drawing.Color.Honeydew;
            this.lblPQ_Desc.Location = new System.Drawing.Point(41, 51);
            this.lblPQ_Desc.Name = "lblPQ_Desc";
            this.lblPQ_Desc.Size = new System.Drawing.Size(84, 16);
            this.lblPQ_Desc.TabIndex = 15;
            this.lblPQ_Desc.Text = "Description *";
            // 
            // dgwPQuality_Master
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwPQuality_Master.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwPQuality_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwPQuality_Master.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwPQuality_Master.Location = new System.Drawing.Point(30, 450);
            this.dgwPQuality_Master.Name = "dgwPQuality_Master";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwPQuality_Master.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwPQuality_Master.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwPQuality_Master.Size = new System.Drawing.Size(649, 163);
            this.dgwPQuality_Master.TabIndex = 13;
            this.dgwPQuality_Master.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwPQuality_Master_RowHeaderMouseClick);
            // 
            // RPeP_MasterPQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(200, 200);
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(804, 446);
            this.Controls.Add(this.dgwPQuality_Master);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblGoupMgt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_MasterPQuality";
            this.Text = "RPeP_MasterPQuality";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPeP_MasterPQuality_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPQuality_Master)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGoupMgt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPQ_Desc;
        private System.Windows.Forms.Label lblBF;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.Label lblGrp_ID;
        private System.Windows.Forms.TextBox txtPQ_Desc;
        private System.Windows.Forms.Label PQ_Active;
        private System.Windows.Forms.TextBox txtPQ_Rate;
        private System.Windows.Forms.Label lblPQ_Rate;
        private System.Windows.Forms.ComboBox ddlPQ_Active;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.ToolTip ttlToolTip;
        private System.Windows.Forms.DataGridView dgwPQuality_Master;
        private System.Windows.Forms.Label lblDesc_Char;
        private System.Windows.Forms.TextBox txtPQ_ID;
        private System.Windows.Forms.ComboBox ddlGSM_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlBF_ID;
        private System.Windows.Forms.Button cmdCancel;

    }
}