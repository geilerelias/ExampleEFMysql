using LayerDomain.Entities;
using LayerInfraestructura.Data.Base;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infraestructure.Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MysqlContext : DbContextBase
    {
        public MysqlContext() : base("Name=MysqlContext")
        {

        }
        protected MysqlContext(DbConnection connection)
          : base(connection)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
