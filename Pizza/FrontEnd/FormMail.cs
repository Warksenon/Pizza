using System;
using System.Windows.Forms;

namespace Pizza
{
    public partial class FormMail : Form
    {

        private Email email = new Email();
       
        public FormMail(Form1 form1)
        {
            InitializeComponent();          
        }

        private void FormMail_Load(object sender, EventArgs e)
        {
            SetTextView();
        }

        private void SetTextView()
        {
            Registry registry = new Registry();
            tSender.Text = registry.Sender;
            tPassword.Text = registry.Password;
            tPort.Text = registry.Port;
            tSmtp.Text = registry.Smtp;
            tRecipient.Text = registry.Recipient;
        }

        bool  SaveDataEmial()
        {
            Registry registry = new Registry();
            bool falg = true;
            registry.Sender = tSender.Text;
            registry.Password = tPassword.Text;
            registry.Port = tPort.Text;
            registry.Smtp = tSmtp.Text;
            registry.Recipient = tRecipient.Text;

            if (!registry.SaveRegistry())
            {
                falg = false;
                MessageBox.Show("Nieprawidłowe dane. Upewni się że wprowadzone dane: andresów e-mail, hasło, smtp, port są prawidłowe ", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return falg;
        }


        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (SaveDataEmial())
            {
                this.Close();
            }            
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
