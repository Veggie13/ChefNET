using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChefNET
{
    public class Recipe
    {
        public delegate int InstructionDelegate(Recipe master, IEnumerable<Bowl> bowls, IEnumerable<BakingDish> dishes);
        public InstructionDelegate Instructions;

        public List<Bowl> _bowls = new List<Bowl>();
        public List<BakingDish> _dishes = new List<BakingDish>();

        public Recipe(InstructionDelegate inst)
        {
            _bowls.Add(new Bowl());
            _dishes.Add(new BakingDish());
            Instructions = inst;
        }

        public Bowl Serve(int dishes, IEnumerable<Bowl> bowls, IEnumerable<BakingDish> hisDishes)
        {
            if (bowls != null)
                _bowls = bowls.Select((b) => (new Bowl(b))).ToList();
            if (hisDishes != null)
                _dishes = hisDishes.Select((d) => (new BakingDish(d))).ToList();

            int fridge = Instructions(this, _bowls, _dishes);
            if (fridge >= 0)
                dishes = fridge;
            for (int d = 0; d < dishes; d++)
                _dishes[d].Serve();
            return _bowls[0];
        }

        public void ServeWith(Recipe aux)
        {
            Bowl b = aux.Serve(0, _bowls, _dishes);
            _bowls[0].EmptyBowlInto(b);
        }
    }
}
