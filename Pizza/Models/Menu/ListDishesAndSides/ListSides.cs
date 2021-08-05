using System.Collections.Generic;

using Pizza.Models.Menu.ListDishesAndSides;

namespace Pizza
{
    public class ListSides : ListName, IListGet<string>, IListSet<string>
    {
        private readonly List<string>  listSides = new List<string>();

        public void SetList ( List<string> listKey )
        {
            listSides.Clear();
            foreach (var k in listKey)
            {
                string side = Name.GetNameConfig(k);
                listSides.Add( side );
            }
        }

        public List<string> GetList ()
        {
            var list = listSides;
            return list;
        }

    }
}
