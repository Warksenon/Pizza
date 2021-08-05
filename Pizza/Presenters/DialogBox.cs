using System.Windows.Forms;

namespace Pizza
{
    public class DialogBox : IDialogService
    {
        public void ShowMessage ( string message )
        {
            MessageBox.Show( message );
        }
    }
}
