using System;
using System.Windows.Forms;
using Pizza.Models.Registry;
using Pizza.Presenters;
using Pizza.Presenters.PresenterFormMail;

namespace Pizza
{
    public partial class FormMail : Form, IFormMail
    {
        public TextBox TextBoxSender { get => tSender; set => tSender = value; }
        public TextBox TextBoxRecipient { get => tRecipient; set => tRecipient = value; }
        public TextBox TextBoxPassword { get => tPassword; set => tPassword = value; }
        public TextBox TextBoxSmtp { get => tSmtp; set => tSmtp = value; }
        public TextBox TextBoxPort { get => tPort; set => tPort = value; }

        public FormMail ()
        {
            InitializeComponent();
        }

        private void FormMail_Load ( object sender, EventArgs e )
        {
            new FormMailLoad( this ).SetTextForTextBox( new LoadRegistry() );
        }

        private void ButtonSave_Click ( object sender, EventArgs e )
        {
            new FormMailSavePresenters( this ).SaveDataEmial( new SaveRegistry(), new DialogBox() );
        }

        private void ButtonClose_Click ( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}
