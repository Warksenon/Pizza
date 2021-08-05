using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

using Pizza.SqlLite;

namespace Pizza.Models.SqlLite
{
    internal abstract class OrderSQL : CreateConnection
    {
        protected void AddNewTaskOrder ( Order order )
        {
            PriceAll priceAll = order.PriceAll;
            priceAll.ID = FindingMaxIdCena();
            SQLiteConnection cn = CreateSQLiteConnection();
            using (cn)
            {
                cn.Open();

                string sql = "INSERT INTO " + Name.PriceAll + "(" + Name.Id + ", " + Name.Price + ", " + Name.Date + ", " + Name.Comments + ") VALUES(@param1, @param2, @param3, @param4)";

                SQLiteParameter param1 = new SQLiteParameter("param1", DbType.Int64);
                SQLiteParameter param2 = new SQLiteParameter("param2", DbType.String);
                SQLiteParameter param3 = new SQLiteParameter("param3", DbType.String);
                SQLiteParameter param4 = new SQLiteParameter("param4", DbType.String);

                using (SQLiteCommand cmd = new SQLiteCommand( sql, cn ))
                {
                    cmd.Parameters.Add( param1 );
                    cmd.Parameters.Add( param2 );
                    cmd.Parameters.Add( param3 );
                    cmd.Parameters.Add( param4 );

                    param1.Value = order.PriceAll.ID;
                    param2.Value = order.PriceAll.Price;
                    param3.Value = order.PriceAll.Date;
                    param4.Value = order.PriceAll.Comments;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        RecordOfExceptions.Save( Convert.ToString( e ), "InsertAndQuestionSQL - AddNewTaskOrder" );
                    }
                }
                cn.Close();
                AddNewTaskDish( order );
            }

        }

        private void AddNewTaskDish ( Order order )
        {
            SQLiteConnection cn = CreateSQLiteConnection();
            using (cn)
            {
                List<Dish> listaDania = order.ListDishes;
                PriceAll cena = order.PriceAll;
                cn.Open();
                foreach (var dania in listaDania)
                {
                    string sql = "INSERT INTO " + Name.Dishes + "(" + Name.IdPrice + ", " + Name.Dish + ", " + Name.Price + ", " + Name.SidesDishes + ") VALUES(@param1, @param2, @param3, @param4)";

                    SQLiteParameter param1 = new SQLiteParameter("param1", DbType.String);
                    SQLiteParameter param2 = new SQLiteParameter("param2", DbType.String);
                    SQLiteParameter param3 = new SQLiteParameter("param3", DbType.String);
                    SQLiteParameter param4 = new SQLiteParameter("param4", DbType.String);

                    using (SQLiteCommand cmd = new SQLiteCommand( sql, cn ))
                    {
                        cmd.Parameters.Add( param1 );
                        cmd.Parameters.Add( param2 );
                        cmd.Parameters.Add( param3 );
                        cmd.Parameters.Add( param4 );

                        param1.Value = order.PriceAll.ID;
                        param2.Value = dania.Name;
                        param3.Value = dania.Price;
                        param4.Value = dania.Sides;

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
                        }
                    }
                }
                cn.Close();
            }
        }

        private int FindingMaxIdCena ()
        {
            int id = 0;
            SQLiteConnection cn = CreateSQLiteConnection();

            using (cn)
            {
                string findingMaxIdPrice = "SELECT  MAX(id) FROM " + Name.PriceAll;
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand( findingMaxIdPrice, cn ))
                    {
                        cn.Open();
                        SQLiteDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //Did not close the connection, in the case of an epty table
                                try
                                {
                                    id = Convert.ToInt32( dr [0] );

                                }
                                catch
                                {
                                    dr.Close();
                                }
                            }
                            dr.Close();
                            id++;
                        }
                    }
                }
                catch (Exception e)
                {
                    RecordOfExceptions.Save( Convert.ToString( e ), "InsertAndQuestionSQL - FindingMaxIdCena" );
                    id = 1;
                    cn.Close();
                }
                cn.Close();
                return id;
            }
        }
    }
}
