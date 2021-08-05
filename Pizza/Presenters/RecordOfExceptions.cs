using System;
using System.IO;

namespace Pizza
{
    public class RecordOfExceptions
    {
        public static void Save ( string e, string name )
        {
            string dateWithTime = DateTime.Now.ToString();
            string olnyDate = DateTime.Now.ToString("yyyy-MM-dd");
            string filetxt = @"\Record Of Exceptions.txt";
            string _path = @"ErrorLog\" + olnyDate;
            Directory.CreateDirectory( _path );

            try
            {
                using (StreamWriter streamW = new StreamWriter( (_path + filetxt), true ))
                {
                    string date = "Data : " + dateWithTime;
                    streamW.WriteLine( date );
                    streamW.WriteLine( name );
                    streamW.WriteLine( e );
                    streamW.WriteLine( "" );
                    streamW.Flush();
                }
            }
            catch
            {

            }
        }
    }
}
