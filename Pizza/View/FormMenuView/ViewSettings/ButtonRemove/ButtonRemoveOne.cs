namespace Pizza
{
    public class ButtonRemoveOne : ButtonRemove
    {
        public ButtonRemoveOne(FormMenu form) : base(form) { }

        public override void ViewSetting()
        {
            SetSettingsButton();
        }

        private void SetSettingsButton()
        {
            if (CheckingListOrderIfEmpty())
            {
                RemoveAll();
            }
            else
            {
                form.ButtonRemoveOne.Visible = false;
            }
        }

        private bool CheckingListOrderIfEmpty()
        {
            if (form.ListViewOrder.Items.Count < 1)
                return true;
            else
                return false;
        }
    }
}
