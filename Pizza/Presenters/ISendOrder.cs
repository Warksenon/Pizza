namespace Pizza.Presenters
{
    public interface ISendOrder
    {
        bool SendMessag ( IElementGet<Order> element );
    }
}
