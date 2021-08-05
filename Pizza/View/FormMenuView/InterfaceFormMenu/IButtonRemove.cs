using System.Windows.Forms;

namespace Pizza.View.Form1
{
    public interface IButtonRemove
    {
        Button ButtonRemoveOne { get; set; }
        Button ButtonRemoveAll { get; set; }
    }
}
