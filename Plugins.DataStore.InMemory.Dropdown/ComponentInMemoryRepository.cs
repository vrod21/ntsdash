using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public class ComponentInMemoryRepository : IComponentRepository
    {
        private readonly List<Component> _components;

        public ComponentInMemoryRepository()
        {
            _components = new List<Component>()
            {
                new Component { Id = 1, Name = "Full Checking" },
                new Component { Id = 2, Name = "IPF" },
                new Component { Id = 3, Name = "DCF (-)" },
                new Component { Id = 4, Name = "DCF (+)" },
            };
        }

        public List<Component> GetComponent()
        {
            return _components;
        }
    }
}
