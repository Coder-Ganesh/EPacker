﻿namespace ePacker1
{
    partial class RPeP_PrintingStereo
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
            this.txtorderSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdOrderSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GridView1 = new System.Windows.Forms.DataGridView();
            this.CmdSearch = new System.Windows.Forms.Button();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.txtPSPR_ContrTime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ddlS_ID = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPSPR_Mfg = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPSPR_NoColrs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPSPR_Paper = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlM_ID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlOrder_ID = new System.Windows.Forms.ComboBox();
            this.label127 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtPSPR_Dt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPSPR_ID = new System.Windows.Forms.TextBox();
            this.label125 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtorderSearch
            // 
            this.txtorderSearch.Location = new System.Drawing.Point(402, 108);
            this.txtorderSearch.MaxLength = 10;
            this.txtorderSearch.Name = "txtorderSearch";
            this.txtorderSearch.Size = new System.Drawing.Size(117, 20);
            this.txtorderSearch.TabIndex = 94;
            // 
            // panel1
            // 
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
            this.panel1.Controls.Add(this.txtPSPR_ContrTime);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.ddlS_ID);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtPSPR_Mfg);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtPSPR_NoColrs);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPSPR_Paper);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ddlM_ID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ddlOrder_ID);
            this.panel1.Controls.Add(this.label127);
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Controls.Add(this.txtPSPR_Dt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPSPR_ID);
            this.panel1.Controls.Add(this.label125);
            this.panel1.Location = new System.Drawing.Point(34, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 698);
            this.panel1.TabIndex = 165;
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(260, 470);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 93;
            this.label1.Text = "Search By Order";
            // 
            // GridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridView1.Location = new System.Drawing.Point(27, 511);
            this.GridView1.Name = "GridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.GridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.GridView1.Size = new System.Drawing.Size(892, 127);
            this.GridView1.TabIndex = 92;
            this.GridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView1_RowHeaderMouseClick);
            // 
            // CmdSearch
            // 
            this.CmdSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.CmdSearch.Location = new System.Drawing.Point(640, 453);
            this.CmdSearch.Name = "CmdSearch";
            this.CmdSearch.Size = new System.Drawing.Size(50, 51);
            this.CmdSearch.TabIndex = 26;
            this.CmdSearch.UseVisualStyleBackColor = true;
            this.CmdSearch.Click += new System.EventHandler(this.CmdSearch_Click);
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(399, 470);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(220, 20);
            this.txt_Search.TabIndex = 25;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.Location = new System.Drawing.Point(378, 388);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 22;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdEdit.Location = new System.Drawing.Point(434, 388);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(50, 51);
            this.cmdEdit.TabIndex = 23;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdReset.Location = new System.Drawing.Point(322, 388);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(50, 51);
            this.cmdReset.TabIndex = 21;
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.Location = new System.Drawing.Point(266, 388);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 20;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // txtPSPR_ContrTime
            // 
            this.txtPSPR_ContrTime.Location = new System.Drawing.Point(132, 346);
            this.txtPSPR_ContrTime.MaxLength = 20;
            this.txtPSPR_ContrTime.Multiline = true;
            this.txtPSPR_ContrTime.Name = "txtPSPR_ContrTime";
            this.txtPSPR_ContrTime.Size = new System.Drawing.Size(452, 20);
            this.txtPSPR_ContrTime.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Honeydew;
            this.label11.Location = new System.Drawing.Point(22, 347);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 33);
            this.label11.TabIndex = 81;
            this.label11.Text = "Contract Time *";
            // 
            // ddlS_ID
            // 
            this.ddlS_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlS_ID.FormattingEnabled = true;
            this.ddlS_ID.ItemHeight = 13;
            this.ddlS_ID.Location = new System.Drawing.Point(133, 302);
            this.ddlS_ID.MaxDropDownItems = 100;
            this.ddlS_ID.MaxLength = 50;
            this.ddlS_ID.Name = "ddlS_ID";
            this.ddlS_ID.Size = new System.Drawing.Size(451, 21);
            this.ddlS_ID.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Honeydew;
            this.label10.Location = new System.Drawing.Point(23, 307);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 76;
            this.label10.Text = "Shift *";
            // 
            // txtPSPR_Mfg
            // 
            this.txtPSPR_Mfg.Location = new System.Drawing.Point(133, 263);
            this.txtPSPR_Mfg.MaxLength = 50;
            this.txtPSPR_Mfg.Name = "txtPSPR_Mfg";
            this.txtPSPR_Mfg.Size = new System.Drawing.Size(452, 20);
            this.txtPSPR_Mfg.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Honeydew;
            this.label9.Location = new System.Drawing.Point(23, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 16);
            this.label9.TabIndex = 74;
            this.label9.Text = "Manufacturing. *";
            // 
            // txtPSPR_NoColrs
            // 
            this.txtPSPR_NoColrs.Location = new System.Drawing.Point(133, 223);
            this.txtPSPR_NoColrs.MaxLength = 20;
            this.txtPSPR_NoColrs.Name = "txtPSPR_NoColrs";
            this.txtPSPR_NoColrs.Size = new System.Drawing.Size(452, 20);
            this.txtPSPR_NoColrs.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(23, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 70;
            this.label5.Text = "No.of Colors  *";
            // 
            // txtPSPR_Paper
            // 
            this.txtPSPR_Paper.Location = new System.Drawing.Point(133, 190);
            this.txtPSPR_Paper.MaxLength = 20;
            this.txtPSPR_Paper.Name = "txtPSPR_Paper";
            this.txtPSPR_Paper.Size = new System.Drawing.Size(452, 20);
            this.txtPSPR_Paper.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(23, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 68;
            this.label4.Text = "Paper *";
            // 
            // ddlM_ID
            // 
            this.ddlM_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlM_ID.FormattingEnabled = true;
            this.ddlM_ID.ItemHeight = 13;
            this.ddlM_ID.Location = new System.Drawing.Point(133, 147);
            this.ddlM_ID.MaxDropDownItems = 100;
            this.ddlM_ID.MaxLength = 50;
            this.ddlM_ID.Name = "ddlM_ID";
            this.ddlM_ID.Size = new System.Drawing.Size(451, 21);
            this.ddlM_ID.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(23, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 64;
            this.label3.Text = "Machine *";
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
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(608, 9);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.LightSlateGray;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // txtPSPR_Dt
            // 
            this.txtPSPR_Dt.Location = new System.Drawing.Point(133, 69);
            this.txtPSPR_Dt.MaxLength = 10;
            this.txtPSPR_Dt.Name = "txtPSPR_Dt";
            this.txtPSPR_Dt.Size = new System.Drawing.Size(452, 20);
            this.txtPSPR_Dt.TabIndex = 2;
            this.txtPSPR_Dt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPSSC_Dt_MouseClick);
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
            // txtPSPR_ID
            // 
            this.txtPSPR_ID.Enabled = false;
            this.txtPSPR_ID.Location = new System.Drawing.Point(133, 31);
            this.txtPSPR_ID.MaxLength = 100;
            this.txtPSPR_ID.Name = "txtPSPR_ID";
            this.txtPSPR_ID.Size = new System.Drawing.Size(165, 20);
            this.txtPSPR_ID.TabIndex = 1;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(267, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(721, 31);
            this.label7.TabIndex = 164;
            this.label7.Text = "Production Card For Top Printing (Not Paper Printed)          ";
            // 
            // RPeP_PrintingStereo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Name = "RPeP_PrintingStereo";
            this.Text = "RPeP_PrintingStereo";
            this.Load += new System.EventHandler(this.RPeP_PrintingStereo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOrderSearch;
        private System.Windows.Forms.TextBox txtorderSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GridView1;
        private System.Windows.Forms.Button CmdSearch;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.TextBox txtPSPR_ContrTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddlS_ID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPSPR_Mfg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPSPR_NoColrs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPSPR_Paper;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlM_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlOrder_ID;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox txtPSPR_Dt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPSPR_ID;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.Label label7;
    }
}