using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.SqlLite
{
     class InsertAndQuestionSQL: CreateConnection , ILoadHistoryOrders, ISaveHistory
    {

        private void AddNewTaskOrder(Order order)
        {
            PriceAll priceAll = order.PriceAll;
            FindingMaxIdCena(priceAll);
            SQLiteConnection cn = CreateSQLiteConnection();
            using (cn)
            {

                cn.Open();

                string sql = "INSERT INTO " + name.PriceAll + "(" + name.Id + ", " + name.Price + ", " + name.Date + ", " + name.Comments + ") VALUES(@param1, @param2, @param3, @param4)";

                SQLiteParameter param1 = new SQLiteParameter("param1", DbType.Int64);
                SQLiteParameter param2 = new SQLiteParameter("param2", DbType.String);
                SQLiteParameter param3 = new SQLiteParameter("param3", DbType.String);
                SQLiteParameter param4 = new SQLiteParameter("param4", DbType.String);

                SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);


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
                    Console.WriteLine("bład przy dodawaniu zamownienia \n" + e);
                }
                cn.Close();              
                AddNewTaskDish(order);
            }

        }

        private void AddNewTaskDish(Order order)
        {
            SQLiteConnection cn = CreateSQLiteConnection();
            using (cn)
            {               
                List<Dish> listaDania = order.ListDishes;
                PriceAll cena = order.PriceAll;
                cn.Open();
                foreach (var dania in listaDania)
                {
                    string sql = "INSERT INTO " + name.Dishes + "(" + name.IdPrice + ", " + name.Dish + ", " + name.Price + ", " + name.SidesDishes + ") VALUES(@param1, @param2, @param3, @param4)";

                    SQLiteParameter param1 = new SQLiteParameter("param1", DbType.String);
                    SQLiteParameter param2 = new SQLiteParameter("param2", DbType.String);
                    SQLiteParameter param3 = new SQLiteParameter("param3", DbType.String);
                    SQLiteParameter param4 = new SQLiteParameter("param4", DbType.String);

                    
                    SQLiteCommand cmd = new SQLiteCommand(sql, cn);
                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);
                    cmd.Parameters.Add(param3);
                    cmd.Parameters.Add(param4);

                    param1.Value = order.PriceAll.ID;
                    param2.Value = dania.Name;
                    param3.Value = dania.Price;
                    param4.Value = dania.SidesDishes;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("bład AddNewTaskDania\n" + e);
                    }
                }
                cn.Close();
            }
        }

        private void FindingMaxIdCena(PriceAll cena)
        {
            SQLiteConnection cn = CreateSQLiteConnection();
            using (cn)
            {
                string findingMaxIdPrice = "SELECT  MAX(id) FROM " + name.PriceAll;
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(findingMaxIdPrice, cn))
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
                                    cena.ID = Convert.ToInt64(dr[0]);
                                    
                                }
                                catch
                                {
                                    dr.Close();
                                }
                            }
                            dr.Close();
                            cena.ID++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    cena.ID = 1;
                    cn.Close();

                }
                cn.Close();

            }
        }

       
        private void UpdateAllTabele(List<Order> listOrder)
        {
            RemoveAllTask();

            foreach(var order in listOrder)
            {
                AddNewTaskOrder(order);
            }
        }

        private void RemoveAllTask()
        {
            SQLiteConnection cn = CreateSQLiteConnection();
            using (cn)
            {
                string deletePriceAll = "DELETE FROM "+ name.PriceAll;
                SQLiteCommand cmd = new SQLiteCommand(deletePriceAll, cn);
                cn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                cn.Close();
                SQLiteConnection.ClearAllPools();
            }
            cn = CreateSQLiteConnection();
            using (cn)
            {

                cn.Open();
                string sql = "DELETE FROM "+name.Dishes;

                SQLiteCommand cmd = new SQLiteCommand(sql, cn);

                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {                  
                    Console.WriteLine(ex);                 
                }

                cn.Close();
                SQLiteConnection.ClearAllPools();
            }           
        }

        private Order LoadDishes(string num, Order order)
        {
            SQLiteConnection cn = CreateSQLiteConnection();
            using (cn)
            {
                string qIdCeny = "SELECT * FROM " + name.Dishes + " WHERE " + name.IdPrice + " = " + num;
                try
                {
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(qIdCeny, cn);
                    AddDihes(order, cmd);
                    cmd.Cancel();                  
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                cn.Close();
            }
            return order;
        }

        private void AddDihes(Order order, SQLiteCommand cmd)
        {
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    try
                    {
                        Dish dish = new Dish
                        {
                            IdPrice = Convert.ToInt64(dr[1]),
                            Name = Convert.ToString(dr[2]),
                            Price = Convert.ToString(dr[3]),
                            SidesDishes = Convert.ToString(dr[4])
                        };
                        order.AddDishToListDisch(dish);
                    }
                    catch
                    {
                        dr.Close();
                    }
                    
                }
            }
            dr.Close();
        }

        private List<Order> LoadListOrderFromSQL()
        {
            List<Order> listorder = new List<Order>();
            SQLiteConnection cn = CreateSQLiteConnection();
            using (cn)
                {
                    string qCeny = "SELECT * FROM " + name.PriceAll + "";
                    try
                    {
                        cn.Open();
                        SQLiteCommand cmd = new SQLiteCommand(qCeny, cn);
                        SQLiteDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                        AddOrdersToListOrders(dr, listorder);
                        dr.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Błąd przy pobieraniu listy zamowień\n" + e);
                    }
                    cn.Close();
                }
                return listorder;
            }

        private void AddOrdersToListOrders (SQLiteDataReader dr, List<Order> listorder)
        {
            while (dr.Read())
            {
                try
                {
                    Order order = new Order();
                    PriceAll price = new PriceAll
                    {
                        ID = Convert.ToInt64(dr[0]),
                        Price = Convert.ToString(dr[1]),
                        Date = Convert.ToString(dr[2]),
                        Comments = Convert.ToString(dr[3])
                    };
                    order.PriceAll = price;
                    order = LoadDishes(Convert.ToString(price.ID), order);
                    listorder.Add(order);
                }
                catch
                {
                    dr.Close();
                }
            }
        }

        public List<Order> LoadHistory()
        {
            return LoadListOrderFromSQL();
        }

        public void SaveHistoryOrders(List<Order> listOrder)
        {
            UpdateAllTabele(listOrder);
        }

        public void AddOrder(Order order)
        {
            AddNewTaskOrder(order);
        }
    }
}
