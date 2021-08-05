using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{

    public class SaveFiles : ISaveHistory
    {
        const string folderDatabase = @"c:\SQL\Konsola\sqlite\Historia zamówień.txt";
        Name name = new Name();
        private void SaveListOrder(List<Order> listOrder)
        {
            try
            {
                using (StreamWriter streamW = new StreamWriter((folderDatabase), false))
                {
                    streamW.WriteLine("");
                    streamW.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zapisanie do pilku txt nie powiodło się ", "Błąd przy zapisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RecordOfExceptions.Save(Convert.ToString(ex), "SaveFiles");
            }

            foreach (var order in listOrder)
            {
                Save(order);
            }
        }

        private void Save(Order order)
        {
            try
            {
                using (StreamWriter streamW = new StreamWriter((folderDatabase), true))
                {
                    string s="";
                    s = name.BeginningOfOrderCode + "\n" + AddPriceAll(order.PriceAll) + AddDishes(order)+ name.EndOfOrderCode;
                    streamW.WriteLine(s);
                    streamW.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zapisanie do pilku txt nie powiodło się ", "Błąd przy zapisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RecordOfExceptions.Save(Convert.ToString(ex), "Save");
            }
        }

        private string AddPriceAll (PriceAll priceAll)
        {
            string stPriceAll = name.PriceAllBeginning + "\n";
            stPriceAll += name.PriceAll+ priceAll.Price +"\n";
            stPriceAll += name.Date + priceAll.Date + "\n";
            stPriceAll += name.Comments + priceAll.Comments + "\n";
            stPriceAll += name.PriceAllEnd + "\n";
            return stPriceAll;
        }

        private string AddDishes(Order order)
        {
            string stDish=""; 
            foreach (var dish in order.ListDishes)
            {
                stDish += name.DishBeginning + "\n";
                stDish += name.Dish + dish.Name + "\n";
                stDish += name.Price + dish.Price + "\n";
                stDish += name.SidesDishes + dish.SidesDishes + "\n";
                stDish += name.DishEnd + "\n";
            }
             
            return stDish;
        }

        public void SaveHistoryOrders(List<Order> listOrder)
        {
            SaveListOrder(listOrder);
        }

        public void AddOrder(Order order)
        {
            Save(order);
        }
    }
}

