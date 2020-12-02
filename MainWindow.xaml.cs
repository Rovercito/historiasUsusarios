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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;

namespace historiasUsusarios
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        string path = @"D:\textoProyecto\Usuarios.txt";
        string pathAux = @"D:\textoProyecto\auxiliar.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonIngresar_Click(object sender, RoutedEventArgs e)
        {
            string[] palabras;
            try
            {
                bool encontrado = false;
                StreamReader tuberia;
                tuberia = File.OpenText(path);
                string linea, separdor = "/";
                linea = tuberia.ReadLine();
                while (linea != null)
                {
                    palabras = Regex.Split(linea, separdor);
                    if (palabras[0] == TextBoxUsuario.Text && palabras[4] == PasswodBox1.Password)
                    {
                        encontrado = true;
                        Ventas v1 = new Ventas();
                        v1.Show();
                        this.Close();
                        break;
                    }
                    linea = tuberia.ReadLine();
                }
                tuberia.Close();
                if (!encontrado)
                {
                    MessageBox.Show("Usuario o password incorrecto");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string usuario = TextBoxUsuario.Text;
            string password = PasswodBox1.Password;
            if (usuario == "admin" && password == "admin")
            {
                CrearUsuarios v2 = new CrearUsuarios();
                v2.Show();
                TextBoxUsuario.Clear();
                PasswodBox1.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("usuario o password incorrecto");
            }   
        }

        private void TxbSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Realmente desea salir? SI/NO ", "Informacion", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void TxbConcepto_Click(object sender, RoutedEventArgs e)
        {
            
            {
                if (MessageBox.Show("Integrantes:" +
                    "\n Anthony Jhamil Omonte"+
                    "\n Rodrigo Alejandro Angulo"+
                    "\n Maria Magdalena Rodriguez Donaire"+
                    "\n Rover Serrano Quiroz"+
                    "\n Edilberto Aviles Zambrana"+
                    "\n  "+
                    "\n Desea contactarnos?","", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("http://www.google.com");
                }
            }
        }  
    }
}
