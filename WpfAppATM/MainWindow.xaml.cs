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
        int[] resultado = new int[3];

        List<Cedula> cedulasNoCaixa = new List<Cedula> { 
            new Cedula() { Value = 10, Amount = 10, }, 
            new Cedula() { Value = 50, Amount = 10, },
            new Cedula() { Value = 100, Amount = 10, } 
        };

        public MainWindow()
        {
            InitializeComponent();


            nota10.Text = cedulasNoCaixa[0].Amount.ToString();
            nota50.Text = cedulasNoCaixa[1].Amount.ToString();
            nota100.Text = cedulasNoCaixa[2].Amount.ToString();
        }

        public static void FormatoMoeda(ref TextBox txt)
        {

            String n = string.Empty;
            int v = 0;
            try
            {

                v = Convert.ToInt32(n);
                txt.Text = String.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;

                /* n = txt.Text.Replace(",", "").Replace(".", "");
                 if (n.Equals(""))
                     n = "";
                 n = n.PadLeft(3, '0');
                 if (n.Length > 3 & n.Substring(0, 1) == "0")
                     n = n.Substring(1, n.Length - 1);
                 //v = Convert.ToDouble(n) / 100;
                 txt.Text = String.Format("{0:N}", v);
                 txt.SelectionStart = txt.Text.Length;
                 */
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
            //Result1.Text = resultado[2].ToString() ;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtResult.Clear();
            nota10.Clear();
            nota50.Clear();
            nota100.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void Button_Click_Enter(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            lblError.Content = string.Empty;

            var result = new Dictionary<int, Cedula>();

            try
            {

                int valorSaque;//260;
                if (!Int32.TryParse(txtResult.Text, out valorSaque))
                {
                    throw new Exception("Valor inválido!");
                }

                result = Operations.Withdraw(cedulasNoCaixa, valorSaque);
                //resultado = Operations.Withdraw(quantidade, valor, 3, valorSaque);
            }
            catch (Exception ex)
            {
                if (ex.Data.Contains("result") && typeof(Dictionary<int, Cedula>) == ex.Data["result"].GetType())
                {
                    result = (Dictionary<int, Cedula>) ex.Data["result"];
                    cedulasNoCaixa.FirstOrDefault(txt => txt.Value == 10).Amount += (result.ContainsKey(10) ? result[10].Amount : 0);
                    cedulasNoCaixa.FirstOrDefault(txt => txt.Value == 50).Amount += (result.ContainsKey(50) ? result[50].Amount : 0);
                    cedulasNoCaixa.FirstOrDefault(txt => txt.Value == 100).Amount += (result.ContainsKey(100) ? result[100].Amount : 0);
                }

                lblError.Content = ex.Message;
            }

            notasSacadas10.Text = (result.ContainsKey(10) ? result[10].Amount : 0).ToString();
            notasSacadas50.Text = (result.ContainsKey(50) ? result[50].Amount : 0).ToString();
            notasSacadas100.Text = (result.ContainsKey(100) ? result[100].Amount : 0).ToString();

            nota10.Text = cedulasNoCaixa.FirstOrDefault(txt => txt.Value == 10).Amount.ToString();
            nota50.Text = cedulasNoCaixa.FirstOrDefault(txt => txt.Value == 50).Amount.ToString();
            nota100.Text = cedulasNoCaixa.FirstOrDefault(txt => txt.Value == 100).Amount.ToString();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            cedulasNoCaixa.FirstOrDefault(txt => txt.Value == 10).Amount = Int32.Parse(nota10.Text);
            cedulasNoCaixa.FirstOrDefault(txt => txt.Value == 50).Amount = Int32.Parse(nota50.Text);
            cedulasNoCaixa.FirstOrDefault(txt => txt.Value == 100).Amount = Int32.Parse(nota100.Text);
        }
    }
}
