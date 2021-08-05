using System.Windows.Forms;

namespace Pizza.View.FormHistry.ButtonFormMail
{
    public interface IButtonFormHistory
    {
        Button ButtonLoadTxt { get; set; }
        Button ButtonLoadSql { get; set; }
        Button ButtonCopyTxt { get; set; }
        Button ButtonCopySql { get; set; }
    }
}
