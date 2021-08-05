using Pizza.Models.OrderComposition;

namespace Pizza
{
    public class Dish : Verifier
    {
        private string name;
        private string price;
        private string sides;
        private readonly int id;

        public Dish () { }

        public Dish ( int id )
        {
            this.id = id;
        }

        public string Name
        {
            get { return CheckIsNotNull( name ); }
            set { name = CheckIsNotNull( value ); }
        }

        public string Price
        {
            get { return CheckIsNotNull( price ); }
            set { price = CheckIsNotNull( value ); }
        }

        public string Sides
        {
            get { return CheckIsNotNull( sides ); }
            set { sides = CheckIsNotNull( value ); }
        }

        public int Id
        {
            get { return id; }
        }
    }
}


