using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ergolys.DataAccess;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using Ergolys.DataAccess;
using System.IO;
using System.Reflection;
using Moq;

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
    }
}
