using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace POS_Inventory.DAL
{
    public class AccessDatabase : IDatabase
    {
        private OleDbConnection _connection; 
        public IDbConnection connection
        {
            get 
            {
                if (_connection ==null)
                {
                    _connection = new OleDbConnection(GetConnectionString());
                }
                return _connection;
            }
        }
        public string CommandText { get; set; }
        
        public string GetConnectionString()
        {
           return  ConfigurationManager.ConnectionStrings["AccessConnection"].ConnectionString;
        }        

        public bool Execute()
        {
            bool IsExecuted = false;
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (var myCommand = new OleDbCommand(CommandText, (OleDbConnection)connection))
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
                    using (var myCommand = new OleDbCommand(CommandText, (OleDbConnection)connection))
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
                    using (var myCommand = new OleDbCommand(CommandText, (OleDbConnection)connection))
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
                        var adapter = new OleDbDataAdapter(myCommand);
                        adapter.Fill(myTable);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error opening connection..{0}", ex.Message);

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
                var para = new OleDbParameter(p.Name, p.ParaValue);
                
                ParameterList.Add(para);
            });
        }
       

    }

}
