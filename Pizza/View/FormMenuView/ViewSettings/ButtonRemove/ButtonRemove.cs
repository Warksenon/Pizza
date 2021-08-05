﻿using Pizza.View.Form1View;
using System.Drawing;

namespace Pizza
{
    public abstract class ButtonRemove : ViewFormMenu, IView
    {
        protected ButtonRemove(FormMenu form) : base(form) { }

        public abstract void ViewSetting();

        protected void RemoveAll()
        {
            form.ButtonSubmitOrder.BackColor = SystemColors.Control;
            form.ButtonRemoveAll.Visible = false;
            form.ButtonRemoveOne.Visible = false;
        }
    }
}
