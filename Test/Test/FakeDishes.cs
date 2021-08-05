using Pizza;

namespace Test.Test
{
    public class FakeDishes
    {
        public static Dish CrateFerst ()
        {
            var dish = new Dish(1)
            {
                Name="nameFerst",
                Sides="sideFerst",
                Price = "priceFerst"
            };

            return dish;
        }

        public static Dish CrateSecond ()
        {
            var dish = new Dish(2)
            {
                Name="nameSecond",
                Sides="sideSecond",
                Price = "priceSecond"
            };

            return dish;
        }

        public static Dish CrateThird ()
        {
            var dish = new Dish(3)
            {
                Name="nameThird",
                Sides="sideThird",
                Price = "priceThird"
            };

            return dish;
        }

        public static Dish CrateFourth ()
        {
            var dish = new Dish(4)
            {
                Name="nameFourth",
                Sides="sideFourth",
                Price = "priceFourth"
            };

            return dish;
        }

        public static Dish CrateFifth ()
        {
            var dish = new Dish(5)
            {
                Name="nameFifth",
                Sides="sideFifth",
                Price = "priceFifth"
            };

            return dish;
        }

    }
}
