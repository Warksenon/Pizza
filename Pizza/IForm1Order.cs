using System.ComponentModel;
using System.Windows.Forms;

namespace Pizza
{
    public interface IForm1Order
    {
        TextBox TextBoxQuantityDishes { get; set; }

        ListView ListViewOrder { get; set; }

        Label LabelPrice { get; set; }

        BackgroundWorker BackgroundWorker { get; set;}

        TextBox TextBoxComments { get; set; }
    }
}
