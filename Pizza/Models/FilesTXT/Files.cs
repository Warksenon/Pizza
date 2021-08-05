using System.Collections.Generic;

namespace Pizza.Models.FilesTXT
{
    internal abstract class Files
    {
        protected List<Order> listOrder = new List<Order>();
        protected const string path = @"c:\SQL\Konsola\sqlite";
        protected const string fileName = path+@"\Historia zamówień.txt";

        protected void CreateFolder ()
        {
            if (!System.IO.File.Exists( path ))
            {
                System.IO.Directory.CreateDirectory( path );
            }
            else
            {
                return;
            }
        }
    }
}
