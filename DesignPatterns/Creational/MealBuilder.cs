/* Task 8:
Develop a meal ordering system where a Meal consists of several optional parts: 
drink, main course, dessert, and side dish. */

namespace Task8
{
    public class Meal
    {
        public string? Drink { get; set; }
        public string? Dessert { get; set; }

        public string? SideDish { get; set; }

        public override string ToString() => $"Meal with {Drink}, {Dessert} and {SideDish}";
    }

    public interface IMealBuilder
    {
        void DrinkBuilder();
        void DessertBuilder();

        void SideDishBuilder();
        Meal GetMeal();    
    }

    public class LunchBuilder : IMealBuilder
    {
        private Meal _meal = new();
        public void DessertBuilder() => _meal.Dessert = "Croissant";

        public void DrinkBuilder() => _meal.Drink = "Oringe juice";
        
        public void SideDishBuilder()  =>_meal.SideDish = "Potatos"; 
         
        public Meal GetMeal()
        {
            var meal = _meal;
            _meal = new();
            return meal;
        }
    }

    public class Director 
    {
        private readonly IMealBuilder _mealBuilder;
        public Director(IMealBuilder mealBuilder) => _mealBuilder = mealBuilder;

        public void MakeMeal()
        {
            _mealBuilder.SideDishBuilder();
            _mealBuilder.DrinkBuilder();
            _mealBuilder.DessertBuilder();
        }
    }

    
}
