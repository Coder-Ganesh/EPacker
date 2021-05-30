namespace ePacker1
{
    partial class RPeP_MasterShift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterShift));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.ddlS_Active = new System.Windows.Forms.ComboBox();
            this.txtS_Name = new System.Windows.Forms.TextBox();
            this.txtS_ID = new System.Windows.Forms.TextBox();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.lblS_Name = new System.Windows.Forms.Label();
            this.lblS_Active = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgwShift_Master = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwShift_Master)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.ddlS_Active);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.txtS_Name);
            this.panel1.Controls.Add(this.txtS_ID);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.lblS_Name);
            this.panel1.Controls.Add(this.lblS_Active);
            this.panel1.Location = new System.Drawing.Point(23, 93);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 296);
            this.panel1.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCancel.BackgroundImage")));
            this.cmdCancel.Location = new System.Drawing.Point(375, 215);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(70, 75);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // ddlS_Active
            // 
            this.ddlS_Active.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ddlS_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlS_Active.FormattingEnabled = true;
            this.ddlS_Active.Location = new System.Drawing.Point(119, 143);
            this.ddlS_Active.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlS_Active.Name = "ddlS_Active";
            this.ddlS_Active.Size = new System.Drawing.Size(201, 30);
            this.ddlS_Active.TabIndex = 8;
            // 
            // txtS_Name
            // 
            this.txtS_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtS_Name.Location = new System.Drawing.Point(119, 73);
            this.txtS_Name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtS_Name.Name = "txtS_Name";
            this.txtS_Name.Size = new System.Drawing.Size(201, 28);
            this.txtS_Name.TabIndex = 7;
            this.txtS_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtS_Name_KeyPress);
            // 
            // txtS_ID
            // 
            this.txtS_ID.Location = new System.Drawing.Point(147, 22);
            this.txtS_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtS_ID.Name = "txtS_ID";
            this.txtS_ID.Size = new System.Drawing.Size(175, 22);
            this.txtS_ID.TabIndex = 6;
            this.txtS_ID.Visible = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.BackgroundImage")));
            this.cmdRefresh.Location = new System.Drawing.Point(188, 215);
            this.cmdRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(70, 75);
            this.cmdRefresh.TabIndex = 10;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdEdit.BackgroundImage")));
            this.cmdEdit.Location = new System.Drawing.Point(98, 215);
            this.cmdEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(70, 75);
            this.cmdEdit.TabIndex = 11;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSubmit.BackgroundImage")));
            this.cmdSubmit.Location = new System.Drawing.Point(4, 215);
            this.cmdSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(70, 75);
            this.cmdSubmit.TabIndex = 9;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // lblS_Name
            // 
            this.lblS_Name.AutoSize = true;
            this.lblS_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS_Name.ForeColor = System.Drawing.Color.Honeydew;
            this.lblS_Name.Location = new System.Drawing.Point(10, 78);
            this.lblS_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblS_Name.Name = "lblS_Name";
            this.lblS_Name.Size = new System.Drawing.Size(57, 24);
            this.lblS_Name.TabIndex = 1;
            this.lblS_Name.Text = "Shift *";
            // 
            // lblS_Active
            // 
            this.lblS_Active.AutoSize = true;
            this.lblS_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS_Active.ForeColor = System.Drawing.Color.Honeydew;
            this.lblS_Active.Location = new System.Drawing.Point(10, 143);
            this.lblS_Active.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblS_Active.Name = "lblS_Active";
            this.lblS_Active.Size = new System.Drawing.Size(73, 24);
            this.lblS_Active.TabIndex = 2;
            this.lblS_Active.Text = "Active *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(439, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shift Management";
            // 
            // dgwShift_Master
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwShift_Master.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwShift_Master.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwShift_Master.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwShift_Master.Location = new System.Drawing.Point(542, 93);
            this.dgwShift_Master.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgwShift_Master.Name = "dgwShift_Master";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwShift_Master.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgwShift_Master.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwShift_Master.Size = new System.Drawing.Size(527, 296);
            this.dgwShift_Master.TabIndex = 6;
            this.dgwShift_Master.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwShift_Master_RowHeaderMouseClick);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(278, 216);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 75);
            this.btnDelete.TabIndex = 88;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // RPeP_MasterShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1502, 683);
            this.Controls.Add(this.dgwShift_Master);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RPeP_MasterShift";
            this.Text = "RPeP_MasterShift";
            this.Load += new System.EventHandler(this.RPeP_MasterShift_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwShift_Master)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Label lblS_Name;
        private System.Windows.Forms.Label lblS_Active;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgwShift_Master;
        private System.Windows.Forms.ComboBox ddlS_Active;
        private System.Windows.Forms.TextBox txtS_Name;
        private System.Windows.Forms.TextBox txtS_ID;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button btnDelete;
    }
}