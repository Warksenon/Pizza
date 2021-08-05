using Pizza.Presenters;

namespace Pizza.Models.SqlLite
{
    internal class SaveOrderSQL : OrderSQL, IElementSet<Order>
    {
        public void SetElement ( Order order )
        {
            AddNewTaskOrder( order );
        }
    }
}
