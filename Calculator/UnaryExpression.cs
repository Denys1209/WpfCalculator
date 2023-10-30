using System;

namespace WpfHW2
{
    class UnaryExpression : Expression
    {
        private Expression expr1;
        private char operation;

        public UnaryExpression( char operation, Expression expr1)
        {
            this.expr1 = expr1;
            this.operation = operation;
        }

        public double eval()
        {
            switch (operation) 
            {
                case '-': return -expr1.eval();
                case '+':
                default: return expr1.eval();
            }
        }
    }
}
