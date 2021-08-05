using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;
using Test.TModels.TSQLite;
using Test.TPresenters;


namespace Test
{
    [TestClass]
    public class TestSqLite
    {
        readonly Name name = new Name();

        [TestMethod]
        public void TestSaveOrder()
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
            Assert.AreEqual(order.ListDishes[0].Name, name.Margh);

            Assert.AreEqual(order.PriceAll.Comments, lOrder[0].PriceAll.Comments);
            Assert.AreEqual(order.PriceAll.Date, lOrder[0].PriceAll.Date);
            Assert.AreEqual(order.PriceAll.Price, lOrder[0].PriceAll.Price);

            Assert.AreEqual(order.ListDishes[0].Name, lOrder[0].ListDishes[0].Name);
            Assert.AreEqual(order.ListDishes[0].Price, lOrder[0].ListDishes[0].Price);

            Assert.AreEqual(order.ListDishes[0].SidesDishes, lOrder[0].ListDishes[0].SidesDishes);
        }

        [TestMethod]
        public void TestSaveOrderList()
        {
            TCreateTabeles createSql = new TCreateTabeles();
            createSql.CreateSQLiteTables();
            TInsertAndQuestionSQL sql = new TInsertAndQuestionSQL();
            sql.RemoveAllTask();    
            
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
            save.SaveOrderList(TSave.ChoiceSaveOrder.Sql, lOrder);

            TLoadOrder load = new TLoadOrder();
            List<Order> loadSql = load.LoadOrderList(TLoadOrder.ChoiceLoadOrder.Sql);

            Assert.AreEqual(lOrder[0].PriceAll.Comments, loadSql[0].PriceAll.Comments);
            Assert.AreEqual(lOrder[0].PriceAll.Date, loadSql[0].PriceAll.Date);
            Assert.AreEqual(lOrder[0].PriceAll.Price, loadSql[0].PriceAll.Price);

            Assert.AreEqual(lOrder[0].ListDishes[0].Name, loadSql[0].ListDishes[0].Name);
            Assert.AreEqual("Margheritta", loadSql[0].ListDishes[0].Name);
            Assert.AreEqual(lOrder[0].ListDishes[0].Price, loadSql[0].ListDishes[0].Price);
            Assert.AreEqual(lOrder[0].ListDishes[0].SidesDishes, loadSql[0].ListDishes[0].SidesDishes);

            Assert.AreEqual(lOrder[0].ListDishes[1].Name, loadSql[0].ListDishes[1].Name);
            Assert.AreEqual(lOrder[0].ListDishes[1].Price, loadSql[0].ListDishes[1].Price);
            Assert.AreEqual(lOrder[0].ListDishes[1].SidesDishes, loadSql[0].ListDishes[1].SidesDishes);

            Assert.AreEqual(lOrder[0].ListDishes[2].Name, loadSql[0].ListDishes[2].Name);
            Assert.AreEqual(lOrder[0].ListDishes[2].Price, loadSql[0].ListDishes[2].Price);
            Assert.AreEqual(lOrder[0].ListDishes[2].SidesDishes, loadSql[0].ListDishes[2].SidesDishes);

            Assert.AreEqual(lOrder[0].ListDishes[3].Name, loadSql[0].ListDishes[3].Name);
            Assert.AreEqual(lOrder[0].ListDishes[3].Price, loadSql[0].ListDishes[3].Price);
            Assert.AreEqual(lOrder[0].ListDishes[3].SidesDishes, loadSql[0].ListDishes[3].SidesDishes);



            order.ListDishes = listOfDishes.LoadListMainDish();       
            date = DateTime.Now.ToString();
            order.PriceAll.Date = date;
            lOrder.Add(order);
            save.SaveOrderList(TSave.ChoiceSaveOrder.Sql, lOrder);
            loadSql = load.LoadOrderList(TLoadOrder.ChoiceLoadOrder.Sql);

            Assert.AreEqual(lOrder[1].PriceAll.Comments, loadSql[1].PriceAll.Comments);
            Assert.AreEqual(lOrder[1].PriceAll.Date, loadSql[1].PriceAll.Date);
            Assert.AreEqual(lOrder[1].PriceAll.Price, loadSql[1].PriceAll.Price);

            Assert.AreEqual(lOrder[1].ListDishes[0].Name, loadSql[1].ListDishes[0].Name);
            Assert.AreEqual("Schabowy z frytkami/ryżem/ziemniakami", loadSql[1].ListDishes[0].Name);
            Assert.AreEqual(lOrder[1].ListDishes[0].Price, loadSql[1].ListDishes[0].Price);
            Assert.AreEqual(lOrder[1].ListDishes[0].SidesDishes, loadSql[1].ListDishes[0].SidesDishes);

            Assert.AreEqual(lOrder[1].ListDishes[1].Name, loadSql[1].ListDishes[1].Name);
            Assert.AreEqual(lOrder[1].ListDishes[1].Price, loadSql[1].ListDishes[1].Price);
            Assert.AreEqual(lOrder[1].ListDishes[1].SidesDishes, loadSql[1].ListDishes[1].SidesDishes);

            Assert.AreEqual(lOrder[1].ListDishes[2].Name, loadSql[1].ListDishes[2].Name);
            Assert.AreEqual(lOrder[1].ListDishes[2].Price, loadSql[1].ListDishes[2].Price);
            Assert.AreEqual(lOrder[1].ListDishes[2].SidesDishes, loadSql[1].ListDishes[2].SidesDishes);


            order.ListDishes = listOfDishes.LoadListSoups();          
            date = DateTime.Now.ToString();
            order.PriceAll.Date = date;
            lOrder.Add(order);
            save.SaveOrderList(TSave.ChoiceSaveOrder.Sql, lOrder);
            loadSql = load.LoadOrderList(TLoadOrder.ChoiceLoadOrder.Sql);

            Assert.AreEqual(lOrder[2].PriceAll.Comments, loadSql[2].PriceAll.Comments);
            Assert.AreEqual(lOrder[2].PriceAll.Date, loadSql[2].PriceAll.Date);
            Assert.AreEqual(lOrder[2].PriceAll.Price, loadSql[2].PriceAll.Price);

            Assert.AreEqual(lOrder[2].ListDishes[0].Name, loadSql[2].ListDishes[0].Name);
            Assert.AreEqual("Pomidorowa", loadSql[2].ListDishes[0].Name);
            Assert.AreEqual(lOrder[2].ListDishes[0].Price, loadSql[2].ListDishes[0].Price);
            Assert.AreEqual(lOrder[2].ListDishes[0].SidesDishes, loadSql[2].ListDishes[0].SidesDishes);

            Assert.AreEqual(lOrder[2].ListDishes[1].Name, loadSql[2].ListDishes[1].Name);
            Assert.AreEqual(lOrder[2].ListDishes[1].Price, loadSql[2].ListDishes[1].Price);
            Assert.AreEqual(lOrder[2].ListDishes[1].SidesDishes, loadSql[2].ListDishes[1].SidesDishes);
        }

    
    }
}

