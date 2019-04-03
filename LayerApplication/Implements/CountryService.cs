using LayerApplications.Base;
using LayerApplications.Contracts;
using LayerDomain.Abstracts;
using LayerDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LayerApplications.Implements
{

    public class CountryService : EntityService<Country>, ICountryService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ICountryRepository _countryRepository;

        public CountryService(IUnitOfWork unitOfWork, ICountryRepository countryRepository)
            : base(unitOfWork, countryRepository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
        }

    }

}