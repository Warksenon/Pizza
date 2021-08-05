using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    public class EmailMessage
    {
        private readonly List<Dish> listDishes;
        private readonly PriceAll priceAll;

        public EmailMessage ( Order order )
        {
            this.listDishes = order.ListDishes;
            this.priceAll = order.PriceAll;
        }

        public string WriteBill ()
        {
            string bill;
            bill = WritePriceAll( priceAll );
            bill += WriteDischesAll();
            bill += Name.CommentsMessag + "\n" + priceAll.Comments;

            return bill;
        }

        private string WritePriceAll ( PriceAll priceAll )
        {
            StringBuilder price = new StringBuilder();
            price.AppendLine( LinesHash() );
            price.AppendLine( OneHash() );
            price.Append( Data( priceAll ) );
            price.Append( NamePrice() );
            price.AppendLine( OneHash() );
            price.AppendLine( LinesHash() );

            return price.ToString();
        }
        private string LinesHash ()
        {
            return Name.HashSigns51;
        }

        private string Data ( PriceAll priceAll )
        {
            string data = string.Format("# {0,33}{1,16}", priceAll.Date, " ") + "\n";
            return data;
        }

        private string NamePrice ()
        {
            return "#" + string.Format( "{0,27}{1,-22}", Name.NPrice + ": ", priceAll.Price ) + "\n";
        }

        private string WriteDischesAll ()
        {
            StringBuilder dischesAll = new StringBuilder();

            foreach (var item in listDishes)
            {
                dischesAll.Append( WriteDisch( item ) );

            }
            return dischesAll.ToString();
        }

        private string OneHash ()
        {
            return "#";
        }

        private StringBuilder WriteDisch ( Dish disch )
        {
            StringBuilder wirteDisch = new StringBuilder();
            wirteDisch.AppendLine( LinesHash() );
            wirteDisch.AppendLine( OneHash() );
            wirteDisch.Append( TextPlusNewLines( disch.Name ) );

            if (CheckingAddOns( disch ))
            {
                string sidesDishes = disch.Sides;
                StringBuilder newSidesDishes = new StringBuilder();

                while (SideDishesIsEmpty( sidesDishes ))
                {
                    newSidesDishes.Append( "# " );
                    newSidesDishes.AppendLine( FindingCommaOrPeriodAndCuttingCharacters( sidesDishes ) );
                    sidesDishes = RemoveSideDishAndWhiteSigns( sidesDishes );

                }

                wirteDisch.Append( newSidesDishes );
            }

            string price = Name.PriceForDish + disch.Price + "\n";
            wirteDisch.Append( price );
            wirteDisch.AppendLine( OneHash() );
            wirteDisch.AppendLine( LinesHash() );

            return wirteDisch;
        }

        private string FindingCommaOrPeriodAndCuttingCharacters ( string sideDishes )
        {
            int index = FindIndexCommaOrPeriod(sideDishes);
            return ReturningCutWord( index, sideDishes );
        }

        private string ReturningCutWord ( int index, string sideDishes )
        {
            if (index == -1)
            {
                return "";
            }
            else
            {
                return sideDishes.Substring( 0, index );
            }
        }

        private int FindIndexCommaOrPeriod ( string sideDishes )
        {
            int index = sideDishes.IndexOf(",");
            if (index == -1)
            {
                index = sideDishes.IndexOf( "." );
            }
            return index;
        }

        private string RemoveSideDishAndWhiteSigns ( string sideDish )
        {
            int index = FindIndexCommaOrPeriod(sideDish);
            sideDish = sideDish.Remove( 0, index + 1 );

            return sideDish.Trim();
        }

        private bool CheckingAddOns ( Dish disch )
        {
            if (disch.Sides.Equals( "" ))
                return false;
            else
                return true;
        }

        private bool SideDishesIsEmpty ( string sideDishes )
        {
            if (sideDishes.Equals( "" ))
                return false;
            else
                return true;
        }

        private string TextPlusNewLines ( string text )
        {
            return "# " + text + "\n";
        }
    }
}
