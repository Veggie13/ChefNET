using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChefNET
{
    public class BakingDish
    {
        public List<Ingredient> _values = new List<Ingredient>();

        public BakingDish() { }
        public BakingDish(BakingDish dish)
        {
            _values = dish._values.Select((i) => (new Ingredient(i))).ToList();
        }

        public void Serve()
        {
            foreach (var i in _values)
                Console.WriteLine("{0}", i.ToString());
        }

        public void PourBowlInto(Bowl bowl)
        {
            _values.InsertRange(0, bowl._ingredients.Select((i) => (new Ingredient(i))));
        }
    }
}
