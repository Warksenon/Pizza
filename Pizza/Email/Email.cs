using System;
using System.Net;
using System.Net.Mail;

namespace Pizza
{
    public class Email
    {
       
        string message;
        HelpFinding helpFinding = new HelpFinding();

        public string Message
        {

            get
            {
                return helpFinding.CheckIsNotNull(message);
            }
            set
            {
                message = helpFinding.CheckIsNotNull(value);
            }
        }

        public bool SendEmail(string str)
        {
            bool flag = true;

            Registry registry = new Registry();

            Message = str;
            MailMessage send = new MailMessage();

            SmtpClient client = new SmtpClient();
            try
            {
                client.Credentials = new NetworkCredential(registry.Sender, registry.Password);
                client.Host = registry.Smtp;
                client.Port = Convert.ToInt32(registry.Port);
                client.EnableSsl = true;
                try
                {
                    send.From = new MailAddress(registry.Sender);
                    send.Subject = "Zamówienie Pizza";
                    send.Body = message;
                    send.To.Add(registry.Recipient);
                }
                catch (Exception ex)
                {
                    RecordOfExceptions.Save(Convert.ToString(ex), "SendEmail");
                    flag = false;
                }
                client.Send(send);

            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save(Convert.ToString(ex), "SendEmail");
                flag = false;
            }
            return flag;

        }

    }
}
