using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.SqlLite
{
    class CreateConnection
    {
        public Name name = new Name();

        public const string folderDatabase = @"c:\SQL\Konsola\sqlite\";
        public const string databaseFile = "SqlLitePizza.sqlite";
        public const string strConnection = @"Data Source=" + folderDatabase + databaseFile + ";Version=3;";

        public SQLiteConnection CreateSQLiteConnection()
        {
            SQLiteConnection cn = new SQLiteConnection(strConnection);
            return cn;
        }
    }
}
