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

namespace trabajo_3.UI.Consulta
{
    /// <summary>
    /// Interaction logic for cConsulta.xaml
    /// </summary>
    public partial class cConsulta : Window
    {
        public cConsulta()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var data_1 = new List<Estudiante>();
            var data_2 = new List<Carrera>();

            if (FiltroComboBox.Text == "Estudiante")
            {
                if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))
                { //si no hay criterio, busco todos         
                    data_1 = EstudianteBLL.GetList(l => true);
                }
                else
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0:
                            data_1 = EstudianteBLL.GetList(l => l.Nombre.Contains(CriterioTextBox.Text));
                            break;
                    }
                }
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = data_1;

            }
            else
            {
                if (FiltroComboBox.Text == "Carrera")
                {
                    if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))
                    {
                        data_2 = CarreraBLL.GetList(l => true);
                    }
                    else
                    {
                        switch (FiltroComboBox.SelectedIndex)
                        {
                            case 0:
                                data_2 = CarreraBLL.GetList(l => l.Nombre.Contains(CriterioTextBox.Text));
                                break;
                        }
                    }

                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = data_2;
                }

            }
        }
    }
}
