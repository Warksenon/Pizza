using System;
using System.Net;
using System.Net.Mail;

namespace Pizza.Presenters.Email
{
    public class EmailSend : ISendOrder
    {
        IElementGet<EmailData> _loadEmail;
        public EmailSend ( IElementGet<EmailData> loadEmail )
        {
            _loadEmail = loadEmail;
        }

        public bool SendMessag ( IElementGet<Order> element )
        {
            var order = element.GetElement();
            var emailMessage = new EmailMessage(order);
            var message = emailMessage.WriteBill();
            return SendEmail( message );
        }

        private bool SendEmail ( string message )
        {
            bool flag = false;

            EmailData registry = _loadEmail.GetElement();
            using (MailMessage send = new MailMessage())
            {
                using (SmtpClient client = new SmtpClient())
                {
                    try
                    {
                        client.Credentials = new NetworkCredential( registry.Sender, registry.Password );
                        client.Host = registry.Smtp;
                        client.Port = Convert.ToInt32( registry.Port );
                        client.EnableSsl = true;
                        try
                        {
                            send.From = new MailAddress( registry.Sender );
                            send.Subject = "Zamówienie Pizza";
                            send.Body = message;
                            send.To.Add( registry.Recipient );
                        }
                        catch (Exception ex)
                        {
                            RecordOfExceptions.Save( Convert.ToString( ex ), "SendEmail" );
                        }
                        client.Send( send );
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        RecordOfExceptions.Save( Convert.ToString( ex ), "SendEmail" );
                    }
                }
            }

            return flag;
        }

    }
}
