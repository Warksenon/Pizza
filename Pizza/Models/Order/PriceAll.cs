namespace Pizza
{
    public class PriceAll
    {        
        string date;
        string comments;       
        string price;
        int id;

        public PriceAll() { }

        public int ID 
        { 
            get { return id; }
            set { id = value; }
        }
        
        public string Price
        {
            get {return price = HelpFinding.CheckIsNotNull(price); }
            set { price = HelpFinding.CheckIsNotNull(value); }
        }
        public string Date
        {
            get { return HelpFinding.CheckIsNotNull(date); }
            set { date = HelpFinding.CheckIsNotNull(value); }
        }
        public string Comments
        {
            get { return HelpFinding.CheckIsNotNull(comments); }
            set { comments = HelpFinding.CheckIsNotNull(value);  }
        }
        
    }
}
