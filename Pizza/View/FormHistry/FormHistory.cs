using System;
using System.Windows.Forms;

using Pizza.Models.SqlLite;
using Pizza.Presenters.PresenterFormHistory;
using Pizza.Presenters.PresenterFormHistory.CopyHistory;
using Pizza.View.FormHistry.ButtonFormHistory;
using Pizza.View.FormHistry.ButtonFormMail;

namespace Pizza
{
    public partial class FormHistory : Form, IListViewHistory, IButtonFormHistory
    {
        HistoryPriceListView _priceLV;
        ButtonFormHistory _button;
        public FormHistory ()
        {
            InitializeComponent();
        }

        public ListView ListViewPrice { get => LVprice; set => LVprice = value; }
        public ListView ListViewDishes { get => LVdishes; set => LVdishes = value; }
        public Button ButtonLoadTxt { get => bText; set => bText = value; }
        public Button ButtonLoadSql { get => bSql; set => bSql = value; }
        public Button ButtonCopyTxt { get => bTxtToSQL; set => bTxtToSQL = value; }
        public Button ButtonCopySql { get => buttonSQLToTxt; set => buttonSQLToTxt = value; }

        private void FormHistory_Load ( object sender, EventArgs e )
        {
            _priceLV = new HistoryPriceListView( this );
            _priceLV.SetList( new LoadHistorySQL() );
            _button = new ButtonFormHistory( this );
            _button.AllButtonColorsControl( bSql.Name );
        }

        private void ButtonTextList_Click ( object sender, EventArgs e )
        {
            _priceLV.SetList( new LoadingFilesTxt() );
            _button.AllButtonColorsControl( bText.Name );
        }

        private void ButtonSqlList_Click ( object sender, EventArgs e )
        {
            _priceLV.SetList( new LoadHistorySQL() );
            _button.AllButtonColorsControl( bSql.Name );
        }

        private void ButtonTxtToSql ( object sender, EventArgs e )
        {
            _button.AllButtonColorsControl( bTxtToSQL.Name );
            var load = new LoadingFilesTxt();
            var save =  new SaveHistorySQL();
            HistoryCopy.CopyHistory( load, save );
            _priceLV.SetList( new LoadingFilesTxt() );
            _button.AllButtonColorsControl( bText.Name );
        }

        private void ButtonSQLToTxt_Click ( object sender, EventArgs e )
        {
            _button.AllButtonColorsControl( buttonSQLToTxt.Name );
            var load = new LoadHistorySQL();
            var save =  new SaveFilesHistoryOrder();
            HistoryCopy.CopyHistory( load, save );
            _priceLV.SetList( new LoadingFilesTxt() );
            _button.AllButtonColorsControl( bSql.Name );
        }

        private void ButtonClose_Click ( object sender, EventArgs e )
        {
            this.Close();
        }

        private void LVprice_SelectedIndexChanged ( object sender, EventArgs e )
        {
            new HistoryDishesListView( this ).SetList( _priceLV );
        }

    }
}
