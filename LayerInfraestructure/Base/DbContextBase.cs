using System;
using System.Data.Common;
using System.Data.Entity;

namespace LayerInfraestructura.Data.Base
{

    public class DbContextBase : DbContext, IDbContext
    {
        public DbContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
        public DbContextBase(DbConnection connection)
          : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public Action<string> Log
        {
            get
            {
                return Database.Log;
            }
            set
            {
                Database.Log = value;
            }
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
