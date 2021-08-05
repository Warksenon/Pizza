using System.Collections.Generic;

namespace Pizza
{
    public interface ISaveHistory<T>
    {
        void SaveHistoryOrders ( List<T> listOrders );
    }
}
