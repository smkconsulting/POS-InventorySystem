using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS_Inventory.DAL
{
    public static class DatabaseFactory
    {
        public static IDatabase CreateDatabase(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.AccessDatabase:
                    return new AccessDatabase();
                case DatabaseType.SQLiteDatabase:
                    return new SQLiteDatabase();
                default:
                    return new SqlServerDatabase();

            }
        }
    }
}
