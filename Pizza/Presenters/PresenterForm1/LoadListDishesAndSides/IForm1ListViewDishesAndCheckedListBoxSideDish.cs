using System.Windows.Forms;

namespace Pizza
{
    public interface IForm1ListViewDishesAndCheckedListBoxSideDish
    {
        ListView ListViewDishes { get; set; }
        CheckedListBox CheckedListBoxSideDish { get; set; }
    }
}
