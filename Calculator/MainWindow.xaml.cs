using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfHW2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> strings;
        public MainWindow()
        {
            InitializeComponent();
            strings = new List<string> { }; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button but)
            {
                if (but.Content.ToString() == "CE")
                {
                    FirstField.Text = "0";
                    SecondField.Text = String.Join("", strings);
                    if (SecondField.Text == "")  SecondField.Text = "0";
                }
                else if (but.Content.ToString() == "C")
                {
                    SecondField.Text = "0";
                    strings.Clear();
                    FirstField.Text = "0";
                }
                else if (but.Content.ToString() == "*")
                {
                    if (FirstField.Text == "0") return;
                    strings.Add(FirstField.Text.ToString());
                    strings.Add("*");
                    SecondField.Text += "*";
                    FirstField.Text = "0";
                }
                else if (but.Content.ToString() == "/")
                {
                    if (FirstField.Text == "0") return;
                    strings.Add(FirstField.Text.ToString());
                    strings.Add("/");
                    SecondField.Text += "/";
                    FirstField.Text = "0";
                }
                else if (but.Content.ToString() == "-")
                {
                    if (FirstField.Text != "0" && FirstField.Text != "-")
                    {
                        strings.Add(FirstField.Text.ToString());
                        strings.Add("-");
                        SecondField.Text += "-";
                        FirstField.Text = "0";
                    }
                    else if (FirstField.Text == "0") 
                    {   if (SecondField.Text == "0")  
                            SecondField.Text = String.Join("", SecondField.Text.ToString().SkipLast(1));
                        FirstField.Text = "-";
                        SecondField.Text += "-";
                    }

                }
                else if (but.Content.ToString() == "+")
                {
                    if (FirstField.Text == "0") return;
                    strings.Add(FirstField.Text.ToString());
                    strings.Add("+");
                    SecondField.Text += "+";
                    FirstField.Text = "0";
                }
                else if (but.Content.ToString() == "<")
                {

                    if (SecondField.Text != "0") SecondField.Text = SecondField.Text.Remove(SecondField.Text.Length - 1);
                    if (FirstField.Text != "0") FirstField.Text = FirstField.Text.Remove(FirstField.Text.Length - 1);
                    if (SecondField.Text == "") SecondField.Text = "0";
                    if (FirstField.Text == "")
                    {
                        FirstField.Text = "0";
                    }
                    else if (FirstField.Text == "0")
                    {
                        if (strings.Count != 0)
                        {
                            strings.Remove(strings[strings.Count - 1]);
                            FirstField.Text = strings[strings.Count - 1];
                        }
                    }

                }
                else if (but.Content.ToString() == "=")
                {
                    strings.Add(FirstField.Text);
                    string input = String.Join("", strings);
                    List<Token> list = new Lexer(input).Tokenize();
                    List<Expression> expressions = new Parser(list).Parse();
                    foreach(var i in expressions)
                    { 
                        var res = i.eval().ToString();
                        SecondField.Text = res;
                        FirstField.Text = res;
                        strings.Clear();
                    }
                }
                else if (but.Content.ToString() == ".") 
                {
                    if (FirstField.Text.Contains(".") != true)
                    {
                        if (FirstField.Text =="0" && SecondField.Text != "0") SecondField.Text += "0";
                        SecondField.Text += but.Content;
                        FirstField.Text += but.Content;
                    }
                }
                else
                {
                    if (FirstField.Text == "0") FirstField.Text = "";
                    if (SecondField.Text == "0") SecondField.Text = "";
                    FirstField.Text += but.Content;
                    SecondField.Text += but.Content;
                }
            }
        }
    }
}
