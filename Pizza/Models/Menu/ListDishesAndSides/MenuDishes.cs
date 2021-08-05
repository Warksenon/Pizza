using System.Collections.Generic;

namespace Pizza
{
    public class MenuDishes<D, S> where D : IListGet<Dish>, IListSet<string> where S : IListGet<string>, IListSet<string>
    {
        private readonly S _sides;
        private readonly D _dishes;

        public MenuDishes ( D dishes, S sides )
        {
            _dishes = dishes;
            _sides = sides;
        }

        public void CreateMenuPizza ( IListSet<Dish> dishes, IListSet<string> sides )
        {
            var keySides = new List<string> { "doubelCheesePrice", "salamiPrice", "hamPrice", "mushroomsPrice" };
            var listSides= CreateSidesList( keySides );
            sides.SetList( listSides );

            var keyDishes = new List<string> { "marghPrice", "vegetPrice", "toscaPrice", "venecPrice" };
            var listDishes = CreateDishesList( keyDishes );
            dishes.SetList( listDishes );
        }

        public void CreateMenuMainDishes ( IListSet<Dish> dishes, IListSet<string> sides )
        {
            var keySides = new List<string> { "barPrice", "setOfSaucesPrice" };
            var listSides = CreateSidesList( keySides );
            sides.SetList( listSides );

            var keyDishes = new List<string> { "schnitzelPrice", "fishPrice", "potatoPrice" };
            var listDishes = CreateDishesList( keyDishes );
            dishes.SetList( listDishes );
        }

        public void CreateMenuSoups ( IListSet<Dish> dishes, IListSet<string> sides )
        {
            sides.SetList( new List<string>() );

            var keyDishes = new List<string> { "tomatoPrice", "chickenSoupPrice" };
            var listDishes= CreateDishesList( keyDishes );
            dishes.SetList( listDishes );
        }

        public void CreateMenuDrinks ( IListSet<Dish> dishes, IListSet<string> sides )
        {
            sides.SetList( new List<string>() );

            var keyDishes = new List<string> { "coffeePrice", "teaPrice", "colaPrice" };
            var listDishes = CreateDishesList( keyDishes );
            dishes.SetList( listDishes );
        }

        private List<string> CreateSidesList ( List<string> listKey )
        {
            var sides =  _sides;
            sides.SetList( listKey );
            return sides.GetList();
        }

        private List<Dish> CreateDishesList ( List<string> listKey )
        {
            var dishes = _dishes;
            dishes.SetList( listKey );
            return dishes.GetList();
        }

    }
}
