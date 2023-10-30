using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfHW2
{
    class Parser
    {
        private static Token EOF = new Token(TokenType.EOF, "");

        private List<Token> tokes;
        private int pos;
        private int size;

        public Parser(List<Token> tokens) 
        {
            this.tokes = tokens;
            size = tokes.Count;
        }

        public List<Expression> Parse() 
        {
            List<Expression> result = new List<Expression>();
            while (!Match(TokenType.EOF)) 
            {
                result.Add(Expression());
            }
            return result;
        }

        private Expression Expression() 
        {
            
            return Additive();
        }
        private Expression Additive() 
        {
            Expression expr = Multiplicative();
            while (true)
            {
                if (Match(TokenType.PLUS)) 
                {
                    expr = new BinaryExpression('+', expr, Multiplicative());
                    continue;
                }
                if (Match(TokenType.MINUS)) 
                {
                    expr = new BinaryExpression('-', expr, Multiplicative());
                    continue;
                }
                break;
            }
            return expr;
        }
        private Expression Multiplicative() 
        {
            Expression expr = Unary();
            while (true)
            {
                if (Match(TokenType.STAR)) 
                {
                    expr = new BinaryExpression('*', expr, Unary());
                    continue;
                }
                if (Match(TokenType.SLASH)) 
                {
                    expr = new BinaryExpression('/', expr, Unary());
                    continue;
                }
                break;
            }
            return expr;
        }

        private Expression Unary() 
        {
            if (Match(TokenType.MINUS))
            {
                return new UnaryExpression('-', Primary());
            }
            return Primary();
        }
        private Expression Primary() 
        {
            Token current = Get(0);
            if (Match(TokenType.NUMBER)) 
            {
                return new NumberExpression(Double.Parse(current.text));
            }
            throw new Exception("Uknown epression");
        }

        private Boolean Match(TokenType type) 
        {
            Token current = Get(0);
            if (type != current.type) return false;
            pos++;
            return true;
        }

        private Token Get(int relativePosition) 
        {
            int position = pos + relativePosition;
            if (position >= size) return EOF;
            return tokes[position];
        }
    }
}
