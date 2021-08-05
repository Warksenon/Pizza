namespace Pizza.Presenters
{
    public class SaveOrder
    {
        public void AddOrder( IAddOrder save )
        {
            save.AddOrder();
        }
    }
}
