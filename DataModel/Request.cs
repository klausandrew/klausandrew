using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Ergolys.DataAccess;

namespace Ergolys.DataModel
{
    class Request
    {

        public int RequestID { get; set; }
        public DateTime DateOfRequest { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }

    class RequestSet : IDataAccess
    {

        //IInterface i;// = new IInterface();   
        public List<Request> RequestRecords {get; set;}

        public string Create()
        {
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
