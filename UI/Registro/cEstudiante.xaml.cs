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
using trabajo_3.BLL;
using trabajo_3.Entidades;

namespace trabajo_3.UI.Registro
{
    /// <summary>
    /// Interaction logic for cEstudiante.xaml
    /// </summary>
    
    public partial class cEstudiante : Window
    {
        public cEstudiante()
        {
            InitializeComponent();
            
            var lista = EstudianteBLL.GetLista();
            consulta.ItemsSource = lista;
            
        }

        private void guardar_Click(object sender, RoutedEventArgs e)
        {
            Estudiante estudiante= new  Estudiante (int.Parse(estudiantes.Text),Nombre.Text,email.Text,int.Parse(Carreraid.Text));
            if (!EstudianteBLL.Existes(int.Parse(estudiantes.Text)))
            {
                var paso = EstudianteBLL.Insertar(estudiante);
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            var lista = EstudianteBLL.GetLista();
            consulta.ItemsSource = lista;
        }

        private void editar_Click(object sender, RoutedEventArgs e)
        {
            Estudiante estudiante= new  Estudiante (int.Parse(estudiantes.Text),Nombre.Text,email.Text,int.Parse(Carreraid.Text));
            var paso = EstudianteBLL.Existe(estudiante,int.Parse(estudiantes.Text));
            if (paso)
            {
                MessageBox.Show("FUE EDITADO CON EXITO", "Exito",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ERROR DE EDICION", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var lista =EstudianteBLL.GetLista();
            consulta.ItemsSource = lista;
        }

        private void eliminar_Click(object sender, RoutedEventArgs e)
        {
            
            if (EstudianteBLL.Eliminar(int.Parse(estudiantes.Text)))
            {
                MessageBox.Show("FUE ELIMINADO CON EXITO", "Exito",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ERROR", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var lista = EstudianteBLL.GetLista();
            consulta.ItemsSource = lista;
        }
    }
}
