using System;
using System.Data.SQLite;
using System.IO;

namespace Pizza.SqlLite
{
    internal class CreateSQLiteTables : CreateConnection
    {
        public void CreateSqliteTables ()
        {
            CreateSQLiteDatabaseFile();
            CreateSQLitePriceAll( CreateSQLiteConnection() );
            CreateSQLiteDishes( CreateSQLiteConnection() );
        }

        private void CreateSQLiteDatabaseFile ()
        {
            DirectoryInfo di = new DirectoryInfo(folderDatabase);

            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
                }
            }

            FileInfo fi = new FileInfo(folderDatabase + databaseFile);

            if (!fi.Exists)
            {
                SQLiteConnection.CreateFile( folderDatabase + databaseFile );
            }
        }

        private void CreateSQLitePriceAll ( SQLiteConnection cn )
        {
            using (cn)
            {
                string sql = "CREATE TABLE '" + Name.PriceAll + "'('id' INTEGER PRIMARY KEY , '" + Name.Price + "' TEXT, '" + Name.Date + "' TEXT, '" + Name.Comments + "' TEXT);";

                try
                {
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand( sql, cn ))
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Cancel();
                    }
                }
                catch (Exception ex)
                {
                    RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
                }
                cn.Close();
            }
        }

        private void CreateSQLiteDishes ( SQLiteConnection cn )
        {
            using (cn)
            {
                string sql2 = "CREATE TABLE '" + Name.Dishes + "'('id' INTEGER PRIMARY KEY,'" + Name.IdPrice + "' int, '" + Name.Dish + "' TEXT ,'" + Name.Price + "' TEXT,'" + Name.SidesDishes + "' );";

                try
                {
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand( sql2, cn ))
                    {
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
                }
                cn.Close();
            }
        }
    }
}
