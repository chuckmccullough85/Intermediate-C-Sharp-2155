
namespace Examples
{
public enum Meal
{
    Breakfast,
    Lunch,
    Dinner,
    Snack
}

public enum Meal2
{
    Breakfast=1,
    Lunch=10,
    Dinner= 20,
    Snack=30
}

    public class EnumExample
    {
        public static void Func(Meal meal)
        {
            meal = Meal.Dinner;
        }

        public static void EE()
        {
            Meal meal = Meal.Breakfast;
            Func(meal);

            System.Console.WriteLine("Meal: {0}", meal);
        }
    }

}