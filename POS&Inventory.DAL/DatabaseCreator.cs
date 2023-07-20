using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS_Inventory.DAL
{
    public static class DatabaseCreator
    {
        public static IDatabase GetDatabase()
        {
            return DatabaseFactory.CreateDatabase(DatabaseType.SQLiteDatabase);
        }
    }
}
