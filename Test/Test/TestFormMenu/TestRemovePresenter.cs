using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;
using Pizza.Presenters.PresenterFormMenu;

namespace Test.Test.TestFormMenu
{
    [TestClass]
    public class TestRemovePresenter
    {
        [TestMethod]
        public void RemoveAll_CheckClearListView_CoutIsZero ()
        {
            var form = FormTest.CreateFormMenu();
            var lvOrder = new OrderListView(form);
            var listDishes =  FakeCreateLis.CreateListWithThreeDishes();
            lvOrder.SetList( listDishes );
            var remove = new RemovePresenter(form);
            var countBeforeRemove = form.ListViewOrder.Items.Count;
            remove.RemoveAll();

            var currentCount = form.ListViewOrder.Items.Count;

            Assert.AreEqual( 0, currentCount );
            Assert.AreEqual( 3, countBeforeRemove );
        }

    }

    internal class FakeCreateLis
    {
        public static List<Dish> CreateListWithThreeDishes ()
        {
            var list = new List<Dish>();

            var dish = new Dish
            {
                Name="sss",
                Sides="ff",
                Price = "1"
            };
            list.Add( dish );

            var dish1 = new Dish
            {
                Name="ddd",
                Sides="ccc",
                Price = "2"
            };
            list.Add( dish1 );

            var dish2 = new Dish
            {
                Name="ddd",
                Sides="ccc",
                Price = "2"
            };
            list.Add( dish2 );

            return list;
        }
    }
}
