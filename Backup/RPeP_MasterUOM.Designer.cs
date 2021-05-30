namespace ePacker1
{
    partial class RPeP_MasterUOM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterUOM));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.ddlUOM_Active = new System.Windows.Forms.ComboBox();
            this.txtUOM_Name = new System.Windows.Forms.TextBox();
            this.txtUOM_ID = new System.Windows.Forms.TextBox();
            this.lblUOM_Name = new System.Windows.Forms.Label();
            this.lblUOM_Active = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgwUOM_Master = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwUOM_Master)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.ddlUOM_Active);
            this.panel1.Controls.Add(this.txtUOM_Name);
            this.panel1.Controls.Add(this.txtUOM_ID);
            this.panel1.Controls.Add(this.lblUOM_Name);
            this.panel1.Controls.Add(this.lblUOM_Active);
            this.panel1.Location = new System.Drawing.Point(194, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 259);
            this.panel1.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.Location = new System.Drawing.Point(368, 185);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdRefresh.Location = new System.Drawing.Point(256, 185);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(50, 51);
            this.cmdRefresh.TabIndex = 9;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdEdit.Location = new System.Drawing.Point(312, 185);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(50, 51);
            this.cmdEdit.TabIndex = 8;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.Location = new System.Drawing.Point(200, 185);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 7;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // ddlUOM_Active
            // 
            this.ddlUOM_Active.FormattingEnabled = true;
            this.ddlUOM_Active.Location = new System.Drawing.Point(200, 117);
            this.ddlUOM_Active.Name = "ddlUOM_Active";
            this.ddlUOM_Active.Size = new System.Drawing.Size(146, 21);
            this.ddlUOM_Active.TabIndex = 6;
            // 
            // txtUOM_Name
            // 
            this.txtUOM_Name.Location = new System.Drawing.Point(200, 57);
            this.txtUOM_Name.Name = "txtUOM_Name";
            this.txtUOM_Name.Size = new System.Drawing.Size(146, 20);
            this.txtUOM_Name.TabIndex = 5;
            this.txtUOM_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUOM_Name_KeyPress);
            // 
            // txtUOM_ID
            // 
            this.txtUOM_ID.Location = new System.Drawing.Point(200, 12);
            this.txtUOM_ID.Name = "txtUOM_ID";
            this.txtUOM_ID.Size = new System.Drawing.Size(146, 20);
            this.txtUOM_ID.TabIndex = 4;
            this.txtUOM_ID.Visible = false;
            // 
            // lblUOM_Name
            // 
            this.lblUOM_Name.AutoSize = true;
            this.lblUOM_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOM_Name.ForeColor = System.Drawing.Color.Honeydew;
            this.lblUOM_Name.Location = new System.Drawing.Point(119, 58);
            this.lblUOM_Name.Name = "lblUOM_Name";
            this.lblUOM_Name.Size = new System.Drawing.Size(47, 16);
            this.lblUOM_Name.TabIndex = 2;
            this.lblUOM_Name.Text = "UOM *";
            // 
            // lblUOM_Active
            // 
            this.lblUOM_Active.AutoSize = true;
            this.lblUOM_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOM_Active.ForeColor = System.Drawing.Color.Honeydew;
            this.lblUOM_Active.Location = new System.Drawing.Point(119, 118);
            this.lblUOM_Active.Name = "lblUOM_Active";
            this.lblUOM_Active.Size = new System.Drawing.Size(53, 16);
            this.lblUOM_Active.TabIndex = 3;
            this.lblUOM_Active.Text = "Active *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(316, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "UOM Management";
            // 
            // dgwUOM_Master
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwUOM_Master.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwUOM_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwUOM_Master.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwUOM_Master.Location = new System.Drawing.Point(273, 352);
            this.dgwUOM_Master.Name = "dgwUOM_Master";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwUOM_Master.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwUOM_Master.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwUOM_Master.Size = new System.Drawing.Size(347, 150);
            this.dgwUOM_Master.TabIndex = 2;
            this.dgwUOM_Master.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwUOM_Master_RowHeaderMouseClick);
            // 
            // RPeP_MasterUOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(804, 534);
            this.Controls.Add(this.dgwUOM_Master);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_MasterUOM";
            this.Text = "RPeP_MasterUOM";
            this.Load += new System.EventHandler(this.RPeP_MasterUOM_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwUOM_Master)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtUOM_Name;
        private System.Windows.Forms.TextBox txtUOM_ID;
        private System.Windows.Forms.Label lblUOM_Name;
        private System.Windows.Forms.Label lblUOM_Active;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.ComboBox ddlUOM_Active;
        private System.Windows.Forms.DataGridView dgwUOM_Master;
        private System.Windows.Forms.Button cmdCancel;
    }
}