using System.Collections.Generic;

using NUnit.Framework;

using Pizza;
using Pizza.Presenters.PresenterFormHistory.CopyHistory;

namespace Test.Test.TestFormHistory
{
    [TestFixture]
    public class TestHistoryCopy
    {
        [TestCase( "0", "nameFerst", "sideFerst", "priceFerst" )]
        [TestCase( "1", "nameSecond", "sideSecond", "priceSecond" )]
        public void CopyHistory_TestCopyData_ReturnListStringNameSidesPrice ( int index, string expecteName, string expecteSides, string expectePrice )
        {
            var load = new  FakeListOrder();
            var save = new  FakeSaveList();
            HistoryCopy.CopyHistory( load, save );

            var currentName  = save.name[index];
            var currentSides = save.sides[index];
            var currentPrice =  save.price[index];

            Assert.AreEqual( expecteName, currentName );
            Assert.AreEqual( expecteSides, currentSides );
            Assert.AreEqual( expectePrice, currentPrice );
        }
    }

    internal class FakeSaveList : ISaveHistory<Order>
    {
        public List<string> name = new List<string>();
        public List<string> sides = new List<string>();
        public List<string> price = new List<string>();

        public void SaveHistoryOrders ( List<Order> listOrders )
        {
            foreach (var order in listOrders)
            {
                foreach (var dish in order.ListDishes)
                {
                    name.Add( dish.Name );
                    sides.Add( dish.Sides );
                    price.Add( dish.Price );
                }
            }
        }
    }
}
