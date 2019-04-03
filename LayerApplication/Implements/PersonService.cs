using LayerApplications.Base;
using LayerApplications.Contracts;
using LayerDomain.Abstracts;
using LayerDomain.Entities;

namespace LayerApplications.Implements
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IPersonRepository _personRepository;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository)
            : base(unitOfWork, personRepository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
        }

    }

}