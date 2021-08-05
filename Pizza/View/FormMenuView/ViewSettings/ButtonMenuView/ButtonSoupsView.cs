using System.Drawing;

using Pizza.View.Form1View.ViewSettings.ButtonMenu;

namespace Pizza
{
    public class ButtonSoupsView : ButtonMenuView
    {
        public ButtonSoupsView( FormMenu form ) : base( form ) { }

        public override void ViewSetting()
        {
            ClearColorButton();
            SoupsButtonSettings();
        }

        private void SoupsButtonSettings()
        {
            ButtonSeting();
            ChengeNameLabelMenuInfo( "Zupy" );
            form.SoupButton.BackColor = Color.LawnGreen;
        }
    }
}
