
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
            string tag = "\0";

            return;

        }
        private void Print_Arthermatic_op(object sender, RoutedEventArgs e)
        {
            string tag = "1\0";
            if(sender is Button button)
            {   
                tag = button.Tag?.ToString();
            }
            int a = Int32.Parse(tag);
            switch (a) {
            case 101:
            {
                        textbox1.Text += equal.Content.ToString();
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

            default:
            {
                       return;
            }
        }

        }
        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
             
        }
    }
}