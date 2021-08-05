using Pizza.Presenters;
using Pizza.Presenters.PresenterFormMail;
using System;
using System.Windows.Forms;

namespace Pizza
{
    public partial class FormMail : Form , IFormMail
    {
        IOnEvent eevent = new OnEvent();

        public TextBox TextBoxSender { get => tSender; set => tSender = value; }
        public TextBox TextBoxRecipient { get => tRecipient; set => tRecipient = value; }
        public TextBox TextBoxPassword { get => tPassword; set => tPassword = value; }
        public TextBox TextBoxSmtp { get => tSmtp; set => tSmtp = value; }
        public TextBox TextBoxPort { get => tPort; set => tPort = value; }

        public FormMail()
        {            
            InitializeComponent();          
        }

        private void FormMail_Load(object sender, EventArgs e)
        {
            eevent.SetLogic(new FormMailLoad(this));
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            eevent.SetLogic(new FormMailSavePresenters(this));                
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
