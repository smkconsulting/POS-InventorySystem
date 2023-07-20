using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace POS_Inventory.DAL
{
    public interface IDatabase
    {
        IDbConnection connection { get; }
        bool Execute();
        DataTable SelectData();
        List<IDbDataParameter> ParameterList { get; set; }
        List<MyDbParater>Parameters { get; set; }
        string CommandText { get; set; }
        string GetConnectionString();

        //method to convert list of mydbparameters to list of database specifict parameters 
        void ConvertParameters();
        
        //use to execute count commands and return integer
        int ExecuteInt();

    }
}
