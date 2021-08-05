using System;

using Microsoft.Win32;

namespace Pizza.Models.Registry
{
    internal class LoadRegistry : Registry, IElementGet<EmailData>
    {
        public EmailData GetElement ()
        {
            return ReadingRegistry();
        }

        private EmailData ReadingRegistry ()
        {
            try
            {
                RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subKey);
                emailData.Sender = ( string )key.GetValue( Name.Sender );
                emailData.Password = ( string )key.GetValue( Name.Password );
                emailData.Port = ( string )key.GetValue( Name.Port );
                emailData.Smtp = ( string )key.GetValue( Name.Smtp );
                emailData.Recipient = ( string )key.GetValue( Name.Recipient );
                key.Close();
            }
            catch (Exception ex)
            {
                RecordOfExceptions.Save( Convert.ToString( ex ), "LoadRegistry" );
            }

            return emailData;
        }
    }
}
