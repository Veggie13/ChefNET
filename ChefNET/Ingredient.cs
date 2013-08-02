using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChefNET
{
    public class Ingredient
    {
        public int _value;
        bool _liquid = false;

        public Ingredient(int val)
        {
            _value = val;
        }

        public Ingredient(Ingredient i)
        {
            Copy(i);
        }

        public void Copy(Ingredient i)
        {
            _value = i._value;
            _liquid = i._liquid;
        }

        public void TakeFromFridge()
        {
            string inLine = Console.ReadLine();
            _value = int.Parse(inLine);
        }

        public void Liquefy()
        {
            _liquid = true;
        }

        public override string ToString()
        {
            if (_liquid)
                return Convert.ToChar(_value).ToString();
            else
                return _value.ToString();
        }
    }
}
