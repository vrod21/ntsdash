using DataAccessLibrary.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> GetPublisher();
    }
}
