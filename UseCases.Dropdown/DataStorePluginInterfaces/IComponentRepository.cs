using CoreBusiness.Dropdown;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public interface IComponentRepository
    {
        List<Component> GetComponent();
    }
}