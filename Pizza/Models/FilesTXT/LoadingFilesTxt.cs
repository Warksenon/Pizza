using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using Pizza.Models.FilesTXT;

namespace Pizza
{
    internal class LoadingFilesTxt : Files, IListGet<Order>
    {
        private List<Order> LoadOrderListFromTxt ()
        {

            try
            {
                string jsonFromFile;
                using (var reader = new StreamReader( fileName ))
                {
                    jsonFromFile = reader.ReadToEnd();
                }

                var order = JsonConvert.DeserializeObject<JsonHelper>(jsonFromFile);
                listOrder = order.List;
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
            }

            return listOrder;
        }

        public List<Order> GetList ()
        {
            return LoadOrderListFromTxt();
        }
    }
}
