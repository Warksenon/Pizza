using System.Windows.Forms;

namespace Pizza
{
    public interface IListViewHistory
    {
        ListView ListViewPrice { get; set; }
        ListView ListViewDishes { get; set; }
    }
}
