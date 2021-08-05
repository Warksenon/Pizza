namespace Pizza
{
    public class ListViewDishes
    {
        private readonly FormMenu _form;

        public ListViewDishes ( FormMenu form )
        {
            _form = form;
        }

        public void ViewSetting ()
        {
            SetVisibleButtonDishesOK();
            SetVisibleTextViewDishesQuantity();
        }

        private void SetVisibleButtonDishesOK ()
        {
            _form.AddButton.Visible = true;
        }

        private void SetVisibleTextViewDishesQuantity ()
        {
            _form.QTextbox.Visible = true;
        }
    }
}
