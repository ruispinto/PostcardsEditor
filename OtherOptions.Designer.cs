
namespace PostcardsEditor
{
    partial class OtherOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OtherOptions));
            this.dataGridOthers = new System.Windows.Forms.DataGridView();
            this.r_coloring = new System.Windows.Forms.RadioButton();
            this.r_cond = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.r_country = new System.Windows.Forms.RadioButton();
            this.r_material = new System.Windows.Forms.RadioButton();
            this.r_orient = new System.Windows.Forms.RadioButton();
            this.r_publisher = new System.Windows.Forms.RadioButton();
            this.r_shape = new System.Windows.Forms.RadioButton();
            this.r_sentType = new System.Windows.Forms.RadioButton();
            this.r_size = new System.Windows.Forms.RadioButton();
            this.r_theme = new System.Windows.Forms.RadioButton();
            this.r_year = new System.Windows.Forms.RadioButton();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_closeOthers = new System.Windows.Forms.Button();
            this.btn_excelTable = new System.Windows.Forms.Button();
            this.btn_deleteOthers = new System.Windows.Forms.Button();
            this.chk_deleteOthers = new System.Windows.Forms.CheckBox();
            this.btn_editOthers = new System.Windows.Forms.Button();
            this.btn_addOthers = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gb_table = new System.Windows.Forms.GroupBox();
            this.lbl_tableName = new System.Windows.Forms.Label();
            this.saveTablesDiaglog = new System.Windows.Forms.SaveFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chk_updateOther = new System.Windows.Forms.CheckBox();
            this.btn_closeOthersPanel = new System.Windows.Forms.Button();
            this.btn_saveOthersPanel = new System.Windows.Forms.Button();
            this.txt_otherOptionsField3 = new System.Windows.Forms.TextBox();
            this.txt_otherOptionsField2 = new System.Windows.Forms.TextBox();
            this.txt_otherOptionsField1 = new System.Windows.Forms.TextBox();
            this.lbl_otherOptField3 = new System.Windows.Forms.Label();
            this.lbl_otherOptField2 = new System.Windows.Forms.Label();
            this.lbl_otherOptField1 = new System.Windows.Forms.Label();
            this.lbl_otherOptions = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOthers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gb_table.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridOthers
            // 
            this.dataGridOthers.AllowUserToAddRows = false;
            this.dataGridOthers.AllowUserToDeleteRows = false;
            this.dataGridOthers.AllowUserToResizeColumns = false;
            this.dataGridOthers.AllowUserToResizeRows = false;
            this.dataGridOthers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOthers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridOthers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridOthers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOthers.GridColor = System.Drawing.Color.DarkGreen;
            this.dataGridOthers.Location = new System.Drawing.Point(12, 116);
            this.dataGridOthers.Name = "dataGridOthers";
            this.dataGridOthers.ReadOnly = true;
            this.dataGridOthers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridOthers.Size = new System.Drawing.Size(741, 431);
            this.dataGridOthers.TabIndex = 0;
            this.dataGridOthers.TabStop = false;
            // 
            // r_coloring
            // 
            this.r_coloring.AutoSize = true;
            this.r_coloring.Location = new System.Drawing.Point(100, 20);
            this.r_coloring.Name = "r_coloring";
            this.r_coloring.Size = new System.Drawing.Size(82, 22);
            this.r_coloring.TabIndex = 1;
            this.r_coloring.TabStop = true;
            this.r_coloring.Text = "Coloring";
            this.r_coloring.UseVisualStyleBackColor = true;
            // 
            // r_cond
            // 
            this.r_cond.AutoSize = true;
            this.r_cond.Location = new System.Drawing.Point(100, 48);
            this.r_cond.Name = "r_cond";
            this.r_cond.Size = new System.Drawing.Size(89, 22);
            this.r_cond.TabIndex = 2;
            this.r_cond.TabStop = true;
            this.r_cond.Text = "Condition";
            this.r_cond.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 83);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose which table do you want to edit:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // r_country
            // 
            this.r_country.AutoSize = true;
            this.r_country.Location = new System.Drawing.Point(100, 76);
            this.r_country.Name = "r_country";
            this.r_country.Size = new System.Drawing.Size(78, 22);
            this.r_country.TabIndex = 3;
            this.r_country.TabStop = true;
            this.r_country.Text = "Country";
            this.r_country.UseVisualStyleBackColor = true;
            // 
            // r_material
            // 
            this.r_material.AutoSize = true;
            this.r_material.Location = new System.Drawing.Point(196, 20);
            this.r_material.Name = "r_material";
            this.r_material.Size = new System.Drawing.Size(78, 22);
            this.r_material.TabIndex = 4;
            this.r_material.TabStop = true;
            this.r_material.Text = "Material";
            this.r_material.UseVisualStyleBackColor = true;
            // 
            // r_orient
            // 
            this.r_orient.AutoSize = true;
            this.r_orient.Location = new System.Drawing.Point(196, 48);
            this.r_orient.Name = "r_orient";
            this.r_orient.Size = new System.Drawing.Size(98, 22);
            this.r_orient.TabIndex = 5;
            this.r_orient.TabStop = true;
            this.r_orient.Text = "Orientation";
            this.r_orient.UseVisualStyleBackColor = true;
            // 
            // r_publisher
            // 
            this.r_publisher.AutoSize = true;
            this.r_publisher.Location = new System.Drawing.Point(196, 76);
            this.r_publisher.Name = "r_publisher";
            this.r_publisher.Size = new System.Drawing.Size(87, 22);
            this.r_publisher.TabIndex = 6;
            this.r_publisher.TabStop = true;
            this.r_publisher.Text = "Publisher";
            this.r_publisher.UseVisualStyleBackColor = true;
            // 
            // r_shape
            // 
            this.r_shape.AutoSize = true;
            this.r_shape.Location = new System.Drawing.Point(300, 48);
            this.r_shape.Name = "r_shape";
            this.r_shape.Size = new System.Drawing.Size(68, 22);
            this.r_shape.TabIndex = 8;
            this.r_shape.TabStop = true;
            this.r_shape.Text = "Shape";
            this.r_shape.UseVisualStyleBackColor = true;
            // 
            // r_sentType
            // 
            this.r_sentType.AutoSize = true;
            this.r_sentType.Location = new System.Drawing.Point(300, 20);
            this.r_sentType.Name = "r_sentType";
            this.r_sentType.Size = new System.Drawing.Size(92, 22);
            this.r_sentType.TabIndex = 7;
            this.r_sentType.TabStop = true;
            this.r_sentType.Text = "Sent Type";
            this.r_sentType.UseVisualStyleBackColor = true;
            // 
            // r_size
            // 
            this.r_size.AutoSize = true;
            this.r_size.Location = new System.Drawing.Point(300, 76);
            this.r_size.Name = "r_size";
            this.r_size.Size = new System.Drawing.Size(55, 22);
            this.r_size.TabIndex = 9;
            this.r_size.TabStop = true;
            this.r_size.Text = "Size";
            this.r_size.UseVisualStyleBackColor = true;
            // 
            // r_theme
            // 
            this.r_theme.AutoSize = true;
            this.r_theme.Location = new System.Drawing.Point(413, 20);
            this.r_theme.Name = "r_theme";
            this.r_theme.Size = new System.Drawing.Size(72, 22);
            this.r_theme.TabIndex = 10;
            this.r_theme.TabStop = true;
            this.r_theme.Text = "Theme";
            this.r_theme.UseVisualStyleBackColor = true;
            // 
            // r_year
            // 
            this.r_year.AutoSize = true;
            this.r_year.Location = new System.Drawing.Point(413, 48);
            this.r_year.Name = "r_year";
            this.r_year.Size = new System.Drawing.Size(56, 22);
            this.r_year.TabIndex = 11;
            this.r_year.TabStop = true;
            this.r_year.Text = "Year";
            this.r_year.UseVisualStyleBackColor = true;
            // 
            // btn_open
            // 
            this.btn_open.BackColor = System.Drawing.Color.Silver;
            this.btn_open.ForeColor = System.Drawing.Color.Black;
            this.btn_open.Location = new System.Drawing.Point(501, 46);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(88, 30);
            this.btn_open.TabIndex = 12;
            this.btn_open.Text = "&Open";
            this.btn_open.UseVisualStyleBackColor = false;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_closeOthers
            // 
            this.btn_closeOthers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_closeOthers.BackColor = System.Drawing.Color.Silver;
            this.btn_closeOthers.ForeColor = System.Drawing.Color.Black;
            this.btn_closeOthers.Location = new System.Drawing.Point(666, 560);
            this.btn_closeOthers.Name = "btn_closeOthers";
            this.btn_closeOthers.Size = new System.Drawing.Size(88, 30);
            this.btn_closeOthers.TabIndex = 13;
            this.btn_closeOthers.Text = "&Close";
            this.btn_closeOthers.UseVisualStyleBackColor = false;
            this.btn_closeOthers.Click += new System.EventHandler(this.btn_closeOthers_Click);
            // 
            // btn_excelTable
            // 
            this.btn_excelTable.BackColor = System.Drawing.Color.Silver;
            this.btn_excelTable.ForeColor = System.Drawing.Color.Black;
            this.btn_excelTable.Location = new System.Drawing.Point(505, 9);
            this.btn_excelTable.Name = "btn_excelTable";
            this.btn_excelTable.Size = new System.Drawing.Size(116, 30);
            this.btn_excelTable.TabIndex = 14;
            this.btn_excelTable.Text = "Export to Excel";
            this.btn_excelTable.UseVisualStyleBackColor = false;
            this.btn_excelTable.Click += new System.EventHandler(this.btn_excelTable_Click);
            // 
            // btn_deleteOthers
            // 
            this.btn_deleteOthers.BackColor = System.Drawing.Color.Silver;
            this.btn_deleteOthers.ForeColor = System.Drawing.Color.Black;
            this.btn_deleteOthers.Location = new System.Drawing.Point(397, 9);
            this.btn_deleteOthers.Name = "btn_deleteOthers";
            this.btn_deleteOthers.Size = new System.Drawing.Size(88, 30);
            this.btn_deleteOthers.TabIndex = 18;
            this.btn_deleteOthers.Text = "Delete";
            this.btn_deleteOthers.UseVisualStyleBackColor = false;
            this.btn_deleteOthers.Click += new System.EventHandler(this.btn_deleteOthers_Click);
            // 
            // chk_deleteOthers
            // 
            this.chk_deleteOthers.AutoSize = true;
            this.chk_deleteOthers.Location = new System.Drawing.Point(380, 19);
            this.chk_deleteOthers.Name = "chk_deleteOthers";
            this.chk_deleteOthers.Size = new System.Drawing.Size(15, 14);
            this.chk_deleteOthers.TabIndex = 17;
            this.chk_deleteOthers.UseVisualStyleBackColor = true;
            this.chk_deleteOthers.CheckedChanged += new System.EventHandler(this.chk_deleteOthers_CheckedChanged);
            // 
            // btn_editOthers
            // 
            this.btn_editOthers.BackColor = System.Drawing.Color.Silver;
            this.btn_editOthers.ForeColor = System.Drawing.Color.Black;
            this.btn_editOthers.Location = new System.Drawing.Point(282, 9);
            this.btn_editOthers.Name = "btn_editOthers";
            this.btn_editOthers.Size = new System.Drawing.Size(88, 30);
            this.btn_editOthers.TabIndex = 16;
            this.btn_editOthers.Text = "E&dit";
            this.btn_editOthers.UseVisualStyleBackColor = false;
            this.btn_editOthers.Click += new System.EventHandler(this.btn_editOthers_Click);
            // 
            // btn_addOthers
            // 
            this.btn_addOthers.BackColor = System.Drawing.Color.Silver;
            this.btn_addOthers.ForeColor = System.Drawing.Color.Black;
            this.btn_addOthers.Location = new System.Drawing.Point(189, 9);
            this.btn_addOthers.Name = "btn_addOthers";
            this.btn_addOthers.Size = new System.Drawing.Size(88, 30);
            this.btn_addOthers.TabIndex = 15;
            this.btn_addOthers.Text = "&Add";
            this.btn_addOthers.UseVisualStyleBackColor = false;
            this.btn_addOthers.Click += new System.EventHandler(this.btn_addOthers_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.r_year);
            this.groupBox1.Controls.Add(this.btn_open);
            this.groupBox1.Controls.Add(this.r_coloring);
            this.groupBox1.Controls.Add(this.r_cond);
            this.groupBox1.Controls.Add(this.r_theme);
            this.groupBox1.Controls.Add(this.r_country);
            this.groupBox1.Controls.Add(this.r_size);
            this.groupBox1.Controls.Add(this.r_material);
            this.groupBox1.Controls.Add(this.r_sentType);
            this.groupBox1.Controls.Add(this.r_orient);
            this.groupBox1.Controls.Add(this.r_shape);
            this.groupBox1.Controls.Add(this.r_publisher);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 109);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // gb_table
            // 
            this.gb_table.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_table.Controls.Add(this.lbl_tableName);
            this.gb_table.Location = new System.Drawing.Point(615, 1);
            this.gb_table.Name = "gb_table";
            this.gb_table.Size = new System.Drawing.Size(139, 109);
            this.gb_table.TabIndex = 17;
            this.gb_table.TabStop = false;
            // 
            // lbl_tableName
            // 
            this.lbl_tableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tableName.Location = new System.Drawing.Point(19, 20);
            this.lbl_tableName.Name = "lbl_tableName";
            this.lbl_tableName.Size = new System.Drawing.Size(103, 78);
            this.lbl_tableName.TabIndex = 0;
            this.lbl_tableName.Text = "table name here";
            this.lbl_tableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel2.Controls.Add(this.chk_updateOther);
            this.panel2.Controls.Add(this.btn_closeOthersPanel);
            this.panel2.Controls.Add(this.btn_saveOthersPanel);
            this.panel2.Controls.Add(this.txt_otherOptionsField3);
            this.panel2.Controls.Add(this.txt_otherOptionsField2);
            this.panel2.Controls.Add(this.txt_otherOptionsField1);
            this.panel2.Controls.Add(this.lbl_otherOptField3);
            this.panel2.Controls.Add(this.lbl_otherOptField2);
            this.panel2.Controls.Add(this.lbl_otherOptField1);
            this.panel2.Controls.Add(this.lbl_otherOptions);
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panel2.Location = new System.Drawing.Point(4, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 200);
            this.panel2.TabIndex = 18;
            // 
            // chk_updateOther
            // 
            this.chk_updateOther.AutoSize = true;
            this.chk_updateOther.Location = new System.Drawing.Point(366, 159);
            this.chk_updateOther.Name = "chk_updateOther";
            this.chk_updateOther.Size = new System.Drawing.Size(74, 22);
            this.chk_updateOther.TabIndex = 11;
            this.chk_updateOther.Text = "Update";
            this.chk_updateOther.UseVisualStyleBackColor = true;
            this.chk_updateOther.CheckedChanged += new System.EventHandler(this.chk_updateOther_CheckedChanged);
            // 
            // btn_closeOthersPanel
            // 
            this.btn_closeOthersPanel.BackColor = System.Drawing.Color.Silver;
            this.btn_closeOthersPanel.ForeColor = System.Drawing.Color.Black;
            this.btn_closeOthersPanel.Location = new System.Drawing.Point(589, 152);
            this.btn_closeOthersPanel.Name = "btn_closeOthersPanel";
            this.btn_closeOthersPanel.Size = new System.Drawing.Size(75, 35);
            this.btn_closeOthersPanel.TabIndex = 10;
            this.btn_closeOthersPanel.Text = "&Close";
            this.btn_closeOthersPanel.UseVisualStyleBackColor = false;
            this.btn_closeOthersPanel.Click += new System.EventHandler(this.btn_closeOthersPanel_Click);
            // 
            // btn_saveOthersPanel
            // 
            this.btn_saveOthersPanel.BackColor = System.Drawing.Color.Silver;
            this.btn_saveOthersPanel.ForeColor = System.Drawing.Color.Black;
            this.btn_saveOthersPanel.Location = new System.Drawing.Point(446, 152);
            this.btn_saveOthersPanel.Name = "btn_saveOthersPanel";
            this.btn_saveOthersPanel.Size = new System.Drawing.Size(75, 35);
            this.btn_saveOthersPanel.TabIndex = 9;
            this.btn_saveOthersPanel.Text = "&Save";
            this.btn_saveOthersPanel.UseVisualStyleBackColor = false;
            this.btn_saveOthersPanel.Click += new System.EventHandler(this.btn_saveOthersPanel_Click);
            // 
            // txt_otherOptionsField3
            // 
            this.txt_otherOptionsField3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_otherOptionsField3.Location = new System.Drawing.Point(209, 115);
            this.txt_otherOptionsField3.Name = "txt_otherOptionsField3";
            this.txt_otherOptionsField3.Size = new System.Drawing.Size(455, 24);
            this.txt_otherOptionsField3.TabIndex = 7;
            // 
            // txt_otherOptionsField2
            // 
            this.txt_otherOptionsField2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_otherOptionsField2.Location = new System.Drawing.Point(209, 79);
            this.txt_otherOptionsField2.Name = "txt_otherOptionsField2";
            this.txt_otherOptionsField2.Size = new System.Drawing.Size(455, 24);
            this.txt_otherOptionsField2.TabIndex = 6;
            // 
            // txt_otherOptionsField1
            // 
            this.txt_otherOptionsField1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_otherOptionsField1.Location = new System.Drawing.Point(209, 44);
            this.txt_otherOptionsField1.Name = "txt_otherOptionsField1";
            this.txt_otherOptionsField1.Size = new System.Drawing.Size(455, 24);
            this.txt_otherOptionsField1.TabIndex = 5;
            // 
            // lbl_otherOptField3
            // 
            this.lbl_otherOptField3.Location = new System.Drawing.Point(17, 118);
            this.lbl_otherOptField3.Name = "lbl_otherOptField3";
            this.lbl_otherOptField3.Size = new System.Drawing.Size(191, 18);
            this.lbl_otherOptField3.TabIndex = 3;
            this.lbl_otherOptField3.Text = "Field3";
            this.lbl_otherOptField3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_otherOptField2
            // 
            this.lbl_otherOptField2.Location = new System.Drawing.Point(17, 82);
            this.lbl_otherOptField2.Name = "lbl_otherOptField2";
            this.lbl_otherOptField2.Size = new System.Drawing.Size(191, 18);
            this.lbl_otherOptField2.TabIndex = 2;
            this.lbl_otherOptField2.Text = "Field2";
            this.lbl_otherOptField2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_otherOptField1
            // 
            this.lbl_otherOptField1.Location = new System.Drawing.Point(17, 46);
            this.lbl_otherOptField1.Name = "lbl_otherOptField1";
            this.lbl_otherOptField1.Size = new System.Drawing.Size(191, 18);
            this.lbl_otherOptField1.TabIndex = 1;
            this.lbl_otherOptField1.Text = "Field1";
            this.lbl_otherOptField1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_otherOptions
            // 
            this.lbl_otherOptions.AutoSize = true;
            this.lbl_otherOptions.Location = new System.Drawing.Point(14, 17);
            this.lbl_otherOptions.Name = "lbl_otherOptions";
            this.lbl_otherOptions.Size = new System.Drawing.Size(70, 18);
            this.lbl_otherOptions.TabIndex = 0;
            this.lbl_otherOptions.Text = "Add / Edit";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btn_deleteOthers);
            this.groupBox2.Controls.Add(this.chk_deleteOthers);
            this.groupBox2.Controls.Add(this.btn_excelTable);
            this.groupBox2.Controls.Add(this.btn_editOthers);
            this.groupBox2.Controls.Add(this.btn_addOthers);
            this.groupBox2.Location = new System.Drawing.Point(12, 551);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(639, 42);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // OtherOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(766, 602);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_closeOthers);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gb_table);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridOthers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OtherOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Other Options";
            this.Load += new System.EventHandler(this.OtherOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOthers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_table.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridOthers;
        private System.Windows.Forms.RadioButton r_coloring;
        private System.Windows.Forms.RadioButton r_cond;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton r_country;
        private System.Windows.Forms.RadioButton r_material;
        private System.Windows.Forms.RadioButton r_orient;
        private System.Windows.Forms.RadioButton r_publisher;
        private System.Windows.Forms.RadioButton r_shape;
        private System.Windows.Forms.RadioButton r_size;
        private System.Windows.Forms.RadioButton r_theme;
        private System.Windows.Forms.RadioButton r_year;
        private System.Windows.Forms.RadioButton r_sentType;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_closeOthers;
        private System.Windows.Forms.Button btn_excelTable;
        private System.Windows.Forms.CheckBox chk_deleteOthers;
        private System.Windows.Forms.Button btn_editOthers;
        private System.Windows.Forms.Button btn_addOthers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gb_table;
        private System.Windows.Forms.Label lbl_tableName;
        private System.Windows.Forms.SaveFileDialog saveTablesDiaglog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_otherOptions;
        private System.Windows.Forms.TextBox txt_otherOptionsField3;
        private System.Windows.Forms.TextBox txt_otherOptionsField2;
        private System.Windows.Forms.TextBox txt_otherOptionsField1;
        private System.Windows.Forms.Label lbl_otherOptField3;
        private System.Windows.Forms.Label lbl_otherOptField2;
        private System.Windows.Forms.Label lbl_otherOptField1;
        private System.Windows.Forms.Button btn_closeOthersPanel;
        private System.Windows.Forms.Button btn_saveOthersPanel;
        private System.Windows.Forms.CheckBox chk_updateOther;
        private System.Windows.Forms.Button btn_deleteOthers;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}