using System.Drawing;

namespace Pizza
{
    public class ButtonRemoveView
    {
        private readonly FormMenu _form;
        public ButtonRemoveView ( FormMenu form )
        {
            _form = form;
        }

        public void RemoveOne ()
        {
            if (CheckingListOrderIfEmpty())
            {
                RemoveAll();
            }
            else
            {
                _form.ButtonRemoveOne.Visible = false;
            }
        }

        public void RemoveAll ()
        {
            _form.ButtonSubmitOrder.BackColor = SystemColors.Control;
            _form.ButtonRemoveAll.Visible = false;
            _form.ButtonRemoveOne.Visible = false;
        }

        private bool CheckingListOrderIfEmpty ()
        {
            if (_form.ListViewOrder.Items.Count < 1)
                return true;
            else
                return false;
        }

    }
}
