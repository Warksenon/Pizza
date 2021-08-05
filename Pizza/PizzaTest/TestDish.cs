using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;

namespace PizzaTest
{
    [TestClass]
    public class TestDish
    {
        [TestMethod]
        public void TestDishAllAddAdditions()
        {
            //Arrange
            Dish dish = new Dish();

            Assert.AreEqual("", dish.SidesDishes);

            dish.SidesDishes = Name.salamiCena;
            Assert.AreEqual(Name.salamiCena, dish.SidesDishes);

        }
    }
}
