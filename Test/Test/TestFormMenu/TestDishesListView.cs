using System.Collections.Generic;

using NUnit.Framework;

using Pizza;
using Pizza.Presenters.PresenterFormMenu;

namespace Test.Test.TestFormMenu
{
    [TestFixture]
    public class TestDishesListView
    {
        [TestCase( "0", "dish1", "11zl" )]
        [TestCase( "1", "dish2", "22zl" )]
        public void SetList_SimulationSetListDishes_ReturnDish ( int index, string expectedName, string expectedPrice )
        {
            var form = FormTest.CreateFormMenu();
            DishesListView lvDishes = new DishesListView(form);
            var list =  FakeDishesList.GetDishes();
            lvDishes.SetList( list );

            var currentName = form.ListViewDishes.Items[index].SubItems[0].Text;
            var currentPrice =  form.ListViewDishes.Items[index].SubItems[1].Text;

            Assert.AreEqual( expectedName, currentName );
            Assert.AreEqual( expectedPrice, currentPrice );
        }

        [TestCase( "0", "dish1", "11zl" )]
        [TestCase( "1", "dish2", "22zl" )]
        public void GetElement_SimulationSelectDish_ReturnDish ( int index, string expectedName, string expectedPrice )
        {
            var form = FormTest.CreateFormMenu();
            DishesListView lvDishes = new DishesListView(form);
            var list =  FakeDishesList.GetDishes();
            lvDishes.SetList( list );
            lvDishes.SetIndexSelecteItem( index );
            var dish = lvDishes.GetElement();

            var currentName = dish.Name;
            var currentPrice =  dish.Price;

            Assert.AreEqual( expectedName, currentName );
            Assert.AreEqual( expectedPrice, currentPrice );
        }

        [TestCase( "0" )]
        [TestCase( "1" )]
        public void GetElement_SimulationGetElemntFromEmptyList_ReturnEmptyDish ( int index )
        {
            var form = FormTest.CreateFormMenu();
            DishesListView lvDishes = new DishesListView(form);
            lvDishes.SetIndexSelecteItem( index );
            var dish = lvDishes.GetElement();

            var currentName = dish.Name;
            var currentPrice =  dish.Price;

            Assert.IsEmpty( currentName );
            Assert.IsEmpty( currentPrice );
        }
    }

    internal class FakeDishesList
    {
        static public List<Dish> GetDishes ()
        {
            var dish1 = new Dish
            {
                Name = "dish1",
                Price = "11zl"
            };

            var dish2 = new Dish
            {
                Name = "dish2",
                Price = "22zl"
            };

            var list = new List<Dish>();
            list.Add( dish1 );
            list.Add( dish2 );
            return list;
        }
    }
}
