using LayerDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerApplications.Base
{

    public interface IEntityService<T> : IService
        where T : BaseEntity
    {
        T Find(object id);
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
