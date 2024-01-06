using CoreBusiness.Dropdown;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public interface IJournalRepository
    {
        List<Journal> GetJournalIdByPublisherName(string publisherName);
    }
}