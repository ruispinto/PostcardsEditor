using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using PostcardsEditor.myclass;

namespace PostcardsEditor.myclass
{
    class dataclass : connection_class
    {
        // declaring lists
        public List<string> dt_coloringFill = new List<string>();
        public List<string> dt_condFill = new List<string>();
        public List<string> dt_countryFill = new List<string>();
        public List<string> dt_materialFill = new List<string>();
        public List<string> dt_orientFill = new List<string>();
        public List<string> dt_publishFill = new List<string>();
        public List<string> dt_sentTypeFill = new List<string>();
        public List<string> dt_shapeFill = new List<string>();
        public List<string> dt_sizeFill = new List<string>();
        public List<string> dt_themeFill = new List<string>();
        public List<string> dt_yearFill = new List<string>();
        public List<string> dt_cardNumberFill = new List<string>();

        // declaring all fields that are used in the postcards
        public Int32 cardID { get; set; }                     // Card Number (record number --> to delete the right record)
        public string cardNumber { get; set; }              // Card Number (unique numbering)
        public string cardPublisher { get; set; }           // Publisher
        public string cardScanned { get; set; }             // Scanned ? (logical --> checked option)
        public string cardInTheBlog { get; set; }           // In the blog ? (logical --> checked option)
        public string cardCountry { get; set; }             // Country
        public string cardDescEng { get; set; }             // Description in English
        public string cardDescOrg { get; set; }             // Original Postcard Description
        public string cardTheme { get; set; }               // Theme
        public string cardColoring { get; set; }            // Coloring
        public string cardYear { get; set; }                // Year
        public string cardImgNumber { get; set; }           // Number of images in the postcard (average)
        public string cardSeriesMulti { get; set; }         // Series ? (logical --> checked option)  ==> if it is true, open a new add series window
        public string cardTotCardNumber { get; set; }       // Total number of cards in the series
        public string cardSize { get; set; }                // Size
        public string cardShape { get; set; }               // Shape
        public string cardOrient { get; set; }              // Orientation
        public string cardBarcode { get; set; }             // Barcode
        public string cardMaterial { get; set; }            // Material
        public string cardCondition { get; set; }           // Condition
        public string cardBorders { get; set; }             // Borders ? (logical --> checked option)
        public string cardFrontTxtColor { get; set; }       // Front Text Color
        public string cardBackTxtColor { get; set; }        // Back Text Color
        public string cardDatePurchased { get; set; }       // Purchase Date
        public string cardCostPrice { get; set; }           // Cost Price (if purchased)
        public string cardWebpage { get; set; }             // Website
        public string cardIdentical { get; set; }           // Identical ? (logical --> checked option)
        public string cardEqualsTo { get; set; }            // Equals to --> stores the other identical card number
        public string cardDifferences { get; set; }         // Differences between the two postcards
        public string cardBigDesc { get; set; }             // Big Description (if needed)
        public string cardSentType { get; set; }            // Sent Type option (if offered or bought or brought by someone)
        public string cardTypeDesc { get; set; }            // Who offered / Bought / Brought...
        public string cardFrontImgPath { get; set; }        // Front Image Path (web / hdd)
        public string cardBackImgPath { get; set; }         // Back Image Path (web / hdd

        // declaring all fields that are used in the postcards series
        public Int32 seriesID { get; set; }               // Postcard Number (to delete the right record)
        public string seriesCardNumber { get; set; }        // Postcard Number (unique numbering of postcards) --> from main table
        public string seriesSecCardNumber { get; set; }     // New Secondary postcard number
        public string seriesDescEng { get; set; }           // Description in English
        public string seriesDescOrg { get; set; }           // Original Postcard Description
        public string seriesColorAbr { get; set; }          // Coloring
        public string seriesOrient { get; set; }            // Orientation
        public string seriesImgCount { get; set; }          // Number of images in the postcard (average)
        public string seriesDate { get; set; }              // Reference Date
        public string seriesYearNumber { get; set; }        // Year
        public string seriesBarcode { get; set; }           // Barcode
        public string seriesFrontTxtColor { get; set; }     // Front Text Color
        public string seriesBackTxtColor { get; set; }      // Back Text Color
        public string seriesBigDesc { get; set; }           // Big Description (if needed)
        public string seriesFrontImgPath { get; set; }      // Front Image Path (web / hdd)
        public string seriesBackImgPath { get; set; }       // Back Image Path (web / hdd

        // declaring variables just to change Series Card Number
        public string old_seriesSecond { get; set; }        // Old Secondary postcard number
        public string new_seriesSecond { get; set; }        // New Secondary postcard number

        // declaring all fields for other tables
        public Int32 othersID { get; set; }
        public string othersField1 { get; set; }
        public string othersField2 { get; set; }
        public string othersField3 { get; set; }

        // read properties
        public DataTable DT = new DataTable();
        public DataSet DS = new DataSet();

