namespace Pizza.Presenters.PresenterFormMail
{
    public class FormMailLoad
    {
        private readonly FormMail _form;
        public FormMailLoad ( FormMail form )
        {
            _form = form;
        }

        public void SetTextForTextBox ( IElementGet<EmailData> loadEmailData )
        {
            EmailData emailData = loadEmailData.GetElement();
            _form.TextBoxSender.Text = emailData.Sender;
            _form.TextBoxPassword.Text = emailData.Password;
            _form.TextBoxPort.Text = emailData.Port;
            _form.TextBoxSmtp.Text = emailData.Smtp;
            _form.TextBoxRecipient.Text = emailData.Recipient;
        }
    }
}
