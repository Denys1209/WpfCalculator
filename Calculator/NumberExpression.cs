using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHW2
{
    class NumberExpression : Expression
    {
        private double value;
        public NumberExpression(double value) 
        {
            this.value = value;
        }

        public double eval()
        {
            return value;
        }
    }
}
