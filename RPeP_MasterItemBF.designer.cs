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
            this.dgwItem_BF_Master = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwItem_BF_Master)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(307, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item - BF Management";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDelete);
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
            this.panel1.Location = new System.Drawing.Point(13, 97);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 502);
            this.panel1.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCancel.BackgroundImage")));
            this.cmdCancel.Location = new System.Drawing.Point(386, 218);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 75);
            this.cmdCancel.TabIndex = 13;
            this.toolTip1.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdEdit.BackgroundImage")));
            this.cmdEdit.Location = new System.Drawing.Point(104, 218);
            this.cmdEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 75);
            this.cmdEdit.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cmdEdit, "Edit");
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdReset.BackgroundImage")));
            this.cmdReset.Location = new System.Drawing.Point(198, 218);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 75);
            this.cmdReset.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cmdReset, "Reset");
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSubmit.BackgroundImage")));
            this.cmdSubmit.Location = new System.Drawing.Point(14, 218);
            this.cmdSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(75, 75);
            this.cmdSubmit.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmdSubmit, "Submit");
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // ddlBF_Active
            // 
            this.ddlBF_Active.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBF_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBF_Active.FormattingEnabled = true;
            this.ddlBF_Active.Location = new System.Drawing.Point(120, 113);
            this.ddlBF_Active.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlBF_Active.Name = "ddlBF_Active";
            this.ddlBF_Active.Size = new System.Drawing.Size(153, 30);
            this.ddlBF_Active.TabIndex = 9;
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(353, 39);
            this.ddlGrp_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(132, 24);
            this.ddlGrp_ID.TabIndex = 1;
            this.toolTip1.SetToolTip(this.ddlGrp_ID, "Select Group Name");
            this.ddlGrp_ID.Visible = false;
            // 
            // txtBF_Value
            // 
            this.txtBF_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBF_Value.Location = new System.Drawing.Point(120, 68);
            this.txtBF_Value.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBF_Value.MaxLength = 7;
            this.txtBF_Value.Name = "txtBF_Value";
            this.txtBF_Value.Size = new System.Drawing.Size(153, 28);
            this.txtBF_Value.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtBF_Value, "Enter Value");
            this.txtBF_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBF_Value_KeyPress);
            // 
            // txtBF_ID
            // 
            this.txtBF_ID.Location = new System.Drawing.Point(120, 36);
            this.txtBF_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBF_ID.Name = "txtBF_ID";
            this.txtBF_ID.Size = new System.Drawing.Size(132, 22);
            this.txtBF_ID.TabIndex = 6;
            // 
            // lblBF_Active
            // 
            this.lblBF_Active.AutoSize = true;
            this.lblBF_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBF_Active.ForeColor = System.Drawing.Color.Honeydew;
            this.lblBF_Active.Location = new System.Drawing.Point(28, 114);
            this.lblBF_Active.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBF_Active.Name = "lblBF_Active";
            this.lblBF_Active.Size = new System.Drawing.Size(73, 24);
            this.lblBF_Active.TabIndex = 5;
            this.lblBF_Active.Text = "Active *";
            // 
            // lblBF_Value
            // 
            this.lblBF_Value.AutoSize = true;
            this.lblBF_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBF_Value.ForeColor = System.Drawing.Color.Honeydew;
            this.lblBF_Value.Location = new System.Drawing.Point(28, 69);
            this.lblBF_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBF_Value.Name = "lblBF_Value";
            this.lblBF_Value.Size = new System.Drawing.Size(71, 24);
            this.lblBF_Value.TabIndex = 4;
            this.lblBF_Value.Text = "Value *";
            // 
            // lblGrp_ID
            // 
            this.lblGrp_ID.AutoSize = true;
            this.lblGrp_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrp_ID.ForeColor = System.Drawing.Color.Honeydew;
            this.lblGrp_ID.Location = new System.Drawing.Point(261, 41);
            this.lblGrp_ID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrp_ID.Name = "lblGrp_ID";
            this.lblGrp_ID.Size = new System.Drawing.Size(66, 20);
            this.lblGrp_ID.TabIndex = 3;
            this.lblGrp_ID.Text = "Group *";
            this.lblGrp_ID.Visible = false;
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
            this.dgwItem_BF_Master.Location = new System.Drawing.Point(588, 167);
            this.dgwItem_BF_Master.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.dgwItem_BF_Master.Size = new System.Drawing.Size(508, 432);
            this.dgwItem_BF_Master.TabIndex = 15;
            this.dgwItem_BF_Master.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwItem_BF_Master_RowHeaderMouseClick);
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackColor = System.Drawing.Color.Black;
            this.cmdExcelReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdExcelReport.BackgroundImage")));
            this.cmdExcelReport.Location = new System.Drawing.Point(925, 89);
            this.cmdExcelReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(75, 75);
            this.cmdExcelReport.TabIndex = 16;
            this.cmdExcelReport.UseVisualStyleBackColor = false;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(292, 218);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 75);
            this.btnDelete.TabIndex = 93;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // RPeP_MasterItemBF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1786, 711);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.dgwItem_BF_Master);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.DataGridView dgwItem_BF_Master;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button cmdExcelReport;
        private System.Windows.Forms.Button btnDelete;
    }
}