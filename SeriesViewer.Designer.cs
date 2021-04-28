
namespace PostcardsEditor
{
    partial class SeriesViewer
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
            this.sFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btn_seriesViewerClose = new System.Windows.Forms.Button();
            this.btn_seriesAdd = new System.Windows.Forms.Button();
            this.btn_seriesEdit = new System.Windows.Forms.Button();
            this.btn_seriesDelete = new System.Windows.Forms.Button();
            this.chk_seriesDelete = new System.Windows.Forms.CheckBox();
            this.lbl_seriesRowNumber = new System.Windows.Forms.Label();
            this.btn_seriesSaveExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridSeries = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_loadingSeries = new System.Windows.Forms.Label();
            this.txt_updSecondNumber = new System.Windows.Forms.TextBox();
            this.btn_updSecondNumber = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_seriesAddEdit = new System.Windows.Forms.Label();
            this.chk_seriesUpdate = new System.Windows.Forms.CheckBox();
            this.btn_seriesSave = new System.Windows.Forms.Button();
            this.btn_seriesPanelClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_seriesOpenBackImg = new System.Windows.Forms.Button();
            this.btn_seriesOpenFrontImg = new System.Windows.Forms.Button();
            this.pic_seriesBackImg = new System.Windows.Forms.PictureBox();
            this.txt_seriesBigDescription = new System.Windows.Forms.TextBox();
            this.pic_seriesFrontImg = new System.Windows.Forms.PictureBox();
            this.txt_seriesBackImg = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_seriesFrontImg = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_seriesBackTxtColor = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_seriesFrtTxtColor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_seriesDate = new System.Windows.Forms.TextBox();
            this.dateTimePickerSeries = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.combo_seriesColoring = new System.Windows.Forms.ComboBox();
            this.txt_seriesBarcodeGen = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.combo_seriesYear = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_seriesTotalImgCard = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.combo_seriesOrient = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_seriesSecondNumber = new System.Windows.Forms.TextBox();
            this.txt_mainCardNumber = new System.Windows.Forms.TextBox();
            this.txt_seriesDescENG = new System.Windows.Forms.TextBox();
            this.txt_seriesDescORIG = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_MainCard = new System.Windows.Forms.TextBox();
            this.chk_allSeries = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSeries)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_seriesBackImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_seriesFrontImg)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_seriesViewerClose
            // 
            this.btn_seriesViewerClose.Location = new System.Drawing.Point(1044, 8);
            this.btn_seriesViewerClose.Name = "btn_seriesViewerClose";
            this.btn_seriesViewerClose.Size = new System.Drawing.Size(88, 26);
            this.btn_seriesViewerClose.TabIndex = 6;
            this.btn_seriesViewerClose.Text = "&Close";
            this.btn_seriesViewerClose.UseVisualStyleBackColor = true;
            this.btn_seriesViewerClose.Click += new System.EventHandler(this.btn_seriesViewerClose_Click);
            // 
            // btn_seriesAdd
            // 
            this.btn_seriesAdd.Location = new System.Drawing.Point(534, 8);
            this.btn_seriesAdd.Name = "btn_seriesAdd";
            this.btn_seriesAdd.Size = new System.Drawing.Size(88, 26);
            this.btn_seriesAdd.TabIndex = 1;
            this.btn_seriesAdd.Text = "&Add";
            this.btn_seriesAdd.UseVisualStyleBackColor = true;
            this.btn_seriesAdd.Click += new System.EventHandler(this.btn_seriesAdd_Click);
            // 
            // btn_seriesEdit
            // 
            this.btn_seriesEdit.Location = new System.Drawing.Point(628, 8);
            this.btn_seriesEdit.Name = "btn_seriesEdit";
            this.btn_seriesEdit.Size = new System.Drawing.Size(88, 26);
            this.btn_seriesEdit.TabIndex = 2;
            this.btn_seriesEdit.Text = "E&dit";
            this.btn_seriesEdit.UseVisualStyleBackColor = true;
            this.btn_seriesEdit.Click += new System.EventHandler(this.btn_seriesEdit_Click);
            // 
            // btn_seriesDelete
            // 
            this.btn_seriesDelete.Enabled = false;
            this.btn_seriesDelete.Location = new System.Drawing.Point(754, 7);
            this.btn_seriesDelete.Name = "btn_seriesDelete";
            this.btn_seriesDelete.Size = new System.Drawing.Size(88, 26);
            this.btn_seriesDelete.TabIndex = 4;
            this.btn_seriesDelete.Text = "&Delete";
            this.btn_seriesDelete.UseVisualStyleBackColor = true;
            this.btn_seriesDelete.Click += new System.EventHandler(this.btn_seriesDelete_Click);
            // 
            // chk_seriesDelete
            // 
            this.chk_seriesDelete.AutoSize = true;
            this.chk_seriesDelete.Location = new System.Drawing.Point(737, 15);
            this.chk_seriesDelete.Name = "chk_seriesDelete";
            this.chk_seriesDelete.Size = new System.Drawing.Size(15, 14);
            this.chk_seriesDelete.TabIndex = 3;
            this.chk_seriesDelete.UseVisualStyleBackColor = true;
            // 
            // lbl_seriesRowNumber
            // 
            this.lbl_seriesRowNumber.AutoSize = true;
            this.lbl_seriesRowNumber.Location = new System.Drawing.Point(212, 11);
            this.lbl_seriesRowNumber.Name = "lbl_seriesRowNumber";
            this.lbl_seriesRowNumber.Size = new System.Drawing.Size(39, 18);
            this.lbl_seriesRowNumber.TabIndex = 0;
            this.lbl_seriesRowNumber.Text = "Row";
            // 
            // btn_seriesSaveExcel
            // 
            this.btn_seriesSaveExcel.Location = new System.Drawing.Point(884, 7);
            this.btn_seriesSaveExcel.Name = "btn_seriesSaveExcel";
            this.btn_seriesSaveExcel.Size = new System.Drawing.Size(130, 26);
            this.btn_seriesSaveExcel.TabIndex = 5;
            this.btn_seriesSaveExcel.Text = "Export to Excel";
            this.btn_seriesSaveExcel.UseVisualStyleBackColor = true;
            this.btn_seriesSaveExcel.Click += new System.EventHandler(this.btn_seriesSaveExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Postcard Series";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_seriesSaveExcel);
            this.panel1.Controls.Add(this.lbl_seriesRowNumber);
            this.panel1.Controls.Add(this.chk_seriesDelete);
            this.panel1.Controls.Add(this.btn_seriesDelete);
            this.panel1.Controls.Add(this.btn_seriesEdit);
            this.panel1.Controls.Add(this.btn_seriesAdd);
            this.panel1.Controls.Add(this.btn_seriesViewerClose);
            this.panel1.Location = new System.Drawing.Point(5, 790);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 42);
            this.panel1.TabIndex = 1;
            // 
            // dataGridSeries
            // 
            this.dataGridSeries.AllowUserToAddRows = false;
            this.dataGridSeries.AllowUserToDeleteRows = false;
            this.dataGridSeries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridSeries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSeries.Location = new System.Drawing.Point(6, 39);
            this.dataGridSeries.Name = "dataGridSeries";
            this.dataGridSeries.ReadOnly = true;
            this.dataGridSeries.Size = new System.Drawing.Size(1151, 745);
            this.dataGridSeries.TabIndex = 1;
            this.dataGridSeries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSeries_CellContentClick);
            this.dataGridSeries.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSeries_CellContentClick);
            this.dataGridSeries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSeries_ViewContent);
            this.dataGridSeries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridSeries_CellContentClick);
            this.dataGridSeries.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridSeries_CellContentClick);
            this.dataGridSeries.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridSeries_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PeachPuff;
            this.panel2.Controls.Add(this.lbl_loadingSeries);
            this.panel2.Controls.Add(this.txt_updSecondNumber);
            this.panel2.Controls.Add(this.btn_updSecondNumber);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lbl_seriesAddEdit);
            this.panel2.Controls.Add(this.chk_seriesUpdate);
            this.panel2.Controls.Add(this.btn_seriesSave);
            this.panel2.Controls.Add(this.btn_seriesPanelClose);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(21, 169);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1131, 660);
            this.panel2.TabIndex = 3;
            // 
            // lbl_loadingSeries
            // 
            this.lbl_loadingSeries.AutoSize = true;
            this.lbl_loadingSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_loadingSeries.Location = new System.Drawing.Point(473, 13);
            this.lbl_loadingSeries.Name = "lbl_loadingSeries";
            this.lbl_loadingSeries.Size = new System.Drawing.Size(160, 24);
            this.lbl_loadingSeries.TabIndex = 16;
            this.lbl_loadingSeries.Text = "Loading content...";
            // 
            // txt_updSecondNumber
            // 
            this.txt_updSecondNumber.Location = new System.Drawing.Point(247, 625);
            this.txt_updSecondNumber.Name = "txt_updSecondNumber";
            this.txt_updSecondNumber.Size = new System.Drawing.Size(307, 24);
            this.txt_updSecondNumber.TabIndex = 10;
            // 
            // btn_updSecondNumber
            // 
            this.btn_updSecondNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updSecondNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_updSecondNumber.Location = new System.Drawing.Point(560, 623);
            this.btn_updSecondNumber.Name = "btn_updSecondNumber";
            this.btn_updSecondNumber.Size = new System.Drawing.Size(138, 28);
            this.btn_updSecondNumber.TabIndex = 9;
            this.btn_updSecondNumber.Text = "&New 2nd Number";
            this.btn_updSecondNumber.UseVisualStyleBackColor = true;
            this.btn_updSecondNumber.Click += new System.EventHandler(this.btn_updSecondNumber_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 627);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Postcard Series";
            // 
            // lbl_seriesAddEdit
            // 
            this.lbl_seriesAddEdit.AutoSize = true;
            this.lbl_seriesAddEdit.Location = new System.Drawing.Point(12, 13);
            this.lbl_seriesAddEdit.Name = "lbl_seriesAddEdit";
            this.lbl_seriesAddEdit.Size = new System.Drawing.Size(70, 18);
            this.lbl_seriesAddEdit.TabIndex = 0;
            this.lbl_seriesAddEdit.Text = "Add / Edit";
            // 
            // chk_seriesUpdate
            // 
            this.chk_seriesUpdate.AutoSize = true;
            this.chk_seriesUpdate.Location = new System.Drawing.Point(764, 626);
            this.chk_seriesUpdate.Name = "chk_seriesUpdate";
            this.chk_seriesUpdate.Size = new System.Drawing.Size(74, 22);
            this.chk_seriesUpdate.TabIndex = 5;
            this.chk_seriesUpdate.Text = "Update";
            this.chk_seriesUpdate.UseVisualStyleBackColor = true;
            // 
            // btn_seriesSave
            // 
            this.btn_seriesSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seriesSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_seriesSave.Location = new System.Drawing.Point(839, 622);
            this.btn_seriesSave.Name = "btn_seriesSave";
            this.btn_seriesSave.Size = new System.Drawing.Size(84, 28);
            this.btn_seriesSave.TabIndex = 6;
            this.btn_seriesSave.Text = "&Save";
            this.btn_seriesSave.UseVisualStyleBackColor = true;
            this.btn_seriesSave.Click += new System.EventHandler(this.btn_seriesSave_Click);
            // 
            // btn_seriesPanelClose
            // 
            this.btn_seriesPanelClose.Location = new System.Drawing.Point(1023, 623);
            this.btn_seriesPanelClose.Name = "btn_seriesPanelClose";
            this.btn_seriesPanelClose.Size = new System.Drawing.Size(90, 26);
            this.btn_seriesPanelClose.TabIndex = 7;
            this.btn_seriesPanelClose.Text = "&Close";
            this.btn_seriesPanelClose.UseVisualStyleBackColor = true;
            this.btn_seriesPanelClose.Click += new System.EventHandler(this.btn_seriesPanelClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_seriesOpenBackImg);
            this.groupBox3.Controls.Add(this.btn_seriesOpenFrontImg);
            this.groupBox3.Controls.Add(this.pic_seriesBackImg);
            this.groupBox3.Controls.Add(this.txt_seriesBigDescription);
            this.groupBox3.Controls.Add(this.pic_seriesFrontImg);
            this.groupBox3.Controls.Add(this.txt_seriesBackImg);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txt_seriesFrontImg);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Location = new System.Drawing.Point(15, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1105, 450);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // btn_seriesOpenBackImg
            // 
            this.btn_seriesOpenBackImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seriesOpenBackImg.Location = new System.Drawing.Point(1066, 44);
            this.btn_seriesOpenBackImg.Name = "btn_seriesOpenBackImg";
            this.btn_seriesOpenBackImg.Size = new System.Drawing.Size(32, 23);
            this.btn_seriesOpenBackImg.TabIndex = 4;
            this.btn_seriesOpenBackImg.Text = "...";
            this.btn_seriesOpenBackImg.UseVisualStyleBackColor = true;
            this.btn_seriesOpenBackImg.Click += new System.EventHandler(this.btn_seriesOpenBackImg_Click);
            // 
            // btn_seriesOpenFrontImg
            // 
            this.btn_seriesOpenFrontImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seriesOpenFrontImg.Location = new System.Drawing.Point(510, 44);
            this.btn_seriesOpenFrontImg.Name = "btn_seriesOpenFrontImg";
            this.btn_seriesOpenFrontImg.Size = new System.Drawing.Size(32, 23);
            this.btn_seriesOpenFrontImg.TabIndex = 2;
            this.btn_seriesOpenFrontImg.Text = "...";
            this.btn_seriesOpenFrontImg.UseVisualStyleBackColor = true;
            this.btn_seriesOpenFrontImg.Click += new System.EventHandler(this.btn_seriesOpenFrontImg_Click);
            // 
            // pic_seriesBackImg
            // 
            this.pic_seriesBackImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_seriesBackImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_seriesBackImg.Enabled = false;
            this.pic_seriesBackImg.Location = new System.Drawing.Point(568, 76);
            this.pic_seriesBackImg.Name = "pic_seriesBackImg";
            this.pic_seriesBackImg.Size = new System.Drawing.Size(530, 370);
            this.pic_seriesBackImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_seriesBackImg.TabIndex = 54;
            this.pic_seriesBackImg.TabStop = false;
            // 
            // txt_seriesBigDescription
            // 
            this.txt_seriesBigDescription.Location = new System.Drawing.Point(128, 15);
            this.txt_seriesBigDescription.Name = "txt_seriesBigDescription";
            this.txt_seriesBigDescription.Size = new System.Drawing.Size(970, 24);
            this.txt_seriesBigDescription.TabIndex = 0;
            // 
            // pic_seriesFrontImg
            // 
            this.pic_seriesFrontImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_seriesFrontImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_seriesFrontImg.Enabled = false;
            this.pic_seriesFrontImg.Location = new System.Drawing.Point(12, 76);
            this.pic_seriesFrontImg.Name = "pic_seriesFrontImg";
            this.pic_seriesFrontImg.Size = new System.Drawing.Size(530, 370);
            this.pic_seriesFrontImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_seriesFrontImg.TabIndex = 53;
            this.pic_seriesFrontImg.TabStop = false;
            // 
            // txt_seriesBackImg
            // 
            this.txt_seriesBackImg.Location = new System.Drawing.Point(683, 44);
            this.txt_seriesBackImg.Name = "txt_seriesBackImg";
            this.txt_seriesBackImg.Size = new System.Drawing.Size(379, 24);
            this.txt_seriesBackImg.TabIndex = 3;
            this.txt_seriesBackImg.TextChanged += new System.EventHandler(this.pic_loader);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(20, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(108, 18);
            this.label20.TabIndex = 1;
            this.label20.Text = "Big Description";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(563, 46);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(120, 18);
            this.label23.TabIndex = 2;
            this.label23.Text = "Back Image Path";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_seriesFrontImg
            // 
            this.txt_seriesFrontImg.Location = new System.Drawing.Point(128, 44);
            this.txt_seriesFrontImg.Name = "txt_seriesFrontImg";
            this.txt_seriesFrontImg.Size = new System.Drawing.Size(379, 24);
            this.txt_seriesFrontImg.TabIndex = 1;
            this.txt_seriesFrontImg.TextChanged += new System.EventHandler(this.pic_loader);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(7, 45);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(121, 18);
            this.label22.TabIndex = 2;
            this.label22.Text = "Front Image Path";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_seriesBackTxtColor);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txt_seriesFrtTxtColor);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txt_seriesDate);
            this.groupBox2.Controls.Add(this.dateTimePickerSeries);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.combo_seriesColoring);
            this.groupBox2.Controls.Add(this.txt_seriesBarcodeGen);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.combo_seriesYear);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txt_seriesTotalImgCard);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.combo_seriesOrient);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(569, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 132);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // txt_seriesBackTxtColor
            // 
            this.txt_seriesBackTxtColor.Location = new System.Drawing.Point(119, 101);
            this.txt_seriesBackTxtColor.Multiline = true;
            this.txt_seriesBackTxtColor.Name = "txt_seriesBackTxtColor";
            this.txt_seriesBackTxtColor.Size = new System.Drawing.Size(425, 28);
            this.txt_seriesBackTxtColor.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 18);
            this.label16.TabIndex = 13;
            this.label16.Text = "Back Text Color";
            // 
            // txt_seriesFrtTxtColor
            // 
            this.txt_seriesFrtTxtColor.Location = new System.Drawing.Point(119, 69);
            this.txt_seriesFrtTxtColor.Multiline = true;
            this.txt_seriesFrtTxtColor.Name = "txt_seriesFrtTxtColor";
            this.txt_seriesFrtTxtColor.Size = new System.Drawing.Size(425, 28);
            this.txt_seriesFrtTxtColor.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 18);
            this.label10.TabIndex = 14;
            this.label10.Text = "Front Text Color";
            // 
            // txt_seriesDate
            // 
            this.txt_seriesDate.Location = new System.Drawing.Point(114, 41);
            this.txt_seriesDate.MaxLength = 10;
            this.txt_seriesDate.Name = "txt_seriesDate";
            this.txt_seriesDate.Size = new System.Drawing.Size(81, 24);
            this.txt_seriesDate.TabIndex = 3;
            this.txt_seriesDate.Text = "2021-04-20";
            // 
            // dateTimePickerSeries
            // 
            this.dateTimePickerSeries.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerSeries.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSeries.Location = new System.Drawing.Point(196, 41);
            this.dateTimePickerSeries.Name = "dateTimePickerSeries";
            this.dateTimePickerSeries.Size = new System.Drawing.Size(18, 24);
            this.dateTimePickerSeries.TabIndex = 4;
            this.dateTimePickerSeries.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(48, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 18);
            this.label8.TabIndex = 12;
            this.label8.Text = "Coloring";
            // 
            // combo_seriesColoring
            // 
            this.combo_seriesColoring.FormattingEnabled = true;
            this.combo_seriesColoring.Location = new System.Drawing.Point(114, 10);
            this.combo_seriesColoring.Name = "combo_seriesColoring";
            this.combo_seriesColoring.Size = new System.Drawing.Size(48, 26);
            this.combo_seriesColoring.TabIndex = 0;
            // 
            // txt_seriesBarcodeGen
            // 
            this.txt_seriesBarcodeGen.Location = new System.Drawing.Point(426, 40);
            this.txt_seriesBarcodeGen.Name = "txt_seriesBarcodeGen";
            this.txt_seriesBarcodeGen.Size = new System.Drawing.Size(118, 24);
            this.txt_seriesBarcodeGen.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(360, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 18);
            this.label13.TabIndex = 1;
            this.label13.Text = "Barcode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(246, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Year";
            // 
            // combo_seriesYear
            // 
            this.combo_seriesYear.FormattingEnabled = true;
            this.combo_seriesYear.Location = new System.Drawing.Point(287, 39);
            this.combo_seriesYear.Name = "combo_seriesYear";
            this.combo_seriesYear.Size = new System.Drawing.Size(64, 26);
            this.combo_seriesYear.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(73, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 18);
            this.label17.TabIndex = 1;
            this.label17.Text = "Date";
            // 
            // txt_seriesTotalImgCard
            // 
            this.txt_seriesTotalImgCard.Location = new System.Drawing.Point(508, 13);
            this.txt_seriesTotalImgCard.Name = "txt_seriesTotalImgCard";
            this.txt_seriesTotalImgCard.Size = new System.Drawing.Size(36, 24);
            this.txt_seriesTotalImgCard.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(443, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "Tot.Img.";
            // 
            // combo_seriesOrient
            // 
            this.combo_seriesOrient.FormattingEnabled = true;
            this.combo_seriesOrient.Items.AddRange(new object[] {
            "---",
            "2",
            "H",
            "V"});
            this.combo_seriesOrient.Location = new System.Drawing.Point(318, 10);
            this.combo_seriesOrient.Name = "combo_seriesOrient";
            this.combo_seriesOrient.Size = new System.Drawing.Size(33, 26);
            this.combo_seriesOrient.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(235, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 18);
            this.label12.TabIndex = 1;
            this.label12.Text = "Orientation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_seriesSecondNumber);
            this.groupBox1.Controls.Add(this.txt_mainCardNumber);
            this.groupBox1.Controls.Add(this.txt_seriesDescENG);
            this.groupBox1.Controls.Add(this.txt_seriesDescORIG);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(15, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 132);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txt_seriesSecondNumber
            // 
            this.txt_seriesSecondNumber.Location = new System.Drawing.Point(144, 41);
            this.txt_seriesSecondNumber.Name = "txt_seriesSecondNumber";
            this.txt_seriesSecondNumber.Size = new System.Drawing.Size(212, 24);
            this.txt_seriesSecondNumber.TabIndex = 1;
            // 
            // txt_mainCardNumber
            // 
            this.txt_mainCardNumber.Location = new System.Drawing.Point(144, 11);
            this.txt_mainCardNumber.Name = "txt_mainCardNumber";
            this.txt_mainCardNumber.Size = new System.Drawing.Size(212, 24);
            this.txt_mainCardNumber.TabIndex = 0;
            // 
            // txt_seriesDescENG
            // 
            this.txt_seriesDescENG.Location = new System.Drawing.Point(144, 69);
            this.txt_seriesDescENG.Name = "txt_seriesDescENG";
            this.txt_seriesDescENG.Size = new System.Drawing.Size(394, 24);
            this.txt_seriesDescENG.TabIndex = 2;
            // 
            // txt_seriesDescORIG
            // 
            this.txt_seriesDescORIG.Location = new System.Drawing.Point(144, 98);
            this.txt_seriesDescORIG.Name = "txt_seriesDescORIG";
            this.txt_seriesDescORIG.Size = new System.Drawing.Size(394, 24);
            this.txt_seriesDescORIG.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Description (Orig)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Description (Eng)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Series Card Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Main Card Number";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Postcard";
            // 
            // txt_MainCard
            // 
            this.txt_MainCard.Enabled = false;
            this.txt_MainCard.Location = new System.Drawing.Point(73, 6);
            this.txt_MainCard.Name = "txt_MainCard";
            this.txt_MainCard.Size = new System.Drawing.Size(341, 24);
            this.txt_MainCard.TabIndex = 0;
            this.txt_MainCard.TabStop = false;
            // 
            // chk_allSeries
            // 
            this.chk_allSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_allSeries.AutoSize = true;
            this.chk_allSeries.Location = new System.Drawing.Point(955, 8);
            this.chk_allSeries.Name = "chk_allSeries";
            this.chk_allSeries.Size = new System.Drawing.Size(202, 22);
            this.chk_allSeries.TabIndex = 4;
            this.chk_allSeries.Text = "Show All Series Postcards";
            this.chk_allSeries.UseVisualStyleBackColor = true;
            this.chk_allSeries.CheckedChanged += new System.EventHandler(this.chk_allSeries_CheckedChanged);
            // 
            // SeriesViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 836);
            this.ControlBox = false;
            this.Controls.Add(this.chk_allSeries);
            this.Controls.Add(this.txt_MainCard);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridSeries);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeriesViewer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Postcard Series Viewer";
            this.Load += new System.EventHandler(this.SeriesViewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSeries)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_seriesBackImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_seriesFrontImg)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog sFileDialog;
        private System.Windows.Forms.Button btn_seriesViewerClose;
        private System.Windows.Forms.Button btn_seriesAdd;
        private System.Windows.Forms.Button btn_seriesEdit;
        private System.Windows.Forms.Button btn_seriesDelete;
        private System.Windows.Forms.CheckBox chk_seriesDelete;
        private System.Windows.Forms.Label lbl_seriesRowNumber;
        private System.Windows.Forms.Button btn_seriesSaveExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridSeries;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_seriesAddEdit;
        private System.Windows.Forms.CheckBox chk_seriesUpdate;
        private System.Windows.Forms.Button btn_seriesSave;
        private System.Windows.Forms.Button btn_seriesPanelClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_seriesOpenBackImg;
        private System.Windows.Forms.Button btn_seriesOpenFrontImg;
        private System.Windows.Forms.PictureBox pic_seriesBackImg;
        private System.Windows.Forms.PictureBox pic_seriesFrontImg;
        private System.Windows.Forms.TextBox txt_seriesBackImg;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_seriesFrontImg;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_seriesDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerSeries;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_seriesBigDescription;
        private System.Windows.Forms.ComboBox combo_seriesColoring;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_seriesBarcodeGen;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combo_seriesYear;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_seriesTotalImgCard;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox combo_seriesOrient;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_seriesSecondNumber;
        private System.Windows.Forms.TextBox txt_mainCardNumber;
        private System.Windows.Forms.TextBox txt_seriesDescENG;
        private System.Windows.Forms.TextBox txt_seriesDescORIG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_seriesBackTxtColor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_seriesFrtTxtColor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_MainCard;
        private System.Windows.Forms.CheckBox chk_allSeries;
        private System.Windows.Forms.TextBox txt_updSecondNumber;
        private System.Windows.Forms.Button btn_updSecondNumber;
        private System.Windows.Forms.Label lbl_loadingSeries;
    }
}