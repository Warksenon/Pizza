using Pizza.Presenters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pizza
{
    public partial class FormHistory : Form , IFormHistory
    {

        FormHistoryPresenters presenters;
        public FormHistory()
        {
            InitializeComponent();         
        }
   
        public ListView ListViewPrice { get => LVprice; set => LVprice = value; }
        public ListView ListViewDishes { get => LVdishes; set => LVdishes = value; }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            presenters = new FormHistoryPresenters(this);
            presenters.LoadHistoryFromSQL();
            ButtonColorChange(Button.HistSQL);
        }

        public enum Button
        {
            HistSQL,
            HistTXT,
            SqlToTxt,
            TxtToSql
        }

        private void ButtonColorChange(Button p)
        {
            AllButtonSetSystemColorsControl();

            switch (p)
            {
                case Button.HistSQL: bSql.BackColor = Color.LawnGreen; break;
                case Button.HistTXT: bText.BackColor = Color.LawnGreen; break;
                case Button.SqlToTxt: buttonSQLToTxt.BackColor = Color.Firebrick; break;
                case Button.TxtToSql: bTxtToSQL.BackColor = Color.Firebrick; break;
            }

        }

        private void AllButtonSetSystemColorsControl()
        {
            bSql.BackColor = SystemColors.Control;
            bText.BackColor = SystemColors.Control;
            buttonSQLToTxt.BackColor = SystemColors.Control;
            bTxtToSQL.BackColor = SystemColors.Control;
        }

        private void ButtonTextList_Click(object sender, EventArgs e)
        {
            presenters.LoadHistroyFromTxt();
            ButtonColorChange(Button.HistTXT);
        }

        private void ButtonSqlList_Click(object sender, EventArgs e)
        {
            presenters.LoadHistoryFromSQL();
            ButtonColorChange(Button.HistSQL);
        }

        private void ButtonTxtToSql(object sender, EventArgs e)
        {
            presenters.CopyDataFromFilesTxt();
            ButtonColorChange(Button.TxtToSql);
            presenters.LoadHistroyFromTxt();
            ButtonColorChange(Button.HistTXT);
        }

        private void ButtonSQLToTxt_Click(object sender, EventArgs e)
        {
            presenters.CopyDataFromSQL();
            ButtonColorChange(Button.SqlToTxt);
            presenters.LoadHistoryFromSQL();
            ButtonColorChange(Button.HistSQL);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LVprice_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenters.LoadLVDishes();
        }
    }

}
