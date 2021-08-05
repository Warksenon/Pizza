using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using Pizza.Models.FilesTXT;

namespace Pizza
{
    internal class SaveFilesHistoryOrder : Files, ISaveHistory<Order>
    {
        public SaveFilesHistoryOrder ()
        {
            CreateFolder();
        }

        public void SaveHistoryOrders ( List<Order> listOrder )
        {
            this.listOrder = listOrder;
            SaveListOrder();
        }

        private void SaveListOrder ()
        {
            try
            {
                JsonHelper jsonHelper = new JsonHelper
                {
                    List = listOrder
                };
                var customer = jsonHelper;

                var jsonToWrite = JsonConvert.SerializeObject(customer, Formatting.Indented);

                using (var writer = new StreamWriter( fileName ))
                {
                    writer.Write( jsonToWrite );
                }
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
            }
        }

    }
}

