using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace Ergolys.DataAccess
{
    public interface IDataAccess
    {
        void Create();
        void Update();
        void Delete();
        DataSet Read(string cmd);
        void Open();
    }
}