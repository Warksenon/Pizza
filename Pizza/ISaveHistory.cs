using System.Collections.Generic;

namespace Pizza
{
    public interface ISaveHistory
    {
        void SaveHistoryOrders(List<Order> listOrder);

        void AddOrder(Order order);
    }
}
