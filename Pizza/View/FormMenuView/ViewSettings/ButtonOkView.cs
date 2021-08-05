using System.Drawing;

using Pizza.Presenters;

namespace Pizza
{
    public class ButtonOkView
    {
        private readonly FormMenu _form;

        public ButtonOkView ( FormMenu form )
        {
            _form = form;
        }

        public void ViewSetting ()
        {
            string text = _form.QTextbox.Text;
            int number = HelperConvert.ConvertTextToInt(text);

            if (number > 0)
            {
                _form.ButtonSubmitOrder.BackColor = Color.LawnGreen;
                _form.ButtonRemoveAll.Visible = true;
            }
            else
            {
                _form.ButtonRemoveAll.Visible = false;
            }

            _form.ButtonRemoveOne.Visible = false;
        }
    }
}
