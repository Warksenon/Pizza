using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Presenters.PresenterForm1
{
    abstract class RemoveOrder : ILogic
    {
        protected IForm1ListViewOrder lvOrder;
        public RemoveOrder(FormMenu form1)
        {
            lvOrder = form1;
        }

        public abstract void LogicSettings();
    }
}
