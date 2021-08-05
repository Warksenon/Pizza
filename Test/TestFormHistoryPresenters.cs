using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;
using Test.TModels.TFilesTxt;
using Test.TModels.TSQLite;
using Test.TPresenters;

namespace Test
{
    [TestClass]
    public class TestFormHistoryPresenters : IFormHistory
    {
        ListView lvPrice = new ListView();
        ListView lvDish = new ListView();

        public ListView ListViewPrice { get => lvPrice; set => lvPrice = value; }
        public ListView ListViewDishes { get => lvDish; set => lvDish = value; }

        TFormHistoryPresenters history;
        

        [TestMethod]
        public void TestLoadHistoryFromSQLAndLoadLVDishes()
        {
            TCreateTabeles createSql = new TCreateTabeles();
            createSql.CreateSQLiteTables();
            TInsertAndQuestionSQL sql = new TInsertAndQuestionSQL();
            sql.RemoveAllTask();

            ListOfDishes listOfDishes = new ListOfDishes();

            List<Dish> lPizza = listOfDishes.LoadListPizza();
            PriceAll price = new PriceAll
            {
                Comments = "hhhhh",
                Date = "24.03.2020",
                Price = "120"
            };

            Order order = new Order
            {
                PriceAll = price,
                ListDishes = lPizza
            };

            TSave save = new TSave();
            save.SaveOrder(TSave.ChoiceSaveOrder.Sql, order);

            TLoadOrder load = new TLoadOrder();
            List<Order> lOrder = load.LoadOrderList(TLoadOrder.ChoiceLoadOrder.Sql);

            Assert.AreEqual(order.PriceAll.Comments, lOrder[0].PriceAll.Comments);
            Assert.AreEqual(order.PriceAll.Date, lOrder[0].PriceAll.Date);
            Assert.AreEqual(order.PriceAll.Price, lOrder[0].PriceAll.Price);

            Assert.AreEqual(order.ListDishes[0].Name, lOrder[0].ListDishes[0].Name);
            Assert.AreEqual(order.ListDishes[0].Price, lOrder[0].ListDishes[0].Price);

            Assert.AreEqual(order.ListDishes[0].SidesDishes, lOrder[0].ListDishes[0].SidesDishes);

            history = new TFormHistoryPresenters(this);
            history.LoadHistoryFromSQL();

            Assert.AreEqual(order.PriceAll.Date, lvPrice.Items[0].SubItems[1].Text);
            Assert.AreEqual(order.PriceAll.Price, lvPrice.Items[0].SubItems[2].Text);
            Assert.AreEqual(order.PriceAll.Comments, lvPrice.Items[0].SubItems[3].Text);

            history.LoadLVDishes(Convert.ToInt16(order.PriceAll.ID-1));

            Assert.AreEqual(order.ListDishes[0].Name, lvDish.Items[0].SubItems[1].Text);
            Assert.AreEqual(order.ListDishes[0].Price, lvDish.Items[0].SubItems[2].Text);
            Assert.AreEqual(order.ListDishes[0].SidesDishes, lvDish.Items[0].SubItems[3].Text);

            Assert.AreEqual(order.ListDishes[1].Name, lvDish.Items[1].SubItems[1].Text);
            Assert.AreEqual(order.ListDishes[1].Price, lvDish.Items[1].SubItems[2].Text);
            Assert.AreEqual(order.ListDishes[1].SidesDishes, lvDish.Items[1].SubItems[3].Text);

            Assert.AreEqual(order.ListDishes[2].Name, lvDish.Items[2].SubItems[1].Text);
            Assert.AreEqual(order.ListDishes[2].Price, lvDish.Items[2].SubItems[2].Text);
            Assert.AreEqual(order.ListDishes[2].SidesDishes, lvDish.Items[2].SubItems[3].Text);

            Assert.AreEqual(order.ListDishes[3].Name, lvDish.Items[3].SubItems[1].Text);
            Assert.AreEqual(order.ListDishes[3].Price, lvDish.Items[3].SubItems[2].Text);
            Assert.AreEqual(order.ListDishes[3].SidesDishes, lvDish.Items[3].SubItems[3].Text);

        }

