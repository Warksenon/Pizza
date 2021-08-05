using System.Collections.Generic;
using NUnit.Framework;
using Pizza;
using Pizza.Presenters.PresenterFormMenu;

namespace Test.Test.TestFormMenu
{
    [TestFixture]
    public class TestOrderListView
    {
        [TestCase( "200 zł", "200" )]
        [TestCase( "10 zł", "10" )]
        [TestCase( "1 zł", "1" )]
        [TestCase( "0 zł", "0" )]
        [TestCase( "0 ", "0" )]
        [TestCase( "", "0" )]
        [TestCase( "101  zł", "101" )]
        [TestCase( "1  0  3  zł", "103" )]
        [TestCase( "1  0 aa 1  zł", "0" )]
        [TestCase( "zł", "0" )]
        [TestCase( "bbbb", "0" )]
        [TestCase( "3300 ", "3300" )]
        public void FindPriceAndConvertToDoubel_SetPriceText_ReturnDoubel ( string textPrice, double expectePrice )
        {
            var form = FormTest.CreateFormMenu();
            var lvOrder = new OrderListView(form);

            var currentPrice = lvOrder.FindPriceAndConvertToDoubel(textPrice);

            Assert.AreEqual( expectePrice, currentPrice );
        }

        FormMenu _form = new FormMenu();

        [TestCase( "0", "schabowy", "Bar sałatkowy", "35zł" )]
        [TestCase( "1", "Ryba z frytkami", "Zestaw sosów", "34zł" )]
        [TestCase( "2", "Placek po węgiersku", "Bar sałatkowy", "35zł" )]
        [TestCase( "3", "Vegetariana", "Salami, Szynka", "30zł" )]
        [TestCase( "4", "Tosca", "", "25zł" )]
        public void SetList_CheckAddDishesToListView_ReturnNameDishAndSidesAndPrice ( int index, string expecteName, string expecteSides, string expectePrice )
        {
            var dish = new Dish
            {
                Name=expecteName,
                Sides=expecteSides,
                Price = expectePrice
            };
            var list = new List<Dish>();
            list.Add( dish );
            var lvOrder = new OrderListView(_form);
            lvOrder.SetList( list );


            var currentName  = _form.ListViewOrder.Items [index].SubItems [0].Text;
            var currentSides = _form.ListViewOrder.Items [index].SubItems [1].Text;
            var currentPrice = _form.ListViewOrder.Items [index].SubItems [2].Text;

            Assert.AreEqual( expecteName, currentName );
            Assert.AreEqual( expecteSides, currentSides );
            Assert.AreEqual( expectePrice, currentPrice );
        }

        [TestCase()]
        public void GetPricaAll_CheckPriceCalculations_ReturnPrice ()
        {
            var form =  new FormMenu();
            var list = FakeCreateListDish.CreateListWithFourDishes();
            var lvOrder = new OrderListView(form);
            lvOrder.SetList( list );

            var currentPrice = lvOrder.GetPricaAll();

            Assert.AreEqual( 6, currentPrice );
        }

        [TestCase( "0" )]
        [TestCase( "1" )]
        [TestCase( "2" )]
        [TestCase( "3" )]
        public void GetElement_CheckGetOrderFromListView_ReturnOrder ( int index )
        {
            var form =  new FormMenu();
            var list = FakeCreateListDish.CreateListWithFourDishes();
            var lvOrder = new OrderListView(form);
            lvOrder.SetList( list );
            var order = lvOrder.GetElement();

            var expectePrice = index.ToString();
            var currentName  = order.ListDishes[index].Name;
            var currentSides = order.ListDishes[index].Sides;
            var currentPrice = order.ListDishes[index].Price;

            Assert.AreEqual( "sss", currentName );
            Assert.AreEqual( "ff", currentSides );
            Assert.AreEqual( expectePrice, currentPrice );
        }
    }

    internal class FakeCreateListDish
    {
        public static List<Dish> CreateListWithFourDishes ()
        {
            var list = new List<Dish>();

            for (int i = 0; i < 4; i++)
            {
                var dish = new Dish
                {
                    Name="sss",
                    Sides="ff",
                    Price = i.ToString()
                };
                list.Add( dish );
            }

            return list;
        }
    }
}
