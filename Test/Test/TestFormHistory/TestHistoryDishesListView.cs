using System.Collections.Generic;

using NUnit.Framework;

using Pizza;
using Pizza.Presenters.PresenterFormHistory;

namespace Test.Test.TestFormHistory
{
    [TestFixture]
    public class TestHistoryDishesListView
    {
        [TestCase( "0", "1", "nameFerst", "sideFerst", "priceFerst" )]
        [TestCase( "1", "2", "nameSecond", "sideSecond", "priceSecond" )]
        [TestCase( "2", "3", "nameThird", "sideThird", "priceThird" )]
        [TestCase( "3", "4", "nameFourth", "sideFourth", "priceFourth" )]
        [TestCase( "4", "5", "nameFifth", "sideFifth", "priceFifth" )]
        public void SetList_SetListOrder_ReturnLoadOrderWithListView ( int index, string expecteId, string expecteName, string expecteSides, string expectePrice )
        {
            var form = FormTest.CreateFormHistory();
            var list = new  FakeListDishes();
            var listView = new HistoryDishesListView(form);
            listView.SetList( list );

            var currentId = form.ListViewDishes.Items[index].SubItems[0].Text;
            var currentName  = form.ListViewDishes.Items[index].SubItems[1].Text;
            var currentPrice =  form.ListViewDishes.Items[index].SubItems[2].Text;
            var currentSides =  form.ListViewDishes.Items[index].SubItems[3].Text;


            Assert.AreEqual( expecteId, currentId );
            Assert.AreEqual( expecteName, currentName );
            Assert.AreEqual( expecteSides, currentSides );
            Assert.AreEqual( expectePrice, currentPrice );
        }
    }

    internal class FakeListDishes : IListGet<Dish>
    {
        public List<Dish> GetList ()
        {
            var list = new List<Dish>();

            var dis1 = FakeDishes.CrateFerst();
            var dis2 = FakeDishes.CrateSecond();
            var dis3 = FakeDishes.CrateThird();
            var dis4 = FakeDishes.CrateFourth();
            var dis5 = FakeDishes.CrateFifth();

            list.Add( dis1 );
            list.Add( dis2 );
            list.Add( dis3 );
            list.Add( dis4 );
            list.Add( dis5 );


            return list;
        }
    }
}
