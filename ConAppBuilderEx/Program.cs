using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppBuilderEx
{
    public class RestaurantApp
    {
        public class MainApp
        {
            public static void Main()
            {
                MealCombo combo;
                Restaurant restaurant = new Restaurant();

                combo = new VegCombo();
                restaurant.Construct(combo);
                combo.Meal.Display();

                combo = new NvCombo();
                restaurant.Construct(combo);
                combo.Meal.Display();
            }
        }

        class Restaurant
        {
            public void Construct(MealCombo mealCombo)
            {
                mealCombo.BuildBurger();
                mealCombo.BuildDessert();
                mealCombo.BuildDrink();
                mealCombo.BuildToy();
            }
        }

        abstract class MealCombo
        {
            protected Meal meal;

            public Meal Meal { get { return meal; } }

            public abstract void BuildBurger();
            public abstract void BuildDrink();
            public abstract void BuildDessert();
            public abstract void BuildToy();
        }

        class VegCombo : MealCombo
        {
            public VegCombo()
            {
                meal = new Meal("Veg");
            }

            public override void BuildBurger()
            {
                meal["Burger"] = "Paneer burger";
            }

            public override void BuildDessert()
            {
                meal["Dessert"] = "donut";
            }

            public override void BuildDrink()
            {
                meal["Drink"] = "pepsi";
            }

            public override void BuildToy()
            {
                meal["Toy"] = "Car";
            }
        }

        class NvCombo : MealCombo
        {
            public NvCombo()
            {
                meal = new Meal("Non veg");
            }

            public override void BuildBurger()
            {
                meal["Burger"] = "Chicken burger";
            }

            public override void BuildDessert()
            {
                meal["Dessert"] = "Pie";
            }

            public override void BuildDrink()
            {
                meal["Drink"] = "Coke";
            }

            public override void BuildToy()
            {
                meal["Toy"] = "Transformer toy";
            }
        }

        class Meal
        {
            private string _mealType;
            private Dictionary<string, string> _items = new Dictionary<string, string>();

            public Meal(string mealType)
            {
                this._mealType = mealType;
            }

            public string this[string key]
            {
                get { return _items[key]; }
                set { _items[key] = value; }
            }

            public void Display()
            {
                Console.WriteLine("===========================");
                Console.WriteLine("Burger: {0}", _items["Burger"]);
                Console.WriteLine("Drink: {0}", _items["Drink"]);
                Console.WriteLine("Dessert: {0}", _items["Dessert"]);
                Console.WriteLine("Toy: {0}", _items["Toy"]);
            }
        }
    }
}