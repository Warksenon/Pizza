using System.Collections.Generic;
using NUnit.Framework;

using Pizza;


namespace Test
{
    [TestFixture]
    public class TestMenuDishes
    {
        static FakeListDishes  fakeLD = new FakeListDishes();
        static FakeListSides  fakeLS = new FakeListSides();
        MenuDishes<FakeListDishes,FakeListSides> menu = new MenuDishes<FakeListDishes,FakeListSides>( fakeLD, fakeLS);
        FakeDishesList dishesList = new FakeDishesList ();
        FakeSidesList sidesList =new  FakeSidesList ();

        [TestCase( "marghPrice", "1", "0" )]
        [TestCase( "vegetPrice", "2", "1" )]
        [TestCase( "toscaPrice", "3", "2" )]
        [TestCase( "venecPrice", "4", "3" )]
        public void CreateMenuPizza_CheckDataPizzaDish_ReturnListDishPizza ( string expectationsName, string expectationsPrice, int index )
        {
            menu.CreateMenuPizza( dishesList, sidesList );
            var list = dishesList.GetList();

            var  currentName  = list [index].Name;
            var  currentPrice = list [index].Price;

            Assert.AreEqual( expectationsName, currentName );
            Assert.AreEqual( expectationsPrice, currentPrice );
        }

        [TestCase( "doubelCheesePrice", "0" )]
        [TestCase( "salamiPrice", "1" )]
        [TestCase( "hamPrice", "2" )]
        [TestCase( "mushroomsPrice", "3" )]
        public void CreateMenuPizza_CheckDataPizzaSides_ReturnListSidesPizza ( string expectationsName, int index )
        {
            menu.CreateMenuPizza( dishesList, sidesList );
            var list = sidesList.GetList();

            var  currentName  = list [index];

            Assert.AreEqual( expectationsName, currentName );
        }

        [TestCase( "schnitzelPrice", "1", "0" )]
        [TestCase( "fishPrice", "2", "1" )]
        [TestCase( "potatoPrice", "3", "2" )]
        public void CreateMenuMainDishes_CheckDataMainDishes_ReturnListDishMainDishes ( string expectationsName, string expectationsPrice, int index )
        {
            menu.CreateMenuMainDishes( dishesList, sidesList );
            var list = dishesList.GetList();

            var  currentName  = list [index].Name;
            var  currentPrice = list [index].Price;

            Assert.AreEqual( expectationsName, currentName );
            Assert.AreEqual( expectationsPrice, currentPrice );
        }

        [TestCase( "barPrice", "0" )]
        [TestCase( "setOfSaucesPrice", "1" )]
        public void CreateMenuMainDishes_CheckDataMainDishesSides_ReturnListSidesMainDishes ( string expectationsName, int index )
        {
            menu.CreateMenuMainDishes( dishesList, sidesList );
            var list = sidesList.GetList();

            var  currentName  = list [index];

            Assert.AreEqual( expectationsName, currentName );
        }

        [TestCase( "coffeePrice", "1", "0" )]
        [TestCase( "teaPrice", "2", "1" )]
        [TestCase( "colaPrice", "3", "2" )]
        public void CreateMenuDrinks_CheckDataDrinksDish_ReturnListDishDrinks ( string expectationsName, string expectationsPrice, int index )
        {
            menu.CreateMenuDrinks( dishesList, sidesList );
            var list = dishesList.GetList();

            var  currentName  = list [index].Name;
            var  currentPrice = list [index].Price;

            Assert.AreEqual( expectationsName, currentName );
            Assert.AreEqual( expectationsPrice, currentPrice );
        }

        [TestCase( "tomatoPrice", "1", "0" )]
        [TestCase( "chickenSoupPrice", "2", "1" )]
        public void CreateMenuSoup_CheckDataSaupsDish_ReturnListDishSaups ( string expectationsName, string expectationsPrice, int index )
        {
            menu.CreateMenuSoups( dishesList, sidesList );
            var list = dishesList.GetList();

            var  currentName  = list [index].Name;
            var  currentPrice = list [index].Price;

            Assert.AreEqual( expectationsName, currentName );
            Assert.AreEqual( expectationsPrice, currentPrice );
        }


