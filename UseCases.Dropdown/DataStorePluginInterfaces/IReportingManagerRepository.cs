using CoreBusiness.Dropdown;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public interface IReportingManagerRepository
    {
        List<ReportingManager> GetReportingManager();
    }
}