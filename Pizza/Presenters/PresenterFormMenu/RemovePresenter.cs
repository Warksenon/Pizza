namespace Pizza
{
    public class RemovePresenter
    {
        private readonly FormMenu _form;

        public RemovePresenter ( FormMenu form )
        {
            _form = form;
        }

        public void RemoveOne ()
        {
            _form.ListViewOrder.SelectedItems [0].Remove();
        }

        public void RemoveAll ()
        {
            _form.ListViewOrder.Items.Clear();
        }

    }
}
