using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfHW2
{
    class Lexer
    {
        private static Dictionary<Char, TokenType> OPERATORS = new Dictionary<Char, TokenType>() 
        {
            { '+', TokenType.PLUS },
            { '-', TokenType.MINUS },
            { '*', TokenType.STAR },
            { '/', TokenType.SLASH },
        };
        private string input;
        private List<Token> tokens;
        private int lenght;
        private int pos;

        public Lexer(string input) 
        {
            this.input = input;
            lenght = input.Length;

            tokens = new List<Token>();
        }


        public List<Token> Tokenize() 
        {
            while (pos < lenght) 
            {
                char current = Peek(0);
                if (Char.IsDigit(current)) TokenizeNumber();
                else if (OPERATORS.ContainsKey(current))
                {
                    TokenizeOperator();
                }
                else 
                {
                    Next();
                }

            }
            return tokens;
        }

        private void TokenizeOperator() 
        {
            AddToken(OPERATORS[Peek(0)]);
            Next();
        }
        private void TokenizeNumber() 
        {
            StringBuilder sb = new StringBuilder();
            char current = Peek(0);
            while (true)
            {
                if (!Char.IsDigit(current) && current!='.') break;
                sb.Append(current);
                current = Next();
            }
            AddToken(TokenType.NUMBER, sb.ToString());

        }

        private char Next() 
        {
            pos++;
            return Peek(0);
        }

        private char Peek(int relativePosition) 
        {
            int position = pos + relativePosition;
            if (position >= lenght) return '\0';
            return input[position];
        }
        private void AddToken(TokenType type)
        {
            AddToken(type, "");
        }
        private void AddToken(TokenType type, string text) 
        {
            tokens.Add(new Token(type, text));
        }
    }
}
