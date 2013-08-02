using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChefNET;

namespace ChefTest
{
    class Program
    {
        static int Souffle(Recipe master, IEnumerable<Bowl> bowls, IEnumerable<BakingDish> dishes)
        {
            //Ingredients.
            Ingredient
                haricotBeans = new Ingredient(72),
                eggs = new Ingredient(101),
                lard = new Ingredient(108),
                oil = new Ingredient(111),
                zucchinis = new Ingredient(32),
                water = new Ingredient(119),
                redSalmon = new Ingredient(114),
                dijonMustard = new Ingredient(100),
                potatoes = new Ingredient(33);
            Bowl bowl = bowls.First();

            //Method.
            bowl.PutIngredientInto(potatoes);
            bowl.PutIngredientInto(dijonMustard);
            bowl.PutIngredientInto(lard);
            bowl.PutIngredientInto(redSalmon);
            bowl.PutIngredientInto(oil);
            bowl.PutIngredientInto(water);
            bowl.PutIngredientInto(zucchinis);
            bowl.PutIngredientInto(oil);
            bowl.PutIngredientInto(lard);
            bowl.PutIngredientInto(lard);
            bowl.PutIngredientInto(eggs);
            bowl.PutIngredientInto(haricotBeans);
            bowl.LiquefyContents();
            dishes.First().PourBowlInto(bowl);

            return -1;
        }

        static int Fibonacci(Recipe master, IEnumerable<Bowl> bowls, IEnumerable<BakingDish> dishes)
        {
            // Ingredients
            Ingredient
                flour = new Ingredient(100),
                butter = new Ingredient(250),
                egg = new Ingredient(1);
            Bowl bowl = bowls.First();

            // Method
            while (flour._value != 0)
            {
                bowl.PutIngredientInto(flour);
                master.ServeWith(new Recipe(CaramelMethod));
                bowl.Stir(2);
                bowl.RemoveIngredient(egg);
                flour._value--;
            }
            bowl.Stir(2);
            bowl.FoldIngredientInto(butter);
            dishes.First().PourBowlInto(bowl);

            return -1;
        }

        static int CaramelMethod(Recipe master, IEnumerable<Bowl> bowls, IEnumerable<BakingDish> dishes)
        {
            // Ingredients
            Ingredient
                whiteSugar = new Ingredient(1),
                brownSugar = new Ingredient(1),
                vanillaBean = new Ingredient(1);
            Bowl bowl = bowls.First();

            // Method
            bowl.FoldIngredientInto(whiteSugar);
            bowl.PutIngredientInto(whiteSugar);
            bowl.FoldIngredientInto(brownSugar);
            bowl.Clean();
            bowl.PutIngredientInto(whiteSugar);
            bowl.RemoveIngredient(vanillaBean);
            bowl.FoldIngredientInto(whiteSugar);
            while (whiteSugar._value != 0)
            {
                bowl.PutIngredientInto(vanillaBean);
                return 0;
            }
            bowl.PutIngredientInto(whiteSugar);
            bowl.RemoveIngredient(vanillaBean);
            bowl.FoldIngredientInto(whiteSugar);
            while (whiteSugar._value != 0)
            {
                bowl.PutIngredientInto(vanillaBean);
                return 0;
            }
            bowl.PutIngredientInto(whiteSugar);
            master.ServeWith(new Recipe(CaramelMethod));
            bowl.FoldIngredientInto(brownSugar);
            bowl.PutIngredientInto(whiteSugar);
            bowl.AddIngredient(vanillaBean);
            master.ServeWith(new Recipe(CaramelMethod));
            bowl.AddIngredient(brownSugar);

            return -1;
        }

        static void Main(string[] args)
        {
            Recipe recipe = new Recipe(Fibonacci);

            recipe.Serve(1, null, null);
            Console.ReadLine();
        }
    }
}
