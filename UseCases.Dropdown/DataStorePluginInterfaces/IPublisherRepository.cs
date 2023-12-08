using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Dropdown.DataStorePluginInterfaces
{
    public interface IPublisherRepository
    {
        List<Publisher> GetPublishers();
    }
}
