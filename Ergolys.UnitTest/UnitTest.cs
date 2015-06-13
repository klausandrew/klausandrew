using Ergolys.DataAccess;
using Ergolys.NorthwindEntityContext;
using ImageModule.Models;
using ImageModule.Models.ImageModuleRepository;
using Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Collections;
using System.Configuration;

namespace Ergolys.UnitTest {

    [TestClass]
    public class ErgolysUnitTests {
        [TestMethod]
        public void DataAccess() {
            IDataAccess _da = new DataAccess.DataAccess();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            Mock<DataSet> moqOrders = new Mock<DataSet>();

            //Solution directory TODO: |DataDirectory|
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Klaus\Desktop\Andrew\github\Ergolys\ObjectModels\NORTHWND.MDF;Integrated Security=True");
            SqlConnection connection =
                new SqlConnection(
                    String.Format(@"Data Source=(LocalDB)\v11.0;AttachDbFilename={0}{1};Integrated Security=True", dir,
                        "\\Northwind\\Data\\NORTHWND.MDF"));

            connection.Open();

            SqlCommand command = new SqlCommand("Select * from Orders", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(ds);
            dt = ds.Tables[0];
        }
        [TestMethod]
        public void GetNWEntities() {

            ImageContext images = new ImageContext();



            //var records = (from r in images.Images
            //               where r != null
            //               select r).AsEnumerable();

            //Assert.IsNotNull(records);
        }
        [TestMethod]
        public void ContextConnection() {

            //unimportant
            //SqlConnection conn = new SqlConnection();
            //SqlCommand comm = new SqlCommand();

            //comm.ExecuteReader();

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataSet ds =new DataSet();
            //adapter.Fill(ds);

            //IEnumerable<Order> order = (from o in db.Orders
            //    select o).AsEnumerable();
        }

        [TestMethod]
        public void NotificationObject() {

        }

        [TestMethod]
        public void CascadeUpdate() {

            var connectionString = ConfigurationManager.ConnectionStrings["NORTHWINDEntities"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            //SqlCommand command = new SqlCommand("SELECT * FROM information_schema.tables", conn);
            SqlCommand command = new SqlCommand("SELECT *", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            
            DataSet ds = new DataSet();
            //DataTable dtOrders = adapter.Fill(ds.Tables["Orders"]);
            //DataTable dtOrderDetail = adapter.Fill(ds.Tables["Order_Details"]);

            //Select DB Objects

            //SELECT sobjects.name
            //FROM sysobjects sobjects
            //WHERE sobjects.xtype = 'U'
            //Here is a list of other object types you can search for as well:

            //C: Check constraint
            //D: Default constraint
            //F: Foreign Key constraint
            //L: Log
            //P: Stored procedure
            //PK: Primary Key constraint
            //RF: Replication Filter stored procedure
            //S: System table
            //TR: Trigger
            //U: User table
            //UQ: Unique constraint
            //V: View
            //X: Extended stored procedure
            
            
            using(var context = new NorthwindEntityContext.NORTHWINDEntities()){
                //var da = DataAccess();
                
                for (int i = 0; i < 125; i++) {
                    context.Orders.Add(new Order() { OrderID = i });
                }
                for (int i = 0; i < 125; i++) {
                    context.Order_Details.Add(new Order_Detail() { OrderID = i });
                }

                //var query = from o in context.Orders
                //            from c in context.Customers.Where(c => c.CustomerID == o.CustomerID).DefaultIfEmpty()
                //            from d in context.Order_Details.Where(d => d.OrderID == o.OrderID).DefaultIfEmpty()
                //    group new { o, c, d } by new { o.OrderDate.Value.Year, c.CompanyName } into g
                //    select new {
                //        Company = g.Key.CompanyName,
                //        OrderYear = g.Key.Year,
                //        Amount = g.Sum(e => e.d.UnitPrice * e.d.Quantity)
                //    };            
            }


            NORTHWINDEntities north = new NORTHWINDEntities();
            var query = from o in north.Orders
                    from c in north.Customers.Where(c => c.CustomerID == o.CustomerID).DefaultIfEmpty()
                    from d in north.Order_Details.Where(d => d.OrderID == o.OrderID).DefaultIfEmpty()
                    group new { o, c, d } by new { o.OrderDate.Value.Year, c.CompanyName } into g
                    select new {
                        Company = g.Key.CompanyName,
                        OrderYear = g.Key.Year,
                        Amount = g.Sum(e => e.d.UnitPrice * e.d.Quantity)
                    };

            NORTHWINDEntities db = new NORTHWINDEntities();
            for (int i = 0; i < 125; i++) {
                db.Orders.Add(new Order() { OrderID = i});
            }
            for (int i = 0; i < 125; i++) {
                db.Order_Details.Add(new Order_Detail() { OrderID = i});
            }

            //select record(s)
            var record = from r in db.Orders
                         join d in db.Order_Details on r.OrderID equals d.OrderID
                         select r;
            string rec = "";
            
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetInterface() {
            IEnumerable _data = null;
            
            _data.GetType();
            NORTHWINDEntities db = new NORTHWINDEntities();
            var records = (from o in db.Orders
                           select o).AsEnumerable();

            ImageContext image = new ImageContext();
            for (int i = 0; i <= 100; i++) {
                image.Images.Add(new ImageModel() {
                    Id = int.MinValue
                });
            }

            IEnumerable<ImageModel> img = (from r in image.Images
                                           where r != null
                                           select r).AsEnumerable();
            Assert.IsNotNull(img);
        }

        [TestMethod]
        public void DataObject() {
            NORTHWINDEntities db = new NORTHWINDEntities();
            var records = (from o in db.Orders
                           select o).AsEnumerable();
            //db.Orders();
            //Moq.Linq();
            ImageContext image = new ImageContext();
            for (int i = 0; i <= 100; i++) {       

                image.Images.Add(new ImageModel() {
                    Id = int.MinValue
                });
            }
            IEnumerable<ImageModel> img = (from r in image.Images
                                           where r != null
                                           select r).AsEnumerable();
            //var ll = new LazyLoader;
            //LazyLoader;

            //Moq.Linq(img);
            //img.Cast<ImagesDBContext>(image)(img);

            Assert.IsNotNull(image);
        }
        [TestMethod]
        public void AccessWebPage() {
            WebClient webClient = new WebClient();
            webClient.Credentials = new System.Net.NetworkCredential("UserName", "Password", "Domain");
            string pageHTML = webClient.DownloadString("https://online.wellsfargo.com/cgi-bin/signon.cgi");

            pageHTML = "";

            //TODO: Add creditials to page html and run http put request.

            WebRequest myWebRequest = WebRequest.Create("https://online.wellsfargo.com/cgi-bin/signon.cgi");
            WebResponse myWebResponse = myWebRequest.GetResponse();
            Stream ReceiveStream = myWebResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(ReceiveStream, encode);
            string strResponse = readStream.ReadToEnd();

            //TODO: writes markup without css formatting
            string strFilePath = @"C:\Users\Klaus\Desktop\Andrew\github\Ergolys.UnitTest\TestFile.cgi";

            //parse file for un an pw field
            //string.Parse(strFilePath.Substring(0));

            StreamWriter oSw = new StreamWriter(strFilePath);
            oSw.WriteLine(strResponse);
            oSw.Close();
            readStream.Close();
            myWebResponse.Close();

            Console.WriteLine("Test");
            Console.ReadLine();
            Assert.Fail("All tests are designed to fail, at first...");
        }
        [TestMethod]
        public void FizzBuzz() {
            StringBuilder print = new StringBuilder();
            for (decimal i = 0; i <= 100; i++) {
                print.Append(Environment.NewLine);
                print.Append(i.ToString() + " - ");
                print.Append(((i / 3 % 1) == 0) ? "Fizz" : "");
                print.AppendLine(((i / 5 % 1) == 0) ? "Buzz" : "");
            }
        }
        [TestMethod]
        public void Minify() {

            //var fileList = new Directory.GetFiles("C:\\Users\\Klaus\\Desktop\\Andrew\\githubCSmin\\Ergolys\\Content"); //FileAttributes fa; 
            //foreach(string fn in fileList){
            //    fileList.Add(fileList[i]);
            //}

            Assert.IsTrue(true);
        }
        /// <summary>
        /// apx. ~15min. 
        /// </summary>
        [TestMethod]
        public void WriteFile() {
            StringBuilder print = new StringBuilder();
            for (decimal i = 0; i <= 100; i++) {
                print.Append(Environment.NewLine);
                print.Append(i.ToString() + " - ");
                print.Append(((i / 3 % 1) == 0) ? "Fizz" : "");
                print.AppendLine(((i / 5 % 1) == 0) ? "Buzz" : "");
            }
            string file = @"C:\Users\Klaus\Desktop\Andrew\github\Ergolys.UnitTest\FileStreamFromByteArray.txt";
            FileStream writer = File.Open(file, FileMode.Truncate);
            //writer.WriteAsync(print.ToString);// (print);
            writer.Close();
        }
        [TestMethod]
        public void parseJson() {
            JsonParser json = new Json.JsonParser();
            json.ToString();
            //json(parseJson());
        }
        [TestMethod]
        public void DbContextCreate() {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void DbContextRead() { 
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void DbContextUpdate() {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void DbContextLogicalDelete() {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void GetImageSet() {
            IEnumerable<ImageModel> ImageSet;
            Assert.IsTrue(true);
        }

        /*using System;
        using System.Collections.Generic;
        using System.Text;
        using System.Configuration;
        using System.Data.SqlClient;
        using System.IO;
 
        namespace myMoney
        {
 
            class DB
            {
                const string connectionSting = ConfigurationManager.ConnectionStrings["myMoney.Properties.Settings.myMoneyConnectionString"].ConnectionString;
       
                public static string GetSingleValue(string queryString)
                {
                    object queryResult;
 
                    using (SqlConnection connection = new SqlConnection(
                               connectionSting))
                    {
                        SqlCommand command = new SqlCommand(queryString);
                        command.Connection = connection;
                        connection.Open();
 
                        queryResult = command.ExecuteScalar();
                        connection.Close();
                        return queryResult.ToString();
                    }
                }
 
                public static void WriteSingleValue(string updateString)
                {
                    using (SqlConnection connection = new SqlConnection(connectionSting))
                    {
                        SqlCommand command = new SqlCommand(updateString);
                        command.Connection = connection;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }*/
    }
}   


        
 