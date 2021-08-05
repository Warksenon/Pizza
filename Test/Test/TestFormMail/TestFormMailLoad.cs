using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;
using Pizza.Presenters.PresenterFormMail;

namespace Test.Test.TestFormMail
{
    [TestClass]
    public class TestFormMailLoad
    {
        [TestMethod]
        public void SetTextForTextBox_CheckSetTextDefaultEmailData_ReturnStringWithTextBox ()
        {
            var form = FormTest.CreateFormMail();
            var mailLoad = new FormMailLoad(form);
            mailLoad.SetTextForTextBox( new FakeEmailDataDefault() );

            var currentSender =  form.TextBoxSender.Text;
            var currentPassword =  form.TextBoxPassword.Text;
            var currentRecipient =  form.TextBoxRecipient.Text;
            var currentSmtp =  form.TextBoxSmtp.Text;
            var currentPort =  form.TextBoxPort.Text;

            Assert.AreEqual( "listorders39@gmail.com", currentSender );
            Assert.AreEqual( "Testy2020!", currentPassword );
            Assert.AreEqual( "listorders39@gmail.com", currentRecipient );
            Assert.AreEqual( "smtp.gmail.com", currentSmtp );
            Assert.AreEqual( "587", currentPort );
        }

        [TestMethod]
        public void SetTextForTextBox_CheckSetText_ReturnStringWithTextBox ()
        {
            var form = FormTest.CreateFormMail();
            var mailLoad = new FormMailLoad(form);
            mailLoad.SetTextForTextBox( new FakeEmailDat() );

            var currentSender =  form.TextBoxSender.Text;
            var currentPassword =  form.TextBoxPassword.Text;
            var currentRecipient =  form.TextBoxRecipient.Text;
            var currentSmtp =  form.TextBoxSmtp.Text;
            var currentPort =  form.TextBoxPort.Text;

            Assert.AreEqual( "sss", currentSender );
            Assert.AreEqual( "ppp", currentPassword );
            Assert.AreEqual( "rrr", currentRecipient );
            Assert.AreEqual( "smtp", currentSmtp );
            Assert.AreEqual( "port", currentPort );
        }
    }

    internal class FakeEmailDataDefault : IElementGet<EmailData>
    {
        public EmailData GetElement ()
        {
            return new EmailData();
        }
    }


}
