using System.Drawing;

namespace Pizza.View.Form1View.ViewSettings.ButtonMenu
{
    public abstract class ButtonMenu : ViewFormMenu, IView
    {

        public ButtonMenu(FormMenu form1) : base(form1) { }

        protected void ButtonSeting()
        {
            ClearColorButton();
            HidenButtonDishesOK();
            HidingTextBoxDishesQuantity();
            CleaningTextBoxDishesQuantity();
        }

        protected void ClearColorButton()
        {
            form.PizzzaButton.BackColor = SystemColors.Control;
            form.MainButton.BackColor = SystemColors.Control;
            form.SoupButton.BackColor = SystemColors.Control;
            form.DrinksButton.BackColor = SystemColors.Control;
        }

        protected void HidenButtonDishesOK()
        {
            form.AddButton.Visible = false;
        }

        protected void HidingTextBoxDishesQuantity()
        {
            form.QTextbox.Visible = false;
        }

        protected void CleaningTextBoxDishesQuantity()
        {
            form.QTextbox.Text = "1";
        }

        protected void ChengeNameLabelMenuInfo(string infoMenu)
        {
            form.LabelMenu.Text = infoMenu;
        }

        public abstract void ViewSetting();

    }
}