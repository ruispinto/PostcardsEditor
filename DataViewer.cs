﻿using System;
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
        public string get_cardNumber, get_cardPublish, get_cardCountry, get_cardTheme, get_cardColoring, get_cardYear, get_cardSize, get_cardShape, get_cardOrient, get_cardCond, get_cardSentType, get_cardEquals;

        // update (or not) postcard
        public bool chkCard = false;

        public DataViewer()
        {
            InitializeComponent();
            panel2.Visible = false;
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
            }
        }

        private void pic_loader(object sender, EventArgs e)
        {
            // test if the front image is a real image file
            try
            {
                // if is the real image, display the new image
                pic_frontImg.Image = new Bitmap(txt_frontImgPath.Text);
            }
            catch
            {
                // if it's not, display the default image
                pic_frontImg.Image = new Bitmap(Properties.Resources.no_image);
            }

            // test if the back image is a real image file
            try
            {
                // if is the real image, display the new image
                pic_backImg.Image = new Bitmap(txt_backImgPath.Text);
            }
            catch
            {
                // if it's not, display the default image
                pic_backImg.Image = new Bitmap(Properties.Resources.no_image);
            }
        }

        private void btn_saveCard_Click(object sender, EventArgs e)
        {
            if (txt_cardNumber.Text.Length > 0 || txt_cardNumber.Text.Trim() != "")
            {
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
                }
                else
                {
                    dc.cardIdentical = "N";
                }
                if (combo_cardNumber.Text == "Choose...")
                {
                    dc.cardEqualsTo = "";
                }
                else
                {
                    dc.cardEqualsTo = combo_cardNumber.Text;
                }
                dc.cardDifferences = txt_cardDifferencies.Text;
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
                if (chkCard == true)
                    dc.UPDATE_CARD();
                else
                    dc.ADD_CARD();

                // create a messegabox with all results to confirm
                string query = "Card\n\nCard Number: " + txt_cardNumber.Text + "\nPublisher " + combo_publish.Text + "\nCountry " + combo_country.Text + "\n\nSaved!";
                MessageBox.Show(query);

                con.connectdb.Close();
                panel2.Visible = false;
            }
            else
            {
                MessageBox.Show("Field 'Card Number' cannot be empty.", "Card Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            Form newform = new About();
            newform.Show();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void chk_identical_CheckedChanged(object sender, EventArgs e)
        {
            // checi if the 'identical' checkbox is checked or not
            if (!chk_identical.Checked)
            {
                // fields disabled if 'identical' checkbox isn't checked
                lbl_cardEqualsTo.Enabled = false;
                lbl_differencies.Enabled = false;
                txt_cardDifferencies.Enabled = false;
                combo_cardNumber.Enabled = false;
            }
            else
            {
                // fields enabled if 'identical' checkbox is checked
                lbl_cardEqualsTo.Enabled = true;
                lbl_differencies.Enabled = true;
                txt_cardDifferencies.Enabled = true;
                combo_cardNumber.Enabled = true;
            }
        }

        private void dtPicker_changed(object sender, EventArgs e)
        {
            txt_datePurchase.Text = dateTimePicker1.Value.ToString();

        }

        private void chk_updateCard_CheckedChanged(object sender, EventArgs e)
        {
            if (!chk_updateCard.Checked == true)
            {
                chkCard = false;
                txt_cardNumber.Enabled = true;
                txt_backImgPath.Text = "";
                txt_frontImgPath.Text = "";
            }
            else
            {
                chkCard = true;
                txt_cardNumber.Enabled = false;
                txt_frontImgPath.Text = dataGridView1.CurrentRow.Cells[30].Value.ToString();
                txt_backImgPath.Text = dataGridView1.CurrentRow.Cells[31].Value.ToString();
            }
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
            }
            else
            {
                btn_delete.Enabled = false;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string del_msg = "You are about to delete:\n\nPostcard Number: " + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "\nPublisher: " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "\n\nAre you sure ?";
            DialogResult dialog = MessageBox.Show(del_msg, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            btn_delete.Enabled = false;
            chk_delete.Checked = false;
            if(dialog == DialogResult.Yes)
            {
                txt_cardNumber.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                dc.cardNumber = txt_cardNumber.Text;
                dc.DELETE_CARD();

                dataGridView1.DataSource = null;
                dc.REFRESH_DATA();
                dataGridView1.DataSource = dc.DT;

                del_msg = "Postcard number " + txt_cardNumber.Text.Trim() + " deleted!";
                MessageBox.Show(del_msg, "", MessageBoxButtons.OK);
            }


        }

        private void DataViewer_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            // tests database connection
            try
            {
                con.connectdb.Open();
                lbl_dbcon.ForeColor = Color.Green;
                lbl_dbcon.Text = "Connected";
                con.connectdb.Close();

                dc.REFRESH_DATA();
                dataGridView1.DataSource = dc.DT;
            }
            catch
            {
                lbl_dbcon.ForeColor = Color.Red;
                lbl_dbcon.Text = "Not Connected!";
                MessageBox.Show("Connection error! Please check your internet connection.");
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            lbl_addEdit.Text = "Add Postcard";
            chkCard = false;

            LOAD_PANEL();

            dataGridView1.DataSource = null;
            dc.REFRESH_DATA();
            dataGridView1.DataSource = dc.DT;
        }

        private void btn_edit_Click(object sender, EventArgs e)

        {
            chkCard = true;
            chk_updateCard.Checked = chkCard;
            panel2.Visible = true;
            lbl_addEdit.Text = "Edit Postcard";

            LOAD_PANEL();
            
            dataGridView1.DataSource = null;
            dc.REFRESH_DATA();
            dataGridView1.DataSource = dc.DT;
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
                using (var package = new ExcelPackage(new System.IO.FileInfo(sFDialog.FileName)))
                {
                    // define spreadsheet's sheet name
                    var worksheet = package.Workbook.Worksheets.Add("Users");

                    // save the header
                    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i].Value = dataGridView1.Columns[i - 1].HeaderText;
                    }

                    // save all information in the gridview to the spreadsheet
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    // adjust column's width
                    worksheet.Cells.AutoFitColumns(0);

                    // save file to the disk
                    package.Save();
                }
                MessageBox.Show("Database exported!");
            }
            // cursor is back to default
            Cursor.Current = Cursors.Default;
        }

        // In case you click with your mouse
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            lbl_rowNumber.Text = "Row " + dataGridView1.CurrentRow.Index.ToString() + " / " + (dataGridView1.RowCount - 1).ToString();
        }

        // In case you press down a key in the grid
        private void dataGridView1_CellContentClick(object sender, KeyPressEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            lbl_rowNumber.Text = "Row " + dataGridView1.CurrentRow.Index.ToString() + " / " + (dataGridView1.RowCount - 1).ToString();
        }

        // in case you move around using arrow keys (or enter key)
        private void dataGridView1_CellContentClick(object sender, KeyEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            lbl_rowNumber.Text = "Row " + dataGridView1.CurrentRow.Index.ToString() + " / " + (dataGridView1.RowCount - 1).ToString();
        }

        // Just the preparation for the add/edit panel
        private void LOAD_PANEL()
        {
            // At the beginning, these fields are disabled
            lbl_cardEqualsTo.Enabled = false;
            lbl_differencies.Enabled = false;
            txt_cardDifferencies.Enabled = false;
            combo_cardNumber.Enabled = false;

            // Check if any of the image path fields has any image name. If it has, it shows, otherwise just show the default image
            if (txt_frontImgPath.Text == "" | txt_frontImgPath.Text == null && txt_backImgPath.Text == "" | txt_backImgPath.Text == null)
            {
                pic_frontImg.Image = new Bitmap(Properties.Resources.no_image);
                pic_backImg.Image = new Bitmap(Properties.Resources.no_image);
                pic_frontImg.Enabled = false;
                pic_backImg.Enabled = false;
            }
            else
            {
                pic_frontImg.Image = new Bitmap(txt_frontImgPath.Text);
                pic_backImg.Image = new Bitmap(txt_backImgPath.Text);
                pic_frontImg.Enabled = true;
                pic_backImg.Enabled = true;
            }

            txt_cardNumber.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            get_cardPublish = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "Y")
                chk_scanned.Checked = true;
            else
                chk_scanned.Checked = false;
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Y")
                chk_blog.Checked = true;
            else
                chk_blog.Checked = false;
            get_cardCountry = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_descENG.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_descORIG.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            get_cardTheme = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            get_cardColoring = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            get_cardYear = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txt_totalmgInCard.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[11].Value.ToString() == "Y")
                chk_seriesMulti.Checked = true;
            else
                chk_seriesMulti.Checked = false;
            txt_totSeriesCards.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            get_cardSize = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            get_cardShape = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            get_cardOrient = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            txt_barcodeGen.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            get_cardCond = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[18].Value.ToString() == "Y")
                chk_borders.Checked = true;
            else
                chk_borders.Checked = false;
            txt_frtTxtColor.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            txt_backTxtColor.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            txt_datePurchase.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            try
            {
                dateTimePicker1.Value = DateTime.Parse(txt_datePurchase.Text);
            }
            catch
            {
                dateTimePicker1.Value = DateTime.Now;
            }
            txt_price.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
            txt_webpage.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[24].Value.ToString() == "Y")
                chk_identical.Checked = true;
            else
                chk_identical.Checked = false;
            get_cardEquals = dataGridView1.CurrentRow.Cells[25].Value.ToString();
            txt_cardDifferencies.Text = dataGridView1.CurrentRow.Cells[26].Value.ToString();
            txt_bigDescription.Text = dataGridView1.CurrentRow.Cells[27].Value.ToString();
            get_cardSentType = dataGridView1.CurrentRow.Cells[28].Value.ToString();
            txt_TypeDesc.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();
            if (chkCard == true)
            {
                txt_frontImgPath.Text = dataGridView1.CurrentRow.Cells[30].Value.ToString();
                txt_backImgPath.Text = dataGridView1.CurrentRow.Cells[31].Value.ToString();
            }
            else
            {
                txt_frontImgPath.Text = "";
                txt_backImgPath.Text = "";
            }

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
                string message = "Connection errror! Please check your internet connection and/or database connection.";
                MessageBox.Show(message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