        // other variables
        public string sVersion = "2.0.04.0004";
        public string dVersion = "2021-10-29";

        // fetch data from coloring Table
        public void Show_ColoringTable()
        {
            dt_coloringFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT * FROM coloring";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_coloringFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }

        // fetch data from condition Table (the word 'condition' is a reserved word, therefore never use it in SQL table name
        public void Show_CondTable()
        {
            dt_condFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT * FROM cond";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add a new blank option (just to choose later)
                dt_condFill.Add("Choose...");

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_condFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }

        // fetch data from country Table
        public void Show_CountryTable()
        {
            dt_countryFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT * FROM country";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add a new blank option (just to choose later)
                dt_countryFill.Add("Choose...");

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_countryFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }

        // fetch data from condition Table (the word 'condition' is a reserved word, therefore never use it in SQL table name
        public void Show_MaterialTable()
        {
            dt_materialFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT * FROM material";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_materialFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }

        // fetch data from orientation Table
        public void Show_OrientTable()
        {
            dt_orientFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT * FROM orient";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add a new blank option (just to choose later)
                dt_orientFill.Add("Choose...");

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_orientFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }

        // fetch data from publisher Table
        public void Show_PublishTable()
        {
            dt_publishFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT * FROM publish";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add a new blank option (just to choose later)
                dt_publishFill.Add("Choose...");

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_publishFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }

        // fetch data from sentType Table
        public void Show_SentTypeTable()
        {
            dt_sentTypeFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT * FROM senttype";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add a new blank option (just to choose later)
                dt_sentTypeFill.Add("Choose...");

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_sentTypeFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }

        // fetch data from shape Table
        public void Show_ShapeTable()
        {
            dt_shapeFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT * FROM shape";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add a new blank option (just to choose later)
                dt_shapeFill.Add("Choose...");

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_shapeFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }

        // fetch data from size Table
        public void Show_SizeTable()
        {
            dt_sizeFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT * FROM size";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add a new blank option (just to choose later)
                dt_sizeFill.Add("Choose...");

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_sizeFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }

        // fetch data from theme Table
        public void Show_ThemeTable()
        {
            dt_themeFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT * FROM theme";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add a new blank option (just to choose later)
                dt_themeFill.Add("Choose...");

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_themeFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }

        // fetch data from year Table (the word 'Year' is a reserved word, therefore never use it in SQL table name
        public void Show_YearTable()
        {
            dt_yearFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT * FROM yyear";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add a new blank option (just to choose later)
                dt_yearFill.Add("Choose...");

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_yearFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }

        // fetch data from card Table (the word 'Year' is a reserved word, therefore never use it in SQL table name
        public void Show_CardNumberTable()
        {
            dt_cardNumberFill.Clear();
            MySqlDataReader rd;
            string query = "SELECT cardid,cardnumber FROM card";
            using (var cmd = new MySqlCommand())
            {
                connectdb.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add a new blank option (just to choose later)
                dt_cardNumberFill.Add("Choose...");

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt_cardNumberFill.Add(rd[1].ToString());
                }
                connectdb.Close();
            }
        }



        // *******************************************************************************************************
        // * 
        // *  Card Table Management
        // * 
        // * *****************************************************************************************************

        // Show data from the table 'Card' in the grid
        public void REFRESH_CARD()
        {
            string query = "SELECT cardid AS 'Card #', cardnumber AS 'Card Number', cardpublisher AS 'Publisher', cardscanned AS 'Scanned', cardintheblog AS 'Blog', cardcountryname AS 'Country', carddesceng AS 'Description (English)', carddescoriginal AS 'Description (Original)', cardthemename AS 'Theme', cardcoloringabr AS 'Coloring', cardyearnumber AS 'Year', cardimgnmbr AS 'Tot.Num.of Img', cardseriesmulti AS 'Series ?', cardseriestotal AS 'Total Series', cardsizename AS 'Size', cardshapename AS 'Shape', cardorientabr AS 'Orient.', cardbarcode AS 'Barcode', cardmaterial as 'Material', cardcondabr AS 'Condition', cardborders AS 'Borders ?', cardfronttxtcolor AS 'Front Text Color', cardbacktxtcolor AS 'Back Text Color', carddatepurchased AS 'Purchase Date', cardcostprice AS 'Cost Price', cardwebpage AS 'Webpage', cardidentical AS 'Identical ?', cardequalsto AS 'Equals to', carddifferences AS 'Differencies', cardbigdesc AS 'Big Description', cardsenttypename AS 'Sent Type', cardtypedesc AS 'Type Description', cardfrontimgpath AS 'Front Image Path', cardbackimgpath AS 'Back Image Path' FROM card";
            DS = new DataSet();
            DT.Clear();
            MySqlDataAdapter DA = new MySqlDataAdapter(query, connectdb);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }

        // Add postcard to database
        public void ADD_CARD()
        {
            connectdb.Open();
            string query = "INSERT INTO card(cardnumber, cardpublisher, cardscanned, cardintheblog, cardcountryname, carddesceng, carddescoriginal, cardthemename, cardcoloringabr, cardyearnumber, cardimgnmbr, cardseriesmulti, cardseriestotal, cardsizename, cardshapename, cardorientabr, cardbarcode, cardmaterial, cardcondabr, cardborders, cardfronttxtcolor, cardbacktxtcolor, carddatepurchased, cardcostprice, cardwebpage, cardidentical, cardequalsto, carddifferences, cardbigdesc, cardsenttypename, cardtypedesc, cardfrontimgpath, cardbackimgpath) VALUES(@cnumber, @cpublisher, @cscan, @cblog, @ccountry, @cdesceng, @cdescorig, @ctheme, @ccolor, @cyear, @cimg, @csermulti, @csertotal, @csize, @cshape, @corient, @cbarcode, @cmaterial, @ccond, @cborders, @cfrttxtcolor, @cbcktxtcolor, @cdtpurchase, @ccost, @cweb, @cidentical, @cequals, @cdif, @cbigdsc, @csenttype, @ctypedesc, @cfrtimg, @cbckimg)";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@cnumber", MySqlDbType.VarChar).Value = cardNumber;
                cmd.Parameters.Add("@cpublisher", MySqlDbType.VarChar).Value = cardPublisher;
                cmd.Parameters.Add("@cscan", MySqlDbType.VarChar).Value = cardScanned;
                cmd.Parameters.Add("@cblog", MySqlDbType.VarChar).Value = cardInTheBlog;
                cmd.Parameters.Add("@ccountry", MySqlDbType.VarChar).Value = cardCountry;
                cmd.Parameters.Add("@cdesceng", MySqlDbType.VarChar).Value = cardDescEng;
                cmd.Parameters.Add("@cdescorig", MySqlDbType.VarChar).Value = cardDescOrg;
                cmd.Parameters.Add("@ctheme", MySqlDbType.VarChar).Value = cardTheme;
                cmd.Parameters.Add("@ccolor", MySqlDbType.VarChar).Value = cardColoring;
                cmd.Parameters.Add("@cyear", MySqlDbType.VarChar).Value = cardYear;
                cmd.Parameters.Add("@cimg", MySqlDbType.VarChar).Value = cardImgNumber;
                cmd.Parameters.Add("@csermulti", MySqlDbType.VarChar).Value = cardSeriesMulti;
                cmd.Parameters.Add("@csertotal", MySqlDbType.VarChar).Value = cardTotCardNumber;
                cmd.Parameters.Add("@csize", MySqlDbType.VarChar).Value = cardSize;
                cmd.Parameters.Add("@cshape", MySqlDbType.VarChar).Value = cardShape;
                cmd.Parameters.Add("@corient", MySqlDbType.VarChar).Value = cardOrient;
                cmd.Parameters.Add("@cbarcode", MySqlDbType.VarChar).Value = cardBarcode;
                cmd.Parameters.Add("@cmaterial", MySqlDbType.VarChar).Value = cardMaterial;
                cmd.Parameters.Add("@ccond", MySqlDbType.VarChar).Value = cardCondition;
                cmd.Parameters.Add("@cborders", MySqlDbType.VarChar).Value = cardBorders;
                cmd.Parameters.Add("@cfrttxtcolor", MySqlDbType.VarChar).Value = cardFrontTxtColor;
                cmd.Parameters.Add("@cbcktxtcolor", MySqlDbType.VarChar).Value = cardBackTxtColor;
                cmd.Parameters.Add("@cdtpurchase", MySqlDbType.VarChar).Value = cardDatePurchased;
                cmd.Parameters.Add("@ccost", MySqlDbType.VarChar).Value = cardCostPrice;
                cmd.Parameters.Add("@cweb", MySqlDbType.VarChar).Value = cardWebpage;
                cmd.Parameters.Add("@cidentical", MySqlDbType.VarChar).Value = cardIdentical;
                cmd.Parameters.Add("@cequals", MySqlDbType.VarChar).Value = cardEqualsTo;
                cmd.Parameters.Add("@cdif", MySqlDbType.VarChar).Value = cardDifferences;
                cmd.Parameters.Add("@cbigdsc", MySqlDbType.VarChar).Value = cardBigDesc;
                cmd.Parameters.Add("@csenttype", MySqlDbType.VarChar).Value = cardSentType;
                cmd.Parameters.Add("@ctypedesc", MySqlDbType.VarChar).Value = cardTypeDesc;
                cmd.Parameters.Add("@cfrtimg", MySqlDbType.VarChar).Value = cardFrontImgPath;
                cmd.Parameters.Add("@cbckimg", MySqlDbType.VarChar).Value = cardBackImgPath;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Edit postcard from the database
        public void UPDATE_CARD()
        {
            connectdb.Open();
            string query = "UPDATE card SET cardnumber=@cnumber, cardpublisher=@cpublisher, cardscanned=@cscan, cardintheblog=@cblog, cardcountryname=@ccountry, carddesceng=@cdesceng, carddescoriginal=@cdescorig, cardthemename=@ctheme, cardcoloringabr=@ccolor, cardyearnumber=@cyear, cardimgnmbr=@cimg, cardseriesmulti=@csermulti, cardseriestotal=@csertotal, cardsizename=@csize, cardshapename=@cshape, cardorientabr=@corient, cardbarcode=@cbarcode, cardmaterial=@cmaterial, cardcondabr=@ccond, cardborders=@cborders, cardfronttxtcolor=@cfrttxtcolor, cardbacktxtcolor=@cbcktxtcolor, carddatepurchased=@cdtpurchase, cardcostprice=@ccost, cardwebpage=@cweb, cardidentical=@cidentical, cardequalsto=@cequals, carddifferences=@cdif, cardbigdesc=@cbigdsc, cardsenttypename=@csenttype, cardtypedesc=@ctypedesc, cardfrontimgpath=@cfrtimg, cardbackimgpath=@cbckimg WHERE cardid=@cid";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@cnumber", MySqlDbType.VarChar).Value = cardNumber;
                cmd.Parameters.Add("@cpublisher", MySqlDbType.VarChar).Value = cardPublisher;
                cmd.Parameters.Add("@cscan", MySqlDbType.VarChar).Value = cardScanned;
                cmd.Parameters.Add("@cblog", MySqlDbType.VarChar).Value = cardInTheBlog;
                cmd.Parameters.Add("@ccountry", MySqlDbType.VarChar).Value = cardCountry;
                cmd.Parameters.Add("@cdesceng", MySqlDbType.VarChar).Value = cardDescEng;
                cmd.Parameters.Add("@cdescorig", MySqlDbType.VarChar).Value = cardDescOrg;
                cmd.Parameters.Add("@ctheme", MySqlDbType.VarChar).Value = cardTheme;
                cmd.Parameters.Add("@ccolor", MySqlDbType.VarChar).Value = cardColoring;
                cmd.Parameters.Add("@cyear", MySqlDbType.VarChar).Value = cardYear;
                cmd.Parameters.Add("@cimg", MySqlDbType.VarChar).Value = cardImgNumber;
                cmd.Parameters.Add("@csermulti", MySqlDbType.VarChar).Value = cardSeriesMulti;
                cmd.Parameters.Add("@csertotal", MySqlDbType.VarChar).Value = cardTotCardNumber;
                cmd.Parameters.Add("@csize", MySqlDbType.VarChar).Value = cardSize;
                cmd.Parameters.Add("@cshape", MySqlDbType.VarChar).Value = cardShape;
                cmd.Parameters.Add("@corient", MySqlDbType.VarChar).Value = cardOrient;
                cmd.Parameters.Add("@cbarcode", MySqlDbType.VarChar).Value = cardBarcode;
                cmd.Parameters.Add("@cmaterial", MySqlDbType.VarChar).Value = cardMaterial;
                cmd.Parameters.Add("@ccond", MySqlDbType.VarChar).Value = cardCondition;
                cmd.Parameters.Add("@cborders", MySqlDbType.VarChar).Value = cardBorders;
                cmd.Parameters.Add("@cfrttxtcolor", MySqlDbType.VarChar).Value = cardFrontTxtColor;
                cmd.Parameters.Add("@cbcktxtcolor", MySqlDbType.VarChar).Value = cardBackTxtColor;
                cmd.Parameters.Add("@cdtpurchase", MySqlDbType.VarChar).Value = cardDatePurchased;
                cmd.Parameters.Add("@ccost", MySqlDbType.VarChar).Value = cardCostPrice;
                cmd.Parameters.Add("@cweb", MySqlDbType.VarChar).Value = cardWebpage;
                cmd.Parameters.Add("@cidentical", MySqlDbType.VarChar).Value = cardIdentical;
                cmd.Parameters.Add("@cequals", MySqlDbType.VarChar).Value = cardEqualsTo;
                cmd.Parameters.Add("@cdif", MySqlDbType.VarChar).Value = cardDifferences;
                cmd.Parameters.Add("@cbigdsc", MySqlDbType.VarChar).Value = cardBigDesc;
                cmd.Parameters.Add("@csenttype", MySqlDbType.VarChar).Value = cardSentType;
                cmd.Parameters.Add("@ctypedesc", MySqlDbType.VarChar).Value = cardTypeDesc;
                cmd.Parameters.Add("@cfrtimg", MySqlDbType.VarChar).Value = cardFrontImgPath;
                cmd.Parameters.Add("@cbckimg", MySqlDbType.VarChar).Value = cardBackImgPath;

                // WHERE clause
                cmd.Parameters.Add("@cid", MySqlDbType.Int32).Value = cardID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Delete postcard in the database
        public void DELETE_CARD()
        {
            connectdb.Open();
            string query = "DELETE FROM card WHERE cardid=@cid";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // WHERE
                cmd.Parameters.Add("@cid",MySqlDbType.Int32).Value = cardID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }



        // *******************************************************************************************************
        // * 
        // *  Search (show all and check one)
        // * 
        // * *****************************************************************************************************

        // Search through the cards
        public void SEARCH_CARD(string searchText)
        {
            string query = "SELECT cardid AS 'Card #', cardnumber AS 'Card Number', cardpublisher AS 'Publisher', cardscanned AS 'Scanned', cardintheblog AS 'Blog', cardcountryname AS 'Country', carddesceng AS 'Description (English)', carddescoriginal AS 'Description (Original)', cardthemename AS 'Theme', cardcoloringabr AS 'Coloring', cardyearnumber AS 'Year', cardimgnmbr AS 'Tot.Num.of Img', cardseriesmulti AS 'Series ?', cardseriestotal AS 'Total Series', cardsizename AS 'Size', cardshapename AS 'Shape', cardorientabr AS 'Orient.', cardbarcode AS 'Barcode', cardmaterial as 'Material', cardcondabr AS 'Condition', cardborders AS 'Borders ?', cardfronttxtcolor AS 'Front Text Color', cardbacktxtcolor AS 'Back Text Color', carddatepurchased AS 'Purchase Date', cardcostprice AS 'Cost Price', cardwebpage AS 'Webpage', cardidentical AS 'Identical ?', cardequalsto AS 'Equals to', carddifferences AS 'Differencies', cardbigdesc AS 'Big Description', cardsenttypename AS 'Sent Type', cardtypedesc AS 'Type Description', cardfrontimgpath AS 'Front Image Path', cardbackimgpath AS 'Back Image Path' FROM card WHERE CONCAT_WS(' ', cardnumber, cardpublisher, cardcountryname, carddesceng, carddescoriginal, cardthemename, cardsizename, cardshapename, cardbarcode, cardmaterial) LIKE '%" + searchText + "%'";
            DS = new DataSet();
            DT.Clear();
            MySqlDataAdapter DA = new MySqlDataAdapter(query, connectdb);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }

        // Search for cardnumber only
        public bool SEARCH_NUMBER()
        {
            bool check = false;
            int checkNumber = 0;
            connectdb.Open();
            MySqlDataReader reader;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT cardnumber FROM card WHERE cardnumber=@cnumber";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;
                cmd.Parameters.Add("@cnumber", MySqlDbType.VarChar).Value = cardNumber;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    checkNumber++;
                }
                connectdb.Close();
                if (checkNumber >= 1)
                    check = true;
                else
                    check = false;
            }
            return check;
        }


        // *******************************************************************************************************
        // * 
        // *  Series Card Table Management
        // * 
        // * *****************************************************************************************************

        // Show data from the table 'CardSeries' in the grid
        public void REFRESH_MULTICARD(string upd_cardnumber)
        {
            string query = "SELECT seriesid AS 'Series #', seriescardnumber AS 'Main Card Number', seriesseccardnumber AS 'Secondary Card Number', seriesdesceng AS 'Description (English)', seriesdescoriginal AS 'Description (Original)', seriescolorabr AS 'Coloring', seriesorientabr AS 'Orient.', seriesimgcount AS 'Tot.Num.of Img', seriesdate AS 'Referenced Date', seriesyearnumber AS 'Year', seriesbarcode AS 'Barcode', seriesfronttxtcolor AS 'Front Text Color', seriesbacktxtcolor AS 'Back Text Color', seriesbigdesc AS 'Big Description', seriesfrontimgpath AS 'Front Image Path', seriesbackimgpath AS 'Back Image Path' FROM cardseries WHERE seriescardnumber='" + upd_cardnumber + "'";
            DS = new DataSet();
            DT.Clear();
            MySqlDataAdapter DA = new MySqlDataAdapter(query, connectdb);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }

        // Show data from the table 'CardSeries' in the grid
        public void REFRESH_ALL_MULTICARD()
        {
            string query = "SELECT seriesid AS 'Series #', seriescardnumber AS 'Main Card Number', seriesseccardnumber AS 'Secondary Card Number', seriesdesceng AS 'Description (English)', seriesdescoriginal AS 'Description (Original)', seriescolorabr AS 'Coloring', seriesorientabr AS 'Orient.', seriesimgcount AS 'Tot.Num.of Img', seriesdate AS 'Referenced Date', seriesyearnumber AS 'Year', seriesbarcode AS 'Barcode', seriesfronttxtcolor AS 'Front Text Color', seriesbacktxtcolor AS 'Back Text Color', seriesbigdesc AS 'Big Description', seriesfrontimgpath AS 'Front Image Path', seriesbackimgpath AS 'Back Image Path' FROM cardseries";
            DS = new DataSet();
            DT.Clear();
            MySqlDataAdapter DA = new MySqlDataAdapter(query, connectdb);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }

        // Add postcard to database
        public void ADD_SERIESCARD()
        {
            connectdb.Open();
            string query = "INSERT INTO cardseries(seriescardnumber, seriesseccardnumber, seriesdesceng, seriesdescoriginal, seriescolorabr, seriesorientabr, seriesimgcount, seriesdate, seriesyearnumber, seriesbarcode, seriesfronttxtcolor, seriesbacktxtcolor, seriesbigdesc, seriesfrontimgpath, seriesbackimgpath) VALUES(@snumber, @ssecnumber, @sdesceng, @sdescorig, @scolor, @sorient, @simg, @sdate, @syear, @sbarcode, @sfrttxtcolor, @sbcktxtcolor, @sbigdsc, @sfrtimg, @sbckimg)";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@snumber", MySqlDbType.VarChar).Value = seriesCardNumber;
                cmd.Parameters.Add("@ssecnumber", MySqlDbType.VarChar).Value = seriesSecCardNumber;
                cmd.Parameters.Add("@sdesceng", MySqlDbType.VarChar).Value = seriesDescEng;
                cmd.Parameters.Add("@sdescorig", MySqlDbType.VarChar).Value = seriesDescOrg;
                cmd.Parameters.Add("@scolor", MySqlDbType.VarChar).Value = seriesColorAbr;
                cmd.Parameters.Add("@sorient", MySqlDbType.VarChar).Value = seriesOrient;
                cmd.Parameters.Add("@simg", MySqlDbType.VarChar).Value = seriesImgCount;
                cmd.Parameters.Add("@sdate", MySqlDbType.VarChar).Value = seriesDate;
                cmd.Parameters.Add("@syear", MySqlDbType.VarChar).Value = seriesYearNumber;
                cmd.Parameters.Add("@sbarcode", MySqlDbType.VarChar).Value = seriesBarcode;
                cmd.Parameters.Add("@sfrttxtcolor", MySqlDbType.VarChar).Value = seriesFrontTxtColor;
                cmd.Parameters.Add("@sbcktxtcolor", MySqlDbType.VarChar).Value = seriesBackTxtColor;
                cmd.Parameters.Add("@sbigdsc", MySqlDbType.VarChar).Value = seriesBigDesc;
                cmd.Parameters.Add("@sfrtimg", MySqlDbType.VarChar).Value = seriesFrontImgPath;
                cmd.Parameters.Add("@sbckimg", MySqlDbType.VarChar).Value = seriesBackImgPath;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Edit postcard from the database
        public void UPDATE_SERIESCARD()
        {
            connectdb.Open();
            string query = "UPDATE cardseries SET seriesseccardnumber=@ssecnumber, seriesdesceng=@sdesceng, seriesdescoriginal=@sdescorig, seriescolorabr=@scolor, seriesorientabr=@sorient, seriesimgcount=@simg, seriesdate=@sdate, seriesyearnumber=@syear, seriesbarcode=@sbarcode, seriesfronttxtcolor=@sfrttxtcolor, seriesbacktxtcolor=@sbcktxtcolor, seriesbigdesc=@sbigdsc, seriesfrontimgpath=@sfrtimg, seriesbackimgpath=@sbckimg WHERE seriesid=@sid";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@ssecnumber", MySqlDbType.VarChar).Value = seriesSecCardNumber;
                cmd.Parameters.Add("@sdesceng", MySqlDbType.VarChar).Value = seriesDescEng;
                cmd.Parameters.Add("@sdescorig", MySqlDbType.VarChar).Value = seriesDescOrg;
                cmd.Parameters.Add("@scolor", MySqlDbType.VarChar).Value = seriesColorAbr;
                cmd.Parameters.Add("@sorient", MySqlDbType.VarChar).Value = seriesOrient;
                cmd.Parameters.Add("@simg", MySqlDbType.VarChar).Value = seriesImgCount;
                cmd.Parameters.Add("@sdate", MySqlDbType.VarChar).Value = seriesDate;
                cmd.Parameters.Add("@syear", MySqlDbType.VarChar).Value = seriesYearNumber;
                cmd.Parameters.Add("@sbarcode", MySqlDbType.VarChar).Value = seriesBarcode;
                cmd.Parameters.Add("@sfrttxtcolor", MySqlDbType.VarChar).Value = seriesFrontTxtColor;
                cmd.Parameters.Add("@sbcktxtcolor", MySqlDbType.VarChar).Value = seriesBackTxtColor;
                cmd.Parameters.Add("@sbigdsc", MySqlDbType.VarChar).Value = seriesBigDesc;
                cmd.Parameters.Add("@sfrtimg", MySqlDbType.VarChar).Value = seriesFrontImgPath;
                cmd.Parameters.Add("@sbckimg", MySqlDbType.VarChar).Value = seriesBackImgPath;


                // WHERE clause
                cmd.Parameters.Add("@sid", MySqlDbType.Int32).Value = seriesID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Delete postcard in the database
        public void DELETE_SERIESCARD()
        {
            connectdb.Open();
            string query = "DELETE FROM cardseries WHERE seriesid=@sid";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // WHERE
                cmd.Parameters.Add("@sid", MySqlDbType.Int32).Value = seriesID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }


        // *******************************************************************************************************
        // * 
        // *  Other Tables Management
        // * 
        // * *****************************************************************************************************

        // Show data from the table 'coloring' in the grid
        public void REFRESH_OTHERS(int opt)
        {
            string query = "";
            if (opt == 1)
            {
                query = "SELECT coloringid AS 'Coloring #', coloringabr AS 'Abrev.', coloringname AS 'Coloring Name' FROM coloring";
            }
            else if(opt == 2)
            {
                query = "SELECT condid AS 'Condition #', condabr AS 'Abrev.', condname AS 'Condition Name', conddesc AS 'Description' FROM cond";
            }
            else if (opt == 3)
            {
                query = "SELECT countryid AS 'Country #', countryname AS 'Country', countryiso AS 'ISO' FROM country";
            }
            else if (opt == 4)
            {
                query = "SELECT materialid AS 'Material #', materialname AS 'Material Name' FROM material";
            }
            else if (opt == 5)
            {
                query = "SELECT orientid AS 'Orientation #', orientabr AS 'Abrev.', orientname AS 'Orientation Name' FROM orient";
            }
            else if (opt == 6)
            {
                query = "SELECT publishid AS 'Publisher #', publishname AS 'Publisher Name', publishcompanies AS 'Companies' FROM publish";
            }
            else if (opt == 7)
            {
                query = "SELECT sentypeid AS 'Sent Type #', senttypename AS 'Name' FROM senttype";
            }
            else if (opt == 8)
            {
                query = "SELECT shapeid AS 'Shape #', shapename AS 'Name' FROM shape";
            }
            else if (opt == 9)
            {
                query = "SELECT sizeid AS 'Size #', sizename AS 'Name' FROM size";
            }
            else if (opt == 10)
            {
                query = "SELECT themeid AS 'Theme #', themename AS 'Theme' FROM theme";
            }
            else if (opt == 11)
            {
                query = "SELECT yearid AS 'Year #', yearnumber AS 'Year' FROM yyear";
            }
            DS = new DataSet();
            DT.Clear();
            MySqlDataAdapter DA01 = new MySqlDataAdapter(query, connectdb);
            DA01.Fill(DS);
            DT = DS.Tables[0];
        }

        // Add data to the coloring table
        public void ADD_OTHERS_COLORING()
        {
            string query = "INSERT INTO coloring(coloringabr, coloringname) VALUES(@otherField1, @otherField2)";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;
                cmd.Parameters.Add("@otherField2", MySqlDbType.VarChar).Value = othersField2;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Add data to the condition table
        public void ADD_OTHERS_COND()
        {
            string query = "INSERT INTO cond(condabr, condname, conddesc) VALUES(@otherField1, @otherField2, @otherField3)";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;
                cmd.Parameters.Add("@otherField2", MySqlDbType.VarChar).Value = othersField2;
                cmd.Parameters.Add("@otherField3", MySqlDbType.VarChar).Value = othersField3;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Add data to the country table
        public void ADD_OTHERS_COUNTRY()
        {
            string query = "INSERT INTO country(countryname, countryiso) VALUES(@otherField1, @otherField2)";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;
                cmd.Parameters.Add("@otherField2", MySqlDbType.VarChar).Value = othersField2;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Add data to the material table
        public void ADD_OTHERS_MATERIAL()
        {
            string query = "INSERT INTO material(materialname) VALUES(@otherField1)";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Add data to the orientation table
        public void ADD_OTHERS_ORIENT()
        {
            string query = "";
            query = "INSERT INTO orient(orientabr, orientname) VALUES(@otherField1, @otherField2)";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;
                cmd.Parameters.Add("@otherField2", MySqlDbType.VarChar).Value = othersField2;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Add data to the publisher table
        public void ADD_OTHERS_PUBLISH()
        {
            string query = "INSERT INTO publish(publishname, publishcompanies) VALUES(@otherField1, @otherField2)";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;
                cmd.Parameters.Add("@otherField2", MySqlDbType.VarChar).Value = othersField2;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Add data to the sent type table
        public void ADD_OTHERS_SENTTYPE()
        {
            string query = "INSERT INTO senttype(senttypename) VALUES(@otherField1)";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Add data to the shape table
        public void ADD_OTHERS_SHAPE()
        {
            string query = "INSERT INTO shape(shapename) VALUES(@otherField1)";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Add data to the size table
        public void ADD_OTHERS_SIZE()
        {
            string query = "INSERT INTO size(sizename) VALUES(@otherField1)";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Add data to the theme table
        public void ADD_OTHERS_THEME()
        {
            string query = "INSERT INTO theme(themename) VALUES(@otherField1)";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Add data to the year table
        public void ADD_OTHERS_YEAR()
        {
            string query = "INSERT INTO yyear(yearnumber) VALUES(@otherField1)";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Update data to the coloring table
        public void UPDATE_OTHERS_COLORING()
        {
            string query = "UPDATE coloring SET coloringabr=@otherField1, coloringname=@otherField2 WHERE coloringid=@otherID";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;
                cmd.Parameters.Add("@otherField2", MySqlDbType.VarChar).Value = othersField2;

                // WHERE clause
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Update data to the condition table
        public void UPDATE_OTHERS_COND()
        {
            string query = "UPDATE cond SET condabr=@otherField1, condname=@otherField2, conddesc=@otherField3 WHERE condid=@otherID";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;
                cmd.Parameters.Add("@otherField2", MySqlDbType.VarChar).Value = othersField2;
                cmd.Parameters.Add("@otherField3", MySqlDbType.VarChar).Value = othersField3;

                // WHERE clause
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Update data to the country table
        public void UPDATE_OTHERS_COUNTRY()
        {
            string query = "UPDATE cond SET countryname=@otherField1, countryiso=@otherField2 WHERE countryid=@otherID";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;
                cmd.Parameters.Add("@otherField2", MySqlDbType.VarChar).Value = othersField2;

                // WHERE clause
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Update data to the material table
        public void UPDATE_OTHERS_MATERIAL()
        {
            string query = "UPDATE material SET materialname=@otherField1 WHERE materialid=@otherID";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // WHERE clause
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Update data to the orientation table
        public void UPDATE_OTHERS_ORIENT()
        {
            string query = "UPDATE orient SET orientabr=@otherField1, orientname=@otherField2 WHERE orientid=@otherID";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;
                cmd.Parameters.Add("@otherField2", MySqlDbType.VarChar).Value = othersField2;

                // WHERE clause
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Update data to the publisher table
        public void UPDATE_OTHERS_PUBLISH()
        {
            string query = "UPDATE publish SET publishname=@otherField1, publishcompanies=@otherField2 WHERE publishid=@otherID";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;
                cmd.Parameters.Add("@otherField2", MySqlDbType.VarChar).Value = othersField2;

                // WHERE clause
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Update data to the senttype table
        public void UPDATE_OTHERS_SENTTYPE()
        {
            string query = "UPDATE senttype SET senttypename=@otherField1 WHERE senttypeid=@otherID";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // WHERE clause
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Update data to the shape table
        public void UPDATE_OTHERS_SHAPE()
        {
            string query = "UPDATE shape SET shapename=@otherField1 WHERE shapeid=@otherID";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // WHERE clause
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Update data to the size table
        public void UPDATE_OTHERS_SIZE()
        {
            string query = "UPDATE size SET sizename=@otherField1 WHERE sizeid=@otherID";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // WHERE clause
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Update data to the theme table
        public void UPDATE_OTHERS_THEME()
        {
            string query = "UPDATE theme SET themename=@otherField1 WHERE themeid=@otherID";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // WHERE clause
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Update data to the year table
        public void UPDATE_OTHERS_YEAR()
        {
            string query = "UPDATE year SET yearnumber=@otherField1 WHERE yearid=@otherID";
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@otherField1", MySqlDbType.VarChar).Value = othersField1;

                // WHERE clause
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Delete postcard in the database
        public void DELETE_OTHERS(int opt)
        {
            string query = "";
            if (opt == 1)
                query = "DELETE FROM coloring WHERE coloringid=@otherID";
            else if (opt == 2)
                query = "DELETE FROM cond WHERE condid=@otherID";
            else if (opt == 3)
                query = "DELETE FROM country WHERE countryid=@otherID";
            else if (opt == 4)
                query = "DELETE FROM material WHERE materialid=@otherID";
            else if (opt == 5)
                query = "DELETE FROM orient WHERE orientid=@otherID";
            else if (opt == 6)
                query = "DELETE FROM publish WHERE publishid=@otherID";
            else if (opt == 7)
                query = "DELETE FROM senttype WHERE senttypeid=@otherID";
            else if (opt == 8)
                query = "DELETE FROM shape WHERE shapeid=@otherID";
            else if (opt == 9)
                query = "DELETE FROM size WHERE sizeid=@otherID";
            else if (opt == 10)
                query = "DELETE FROM theme WHERE themeid=@otherID";
            else if (opt == 11)
                query = "DELETE FROM yyear WHERE yearid=@otherID";

            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // WHERE
                cmd.Parameters.Add("@otherID", MySqlDbType.Int32).Value = othersID;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }
        /*
         * 
         *  End of Others Table Management
         * 
         */

    }
}
