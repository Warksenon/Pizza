using System.Drawing;

namespace Pizza.View.FormHistry.ButtonFormHistory
{
    public class ButtonFormHistory
    {
        private readonly FormHistory  _form;

        public ButtonFormHistory ( FormHistory form )
        {
            _form = form;
        }

        public void AllButtonColorsControl ( string nameButton )
        {

            _form.ButtonLoadTxt.BackColor = SystemColors.Control;
            _form.ButtonLoadSql.BackColor = SystemColors.Control;
            _form.ButtonCopyTxt.BackColor = SystemColors.Control;
            _form.ButtonCopySql.BackColor = SystemColors.Control;

            switch (nameButton)
            {
                case "bText":
                _form.ButtonLoadTxt.BackColor = Color.LawnGreen;
                break;
                case "bSql":
                _form.ButtonLoadSql.BackColor = Color.LawnGreen;
                break;
                case "bTxtToSQL":
                _form.ButtonCopyTxt.BackColor = Color.LawnGreen;
                break;
                case "buttonSQLToTxt":
                _form.ButtonCopySql.BackColor = Color.LawnGreen;
                break;
            }

        }
    }
}
