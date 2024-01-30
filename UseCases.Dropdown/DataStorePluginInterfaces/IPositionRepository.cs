using CoreBusiness.Dropdown;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public interface IPositionRepository
    {
        List<Position> GetPosition();
    }
}