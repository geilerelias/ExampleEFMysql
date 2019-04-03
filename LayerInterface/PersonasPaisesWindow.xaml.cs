using Infraestructure.Data;
using Infraestructure.Data.Repositories;
using LayerApplications.Implements;
using LayerDomain.Entities;
using SirccELC.Infraestructura.Data;
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

namespace LayerInterface
{
    /// <summary>
    /// Lógica de interacción para PersonasPaisesWindow.xaml
    /// </summary>
    public partial class PersonasPaisesWindow : Window
    {

        MysqlContext context = new MysqlContext();
        public PersonasPaisesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarCombobox();
        }

        private void CargarCombobox()
        {
            CountryService service = new CountryService(new UnitOfWork(context), new CountryRepository(context));
            ComboBoxCountry.ItemsSource = null;
            ComboBoxCountry.UpdateLayout();
            List<Country> countries = service.GetAll().ToList();
            foreach (var item in countries)
            {
                ComboBoxCountry.Items.Add(item.Name);
            }
        }

        private void ComboBoxCountry_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            CargarGrilla(ComboBoxCountry.Text);
        }

        private void CargarGrilla(string countryName)
        {
            CountryService service = new CountryService(new UnitOfWork(context), new CountryRepository(context));
            Country country = service.GetAll().ToList().Find(x => x.Name == countryName);
            PersonService servicePerson = new PersonService(new UnitOfWork(context), new PersonRepository(context));
            DataGridCountry.ItemsSource = null;
            DataGridCountry.UpdateLayout();
            List<Person> countries = servicePerson.GetAll().ToList().FindAll(x => x.CountryId == country.Id);
            DataGridCountry.ItemsSource = countries;
        }

    }
}
