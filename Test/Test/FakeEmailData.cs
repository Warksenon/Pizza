using Pizza;

namespace Test.Test
{
    public class FakeEmailDat : IElementGet<EmailData>
    {
        public EmailData GetElement ()
        {
            var dataEmail =  new EmailData();
            dataEmail.Sender = "sss";
            dataEmail.Password = "ppp";
            dataEmail.Recipient = "rrr";
            dataEmail.Smtp = "smtp";
            dataEmail.Port = "port";

            return dataEmail;
        }
    }
}
