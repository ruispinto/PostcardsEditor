using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using PostcardsEditor.myclass;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace PostcardsEditor
{
    public partial class DataViewer : Form
    {
        connection_class con = new connection_class();
        dataclass dc = new dataclass();

        // Temporary variables
        public string get_cardNumber, get_cardPublish, get_cardCountry, get_cardTheme, get_cardColoring, get_cardYear, get_cardSize, get_cardShape, get_cardOrient, get_cardCond, get_cardSentType, get_cardEquals, get_cardMaterial;
        public Int32 get_cardID;

        // search variables
        public string search_text, search_option;

        // update (or not) postcard
        public bool chkCard = false;

        public DataViewer()
        {
            InitializeComponent();

            btn_publishBlog.Visible = false;
            panel2.Visible = false;
            panel1.Enabled = true;
            panel3.Enabled = true;
        }



        private void DataViewer_Load(object sender, EventArgs e)
        {
            //this.BackColor = Properties.Settings.Default.FormBackground; ;
            dataGridCard.DataSource = null;
            combo_searchType.SelectedIndex = 0;
            combo_searchType.SelectedItem = combo_searchType.SelectedIndex;
            dataGridCard.ForeColor = Color.FromArgb(64, 64, 64);

            // tests database connection
            try
            {
                con.connectdb.Open();
                lbl_dbcon.ForeColor = Color.Green;
                lbl_dbcon.Text = "Connected";
                con.connectdb.Close();
                dc.REFRESH_CARD();
                dataGridCard.DataSource = dc.DT;
            }
            catch
            {
                lbl_dbcon.ForeColor = Color.Red;
                lbl_dbcon.Text = "Not Connected!";
                MessageBox.Show("Database connection error!\n\nPlease check your internet connection or\ndatabase under maintenance.\n\nPlease be patient and come back later.", "Postcards Editor");
                System.Windows.Forms.Application.Exit();
            }
        }



        private void btn_openFrontImg_Click(object sender, EventArgs e)
        {
            // display dialog box to choose a new front image
            OpenFileDialog picPicker = new OpenFileDialog();
            if (picPicker.ShowDialog() == DialogResult.OK)
            {
                pic_frontImg.Image = new Bitmap(picPicker.FileName);
                txt_frontImgPath.Text = picPicker.FileName;
                pic_frontImg.Enabled = true;
                pic_loader();
            }
        }



        private void btn_openBackImg_Click(object sender, EventArgs e)
        {
            // display dialog box to choose a new back image
            OpenFileDialog picPicker = new OpenFileDialog();
            if (picPicker.ShowDialog() == DialogResult.OK)
            {
                pic_backImg.Image = new Bitmap(picPicker.FileName);
                txt_backImgPath.Text = picPicker.FileName;
                pic_backImg.Enabled = true;
                pic_loader();
            }
        }



        // show image from disk/web or no_image
        private void pic_loader()
        {
            // test if the front image exists
            if(txt_frontImgPath.Text.Trim() != "")
            {
                try
                {
                    // if it exists, display the image
                    if (txt_frontImgPath.Text.Substring(0, 4) == "HTTP" || txt_frontImgPath.Text.Substring(0, 4) == "http" || txt_frontImgPath.Text.Substring(0, 3) == "WWW" || txt_frontImgPath.Text.Substring(0, 3) == "www")
                        pic_frontImg.ImageLocation = txt_frontImgPath.Text;
                    else
                        pic_frontImg.Image = new Bitmap(txt_frontImgPath.Text);
                }
                catch
                {
                    // if it exists, display the image
                    pic_frontImg.Image = new Bitmap(Properties.Resources.no_image);
                }
            }
            else
                pic_frontImg.Image = new Bitmap(Properties.Resources.no_image);

            // test if the back image exists
            if(txt_backImgPath.Text.Trim() != "")
            {
                try
                {
                    // if is the real image, display the new image
                    if (txt_backImgPath.Text.Substring(0, 4) == "HTTP" || txt_backImgPath.Text.Substring(0, 4) == "http" || txt_backImgPath.Text.Substring(0, 3) == "WWW" || txt_backImgPath.Text.Substring(0, 3) == "www")
                        pic_backImg.ImageLocation = txt_backImgPath.Text;
                    else
                        pic_backImg.Image = new Bitmap(txt_backImgPath.Text);
                }
                catch
                {
                    // if it doesn't exist, display the no_image image
                    pic_backImg.Image = new Bitmap(Properties.Resources.no_image);
                }
            }
            else
                pic_backImg.Image = new Bitmap(Properties.Resources.no_image);
        }



        /***********************************
         *          SAVE POSTCARD          *
        ************************************/
        private void btn_saveCard_Click(object sender, EventArgs e)
        {
            int localRow = dataGridCard.CurrentRow.Index;
            if (txt_cardNumber.Text.Length > 0 || txt_cardNumber.Text.Trim() != "")
            {
                // check if postcard number already exists
                dc.cardNumber = txt_cardNumber.Text;
                if (combo_publish.Text == "Choose...")
                {
                    dc.cardPublisher = "";
                }
                else
                {
                    dc.cardPublisher = combo_publish.Text;
                }
                if (chk_scanned.Checked == true)
                {
                    dc.cardScanned = "Y";
                }
                else
                {
                    dc.cardScanned = "N";
                }
                if (chk_blog.Checked == true)
                {
                    dc.cardInTheBlog = "Y";
                }
                else
                {
                    dc.cardInTheBlog = "N";
                }
                if (combo_country.Text == "Choose...")
                {
                    dc.cardCountry = "";
                }
                else
                {
                    dc.cardCountry = combo_country.Text;
                }
                dc.cardDescEng = txt_descENG.Text;
                dc.cardDescOrg = txt_descORIG.Text;
                if (combo_coloring.Text == "Choose...")
                {
                    dc.cardColoring = "";
                }
                else
                {
                    dc.cardColoring = combo_coloring.Text;
                }
                dc.cardTheme = combo_theme.Text;
                if (combo_year.Text == "Choose...")
                {
                    dc.cardYear = "----";
                }
                else
                {
                    dc.cardYear = combo_year.Text;
                }
                dc.cardImgNumber = txt_totalmgInCard.Text;
                if (chk_seriesMulti.Checked == true)
                {
                    dc.cardSeriesMulti = "Y";
                }
                else
                {
                    dc.cardSeriesMulti = "N";
                }
                dc.cardTotCardNumber = txt_totSeriesCards.Text;
                if (combo_size.Text == "")
                {
                    dc.cardSize = "";
                }
                else
                {
                    dc.cardSize = combo_size.Text;
                }
                if (combo_shape.Text == "")
                {
                    dc.cardShape = "";
                }
                else
                {
                    dc.cardShape = combo_shape.Text;
                }
                if (combo_orient.Text == "Choose...")
                {
                    dc.cardOrient = "";
                }
                else
                {
                    dc.cardOrient = combo_orient.Text;
                }
                dc.cardBarcode = txt_barcodeGen.Text;
                if (combo_material.Text == "")
                {
                    dc.cardMaterial = "";
                }
                else
                {
                    dc.cardMaterial = combo_material.Text;
                }
                if (combo_cond.Text == "Choose...")
                {
                    dc.cardCondition = "";
                }
                else
                {
                    dc.cardCondition = combo_cond.Text;
                }
                if (chk_borders.Checked == true)
                {
                    dc.cardBorders = "Y";
                }
                else
                {
                    dc.cardBorders = "N";
                }
                dc.cardFrontTxtColor = txt_frtTxtColor.Text;
                dc.cardBackTxtColor = txt_backTxtColor.Text;
                if (txt_datePurchase.TextLength > 10)
                    txt_datePurchase.Text = txt_datePurchase.Text.Substring(0, 10);
                dc.cardDatePurchased = txt_datePurchase.Text;
                dc.cardCostPrice = txt_price.Text;
                dc.cardWebpage = txt_webpage.Text;
                if (chk_identical.Checked == true)
                {
                    dc.cardIdentical = "Y";
                    if (combo_cardNumber.Text == "Choose...")
                    {
                        dc.cardEqualsTo = "";
                    }
                    else
                    {
                        dc.cardEqualsTo = combo_cardNumber.Text;
                    }
                    dc.cardDifferences = txt_cardDifferencies.Text;
                }
                else
                {
                    dc.cardIdentical = "N";
                    dc.cardEqualsTo = "";
                    dc.cardDifferences = "";
                }
                dc.cardBigDesc = txt_bigDescription.Text;
                if (combo_SentType.Text == "Choose...")
                {
                    dc.cardSentType = "";
                }
                else
                {
                    dc.cardSentType = combo_SentType.Text;
                }
                dc.cardTypeDesc = txt_TypeDesc.Text;
                dc.cardFrontImgPath = txt_frontImgPath.Text;
                dc.cardBackImgPath = txt_backImgPath.Text;

                // check if it is a new postcard or an update
                string query2 = "";
                if (chkCard == true)
                {
                    dc.cardID = get_cardID;
                    dc.UPDATE_CARD();
                    query2 = "Updated!";
                }
                else
                {
                    bool verify = false;
                    verify = dc.SEARCH_NUMBER();
                    if (verify)
                    {
                        query2 = "Already Exists!";
                    }
                    else
                    {
                        dc.ADD_CARD();
                        query2 = "Added!";
                    }
                }

                // create a messegabox with all results to confirm
                string query = "Card\n\nCard Number: " + txt_cardNumber.Text + "\nPublisher " + combo_publish.Text + "\nCountry " + combo_country.Text + "\n\n" + query2;
                MessageBox.Show(query);

                con.connectdb.Close();
                panel2.Visible = false;

                if (chk_seriesMulti.Checked == true)
                {
                    string del_msg = "This postcard is part of a set of several postcards.\n\nDo you want to add them now ?";
                    DialogResult dialog = MessageBox.Show(del_msg, "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        Form newform = new SeriesViewer(txt_cardNumber.Text.Trim());
                        newform.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Field 'Card Number' cannot be empty.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            panel1.Enabled = true;
            panel3.Enabled = true;
            dataGridCard.DataSource = null;
            dataGridCard.BackgroundColor = Color.FromArgb(64, 64, 64);
            dc.REFRESH_CARD();
            dataGridCard.DataSource = dc.DT;
            dataGridCard.Rows[localRow].Selected = true;
            dataGridCard.FirstDisplayedScrollingRowIndex = localRow;
            dataGridCard.Focus();
            dataGridCard.Enabled = true;
        }



        private void btn_about_Click(object sender, EventArgs e)
        {
            dataGridCard.Enabled = false;
            Form newform = new About();
            newform.ShowDialog();
            dataGridCard.Enabled = true;

        }



        private void btn_close_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel3.Enabled = true;
            panel2.Visible = false;

            // enable editing and adding
            btn_saveCard.Visible = true;
            chk_updateCard.Visible = true;
            btn_openBackImg.Enabled = true;
            btn_openFrontImg.Enabled = true;
            dateTimePicker1.Enabled = true;
            dataGridCard.Enabled = true;
        }



        private void chk_identical_CheckedChanged(object sender, EventArgs e)
        {
            // checi if the 'identical' checkbox is checked or not
            if (chk_identical.Checked == false)
            {
                // fields disabled if 'identical' checkbox isn't checked
                txt_cardDifferencies.Enabled = false;
                combo_cardNumber.Enabled = false;
            }
            else
            {
                // fields enabled if 'identical' checkbox is checked
                txt_cardDifferencies.Enabled = true;
                combo_cardNumber.Enabled = true;
            }
        }



        private void dtPicker_changed(object sender, EventArgs e)
        {
            if (txt_datePurchase.Text.Trim() != "")
                txt_datePurchase.Text = dateTimePicker1.Value.ToString();
        }



        private void chk_updateCard_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_updateCard.Checked != true)
            {
                chkCard = false;
                txt_backImgPath.Text = "";
                txt_frontImgPath.Text = "";
            }
            else
            {
                chkCard = true;
                get_cardID = (Int32)dataGridCard.CurrentRow.Cells[0].Value;
                txt_frontImgPath.Text = dataGridCard.CurrentRow.Cells[32].Value.ToString();
                txt_backImgPath.Text = dataGridCard.CurrentRow.Cells[33].Value.ToString();
            }
            pic_loader();
        }



        private void btn_series_Click(object sender, EventArgs e)
        {
            Form newform = new SeriesViewer("");
            newform.ShowDialog();
        }



        private void dataGridCard_ContentView(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Enabled = false;
            panel3.Enabled = false;
            panel2.Visible = true;
            lbl_addEdit.Text = "View Postcard Info";
            VIEW_PANEL();
        }



        // not ready button
        private void btn_publishBlog_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not ready yet. Try again later.");
        }



        // button used to reset the search (in case of it has been used)
        private void btn_cardRefresh_Click(object sender, EventArgs e)
        {
            REFRESH_CARD_STILL();
            txt_searchBox.Text = "";
            combo_searchType.SelectedIndex = 0;
            combo_searchType.SelectedItem = combo_searchType.SelectedIndex;

        }



        private void btn_moreOptions_Click(object sender, EventArgs e)
        {
            Form newform = new OtherOptions();
            newform.ShowDialog();
        }



        private void btn_exitApp_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void chk_delete_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_delete.Checked)
            {
                btn_delete.Enabled = true;
                btn_delete.ForeColor = Color.White;
                btn_delete.BackColor = Color.Red;
            }
            else
            {
                btn_delete.Enabled = false;
                btn_delete.ForeColor = Color.White;
                btn_delete.BackColor = Color.Red;
            }
        }



        private void btn_delete_Click(object sender, EventArgs e)
        {
            string del_msg = "You are about to delete:\n\nPostcard Number: " + dataGridCard.CurrentRow.Cells[0].Value.ToString() + "\nPublisher: " + dataGridCard.CurrentRow.Cells[1].Value.ToString() + "\n\nAre you sure ?";
            DialogResult dialog = MessageBox.Show(del_msg, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            btn_delete.Enabled = false;
            chk_delete.Checked = false;
            if (dialog == DialogResult.Yes)
            {
                get_cardID = (Int32)dataGridCard.CurrentRow.Cells[0].Value;
                dc.cardID = get_cardID;
                txt_cardNumber.Text = dataGridCard.CurrentRow.Cells[0].Value.ToString();
                dc.cardNumber = txt_cardNumber.Text;
                dc.DELETE_CARD();

                dataGridCard.DataSource = null;
                dc.REFRESH_CARD();
                dataGridCard.DataSource = dc.DT;

                del_msg = "Postcard number " + txt_cardNumber.Text.Trim() + " deleted!";
                MessageBox.Show(del_msg, "", MessageBoxButtons.OK);
            }
        }



        private void btn_add_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel3.Enabled = false;
            panel2.Visible = true;
            lbl_addEdit.Text = "Add Postcard";
            chkCard = false;
            chk_updateCard.Checked = chkCard;
            // load the panel to show all data from a chosen card without the images
            LOAD_PANEL();
        }



        private void btn_edit_Click(object sender, EventArgs e)

        {
            panel1.Enabled = false;
            panel3.Enabled = false;
            chkCard = true;
            chk_updateCard.Checked = chkCard;
            get_cardID = (Int32)dataGridCard.CurrentRow.Cells[0].Value;
            panel2.Visible = true;
            lbl_addEdit.Text = "Edit Postcard";
            // load the panel to show all the data to update
            LOAD_PANEL();
        }



        /*
         * 
         *      SAVE TO EXCEL FILE (no need to have Excel installed in your computer
         * 
         */
        private void btn_saveExcel_Click(object sender, EventArgs e)
        {
            // export to excel
            sFDialog.InitialDirectory = "C:";
            sFDialog.Title = "Save as Excel File";
            sFDialog.FileName = "";
            sFDialog.Filter = "Excel Files 2007 and up|*.xlsx";

            // choose the folder where to write the file. If 'OK' is pressed, it saves the complete path to that folder.
            if (sFDialog.ShowDialog() != DialogResult.Cancel)
            {
                // change cursor to wait mode while saving the file
                Cursor.Current = Cursors.WaitCursor;

                // EPPlus license (Excel isn't required to be installed in the computer. You may use other open source software to open it)
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                try
                {
                    using (var package = new ExcelPackage(new System.IO.FileInfo(sFDialog.FileName)))
                    {
                        // define spreadsheet's sheet name
                        var worksheet = package.Workbook.Worksheets.Add("Postcards");

                        // save the header
                        for (int i = 1; i < dataGridCard.Columns.Count + 1; i++)
                        {
                            worksheet.Cells[1, i].Value = dataGridCard.Columns[i - 1].HeaderText;
                        }

                        // save all information in the gridview to the spreadsheet
                        for (int i = 0; i < dataGridCard.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridCard.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dataGridCard.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        // adjust column's width
                        worksheet.Cells.AutoFitColumns(0);

                        // save file to the disk
                        package.Save();
                    }
                    MessageBox.Show("Database exported!");
                }
                catch
                {
                    MessageBox.Show("File already exists! Please try again.");

                }
            }
            // cursor is back to default
            Cursor.Current = Cursors.Default;
        }



        // In case text box is changed
        private void _pic_loader(object sender, EventArgs e)
        {
            pic_loader();
        }



        // In case of a mouse click
        private void dataGridCard_MouseClick(object sender, MouseEventArgs e)
        {
            update_cardNumber();
        }



        // In case you click with your mouse
        private void dataGridCard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            update_cardNumber();
        }



        // In case you press down a key in the grid
        private void dataGridCard_CellContentClick(object sender, KeyPressEventArgs e)
        {
            update_cardNumber();
        }



        // in case you move around using arrow keys (or enter key)
        private void dataGridCard_CellContentClick(object sender, KeyEventArgs e)
        {
            update_cardNumber();
        }



        // update row number and card number
        private void update_cardNumber()
        {
            Int32 currentRow = dataGridCard.CurrentRow.Index + 1;
            lbl_rowNumber.Text = "Row " + currentRow.ToString() + " / " + (dataGridCard.RowCount).ToString();
            lbl_cardNumber.Text = dataGridCard.CurrentRow.Cells[1].Value.ToString();
        }



        // Just the preparation for the add/edit panel
        private void LOAD_PANEL()
        {
            dataGridCard.Enabled = false;
            lbl_loadingCard.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
            txt_cardDifferencies.Enabled = false;
            combo_cardNumber.Enabled = false;
            btn_publishBlog.Visible = false;

            get_cardID = (Int32)dataGridCard.CurrentRow.Cells[0].Value;
            txt_cardNumber.Text = dataGridCard.CurrentRow.Cells[1].Value.ToString();
            get_cardPublish = dataGridCard.CurrentRow.Cells[2].Value.ToString();
            if (dataGridCard.CurrentRow.Cells[3].Value.ToString() == "Y")
                chk_scanned.Checked = true;
            else
                chk_scanned.Checked = false;
            if (dataGridCard.CurrentRow.Cells[4].Value.ToString() == "Y")
                chk_blog.Checked = true;
            else
                chk_blog.Checked = false;
            get_cardCountry = dataGridCard.CurrentRow.Cells[5].Value.ToString();
            txt_descENG.Text = dataGridCard.CurrentRow.Cells[6].Value.ToString();
            txt_descORIG.Text = dataGridCard.CurrentRow.Cells[7].Value.ToString();
            get_cardTheme = dataGridCard.CurrentRow.Cells[8].Value.ToString();
            get_cardColoring = dataGridCard.CurrentRow.Cells[9].Value.ToString();
            get_cardYear = dataGridCard.CurrentRow.Cells[10].Value.ToString();
            txt_totalmgInCard.Text = dataGridCard.CurrentRow.Cells[11].Value.ToString();
            if (dataGridCard.CurrentRow.Cells[12].Value.ToString() == "Y")
                chk_seriesMulti.Checked = true;
            else
                chk_seriesMulti.Checked = false;
            txt_totSeriesCards.Text = dataGridCard.CurrentRow.Cells[13].Value.ToString();
            get_cardSize = dataGridCard.CurrentRow.Cells[14].Value.ToString();
            get_cardShape = dataGridCard.CurrentRow.Cells[15].Value.ToString();
            get_cardOrient = dataGridCard.CurrentRow.Cells[16].Value.ToString();
            txt_barcodeGen.Text = dataGridCard.CurrentRow.Cells[17].Value.ToString();
            get_cardMaterial = dataGridCard.CurrentRow.Cells[18].Value.ToString();
            get_cardCond = dataGridCard.CurrentRow.Cells[19].Value.ToString();
            if (dataGridCard.CurrentRow.Cells[20].Value.ToString() == "Y")
                chk_borders.Checked = true;
            else
                chk_borders.Checked = false;
            txt_frtTxtColor.Text = dataGridCard.CurrentRow.Cells[21].Value.ToString();
            txt_backTxtColor.Text = dataGridCard.CurrentRow.Cells[22].Value.ToString();
            if ((dataGridCard.CurrentRow.Cells[23].Value.ToString()).Trim() != "")
            {
                txt_datePurchase.Text = dataGridCard.CurrentRow.Cells[23].Value.ToString();
                try
                {
                    dateTimePicker1.Value = DateTime.Parse(txt_datePurchase.Text);
                }
                catch
                {
                    dateTimePicker1.Value = DateTime.Now;
                }
            }
            else
            {
                txt_datePurchase.Text = "";
                dateTimePicker1.Value = DateTime.Now;
            }
            txt_price.Text = dataGridCard.CurrentRow.Cells[24].Value.ToString();
            txt_webpage.Text = dataGridCard.CurrentRow.Cells[25].Value.ToString();
            // Check the identical checkbox
            if (dataGridCard.CurrentRow.Cells[26].Value.ToString() == "Y")
            {
                chk_identical.Checked = true;
                txt_cardDifferencies.Enabled = true;
                combo_cardNumber.Enabled = true;
            }
            else
            {
                chk_identical.Checked = false;
                txt_cardDifferencies.Enabled = false;
                combo_cardNumber.Enabled = false;
            }
            get_cardEquals = dataGridCard.CurrentRow.Cells[27].Value.ToString();
            txt_cardDifferencies.Text = dataGridCard.CurrentRow.Cells[28].Value.ToString();
            txt_bigDescription.Text = dataGridCard.CurrentRow.Cells[29].Value.ToString();
            get_cardSentType = dataGridCard.CurrentRow.Cells[30].Value.ToString();
            txt_TypeDesc.Text = dataGridCard.CurrentRow.Cells[31].Value.ToString();

            if (chkCard == true)
            {
                txt_frontImgPath.Text = dataGridCard.CurrentRow.Cells[32].Value.ToString();
                txt_backImgPath.Text = dataGridCard.CurrentRow.Cells[33].Value.ToString();
            }
            else
            {
                txt_frontImgPath.Text = "";
                txt_backImgPath.Text = "";
            }
            pic_loader();

            try
            {
                con.connectdb.Open();
                lbl_dbConnect.ForeColor = Color.Green;
                lbl_dbConnect.Text = "Connected";
                con.connectdb.Close();

                dc.Show_ColoringTable();
                combo_coloring.DataSource = dc.dt_coloringFill;
                if (combo_coloring.FindString(get_cardColoring) >= 0)
                    combo_coloring.SelectedIndex = combo_coloring.FindString(get_cardColoring);
                else
                    combo_coloring.SelectedIndex = 0;

                dc.Show_CondTable();
                combo_cond.DataSource = dc.dt_condFill;
                if (combo_cond.FindString(get_cardCond) >= 0)
                    combo_cond.SelectedIndex = combo_cond.FindString(get_cardCond);

                dc.Show_CountryTable();
                combo_country.DataSource = dc.dt_countryFill;
                if (combo_country.FindString(get_cardCountry) >= 0)
                    combo_country.SelectedIndex = combo_country.FindString(get_cardCountry);

                dc.Show_MaterialTable();
                combo_material.DataSource = dc.dt_materialFill;
                if (combo_material.FindString(get_cardMaterial) >= 0)
                    combo_material.SelectedIndex = combo_material.FindString(get_cardMaterial);

                dc.Show_OrientTable();
                combo_orient.DataSource = dc.dt_orientFill;
                if (combo_orient.FindString(get_cardOrient) >= 0)
                    combo_orient.SelectedIndex = combo_orient.FindString(get_cardOrient);

                dc.Show_PublishTable();
                combo_publish.DataSource = dc.dt_publishFill;
                if (combo_publish.FindString(get_cardPublish) >= 0)
                    combo_publish.SelectedIndex = combo_publish.FindString(get_cardPublish);

                dc.Show_SentTypeTable();
                combo_SentType.DataSource = dc.dt_sentTypeFill;
                if (combo_SentType.FindString(get_cardSentType) >= 0)
                    combo_SentType.SelectedIndex = combo_SentType.FindString(get_cardSentType);

                dc.Show_ShapeTable();
                combo_shape.DataSource = dc.dt_shapeFill;
                if (combo_shape.FindString(get_cardShape) >= 0)
                    combo_shape.SelectedIndex = combo_shape.FindString(get_cardShape);

                dc.Show_SizeTable();
                combo_size.DataSource = dc.dt_sizeFill;
                if (combo_size.FindString(get_cardSize) >= 0)
                    combo_size.SelectedIndex = combo_size.FindString(get_cardSize);

                dc.Show_ThemeTable();
                combo_theme.DataSource = dc.dt_themeFill;
                if (combo_theme.FindString(get_cardTheme) >= 0)
                    combo_theme.SelectedIndex = combo_theme.FindString(get_cardTheme);

                dc.Show_YearTable();
                combo_year.DataSource = dc.dt_yearFill;
                if (combo_year.FindString(get_cardYear) >= 0)
                    combo_year.SelectedIndex = combo_year.FindString(get_cardYear);

                dc.Show_CardNumberTable();
                combo_cardNumber.DataSource = dc.dt_cardNumberFill;
                if (chk_identical.Checked == true)
                    {
                    if (combo_cardNumber.FindString(get_cardEquals) >= 0)
                        combo_cardNumber.SelectedIndex = combo_cardNumber.FindString(get_cardEquals);
                }
            }
            catch
            {
                lbl_dbConnect.ForeColor = Color.Red;
                lbl_dbConnect.Text = "Error";
                string message = "Connection error! Please check your internet connection and/or database connection.";
                MessageBox.Show(message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
            lbl_loadingCard.Visible = false;
            Cursor.Current = Cursors.Default;
        }



        // Just the preparation for the add/edit panel
        private void VIEW_PANEL()
        {
            dataGridCard.Enabled = false;
            lbl_loadingCard.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
            btn_publishBlog.Visible = false;

            // disable updating and adding
            btn_saveCard.Visible = false;
            btn_openFrontImg.Enabled = false;
            btn_openBackImg.Enabled = false;
            dateTimePicker1.Enabled = false;
            chk_updateCard.Visible = false;

            txt_cardNumber.Text = dataGridCard.CurrentRow.Cells[1].Value.ToString();
            combo_publish.Text = dataGridCard.CurrentRow.Cells[2].Value.ToString();
            if (dataGridCard.CurrentRow.Cells[3].Value.ToString() == "Y")
                chk_scanned.Checked = true;
            else
                chk_scanned.Checked = false;
            if (dataGridCard.CurrentRow.Cells[4].Value.ToString() == "Y")
                chk_blog.Checked = true;
            else
                chk_blog.Checked = false;
            combo_country.Text = dataGridCard.CurrentRow.Cells[5].Value.ToString();
            txt_descENG.Text = dataGridCard.CurrentRow.Cells[6].Value.ToString();
            txt_descORIG.Text = dataGridCard.CurrentRow.Cells[7].Value.ToString();
            combo_theme.Text = dataGridCard.CurrentRow.Cells[8].Value.ToString();
            combo_coloring.Text = dataGridCard.CurrentRow.Cells[9].Value.ToString();
            combo_year.Text = dataGridCard.CurrentRow.Cells[10].Value.ToString();
            txt_totalmgInCard.Text = dataGridCard.CurrentRow.Cells[11].Value.ToString();
            if (dataGridCard.CurrentRow.Cells[12].Value.ToString() == "Y")
                chk_seriesMulti.Checked = true;
            else
                chk_seriesMulti.Checked = false;
            txt_totSeriesCards.Text = dataGridCard.CurrentRow.Cells[13].Value.ToString();
            combo_size.Text = dataGridCard.CurrentRow.Cells[14].Value.ToString();
            combo_shape.Text = dataGridCard.CurrentRow.Cells[15].Value.ToString();
            combo_orient.Text = dataGridCard.CurrentRow.Cells[16].Value.ToString();
            txt_barcodeGen.Text = dataGridCard.CurrentRow.Cells[17].Value.ToString();
            combo_material.Text = dataGridCard.CurrentRow.Cells[18].Value.ToString();
            combo_cond.Text = dataGridCard.CurrentRow.Cells[19].Value.ToString();
            if (dataGridCard.CurrentRow.Cells[20].Value.ToString() == "Y")
                chk_borders.Checked = true;
            else
                chk_borders.Checked = false;
            txt_frtTxtColor.Text = dataGridCard.CurrentRow.Cells[21].Value.ToString();
            txt_backTxtColor.Text = dataGridCard.CurrentRow.Cells[22].Value.ToString();
            if ((dataGridCard.CurrentRow.Cells[23].Value.ToString()).Trim() != "")
            {
                txt_datePurchase.Text = dataGridCard.CurrentRow.Cells[23].Value.ToString();
                try
                {
                    dateTimePicker1.Value = DateTime.Parse(txt_datePurchase.Text);
                }
                catch
                {
                    dateTimePicker1.Value = DateTime.Now;
                }
            }
            else
            {
                txt_datePurchase.Text = "";
                dateTimePicker1.Value = DateTime.Now;
            }
            txt_price.Text = dataGridCard.CurrentRow.Cells[24].Value.ToString();
            txt_webpage.Text = dataGridCard.CurrentRow.Cells[25].Value.ToString();
            if (dataGridCard.CurrentRow.Cells[26].Value.ToString() == "Y")
            {
                chk_identical.Checked = true;
            }
            else
            {
                chk_identical.Checked = false;
            }
            combo_cardNumber.Text = dataGridCard.CurrentRow.Cells[27].Value.ToString();
            txt_cardDifferencies.Text = dataGridCard.CurrentRow.Cells[28].Value.ToString();
            txt_bigDescription.Text = dataGridCard.CurrentRow.Cells[29].Value.ToString();
            combo_SentType.Text = dataGridCard.CurrentRow.Cells[30].Value.ToString();
            txt_TypeDesc.Text = dataGridCard.CurrentRow.Cells[31].Value.ToString();
            txt_frontImgPath.Text = dataGridCard.CurrentRow.Cells[32].Value.ToString();
            txt_backImgPath.Text = dataGridCard.CurrentRow.Cells[33].Value.ToString();
            if (txt_frontImgPath.Text.Trim()!="")
                pic_loader();

            // Check database connection
            try
            {
                con.connectdb.Open();
                lbl_dbConnect.ForeColor = Color.Green;
                lbl_dbConnect.Text = "Connected";
                con.connectdb.Close();
            }
            catch
            {
                lbl_dbConnect.ForeColor = Color.Red;
                lbl_dbConnect.Text = "Error";
                string message = "Connection error! Please check your internet connection and/or database connection.";
                MessageBox.Show(message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
            lbl_loadingCard.Visible = false;
            Cursor.Current = Cursors.Default;
        }



        // refresh all data in the datagrid but stays in the same card
        private void REFRESH_CARD_STILL()
        {
            int localRow;
            try
            {
                localRow = dataGridCard.CurrentRow.Index;
            }
            catch
            {
                localRow = dataGridCard.RowCount;
            }
            dataGridCard.DataSource = null;
            dataGridCard.BackgroundColor = Color.FromArgb(64, 64, 64);
            dc.REFRESH_CARD();
            dataGridCard.DataSource = dc.DT;
            try
            {
                dataGridCard.Rows[localRow].Selected = true;
                dataGridCard.FirstDisplayedScrollingRowIndex = localRow;
            }
            catch
            {
                localRow = 0;
            }
            dataGridCard.Focus();
            dataGridCard.Enabled = true;
        }



        // Seeach list
        private void combo_searchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* all options to search list
                01. Card Number
                02. Publisher
                03. Scanned ?
                04. Published in the blog ?
                05. Country
                06. Description ENG
                07. Description ORG
                08. Theme
                09. Series ?
                10. Condition
                11. Borders ?
                12. Identical ?
                13. Offer Type Description
            */
            if (combo_searchType.SelectedIndex == 1)
                search_option = "cardnumber";
            else if (combo_searchType.SelectedIndex == 2)
                search_option = "cardpublisher";
            else if (combo_searchType.SelectedIndex == 3)
                search_option = "cardscanned";
            else if (combo_searchType.SelectedIndex == 4)
                search_option = "cardintheblog";
            else if (combo_searchType.SelectedIndex == 5)
                search_option = "cardcountryname";
            else if (combo_searchType.SelectedIndex == 6)
                search_option = "carddesceng";
            else if (combo_searchType.SelectedIndex == 7)
                search_option = "carddescoriginal";
            else if (combo_searchType.SelectedIndex == 8)
                search_option = "cardthemename";
            else if (combo_searchType.SelectedIndex == 9)
                search_option = "cardseriesmulti";
            else if (combo_searchType.SelectedIndex == 10)
                search_option = "cardcondabr";
            else if (combo_searchType.SelectedIndex == 11)
                search_option = "cardborders";
            else if (combo_searchType.SelectedIndex == 12)
                search_option = "cardidentical";
            else if (combo_searchType.SelectedIndex == 13)
                search_option = "cardtypedesc";
            else
                search_option = "";
        }



        // Search button
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (search_option != "" && txt_searchBox.Text.ToString() != "")
            {
                dataGridCard.DataSource = null;
                dc.SEARCH_CARD(search_option, txt_searchBox.Text.ToString());
                dataGridCard.DataSource = dc.DT;
                dataGridCard.Enabled = true;
            }
            else
                MessageBox.Show("You have to choose where to search and write some text to search.");
        }
    }
}
