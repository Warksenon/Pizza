using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Test.Form1.ViewSettings
{
    [TestClass]
    public class TestButtonRemove : Form1Test
    {
        Button buttonRemoveOne = new Button();
        Button buttonRemoveAll = new Button();
        Button buttonSendOrder = new Button();
        ListView listViewOrder = new ListView();

        //[TestMethod]
        //public void TestViewOnClickButtonRemoveOneWithEmptyListViewOrder()
        //{
        //    //buttonRemoveOne.Visible = false;
        //    //buttonRemoveAll.Visible = false;
        //    //listViewOrder.BackColor = SystemColors.Control;

        //    //eevent.SetView(new ButtonRemoveOne(form));

        //    //Assert.AreEqual(buttonPizza.BackColor, form.bPizza.BackColor);
        //    //Assert.AreEqual(buttonMain.BackColor, form.bMainDish.BackColor);
        //    //Assert.AreEqual(buttonSoups.BackColor, form.bSoups.BackColor);
        //    //Assert.AreEqual(buttonDrinks.BackColor, form.bDrinks.BackColor);
        //    //Assert.AreEqual(textBox.Text, form.QTextbox.Text);
        //    //Assert.AreEqual(labelMenu.Text, form.LabelMenu.Text);
        //    //Assert.AreEqual(buttonAdd.Visible, form.AddButton.Visible);
        //}

        //[TestMethod]
        //public void TestViewOnClickButtonRemoveAll()
        //{
        //}
    }
}