        public void CreateMenuPizza_HandingOverObjectNull_ReturnListNull ()
        {
            FakeListDishes  nullLD=null;
            FakeListSides  nullLS=null;
            MenuDishes<FakeListDishes,FakeListSides> menu = new MenuDishes<FakeListDishes,FakeListSides>( nullLD, nullLS);
            menu.CreateMenuPizza( dishesList, sidesList );
            var listDishes = dishesList.GetList();
            var listSides = sidesList.GetList();

            Assert.IsNull( listDishes );
            Assert.IsNull( listSides );
        }

        public void CreateMenuMainDishes_HandingOverObjectNull_ReturnListNull ()
        {
            FakeListDishes  nullLD=null;
            FakeListSides  nullLS=null;
            MenuDishes<FakeListDishes,FakeListSides> menu = new MenuDishes<FakeListDishes,FakeListSides>( nullLD, nullLS);
            menu.CreateMenuMainDishes( dishesList, sidesList );
            var listDishes = dishesList.GetList();
            var listSides = sidesList.GetList();

            Assert.IsNull( listDishes );
            Assert.IsNull( listSides );
        }

        public void CreateMenuDrinks_HandingOverObjectNull_ReturnListNull ()
        {
            FakeListDishes  nullLD=null;
            FakeListSides  nullLS=null;
            MenuDishes<FakeListDishes,FakeListSides> menu = new MenuDishes<FakeListDishes,FakeListSides>( nullLD, nullLS);
            menu.CreateMenuDrinks( dishesList, sidesList );
            var listDishes = dishesList.GetList();
            var listSides = sidesList.GetList();

            Assert.IsNull( listDishes );
            Assert.IsNull( listSides );
        }

        public void CreateMenuSoups_HandingOverObjectNull_ReturnListNull ()
        {
            FakeListDishes  nullLD=null;
            FakeListSides  nullLS=null;
            MenuDishes<FakeListDishes,FakeListSides> menu = new MenuDishes<FakeListDishes,FakeListSides>( nullLD, nullLS);
            menu.CreateMenuSoups( dishesList, sidesList );
            var listDishes = dishesList.GetList();
            var listSides = sidesList.GetList();

            Assert.IsNull( listDishes );
            Assert.IsNull( listSides );
        }

    }

    public class FakeListDishes : IListGet<Dish>, IListSet<string>
    {
        private List<Dish> listDisches = new List<Dish>();
        private Dish disch = new Dish();

        private void AddDishesToList ( List<string> key )
        {
            listDisches = new List<Dish>();
            int i =1;
            foreach (var k in key)
            {
                disch = new Dish();
                disch.Name = k;
                disch.Price = i.ToString();
                listDisches.Add( disch );
                i++;
            }
        }

        public List<Dish> GetList ()
        {
            return listDisches;
        }

        public void SetList ( List<string> key )
        {
            AddDishesToList( key );
        }
    }

    public class FakeListSides : IListGet<string>, IListSet<string>
    {
        private readonly List<string>  listSides = new List<string>();

        public void SetList ( List<string> listKey )
        {
            listSides.Clear();
            foreach (var k in listKey)
            {
                listSides.Add( k );
            }
        }

        public List<string> GetList ()
        {
            var list = listSides;
            return list;
        }
    }

    internal class FakeDishesList : IElementGet<Dish>, IListSet<Dish>
    {
        private List<Dish> _listDisch = new List<Dish>();
        public FakeDishesList () { }

        public List<Dish> GetList ()
        {
            return _listDisch;
        }

        public Dish GetElement ()
        {
            return _listDisch [0];
        }

        public void SetList ( List<Dish> listDisch )
        {
            _listDisch = listDisch;
        }
    }

    internal class FakeSidesList : IListSet<string>, IListGet<string>
    {
        List<string> sides = new List<string>();
        public FakeSidesList () { }

        public List<string> GetList ()
        {
            return sides;
        }

        public void SetList ( List<string> elements )
        {
            sides = elements;
        }
    }
}
