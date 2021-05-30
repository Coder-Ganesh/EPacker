namespace ePacker1
{
    partial class RPeP_CityMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_CityMaster));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtCity_Name = new System.Windows.Forms.TextBox();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.dgWCityDetails = new System.Windows.Forms.DataGridView();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblCityDetail = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWCityDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.cmdClose);
            this.Panel1.Controls.Add(this.txtCity_Name);
            this.Panel1.Controls.Add(this.cmdInsert);
            this.Panel1.Controls.Add(this.dgWCityDetails);
            this.Panel1.Controls.Add(this.lblCity);
            this.Panel1.Location = new System.Drawing.Point(111, 79);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(426, 331);
            this.Panel1.TabIndex = 0;
            // 
            // cmdClose
            // 
            this.cmdClose.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(271, 65);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(50, 48);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtCity_Name
            // 
            this.txtCity_Name.Location = new System.Drawing.Point(100, 93);
            this.txtCity_Name.Name = "txtCity_Name";
            this.txtCity_Name.Size = new System.Drawing.Size(100, 20);
            this.txtCity_Name.TabIndex = 3;
            this.txtCity_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCity_Name_KeyPress);
            // 
            // cmdInsert
            // 
            this.cmdInsert.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsert.Location = new System.Drawing.Point(215, 65);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(50, 48);
            this.cmdInsert.TabIndex = 2;
            this.cmdInsert.UseVisualStyleBackColor = true;
            this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
            // 
            // dgWCityDetails
            // 
            this.dgWCityDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWCityDetails.Location = new System.Drawing.Point(52, 139);
            this.dgWCityDetails.Name = "dgWCityDetails";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgWCityDetails.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgWCityDetails.Size = new System.Drawing.Size(300, 120);
            this.dgWCityDetails.TabIndex = 1;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.ForeColor = System.Drawing.Color.Honeydew;
            this.lblCity.Location = new System.Drawing.Point(49, 94);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(30, 16);
            this.lblCity.TabIndex = 0;
            this.lblCity.Text = "City";
            // 
            // lblCityDetail
            // 
            this.lblCityDetail.AutoSize = true;
            this.lblCityDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCityDetail.ForeColor = System.Drawing.Color.Orange;
            this.lblCityDetail.Location = new System.Drawing.Point(246, 30);
            this.lblCityDetail.Name = "lblCityDetail";
            this.lblCityDetail.Size = new System.Drawing.Size(153, 31);
            this.lblCityDetail.TabIndex = 0;
            this.lblCityDetail.Text = "City Details";
            // 
            // RPeP_CityMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(644, 521);
            this.Controls.Add(this.lblCityDetail);
            this.Controls.Add(this.Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_CityMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPeP_CityMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPeP_CityMaster_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWCityDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.DataGridView dgWCityDetails;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblCityDetail;
        private System.Windows.Forms.TextBox txtCity_Name;
        private System.Windows.Forms.Button cmdInsert;
        private System.Windows.Forms.Button cmdClose;
    }
}