namespace ePacker1
{
    partial class RPeP_MasterPositive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPeP_MasterPositive));
            this.ddlA_ID = new System.Windows.Forms.ComboBox();
            this.ddlGrp_ID = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtPtve_Qty_RO = new System.Windows.Forms.TextBox();
            this.txtPtve_Qty_CS = new System.Windows.Forms.TextBox();
            this.txtPtve_Qty_OS = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdAgentSearch = new System.Windows.Forms.Button();
            this.txtPtve_ID = new System.Windows.Forms.TextBox();
            this.cmdPtve_File2 = new System.Windows.Forms.Button();
            this.btnPtve_File1 = new System.Windows.Forms.Button();
            this.txtAgentSearch = new System.Windows.Forms.TextBox();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.txtPtve_File1 = new System.Windows.Forms.TextBox();
            this.txtPtve_File2 = new System.Windows.Forms.TextBox();
            this.txtPtve_Name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlPtve_Active = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMasterPositive = new System.Windows.Forms.DataGridView();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtA_Name_Search = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdExcelReport = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterPositive)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlA_ID
            // 
            this.ddlA_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlA_ID.FormattingEnabled = true;
            this.ddlA_ID.Location = new System.Drawing.Point(221, 34);
            this.ddlA_ID.MaxLength = 5;
            this.ddlA_ID.Name = "ddlA_ID";
            this.ddlA_ID.Size = new System.Drawing.Size(206, 21);
            this.ddlA_ID.TabIndex = 4;
            this.toolTip1.SetToolTip(this.ddlA_ID, "Select Agent");
            // 
            // ddlGrp_ID
            // 
            this.ddlGrp_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrp_ID.FormattingEnabled = true;
            this.ddlGrp_ID.Location = new System.Drawing.Point(142, -2);
            this.ddlGrp_ID.MaxLength = 5;
            this.ddlGrp_ID.Name = "ddlGrp_ID";
            this.ddlGrp_ID.Size = new System.Drawing.Size(206, 21);
            this.ddlGrp_ID.TabIndex = 1;
            this.toolTip1.SetToolTip(this.ddlGrp_ID, "Select Group");
            this.ddlGrp_ID.Visible = false;
            this.ddlGrp_ID.SelectedValueChanged += new System.EventHandler(this.ddlGrp_ID_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.txtPtve_Qty_RO);
            this.panel1.Controls.Add(this.txtPtve_Qty_CS);
            this.panel1.Controls.Add(this.txtPtve_Qty_OS);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmdAgentSearch);
            this.panel1.Controls.Add(this.txtPtve_ID);
            this.panel1.Controls.Add(this.cmdPtve_File2);
            this.panel1.Controls.Add(this.btnPtve_File1);
            this.panel1.Controls.Add(this.txtAgentSearch);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdReset);
            this.panel1.Controls.Add(this.cmdSubmit);
            this.panel1.Controls.Add(this.txtPtve_File1);
            this.panel1.Controls.Add(this.txtPtve_File2);
            this.panel1.Controls.Add(this.txtPtve_Name);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ddlPtve_Active);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ddlA_ID);
            this.panel1.Controls.Add(this.ddlGrp_ID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(48, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 503);
            this.panel1.TabIndex = 2;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Close;
            this.cmdCancel.Location = new System.Drawing.Point(452, 353);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(50, 51);
            this.cmdCancel.TabIndex = 17;
            this.toolTip1.SetToolTip(this.cmdCancel, "Cancel");
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtPtve_Qty_RO
            // 
            this.txtPtve_Qty_RO.Location = new System.Drawing.Point(221, 270);
            this.txtPtve_Qty_RO.MaxLength = 50;
            this.txtPtve_Qty_RO.Name = "txtPtve_Qty_RO";
            this.txtPtve_Qty_RO.Size = new System.Drawing.Size(206, 20);
            this.txtPtve_Qty_RO.TabIndex = 12;
            this.txtPtve_Qty_RO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPtve_Qty_RO_KeyPress);
            // 
            // txtPtve_Qty_CS
            // 
            this.txtPtve_Qty_CS.Location = new System.Drawing.Point(221, 237);
            this.txtPtve_Qty_CS.MaxLength = 50;
            this.txtPtve_Qty_CS.Name = "txtPtve_Qty_CS";
            this.txtPtve_Qty_CS.Size = new System.Drawing.Size(206, 20);
            this.txtPtve_Qty_CS.TabIndex = 11;
            this.txtPtve_Qty_CS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPtve_Qty_CS_KeyPress);
            // 
            // txtPtve_Qty_OS
            // 
            this.txtPtve_Qty_OS.Location = new System.Drawing.Point(221, 199);
            this.txtPtve_Qty_OS.MaxLength = 50;
            this.txtPtve_Qty_OS.Name = "txtPtve_Qty_OS";
            this.txtPtve_Qty_OS.Size = new System.Drawing.Size(206, 20);
            this.txtPtve_Qty_OS.TabIndex = 10;
            this.txtPtve_Qty_OS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPtve_Qty_OS_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Honeydew;
            this.label11.Location = new System.Drawing.Point(75, 274);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "Re-order Level (Qty.)*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Honeydew;
            this.label10.Location = new System.Drawing.Point(75, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Closing Stock (Qty.)*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Honeydew;
            this.label9.Location = new System.Drawing.Point(75, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Opening Stock (Qty.)*";
            // 
            // cmdAgentSearch
            // 
            this.cmdAgentSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search1;
            this.cmdAgentSearch.Location = new System.Drawing.Point(591, 3);
            this.cmdAgentSearch.Name = "cmdAgentSearch";
            this.cmdAgentSearch.Size = new System.Drawing.Size(50, 51);
            this.cmdAgentSearch.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmdAgentSearch, "Serach Agent");
            this.cmdAgentSearch.UseVisualStyleBackColor = true;
            this.cmdAgentSearch.Click += new System.EventHandler(this.cmdAgentSearch_Click);
            // 
            // txtPtve_ID
            // 
            this.txtPtve_ID.Location = new System.Drawing.Point(466, -1);
            this.txtPtve_ID.Name = "txtPtve_ID";
            this.txtPtve_ID.Size = new System.Drawing.Size(109, 20);
            this.txtPtve_ID.TabIndex = 15;
            // 
            // cmdPtve_File2
            // 
            this.cmdPtve_File2.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search1;
            this.cmdPtve_File2.Location = new System.Drawing.Point(466, 139);
            this.cmdPtve_File2.Name = "cmdPtve_File2";
            this.cmdPtve_File2.Size = new System.Drawing.Size(50, 51);
            this.cmdPtve_File2.TabIndex = 8;
            this.toolTip1.SetToolTip(this.cmdPtve_File2, "Browse");
            this.cmdPtve_File2.UseVisualStyleBackColor = true;
            this.cmdPtve_File2.Click += new System.EventHandler(this.cmdPtve_File2_Click);
            // 
            // btnPtve_File1
            // 
            this.btnPtve_File1.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search1;
            this.btnPtve_File1.Location = new System.Drawing.Point(466, 82);
            this.btnPtve_File1.Name = "btnPtve_File1";
            this.btnPtve_File1.Size = new System.Drawing.Size(50, 51);
            this.btnPtve_File1.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnPtve_File1, "Browse");
            this.btnPtve_File1.UseVisualStyleBackColor = true;
            this.btnPtve_File1.Click += new System.EventHandler(this.btnPtve_File1_Click);
            // 
            // txtAgentSearch
            // 
            this.txtAgentSearch.Location = new System.Drawing.Point(466, 34);
            this.txtAgentSearch.Name = "txtAgentSearch";
            this.txtAgentSearch.Size = new System.Drawing.Size(109, 20);
            this.txtAgentSearch.TabIndex = 2;
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Edit;
            this.cmdEdit.Location = new System.Drawing.Point(394, 353);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(50, 51);
            this.cmdEdit.TabIndex = 16;
            this.toolTip1.SetToolTip(this.cmdEdit, "Edit");
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Refresh;
            this.cmdReset.Location = new System.Drawing.Point(338, 353);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(50, 51);
            this.cmdReset.TabIndex = 15;
            this.toolTip1.SetToolTip(this.cmdReset, "Refresh");
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_AddNew;
            this.cmdSubmit.Location = new System.Drawing.Point(282, 353);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(50, 51);
            this.cmdSubmit.TabIndex = 14;
            this.toolTip1.SetToolTip(this.cmdSubmit, "Submit");
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // txtPtve_File1
            // 
            this.txtPtve_File1.Location = new System.Drawing.Point(221, 106);
            this.txtPtve_File1.MaxLength = 50;
            this.txtPtve_File1.Name = "txtPtve_File1";
            this.txtPtve_File1.Size = new System.Drawing.Size(206, 20);
            this.txtPtve_File1.TabIndex = 7;
            this.txtPtve_File1.TextChanged += new System.EventHandler(this.txtPtve_File1_TextChanged);
            this.txtPtve_File1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPtve_File1_KeyPress);
            // 
            // txtPtve_File2
            // 
            this.txtPtve_File2.Location = new System.Drawing.Point(221, 155);
            this.txtPtve_File2.MaxLength = 50;
            this.txtPtve_File2.Name = "txtPtve_File2";
            this.txtPtve_File2.Size = new System.Drawing.Size(206, 20);
            this.txtPtve_File2.TabIndex = 9;
            this.txtPtve_File2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPtve_File2_KeyPress);
            // 
            // txtPtve_Name
            // 
            this.txtPtve_Name.Location = new System.Drawing.Point(221, 69);
            this.txtPtve_Name.MaxLength = 50;
            this.txtPtve_Name.Name = "txtPtve_Name";
            this.txtPtve_Name.Size = new System.Drawing.Size(206, 20);
            this.txtPtve_Name.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtPtve_Name, "Enter Positive Name");
            this.txtPtve_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPtve_Name_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Honeydew;
            this.label6.Location = new System.Drawing.Point(75, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Active *";
            // 
            // ddlPtve_Active
            // 
            this.ddlPtve_Active.FormattingEnabled = true;
            this.ddlPtve_Active.Location = new System.Drawing.Point(221, 305);
            this.ddlPtve_Active.MaxLength = 3;
            this.ddlPtve_Active.Name = "ddlPtve_Active";
            this.ddlPtve_Active.Size = new System.Drawing.Size(206, 21);
            this.ddlPtve_Active.TabIndex = 13;
            this.toolTip1.SetToolTip(this.ddlPtve_Active, "Select Active State");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Honeydew;
            this.label5.Location = new System.Drawing.Point(75, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "File 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Honeydew;
            this.label4.Location = new System.Drawing.Point(75, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "File 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Honeydew;
            this.label3.Location = new System.Drawing.Point(75, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Positive Name *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Honeydew;
            this.label2.Location = new System.Drawing.Point(77, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Agent *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(-4, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group *";
            this.label1.Visible = false;
            // 
            // dgvMasterPositive
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMasterPositive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMasterPositive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMasterPositive.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMasterPositive.Location = new System.Drawing.Point(48, 586);
            this.dgvMasterPositive.Name = "dgvMasterPositive";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMasterPositive.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            this.dgvMasterPositive.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMasterPositive.Size = new System.Drawing.Size(669, 139);
            this.dgvMasterPositive.TabIndex = 20;
            this.dgvMasterPositive.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMasterPositive_RowHeaderMouseClick);
            this.dgvMasterPositive.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMasterPositive_CellContentClick);
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackgroundImage = global::ePacker1.Properties.Resources.ePacker_Search;
            this.cmdSearch.Location = new System.Drawing.Point(331, 495);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(50, 51);
            this.cmdSearch.TabIndex = 19;
            this.toolTip1.SetToolTip(this.cmdSearch, "Search Agent");
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Honeydew;
            this.label7.Location = new System.Drawing.Point(124, 527);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Agent *";
            // 
            // txtA_Name_Search
            // 
            this.txtA_Name_Search.Location = new System.Drawing.Point(192, 526);
            this.txtA_Name_Search.Name = "txtA_Name_Search";
            this.txtA_Name_Search.Size = new System.Drawing.Size(121, 20);
            this.txtA_Name_Search.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOrange;
            this.label8.Location = new System.Drawing.Point(248, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(274, 31);
            this.label8.TabIndex = 7;
            this.label8.Text = "Positive Management";
            // 
            // cmdExcelReport
            // 
            this.cmdExcelReport.BackgroundImage = global::ePacker1.Properties.Resources.Excel_Icon;
            this.cmdExcelReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExcelReport.Location = new System.Drawing.Point(387, 495);
            this.cmdExcelReport.Name = "cmdExcelReport";
            this.cmdExcelReport.Size = new System.Drawing.Size(50, 48);
            this.cmdExcelReport.TabIndex = 21;
            this.cmdExcelReport.UseVisualStyleBackColor = false;
            this.cmdExcelReport.Click += new System.EventHandler(this.cmdExcelReport_Click);
            // 
            // RPeP_MasterPositive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(5, 100);
            this.AutoScrollMinSize = new System.Drawing.Size(5, 100);
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.Controls.Add(this.cmdExcelReport);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtA_Name_Search);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.dgvMasterPositive);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RPeP_MasterPositive";
            this.Text = "RPeP_MasterPositive";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPeP_MasterPositive_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterPositive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlA_ID;
        private System.Windows.Forms.ComboBox ddlGrp_ID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPtve_File1;
        private System.Windows.Forms.TextBox txtPtve_File2;
        private System.Windows.Forms.TextBox txtPtve_Name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlPtve_Active;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdPtve_File2;
        private System.Windows.Forms.Button btnPtve_File1;
        private System.Windows.Forms.TextBox txtAgentSearch;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.DataGridView dgvMasterPositive;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtA_Name_Search;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPtve_ID;
        private System.Windows.Forms.Button cmdAgentSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtPtve_Qty_RO;
        private System.Windows.Forms.TextBox txtPtve_Qty_CS;
        private System.Windows.Forms.TextBox txtPtve_Qty_OS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdExcelReport;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}