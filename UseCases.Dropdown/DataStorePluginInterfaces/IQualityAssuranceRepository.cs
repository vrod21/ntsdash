using CoreBusiness.Dropdown;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public interface IQualityAssuranceRepository
    {
        List<QualityAssurance> GetQualiyAssurance();
    }
}