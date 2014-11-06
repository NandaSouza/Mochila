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

namespace WpfAppATM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();

            
        }

        public static void FormatoMoeda(ref TextBox txt)
        {

            String n = string.Empty;
            Double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = String.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;

            }
            catch (Exception) 
            { 
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            txtResult.Text = txtResult.Text + b.Tag;


            //txtResult.Text = txtResult.Text + b.Tag;
            //decimal valor = decimal.Parse(txtResult.Text + b.Tag);
            //txtResult.Text = String.Format(valor.ToString);

            //txtResult.Text = String.Format(txtResult.Text + b.Tag, "0.00");
            //txtResult.Text = convertido;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FormatoMoeda(ref txtResult);
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtResult.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }


      
        
    }
}
