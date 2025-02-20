
using System;
using System.Collections.Specialized;
using System.Transactions;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Navigation;
using static System.Net.Mime.MediaTypeNames;



namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        double pi = 3.141592;
        double e = 2.7182818;
        
        bool Isarth = false;
        
         Stack<double> val = new Stack<double>();
         Stack<string> op = new Stack<string>();
        public MainWindow()
        {
            InitializeComponent();
        }
        public double ans = 0;

        public int multi = 10;

        public static readonly double[] jumptable = new double[] {
            0.7853981633974483,   // n = 0
    0.4636476090008061,   // n = 1
    0.24497866312686414,  // n = 2
    0.12435499454676144,  // n = 3
    0.06241880999595735,  // n = 4
    0.031239833430268277, // n = 5
    0.015623728620476831, // n = 6
    0.007812341060101111, // n = 7
    0.0039062301319669718,// n = 8
    0.0019531225164788188,// n = 9
    0.0009765621895593195,// n = 10
    0.0004882812111948983,// n = 11
    0.00024414062014936177,// n = 12
    0.00012207031189367021,// n = 13
    6.103515617420877e-05,  // n = 14
    3.0517578115526096e-05, // n = 15
    1.5258789061315762e-05, // n = 16
    7.62939453110197e-06,   // n = 17
    3.814697265606496e-06,  // n = 18
    1.907348632810187e-06,  // n = 19
    9.536743164059608e-07   // n = 20
        
        
        
        };

        public static readonly double[] jumptalbe_deg = new double[] {
        45.0,
 26.56505117707799,
 14.036243467926477,
 7.125016348901798,
 3.5763343749973515,
 1.7899106082460694,
 0.8951737102110744,
 0.44761417086055305,
 0.22381050036853808,
 0.1119056770662069,
 0.05595289189380367,
 0.027976452617003676,
 0.013988227142265016,
 0.006994113675352918,
 0.0034970568507040113,
 0.0017485284269804495,
 0.0008742642136937803,
 0.00043713210687233457,
 0.00021856605343934784,
 0.0001092830267200715,
 5.464151336008544e-05

        };


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
            double ans;
            switch (a) {
                case 101:
                    {

                        ans = evaluate(text);
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
                case 109:
                    {
                        textbox1.Text += "!";
                        break;
                    }


            }

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
        private double atan(double a)
        {
            double x = 1, y = a;
            double finalangle = 0;
            double x1, y1;
            for(int i =0; i<20; i++)
            {
                int d = y > 0 ? -1 : 1;
                x1 = x - d * y / (1 << i);
                y1 = y + d * x / (1 << i);
                if (d < 0) finalangle +=jumptable[i];
                else finalangle -=jumptable[i];
                x = x1;
                y = y1;


            }
            return finalangle;
        }
        
        private double inverse_trig(double a, string op)
        {
            int d = 1;
            switch (op) {
                case "atan":
                    {
                        return atan(a);
                    }
                case "asin": {
                        if (a == 1) return Math.PI/2;
                        else if (a == -1) return -Math.PI/2;

                        if (a < 1 || a > -1)
                        {   
                            return d*atan(a / expontential(1 - a * a, 0.5));
                        }
                        break;
                    }
                case "acos":
                    {
                        if (a == 1) return 0;
                        else if (a == -1) return Math.PI;

                        if (a < 1 || a > -1)
                        {       
                                return Math.PI / 2 - atan(a / expontential(1 - a * a, 0.5));
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            
            }
            return -1;

        }

        private double hyper_trig(double a, string op)
        {
            double x = expontential(e, a);
            double y = 1 / x;

            switch(op)
            {

                case "sinh": { return (x - y) / 2; }
                case "cosh": { return (x + y) / 2; }
                case "tanh": { return (x * x - 1) / (x * x + 1); }
                
            };

            return -1;
        }

        private double inv_hyper_trig(double a, string op)
        {
            
            
            switch (op) {
                case "asinh":{return logarithmic(a + expontential(1 + a * a, 0.5), "ln");  }
                case "acosh": {  return logarithmic(a + expontential(-1 + a * a, 0.5), "ln"); }
                case "atanh": { if (a < -1 || a > 1) return 0; return logarithmic((1 + a) / (1-a), "ln")*0.5;}
            }

            return -1;

        }

        private double new_trignometery(double a, string op)
        {
            //using cordic system

            double x = 0.607252935,y=0,phi = a,change=1;
            int d,c=0;
            double x1, y1;


            phi = phi % (2 * Math.PI);
            while(phi > Math.PI / 2)
            {
                phi = Math.PI - phi;
            }
            while (phi < -Math.PI / 2)
            {
                phi = -Math.PI - phi;
            }

            while(c<20 && change > 1e-7)
            {
                d = Math.Sign(phi);
                x1 = x - (d * y / (1 << c));
                y1 = y + (d * x / (1 << c));
                phi -= d * jumptable[c];
                change = Math.Abs(x1 - x) + Math.Abs(y1-y);
                x = x1;
                y = y1;
                c++;
            }

            return op switch 
            {
                "sin" => y,
                "cos" => x,
                "tan" => y / x,
                _ => throw new Exception("invalid")
            };
            
        }

        private double logarithmic(double x, string op)// x = y*2^k
        {

            double K,y,z,z2,power;
            ans = 0;
            int i = 1;
            switch (op) {
                case "ln":
                    {
                        //funtion to calculate ln
                        K = 0;
                        y = x;
                        while (y > 2)
                        {
                            y /= 2;
                            K += 0.6931471;
                        }
                        while (y < 1)
                        {
                            y *= 2;
                            K -= 0.6931471;
                        }

                        z = (y - 1) / (y + 1);
                        z2 = z * z;
                        power = z;
                        i = 1;
                        while (i < 2 * 30)
                        {
                            ans += power / i;
                            power *= z2;
                            i += 2;
                        }
                        return 2 * ans + K;

                    }
                case "log":
                    {
                        K = 0;
                        y = x;
                        while (y > 2)
                        {
                            y /= 2;
                            K += 0.6931471;
                        }
                        while (y < 1)
                        {
                            y *= 2;
                            K -= 0.6931471;
                        }
                        
                        z = (y - 1) / (y + 1);
                        
                        z2 = z * z;
                        ans = 0;
                        power = z;
                        i = 1;
                        while (i < 2 * 30)
                        {
                            ans += power / i;
                            power *= z2;
                            i += 2;
                        }
                        return (2 * ans + K)*0.4342944;
                    }
        }
            return 0;
        }
        private double exp(double x,double y)
        {
            ans = 1;
            while (y > 0) //loops till y !=0
            {
                if (y % 2 == 1)//checks if y is odd if so
                {
                    ans *= x; //muliples ans x so ans = x*ans
                }
                x *= x;//squares x -> x^2
                y = (int)y / 2;//divides y by 2 
            }
            
            return ans;
        }
        private double exp_e(double x)
        {
            return 1 + exp(x, 1) + exp(x, 2) * 0.5 + exp(x, 3) * 0.16666 + 
                exp(x, 4) * 0.041667+exp(x,5)*0.00833 + exp(x,6)*0.001388;

        }
        private double expontential(double x, double y) //x^y
        {
            ans = 1;
            if (x == 0 && y!=0)
            {
                ans = 0;
            }else if(x==0 && y == 0)
            {
                throw new Exception("invlaid");
            }else if(x!=0 && y == 0)
            {
                return ans;
            }

            if (y == (int)y) // check if integer
            {
                
                /*
                    if 2^10
                    not odd 2 -> 2^2 = 4 & 10 -> 5
                    4^5
                    odd ans = 1 => ans*4 4->16 & 5->2.5 -> 2
                    16^2 
                    not odd 16 -> 256 & 2->1
                    256^1
                    odd ans = 4 => ans*256 256->1024 & 1->0

                    ans = 1024

                */
                while (y > 0) //loops till y !=0
                {
                    if (y % 2 == 1)//checks if y is odd if so
                    {
                        ans *= x; //muliples ans x so ans = x*ans
                    }
                    x *= x;//squares x -> x^2
                    y = (int)y / 2;//divides y by 2 
                }
            }
            else
            {
                /*
                 x^(1/n) = z
                log(z) = log(x)/n
                z = e^(log(x)/n)
                compute log(x) first then divide it by n or if fraction multiply it then compute e^() for finaly result
                 
                 */
                if (y == 0 && x == 0) throw new Exception("undefined");
                if (x < 0 && y % 2 == 0) throw new Exception("even roots of neg number is undefined");

                return exp_e(logarithmic(x,"ln") *y);
                
               

                }
            return ans;
        }
        private double factorial(double x)
        {
            ans=1;
            while (x > 0)
            {
                ans = x*ans;
                x--; 
            }
            return ans;
        }
        private void check_op()
        {
            Isarth = false;

            switch (op.Peek()) {

                case "sin":
                    {
                        
                        
                        val.Push(new_trignometery(val.Pop(), op.Peek()));
                        break;
                    }
                case "cos":
                    {
                       
                        val.Push(new_trignometery(val.Pop(), op.Peek()));
                        break;
                    }
                case "tan":
                    {
                        
                        val.Push(new_trignometery(val.Pop(), op.Peek()));
                        break;
                    }
                case "!":
                    {
                        
                        val.Push(factorial(val.Peek()));
                        op.Pop();
                        break;
                    }
                case "abs":
                    {
                        
                        ans = val.Pop();
                        if (ans < 0)
                        {
                            ans = -ans;
                        }
                        val.Push(ans);
                        
                        break;
                    }
                
                case "log":
                    {
                        
                        val.Push(logarithmic(val.Pop(), op.Peek()));
                        break;
                    }
                case "ln":
                    {

                        
                        val.Push(logarithmic(val.Pop(), op.Peek()));
                        break;
                    }
                case "sinh":
                    {
                        val.Push(hyper_trig(val.Pop(), op.Peek()));
                        break;
                    }
                case "cosh":
                    {
                        val.Push(hyper_trig(val.Pop(), op.Peek()));
                        break;
                    }
                case "tanh":
                    {
                        val.Push(hyper_trig(val.Pop(), op.Peek()));
                        break;
                    }
                case "asinh":
                    {
                        val.Push(inv_hyper_trig(val.Pop(), op.Peek()));
                        break;
                    }
                case "acosh":
                    {
                        val.Push(inv_hyper_trig(val.Pop(), op.Peek()));
                        break;
                    }
                case "atanh":
                    {
                        val.Push(inv_hyper_trig(val.Pop(), op.Peek()));
                        break;
                    }
                case "atan":
                    {
                        val.Push(inverse_trig(val.Pop(), op.Peek()));
                        break;
                    }
                case "asin":
                    {
                        val.Push(inverse_trig(val.Pop(), op.Peek()));
                        break;
                    }
                case "acos":
                    {
                        val.Push(inverse_trig(val.Pop(), op.Peek()));
                        break;
                    }
                default:
                    {
                        Isarth = true;
                        break;
                    }


            }



        }

        //arthematic funtion
        private double arthematic(double prev,double next, string p)
        {
            
            switch (p) {
                case "+": {
                        return prev + next;
                    }
                case "-":
                    {
                        return prev - next;
                    }
                case "*":
                    {
                        return prev * next;
                    }
                case "/":
                    {
                        if(next == 0)
                        {
                            throw new InvalidOperationException("cant divide by zero");
                        }
                        else
                        return prev / next;

                    }
                case "^":
                    {
                        return expontential(prev,next);
                    }
                
                default:
                    {
                        throw new Exception("Invalid operator");
                    }

            }

        }

        private static readonly Dictionary<string, int> pre = new Dictionary<string, int>() {
        { "+", 1 }, { "-", 1 }, { "*", 2 }, { "/", 2 }, { "^", 3 },
        { "sin", 4 }, { "cos", 4 }, { "tan", 4 },
            {"atan",4},{"asin",4},{"acos",4},
            { "ln", 4 }, { "log", 4 },
            {"sinh",4},{"cosh",4},{"tanh",4},
            {"asinh",4 },{"acosh",4},{"atanh",4}

        };

        private int Precedence1(string op)
        {
            if (op == "(" || op==")")
            {
                return -1;
            }
            else
            {

                if (pre[op] <= 3)
                {
                    Isarth = true;
                }
                else
                {
                    Isarth = false;
                }
            }
            return pre.ContainsKey(op) ? pre[op] : -1;
            
        }
        //evalution 5th attempt
        private double evaluate(String a)
        {
            //(1+(2*3))
            
            
            string tmp="";
            bool Isdec = false;
            
            
            bool isNeg = false;
            double number = 0,decimal_pointer=1;

            int size = a.Length;

            for (int i = 0; i < size; i++)
            {
                
                if (a[i] == '-' && a[i-1]=='(')
                {
                    i++;
                    isNeg = true;
                }
                if (char.IsWhiteSpace(a[i])) continue; //checks for whitespaces
                //if it encounters "("
                if (a[i] == '(')
                {
                    op.Push("("); // pushes it top of op stack
                }
                else if (a[i] == ')') //if it encounters ")" 
                {
                    //evaluates whats in between the brackets if the top of op stack is "("
                    while (op.Count > 0 && Precedence1(op.Peek()) >= Precedence1(a[i].ToString()))
                    {
                        check_op();

                        if (val.Count >= 2 && op.Peek() != "(" && Isarth==true)
                        {
                            double r = val.Pop();
                            double s = val.Pop();
                            val.Push(arthematic(s, r, op.Peek()));
                        }
                        
                        op.Pop();
                    }
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
                    if (isNeg)
                    {
                        number = -number;
                        isNeg = false;
                    }

                    
                    val.Push(number);
                    
                }
                else //pushes encountered operator in op stack checking the priority 
                {
                    Isarth = true;
                    if (char.IsAsciiLetter(a[i]))
                    {
                        Isarth = false;
                        if (a[i] == 'e')
                        {
                            val.Push(e);
                        }
                        else
                        {
                            tmp += a[i];
                        }

                        if (a[i + 1] == '(')
                        {
                            op.Push(tmp);
                            tmp = "";
                        }

                    }
                    else
                    {
                        while (op.Count > 0 && Precedence1(op.Peek()) >= Precedence1(a[i].ToString()))
                        {
                            check_op();
                            if (val.Count >= 2 && op.Peek() != "(" && Isarth==true)
                                {
                                    double r = val.Pop();
                                    double s = val.Pop();
                                    val.Push(arthematic(s, r, op.Peek()));
                                }
                                
                            
                            op.Pop();
                        }
                        op.Push(a[i].ToString());
                        
                    }
                }
            }
            //evalutes remaining operators outside the bracket
            //if (op.Count == 0) throw new InvalidOperationException("invaild inputs");
            while (op.Count >0)
            {
                check_op();

                if (val.Count >= 2 && op.Peek() != "(" && Isarth == true)
                {

                    double r = val.Pop();
                    double s = val.Pop();
                    val.Push(arthematic(s, r, op.Peek()));
                }
                
                op.Pop();
            }
            ans = val.Pop();
            ans=Math.Round(ans,5);
            return ans; //only answers remains in the val stack
        }

    }


}

    