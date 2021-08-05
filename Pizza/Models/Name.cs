using System.Configuration;

namespace Pizza
{
    public static class Name
    {
        public static string GetNameConfig ( string key )
        {
            string name = ConfigurationManager.AppSettings[key];

            if (HelpFinding.CheckStringIsNotEmpty( name ))
            {
                return name;
            }
            else
            {
                return "name retrieval error: " + key;
            }
        }

        public static string LMenuInfoPizza
        {
            get
            {
                return GetNameConfig( "lMenuInfoPizza" );
            }
        }

        public static string LMenuInfoMainDish
        {
            get
            {
                return GetNameConfig( "lMenuInfoMainDish" );
            }
        }

        public static string LMenuInfoSoups
        {
            get
            {
                return GetNameConfig( "lMenuInfoSoups" );
            }
        }

        public static string LMenuInfoDrinks
        {
            get
            {
                return GetNameConfig( "lMenuInfoDrinks" );
            }
        }

        public static string PriceAll
        {
            get
            {
                return GetNameConfig( "priceAll" );
            }
        }

        public static string Dishes
        {
            get
            {
                return GetNameConfig( "dishes" );
            }
        }

        public static string IdPrice
        {
            get
            {
                return GetNameConfig( "idPrice" );
            }
        }

        public static string Comments
        {
            get
            {
                return GetNameConfig( "comments" );
            }
        }

        public static string Id
        {
            get
            {
                return GetNameConfig( "id" );
            }
        }

        public static string SidesDishes
        {
            get
            {
                return GetNameConfig( "sidesDishes" );
            }
        }

        public static string Date
        {
            get
            {
                return GetNameConfig( "Date" );
            }
        }

        public static string Price
        {
            get
            {
                return GetNameConfig( "Price" );
            }
        }

        public static string Dish
        {
            get
            {
                return GetNameConfig( "Dish" );
            }
        }

        public static string PriceForDish
        {
            get
            {
                return GetNameConfig( "priceForDish" );
            }
        }

        public static string HashSigns51
        {
            get
            {
                return GetNameConfig( "hashSigns51" );
            }
        }

        public static string CommentsMessag
        {
            get
            {
                return GetNameConfig( "commentsMessag" );
            }
        }

        public static string BeginningOfOrderCode
        {
            get
            {
                return GetNameConfig( "beginningOfOrderCode" );
            }
        }
        public static string EndOfOrderCode
        {
            get
            {
                return GetNameConfig( "endOfOrderCode" );
            }
        }

        public static string PriceAllBeginning
        {
            get
            {
                return GetNameConfig( "priceAllBeginning" );
            }
        }

        public static string PriceAllEnd
        {
            get
            {
                return GetNameConfig( "priceAllEnd" );
            }
        }

        public static string DishBeginning
        {
            get
            {
                return GetNameConfig( "dishBeginning" );
            }
        }

        public static string DishEnd
        {
            get
            {
                return GetNameConfig( "dishEnd" );
            }
        }

        public static string NPrice
        {
            get
            {
                return GetNameConfig( "nPrice" );
            }
        }

        public static string Pizza
        {
            get
            {
                return GetNameConfig( "pizza" );
            }
        }

        public static string Denmark
        {
            get
            {
                return GetNameConfig( "denmark" );
            }
        }

        public static string Soups
        {
            get
            {
                return GetNameConfig( "soups" );
            }
        }

        public static string Drinks
        {
            get
            {
                return GetNameConfig( "drinks" );
            }
        }

        public static string Margh
        {
            get
            {
                return GetNameConfig( "margh" );
            }
        }

        public static string Veget
        {
            get
            {
                return GetNameConfig( "veget" );
            }
        }

        public static string Tosca
        {
            get
            {
                return GetNameConfig( "tosca" );
            }
        }

        public static string Venec
        {
            get
            {
                return GetNameConfig( "venec" );
            }
        }

        public static string MarghPrice
        {
            get
            {
                return GetNameConfig( "marghPrice" );
            }
        }

