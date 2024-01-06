using CoreBusiness.Dropdown;
using Plugins.DataStore.InMemory.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Dropdown.UseCaseInterfaces;

namespace UseCases.Dropdown.DropdownUseCase
{
    public class ViewQualityAssuranceUseCase : IViewQualityAssuranceUseCase
    {
        private readonly IQualityAssuranceRepository _qualityAssuranceRepository;

        public ViewQualityAssuranceUseCase(IQualityAssuranceRepository qualityAssuranceRepository)
        {
            _qualityAssuranceRepository = qualityAssuranceRepository;
        }

        public List<QualityAssurance> Execute()
        {
            return _qualityAssuranceRepository.GetQualiyAssurance();
        }
    }
}
