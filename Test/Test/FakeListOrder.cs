using System.Collections.Generic;

using Pizza;

namespace Test.Test
{
    internal class FakeListOrder : IListGet<Order>
    {
        public List<Order> GetList ()
        {
            var list = new List<Order>();
            var order = new Order();
            var priceAll = new PriceAll
            {
                Price = "50zł",
                Comments = "Hmmm....",
                ID=5,
                Date = "2020.12.02"

            };
            order.PriceAll = priceAll;
            var dish = FakeDishes.CrateFerst();
            order.ListDishes.Add( dish );
            var dish2 = FakeDishes.CrateSecond();
            order.ListDishes.Add( dish2 );
            list.Add( order );

            return list;
        }

    }
}
