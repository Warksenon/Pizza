using Pizza.View.Form1View.ViewSettings.ButtonMenu;
using System.Drawing;

namespace Pizza
{
    public class ButtonSoupsView : ButtonMenu
    {
        public ButtonSoupsView(FormMenu form) : base(form) { }

        public override void ViewSetting()
        {
            ClearColorButton();
            SoupsButtonSettings();
        }

        private void SoupsButtonSettings()
        {
            ButtonSeting();
            ChengeNameLabelMenuInfo("Zupy");
            form.SoupButton.BackColor = Color.LawnGreen;
        }
    }
}
