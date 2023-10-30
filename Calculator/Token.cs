using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHW2
{
    enum TokenType
    {
        NUMBER,
        PLUS,
        MINUS,
        STAR,
        SLASH,
        EOF 
    }
    class Token
    {
        public string text { get; set; }
        public TokenType type { get; set; }

        public Token() { }
        public Token(TokenType type, string text )
        {
            this.text = text;
            this.type = type;
        }
    }
}
