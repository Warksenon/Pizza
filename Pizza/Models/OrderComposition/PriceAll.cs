using Pizza.Models.OrderComposition;

namespace Pizza
{
    public class PriceAll : Verifier
    {
        private string date;
        private string comments;
        private string price;
        private int id;

        public PriceAll () { }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Price
        {
            get { return price = CheckIsNotNull( price ); }
            set { price = CheckIsNotNull( value ); }
        }
        public string Date
        {
            get { return CheckIsNotNull( date ); }
            set { date = CheckIsNotNull( value ); }
        }
        public string Comments
        {
            get { return CheckIsNotNull( comments ); }
            set { comments = CheckIsNotNull( value ); }
        }
    }
}
