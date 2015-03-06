using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Ergolys;
using Ergolys.DataAccess;
namespace Ergolys
{
    public class Request
    {

        public int RequestID { get; set; }
        public DateTime DateOfRequest { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }

    public class RequestSet : IDataAccess
    {
        //public List<Request> RequestRecords {get; set;}
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

        public System.Data.DataSet Read(string cmd) {
            throw new NotImplementedException();
        }


        public void Open() {
            throw new NotImplementedException();
        }
    }     
}
