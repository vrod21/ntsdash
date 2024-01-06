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
    public class ViewErrorLocationUseCase : IViewErrorLocationUseCase
    {
        private readonly IErrorLocationRepository _errorLocationRepository;

        public ViewErrorLocationUseCase(IErrorLocationRepository errorLocationRepository)
        {
            _errorLocationRepository = errorLocationRepository;
        }

        public List<ErrorLocation> Execute()
        {
            return _errorLocationRepository.GetErrorLocation();
        }
    }
}
