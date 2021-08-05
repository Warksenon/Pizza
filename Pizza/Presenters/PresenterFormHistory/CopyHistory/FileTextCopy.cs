using Pizza.Models.SqlLite;
using Pizza.Presenters.PresenterFormHistory.CopyHistory;
using Pizza.Presenters.PresenterFormHistory.LoadHistory;

namespace Pizza.Presenters.PresenterFormHistory
{
    internal class FileTextCopy : CopyHistoryOrder
    {
        public FileTextCopy( FormHistory form ) : base( form ) { }

        public override void LogicSettings()
        {
            CopyDataFromFilesTxt();
            new FileTextLoad( form ).LogicSettings();
        }

        public void CopyDataFromFilesTxt()
        {
            copyListOrder = load.LoadOrderList( new LoadingFilesTxt() );
            save.SaveList( new SaveHistorySQL( copyListOrder ) );
        }
    }
}
