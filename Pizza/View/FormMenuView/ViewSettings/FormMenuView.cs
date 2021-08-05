using Pizza.View.Form1View.ViewSettings.ButtonMenu;

namespace Pizza.View.FormMenuView.ViewSettings
{
    internal class FormMenuView
    {
        private readonly FormMenu _form;

        public FormMenuView ( FormMenu form )
        {
            _form = form;
        }

        public void ViewSetting ()
        {
            new ButtonMenuView( _form ).PizzaButtonSettings();
            new ButtonRemoveView( _form ).RemoveAll();
        }
    }
}
