using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    interface IListSides
    {
        void AddSideToList(List<String> listSides, string sideText);     
    }
}
