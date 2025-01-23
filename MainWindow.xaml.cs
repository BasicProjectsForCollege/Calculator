
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ans="\0";
        int val;
        public MainWindow()
        {
            
            InitializeComponent();
            
        }

        private void Print_digits(object sender, RoutedEventArgs e)
        {
            string tag = "1\0";
            if(sender is Button button)
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
                        evaluate(text);
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
        
        private void evaluate(String a)
        {
            int size = a.Length,c=0;
            List<string> val = new List<string>();
            List<char> op = new List<char>();
            List<char> val1 = new List<char>();
            for (int i =0; i<size; i++)
            {
                if (a[i]<47 && a[i] >58)
                {
                    
                    op.Add(a[i]);
                }
                else
                {
                    val1.Add(a[i]);
                }
            }
            MessageBox.Show(val[0]);
        }

        
    }
}