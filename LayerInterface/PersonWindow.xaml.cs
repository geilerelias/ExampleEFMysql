using Infraestructure.Data;
using Infraestructure.Data.Repositories;
using LayerApplications.Implements;
using LayerDomain.Entities;
using Microsoft.Win32;
using SirccELC.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        MysqlContext context = new MysqlContext();


        public string Ruta { get; set; }

        public PersonWindow()
        {
            InitializeComponent();
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            PersonService service = new PersonService(new UnitOfWork(context), new PersonRepository(context));
            int countryId = ObtenerCountryId();
            Person Person = new Person()
            {
                Name = TextBoxName.Text,
                Phone = TextBoxPhone.Text,
                Address = TextBoxAddress.Text,
                State = TextBoxState.Text,
                CountryId = countryId,
                Imagen = File.ReadAllBytes(Ruta)
            };

            service.Create(Person);
            AtualizarGrilla();

            MessageBox.Show("Registro Guardado");
            TextBoxName.Text = string.Empty;
            TextBoxPhone.Text = string.Empty;
            TextBoxAddress.Text = string.Empty;
            TextBoxState.Text = string.Empty;
        }



        private int ObtenerCountryId()
        {
            string countryName = ComboBoxCountryId.Text;
            CountryService service = new CountryService(new UnitOfWork(context), new CountryRepository(context));
            Country country = service.GetAll().ToList().Find(x => x.Name == countryName);
            return country.Id;
        }

        private void AtualizarGrilla()
        {
            PersonService service = new PersonService(new UnitOfWork(context), new PersonRepository(context));
            DataGridPerson.ItemsSource = null;
            DataGridPerson.UpdateLayout();
            DataGridPerson.ItemsSource = service.GetAll().ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AtualizarGrilla();
            CargarCombobox();
        }

        private void CargarCombobox()
        {
            CountryService service = new CountryService(new UnitOfWork(context), new CountryRepository(context));
            ComboBoxCountryId.ItemsSource = null;
            ComboBoxCountryId.UpdateLayout();
            List<Country> countries = service.GetAll().ToList();
            foreach (var item in countries)
            {
                ComboBoxCountryId.Items.Add(item.Name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileObj = new OpenFileDialog()
            {
                Filter = "Imágenes|*.jpg;*.gif;*.png;*.bmp|All Files(*.*) | *.*"
            };
            OpenFileObj.ShowDialog();
            Ruta = OpenFileObj.FileName;
            ImageSource imgsource = new BitmapImage(new Uri(Ruta));
            ImagePerson.Source = imgsource;
        }

        public static BitmapImage ConvertByteArrayToBitmapImage(Byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
    }
}
