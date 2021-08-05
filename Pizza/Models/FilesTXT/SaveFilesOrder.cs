using System;
using Pizza.Presenters;

namespace Pizza.Models.FilesTXT
{
    internal class SaveFilesOrder : Files, IElementSet<Order>
    {
        private Order order;

        private void Save ()
        {
            try
            {
                LoadHistoryToListOrder();
                listOrder.Add( order );
                var saveList = new SaveFilesHistoryOrder();
                saveList.SaveHistoryOrders( listOrder );
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save( Convert.ToString( ex ), ex.StackTrace );
            }
        }

        private void LoadHistoryToListOrder ()
        {
            var load = new LoadingFilesTxt();
            listOrder = load.GetList();
        }

        public void SetElement ( Order elements )
        {
            order = elements;
            Save();
        }

    }
}
