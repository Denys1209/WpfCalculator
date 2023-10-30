using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfHW2
{
    class BinaryExpression : Expression
    {
        private Expression expr1, expr2;
        private char operation;

        public BinaryExpression(char operation, Expression expr1, Expression expr2 ) 
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.operation = operation;
        }
        public double eval()
        {
            try
            {
                switch (operation)
                {
                    case '+': return expr1.eval() + expr2.eval();
                    case '-': return expr1.eval() - expr2.eval();
                    case '*': return expr1.eval() * expr2.eval();
                    case '/': return expr1.eval() / (expr2.eval() == 0 ? 1 : expr2.eval());
                    default: return 0;
                }
            }
            catch (Exception)
            {

                return 0;
            }
          
        }
    }
}
