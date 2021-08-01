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
    public partial class OtherOptions : Form
    {
        // create connection and dataclass classes
        connection_class con = new connection_class();
        dataclass dc = new dataclass();

        // Option from the simple menu
        public int option = 0;
        public int chkResult;
        public bool chkOtherOptions = false;

        // table name
        public string tblName;

        public OtherOptions()
        {
            InitializeComponent();

        }

        // when this form loads some options are defined here
        private void OtherOptions_Load(object sender, EventArgs e)
        {
            btn_deleteOthers.Enabled = false;
            groupBox2.Enabled = false;
            btn_open.Enabled = true;
            panel2.Visible = false;
            con.connectdb.Close();
            dataGridOthers.ForeColor = Color.FromArgb(64, 64, 64);
        }

        // what to show when you click the Open button
        private void btn_open_Click(object sender, EventArgs e)
        {
            if (r_coloring.Checked)
            {
                option = 1;
                tblName = "Coloring Type";
            }
            else if (r_cond.Checked)
            {
                option = 2;
                tblName = "Condition";
            }
            else if (r_country.Checked)
            {
                option = 3;
                tblName = "Country";
            }
            else if (r_material.Checked)
            {
                option = 4;
                tblName = "Material";
            }
            else if (r_orient.Checked)
            {
                option = 5;
                tblName = "Orientation";
            }
            else if (r_publisher.Checked)
            {
                option = 6;
                tblName = "Publisher";
            }
            else if (r_sentType.Checked)
            {
                option = 7;
                tblName = "Sent Type";
            }
            else if (r_shape.Checked)
            {
                option = 8;
                tblName = "Shape";
            }
            else if (r_size.Checked)
            {
                option = 9;
                tblName = "Size";
            }
            else if (r_theme.Checked)
            {
                option = 10;
                tblName = "Theme";
            }
            else if (r_year.Checked)
            {
                option = 11;
                tblName = "Year";
            }
            else
            {
                // check if any option has been choosen
                MessageBox.Show("You have to choose which table you want to edit.", "No option selected");
                option = 0;
                tblName = "";
            }
            if (option > 0)
            {
                REFRESH_OTHERS_PANEL();
            }
        }

        private void btn_addOthers_Click(object sender, EventArgs e)
        {
            chk_updateOther.Checked = false;
            LOAD_OTHERSPANEL();
        }

        private void btn_editOthers_Click(object sender, EventArgs e)
        {
            chk_updateOther.Checked = true;
            LOAD_OTHERSPANEL();
        }

        private void btn_closeOthers_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chk_deleteOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_deleteOthers.Checked == true)
                btn_deleteOthers.Enabled = true;
            else
                btn_deleteOthers.Enabled = false;
        }

        private void btn_deleteOthers_Click(object sender, EventArgs e)
        {
            string del_msg = "You are about to delete:\n\nValue: " + dataGridOthers.CurrentRow.Cells[1].Value.ToString() + "\n\nfrom table: " + tblName + "\n\nAre you sure ?";
            DialogResult dialog = MessageBox.Show(del_msg, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                if (option > 0)
                    dc.othersID = (Int32)dataGridOthers.CurrentRow.Cells[0].Value;
                dc.DELETE_OTHERS(option);
                MessageBox.Show("Value deleted!", "", MessageBoxButtons.OK);
            }

            if (chk_deleteOthers.Checked == true)
                chk_deleteOthers.Checked = false;
            else
                chk_deleteOthers.Checked = true;

            REFRESH_OTHERS_PANEL();
        }

        private void btn_closeOthersPanel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            btn_open.Enabled = true;
            dataGridOthers.Enabled = true;
            groupBox2.Enabled = true;
            groupBox1.Enabled = true;
            btn_closeOthers.Enabled = true;
        }

        private void chk_updateOther_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_updateOther.Checked == true)
                chkOtherOptions = true;
            else
                chkOtherOptions = false;
        }

        private void LOAD_OTHERSPANEL()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            btn_closeOthers.Enabled = false;

            if (chk_updateOther.Checked == false)
            {
                chkOtherOptions = false;
                panel2.Visible = true;
                btn_open.Enabled = false;
                lbl_otherOptions.Text = "Add : " + tblName;
            }
            else
            {
                chkOtherOptions = true;
                panel2.Visible = true;
                btn_open.Enabled = false;
                lbl_otherOptions.Text = "Edit : " + tblName;
            }

            dataGridOthers.Enabled = false;
            if (option > 0)
                dc.othersID = (Int32)dataGridOthers.CurrentRow.Cells[0].Value;

            if (option == 1)            // Coloring
            {
                lbl_otherOptField1.Text = "Abr.";
                lbl_otherOptField2.Text = "Name";
                txt_otherOptionsField1.Text = dataGridOthers.CurrentRow.Cells[1].Value.ToString();
                txt_otherOptionsField2.Text = dataGridOthers.CurrentRow.Cells[2].Value.ToString();
                SHOW_OTHERS_TABLE(2);

            }
            else if (option == 2)       // Condition
            {
                lbl_otherOptField1.Text = "Abr.";
                lbl_otherOptField2.Text = "Name";
                lbl_otherOptField3.Text = "Description";
                txt_otherOptionsField1.Text = dataGridOthers.CurrentRow.Cells[1].Value.ToString();
                txt_otherOptionsField2.Text = dataGridOthers.CurrentRow.Cells[2].Value.ToString();
                txt_otherOptionsField3.Text = dataGridOthers.CurrentRow.Cells[3].Value.ToString();
                SHOW_OTHERS_TABLE(3);
            }
            else if (option == 3)       // Country
            {
                lbl_otherOptField1.Text = "Country";
                lbl_otherOptField2.Text = "ISO";
                txt_otherOptionsField1.Text = dataGridOthers.CurrentRow.Cells[1].Value.ToString();
                txt_otherOptionsField2.Text = dataGridOthers.CurrentRow.Cells[2].Value.ToString();
                SHOW_OTHERS_TABLE(2);
            }
            else if (option == 4)       // Material
            {
                lbl_otherOptField1.Text = "Name";
                txt_otherOptionsField1.Text = dataGridOthers.CurrentRow.Cells[1].Value.ToString();
                SHOW_OTHERS_TABLE(1);
            }
            else if (option == 5)       // orientation
            {
                lbl_otherOptField1.Text = "Abr.";
                lbl_otherOptField2.Text = "Name";
                txt_otherOptionsField1.Text = dataGridOthers.CurrentRow.Cells[1].Value.ToString();
                txt_otherOptionsField2.Text = dataGridOthers.CurrentRow.Cells[2].Value.ToString();
                SHOW_OTHERS_TABLE(2);
            }
            else if (option == 6)       // publisher
            {
                lbl_otherOptField1.Text = "Publisher";
                lbl_otherOptField2.Text = "Companies";
                txt_otherOptionsField1.Text = dataGridOthers.CurrentRow.Cells[1].Value.ToString();
                txt_otherOptionsField2.Text = dataGridOthers.CurrentRow.Cells[2].Value.ToString();
                SHOW_OTHERS_TABLE(2);
            }
            else if (option == 7)       // sent tyoe
            {
                lbl_otherOptField1.Text = "Name";
                txt_otherOptionsField1.Text = dataGridOthers.CurrentRow.Cells[1].Value.ToString();
                SHOW_OTHERS_TABLE(1);
            }
            else if (option == 8)       // shape
            {
                lbl_otherOptField1.Text = "Name";
                txt_otherOptionsField1.Text = dataGridOthers.CurrentRow.Cells[1].Value.ToString();
                SHOW_OTHERS_TABLE(1);
            }
            else if (option == 9)       // size
            {
                lbl_otherOptField1.Text = "Name";
                txt_otherOptionsField1.Text = dataGridOthers.CurrentRow.Cells[1].Value.ToString();
                SHOW_OTHERS_TABLE(1);
            }
            else if (option == 10)      // theme
            {
                lbl_otherOptField1.Text = "Name";
                txt_otherOptionsField1.Text = dataGridOthers.CurrentRow.Cells[1].Value.ToString();
                SHOW_OTHERS_TABLE(1);
            }
            else if (option == 11)      // year
            {
                lbl_otherOptField1.Text = "Year";
                txt_otherOptionsField1.Text = dataGridOthers.CurrentRow.Cells[1].Value.ToString();
                SHOW_OTHERS_TABLE(1);
            }
        }

        private void REFRESH_OTHERS_PANEL()
        {
            gb_table.Visible = true;
            lbl_tableName.Text = "Editing:\n" + tblName;

            dataGridOthers.DataSource = null;
            try
            {
                dc.REFRESH_OTHERS(option);
                dataGridOthers.DataSource = dc.DT;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Connection error! Please check your internet connection.");
                tblName = "";
            }

        }

        private void btn_saveOthersPanel_Click(object sender, EventArgs e)
        {
            int localRow = dataGridOthers.CurrentRow.Index;
            string msgTxt = tblName + "\n\nData saved!";
            if (txt_otherOptionsField1.Text != "" || txt_otherOptionsField1.TextLength > 0)
            {
                if (option == 1)        // Coloring
                {
                    dc.othersField1 = txt_otherOptionsField1.Text;
                    dc.othersField2 = txt_otherOptionsField2.Text;
                    if (chkOtherOptions == true)
                        dc.UPDATE_OTHERS_COLORING();
                    else
                        dc.ADD_OTHERS_COLORING();
                }
                else if (option == 2)   // Condition
                {
                    dc.othersField1 = txt_otherOptionsField1.Text;
                    dc.othersField2 = txt_otherOptionsField2.Text;
                    dc.othersField3 = txt_otherOptionsField3.Text;
                    if (chkOtherOptions == true)
                        dc.UPDATE_OTHERS_COND();
                    else
                        dc.ADD_OTHERS_COND();
                }
                else if (option == 3)   // Country
                {
                    dc.othersField1 = txt_otherOptionsField1.Text;
                    dc.othersField2 = txt_otherOptionsField2.Text;
                    if (chkOtherOptions == true)
                        dc.UPDATE_OTHERS_COUNTRY();
                    else
                        dc.ADD_OTHERS_COUNTRY();
                }
                else if (option == 4)   // Material
                {
                    dc.othersField1 = txt_otherOptionsField1.Text;
                    if (chkOtherOptions == true)
                        dc.UPDATE_OTHERS_MATERIAL();
                    else
                        dc.ADD_OTHERS_MATERIAL();
                }
                else if (option == 5)   // Orientation
                {
                    dc.othersField1 = txt_otherOptionsField1.Text;
                    dc.othersField2 = txt_otherOptionsField2.Text;
                    if (chkOtherOptions == true)
                        dc.UPDATE_OTHERS_ORIENT();
                    else
                        dc.ADD_OTHERS_ORIENT();
                }
                else if (option == 6)   // Publishers
                {
                    dc.othersField1 = txt_otherOptionsField1.Text;
                    dc.othersField2 = txt_otherOptionsField2.Text;
                    if (chkOtherOptions == true)
                        dc.UPDATE_OTHERS_PUBLISH();
                    else
                        dc.ADD_OTHERS_PUBLISH();
                }
                else if (option == 7)   // Sent Type
                {
                    dc.othersField1 = txt_otherOptionsField1.Text;
                    if (chkOtherOptions == true)
                        dc.UPDATE_OTHERS_SENTTYPE();
                    else
                        dc.ADD_OTHERS_SENTTYPE();
                }
                else if (option == 8)   // Shape
                {
                    dc.othersField1 = txt_otherOptionsField1.Text;
                    if (chkOtherOptions == true)
                        dc.UPDATE_OTHERS_SHAPE();
                    else
                        dc.ADD_OTHERS_SHAPE();
                }
                else if (option == 9)   // Size
                {
                    dc.othersField1 = txt_otherOptionsField1.Text;
                    if (chkOtherOptions == true)
                        dc.UPDATE_OTHERS_SIZE();
                    else
                        dc.ADD_OTHERS_SIZE();
                }
                else if (option == 10)   // Theme
                {
                    dc.othersField1 = txt_otherOptionsField1.Text;
                    if (chkOtherOptions == true)
                        dc.UPDATE_OTHERS_THEME();
                    else
                        dc.ADD_OTHERS_THEME();
                }
                else if (option == 11)   // Year
                {
                    dc.othersField1 = txt_otherOptionsField1.Text;
                    if (chkOtherOptions == true)
                        dc.UPDATE_OTHERS_YEAR();
                    else
                        dc.ADD_OTHERS_YEAR();
                }
                // confirmation message
                msgTxt = tblName + "\n\nData saved!";
                MessageBox.Show(msgTxt);
            }
            else
            {
                MessageBox.Show("Field cannot be empty.");
            }
            panel2.Visible = false;
            btn_open.Enabled = true;
            dataGridOthers.Enabled = true;
            chk_updateOther.Checked = false;
            btn_closeOthers.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            dataGridOthers.DataSource = null;
            REFRESH_OTHERS_PANEL();
            dataGridOthers.DataSource = dc.DT;
            dataGridOthers.Rows[localRow].Selected = true;
            dataGridOthers.FirstDisplayedScrollingRowIndex = localRow;
            dataGridOthers.Focus();
            con.connectdb.Close();
        }

        /*
         * 
         *      Show only the number of fields according to the table being used
         * 
         */
        private void SHOW_OTHERS_TABLE(int totalFields)
        {
            if (totalFields == 1)
            {
                lbl_otherOptField2.Text = "";
                lbl_otherOptField3.Text = "";
                lbl_otherOptField1.Visible = true;
                lbl_otherOptField2.Visible = false;
                lbl_otherOptField3.Visible = false;
                txt_otherOptionsField1.Visible = true;
                txt_otherOptionsField2.Visible = false;
                txt_otherOptionsField3.Visible = false;
            }
            else if (totalFields == 2)
            {
                lbl_otherOptField3.Text = "";
                lbl_otherOptField1.Visible = true;
                lbl_otherOptField2.Visible = true;
                lbl_otherOptField3.Visible = false;
                txt_otherOptionsField1.Visible = true;
                txt_otherOptionsField2.Visible = true;
                txt_otherOptionsField3.Visible = false;
            }
            else if (totalFields == 3)
            {
                lbl_otherOptField1.Visible = true;
                lbl_otherOptField2.Visible = true;
                lbl_otherOptField3.Visible = true;
                txt_otherOptionsField1.Visible = true;
                txt_otherOptionsField2.Visible = true;
                txt_otherOptionsField3.Visible = true;
            }
        }

        /*
         * 
         *      SAVE TO EXCEL FILE (no need to have Excel installed in your computer
         * 
         */
        private void btn_excelTable_Click(object sender, EventArgs e)
        {
            if ((tblName != "" || tblName != null) && lbl_tableName.Text != "table name here")
            {

                // export to excel
                saveTablesDiaglog.InitialDirectory = "C:";
                saveTablesDiaglog.Title = "Save as Excel File";
                saveTablesDiaglog.FileName = "";
                saveTablesDiaglog.Filter = "Excel Files 2007 and up|*.xlsx";

                // choose the folder where to write the file. If 'OK' is pressed, it saves the complete path to that folder.
                if (saveTablesDiaglog.ShowDialog() != DialogResult.Cancel)
                {
                    // change cursor to wait mode while saving the file
                    Cursor.Current = Cursors.WaitCursor;

                    // EPPlus license (Excel isn't required to be installed in the computer. You may use other open source software to open it)
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(new System.IO.FileInfo(saveTablesDiaglog.FileName)))
                    {
                        // define spreadsheet's sheet name
                        var worksheet = package.Workbook.Worksheets.Add(tblName);

                        // save the header
                        for (int i = 1; i < dataGridOthers.Columns.Count + 1; i++)
                        {
                            worksheet.Cells[1, i].Value = dataGridOthers.Columns[i - 1].HeaderText;
                        }

                        // save all information in the gridview to the spreadsheet
                        for (int i = 0; i < dataGridOthers.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridOthers.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dataGridOthers.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        // adjust column's width
                        worksheet.Cells.AutoFitColumns(0);

                        // save file to the disk
                        package.Save();
                    }
                    MessageBox.Show("Table exported!");
                }
                // cursor is back to default
                Cursor.Current = Cursors.Default;

            }
            else
            {
                MessageBox.Show("Open a table first.");
            }
        }

    }
}
