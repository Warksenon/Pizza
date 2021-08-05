using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza;

namespace Test
{
    [TestClass]
    public class TestDish
    {
        readonly Name name = new Name();

        [TestMethod]
        public void TestDishAllAddAdditions()
        {
            Dish dish = new Dish();

            Assert.AreEqual("", dish.SidesDishes);
            Assert.AreEqual("", dish.Name);
            Assert.AreEqual("", dish.Price);
            Assert.AreEqual(0, dish.IdPrice);

            dish.SidesDishes = name.SalamiPrice;
            dish.Name = name.Veget;
            dish.Price = "22zł";
            dish.IdPrice = 1;
            Assert.AreEqual("Salami -2zł", dish.SidesDishes);
            Assert.AreEqual("Vegetariana", dish.Name);
            Assert.AreEqual("22zł", dish.Price);
            Assert.AreEqual(1, dish.IdPrice);
        }
    }
}
