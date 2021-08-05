using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pizza.Presenters.PresenterFormHistory;

namespace Test.Test.TestFormHistory
{
    [TestClass]
    public class TestHistoryPriceListView
    {
        [TestMethod]
        public void SetList_SetOrderList_ReturnString ()
        {
            var form = FormTest.CreateFormHistory();
            var listView = new HistoryPriceListView(form);
            listView.SetList( new FakeListOrder() );

            var currentId = form.ListViewPrice.Items[0].SubItems[0].Text;
            var currentDate  = form.ListViewPrice.Items[0].SubItems[1].Text;
            var currentPrice =  form.ListViewPrice.Items[0].SubItems[2].Text;
            var currentComments =  form.ListViewPrice.Items[0].SubItems[3].Text;

            Assert.AreEqual( "5", currentId );
            Assert.AreEqual( "2020.12.02", currentDate );
            Assert.AreEqual( "50zł", currentPrice );
            Assert.AreEqual( "Hmmm....", currentComments );
        }
    }
}
