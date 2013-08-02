using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChefNET
{
    public class Bowl
    {
        public List<Ingredient> _ingredients = new List<Ingredient>();

        public Bowl() { }
        public Bowl(Bowl bowl)
        {
            _ingredients = bowl._ingredients.Select((i) => (new Ingredient(i))).ToList();
        }

        public void PutIngredientInto(Ingredient i)
        {
            _ingredients.Insert(0, new Ingredient(i));
        }

        public void FoldIngredientInto(Ingredient i)
        {
            i.Copy(_ingredients[0]);
            _ingredients.RemoveAt(0);
        }

        public void AddIngredient(Ingredient i)
        {
            var newI = (_ingredients[0]);
            newI._value += i._value;
            //_ingredients.Insert(0, newI);
        }

        public void RemoveIngredient(Ingredient i)
        {
            var newI = (_ingredients[0]);
            newI._value -= i._value;
            //_ingredients.Insert(0, newI);
        }

        public void CombineIngredient(Ingredient i)
        {
            var newI = (_ingredients[0]);
            newI._value *= i._value;
            //_ingredients.Insert(0, newI);
        }

        public void DivideIngredient(Ingredient i)
        {
            var newI = (_ingredients[0]);
            newI._value /= i._value;
            //_ingredients.Insert(0, newI);
        }

        public void Stir(int minutes)
        {
            var i = _ingredients[0];
            _ingredients.RemoveAt(0);
            if (minutes > _ingredients.Count)
                _ingredients.Add(i);
            else
                _ingredients.Insert(minutes, i);
        }

        public void StirIngredientInto(Ingredient i)
        {
            Stir(i._value);
        }

        public void MixWell()
        {
            var r = new Random();
            int n = _ingredients.Count;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                var i = _ingredients[k];
                _ingredients[k] = _ingredients[n];
                _ingredients[n] = i;
            }
        }

        public void Clean()
        {
            _ingredients.Clear();
        }

        public void LiquefyContents()
        {
            foreach (var i in _ingredients)
                i.Liquefy();
        }

        public void EmptyBowlInto(Bowl bowl)
        {
            _ingredients.InsertRange(0, bowl._ingredients.Select((i) => (new Ingredient(i))));
        }
    }
}
