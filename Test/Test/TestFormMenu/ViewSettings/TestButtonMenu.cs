using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;
using Pizza.Presenters.PresenterForm1.VisableElements.Button;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class TestButtonMenu : Form1Test
    {
        Button buttonPizza = new Button();
        Button buttonMain = new Button();
        Button buttonSoups = new Button();
        Button buttonDrinks = new Button();
        Button buttonAdd = new Button();
        TextBox textBox = new TextBox();
        Label labelMenu = new Label();

        void SetColorButton (EnumMenu onClick)
        {           
            buttonPizza.BackColor = SystemColors.Control;
            buttonMain.BackColor = SystemColors.Control;
            buttonSoups.BackColor = SystemColors.Control;
            buttonDrinks.BackColor = SystemColors.Control;

            switch (onClick)
            {
                case EnumMenu.Pizza: buttonPizza.BackColor = Color.LawnGreen; break;
                case EnumMenu.MainDishes: buttonMain.BackColor = Color.LawnGreen; break;
                case EnumMenu.Soups: buttonSoups.BackColor = Color.LawnGreen; break;
                case EnumMenu.Drinks: buttonDrinks.BackColor = Color.LawnGreen; break;
            }
        }

        void SetSettingsButtonAddaAndTextBox()
        {         
            buttonAdd.Visible = false;
            textBox.Text = "1";
        }

        [TestMethod]
        public void TestViewOnClickButtonMenuPizza()
        {
           
            labelMenu.Text = "Pizza";
            SetColorButton(EnumMenu.Pizza);
            SetSettingsButtonAddaAndTextBox();

            eevent.SetView(new ButtonPizzaView(form));

            Assert.AreEqual(buttonPizza.BackColor, form.PizzzaButton.BackColor);
            Assert.AreEqual(buttonMain.BackColor, form.MainButton.BackColor);
            Assert.AreEqual(buttonSoups.BackColor, form.SoupButton.BackColor);
            Assert.AreEqual(buttonDrinks.BackColor, form.DrinksButton.BackColor);
            Assert.AreEqual(textBox.Text, form.QTextbox.Text);
            Assert.AreEqual(labelMenu.Text, form.LabelMenu.Text);
            Assert.AreEqual(buttonAdd.Visible, form.AddButton.Visible);
        }

        [TestMethod]
        public void TestViewOnClickButtonMenuMainDishes()
        {
            labelMenu.Text = "Dania główne";
            SetColorButton(EnumMenu.MainDishes);
            SetSettingsButtonAddaAndTextBox();

            eevent.SetView(new ButtonMainDishesView(form));

            Assert.AreEqual(buttonPizza.BackColor, form.PizzzaButton.BackColor);
            Assert.AreEqual(buttonMain.BackColor, form.MainButton.BackColor);
            Assert.AreEqual(buttonSoups.BackColor, form.SoupButton.BackColor);
            Assert.AreEqual(buttonDrinks.BackColor, form.DrinksButton.BackColor);
            Assert.AreEqual(textBox.Text, form.QTextbox.Text);
            Assert.AreEqual(labelMenu.Text, form.LabelMenu.Text);
            Assert.AreEqual(buttonAdd.Visible, form.AddButton.Visible);
        }

        [TestMethod]
        public void TestViewOnClickButtonMenuSoups()
        {
            labelMenu.Text = "Zupy";
            SetColorButton(EnumMenu.Soups);
            SetSettingsButtonAddaAndTextBox();

            eevent.SetView(new ButtonSoupsView(form));

            Assert.AreEqual(buttonPizza.BackColor, form.PizzzaButton.BackColor);
            Assert.AreEqual(buttonMain.BackColor, form.MainButton.BackColor);
            Assert.AreEqual(buttonSoups.BackColor, form.SoupButton.BackColor);
            Assert.AreEqual(buttonDrinks.BackColor, form.DrinksButton.BackColor);
            Assert.AreEqual(textBox.Text, form.QTextbox.Text);
            Assert.AreEqual(labelMenu.Text, form.LabelMenu.Text);
            Assert.AreEqual(buttonAdd.Visible, form.AddButton.Visible);
        }

        [TestMethod]
        public void TestViewOnClickButtonMenuDrinks()
        {
            labelMenu.Text = "Napoje";
            SetColorButton(EnumMenu.Drinks);
            SetSettingsButtonAddaAndTextBox();

            eevent.SetView(new ButtonDrinksView(form));

            Assert.AreEqual(buttonPizza.BackColor, form.PizzzaButton.BackColor);
            Assert.AreEqual(buttonMain.BackColor, form.MainButton.BackColor);
            Assert.AreEqual(buttonSoups.BackColor, form.SoupButton.BackColor);
            Assert.AreEqual(buttonDrinks.BackColor, form.DrinksButton.BackColor);
            Assert.AreEqual(textBox.Text, form.QTextbox.Text);
            Assert.AreEqual(labelMenu.Text, form.LabelMenu.Text);
            Assert.AreEqual(buttonAdd.Visible, form.AddButton.Visible);
        }
    }
}
