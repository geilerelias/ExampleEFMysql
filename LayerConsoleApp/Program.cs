using Infraestructure.Data;
using Infraestructure.Data.Repositories;
using LayerApplications.Implements;
using LayerDomain.Entities;
using SirccELC.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MysqlContext context = new MysqlContext();
            do
            {
                System.Console.Clear();
                System.Console.WriteLine("MENU PRINCIPAL");
                System.Console.WriteLine("1º) Country");
                System.Console.WriteLine("2º) Person");
                System.Console.WriteLine("3º) Salir");
                System.Console.Write("Seleccione una opción:  ");
                int opcion = System.Console.Read();
                switch (opcion)
                {
                    case '1': MenuCountry(context); break;
                    case '2': MenuPerson(context); break;
                    case '3': Salir(); break;
                    default:
                        break;
                }
            } while (true);

        }

        private static void Salir()
        {
            Environment.Exit(0);
        }

        private static void MenuPerson(MysqlContext context)
        {
            PersonService service = new PersonService(new UnitOfWork(context), new PersonRepository(context));
            char seguir = 's';
            do
            {
                System.Console.Clear();
                System.Console.WriteLine("MENU PERSON");
                System.Console.WriteLine("1º) Crear Person");
                System.Console.WriteLine("2º) Eliminar Person");
                System.Console.WriteLine("3º) Listar Person");
                System.Console.WriteLine("4º) Regresar");
                System.Console.Write("Seleccione una opción:  ");


                switch (System.Console.Read())
                {
                    case '1':
                        System.Console.Clear();
                        System.Console.WriteLine("Crear Person");
                        #region  Crear Person
                        System.Console.ReadLine();
                        System.Console.Write("Digite el nombre: ");
                        string NamePerson = System.Console.ReadLine();
                        System.Console.Write("Digite el estado: ");
                        string StatePerson = System.Console.ReadLine();
                        System.Console.Write("Digite la direccion: ");
                        string AddressPerson = System.Console.ReadLine();
                        System.Console.Write("Digite el id del country: ");
                        int CountryIdPerson = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.Write("Digite el telefono: ");
                        string PhonePerson = System.Console.ReadLine(); ;




                        Person Person = new Person() { Name = NamePerson, Address = AddressPerson, CountryId = CountryIdPerson, Phone = PhonePerson, State = StatePerson };

                        service.Create(Person);

                        #endregion
                        System.Console.ReadKey();
                        // Continuar lógica y extraer métodos //
                        break;
                    case '2':
                        System.Console.Clear();
                        System.Console.WriteLine("Listar Person");
                        #region  Listar Person
                        List<Person> countries = service.GetAll().ToList();

                        for (int i = 0; i < countries.Count; i++)
                        {
                            Person item = countries[i];
                            System.Console.WriteLine($"{i}) { item.Name}");
                        }
                        #endregion

                        System.Console.WriteLine("Eliminar Person");
                        #region  Eliminar Person
                        string nombre = System.Console.ReadLine();
                        Person coun = service.Find(nombre);
                        service.Delete(coun);
                        #endregion
                        System.Console.ReadKey();
                        // Continuar lógica y extraer métodos //
                        break;
                    case '3':
                        System.Console.Clear();
                        System.Console.WriteLine("Listar Person");
                        #region  Listar Person
                        List<Person> people = service.GetAll().ToList();

                        for (int i = 0; i < people.Count; i++)
                        {
                            Person item = people[i];
                            System.Console.WriteLine($"{i}) { item.Name}");
                        }
                        #endregion
                        // Continuar lógica y extraer métodos //
                        System.Console.ReadKey();
                        break;
                    case '4':
                        System.Console.Clear();
                        System.Console.WriteLine("Regresando al principal..   ");
                        System.Console.ReadKey();
                        seguir = 'n';
                        break;
                }


            } while (seguir == 's');
        }

        static void MenuCountry(MysqlContext context)
        {

            CountryService service = new CountryService(new UnitOfWork(context), new CountryRepository(context));
            char seguir = 's';
            do
            {
                System.Console.Clear();
                System.Console.WriteLine("MENU COUNTRY");
                System.Console.WriteLine("1º) Crear Country");
                System.Console.WriteLine("2º) Eliminar Country");
                System.Console.WriteLine("3º) Listar Country");
                System.Console.WriteLine("4º) Regresar");
                System.Console.Write("Seleccione una opción:  ");
                switch (System.Console.Read())
                {
                    case '1':
                        System.Console.Clear();
                        System.Console.WriteLine("Crear Country");
                        #region  Crear Country
                        System.Console.ReadLine();
                        string texto = System.Console.ReadLine();
                        Country country = new Country() { Name = texto };

                        service.Create(country);

                        #endregion
                        System.Console.ReadKey();
                        // Continuar lógica y extraer métodos //
                        break;
                    case '2':
                        System.Console.Clear();
                        System.Console.WriteLine("Eliminar Country");
                        #region  Eliminar Country
                        string nombre = System.Console.ReadLine();
                        Country coun = service.Find(nombre);
                        service.Delete(coun);
                        #endregion
                        System.Console.ReadKey();
                        // Continuar lógica y extraer métodos //
                        break;
                    case '3':
                        System.Console.Clear();
                        System.Console.WriteLine("Listar Country");
                        #region  Listar Country
                        List<Country> countries = service.GetAll().ToList();
                        foreach (var item in countries)
                        {
                            System.Console.WriteLine(item.Name);
                        }
                        #endregion
                        // Continuar lógica y extraer métodos //
                        System.Console.ReadKey();
                        break;
                    case '4':
                        System.Console.Clear();
                        System.Console.WriteLine("Regresando al principal..   ");
                        System.Console.ReadKey();
                        seguir = 'n';
                        break;
                }


            } while (seguir == 's');
        }
    }

    public class PersonReques
    {
        public string NamePerson { get; set; }
        public string StatePerson { get; set; }
        public string AddressPerson { get; set; }
        public int CountryIdPerson { get; set; }
        public string PhonePerson { get; set; }
    }

}
