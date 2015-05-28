using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using Ergolys.DataAccess;
using Ergolys.NorthwindEntityContext;

namespace Ergolys.DataAccess {
    public class DataAccess : IDataAccess {



        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Klaus\Desktop\Andrew\github\Ergolys\ObjectModels\NORTHWND.MDF;Integrated Security=True");

        public void Create() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Select command
        /// </summary>
        /// <param name="select">Select from database</param>
        public DataSet Read(string cmd) {

            IDataAccess _da = new DataAccess();

            SqlConnection connection = new SqlConnection();

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            string sc = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string us = "Data Source=" + sc.Remove(0, 6) + "\\NORTHWIND.MDF";
            string fs = us.Replace("\\", "\\");

            SqlCommand command = new SqlCommand("Select * from Orders", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);


            _da = new DataAccess();
            _da.Open();
            connection.ConnectionString = fs;


            connection.Open();

            ds = _da.Read("Select * from Orders");
            dt = ds.Tables[0];

            return ds;
        }

        public void Update() {
            throw new NotImplementedException();
        }

        public void Delete() {
            throw new NotImplementedException();
        }

        public void Open() {
            connection.Open();
        }

        public void Close() {
            connection.Dispose();
            connection.Close();
        }
    }
}
