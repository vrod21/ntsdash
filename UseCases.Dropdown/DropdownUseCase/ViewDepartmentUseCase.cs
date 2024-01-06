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
    public class ViewDepartmentUseCase : IViewDepartmentUseCase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public ViewDepartmentUseCase(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public List<Department> Execute()
        {
            return _departmentRepository.GetDepartment();
        }
    }
}
