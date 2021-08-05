using System.Windows.Forms;

namespace Pizza
{
    public interface IFormHistory
    {
        ListView ListViewPrice { get; set; }

        ListView ListViewDishes { get; set; }
      
    }
}
