using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;
using Test.TModels.TFilesTxt;
using Test.TPresenters;

namespace Test
{
    [TestClass]
    public class TestLoadingAnDSaveFiles
    {
        [TestMethod]
        public void TestSaveOrderList()
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


            order.ListDishes = listOfDishes.LoadListMainDish();           
            date = DateTime.Now.ToString();
            order.PriceAll.Date = date;
            lOrder.Add(order);
            save.SaveOrderList(TSave.ChoiceSaveOrder.Txt, lOrder);
            loadTxt = load.LoadOrderList(TLoadOrder.ChoiceLoadOrder.Txt);

            Assert.AreEqual(lOrder[1].PriceAll.Comments, loadTxt[1].PriceAll.Comments);
            Assert.AreEqual(lOrder[1].PriceAll.Date, loadTxt[1].PriceAll.Date);
            Assert.AreEqual(lOrder[1].PriceAll.Price, loadTxt[1].PriceAll.Price);

            Assert.AreEqual(lOrder[1].ListDishes[0].Name, loadTxt[1].ListDishes[0].Name);
            Assert.AreEqual("Schabowy z frytkami/ryżem/ziemniakami", loadTxt[1].ListDishes[0].Name);
            Assert.AreEqual(lOrder[1].ListDishes[0].Price, loadTxt[1].ListDishes[0].Price);
            Assert.AreEqual(lOrder[1].ListDishes[0].SidesDishes, loadTxt[1].ListDishes[0].SidesDishes);

            Assert.AreEqual(lOrder[1].ListDishes[1].Name, loadTxt[1].ListDishes[1].Name);
            Assert.AreEqual(lOrder[1].ListDishes[1].Price, loadTxt[1].ListDishes[1].Price);
            Assert.AreEqual(lOrder[1].ListDishes[1].SidesDishes, loadTxt[1].ListDishes[1].SidesDishes);

            Assert.AreEqual(lOrder[1].ListDishes[2].Name, loadTxt[1].ListDishes[2].Name);
            Assert.AreEqual(lOrder[1].ListDishes[2].Price, loadTxt[1].ListDishes[2].Price);
            Assert.AreEqual(lOrder[1].ListDishes[2].SidesDishes, loadTxt[1].ListDishes[2].SidesDishes);


            order.ListDishes = listOfDishes.LoadListSoups();        
            date = DateTime.Now.ToString();
            order.PriceAll.Date = date;
            lOrder.Add(order);
            save.SaveOrderList(TSave.ChoiceSaveOrder.Txt, lOrder);
            loadTxt = load.LoadOrderList(TLoadOrder.ChoiceLoadOrder.Txt);

            Assert.AreEqual(lOrder[2].PriceAll.Comments, loadTxt[2].PriceAll.Comments);
            Assert.AreEqual(lOrder[2].PriceAll.Date, loadTxt[2].PriceAll.Date);
            Assert.AreEqual(lOrder[2].PriceAll.Price, loadTxt[2].PriceAll.Price);

            Assert.AreEqual(lOrder[2].ListDishes[0].Name, loadTxt[2].ListDishes[0].Name);
            Assert.AreEqual("Pomidorowa", loadTxt[2].ListDishes[0].Name);
            Assert.AreEqual(lOrder[2].ListDishes[0].Price, loadTxt[2].ListDishes[0].Price);
            Assert.AreEqual(lOrder[2].ListDishes[0].SidesDishes, loadTxt[2].ListDishes[0].SidesDishes);

            Assert.AreEqual(lOrder[2].ListDishes[1].Name, loadTxt[2].ListDishes[1].Name);
            Assert.AreEqual(lOrder[2].ListDishes[1].Price, loadTxt[2].ListDishes[1].Price);
            Assert.AreEqual(lOrder[2].ListDishes[1].SidesDishes, loadTxt[2].ListDishes[1].SidesDishes);
        }
    }
}
