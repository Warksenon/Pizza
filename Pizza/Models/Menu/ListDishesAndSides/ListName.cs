namespace Pizza.Models.Menu.ListDishesAndSides
{
    public abstract class ListName
    {
        protected string FindName ( string nameAndPrice )
        {
            int index = nameAndPrice.IndexOf("-") - 1;
            if (index == -1)
            {
                return "";
            }
            else
            {
                string sdish = nameAndPrice.Substring(0, index);
                return sdish;
            }
        }
    }
}
