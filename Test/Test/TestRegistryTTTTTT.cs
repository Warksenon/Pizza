using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;

namespace Test
{
    [TestClass]
    public class TestRegistryTTTTTT
    {
        IAction eevent = new Aktion();
        FormMail form = new FormMail();
        

        [TestMethod]
        public void TestMethod1()
        {
            eevent.SetLogic(new FormMailLoad(form));
            Assert.AreEqual("listorders39@gmail.com", form.TextBoxSender.Text);
            Assert.AreEqual("listorders39@gmail.com", form.TextBoxRecipient.Text);
            Assert.AreEqual("Testy2020!", form.TextBoxPassword.Text);
            Assert.AreEqual("smtp.gmail.com", form.TextBoxSmtp.Text);
            Assert.AreEqual("587", form.TextBoxPort.Text);            
        }
    }
}
