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
using System.Windows.Shapes;


namespace CalculoIMCGato
{
    /// <summary>
    /// Lógica interna para JanelaCalculo.xaml
    /// </summary>
    public partial class JanelaCalculo : Window
    {
        public JanelaCalculo()
        {
            InitializeComponent();
        }

        public static double imc = 0;

        private void btnJanelaCalc_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtAltura.Text, out var altura) || !double.TryParse(txtPeso.Text, out var peso))
            {
                MessageBox.Show("nao ok");
            }
            else
            {
                imc = Convert.ToDouble(txtPeso.Text) / (Convert.ToDouble(txtAltura.Text) * Convert.ToDouble(txtAltura.Text));
                JanelaResultado janelaResultado = new JanelaResultado();
                janelaResultado.ShowDialog();
            }
        }

        public double ValorIMC()
        {
            return imc;
        }

        public static string Retorno()
        {
            string tipoIMC = "";

            if (imc < 18.5)
            {
                tipoIMC = "abaixo";
            }
            else if (imc >= 18.5 && imc <= 24.9)
            {
                tipoIMC = "ideal";
            }
            else if (imc >= 24.9)
            {
                tipoIMC = "acima";
            }

            return tipoIMC;
        }
    }
}
