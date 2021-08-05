using System.Windows.Forms;

namespace Pizza
{
    public interface IForm1ButtonMenu
    {
        Button PizzzaButton { get; set; }
        Button MainButton { get; set; }
        Button SoupButton { get; set; }
        Button DrinksButton { get; set; }
    }
}
