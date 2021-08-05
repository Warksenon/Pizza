using System;

using Microsoft.Win32;

namespace Pizza.Models.Registry
{
    internal class SaveRegistry : Registry, ISaveEmailData
    {
        public bool Save ( EmailData emailData )
        {
            this.emailData = emailData;
            return SaveEmailData();
        }

        public bool SaveEmailData ()
        {
            bool flag = false;
            RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
            try
            {
                key.CreateSubKey( subKey );
                key = key.OpenSubKey( subKey, true );

                if (IsValidEmail( emailData.Recipient ))
                {
                    if (DataSender( key ))
                    {
                        key.SetValue( Name.Recipient, emailData.Recipient );
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save( Convert.ToString( ex ), "SaveRegistry" );
            }
            key.Close();
            return flag;
        }

        private bool DataSender ( RegistryKey key )
        {
            bool flag = false;
            try
            {
                if (IsValidEmail( emailData.Sender ))
                {
                    key.SetValue( Name.Sender, emailData.Sender );
                    key.SetValue( Name.Password, emailData.Password );
                    key.SetValue( Name.Smtp, emailData.Smtp );

                    bool success = int.TryParse(emailData.Port, out int i);
                    if (success)
                    {
                        key.SetValue( Name.Port, emailData.Port );
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save( Convert.ToString( ex ), "DataSender" );
            }
            return flag;
        }

        private bool IsValidEmail ( string email )
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