        public static string VegetPrice
        {
            get
            {
                return GetNameConfig( "vegetPrice" );
            }
        }

        public static string ToscaPrice
        {
            get
            {
                return GetNameConfig( "toscaPrice" );
            }
        }

        public static string VenecPrice
        {
            get
            {
                return GetNameConfig( "venecPrice" );
            }
        }

        public static string DoubelCheese
        {
            get
            {
                return GetNameConfig( "doubelCheese" );
            }
        }

        public static string Salami
        {
            get
            {
                return GetNameConfig( "salami" );
            }
        }

        public static string Ham
        {
            get
            {
                return GetNameConfig( "ham" );
            }
        }

        public static string Mushrooms
        {
            get
            {
                return GetNameConfig( "mushrooms" );
            }
        }

        public static string DoubelCheesePrice
        {
            get
            {
                return GetNameConfig( "doubelCheesePrice" );
            }
        }

        public static string SalamiPrice
        {
            get
            {
                return GetNameConfig( "salamiPrice" );
            }
        }

        public static string HamPrice
        {
            get
            {
                return GetNameConfig( "hamPrice" );
            }
        }

        public static string MushroomsPrice
        {
            get
            {
                return GetNameConfig( "mushroomsPrice" );
            }
        }

        public static string Schnitzel
        {
            get
            {
                return GetNameConfig( "schnitzel" );
            }
        }

        public static string Fish
        {
            get
            {
                return GetNameConfig( "fish" );
            }
        }

        public static string Potato
        {
            get
            {
                return GetNameConfig( "potato" );
            }
        }

        public static string SchnitzelPrice
        {
            get
            {
                return GetNameConfig( "schnitzelPrice" );
            }
        }

        public static string FishPrice
        {
            get
            {
                return GetNameConfig( "fishPrice" );
            }
        }

        public static string PotatoPrice
        {
            get
            {
                return GetNameConfig( "potatoPrice" );
            }
        }

        public static string Bar
        {
            get
            {
                return GetNameConfig( "bar" );
            }
        }

        public static string SetOfSauces
        {
            get
            {
                return GetNameConfig( "setOfSauces" );
            }
        }

        public static string BarPrice
        {
            get
            {
                return GetNameConfig( "barPrice" );
            }
        }

        public static string SetOfSaucesPrice
        {
            get
            {
                return GetNameConfig( "setOfSaucesPrice" );
            }
        }

        public static string Tomato
        {
            get
            {
                return GetNameConfig( "tomato" );
            }
        }

        public static string ChickenSoup
        {
            get
            {
                return GetNameConfig( "chickenSoup" );
            }
        }

        public static string TomatoPrice
        {
            get
            {
                return GetNameConfig( "tomatoPrice" );
            }
        }

        public static string ChickenSoupPrice
        {
            get
            {
                return GetNameConfig( "chickenSoupPrice" );
            }
        }

        public static string Coffee
        {
            get
            {
                return GetNameConfig( "coffee" );
            }
        }

        public static string Tea
        {
            get
            {
                return GetNameConfig( "tea" );
            }
        }

        public static string Cola
        {
            get
            {
                return GetNameConfig( "cola" );
            }
        }

        public static string CoffeePrice
        {
            get
            {
                return GetNameConfig( "coffeePrice" );
            }
        }

        public static string TeaPrice
        {
            get
            {
                return GetNameConfig( "teaPrice" );
            }
        }

        public static string ColaPrice
        {
            get
            {
                return GetNameConfig( "colaPrice" );
            }
        }

        public static string Sender
        {
            get
            {
                return GetNameConfig( "sender" );
            }
        }

        public static string Password
        {
            get
            {
                return GetNameConfig( "password" );
            }
        }

        public static string Smtp
        {
            get
            {
                return GetNameConfig( "smtp" );
            }
        }

        public static string Port
        {
            get
            {
                return GetNameConfig( "port" );
            }
        }

        public static string Recipient
        {
            get
            {
                return GetNameConfig( "recipient" );
            }
        }

    }
}
