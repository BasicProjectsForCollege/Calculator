
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Windows.Media.TextFormatting;
using System.Numerics;
using System.Drawing;
using System.Security.Policy;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        int val;
        public MainWindow()
        {

            InitializeComponent();

        }

        private void Print_digits(object sender, RoutedEventArgs e)
        {
            string tag = "1\0";
            if (sender is Button button)
            {
                tag = button.Tag?.ToString();
            }
            int a = Int32.Parse(tag);
            switch (a) {
                case 0:
                    {
                        textbox1.Text += num0.Content.ToString();
                        break;
                    }
                case 1:
                    {
                        textbox1.Text += num1.Content.ToString();
                        break;
                    }
                case 2:
                    {
                        textbox1.Text += num2.Content.ToString();
                        break;
                    }
                case 3:
                    {
                        textbox1.Text += num3.Content.ToString();
                        break;
                    }
                case 4:
                    {
                        textbox1.Text += num4.Content.ToString();
                        break;
                    }
                case 5:
                    {
                        textbox1.Text += num5.Content.ToString();
                        break;
                    }
                case 6:
                    {
                        textbox1.Text += num6.Content.ToString();
                        break;
                    }
                case 7:
                    {
                        textbox1.Text += num7.Content.ToString();
                        break;
                    }
                case 8:
                    {
                        textbox1.Text += num8.Content.ToString();
                        break;
                    }
                case 9:
                    {
                        textbox1.Text += num9.Content.ToString();
                        break;
                    }
                case 10:
                    {
                        break;
                    }
                case 11:
                    {
                        if (textbox1.Text == "")
                        {
                            textbox1.Text = "0";
                        }
                        textbox1.Text += dot.Content.ToString();
                        break;
                    }

            }


            return;

        }
        private void Print_Arthermatic_op(object sender, RoutedEventArgs e)
        {
            string tag = "1\0";
            string text = textbox1.Text;
            if (sender is Button button)
            {
                tag = button.Tag?.ToString();
            }
            int a = Int32.Parse(tag);
            float ans;
            switch (a) {
                case 101:
                    {
                        
                        ans =evaluate(text);
                        textbox1.Text = ans.ToString();
                        break;
                    }
                case 102:
                    {
                        textbox1.Text += sub.Content.ToString();
                        break;
                    }
                case 103:
                    {
                        textbox1.Text += add.Content.ToString();
                        break;
                    }
                case 104:
                    {
                        textbox1.Text += mul.Content.ToString();
                        break;
                    }
                case 105:
                    {
                        textbox1.Text += div.Content.ToString();
                        break;
                    }
                case 106:
                    {
                        textbox1.Text += per.Content.ToString();
                        break;
                    }
                case 107:
                    {
                        break;
                    }
                case 108:
                    {

                        textbox1.Text = "";
                        break;
                    }


            }

        }

        private char check_op(char c)
        {
            switch (c) {
                case '+': { return '+';}
                case '-': { return '-'; }
                case '*': { return '*'; }
                case '/': { return '/'; }
            }
            return '_';

        }

        private void Print_Trig(object sender, RoutedEventArgs e)
        {
            string tag = "";
            if (sender is Button button)
            {
                tag = button.Tag?.ToString();
            }
            switch (tag) {

                case "sin":
                    {
                        textbox1.Text += sine.Content.ToString() + "(";
                        break;
                    }

            }


        }

        //arthematic funtion
        private float arthematic(float prev,float next, char op)
        {
            
            switch (op) {
                case '+': {
                        return prev + next;
                    }
                case '-':
                    {
                        return prev - next;
                    }
                case '*':
                    {
                        return prev * next;
                    }
                case '/':
                    {
                        return prev / next;
                    }

            }
            return 0;

        }
        private int Precedence1(char op)
        {
            if (op == '+' || op == '-') return 1;
            if (op == '*' || op == '/') return 2;
            return 0;
        }
        private string add_brac(String a)
        {
            /*int size = a.Count();            
            a = a.Insert(0, "(");
            a = a.Insert(size + 1, ")");
            int i = 0;
            int c = 0;
            size = a.Length;
            for (i = 0; i < size; i++)
            {
                if (a[i + c] == '+' || a[i + c] == '-' )
                {
                    a = a.Insert(i + c + 1, "(");
                    a = a.Insert(i + c, ")");
                    c = c + 2;
                }
            }*/
            return  "("+a+")";
            
        }
        


        
        //evalution 5th attempt
        private float evaluate(String a)
        {
            //(1+(2*3))
            Stack<float> val = new Stack<float>();
            Stack<char> op = new Stack<char>();

            bool Isdec = false;

            float number = 0,decimal_pointer=1;

            int size = a.Length;

            for (int i = 0; i < size; i++)
            {
                if (char.IsWhiteSpace(a[i])) continue; //checks for whitespaces

                //if it encounters '('
                if (a[i] == '(')
                {
                    op.Push('('); // pushes it top of op stack
                }
                else if (a[i] == ')') //if it encounters ')' 
                {
                   //evaluates whats in between the brackets if the top of op stack is '('
                    while (op.Count > 0 && (op.Peek() !='('))
                    {
                        float r = val.Pop();
                        float s = val.Pop();
                        val.Push(arthematic(s, r, op.Pop()));
                    }
                    op.Pop();
                }
                else if (char.IsDigit(a[i]))//if encounters digit it pushes it to top
                {
                   
                    number = 0;
                    Isdec = false;
                    decimal_pointer = 1;
                    while (i < size && (char.IsDigit(a[i]) || a[i] == '.'))//if any decimal no.
                    {

                        if (a[i] == '.')//evlautaion after deciaml point
                        {
                            if(Isdec){
                                break;
                            }
                            Isdec = true;
                                i++;
                            continue;
                        }
                        if (Isdec) 
                        {
                            decimal_pointer *= 10;
                            number +=(a[i] - '0')/decimal_pointer;
                        }
                        else{ //evlatuion before decimal point
                            number = number * 10 + (a[i] - '0');
                        }

                        i++;
                    }

                    i--;
                    val.Push(number);//pushes no. when done 
                }
                else //pushes encountered operator in op stack checking the priority 
                {
                    while (op.Count > 0 && Precedence1(op.Peek()) >= Precedence1(a[i]))
                    {
                        float r = val.Pop();
                        float s = val.Pop();
                        val.Push(arthematic(s, r, op.Pop()));
                    }
                    op.Push(a[i]);

                }
                

            }
            //evalutes remaining operators outside the bracket
            while (op.Count >0)
            {
                float r = val.Pop();
                float s = val.Pop();
                val.Push(arthematic(s, r, op.Pop()));
            }

            return val.Pop(); //only answers remains in the val stack
        }

    }


}

    