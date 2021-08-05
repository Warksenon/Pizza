using Pizza.Presenters;

namespace Pizza.Models.SqlLite
{
    class AddOrderSQL : OrderSQL, IAddOrder
    {
        Order order;

        public AddOrderSQL(Order order)
        {
            this.order = order;
        }

        public void AddOrder()
        {
            AddNewTaskOrder(order);
        }
    }
}
