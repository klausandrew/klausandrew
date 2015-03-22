using Ergolys.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;

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
            SqlConnection connection = new SqlConnection(String.Format(@"Data Source=(LocalDB)\v11.0;AttachDbFilename={0}{1};Integrated Security=True",dir,"\\Northwind\\Data\\NORTHWND.MDF"));
            
            connection.Open();
            
            SqlCommand command = new SqlCommand("Select * from Orders", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(ds);
            dt=ds.Tables[0];
        }

        [TestMethod]
        public void AccessWebPage() {

            WebClient webClient = new WebClient();
            webClient.Credentials = new System.Net.NetworkCredential("UserName", "Password", "Domain");
            string pageHTML = webClient.DownloadString("https://online.wellsfargo.com/cgi-bin/signon.cgi");

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
    }
}
