using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Ergolys.DataAccess;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using Ergolys;
using System.IO;

namespace Ergolys
{
    class Program : IDataAccess
    {
        public static void Main(string[] args) {
            #region TestMethods
            
            //SMTPOutgoing smptOutgoing = new SMTPOutgoing();
            //smptOutgoing.SMTP("","","","");
            //Console.WriteLine("Complete");
            //Console.ReadLine();

            //ADO.NET connection
            IDataAccess _da = new DataAccess.DataAccess();

            //var query = from p in dbContext.ProductSet
            //            where p.Categories.CategoryName == "Seafood"
            //            select p;
            //IEnumerable<Product> products = query.ToList();

            _da = new DataAccess.DataAccess();
            _da.Open();
            DataSet ds = _da.Read("Select * from Orders");
            DataTable dt = ds.Tables[0];

            //Refernce another project (MVC)
            //Ask for user input
            //Create Inforce referential integrity with complex object            
            //Read
            //Update
            //Delete record
            //Reference JAVA
            //Reference Perl
            //referenca SOAP

            #region Load dictionary values in enum or from web.config file.
                    Dictionary<int, string> type = new Dictionary<int, string>();
                    type.Add(1, "Home");
                    type.Add(2, "Product");
                    type.Add(3, "Parts");
                    type.Add(4, "Service Order");

                    Console.WriteLine("Select type");
            
                    string selectedValue = Console.Read().ToString();
                    type.ContainsKey(Convert.ToInt32(selectedValue));

                    //foreach (KeyValuePair<int, string> pair in selectedValue) {
                    //    Console.WriteLine(pair.Key.ToString());
                    //}

                    selectedValue.GetType();

                    if (true) {
                        Console.WriteLine("You've selected ", "KeyValue");
                    } else {
                        Console.WriteLine("Invalid selection");
                    }
                    Console.ReadLine();
                #endregion

            #endregion
        }

        public string InputFromConsole() {
            string s = Console.ReadLine();
            return s;
        }

        public void Return(string s) {
            Console.WriteLine(); 
            Console.WriteLine(s.ToString());
        }

        public string Create() {
            throw new NotImplementedException();
        }

        void IDataAccess.Create() {
            throw new NotImplementedException();
        }

        public void Update() {
            throw new NotImplementedException();
        }

        public void Delete() {
            throw new NotImplementedException();
        }

        public DataSet Read(string cmd) {
            throw new NotImplementedException();
        }


        public void Open() {
            throw new NotImplementedException();
        }
    } 
}
