using CoreBusiness.Dropdown;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public interface IErrorTypeRepository
    {
        List<ErrorType> GetErrorTypeByErrorCodeName(string errorCode);
    }
}