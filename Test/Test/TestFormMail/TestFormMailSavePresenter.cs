using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pizza;
using Pizza.Models.Registry;
using Pizza.Presenters;
using Pizza.Presenters.PresenterFormMail;

namespace Test.Test.TestFormMail
{
    [TestClass]
    public class TestFormMailSavePresenter
    {
        [TestMethod]
        public void SaveDataEmial_TestGetTestWithTextBox_ReturnString ()
        {
            var form = FormTest.CreateFormMail();
            var mailLoad = new FormMailLoad(form);
            mailLoad.SetTextForTextBox( new FakeEmailDat() );
            var mailSave = new FormMailSavePresenters(form);
            var save = new FakeSaveDataEmail();
            var dialog = new FakeDialog();
            mailSave.SaveDataEmial( save, dialog );

            var currentSender =  save.Sender;
            var currentPassword =  save.Password;
            var currentRecipient =  save.Recipient;
            var currentSmtp =  save.Smtp;
            var currentPort =  save.Port;

            Assert.AreEqual( "sss", currentSender );
            Assert.AreEqual( "ppp", currentPassword );
            Assert.AreEqual( "rrr", currentRecipient );
            Assert.AreEqual( "smtp", currentSmtp );
            Assert.AreEqual( "port", currentPort );
        }

        [TestMethod]
        public void SaveDataEmial_TestNotCorrectSaveEmailData_ReturnString ()
        {
            var form = FormTest.CreateFormMail();
            var mailLoad = new FormMailLoad(form);
            mailLoad.SetTextForTextBox( new FakeEmailDat() );
            var mailSave = new FormMailSavePresenters(form);
            var save = new FakeSaveDataEmail();
            save.Flag = false;
            var dialog = new FakeDialog();
            mailSave.SaveDataEmial( save, dialog );

            var expectationsDialog = "Nieprawidłowe dane. Upewni się że wprowadzone dane: andresów e-mail, hasło, smtp, port są prawidłowe.";
            var currentDialog =  dialog.Message;

            Assert.AreEqual( expectationsDialog, currentDialog );
        }
    }

    internal class FakeSaveDataEmail : ISaveEmailData
    {
        public bool Flag { get; set; }
        public string Sender;
        public string Password;
        public string Port;
        public string Smtp;
        public string Recipient;

        public FakeSaveDataEmail ()
        {
            Flag = true;
        }

        public bool Save ( EmailData emailData )
        {
            Sender = emailData.Sender;
            Password = emailData.Password;
            Recipient = emailData.Recipient;
            Smtp = emailData.Smtp;
            Port = emailData.Port;

            return Flag;
        }
    }
}
