using CoreBusiness.Dropdown;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public interface IErrorLocationRepository
    {
        List<ErrorLocation> GetErrorLocation();
    }
}