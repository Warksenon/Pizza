namespace Pizza.Presenters.PresenterFormHistory.CopyHistory
{
    public class HistoryCopy
    {
        public static void CopyHistory ( IListGet<Order> load, ISaveHistory<Order> save )
        {
            var copyListOrder = load.GetList();
            save.SaveHistoryOrders( copyListOrder );
        }
    }
}
