using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.SqlLite
{
    class CreateTabeles: CreateConnection
    {
        public void CreateSQLiteTables()
        {          
            CreateSQLiteDatabaseFile();
            CreateSQLitePriceAll(CreateSQLiteConnection());
            CreateSQLiteDishes(CreateSQLiteConnection());           
        }

        private void CreateSQLiteDatabaseFile()
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
                    RecordOfExceptions.Save(Convert.ToString(ex), "CreateSQLiteDatabaseFile");
                }
            }

            FileInfo fi = new FileInfo(folderDatabase + databaseFile);

            if (!fi.Exists)
            {
                SQLiteConnection.CreateFile(folderDatabase + databaseFile);
               
            }
            else
            {
               
            }
        }

        private void CreateSQLitePriceAll(SQLiteConnection cn)
        {
            using (cn)
            {
                string sql = "CREATE TABLE '" + name.PriceAll + "'('id' INTEGER PRIMARY KEY , '" + name.Price + "' TEXT, '" + name.Date + "' TEXT, '" + name.Comments + "' TEXT);";
                try
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                }
                catch (Exception ex)
                {
                    RecordOfExceptions.Save(Convert.ToString(ex), "CreateSQLitePriceAll");
                }
                cn.Close();
            }
        }

        private void CreateSQLiteDishes(SQLiteConnection cn)
        {
            using (cn)
            {
                string sql2 = "CREATE TABLE '" + name.Dishes + "'('id' INTEGER PRIMARY KEY,'" + name.IdPrice + "' int, '" + name.Dish + "' TEXT ,'" + name.Price + "' TEXT,'" + name.SidesDishes + "' );";
                try
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(sql2, cn);
                    cmd.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    RecordOfExceptions.Save(Convert.ToString(ex), "CreateSQLiteDishes");
                }
                cn.Close();
            }
        }
    }
}
