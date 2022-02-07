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
    /// Interaction logic for cCarrera.xaml
    /// </summary>
    public partial class cCarrera : Window
    {
        public cCarrera()
        {
           InitializeComponent();
           var consultas = CarreraBLL.GetLista();
           consulta_2.ItemsSource = consultas;
        }
    
        private void guardar_Click(object sender, RoutedEventArgs e)
        {
            Carrera carreras = new Carrera (int.Parse(carreraid.Text),Carreras.Text);
            if (!CarreraBLL.Existes(int.Parse(carreraid.Text)))
            {
                var paso = CarreraBLL.Insertar(carreras);
            }
            else
            {
                MessageBox.Show("ERROR DE REPETICION");
            }
            var consultas =CarreraBLL.GetLista();
            consulta_2.ItemsSource = consultas;
        }

        private void editar_Click(object sender, RoutedEventArgs e)
        {
            Carrera carreras = new Carrera (int.Parse(carreraid.Text),Carreras.Text);
            var paso = CarreraBLL.Existe(carreras,int.Parse(carreraid.Text));
            if (paso)
            {
                MessageBox.Show("Registro Editado ", "Exito",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se fue posible Editado ", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var consultas = CarreraBLL.GetLista();
            consulta_2.ItemsSource = consultas;
        }

        private void eliminar_Click(object sender, RoutedEventArgs e)
        { 
            if (CarreraBLL.Eliminar(int.Parse(carreraid.Text)))
            {
                MessageBox.Show("Registro Eliminado", "Exito",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var consultas = CarreraBLL.GetLista();
            consulta_2.ItemsSource = consultas;
        }
    }
}
