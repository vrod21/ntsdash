using CoreBusiness.Dropdown;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public interface IPublisherRepository
    {
        List<Publisher> GetPublishers();
    }
}