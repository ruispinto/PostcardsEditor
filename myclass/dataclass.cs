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

        // read properties
        public DataTable DT = new DataTable();
        public DataSet DS = new DataSet();

        public string sVersion = "2.0.01.0426";

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

        // Show data from the table 'Card' in the grid
        public void REFRESH_CARD()
        {
            string query = "SELECT cardnumber AS 'Card Number', cardpublisher AS 'Publisher', cardscanned AS 'Scanned', cardintheblog AS 'Blog', cardcountryname AS 'Country', carddesceng AS 'Description (English)', carddescoriginal AS 'Description (Original)', cardthemename AS 'Theme', cardcoloringabr AS 'Coloring', cardyearnumber AS 'Year', cardimgnmbr AS 'Tot.Num.of Img', cardseriesmulti AS 'Series ?', cardseriestotal AS 'Total Series', cardsizename AS 'Size', cardshapename AS 'Shape', cardorientabr AS 'Orient.', cardbarcode AS 'Barcode', cardmaterial as 'Material', cardcondabr AS 'Condition', cardborders AS 'Borders ?', cardfronttxtcolor AS 'Front Text Color', cardbacktxtcolor AS 'Back Text Color', carddatepurchased AS 'Purchase Date', cardcostprice AS 'Cost Price', cardwebpage AS 'Webpage', cardidentical AS 'Identical ?', cardequalsto AS 'Equals to', carddifferences AS 'Differencies', cardbigdesc AS 'Big Description', cardsenttypename AS 'Sent Type', cardtypedesc AS 'Type Description', cardfrontimgpath AS 'Front Image Path', cardbackimgpath AS 'Back Image Path' FROM card";
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
            string query = "UPDATE card SET cardnumber=@cnumber, cardpublisher=@cpublisher, cardscanned=@cscan, cardintheblog=@cblog, cardcountryname=@ccountry, carddesceng=@cdesceng, carddescoriginal=@cdescorig, cardthemename=@ctheme, cardcoloringabr=@ccolor, cardyearnumber=@cyear, cardimgnmbr=@cimg, cardseriesmulti=@csermulti, cardseriestotal=@csertotal, cardsizename=@csize, cardshapename=@cshape, cardorientabr=@corient, cardbarcode=@cbarcode, cardmaterial=@cmaterial, cardcondabr=@ccond, cardborders=@cborders, cardfronttxtcolor=@cfrttxtcolor, cardbacktxtcolor=@cbcktxtcolor, carddatepurchased=@cdtpurchase, cardcostprice=@ccost, cardwebpage=@cweb, cardidentical=@cidentical, cardequalsto=@cequals, carddifferences=@cdif, cardbigdesc=@cbigdsc, cardsenttypename=@csenttype, cardtypedesc=@ctypedesc, cardfrontimgpath=@cfrtimg, cardbackimgpath=@cbckimg WHERE cardnumber=@cnumber";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

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
                cmd.Parameters.Add("@cnumber", MySqlDbType.VarChar).Value = cardNumber;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Delete postcard in the database
        public void DELETE_CARD()
        {
            connectdb.Open();
            string query = "DELETE FROM card WHERE cardnumber=@cnumber";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // WHERE
                cmd.Parameters.Add("@cnumber", MySqlDbType.VarChar).Value = cardNumber;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();

            }
        }

        // Show data from the table 'CardSeries' in the grid
        public void REFRESH_MULTICARD(string upd_cardnumber)
        {
            string query = "SELECT seriescardnumber AS 'Main Card Number', seriesseccardnumber AS 'Secondary Card Number', seriesdesceng AS 'Description (English)', seriesdescoriginal AS 'Description (Original)', seriescolorabr AS 'Coloring', seriesorientabr AS 'Orient.', seriesimgcount AS 'Tot.Num.of Img', seriesdate AS 'Referenced Date', seriesyearnumber AS 'Year', seriesbarcode AS 'Barcode', seriesfronttxtcolor AS 'Front Text Color', seriesbacktxtcolor AS 'Back Text Color', seriesbigdesc AS 'Big Description', seriesfrontimgpath AS 'Front Image Path', seriesbackimgpath AS 'Back Image Path' FROM cardseries WHERE seriescardnumber='" + upd_cardnumber + "'";
            DT.Clear();
            MySqlDataAdapter DA = new MySqlDataAdapter(query, connectdb);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }

        // Show data from the table 'CardSeries' in the grid
        public void REFRESH_ALL_MULTICARD()
        {
            string query = "SELECT seriescardnumber AS 'Main Card Number', seriesseccardnumber AS 'Secondary Card Number', seriesdesceng AS 'Description (English)', seriesdescoriginal AS 'Description (Original)', seriescolorabr AS 'Coloring', seriesorientabr AS 'Orient.', seriesimgcount AS 'Tot.Num.of Img', seriesdate AS 'Referenced Date', seriesyearnumber AS 'Year', seriesbarcode AS 'Barcode', seriesfronttxtcolor AS 'Front Text Color', seriesbacktxtcolor AS 'Back Text Color', seriesbigdesc AS 'Big Description', seriesfrontimgpath AS 'Front Image Path', seriesbackimgpath AS 'Back Image Path' FROM cardseries";
            DT.Clear();
            MySqlDataAdapter DA = new MySqlDataAdapter(query, connectdb);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }

        // Add postcard to database
        public void ADD_SERIESCARD()
        {
            connectdb.Open();
            string query = "INSERT INTO cardseries(seriescardnumber, seriesseccardnumber, seriesdesceng, seriesdescoriginal, seriescolorabr, seriesorientabr, seriesimgcount, seriesdate, seriesyearnumber, seriesbarcode, seriesfronttxtcolor, seriesbacktxtcolor, seriesbigdesc, seriesfrontimgpath, seriesbackimgpath) VALUES(@snumber, @ssecnumber, @sdesceng, @sdescorig, @scolor, @sorient, @simg, @sdate, @syear, @sbarcode, @sfrttxtcolor, @sbcktxtcolor, @sbigdsc, @sfrtimg, @sbckimg) WHERE seriescardnumber=@snumber";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // add app fields data to the database fields
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

                cmd.Parameters.Add("@snumber", MySqlDbType.VarChar).Value = seriesCardNumber;
                // execute the query (in this case add a new postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Edit postcard from the database
        public void UPDATE_SERIESCARD()
        {
            connectdb.Open();
            string query = "UPDATE cardseries SET seriesseccardnumber=@ssecnumber, seriesdesceng=@sdesceng, seriesdescoriginal=@sdescorig, seriescolorabr=@scolor, seriesorientabr=@sorient, seriesimgcount=@simg, seriesdate=@sdate, seriesyearnumber=@syear, seriesbarcode=@sbarcode, seriesfronttxtcolor=@sfrttxtcolor, seriesbacktxtcolor=@sbcktxtcolor, seriesbigdesc=@sbigdsc, seriesfrontimgpath=@sfrtimg, seriesbackimgpath=@sbckimg WHERE seriesseccardnumber=@old_seriesSecond";
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
                cmd.Parameters.Add("@old_seriesSecond", MySqlDbType.VarChar).Value = seriesSecCardNumber;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }

        // Delete postcard in the database
        public void DELETE_SERIESCARD()
        {
            connectdb.Open();
            string query = "DELETE FROM cardseries WHERE seriesseccardnumber@ssecnumber";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                // WHERE
                cmd.Parameters.Add("@ssecnumber", MySqlDbType.VarChar).Value = seriesSecCardNumber;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();

            }
        }

        // Edit postcard from the database
        public void UPDATE_SECOND_NUMBER()
        {
            connectdb.Open();
            string query = "UPDATE cardseries SET seriesseccardnumber=@new_seriesSecond WHERE seriesseccardnumber=@old_seriesSecond";
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@new_seriesSecond", MySqlDbType.VarChar).Value = seriesSecCardNumber;

                // WHERE clause
                cmd.Parameters.Add("@old_seriesSecond", MySqlDbType.VarChar).Value = seriesSecCardNumber;

                // execute the query (in this case update the current postcard)
                cmd.ExecuteNonQuery();
                connectdb.Close();
            }
        }
    }
}
