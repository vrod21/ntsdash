using CoreBusiness.Dropdown;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public interface IDepartmentRepository
    {
        List<Department> GetDepartment();
    }
}