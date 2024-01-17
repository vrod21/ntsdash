using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public class DepartmentInMemoryRepository : IDepartmentRepository
    {
        private readonly List<Department> _department;
        public DepartmentInMemoryRepository()
        {
            _department = new List<Department>()
            {
                new Department { Id = 1, Name = "PE"},
                new Department { Id = 2, Name = "CE" },
                new Department { Id = 3, Name = "XML" },
                new Department { Id = 4, Name = "TS" },
                new Department { Id = 5, Name = "QC" },
                new Department { Id = 6, Name = "MC" },
                new Department { Id = 7, Name = "PE/CE" },
                new Department { Id = 8, Name = "TS/QC" },
                new Department { Id = 9, Name = "Others" },
            };
        }

        public List<Department> GetDepartment()
        {
            return _department;
        }
    }
}








