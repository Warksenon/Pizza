using Pizza.Models.SqlLite;

namespace Pizza.Presenters.PresenterFormHistory.LoadHistory
{
    internal class SqlLoad : ListViewHistory
    {
        public SqlLoad( FormHistory form ) : base( form ) { }

        public override void LogicSettings()
        {
            LoadHistoryFromSQL();
        }

        private void LoadHistoryFromSQL()
        {
            ClearAllList();
            orderList = load.LoadOrderList( new LoadHistorySQL() );
            LoadLVPriceAll();
        }
    }
}
