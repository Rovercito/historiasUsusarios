using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace historiasUsusarios
{
    /// <summary>
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        string pathVentas = @"D:\textoProyecto\Venta.txt";
        string pathAux = @"D:\textoProyecto\auxiliar.txt";
        public Ventas()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.Text == "Licores")
            {
                MessageBox.Show("En desarrollo");
               // frame1.NavigationService.Navigate(new Page1());
            }
            if (ComboBox1.Text == "Cigarros")
            {
                MessageBox.Show("En desarrollo");
                //frame1.NavigationService.Navigate(new Cigarro());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ListBoxVenta.Items.Clear();
            string[] palabras;
            try
            {
                bool encontrado = false;
                StreamReader tuberia;
                tuberia = File.OpenText(pathVentas);
                string linea, separdor = "/";
                linea = tuberia.ReadLine();
                while (linea != null)
                {
                    palabras = Regex.Split(linea, separdor);
                    //ListBoxPrueba.Items.Add(palabras[0]+ "/" + palabras[1]+ "/"+ palabras[2]);
                    ListBoxVenta.Items.Add(linea);

                    linea = tuberia.ReadLine();

                }
                tuberia.Close();

            }
            catch (Exception)
            {
            }
            ListBoxVenta.Items.Remove("");
        }

        private void ButtinTotal_Click(object sender, RoutedEventArgs e)
        {
            string[] palabras;
            try
            {
                double precioTotal = 0;
                bool encontrado = false;
                StreamReader tuberia;
                tuberia = File.OpenText(pathVentas);
                string linea, separdor = "/";
                linea = tuberia.ReadLine();
                while (linea != null)
                {
                    palabras = Regex.Split(linea, separdor);
                    //ListBoxPrueba.Items.Add(palabras[0]+ "/" + palabras[1]+ "/"+ palabras[2]);
                    precioTotal = precioTotal + int.Parse(palabras[2]);
                    linea = tuberia.ReadLine();

                }
                tuberia.Close();
                MessageBox.Show(precioTotal.ToString() + "Bs.");
            }
            catch (Exception)
            {
            }
        }
    }
}
