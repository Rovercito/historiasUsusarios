using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

namespace historiasUsusarios
{
    /// <summary>
    /// Lógica de interacción para CrearUsuarios.xaml
    /// </summary>
    public partial class CrearUsuarios : Window
    {
        string path = @"D:\textoProyecto\Usuarios.txt";
        public CrearUsuarios()
        {
            InitializeComponent();
        }

        private void ButtonRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNombre.Text == "" && TextBoxPrimer.Text == "" && TextBoxSegundo.Text == "" && TextBoxCi.Text == "" && Password.Password == "")
            {
                MessageBox.Show("No puede dejar en blanco los espacios");
            }
            else
            {
                try
                {
                    //Vamos a usar la clase StreamWrite para crear el archivo
                    StreamWriter tuberia;
                    //Primero debemos de ver si ya existe
                    if (File.Exists(path))
                    {
                        tuberia = File.AppendText(path);
                        //el archivo existe:
                        //la estructura del archivo sera:
                        // nombre/carrera/semestre
                        tuberia.WriteLine(TextBoxNombre.Text + "/" + TextBoxPrimer.Text + "/" + TextBoxSegundo.Text + "/" + TextBoxCi.Text + "/" + Password.Password);
                        tuberia.Close();
                        MessageBox.Show("Nuevo Usuario creado con exito");
                    }

                    else
                    {
                        //no existe, hay que crearlo:
                        StreamWriter tuberiaCrear = File.CreateText(path);
                        tuberiaCrear.Close();
                        MessageBox.Show("Se creo el archivo con exito");

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error " + ex.Message);
                }
            }
            TextBoxNombre.Clear();
            TextBoxPrimer.Clear();
            TextBoxSegundo.Clear();
            TextBoxCi.Clear();
            Password.Clear();
        }

        private void ButtonReiniciar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("En desarrollo", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ButtonModificar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("En desarrollo", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
