using System;
using System.Collections.Generic;
using System.Linq;

namespace T5._1MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> food = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
            Stack<int> caloriesPerDay = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            Dictionary<string, int> meals = new Dictionary<string, int>();
            bool didHe = false;
            meals.Add("salad", 350);
            meals.Add("soup", 490);
            meals.Add("pasta", 680);
            meals.Add("steak", 790);

            int mealCounter = 0;

            while (food.Count > 0 && caloriesPerDay.Count > 0)
            {
                
                int currentDayCalories = caloriesPerDay.Pop();
               
                while (currentDayCalories > 0)
                {
                    string currentMeal = food.Dequeue();
                    mealCounter++;

                    if (currentDayCalories >= meals[currentMeal])
                    {
                        currentDayCalories -= meals[currentMeal];
                    }
                    else
                    {
                        int leftOver = meals[currentMeal] - currentDayCalories;
                        if (caloriesPerDay.Count == 0)
                        {
                            break;
                        }
                        else
                        {
                            currentDayCalories = caloriesPerDay.Pop() - leftOver;
                        }
                    }
                    if (food.Count == 0)
                    {
                        caloriesPerDay.Push(currentDayCalories);
                        break;
                    }
                }
            }

            if (food.Count == 0)
            {
                didHe = true;
            }


            if (didHe)
            {
                caloriesPerDay.Reverse();
                Console.WriteLine($"John had {mealCounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealCounter} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", food)}.");
            }
            



        }
    }
}
