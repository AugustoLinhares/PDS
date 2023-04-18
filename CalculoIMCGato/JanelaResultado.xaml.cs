using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Lógica interna para JanelaResultado.xaml
    /// </summary>
    public partial class JanelaResultado : Window
    {
        public JanelaResultado()
        {
            InitializeComponent();

            if (JanelaCalculo.Retorno() == "abaixo")
            {
                Abaixo();
            }
            else if (JanelaCalculo.Retorno() == "ideal")
            {
                Ideal();
            }
            else if (JanelaCalculo.Retorno() == "acima")
            {
                Acima();
            }

        }

        JanelaCalculo calculoIMC = new JanelaCalculo();

        public void Abaixo()
        {
            txtResultado.Text += "abaixo do peso";
            txtIMC.Text += calculoIMC.ValorIMC() + ")";
            imgGato.Source = new BitmapImage(new Uri(@"/Imagens/gato_todo_lapeado.png", UriKind.Relative));
            imgGato.Margin = new Thickness(0, 150, 0, 0);
        }

        public void Ideal()
        {
            txtResultado.Text += "no peso ideal";
            txtIMC.Text += calculoIMC.ValorIMC() + ")";
            imgGato.Margin = new Thickness(0, -10, -80, 0);
            imgGato.Source = new BitmapImage(new Uri(@"/Imagens/capivara_bombada.png", UriKind.Relative));
            imgGato.Height = 600;
        }

        public void Acima()
        {
            txtResultado.Text += "acima do peso";
            txtIMC.Text += calculoIMC.ValorIMC() + ")";
            imgGato.Height = 500;
            imgGato.Source = new BitmapImage(new Uri(@"/Imagens/gato_gordo.png", UriKind.Relative));
            imgGato.Margin = new Thickness(0,50,0,0);
        }
    }
}
