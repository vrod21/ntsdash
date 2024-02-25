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
    public class ViewComponentUseCase : IViewComponentUseCase
    {
        private readonly IComponentRepository _componentRepository;

        public ViewComponentUseCase(IComponentRepository componentRepository)
        {
            _componentRepository = componentRepository;
        }

        public List<Component> Execute()
        {
            return _componentRepository.GetComponent();
        }
    }
}
