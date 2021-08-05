namespace Pizza
{
    public class Dish
    {
        private string name;
        private string price;
        private string sides;
        private int id;

        public Dish(){}

        public Dish(int id)
        {
            this.id = id;
        }

        public string Name
        {
            get { return HelpFinding.CheckIsNotNull(name); }
            set { name = HelpFinding.CheckIsNotNull(value); }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Sides
        {
            get { return sides; }
            set { sides = value; }
        }

        public int Id
        {
            get { return id; }          
        }
    }
}