        [TestMethod]
        public void TestLoadHistoryFromTxtAndLoadLVDishes()
        {
            TSaveFiles saveFiles = new TSaveFiles();
            saveFiles.CleanFilesTxt();
            
            ListOfDishes listOfDishes = new ListOfDishes();                       
            Order order = new Order
            {
                ListDishes = listOfDishes.LoadListPizza()
            };

            string date = DateTime.Now.ToString();
            order.PriceAll.Date = date;

            List<Order> lOrder = new List<Order>
            {
                order
            };

            TSave save = new TSave();
            save.SaveOrderList(TSave.ChoiceSaveOrder.Txt, lOrder);

            TLoadOrder load = new TLoadOrder();
            List<Order> loadTxt = load.LoadOrderList(TLoadOrder.ChoiceLoadOrder.Txt);          

            Assert.AreEqual(lOrder[0].PriceAll.Comments, loadTxt[0].PriceAll.Comments);
            Assert.AreEqual(lOrder[0].PriceAll.Date, loadTxt[0].PriceAll.Date);
            Assert.AreEqual(lOrder[0].PriceAll.Price, loadTxt[0].PriceAll.Price);

            Assert.AreEqual(lOrder[0].ListDishes[0].Name, loadTxt[0].ListDishes[0].Name);
            Assert.AreEqual("Margheritta", loadTxt[0].ListDishes[0].Name);
            Assert.AreEqual(lOrder[0].ListDishes[0].Price, loadTxt[0].ListDishes[0].Price);
            Assert.AreEqual(lOrder[0].ListDishes[0].SidesDishes, loadTxt[0].ListDishes[0].SidesDishes);

            Assert.AreEqual(lOrder[0].ListDishes[1].Name, loadTxt[0].ListDishes[1].Name);
            Assert.AreEqual(lOrder[0].ListDishes[1].Price, loadTxt[0].ListDishes[1].Price);
            Assert.AreEqual(lOrder[0].ListDishes[1].SidesDishes, loadTxt[0].ListDishes[1].SidesDishes);

            Assert.AreEqual(lOrder[0].ListDishes[2].Name, loadTxt[0].ListDishes[2].Name);
            Assert.AreEqual(lOrder[0].ListDishes[2].Price, loadTxt[0].ListDishes[2].Price);
            Assert.AreEqual(lOrder[0].ListDishes[2].SidesDishes, loadTxt[0].ListDishes[2].SidesDishes);

            Assert.AreEqual(lOrder[0].ListDishes[3].Name, loadTxt[0].ListDishes[3].Name);
            Assert.AreEqual(lOrder[0].ListDishes[3].Price, loadTxt[0].ListDishes[3].Price);
            Assert.AreEqual(lOrder[0].ListDishes[3].SidesDishes, loadTxt[0].ListDishes[3].SidesDishes);

            history = new TFormHistoryPresenters(this);
            history.LoadHistroyFromTxt();

            Assert.AreEqual(order.PriceAll.Date, lvPrice.Items[0].SubItems[1].Text);
            Assert.AreEqual(order.PriceAll.Price, lvPrice.Items[0].SubItems[2].Text);
            Assert.AreEqual(order.PriceAll.Comments, lvPrice.Items[0].SubItems[3].Text);

            history.LoadLVDishes(Convert.ToInt16(order.PriceAll.ID));

            Assert.AreEqual(order.ListDishes[0].Name, lvDish.Items[0].SubItems[1].Text);
            Assert.AreEqual(order.ListDishes[0].Price, lvDish.Items[0].SubItems[2].Text);
            Assert.AreEqual(order.ListDishes[0].SidesDishes, lvDish.Items[0].SubItems[3].Text);

            Assert.AreEqual(order.ListDishes[1].Name, lvDish.Items[1].SubItems[1].Text);
            Assert.AreEqual(order.ListDishes[1].Price, lvDish.Items[1].SubItems[2].Text);
            Assert.AreEqual(order.ListDishes[1].SidesDishes, lvDish.Items[1].SubItems[3].Text);

            Assert.AreEqual(order.ListDishes[2].Name, lvDish.Items[2].SubItems[1].Text);
            Assert.AreEqual(order.ListDishes[2].Price, lvDish.Items[2].SubItems[2].Text);
            Assert.AreEqual(order.ListDishes[2].SidesDishes, lvDish.Items[2].SubItems[3].Text);

            Assert.AreEqual(order.ListDishes[3].Name, lvDish.Items[3].SubItems[1].Text);
            Assert.AreEqual(order.ListDishes[3].Price, lvDish.Items[3].SubItems[2].Text);
            Assert.AreEqual(order.ListDishes[3].SidesDishes, lvDish.Items[3].SubItems[3].Text);

        }
    }


}
