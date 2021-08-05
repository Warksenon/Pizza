using System.Collections.Generic;

namespace Pizza
{
    public  interface ILoadHistoryOrders
    {
        List<Order> LoadHistory();
    }
}
