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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterPQuality));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblGoupMgt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.ddlGSM_ID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlBF_ID = new System.Windows.Forms.ComboBox();
            this.lblDesc_Char = new System.Windows.Forms.Label();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.txtPQ_ID = new System.Windows.Forms.TextBox();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.ddlPQ_Active = new System.Windows.Forms.ComboBox();
            this.PQ_Active = new System.Windows.Forms.Label();
            this.txtPQ_Rate = new System.Windows.Forms.TextBox();
            this.lblPQ_Rate = new System.Windows.Forms.Label();
            this.lblBF = new System.Windows.Forms.Label();
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
            this.lblGoupMgt.Location = new System.Drawing.Point(313, 11);
            this.lblGoupMgt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGoupMgt.Name = "lblGoupMgt";
            this.lblGoupMgt.Size = new System.Drawing.Size(430, 39);
            this.lblGoupMgt.TabIndex = 1;
            this.lblGoupMgt.Text = "Paper Quality Management";
            this.lblGoupMgt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.ddlGSM_ID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ddlBF_ID);
            this.panel1.Controls.Add(this.lblDesc_Char);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.txtPQ_ID);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.ddlPQ_Active);
            this.panel1.Controls.Add(this.PQ_Active);
            this.panel1.Controls.Add(this.txtPQ_Rate);
            this.panel1.Controls.Add(this.lblPQ_Rate);
            this.panel1.Controls.Add(this.lblBF);
            this.panel1.Controls.Add(this.txtPQ_Desc);
            this.panel1.Controls.Add(this.lblPQ_Desc);
            this.panel1.Location = new System.Drawing.Point(40, 68);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 613);
            this.panel1.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(351, 435);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 70);
            this.btnDelete.TabIndex = 83;
            this.ttlToolTip.SetToolTip(this.btnDelete, "Delete");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCancel.BackgroundImage")));
            this.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdCancel.Location = new System.Drawing.Point(450, 435);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 70);
            this.cmdCancel.TabIndex = 82;
            this.ttlToolTip.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // ddlGSM_ID
            // 
            this.ddlGSM_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGSM_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlGSM_ID.FormattingEnabled = true;
            this.ddlGSM_ID.Location = new System.Drawing.Point(197, 170);
            this.ddlGSM_ID.Margin = new System.Windows.Forms.Padding(4);
            this.ddlGSM_ID.Name = "ddlGSM_ID";
            this.ddlGSM_ID.Size = new System.Drawing.Size(203, 30);
            this.ddlGSM_ID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(55, 170);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 60;
            this.label1.Text = "GSM *";
            // 
            // ddlBF_ID
            // 
            this.ddlBF_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBF_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBF_ID.FormattingEnabled = true;
            this.ddlBF_ID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ddlBF_ID.Location = new System.Drawing.Point(197, 117);
            this.ddlBF_ID.Margin = new System.Windows.Forms.Padding(4);
            this.ddlBF_ID.Name = "ddlBF_ID";
            this.ddlBF_ID.Size = new System.Drawing.Size(203, 30);
            this.ddlBF_ID.TabIndex = 2;
            // 
            // lblDesc_Char
            // 
            this.lblDesc_Char.AutoSize = true;
            this.lblDesc_Char.BackColor = System.Drawing.Color.LightSlateGray;
            this.lblDesc_Char.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc_Char.ForeColor = System.Drawing.Color.Yellow;
            this.lblDesc_Char.Location = new System.Drawing.Point(529, 69);
            this.lblDesc_Char.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesc_Char.Name = "lblDesc_Char";
            this.lblDesc_Char.Size = new System.Drawing.Size(81, 24);
            this.lblDesc_Char.TabIndex = 13;
            this.lblDesc_Char.Text = "Charcter";
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdEdit.BackgroundImage")));
            this.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdEdit.Location = new System.Drawing.Point(158, 438);
            this.cmdEdit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 70);
            this.cmdEdit.TabIndex = 12;
            this.ttlToolTip.SetToolTip(this.cmdEdit, "Edit");
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // txtPQ_ID
            // 
            this.txtPQ_ID.Location = new System.Drawing.Point(148, 13);
            this.txtPQ_ID.Name = "txtPQ_ID";
            this.txtPQ_ID.Size = new System.Drawing.Size(100, 22);
            this.txtPQ_ID.TabIndex = 14;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.BackgroundImage")));
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.Location = new System.Drawing.Point(256, 435);
            this.cmdRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(75, 70);
            this.cmdRefresh.TabIndex = 11;
            this.ttlToolTip.SetToolTip(this.cmdRefresh, "Refresh");
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click_1);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSubmit.BackgroundImage")));
            this.cmdSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSubmit.Location = new System.Drawing.Point(59, 439);
            this.cmdSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(75, 70);
            this.cmdSubmit.TabIndex = 10;
            this.ttlToolTip.SetToolTip(this.cmdSubmit, "Submit");
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // ddlPQ_Active
            // 
            this.ddlPQ_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPQ_Active.FormattingEnabled = true;
            this.ddlPQ_Active.Location = new System.Drawing.Point(197, 263);
            this.ddlPQ_Active.Margin = new System.Windows.Forms.Padding(4);
            this.ddlPQ_Active.MaxLength = 3;
            this.ddlPQ_Active.Name = "ddlPQ_Active";
            this.ddlPQ_Active.Size = new System.Drawing.Size(312, 30);
            this.ddlPQ_Active.TabIndex = 4;
            this.ttlToolTip.SetToolTip(this.ddlPQ_Active, "Select Group Active");
            // 
            // PQ_Active
            // 
            this.PQ_Active.AutoSize = true;
            this.PQ_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQ_Active.ForeColor = System.Drawing.Color.Honeydew;
            this.PQ_Active.Location = new System.Drawing.Point(55, 265);
            this.PQ_Active.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PQ_Active.Name = "PQ_Active";
            this.PQ_Active.Size = new System.Drawing.Size(73, 24);
            this.PQ_Active.TabIndex = 81;
            this.PQ_Active.Text = "Active *";
            // 
            // txtPQ_Rate
            // 
            this.txtPQ_Rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPQ_Rate.Location = new System.Drawing.Point(197, 223);
            this.txtPQ_Rate.Margin = new System.Windows.Forms.Padding(4);
            this.txtPQ_Rate.MaxLength = 7;
            this.txtPQ_Rate.Name = "txtPQ_Rate";
            this.txtPQ_Rate.Size = new System.Drawing.Size(312, 28);
            this.txtPQ_Rate.TabIndex = 7;
            this.ttlToolTip.SetToolTip(this.txtPQ_Rate, "Enter Paper Rate");
            this.txtPQ_Rate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPQ_Rate_KeyPress);
            // 
            // lblPQ_Rate
            // 
            this.lblPQ_Rate.AutoSize = true;
            this.lblPQ_Rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPQ_Rate.ForeColor = System.Drawing.Color.Honeydew;
            this.lblPQ_Rate.Location = new System.Drawing.Point(55, 225);
            this.lblPQ_Rate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPQ_Rate.Name = "lblPQ_Rate";
            this.lblPQ_Rate.Size = new System.Drawing.Size(60, 24);
            this.lblPQ_Rate.TabIndex = 61;
            this.lblPQ_Rate.Text = "Rate *";
            // 
            // lblBF
            // 
            this.lblBF.AutoSize = true;
            this.lblBF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBF.ForeColor = System.Drawing.Color.Honeydew;
            this.lblBF.Location = new System.Drawing.Point(55, 117);
            this.lblBF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBF.Name = "lblBF";
            this.lblBF.Size = new System.Drawing.Size(46, 24);
            this.lblBF.TabIndex = 41;
            this.lblBF.Text = "BF *";
            // 
            // txtPQ_Desc
            // 
            this.txtPQ_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPQ_Desc.Location = new System.Drawing.Point(197, 62);
            this.txtPQ_Desc.Margin = new System.Windows.Forms.Padding(4);
            this.txtPQ_Desc.MaxLength = 100;
            this.txtPQ_Desc.Multiline = true;
            this.txtPQ_Desc.Name = "txtPQ_Desc";
            this.txtPQ_Desc.Size = new System.Drawing.Size(312, 31);
            this.txtPQ_Desc.TabIndex = 0;
            this.ttlToolTip.SetToolTip(this.txtPQ_Desc, "Enter Paper Quality Description");
            this.txtPQ_Desc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPQ_Desc_KeyPress);
            // 
            // lblPQ_Desc
            // 
            this.lblPQ_Desc.AutoSize = true;
            this.lblPQ_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPQ_Desc.ForeColor = System.Drawing.Color.Honeydew;
            this.lblPQ_Desc.Location = new System.Drawing.Point(55, 63);
            this.lblPQ_Desc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPQ_Desc.Name = "lblPQ_Desc";
            this.lblPQ_Desc.Size = new System.Drawing.Size(116, 24);
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
            this.dgwPQuality_Master.Location = new System.Drawing.Point(857, 68);
            this.dgwPQuality_Master.Margin = new System.Windows.Forms.Padding(4);
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
            this.dgwPQuality_Master.Size = new System.Drawing.Size(918, 613);
            this.dgwPQuality_Master.TabIndex = 13;
            this.dgwPQuality_Master.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwPQuality_Master_RowHeaderMouseClick);
            // 
            // RPeP_MasterPQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(200, 200);
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1816, 718);
            this.Controls.Add(this.dgwPQuality_Master);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblGoupMgt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.TextBox txtPQ_Desc;
        private System.Windows.Forms.TextBox txtPQ_ID;
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
        private System.Windows.Forms.ComboBox ddlGSM_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlBF_ID;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button btnDelete;
    }
}