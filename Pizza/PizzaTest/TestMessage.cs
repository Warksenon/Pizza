using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PizzaTest
{
    [TestClass]
    public class TestMessage

    {
        [TestMethod]
        public void TestMessagePizzaAll()
        {
            //Arrange
            
            Pizza.PriceAll priceAll = new Pizza.PriceAll() 
            {
                Price = "275zł",
                Comments = "",
                Data = "2020-07-07 21:03:37"
            };


            Pizza.Dish pizza = new Pizza.Dish
            {
                Name = Pizza.Name.margh,
                Price = "20zł"
            };

            Pizza.Dish pizzaSide1 = new Pizza.Dish
            {
                Name = Pizza.Name.vegetCena,
                SidesDishes = Sides(Pizza.Name.SerCena),
                Price = "24zł"
            };

            Pizza.Dish pizzaSide2 = new Pizza.Dish
            {
                Name = Pizza.Name.toscaCena,
                SidesDishes = Sides(Pizza.Name.SerCena, Pizza.Name.salamiCena),
                Price = "29zł"
            };

            Pizza.Dish pizzaSide3 = new Pizza.Dish
            {
                Name = Pizza.Name.venecCena,
                SidesDishes = Sides(Pizza.Name.salamiCena, Pizza.Name.szynkaCena, Pizza.Name.pieczaCena),
                Price = "31zł"
            };

            Pizza.Dish pizzaSide4 = new Pizza.Dish
            {
                Name = Pizza.Name.venecCena,
                SidesDishes = Sides(Pizza.Name.SerCena, Pizza.Name.salamiCena, Pizza.Name.szynkaCena, Pizza.Name.pieczaCena),
                Price = "33zł"
            };

            Pizza.Dish dania1 = new Pizza.Dish
            {
                Name = Pizza.Name.schab,
                SidesDishes = "",
                Price = "30zł"
            };

            Pizza.Dish dania2 = new Pizza.Dish
            {
                Name = Pizza.Name.rybaCena,
                SidesDishes = Sides(Pizza.Name.barCena),
                Price = "33zł"
            };

            Pizza.Dish dania3 = new Pizza.Dish
            {
                Name = Pizza.Name.placeCena,
                SidesDishes = Sides(Pizza.Name.barCena, Pizza.Name.zestawCena),
                Price = "38zł"
            };

            Pizza.Dish zupa1 = new Pizza.Dish
            {
                Name = Pizza.Name.pomid,
                SidesDishes = "",
                Price = "12zł"
            };

            Pizza.Dish zupa2 = new Pizza.Dish
            {
                Name = Pizza.Name.rosol,
                SidesDishes = "",
                Price = "10zł"
            };


            Pizza.Dish napoje1 = new Pizza.Dish
            {
                Name = Pizza.Name.kawa,
                SidesDishes = "",
                Price = "5zł"
            };

            Pizza.Dish napoje2 = new Pizza.Dish
            {
                Name = Pizza.Name.herb,
                SidesDishes = "",
                Price = "5zł"
            };

            Pizza.Dish napoje3 = new Pizza.Dish
            {
                Name = Pizza.Name.cola,
                SidesDishes = "",
                Price = "5zł"
            };

            


            Pizza.Order order = new Pizza.Order
            {
                PriceAll = priceAll
            };
            order.AddDishToListDisch(pizza);
            order.AddDishToListDisch(pizzaSide1);
            order.AddDishToListDisch(pizzaSide2);
            order.AddDishToListDisch(pizzaSide3);
            order.AddDishToListDisch(pizzaSide4);

            order.AddDishToListDisch(dania1);
            order.AddDishToListDisch(dania2);
            order.AddDishToListDisch(dania3);

            order.AddDishToListDisch(zupa1);
            order.AddDishToListDisch(zupa2);

            order.AddDishToListDisch(napoje1);
            order.AddDishToListDisch(napoje2);
            order.AddDishToListDisch(napoje3);

            Pizza.Message message = new Pizza.Message(order);


            string test = "###################################################\n#\n#               2020-07-07 21:03:37                \n#                     Cena: 275zł                 \n#\n###################################################" +
                            "\n###################################################\n#\n# Margheritta\n# Cenna za danie: 20zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Vegetariana -22zł\n# Podwójny Ser -2zł\n# Cenna za danie: 24zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Tosca -25zł\n# Podwójny Ser -2zł\n# Salami -2zł\n# Cenna za danie: 29zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Venecia -25zł\n# Salami -2zł\n# Szynka -2zł\n# Pieczarki -2zł\n# Cenna za danie: 31zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Venecia -25zł\n# Podwójny Ser -2zł\n# Salami -2zł\n# Szynka -2zł\n# Pieczarki -2zł\n# Cenna za danie: 33zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Schabowy z frytkami/ryżem/ziemniakami\n# Cenna za danie: 30zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Ryba z frytkami -28zł\n# Bar sałatkowy -5zł\n# Cenna za danie: 33zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Placek po węgiersku -27zł\n# Bar sałatkowy -5zł\n# Zestaw sosów -6zł\n# Cenna za danie: 38zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Pomidorowa\n# Cenna za danie: 12zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Rosół\n# Cenna za danie: 10zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Kawa\n# Cenna za danie: 5zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Herbata\n# Cenna za danie: 5zł\n#\n###################################################" +
                            "\n###################################################\n#\n# Cola\n# Cenna za danie: 5zł\n#\n###################################################" +
                            "\nUwagi do zamówienia: \n";

            Assert.AreEqual(test,message.WriteBill());

          

        }


        [TestMethod]
        public void TestMessagePizzaMargharita()
        {
            //Arrange

            Pizza.PriceAll priceAll = new Pizza.PriceAll()
            {
                Price = "20zł",
                Comments = "",
                Data = "2020-07-09 17:22:26"
            };

            Pizza.Dish pizza = new Pizza.Dish
            {
                Name = Pizza.Name.margh,
                Price = "20zł"
            };


            Pizza.Order order = new Pizza.Order
            {
                PriceAll = priceAll
            };
            order.AddDishToListDisch(pizza);
            

            Pizza.Message message = new Pizza.Message(order);


            string test = "###################################################\n#\n#               2020-07-09 17:22:26                \n#                     Cena: 20zł                  \n#\n###################################################" +
                          "\n###################################################\n#\n# Margheritta\n# Cenna za danie: 20zł\n#\n###################################################\nUwagi do zamówienia: \n";

            Assert.AreEqual(test, message.WriteBill());

        }


        [TestMethod]
        public void TestMessagePizzaMargharitaSideDisch()
        {
            //Arrange

            Pizza.PriceAll priceAll = new Pizza.PriceAll()
            {
                Price = "28zł",
                Comments = "",
                Data = "2020-07-09 17:27:38"
            };


            Pizza.Dish pizza = new Pizza.Dish
            {
                Name = Pizza.Name.marghCena,
                Price = "28zł",
                SidesDishes = Sides(Pizza.Name.SerCena, Pizza.Name.salamiCena, Pizza.Name.szynkaCena, Pizza.Name.pieczaCena)
            };


            Pizza.Order order = new Pizza.Order
            {
                PriceAll = priceAll
            };
            order.AddDishToListDisch(pizza);


            Pizza.Message message = new Pizza.Message(order);


            string test = "###################################################\n#\n#               2020-07-09 17:27:38                \n#                     Cena: 28zł                  \n#\n###################################################" +
                "\n###################################################\n#\n# Margheritta -20zł\n# Podwójny Ser -2zł\n# Salami -2zł\n# Szynka -2zł\n# Pieczarki -2zł\n# Cenna za danie: 28zł\n#\n###################################################\nUwagi do zamówienia: \n";
            
                Assert.AreEqual(test, message.WriteBill());

        }


        private string Sides (string side1)
        {
            return side1+".";
        }
        private string Sides(string side1, string side2)
        {
            return side1 + ", "+side2 +".";
        }
        private string Sides(string side1, string side2, string side3)
        {
            return side1 + ", " + side2+ ", " + side3 + ".";
        }
        private string Sides(string side1, string side2, string side3, string side4)
        {
            return side1 + ", " + side2 + ", " + side3 + ", " + side4 + ".";
        }


        //public void TestMessageDaniaGlowne()
        //{
        //    //Arrange

        //    Pizza.PriceAll priceAll = new Pizza.PriceAll();
        //    priceAll.Price = "";
        //    priceAll.Comments = "";
        //    priceAll.Data = "";

        //    Pizza.Dish pizza = new Pizza.Dish();
        //    pizza.Name = Pizza.Name.marghCena;

        //    Pizza.Dish pizzaSide1 = new Pizza.Dish();
        //    pizzaSide1.Name = Pizza.Name.vegetCena;
        //    pizzaSide1.SidesDishes = Sides(Pizza.Name.SerCena);

        //    Pizza.Dish pizzaSide2 = new Pizza.Dish();
        //    pizzaSide2.Name = Pizza.Name.vegetCena;
        //    pizzaSide2.SidesDishes = Sides(Pizza.Name.salamiCena, Pizza.Name.szynkaCena);

        //    Pizza.Dish pizzaSide3 = new Pizza.Dish();
        //    pizzaSide3.Name = Pizza.Name.vegetCena;
        //    pizzaSide3.SidesDishes = Sides(Pizza.Name.salamiCena, Pizza.Name.szynkaCena);

        //    priceAll.Price = "";
        //    priceAll.Comments = "";
        //    priceAll.Data = "";


        //    Pizza.Order order = new Pizza.Order();
        //    string test = ""

        //    Assert.AreEqual(test, dish.AllAddAdditions);

        //    dish.AllAddAdditions = Name.salamiCena;
        //    Assert.AreEqual(Name.salamiCena, dish.AllAddAdditions);

        //}
    }
}
