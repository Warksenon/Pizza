using System.Collections.Generic;
using System.Text;

using Pizza.Presenters;
using Pizza.Presenters.PresenterFormMenu;

namespace Pizza
{
    public class AddOrder
    {
        private readonly FormMenu _form;
        private readonly IListSet<Dish> _listDishes;
        IPrice _iPrice;
        IDialogService _dialogService;

        public AddOrder ( FormMenu form, IListSet<Dish> listDishes )
        {

            _form = form;
            _listDishes = listDishes;
            _iPrice = new OrderListView( _form );
            _dialogService = new DialogBox();
        }

        public void SetPrice ( IPrice iPrice )
        {
            _iPrice = iPrice;
        }

        public void SetDialog ( IDialogService dialogService )
        {
            _dialogService = dialogService;
        }

        IElementGet<Dish> _dish;
        IListGet<string> _sides;

        public void SetOrder ( IElementGet<Dish> getDish, IListGet<string> getSides )
        {
            _dish = getDish;
            _sides = getSides;
            var dish = CreateDish();
            var listDish = GetListSelektedDishes(dish);
            _listDishes.SetList( listDish );
        }

        private Dish CreateDish ()
        {
            var dish =  _dish.GetElement();
            var listSides = _sides.GetList();
            if (listSides.Count == 0)
            {
                dish.Sides = "";
            }
            else
            {
                dish.Name = dish.Name + " - " + dish.Price;
                var allSidesToGether = AddAllSides(listSides);
                dish.Sides = allSidesToGether;
                var priceAll = AddPriceDisheAndSide(dish, listSides);
                dish.Price = priceAll;
            }

            return dish;
        }

        private List<Dish> GetListSelektedDishes ( Dish dish )
        {
            var list = new List<Dish>();
            int numbersRepetitions = CheckNumberTextViewDishes();

            if (numbersRepetitions > 0)
            {
                while (numbersRepetitions >= 1)
                {
                    list.Add( dish );
                    numbersRepetitions -= 1;
                }
            }

            return list;
        }

        private int CheckNumberTextViewDishes ()
        {
            int number = HelperConvert.ConvertTextToInt(_form.QTextbox.Text);

            if (number < 1)
            {
                _dialogService.ShowMessage( "Podana ilość produktów nie jest prawidłowa" );
            }

            return number;
        }

        private string AddAllSides ( List<string> listSides )
        {
            StringBuilder allSidesToGether = new StringBuilder();
            for (int i = 0; i < listSides.Count; i++)
            {
                allSidesToGether.Append( listSides [i] );
                if (i == listSides.Count - 1)
                {
                    allSidesToGether.Append( "." );
                }
                else
                {
                    allSidesToGether.Append( "," );
                }
            }

            return allSidesToGether.ToString();
        }

        private string AddPriceDisheAndSide ( Dish dish, List<string> listSides )
        {
            var priceSides = 0.0;
            var price =0.0;

            foreach (var side in listSides)
            {
                price = _iPrice.FindPriceAndConvertToDoubel( side );
                priceSides += price;
            }

            price = _iPrice.FindPriceAndConvertToDoubel( dish.Price );
            var priceAll =  price + priceSides;
            return priceAll + "zł";
        }

    }
}
