namespace Pizza
{
    internal class SaveHistory
    {
        public void SaveList( ISaveHistory save )
        {
            save.SaveHistoryOrders();
        }
    }
}