using LayerDomain.Abstracts;
using LayerDomain.Entities;
using LayerInfraestructura.Data.Base;
using SirccELC.Infraestructura.Data.Base;

namespace Infraestructure.Data.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDbContext context)
              : base(context)
        {

        }

    }
}
