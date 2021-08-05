using System.Windows.Forms;

namespace Pizza
{
    public interface IFormMail
    {

        TextBox TextBoxSender { get; set; }

        TextBox TextBoxRecipient { get; set; }

        TextBox TextBoxPassword { get; set; }

        TextBox TextBoxSmtp { get; set; }

        TextBox TextBoxPort { get; set; }
    }
}
