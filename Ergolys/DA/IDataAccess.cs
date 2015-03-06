using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ergolys
{
    public interface IDataAccess
    {
        void Open();
        void Create();
        /// <summary>
        /// Select command
        /// </summary>
        /// <param name="cmd">Select from database</param>
        DataSet Read(string cmd);
        void Update();
        void Delete();
        void Close();
        //public List<Ergolys.DataAccess> RequestRecords;
    }
}
