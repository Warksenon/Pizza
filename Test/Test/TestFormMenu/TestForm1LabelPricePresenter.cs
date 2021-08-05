using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pizza;
using Pizza.Presenters.PresenterFormMenu;

namespace Test.Test.TestFormMenu
{
    [TestClass]
    public class TestForm1LabelPricePresenter
    {
        [TestMethod]
        public void SetTextLabelPrice_SetrPrice_ReturnPriceInLabelText ()
        {
            var form = FormTest.CreateFormMenu();
            var labelPrice = new Form1LabelPricePresenter(form);
            labelPrice.SetTextLabelPrice( new FakeCalculationPrice() );

            var currentText = form.LabelPrice.Text;

            Assert.AreEqual( "Cena: 200,50 zł", currentText );
        }
    }

    internal class FakeCalculationPrice : IPrice
    {
        public double FindPriceAndConvertToDoubel ( string dish )
        {
            return 0;
        }

        public double GetPricaAll ()
        {
            return 200.50;
        }
    }
}
