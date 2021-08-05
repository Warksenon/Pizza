using Newtonsoft.Json;
using Pizza.Models.FilesTXT;
using Pizza.Presenters;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pizza
{

    public class SaveFiles : ISaveHistory, IAddOrder
    {
        const string _path = @"c:\SQL\Konsola\sqlite\Historia zamówień.txt";
        Order order;
        ListOrder listOrder = new ListOrder();

        public SaveFiles(Order order)
        {
            this.order = order;
        }

        public SaveFiles(List<Order> listOrder)
        {
            this.listOrder.List = listOrder;
        }


        private void SaveListOrder()
        {
            try
            {
                var customer = listOrder;
                var jsonToWrite = JsonConvert.SerializeObject(customer, Formatting.Indented);

                using (var writer = new StreamWriter(_path))
                {
                    writer.Write(jsonToWrite);
                }
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save(Convert.ToString(ex), "SaveListOrder");
            }
        }

        private void Save()
        {
            try
            {
                LoadHistoryToListOrder();
                listOrder.AddOrder(order);
                var customer = listOrder;
                var jsonToWrite = JsonConvert.SerializeObject(customer, Formatting.Indented);

                using (StreamWriter writer = new StreamWriter((_path)))
                {
                    writer.Write(jsonToWrite);
                }
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save(Convert.ToString(ex), "Save");
            }
        }

        private void LoadHistoryToListOrder()
        {
            LoadingFilesTxt load = new LoadingFilesTxt();
            listOrder.List = load.LoadHistory();
        }

        public void SaveHistoryOrders()
        {
            SaveListOrder();
        }

        public void AddOrder()
        {
            Save();
        }
    }
}

