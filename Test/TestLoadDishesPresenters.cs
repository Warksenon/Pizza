using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;
using Pizza.Presenters;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class TestLoadDishesPresenters : IListViewDishes
    {
        ListView lv = new ListView();
        CheckedListBox ch = new CheckedListBox();
        TForm1LoadDishesPresenters presenters;

        public ListView ListViewDishes { get => lv; set => lv = value; }
        public CheckedListBox CheckedListBoxSideDish { get => ch; set => ch = value; }

        readonly Name name = new Name();

        [TestMethod]
        public void LoadPizza()
        {
            presenters = new TForm1LoadDishesPresenters(this);
            presenters.LoadPizza();
           
            Assert.AreEqual(name.Margh, lv.Items[0].SubItems[0].Text);
            Assert.AreEqual("20zł", lv.Items[0].SubItems[1].Text);

            Assert.AreEqual(name.Veget, lv.Items[1].SubItems[0].Text);
            Assert.AreEqual("22zł", lv.Items[1].SubItems[1].Text);

            Assert.AreEqual(name.Tosca, lv.Items[2].SubItems[0].Text);
            Assert.AreEqual("25zł", lv.Items[2].SubItems[1].Text);

            Assert.AreEqual(name.Venec, lv.Items[3].SubItems[0].Text);
            Assert.AreEqual("25zł", lv.Items[3].SubItems[1].Text);
        }

        [TestMethod]
        public void LoadMainDish()
        {
            presenters = new TForm1LoadDishesPresenters(this);
            presenters.LoadMainDish();
           
            Assert.AreEqual(name.Schnitzel, lv.Items[0].SubItems[0].Text);
            Assert.AreEqual("30zł", lv.Items[0].SubItems[1].Text);

            Assert.AreEqual(name.Fish, lv.Items[1].SubItems[0].Text);
            Assert.AreEqual("28zł", lv.Items[1].SubItems[1].Text);

            Assert.AreEqual(name.Potato, lv.Items[2].SubItems[0].Text);
            Assert.AreEqual("27zł", lv.Items[2].SubItems[1].Text);
        }

        [TestMethod]
        public void LoadDrinks()
        {
            presenters = new TForm1LoadDishesPresenters(this);
            presenters.LoadDrinks();

            Assert.AreEqual(name.Coffee, lv.Items[0].SubItems[0].Text);
            Assert.AreEqual("5zł", lv.Items[0].SubItems[1].Text);

            Assert.AreEqual(name.Tea, lv.Items[1].SubItems[0].Text);
            Assert.AreEqual("5zł", lv.Items[1].SubItems[1].Text);

            Assert.AreEqual(name.Cola, lv.Items[2].SubItems[0].Text);
            Assert.AreEqual("5zł", lv.Items[2].SubItems[1].Text);
        }


        [TestMethod]
        public void LoadSaups()
        {
            presenters = new TForm1LoadDishesPresenters(this);
            presenters.LoadSoups();

            Assert.AreEqual(name.Tomato, lv.Items[0].SubItems[0].Text);
            Assert.AreEqual("12zł", lv.Items[0].SubItems[1].Text);

            Assert.AreEqual(name.ChickenSoup, lv.Items[1].SubItems[0].Text);
            Assert.AreEqual("10zł", lv.Items[1].SubItems[1].Text);
        }



        [TestMethod]
        public void LoadSidesDishPizza()
        {
            presenters = new TForm1LoadDishesPresenters(this);
            presenters.LoadSidesDishPizza();

            Assert.AreEqual(name.DoubelCheesePrice, ch.Items[0]);
            Assert.AreEqual(name.SalamiPrice, ch.Items[1]);
            Assert.AreEqual(name.HamPrice, ch.Items[2]);
            Assert.AreEqual(name.MushroomsPrice, ch.Items[3]);
        }

        [TestMethod]
        public void LoadSidesDishMainDish()
        {
            presenters = new TForm1LoadDishesPresenters(this);
            presenters.LoadSidesDishMainDish();

            Assert.AreEqual(name.BarPrice, ch.Items[0]);
            Assert.AreEqual(name.SetOfSaucesPrice, ch.Items[1]);         
        }


    }
}
