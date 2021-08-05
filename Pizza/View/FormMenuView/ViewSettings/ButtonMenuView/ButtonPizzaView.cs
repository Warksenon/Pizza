using System.Drawing;

using Pizza.View.Form1View.ViewSettings.ButtonMenu;

namespace Pizza.Presenters.PresenterFormMenu.VisableElements.Button
{
    public class ButtonPizzaView : ButtonMenuView
    {
        public ButtonPizzaView( FormMenu form1 ) : base( form1 ) { }

        public override void ViewSetting()
        {
            ClearColorButton();
            PizzaButtonSettings();
        }

        private void PizzaButtonSettings()
        {
            ChengeNameLabelMenuInfo( "Pizza" );
            ButtonSeting();
            form.PizzzaButton.BackColor = Color.LawnGreen;
        }
    }
}
