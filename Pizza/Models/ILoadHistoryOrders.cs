using System.Collections.Generic;

namespace Pizza
{
    public interface ILoadHistoryOrders<T>
    {
        List<T> LoadHistory ();
    }
}
