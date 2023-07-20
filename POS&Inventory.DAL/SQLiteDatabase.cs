using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace POS_Inventory.DAL
{
    public class SQLiteDatabase : IDatabase
    {
        private SQLiteConnection _connection; 
        public IDbConnection connection
        {
            get 
            {
                if (_connection ==null)
                {
                    _connection = new SQLiteConnection(GetConnectionString());
                }
                return _connection;
            }
        }
        public string CommandText { get; set; }
        
        public string GetConnectionString()
        {
           return  ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString;
        }        

        public bool Execute()
        {
            bool IsExecuted = false;
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (var myCommand = new SQLiteCommand(CommandText, (SQLiteConnection)connection))
                    {
                        if ((CommandText.ToUpper().StartsWith("SELECT ")) || (CommandText.ToUpper().StartsWith("INSERT "))
                            || (CommandText.ToUpper().StartsWith("UPDATE ")) || (CommandText.ToUpper().StartsWith("DELETE ")))
                        {
                            myCommand.CommandType = CommandType.Text;
                        }
                        else
                        {
                            myCommand.CommandType = CommandType.StoredProcedure;
                        }

                        if (ParameterList != null)
                        {
                            ParameterList.ForEach(p => myCommand.Parameters.Add(p));
                        }
                        IsExecuted = myCommand.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception)
                {
                    //Handle Exception Here
                }

            }
            return IsExecuted;
        }
        public int ExecuteInt()
        {
            int IsExecutedValue = 0;
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (var myCommand = new SQLiteCommand(CommandText, (SQLiteConnection)connection))
                    {
                        if ((CommandText.ToUpper().StartsWith("SELECT ")) || (CommandText.ToUpper().StartsWith("INSERT "))
                            || (CommandText.ToUpper().StartsWith("UPDATE ")) || (CommandText.ToUpper().StartsWith("DELETE "))
                            || (CommandText.ToUpper().StartsWith("SELECT( ")))
                        {
                            myCommand.CommandType = CommandType.Text;
                        }
                        else
                        {
                            myCommand.CommandType = CommandType.StoredProcedure;
                        }

                        if (ParameterList != null)
                        {
                            ParameterList.ForEach(p => myCommand.Parameters.Add(p));
                        }
                        IsExecutedValue = (int)myCommand.ExecuteScalar();
                    }
                }
                catch (Exception)
                {
                    //Handle Exception Here
                }

            }
            return IsExecutedValue;
        }

        // For Select Queries
        public DataTable SelectData()
        {
            var myTable = new DataTable();
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (var myCommand = new SQLiteCommand(CommandText, (SQLiteConnection)connection))
                    {
                        if ((CommandText.ToUpper().StartsWith("SELECT ")) || (CommandText.ToUpper().StartsWith("INSERT "))
                                                    || (CommandText.ToUpper().StartsWith("UPDATE ")) || (CommandText.ToUpper().StartsWith("DELETE ")))
                        {
                            myCommand.CommandType = CommandType.Text;
                        }
                        else
                        {
                            myCommand.CommandType = CommandType.StoredProcedure;
                        }

                        if (ParameterList != null)
                        {
                            ParameterList.ForEach(p => myCommand.Parameters.Add(p));
                        }
                        var adapter = new SQLiteDataAdapter(myCommand);
                        adapter.Fill(myTable);
                    }
                }
                catch (Exception)
                {
                    //Handle Exception Here
                }

            }
            return myTable;
        }

        //List to store Database Specific Paraters;
        public List<IDbDataParameter> ParameterList { get; set; }

        //list to store userdefined Parameters;
        public List<MyDbParater> Parameters { get; set; }

        //convert userdefined parameters to specific database parameters;
        public void ConvertParameters()
        {
            
            Parameters.ForEach(p =>
            {               
                var para = new SQLiteParameter(p.Name, p.ParaValue);
                
                ParameterList.Add(para);
            });
        }
       

    }

}
