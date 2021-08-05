using System.Collections.Generic;

namespace Pizza.Presenters.PresenterFormMenu
{
    public class SidesCheckListBox : IListSet<string>, IListGet<string>
    {
        private readonly FormMenu _form;

        public SidesCheckListBox ( FormMenu form )
        {
            _form = form;
        }

        public List<string> GetList ()
        {
            return GetListCheckedSides();
        }

        private List<string> GetListCheckedSides ()
        {
            List<string> list = new List<string>();

            foreach (object item in _form.CheckedListBoxSide.CheckedItems)
            {
                string side = item.ToString();
                list.Add( side );
            }

            return list;
        }

        public void SetList ( List<string> elements )
        {
            LoadCheckListBoxSideDishe( elements );
        }

        private void LoadCheckListBoxSideDishe ( List<string> listSides )
        {
            ClearCheckedListBox();

            foreach (var side in listSides)
            {
                _form.CheckedListBoxSide.Items.Add( side );
            }
        }

        private void ClearCheckedListBox ()
        {
            _form.CheckedListBoxSide.Items.Clear();
        }


    }
}
