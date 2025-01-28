
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ans = "\0";
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
            switch (a) {
                case 101:
                    {
                        
                        text = add_brac(text);
                        float ans = evaluate(text);
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
        private float arthematic(float prev, float next, char op)
        {
            float res = 0;
            switch (op) {
                case '+': {
                        res = prev + next;
                        break;
                    }
                case '-':
                    {
                        res = prev - next;
                        break;
                    }
                case '*':
                    {
                        res = prev * next;
                        break;
                    }
                case '/':
                    {
                        res = prev / next;
                        break;
                    }

            }
            return res;

        }
        private int Precedence1(char op)
        {
            if (op == '+' || op == '-') return 1;
            if (op == '*' || op == '/') return 2;
            return 0;
        }
        private string add_brac(String a)
        {
            int size=a.Length;
            a.Insert(0, "(");
            a.Insert(size, ")");
            int i = 0;
            int c = 0;
            size = a.Length;
            for (i = 0; i < size; i++)
            {
                if (a[i + c] == '+' || a[i + c] == '-')
                {
                    a = a.Insert(i + c + 1, "(");
                    a = a.Insert(i + c, ")");
                    c = c + 2;
                }
            }
            return a;
        }
        


        //evaluation 1st attempt
        /* private void evaluate(String a)
         {
             List<string> val = new List<string>();
             List<char> op = new List<char>(), pro = new List<char>();
             List<int> pos = new List<int>();
             pro = ['*','/','+','-'];
             int i = 0;
             string tmp="";
             int size = a.Length;
             while (i < size)
             {

                 if (a[i]>45 && a[i] < 59 && a[i] !=47 && i<size)
                 {
                     tmp = tmp + a[i];
                     if (i == size - 1)
                     {
                         val.Add(tmp);
                         break;
                     }
                 }
                 else
                 {   
                     val.Add(tmp);
                     op.Add(a[i]);
                     Check_op(a[i], pos);
                     tmp = "";
                 }
                 i++;
             }
             float ans = 0, size_op = op.Count;


             string tmp1="";

             ans = float.Parse(val[0]);
             for ( i = 0; i < size_op; i++)
             {

                     switch (op[i])
                 {
                     case '+':
                     {
                             ans += float.Parse(val[i + 1]);
                             break;
                     }
                     case '-':
                     {
                             ans -=  float.Parse(val[i + 1]);
                             break;
                     }
                     case '*':
                         {
                             ans *= float.Parse(val[i + 1]);
                             break;
                         }
                     case'/':
                     {       
                             ans /=  float.Parse(val[i + 1]);

                             break;
                     }

                 }
             }

             for(i =0; i<val.Count; i++)
             {
                 tmp1 = tmp1 + val[i] + " ";

             }
             MessageBox.Show(tmp1);
             textbox1.Text = ans.ToString();


         }
       
        
        //evalution 2 attempt
        //test case 1 + 2*3 - 4*5
        by priority do * or / first
          so string becomes 1 + 6 - 20 
          */


        //evaluation 2nd attempt 
        /*private void evaluate(String a)
        {


            bool start = true, end = false;
            string s = "";
            int i = 0, size_string = a.Count();
            s = "";


            a = a.Insert(0, "(");
            a = a.Insert(size_string + 1, ")");
            int c = 0;

            for (i = 0; i < size_string; i++)
            {
                if (a[i + c] == '+' || a[i + c] == '-')
                {
                    a = a.Insert(i + c + 1, "(");
                    a = a.Insert(i + c, ")");
                    c = c + 2;
                }

            }
            size_string = a.Count();
            string val1 = "",op="";

            int c1 = 0;
            float tmp = 1, sum = 0;
            
            i = 0;



            while (i < size_string)
            {
                if (a[i] == '(')
                {
                    start = true;
                    end = false;
                    i++;
                }
                else if (a[i] == ')')
                {

                    start = false;
                    end = true;
                    

                }
                

                //inserting number in val1
                if (a[i] > 45 && a[i] < 59 && a[i] != 47 && end == false)
                {
                    
                    val1 = val1.Insert(c1, a[i].ToString());
                    c1++;

                }
                //checking if a[i] is '/' or '*' ignores '+' and '-'
                if (a[i] < 45 || end == true)
                {

                    c1 = 0;
                    if (val1 != "")
                    {
                        if (a[i] == '*')
                        {
                            op = "*";
                            tmp *= float.Parse(val1);
                        }
                        else if (a[i] == '/')
                        {
                            op = "/";
                            tmp /= float.Parse(val1);
                        }

                    }
                    
                    val1 = "";
                }
                

                
                //adding or subtracting previous
                switch (a[i].ToString())
                {
                    case "+":
                        {
                            sum += tmp;
                            tmp = 1;
                            op = "+";
                            break;
                        }
                    case "-":
                        {
                            sum -= tmp;
                            tmp = 1;
                            op = "-";
                            break;
                        }
                    default:
                        {

                            break;
                        }


                }

                //MessageBox.Show(val1);
               
                if (i == size_string - 1 && end == true)
                {
                    if (op == "+")
                    {
                        sum += tmp;
                    }
                    else if (op == "-")
                    {
                        sum -= tmp;
                    }
                    

                }
                i++;
            }


            textbox1.Text = sum.ToString();

            
        }*/

        //evalutaion 3rd attempt
        /*private float evaluate(String a)
        {
            Stack<char> op = new Stack<char>();
            Stack<float> val = new Stack<float>();
            float number=1;
            int i = 0;
            int size = a.Length;
            
            a = a.Insert(0, "(");
            a = a.Insert(size + 1, ")");
            ;
            int c = 0;
            size = a.Length;
            for ( i = 0; i < size; i++)
            {
                if (a[i + c] == '+' || a[i + c] == '-')
                {
                    a = a.Insert(i + c + 1, "(");
                    a = a.Insert(i + c, ")");
                    c = c + 2;
                }
            }
            //input values with decimal if required 
            i = 0;
            float sum = 0;
            string tmp = "";
            for( i =0; i<size; i++)
            {
                
                if (char.IsDigit(a[i]))
                {
                    number = 0;
                    while (i<size && (char.IsDigit(a[i])|| a[i] == '.'))
                    {
                        if (a[i] == '.')
                        {
                            i++;
                            float decimal_part = 0;
                            while (i<size && char.IsDigit(a[i])){
                                decimal_part += (a[i] - '0')/10;

                            }
                            number += decimal_part;
                            break;
                        }else
                        {
                            number = number * 10 + (a[i] - '0');
                            i++;
                        }
                    }
                    i--;
                    val.Push(number);
                }
                else if (a[i] =='(')
                {
                    op.Push('(');
                }else if (a[i] == ')')
                {
                    while (op.Peek() != '(')
                    {
                        val.Push(arthematic(val.Pop(), val.Pop(), op.Pop()));
                    }
                    op.Pop();
                }
                else if (a[i] =='+' || a[i]=='/' || a[i] == '*' || a[i] == '-')
                {
                    while(op.Count()>0 && Precedence(op.Peek()) >= Precedence(a[i])){
                        val.Push(arthematic(val.Pop(), val.Pop(), op.Pop()));
                    }
                    op.Push(a[i]);
                }
            }
            while (op.Count>0)
            {
                val.Push(arthematic(val.Pop(), val.Pop(), op.Pop()));
            }
            return val.Pop();
        }*/

        //evalution 4th attempt 
        private int evaluate(String a)
        {



            return 0;
        }

    }


}