using Microsoft.Win32;
using System;

namespace Pizza
{
    public class Registry
    {
        const string subKey = "Password99";
        Name name = new Name();

        public Registry()
        {
           ReadingRegistry();
        }

        private string sender;
        private string password;
        private string port;
        private string smtp;
        private string recipient;
        HelpFinding helpFinding = new HelpFinding();

        public string Sender
        {
            get
            {
                if (helpFinding.CheckStringIsEmpty(sender)) return "listorders39@gmail.com";
                else return sender;
            }
            set { sender = helpFinding.CheckIsNotNull(value);}
        }

        public string Password
        {
            get 
            { 
                if (helpFinding.CheckStringIsEmpty(password)) return "Testy2020!";
                else return password;
             }
            set { password = helpFinding.CheckIsNotNull(value);}
        }

        public string Port
        {
            get
            {
                if (helpFinding.CheckStringIsEmpty(port)) return "587";
                else return port;
            }
            set { port = helpFinding.CheckIsNotNull(value);}
        }

        public string Smtp
        {
            get
            {
                if (helpFinding.CheckStringIsEmpty(smtp)) return "smtp.gmail.com";
                else return smtp;
            }
            set { smtp = helpFinding.CheckIsNotNull(value);}
        }

        public string Recipient
        {
            get
            {
                if (helpFinding.CheckStringIsEmpty(recipient)) return "listorders39@gmail.com";
                else return recipient;
            }
            set { recipient = helpFinding.CheckIsNotNull(value);}
        }

       

        public void  ReadingRegistry()
        {
            try
            {
                RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subKey);
                sender = (string)key.GetValue(name.Sender);
                password = (string)key.GetValue(name.Password);
                port = (string)key.GetValue(name.Port);
                smtp = (string)key.GetValue(name.Smtp);
                recipient = (string)key.GetValue(name.Recipient);
                key.Close();
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save(Convert.ToString(ex), "ReadingRegistry");
            }
           
           
        }

        public bool SaveRegistry()
        {
            bool flag = false;
            RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
            try
            {
                key.CreateSubKey(subKey);
                key = key.OpenSubKey(subKey, true);

                if (IsValidEmail(Recipient))
                {
                    if (DataSender(key))
                    {
                        key.SetValue(name.Recipient, Recipient);
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save(Convert.ToString(ex), "SaveRegistry");
                return flag;
            }
            key.Close();
            return flag;
        }

        bool DataSender (RegistryKey key)
        {
            bool flag = false;
            try
            {
                if (IsValidEmail(Sender))
                {
                    key.SetValue(name.Sender, Sender);
                    key.SetValue(name.Password, Password);
                    key.SetValue(name.Smtp, Smtp);

                    int i;
                    bool success = Int32.TryParse(Port, out i);
                    if (success)
                    {
                        key.SetValue(name.Port, Port);
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save(Convert.ToString(ex), "DataSender");
                flag = false;
            }
            return flag;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
