using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{

    internal class AdventGameFrame
    {
        public int Value { get; private set; }
        public string Color { get; private set; }

        public AdventGameFrame(int value, string color) {
            Value = value; 
            Color = color; 
        }
        public override string ToString()
        {
            return $"Value: {Value}, Color: {Color}";
        }

    }
}
