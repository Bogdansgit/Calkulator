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

namespace Calkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num1;
        double num2;
        string op = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string num = button.Content.ToString();

            if (txtValue.Text == "0")
                txtValue.Text = num;
            else
                txtValue.Text += num;

            if (op == "")
            {
                num1 = Double.Parse(txtValue.Text);
            }
            else
            {
                num2 = Double.Parse(txtValue.Text);
            }

        }


        private void btn_operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string str = button.Content.ToString();
            op = str;
            txtValue.Text = op;
        }

        private void btn_Equal_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
            switch (op)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "/": result = num1 / num2; break;
                case "min": result = Math.Min(num1, num2); break;
                case "max": result = Math.Max(num1, num2); break;
                case "avg": result = (num1 + num2) / 2; ; break;
                case "x^y": result = Convert.ToInt32(Math.Pow(num1, num2)); break;
            }
            txtValue.Text = result.ToString();
            op = " ";
            num1 = result;
            num2 = 0;
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            op = "";
            txtValue.Text = "0";
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            if(op == "")
            {
                num1 = 0; txtValue.Text = num1.ToString();
            }
            else
            {
                num2 = 0; txtValue.Text = num2.ToString();
            }
        }

        private void btn_plusminus_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
            {
                num1 *= -1; txtValue.Text = num1.ToString();
            }
            else
            {
                num2 *= -1; txtValue.Text = num2.ToString();
            }
        }

        private void btn_Backspase_Click(object sender, RoutedEventArgs e)
        {
            txtValue.Text = DropLastChar(txtValue.Text);
            if (op == "")
            {
                num1 = Double.Parse(txtValue.Text);
            }
            else
            {
                num2 = Double.Parse(txtValue.Text);
            }
        }

        private string DropLastChar(string text)
        {
            if (text.Length == 1) 
                text = "0";
            else
            {
                text = text.Remove(text.Length - 1, 1);
                if (text [text.Length - 1] == ',')
                {
                    text = text.Remove(text.Length - 1, 1);
                }
                   
            }
            return text;
        }

        private void btn_koma_Click(object sender, RoutedEventArgs e)
        {
            if (op == "") 
                SetKoma(num1);
            else 
                SetKoma(num2);
        }

        private void SetKoma(double num)
        {
            if (txtValue.Text.Contains(','))
                return;
            txtValue.Text += ',';
        }
    }
}

