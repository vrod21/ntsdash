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
    public class ViewPositionUseCase : IViewPositionUseCase
    {
        private readonly IPositionRepository _positionRepository;

        public ViewPositionUseCase(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public List<Position> Execute()
        {
            return _positionRepository.GetPosition();
        }
    }
}
