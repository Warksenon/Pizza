using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;

namespace Test
{
    [TestClass]
    public class TestMessage
    {
        readonly Name name = new Name();
        [TestMethod]
        public void TestMessagePizzaAll()
        {
            

            PriceAll priceAll = new PriceAll()
            {
                Price = "275zł",
                Comments = "",
                Date = "2020-07-07 21:03:37"
            };


            Pizza.Dish pizza = new Pizza.Dish
            {
                Name = name.Margh,
                Price = "20zł"
            };

            Pizza.Dish pizzaSide1 = new Pizza.Dish
            {
                Name = name.VegetPrice,
                SidesDishes = Sides(name.DoubelCheesePrice),
                Price = "24zł"
            };

            Pizza.Dish pizzaSide2 = new Pizza.Dish
            {
                Name = name.ToscaPrice,
                SidesDishes = Sides(name.DoubelCheesePrice, name.SalamiPrice),
                Price = "29zł"
            };

            Pizza.Dish pizzaSide3 = new Pizza.Dish
            {
                Name = name.VenecPrice,
                SidesDishes = Sides(name.SalamiPrice, name.HamPrice, name.MushroomsPrice),
                Price = "31zł"
            };

            Dish pizzaSide4 = new Pizza.Dish
            {
                Name = name.VenecPrice,
                SidesDishes = Sides(name.DoubelCheesePrice, name.SalamiPrice, name.HamPrice, name.MushroomsPrice),
                Price = "33zł"
            };

            Pizza.Dish dania1 = new Pizza.Dish
            {
                Name = name.Schnitzel,
                SidesDishes = "",
                Price = "30zł"
            };

            Pizza.Dish dania2 = new Pizza.Dish
            {
                Name = name.FishPrice,
                SidesDishes = Sides(name.BarPrice),
                Price = "33zł"
            };

            Pizza.Dish dania3 = new Pizza.Dish
            {
                Name = name.PotatoPrice,
                SidesDishes = Sides(name.BarPrice, name.SetOfSaucesPrice),
                Price = "38zł"
            };

            Pizza.Dish zupa1 = new Pizza.Dish
            {
                Name = name.Tomato,
                SidesDishes = "",
                Price = "12zł"
            };

            Pizza.Dish zupa2 = new Pizza.Dish
            {
                Name = name.ChickenSoup,
                SidesDishes = "",
                Price = "10zł"
            };


            Pizza.Dish napoje1 = new Pizza.Dish
            {
                Name = name.Coffee,
                SidesDishes = "",
                Price = "5zł"
            };

            Pizza.Dish napoje2 = new Pizza.Dish
            {
                Name = name.Tea,
                SidesDishes = "",
                Price = "5zł"
            };

            Pizza.Dish napoje3 = new Pizza.Dish
            {
                Name = name.Cola,
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

            Pizza.EmailMessage message = new Pizza.EmailMessage(order);


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

            Assert.AreEqual(test, message.WriteBill());



        }

        [TestMethod]
        public void TestMessagePizzaMargharita()
        {
            //Arrange

            Pizza.PriceAll priceAll = new Pizza.PriceAll()
            {
                Price = "20zł",
                Comments = "",
                Date = "2020-07-09 17:22:26"
            };

            Pizza.Dish pizza = new Pizza.Dish
            {
                Name = name.Margh,
                Price = "20zł"
            };


            Pizza.Order order = new Pizza.Order
            {
                PriceAll = priceAll
            };
            order.AddDishToListDisch(pizza);


            Pizza.EmailMessage message = new Pizza.EmailMessage(order);


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
                Date = "2020-07-09 17:27:38"
            };


            Pizza.Dish pizza = new Pizza.Dish
            {
                Name = name.MarghPrice,
                Price = "28zł",
                SidesDishes = Sides(name.DoubelCheesePrice, name.SalamiPrice, name.HamPrice, name.MushroomsPrice)
            };


            Pizza.Order order = new Pizza.Order
            {
                PriceAll = priceAll
            };
            order.AddDishToListDisch(pizza);


            Pizza.EmailMessage message = new Pizza.EmailMessage(order);


            string test = "###################################################\n#\n#               2020-07-09 17:27:38                \n#                     Cena: 28zł                  \n#\n###################################################" +
                "\n###################################################\n#\n# Margheritta -20zł\n# Podwójny Ser -2zł\n# Salami -2zł\n# Szynka -2zł\n# Pieczarki -2zł\n# Cenna za danie: 28zł\n#\n###################################################\nUwagi do zamówienia: \n";

            Assert.AreEqual(test, message.WriteBill());

        }

        private string Sides(string side1)
        {
            return side1 + ".";
        }

        private string Sides(string side1, string side2)
        {
            return side1 + ", " + side2 + ".";
        }

        private string Sides(string side1, string side2, string side3)
        {
            return side1 + ", " + side2 + ", " + side3 + ".";
        }

        private string Sides(string side1, string side2, string side3, string side4)
        {
            return side1 + ", " + side2 + ", " + side3 + ", " + side4 + ".";
        }

    }
}
