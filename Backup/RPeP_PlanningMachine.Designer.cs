namespace ePacker1
{
    partial class RPeP_PlanningMachine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.txtPSST_ID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPSST_Dt = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label127 = new System.Windows.Forms.Label();
            this.ddlOrder_ID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlI_ID = new System.Windows.Forms.ComboBox();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.CmdSearch = new System.Windows.Forms.Button();
            this.GridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtorderSearch = new System.Windows.Forms.TextBox();
            this.cmdOrderSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPSPM_Type = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddlM_ID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(343, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(365, 31);
            this.label7.TabIndex = 174;
            this.label7.Text = "Production Planning Machine";
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label125.ForeColor = System.Drawing.Color.Honeydew;
            this.label125.Location = new System.Drawing.Point(23, 35);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(67, 16);
            this.label125.TabIndex = 42;
            this.label125.Text = "Serial No.";
            // 
            // txtPSST_ID
            // 
            this.txtPSST_ID.Enabled = false;
            this.txtPSST_ID.Location = new System.Drawing.Point(133, 31);
            this.txtPSST_ID.MaxLength = 100;
            this.txtPSST_ID.Name = "txtPSST_ID";
            this.txtPSST_ID.Size = new System.Drawing.Size(165, 20);
            this.txtPSST_ID.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(23, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 55;
            this.label6.Text = " Date. *";
            // 
            // txtPSST_Dt
            // 
            this.txtPSST_Dt.Location = new System.Drawing.Point(133, 69);
            this.txtPSST_Dt.MaxLength = 10;
            this.txtPSST_Dt.Name = "txtPSST_Dt";
            this.txtPSST_Dt.Size = new System.Drawing.Size(452, 20);
            this.txtPSST_Dt.TabIndex = 2;
            this.txtPSST_Dt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPSST_Dt_MouseClick);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(608, 9);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.LightSlateGray;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label127.ForeColor = System.Drawing.Color.Honeydew;
            this.label127.Location = new System.Drawing.Point(23, 112);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(50, 16);
            this.label127.TabIndex = 58;
            this.label127.Text = "Order *";
            // 
            // ddlOrder_ID
            // 
            this.ddlOrder_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOrder_ID.FormattingEnabled = true;
            this.ddlOrder_ID.Location = new System.Drawing.Point(133, 107);
            this.ddlOrder_ID.MaxLength = 50;
            this.ddlOrder_ID.Name = "ddlOrder_ID";
            this.ddlOrder_ID.Size = new System.Drawing.Size(256, 21);
            this.ddlOrder_ID.TabIndex = 4;
            this.ddlOrder_ID.SelectedIndexChanged += new System.EventHandler(this.ddlOrder_ID_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(23, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 64;
            this.label3.Text = "Item *";
            // 
            // ddlI_ID
            // 
            this.ddlI_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlI_ID.FormattingEnabled = true;
            this.ddlI_ID.ItemHeight = 13;
            this.ddlI_ID.Location = new System.Drawing.Point(133, 151);
            this.ddlI_ID.MaxDropDownItems = 100;
            this.ddlI_ID.MaxLength = 50;
            this.ddlI_ID.Name = "ddlI_ID";
            this.ddlI_ID.Size = new System.Drawing.Size(451, 21);
            this.ddlI_ID.TabIndex = 9;
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.Location = new System.Drawing.Point(266, 303);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 20;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdReset.Location = new System.Drawing.Point(322, 303);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(50, 51);
            this.cmdReset.TabIndex = 21;
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdEdit.Location = new System.Drawing.Point(434, 303);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(50, 51);
            this.cmdEdit.TabIndex = 23;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.Location = new System.Drawing.Point(378, 303);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 22;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(399, 420);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(220, 20);
            this.txt_Search.TabIndex = 25;
            // 
            // CmdSearch
            // 
            this.CmdSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.CmdSearch.Location = new System.Drawing.Point(640, 403);
            this.CmdSearch.Name = "CmdSearch";
            this.CmdSearch.Size = new System.Drawing.Size(50, 51);
            this.CmdSearch.TabIndex = 26;
            this.CmdSearch.UseVisualStyleBackColor = true;
            this.CmdSearch.Click += new System.EventHandler(this.CmdSearch_Click);
            // 
            // GridView1
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.GridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridView1.DefaultCellStyle = dataGridViewCellStyle10;
            this.GridView1.Location = new System.Drawing.Point(27, 461);
            this.GridView1.Name = "GridView1";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Orange;
            this.GridView1.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.GridView1.Size = new System.Drawing.Size(892, 127);
            this.GridView1.TabIndex = 92;
            this.GridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView1_RowHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(260, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 93;
            this.label1.Text = "Search By Order";
            // 
            // txtorderSearch
            // 
            this.txtorderSearch.Location = new System.Drawing.Point(402, 108);
            this.txtorderSearch.MaxLength = 10;
            this.txtorderSearch.Name = "txtorderSearch";
            this.txtorderSearch.Size = new System.Drawing.Size(117, 20);
            this.txtorderSearch.TabIndex = 94;
            // 
            // cmdOrderSearch
            // 
            this.cmdOrderSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.cmdOrderSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdOrderSearch.Location = new System.Drawing.Point(540, 96);
            this.cmdOrderSearch.Name = "cmdOrderSearch";
            this.cmdOrderSearch.Size = new System.Drawing.Size(41, 45);
            this.cmdOrderSearch.TabIndex = 95;
            this.cmdOrderSearch.UseVisualStyleBackColor = true;
            this.cmdOrderSearch.Click += new System.EventHandler(this.cmdOrderSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(23, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 97;
            this.label2.Text = "Type *";
            // 
            // txtPSPM_Type
            // 
            this.txtPSPM_Type.Location = new System.Drawing.Point(133, 188);
            this.txtPSPM_Type.MaxLength = 50;
            this.txtPSPM_Type.Name = "txtPSPM_Type";
            this.txtPSPM_Type.Size = new System.Drawing.Size(452, 20);
            this.txtPSPM_Type.TabIndex = 96;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ddlM_ID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPSPM_Type);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdOrderSearch);
            this.panel1.Controls.Add(this.txtorderSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.GridView1);
            this.panel1.Controls.Add(this.CmdSearch);
            this.panel1.Controls.Add(this.txt_Search);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.ddlI_ID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ddlOrder_ID);
            this.panel1.Controls.Add(this.label127);
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Controls.Add(this.txtPSST_Dt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPSST_ID);
            this.panel1.Controls.Add(this.label125);
            this.panel1.Location = new System.Drawing.Point(41, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 698);
            this.panel1.TabIndex = 175;
            // 
            // ddlM_ID
            // 
            this.ddlM_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlM_ID.FormattingEnabled = true;
            this.ddlM_ID.ItemHeight = 13;
            this.ddlM_ID.Location = new System.Drawing.Point(134, 224);
            this.ddlM_ID.MaxDropDownItems = 100;
            this.ddlM_ID.MaxLength = 50;
            this.ddlM_ID.Name = "ddlM_ID";
            this.ddlM_ID.Size = new System.Drawing.Size(451, 21);
            this.ddlM_ID.TabIndex = 98;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(24, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 99;
            this.label4.Text = "Machine *";
            // 
            // RPeP_PlanningMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(999, 664);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Name = "RPeP_PlanningMachine";
            this.Text = "RPeP_PlanningMachine";
            this.Load += new System.EventHandler(this.RPeP_PlanningMachine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.TextBox txtPSST_ID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPSST_Dt;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.ComboBox ddlOrder_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlI_ID;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button CmdSearch;
        private System.Windows.Forms.DataGridView GridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtorderSearch;
        private System.Windows.Forms.Button cmdOrderSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPSPM_Type;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ddlM_ID;
        private System.Windows.Forms.Label label4;
    }
}