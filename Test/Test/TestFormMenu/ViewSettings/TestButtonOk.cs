using Pizza;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Test.Form1.ViewSettings
{
    [TestClass]
    public class TestButtonOk : Form1Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            Button buttonRemoveOne = new Button();
            Button buttonRemoveAll = new Button();

            form.QTextbox.Text = "0";
            buttonRemoveOne.Visible = false;
            buttonRemoveAll.Visible = false;
            eevent.SetView(new ButtonOkView(form));

            Assert.AreEqual(buttonRemoveOne.Visible, form.ButtonRemoveOne.Visible);
            Assert.AreEqual(buttonRemoveAll.Visible, form.ButtonRemoveAll.Visible);
        }


        [TestMethod]
        public void TestMethod2()
        {
            Button buttonRemoveOne = new Button();
            Button buttonRemoveAll = new Button();

            buttonRemoveOne.Visible = false;
            buttonRemoveAll.Visible = true;
            form.QTextbox.Text = "1";
            eevent.SetView(new ButtonOkView(form));

            Assert.AreEqual(buttonRemoveOne.Visible, form.ButtonRemoveOne.Visible);
            Assert.AreEqual(buttonRemoveAll.Visible, form.ButtonRemoveAll.Visible);
        }
    }
}
