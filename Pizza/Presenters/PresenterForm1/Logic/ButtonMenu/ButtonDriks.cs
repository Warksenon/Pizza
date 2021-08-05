using Pizza.Presenters.PresenterForm1.Logic.ButtonMenu;

namespace Pizza.Presenters.PresenterForm1.Logic
{
    class ButtonDriksLogic : MenuButton
    {        
        public ButtonDriksLogic(FormMenu form1):base(form1){}

        public override void LogicSettings()
        {
            loadDishesToListView.LoadDrinks();
            loadSidesToCheckedListBox.ClearCheckedListBox();
        }
    }
}
