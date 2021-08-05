namespace Pizza
{
    public class EmailData
    {
        private string sender;
        private string password;
        private string port;
        private string smtp;
        private string recipient;

        public string Sender
        {
            get
            {
                if (HelpFinding.CheckStringIsEmpty( sender ))
                    return "listorders39@gmail.com";
                else
                    return sender;
            }
            set
            {
                if (HelpFinding.CheckStringIsNotEmpty( value ))
                    sender = value;
            }
        }

        public string Password
        {
            get
            {
                if (HelpFinding.CheckStringIsEmpty( password ))
                    return "Testy2020!";
                else
                    return password;
            }
            set
            {
                if (HelpFinding.CheckStringIsNotEmpty( value ))
                    password = value;
            }
        }

        public string Port
        {
            get
            {
                if (HelpFinding.CheckStringIsEmpty( port ))
                    return "587";
                else
                    return port;
            }
            set
            {
                if (HelpFinding.CheckStringIsNotEmpty( value ))
                    port = value;
            }
        }

        public string Smtp
        {
            get
            {
                if (HelpFinding.CheckStringIsEmpty( smtp ))
                    return "smtp.gmail.com";
                else
                    return smtp;
            }
            set
            {
                if (HelpFinding.CheckStringIsNotEmpty( value ))
                    smtp = value;
            }
        }

        public string Recipient
        {
            get
            {
                if (HelpFinding.CheckStringIsEmpty( recipient ))
                    return "listorders39@gmail.com";
                else
                    return recipient;
            }
            set
            {
                if (HelpFinding.CheckStringIsNotEmpty( value ))
                    recipient = value;
            }
        }
    }
}
