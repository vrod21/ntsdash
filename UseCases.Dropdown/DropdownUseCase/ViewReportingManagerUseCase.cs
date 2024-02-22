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
    public class ViewReportingManagerUseCase : IViewReportingManagerUseCase
    {
        private readonly IReportingManagerRepository _managerRepository;

        public ViewReportingManagerUseCase(IReportingManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public List<ReportingManager> Execute()
        {
            return _managerRepository.GetReportingManager();
        }
    }
}
