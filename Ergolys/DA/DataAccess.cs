using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Ergolys;
using System.Data;
using System.Data.Sql;
namespace Ergolys
{
    public partial class DataAccess  {



        //Directory.GetFiles("..\\..\\ObjectModels\\NORTHWND.MDF");
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=..\\..\\ObjectModels\\NORTHWND.MDF;Integrated Security=True");
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=\..\..\ObjectModels\NORTHWND.MDF;Integrated Security=True");//
        //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=\\..\\..\\ObjectModels\\" + "NORTHWND.MDF;Integrated Security=True");
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Klaus\Desktop\Andrew\github\Ergolys\ObjectModels\NORTHWND.MDF;Integrated Security=True");
        //string[] path = Directory.GetFiles("..\\..\\ObjectModels\\");

        //string path = "..\\..\\ObjectModels";
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Klaus\Desktop\Andrew\github\Ergolys\ObjectModels\NORTHWND.MDF;Integrated Security=True");

        public void Create() {
            throw new NotImplementedException();
        }
    

        /// <summary>
        /// Select command
        /// </summary>
        /// <param name="select">Select from database</param>
        public DataSet Read(string cmd) {

            string sc = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string us = "Data Source=" + sc.Remove(0, 6) + "\\NORTHWIND.MDF";
            string fs = us.Replace("\",\"", ";");
            //StringBuilder sb = new StringBuilder();
            //sb.Replace("","");

            SqlConnection conn = new SqlConnection {
                ConnectionString = fs//"Data Source=" + sc.Remove(0,6) + "\\NORTHWIND.MDF"
            };

            //TODO:update string literal in App.config
            conn.ConnectionString.Replace(@"\\",@"");
            
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            //string path = "..\\..\\ObjectModels\\";
            //AppDomain.CurrentDomain.SetData("DataDirectory", path);
            //connection.Dispose();
            connection.Close();
            //ConnectionString = "Data Source=" + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Database.sdf"
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=..\..\ObjectModels\NORTHWIND.MDF;Integrated Security=True");
            conn.Open();
            //connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|Northwind.mdf;Integrated Security=True");
            SqlCommand command = new SqlCommand(cmd, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            adapter.Fill(ds);
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

        public DataSet Read() {
            throw new NotImplementedException();
        }
    }
    }
