namespace Pizza
{
    public class ButtonRemoveAll : ButtonRemove
    {
        public ButtonRemoveAll(FormMenu form1) : base(form1) { }

        public override void ViewSetting()
        {
            RemoveAll();
        }
    }
}
