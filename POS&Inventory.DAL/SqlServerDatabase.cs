using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace POS_Inventory.DAL
{
    public class SqlServerDatabase : IDatabase
    {
        public IDbConnection connection => throw new NotImplementedException();      

        public List<IDbDataParameter> ParameterList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CommandText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<MyDbParater> Parameters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ConvertParameters()
        {
            throw new NotImplementedException();
        }

        public bool Execute()
        {
            throw new NotImplementedException();
        }

        public int ExecuteInt()
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public DataTable SelectData()
        {
            throw new NotImplementedException();
        }
    }
}
