using Pizza;

namespace Test.Test
{
    public class FakeEmailDat : IElementGet<EmailData>
    {
        public EmailData GetElement ()
        {
            var dataEmail = new EmailData
            {
                Sender = "sss",
                Password = "ppp",
                Recipient = "rrr",
                Smtp = "smtp",
                Port = "port"
            };

            return dataEmail;
        }
    }
}
