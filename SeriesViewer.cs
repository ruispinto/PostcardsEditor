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
    public partial class SeriesViewer : Form
    {
        connection_class con = new connection_class();
        dataclass dc = new dataclass();

        // Temporary variables
        public string upd_mainCardNumber, upd_seriesSecondNumber, get_seriesColoring, get_seriesYear, get_seriesOrient;

        // update (or not) postcard
        public bool chkSeries = false;

        public SeriesViewer(string multiCardNumber)
        {
            InitializeComponent();
            upd_mainCardNumber = multiCardNumber;
            panel2.Visible = false;
        }

        private void SeriesViewer_Load(object sender, EventArgs e)
        {
            dataGridSeries.DataSource = null;

            // tests database connection
            try
            {
                if (upd_mainCardNumber == "")
                {
                    txt_MainCard.Text = "";
                    dc.REFRESH_ALL_MULTICARD();
                    chk_allSeries.Checked = true;
                    chk_allSeries.Visible = false;
                }
                else
                {
                    txt_MainCard.Text = upd_mainCardNumber;
                    dc.REFRESH_MULTICARD(upd_mainCardNumber);
                    chk_allSeries.Checked = false;
                    chk_allSeries.Visible = true;
                }
                dataGridSeries.DataSource = dc.DT;
            }
            catch
            {
                MessageBox.Show("Connection error! Please check your internet connection.");
                this.Close();
            }
        }

        private void btn_seriesAdd_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel2.Visible = true;
            lbl_seriesAddEdit.Text = "Add Postcard";
            chkSeries = false;
            chk_seriesUpdate.Checked = false;

            LOAD_SPANEL();

            dataGridSeries.DataSource = null;
            if (chk_allSeries.Checked == true)
                dc.REFRESH_ALL_MULTICARD();
            else
                dc.REFRESH_MULTICARD(upd_mainCardNumber);
            dataGridSeries.DataSource = dc.DT;
        }

        private void btn_seriesEdit_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel2.Visible = true;
            lbl_seriesAddEdit.Text = "Edit Postcard";
            chkSeries = true;
            chk_seriesUpdate.Checked = true;

            LOAD_SPANEL();

            dataGridSeries.DataSource = null;
            if (chk_allSeries.Checked == true)
                dc.REFRESH_ALL_MULTICARD();
            else
                dc.REFRESH_MULTICARD(upd_mainCardNumber);
            dataGridSeries.DataSource = dc.DT;
        }

        private void btn_seriesDelete_Click(object sender, EventArgs e)
        {
            string del_msg = "You are about to delete:\n\nPostcard Number: " + dataGridSeries.CurrentRow.Cells[0].Value.ToString() + "\nFrom Main Postcard Number: " + upd_mainCardNumber + "\n\nAre you sure ?";
            DialogResult dialog = MessageBox.Show(del_msg, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            btn_seriesDelete.Enabled = false;
            chk_seriesDelete.Checked = false;
            if (dialog == DialogResult.Yes)
            {
                txt_seriesSecondNumber.Text = dataGridSeries.CurrentRow.Cells[1].Value.ToString();
                dc.seriesSecCardNumber= txt_seriesSecondNumber.Text;
                dc.DELETE_SERIESCARD();

                dataGridSeries.DataSource = null;
                dc.REFRESH_MULTICARD(upd_mainCardNumber);
                dataGridSeries.DataSource = dc.DT;

                del_msg = "Postcard number " + txt_seriesSecondNumber.Text.Trim() + " deleted!";
                MessageBox.Show(del_msg, "", MessageBoxButtons.OK);
            }
        }

        private void btn_seriesOpenBackImg_Click(object sender, EventArgs e)
        {
            // display dialog box to choose a new back image
            OpenFileDialog picPicker = new OpenFileDialog();
            if (picPicker.ShowDialog() == DialogResult.OK)
            {
                pic_seriesBackImg.Image = new Bitmap(picPicker.FileName);
                txt_seriesBackImg.Text = picPicker.FileName;
                pic_seriesBackImg.Enabled = true;
            }
        }

        private void btn_seriesOpenFrontImg_Click(object sender, EventArgs e)
        {
            // display dialog box to choose a new front image
            OpenFileDialog picPicker = new OpenFileDialog();
            if (picPicker.ShowDialog() == DialogResult.OK)
            {
                pic_seriesFrontImg.Image = new Bitmap(picPicker.FileName);
                txt_seriesFrontImg.Text = picPicker.FileName;
                pic_seriesFrontImg.Enabled = true;
            }
        }

        /*
         *      SAVE TO EXCEL FILE (no need to have Excel installed in your computer
         */
        private void btn_seriesSaveExcel_Click(object sender, EventArgs e)
        {
            // initial settings for the file dialog
            sFileDialog.InitialDirectory = "C:";
            sFileDialog.Title = "Save as Excel File";
            sFileDialog.FileName = "";
            sFileDialog.Filter = "Excel Files 2007 and up|*.xlsx";

            // choose the folder where to write the file. If 'OK' is pressed, it saves the complete path to that folder.
            if (sFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                // change cursor to wait mode while saving the file
                Cursor.Current = Cursors.WaitCursor;

                // EPPlus license (Excel isn't required to be installed in the computer. You may use other open source software to open it)
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(new System.IO.FileInfo(sFileDialog.FileName)))
                {
                    // define spreadsheet's sheet name
                    var worksheet = package.Workbook.Worksheets.Add("Postcard Series");

                    // save the header
                    for (int i = 1; i < dataGridSeries.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i].Value = dataGridSeries.Columns[i - 1].HeaderText;
                    }

                    // save all information in the gridview to the spreadsheet
                    for (int i = 0; i < dataGridSeries.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridSeries.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataGridSeries.Rows[i].Cells[j].Value.ToString();
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

        private void chk_allSeries_CheckedChanged(object sender, EventArgs e)
        {
            dataGridSeries.DataSource = null;
            CHECKS_SERIES();
        }

        private void CHECKS_SERIES()
        {
            if (chk_allSeries.Checked == true)
            {
                dataGridSeries.DataSource = null;
                dc.REFRESH_ALL_MULTICARD();
                dataGridSeries.DataSource = dc.DT;
            }
            else
            {
                dataGridSeries.DataSource = null;
                dc.REFRESH_MULTICARD(upd_mainCardNumber);
                dataGridSeries.DataSource = dc.DT;
            }
        }

        private void dataGridSeries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            lbl_seriesRowNumber.Text = "Row " + (dataGridSeries.CurrentRow.Index + 1).ToString() + " / " + (dataGridSeries.RowCount).ToString();
        }

        private void dataGridSeries_CellContentClick(object sender, KeyEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            lbl_seriesRowNumber.Text = "Row " + (dataGridSeries.CurrentRow.Index + 1).ToString() + " / " + (dataGridSeries.RowCount).ToString();
        }

        private void dataGridSeries_CellContentClick(object sender, KeyPressEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            lbl_seriesRowNumber.Text = "Row " + (dataGridSeries.CurrentRow.Index + 1).ToString() + " / " + (dataGridSeries.RowCount).ToString();
        }

        private void btn_seriesPanelClose_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;

            // Re-enable all fields
            if (txt_mainCardNumber.Enabled == false)
            {
                txt_mainCardNumber.Enabled = true;
                txt_seriesBackImg.Enabled = true;
                txt_seriesBackTxtColor.Enabled = true;
                txt_seriesBarcodeGen.Enabled = true;
                txt_seriesBigDescription.Enabled = true;
                txt_seriesDate.Enabled = true;
                txt_seriesDescENG.Enabled = true;
                txt_seriesDescORIG.Enabled = true;
                txt_seriesFrontImg.Enabled = true;
                txt_seriesFrtTxtColor.Enabled = true;
                txt_seriesSecondNumber.Enabled = true;
                txt_seriesTotalImgCard.Enabled = true;
                chk_seriesUpdate.Visible = true;
                btn_seriesSave.Enabled = true;
                btn_seriesOpenBackImg.Enabled = true;
                btn_seriesOpenFrontImg.Enabled = true;
                btn_seriesSave.Visible = true;
                txt_MainCard.Enabled = true;
                combo_seriesColoring.Enabled = true;
                combo_seriesOrient.Enabled = true;
                combo_seriesYear.Enabled = true;
                dateTimePickerSeries.Enabled = true;
                chk_seriesUpdate.Enabled = true;
            }
            panel1.Enabled = true;
        }

        private void btn_seriesViewerClose_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            this.Close();
        }

        private void dataGridSeries_ViewContent(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            lbl_seriesAddEdit.Text = "View Serie Postcard";

            VIEW_SPANEL();
        }

        private void btn_seriesSave_Click(object sender, EventArgs e)
        {
            int localRow = dataGridSeries.CurrentRow.Index;
            if (txt_mainCardNumber.Text.Length > 0 || txt_mainCardNumber.Text.Trim() != "" && txt_seriesSecondNumber.Text.Length > 0 || txt_seriesSecondNumber.Text.Trim() != "" && txt_seriesSecondNumber.Text.Trim()!=txt_mainCardNumber.Text.Trim())
            {
                dc.seriesCardNumber = txt_mainCardNumber.Text;
                dc.seriesSecCardNumber = txt_seriesSecondNumber.Text;
                upd_mainCardNumber = txt_mainCardNumber.Text;
                upd_seriesSecondNumber = txt_seriesSecondNumber.Text;
                dc.seriesDescEng = txt_seriesDescENG.Text;
                dc.seriesDescOrg = txt_seriesDescORIG.Text;
                if (combo_seriesColoring.Text == "Choose...")
                {
                    dc.seriesColorAbr = "";
                }
                else
                {
                    dc.cardColoring = combo_seriesColoring.Text;
                }
                if (combo_seriesOrient.Text == "Choose...")
                {
                    dc.seriesOrient = "";
                }
                else
                {
                    dc.seriesOrient = combo_seriesOrient.Text;
                }
                dc.seriesImgCount = txt_seriesTotalImgCard.Text;
                if (txt_seriesDate.TextLength > 10)
                    txt_seriesDate.Text = txt_seriesDate.Text.Substring(0, 10);
                dc.seriesDate = txt_seriesDate.Text;
                if (combo_seriesYear.Text == "Choose...")
                {
                    dc.seriesYearNumber = "----";
                }
                else
                {
                    dc.seriesYearNumber = combo_seriesYear.Text;
                }
                dc.seriesBarcode = txt_seriesBarcodeGen.Text;
                dc.seriesFrontTxtColor = txt_seriesFrtTxtColor.Text;
                dc.seriesBackTxtColor = txt_seriesBackTxtColor.Text;
                dc.seriesBigDesc = txt_seriesBigDescription.Text;
                dc.seriesFrontImgPath = txt_seriesFrontImg.Text;
                dc.seriesBackImgPath = txt_seriesBackImg.Text;

                // check if it is a new postcard or an update
                if (chkSeries == true)
                    dc.UPDATE_SERIESCARD();
                else
                    dc.ADD_SERIESCARD();

                // create a messegabox with all results to confirm
                string query = "Postcard\n\nCard Number: " + txt_seriesSecondNumber.Text + "\nFrom Main Series: " + txt_mainCardNumber.Text + "\n\nSaved!";
                MessageBox.Show(query);

                con.connectdb.Close();
                panel2.Visible = false;

            }
            else
            {
                MessageBox.Show("Field 'Main Card Number'  and 'Secondary Card Number' cannot be empty.\nField 'Secondary Card Number' must have a unique number.", "Main & Secondary Numbers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataGridSeries.DataSource = null;
            dc.REFRESH_ALL_MULTICARD();
            dataGridSeries.DataSource = dc.DT;
            dataGridSeries.Rows[localRow].Selected = true;
            dataGridSeries.FirstDisplayedScrollingRowIndex = localRow;
            dataGridSeries.Focus();
        }

        private void chk_seriesDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_seriesDelete.Checked == true)
                btn_seriesDelete.Enabled = true;
            else
                btn_seriesDelete.Enabled = false;
        }

        private void pic_loader(object sender, EventArgs e)
        {
            // test if the front image is a real image file
            try
            {
                // if is the real image, display the new image
                if (txt_seriesFrontImg.Text.Substring(0, 4) == "HTTP" || txt_seriesFrontImg.Text.Substring(0, 4) == "http")
                    pic_seriesFrontImg.ImageLocation = txt_seriesFrontImg.Text;
                else
                    pic_seriesFrontImg.Image = new Bitmap(txt_seriesFrontImg.Text);
            }
            catch
            {
                // if it's not, display the default image
                pic_seriesFrontImg.Image = new Bitmap(Properties.Resources.no_image);
            }

            // test if the back image is a real image file
            try
            {
                // if is the real image, display the new image
                if (txt_seriesBackImg.Text.Substring(0, 4) == "HTTP" || txt_seriesBackImg.Text.Substring(0, 4) == "http")
                    pic_seriesBackImg.ImageLocation = txt_seriesBackImg.Text;
                else
                    pic_seriesBackImg.Image = new Bitmap(txt_seriesBackImg.Text);
            }
            catch
            {
                // if it's not, display the default image
                pic_seriesBackImg.Image = new Bitmap(Properties.Resources.no_image);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (txt_seriesDate.Text.Trim() != "")
                txt_seriesDate.Text = dateTimePickerSeries.Value.ToString();
        }

        // Just the preparation for the add/edit panel
        private void LOAD_SPANEL()
        {
            lbl_loadingSeries.Visible = true;
            Cursor.Current = Cursors.WaitCursor;

            txt_mainCardNumber.Text = dataGridSeries.CurrentRow.Cells[0].Value.ToString();
            if (chkSeries == true)
                txt_mainCardNumber.Enabled = false;
            else
                txt_mainCardNumber.Enabled = true;
            txt_seriesSecondNumber.Text = dataGridSeries.CurrentRow.Cells[1].Value.ToString();
            dc.old_seriesSecond = txt_seriesSecondNumber.Text;
            txt_seriesDescENG.Text = dataGridSeries.CurrentRow.Cells[2].Value.ToString();
            txt_seriesDescORIG.Text = dataGridSeries.CurrentRow.Cells[3].Value.ToString();
            get_seriesColoring = dataGridSeries.CurrentRow.Cells[4].Value.ToString();
            get_seriesOrient = dataGridSeries.CurrentRow.Cells[5].Value.ToString();
            txt_seriesTotalImgCard.Text = dataGridSeries.CurrentRow.Cells[6].Value.ToString();
            if ((dataGridSeries.CurrentRow.Cells[7].Value.ToString()).Trim() != "")
            {
                txt_seriesDate.Text = dataGridSeries.CurrentRow.Cells[7].Value.ToString();
                try
                {
                    dateTimePickerSeries.Value = DateTime.Parse(txt_seriesDate.Text);
                }
                catch
                {
                    dateTimePickerSeries.Value = DateTime.Now;
                }
            }
            else
            {
                txt_seriesDate.Text = "";
                dateTimePickerSeries.Value = DateTime.Now;
            }
            get_seriesYear = dataGridSeries.CurrentRow.Cells[8].Value.ToString();
            txt_seriesBarcodeGen.Text = dataGridSeries.CurrentRow.Cells[9].Value.ToString();
            txt_seriesFrtTxtColor.Text = dataGridSeries.CurrentRow.Cells[10].Value.ToString();
            txt_seriesBackTxtColor.Text = dataGridSeries.CurrentRow.Cells[11].Value.ToString();
            txt_seriesBigDescription.Text = dataGridSeries.CurrentRow.Cells[12].Value.ToString();
            if (chkSeries == true)
            {
                txt_seriesFrontImg.Text = dataGridSeries.CurrentRow.Cells[13].Value.ToString();
                txt_seriesBackImg.Text = dataGridSeries.CurrentRow.Cells[14].Value.ToString();
            }
            else
            {
                txt_seriesFrontImg.Text = "";
                txt_seriesBackImg.Text = "";
            }

            // Check if any of the image path fields has any image name. If it has, it shows, otherwise just show the default image
            try
            {
                // Front Image
                if (txt_seriesFrontImg.Text == "" || txt_seriesFrontImg.Text == null)
                {
                    pic_seriesFrontImg.Image = new Bitmap(Properties.Resources.no_image);
                }
                else
                {
                    if (txt_seriesFrontImg.Text.Substring(0, 4) == "HTTP" || txt_seriesFrontImg.Text.Substring(0, 4) == "http")
                        pic_seriesFrontImg.ImageLocation = txt_seriesFrontImg.Text;
                    else
                        pic_seriesFrontImg.Image = new Bitmap(txt_seriesFrontImg.Text);
                }
            }
            catch
            {
                pic_seriesFrontImg.Image = new Bitmap(Properties.Resources.no_image);
            }
            try
            {
                // Back image
                if (txt_seriesBackImg.Text == "" || txt_seriesBackImg.Text == null)
                {
                    pic_seriesBackImg.Image = new Bitmap(Properties.Resources.no_image);
                }
                else
                {
                    if (txt_seriesBackImg.Text.Substring(0, 4) == "HTTP" || txt_seriesBackImg.Text.Substring(0, 4) == "http")
                        pic_seriesBackImg.ImageLocation = txt_seriesBackImg.Text;
                    else
                        pic_seriesBackImg.Image = new Bitmap(txt_seriesBackImg.Text);
                }
            }
            catch
            {
                pic_seriesBackImg.Image = new Bitmap(Properties.Resources.no_image);
            }

            try
            {
                dc.Show_ColoringTable();
                combo_seriesColoring.DataSource = dc.dt_coloringFill;
                if (combo_seriesColoring.FindString(get_seriesColoring) >= 0)
                    combo_seriesColoring.SelectedIndex = combo_seriesColoring.FindString(get_seriesColoring);
                else
                    combo_seriesColoring.SelectedIndex = 0;

                dc.Show_OrientTable();
                combo_seriesOrient.DataSource = dc.dt_orientFill;
                if (combo_seriesOrient.FindString(get_seriesOrient) >= 0)
                    combo_seriesOrient.SelectedIndex = combo_seriesOrient.FindString(get_seriesOrient);

                dc.Show_YearTable();
                combo_seriesYear.DataSource = dc.dt_yearFill;
                if (combo_seriesYear.FindString(get_seriesYear) >= 0)
                    combo_seriesYear.SelectedIndex = combo_seriesYear.FindString(get_seriesYear);
            }
            catch
            {
                string message = "Connection error! Please check your internet connection and/or database connection.";
                MessageBox.Show(message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
            lbl_loadingSeries.Visible = false;
            Cursor.Current = Cursors.Default;
        }

        // Just the preparation for the add/edit panel
        private void VIEW_SPANEL()
        {
            lbl_loadingSeries.Visible = true;
            Cursor.Current = Cursors.WaitCursor;

            // Disable all fields
            txt_mainCardNumber.Enabled = false;
            txt_seriesBackImg.Enabled = false;
            txt_seriesBackTxtColor.Enabled = false;
            txt_seriesBarcodeGen.Enabled = false;
            txt_seriesBigDescription.Enabled = false;
            txt_seriesDate.Enabled = false;
            txt_seriesDescENG.Enabled = false;
            txt_seriesDescORIG.Enabled = false;
            txt_seriesFrontImg.Enabled = false;
            txt_seriesFrtTxtColor.Enabled = false;
            txt_seriesSecondNumber.Enabled = false;
            txt_seriesTotalImgCard.Enabled = false;
            chk_seriesUpdate.Visible = false;
            btn_seriesOpenBackImg.Enabled = false;
            btn_seriesOpenFrontImg.Enabled = false;
            btn_seriesSave.Visible = false;
            txt_MainCard.Enabled = false;
            combo_seriesColoring.Enabled = false;
            combo_seriesOrient.Enabled = false;
            combo_seriesYear.Enabled = false;
            dateTimePickerSeries.Enabled = false;

            txt_mainCardNumber.Text = dataGridSeries.CurrentRow.Cells[0].Value.ToString();
            txt_seriesSecondNumber.Text = dataGridSeries.CurrentRow.Cells[1].Value.ToString();
            dc.old_seriesSecond = txt_seriesSecondNumber.Text;
            txt_seriesDescENG.Text = dataGridSeries.CurrentRow.Cells[2].Value.ToString();
            txt_seriesDescORIG.Text = dataGridSeries.CurrentRow.Cells[3].Value.ToString();
            get_seriesColoring = dataGridSeries.CurrentRow.Cells[4].Value.ToString();
            get_seriesOrient = dataGridSeries.CurrentRow.Cells[5].Value.ToString();
            txt_seriesTotalImgCard.Text = dataGridSeries.CurrentRow.Cells[6].Value.ToString();
            if ((dataGridSeries.CurrentRow.Cells[7].Value.ToString()).Trim() != "")
            {
                txt_seriesDate.Text = dataGridSeries.CurrentRow.Cells[7].Value.ToString();
                try
                {
                    dateTimePickerSeries.Value = DateTime.Parse(txt_seriesDate.Text);
                }
                catch
                {
                    dateTimePickerSeries.Value = DateTime.Now;
                }
            }
            else
            {
                txt_seriesDate.Text = "";
                dateTimePickerSeries.Value = DateTime.Now;
            }
            get_seriesYear = dataGridSeries.CurrentRow.Cells[8].Value.ToString();
            txt_seriesBarcodeGen.Text = dataGridSeries.CurrentRow.Cells[9].Value.ToString();
            txt_seriesFrtTxtColor.Text = dataGridSeries.CurrentRow.Cells[10].Value.ToString();
            txt_seriesBackTxtColor.Text = dataGridSeries.CurrentRow.Cells[11].Value.ToString();
            txt_seriesBigDescription.Text = dataGridSeries.CurrentRow.Cells[12].Value.ToString();
            txt_seriesFrontImg.Text = dataGridSeries.CurrentRow.Cells[13].Value.ToString();
            txt_seriesBackImg.Text = dataGridSeries.CurrentRow.Cells[14].Value.ToString();

            // Check if any of the image path fields has any image name. If it has, it shows, otherwise just show the default image
            try
            {
                // Front Image
                if (txt_seriesFrontImg.Text == "" || txt_seriesFrontImg.Text == null)
                {
                    pic_seriesFrontImg.Image = new Bitmap(Properties.Resources.no_image);
                }
                else
                {
                    if (txt_seriesFrontImg.Text.Substring(0, 4) == "HTTP" || txt_seriesFrontImg.Text.Substring(0, 4) == "http")
                        pic_seriesFrontImg.ImageLocation = txt_seriesFrontImg.Text;
                    else
                        pic_seriesFrontImg.Image = new Bitmap(txt_seriesFrontImg.Text);
                }
            }
            catch
            {
                pic_seriesFrontImg.Image = new Bitmap(Properties.Resources.no_image);
            }
            try
            {
                // Back image
                if (txt_seriesBackImg.Text == "" || txt_seriesBackImg.Text == null)
                {
                    pic_seriesBackImg.Image = new Bitmap(Properties.Resources.no_image);
                }
                else
                {
                    if (txt_seriesBackImg.Text.Substring(0, 4) == "HTTP" || txt_seriesBackImg.Text.Substring(0, 4) == "http")
                        pic_seriesBackImg.ImageLocation = txt_seriesBackImg.Text;
                    else
                        pic_seriesBackImg.Image = new Bitmap(txt_seriesBackImg.Text);
                }
            }
            catch
            {
                pic_seriesBackImg.Image = new Bitmap(Properties.Resources.no_image);
            }

            try
            {
                dc.Show_ColoringTable();
                combo_seriesColoring.DataSource = dc.dt_coloringFill;
                if (combo_seriesColoring.FindString(get_seriesColoring) >= 0)
                    combo_seriesColoring.SelectedIndex = combo_seriesColoring.FindString(get_seriesColoring);
                else
                    combo_seriesColoring.SelectedIndex = 0;

                dc.Show_OrientTable();
                combo_seriesOrient.DataSource = dc.dt_orientFill;
                if (combo_seriesOrient.FindString(get_seriesOrient) >= 0)
                    combo_seriesOrient.SelectedIndex = combo_seriesOrient.FindString(get_seriesOrient);

                dc.Show_YearTable();
                combo_seriesYear.DataSource = dc.dt_yearFill;
                if (combo_seriesYear.FindString(get_seriesYear) >= 0)
                    combo_seriesYear.SelectedIndex = combo_seriesYear.FindString(get_seriesYear);
            }
            catch
            {
                string message = "Connection error! Please check your internet connection and/or database connection.";
                MessageBox.Show(message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
            lbl_loadingSeries.Visible = false;
            Cursor.Current = Cursors.Default;
        }
    }
}
