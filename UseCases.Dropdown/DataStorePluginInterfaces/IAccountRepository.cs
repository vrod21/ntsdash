using CoreBusiness.Dropdown;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public interface IAccountRepository
    {
        List<Account> GetAccount();
    }
}