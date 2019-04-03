using Infraestructure.Data;
using Infraestructure.Data.Repositories;
using LayerApplications.Implements;
using LayerDomain.Entities;
using SirccELC.Infraestructura.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LayerInterface
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MysqlContext context = new MysqlContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            CountryService service = new CountryService(new UnitOfWork(context), new CountryRepository(context));
            Country country = new Country() { Name = TextBoxNombre.Text };
            service.Create(country);
            ActualizarGrilla();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            CountryService service = new CountryService(new UnitOfWork(context), new CountryRepository(context));
            DataGridCountry.ItemsSource = null;
            DataGridCountry.UpdateLayout();
            List<Country> countries = service.GetAll().ToList();
            DataGridCountry.ItemsSource = countries;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow personWindow = new PersonWindow();
            personWindow.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            PersonasPaisesWindow personasPaises = new PersonasPaisesWindow();
            personasPaises.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
        }
    }

}

