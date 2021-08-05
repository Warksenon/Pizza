namespace Pizza.Presenters.PresenterFormHistory.LoadHistory
{
    internal class FileTextLoad : ListViewHistory
    {
        public FileTextLoad( FormHistory form ) : base( form ) { }

        public override void LogicSettings()
        {
            LoadHistroyFromTxt();
        }

        private void LoadHistroyFromTxt()
        {
            ClearAllList();
            orderList = load.LoadOrderList( new LoadingFilesTxt() );
            LoadLVPriceAll();
        }
    }
}
