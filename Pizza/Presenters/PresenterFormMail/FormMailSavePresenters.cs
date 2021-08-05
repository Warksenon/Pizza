using Pizza.Models.Registry;

namespace Pizza.Presenters
{
    public class FormMailSavePresenters
    {
        private readonly FormMail _form;
        public FormMailSavePresenters ( FormMail form )
        {
            _form = form;
        }

        public void SaveDataEmial ( ISaveEmailData saveEmail, IDialogService dialog )
        {
            EmailData emailData = new EmailData
            {
                Sender = _form.TextBoxSender.Text,
                Password = _form.TextBoxPassword.Text,
                Port = _form.TextBoxPort.Text,
                Smtp = _form.TextBoxSmtp.Text,
                Recipient = _form.TextBoxRecipient.Text
            };

            bool saveIsOk = saveEmail.Save(emailData);

            if (!saveIsOk)
            {
                dialog.ShowMessage( "Nieprawidłowe dane. Upewni się że wprowadzone dane: andresów e-mail, hasło, smtp, port są prawidłowe." );
            }

        }
    }
}
