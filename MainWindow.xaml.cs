
using System.Windows;
using System.Windows.Controls;



namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double pi = 3.141592;
        double e = 2.7182818;
         Stack<double> val = new Stack<double>();
         Stack<string> op = new Stack<string>();
        public MainWindow()
        {
            InitializeComponent();
        }
        public double ans = 0;

        public int multi = 10;
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
        private double trignometery(double a, string op)
        {

  
            switch (op) {

                case "sin":
                    {
                        a = a * pi * 0.005555;
                        double res = (a - (expontential(a, 3) * (0.1666667)) + (expontential(a, 5) * (0.0083333)) - (expontential(a, 7) * 0.0001984));
                        return res;

                    }
                case "cos":
                    {
                        a = a * pi * 0.005555;
                        double res = (1 - (expontential(a, 2) * 0.5) + (expontential(a, 4) * 0.0416667) - (expontential(a, 6) * 0.0013889));
                        return res;

                    }
                case "tan":
                    {
                        a = a * pi * 0.005555;
                        double res = (a + expontential(a, 3) * 0.3333334 + expontential(a, 5) * 0.1333334);
                        return res;
                    }

            
        }

            return 0;

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
                        while (i < 2 * 20)
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
                        while (i < 2 * 20)
                        {
                            ans += power / i;
                            power *= z2;
                            i += 2;
                        }
                        return (2 * ans + K) * 0.4343;
                    }
        }
            return 0;
        }
        private double expontential(double x, double y) //x^y
        { //add a flag
            double ans = 1;

            if(x == e)
            {
                while (y > 0)
                {
                    ans *= e;
                    y--;
                }

            }
            else
            {
                while (y > 0)
                {
                    ans *= x;
                    y--;
                }
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
            if (op.Peek() == "sin" || op.Peek() == "cos" || op.Peek() == "tan")
            {
                val.Push(trignometery(val.Pop(), op.Pop()));
            }
            else if (op.Peek() == "ln" || op.Peek() =="log")
            {
                val.Push(logarithmic(val.Pop(), op.Pop()));
            }
            else if (op.Peek() == "!")
            {
                val.Push(factorial(val.Pop()));
                
                op.Pop();
            }else if(op.Peek() == "^")
            {//error for e^(x!)
                double y = val.Pop();
                
                double x = val.Pop();
                val.Push(expontential(x, y));
                op.Pop();
            }
        }
        //arthematic funtion
        private double arthematic(double prev,double next, string op)
        {
            
            switch (op) {
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
                        return prev / next;
                    }
                

            }
            return 0;

        }
        private int Precedence1(string op)
        {
            if (op == "+" || op == "-") return 1;
            if (op == "*" || op == "/") return 2;
            if(op == "sin" || op=="cos"||op=="tan"||op =="log" ||op=="!")  return 3;
            if (op == "^") return 4;
            return 0;
        }
        //evalution 5th attempt
        private double evaluate(String a)
        {
            //(1+(2*3))
            
            
            string tmp="";
            bool Isdec = false;

            double number = 0,decimal_pointer=1;

            int size = a.Length;

            for (int i = 0; i < size; i++)
            {
                if (char.IsWhiteSpace(a[i])) continue; //checks for whitespaces
                //if it encounters "("
                if (a[i] == '(')
                {
                    op.Push("("); // pushes it top of op stack
                }
                else if (a[i] == ')') //if it encounters ")" 
                {
                   //evaluates whats in between the brackets if the top of op stack is "("
                    while (op.Count > 0 && (op.Peek() !="("))
                    {
                        check_op();
                        
                        if (val.Count >= 2)
                        {
                            double r = val.Pop();
                            double s = val.Pop();
                            val.Push(arthematic(s, r, op.Pop()));
                        }
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
                    if (char.IsAsciiLetter(a[i]))
                    {
                        if (a[i] == 'e')
                        {
                            val.Push(e);
                            
                        }
                        tmp += a[i];
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
                            if (val.Count >= 2)
                            {
                                
                                double r = val.Pop();
                                double s = val.Pop();
                                val.Push(arthematic(s, r, op.Pop()));
                            }
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
                if (val.Count >=2)
                {
                    
                    double r = val.Pop();
                    double s = val.Pop();
                    val.Push(arthematic(s, r, op.Pop()));
                }
            }
            return val.Pop(); //only answers remains in the val stack
        }

    }


}

    