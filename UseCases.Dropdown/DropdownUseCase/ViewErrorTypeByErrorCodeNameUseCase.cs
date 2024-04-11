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
    public class ViewErrorTypeByErrorCodeNameUseCase : IViewErrorTypeByErrorCodeNameUseCase
    {
        private readonly IErrorTypeRepository _errorTypeRepository;

        public ViewErrorTypeByErrorCodeNameUseCase(IErrorTypeRepository errorTypeRepository)
        {
            _errorTypeRepository = errorTypeRepository;
        }

        public List<ErrorType> Execute(string errorCode)
        {
            return _errorTypeRepository.GetErrorTypeByErrorCodeName(errorCode);
        }

    }
}
