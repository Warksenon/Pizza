using System;
using System.Collections.Generic;
using System.Data.SQLite;

using Pizza.SqlLite;

namespace Pizza.Models.SqlLite
{
    internal class LoadHistorySQL : CreateConnection, IListGet<Order>
    {
        private List<Order> LoadListOrderFromSQL ()
        {
            var listorder = new List<Order>();
            SQLiteConnection cn = CreateSQLiteConnection();
            using (cn)
            {
                string qCeny = "SELECT * FROM " + Name.PriceAll + "";
                try
                {
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand( qCeny, cn ))
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            AddOrdersToListOrders( dr, listorder );
                            dr.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
                }
                cn.Close();
            }

            return listorder;
        }

        private void AddOrdersToListOrders ( SQLiteDataReader dr, List<Order> listorder )
        {
            while (dr.Read())
            {
                try
                {
                    Order order = new Order();
                    PriceAll price = new PriceAll()
                    {
                        ID = Convert.ToInt32(dr[0]),
                        Price = Convert.ToString(dr[1]),
                        Date = Convert.ToString(dr[2]),
                        Comments = Convert.ToString(dr[3])
                    };
                    order.PriceAll = price;
                    order = LoadDishes( Convert.ToString( price.ID ), order );
                    listorder.Add( order );
                }
                catch (Exception ex)
                {
                    dr.Close();
                    RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
                }
            }
        }

        private Order LoadDishes ( string num, Order order )
        {
            SQLiteConnection cn = CreateSQLiteConnection();
            using (cn)
            {
                string qIdCeny = "SELECT * FROM " + Name.Dishes + " WHERE " + Name.IdPrice + " = " + num;
                try
                {
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand( qIdCeny, cn ))
                    {
                        AddDihes( order, cmd );
                        cmd.Cancel();
                    }
                }
                catch (Exception ex)
                {
                    RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
                }
                cn.Close();
            }

            return order;
        }

        private void AddDihes ( Order order, SQLiteCommand cmd )
        {
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    try
                    {
                        int id = Convert.ToInt32(dr[1]);
                        Dish dish = new Dish(id)
                        {
                            Name = Convert.ToString(dr[2]),
                            Price = Convert.ToString(dr[3]),
                            Sides = Convert.ToString(dr[4])
                        };
                        order.AddDishToListDisch( dish );
                    }
                    catch
                    {
                        dr.Close();
                    }

                }
            }
            dr.Close();
        }

        List<Order> IListGet<Order>.GetList ()
        {
            return LoadListOrderFromSQL();
        }
    }
}
