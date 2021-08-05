using Pizza.Models.SqlLite;
using Pizza.Presenters.PresenterFormHistory.CopyHistory;
using Pizza.Presenters.PresenterFormHistory.LoadHistory;

namespace Pizza.Presenters.PresenterFormHistory.Copy
{
    internal class SqlCopy : CopyHistoryOrder
    {
        public SqlCopy( FormHistory form ) : base( form ) { }

        public override void LogicSettings()
        {
            CopyDataFromSQL();
            new SqlLoad( form ).LogicSettings();
        }

        public void CopyDataFromSQL()
        {
            copyListOrder = load.LoadOrderList( new LoadHistorySQL() );
            save.SaveList( new SaveFilesHistoryOrder( copyListOrder ) );
        }
    }
}
