using DataAccessLibrary.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Dropdown.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class PublisherInMemoryRepository : IPublisherRepository
    {
        private readonly List<Publisher> _publishers;
        public PublisherInMemoryRepository()
        {
            _publishers = new List<Publisher>()
            {
                new Publisher { Id = 1, PublisherName = "Frontiers"},
                new Publisher { Id = 2, PublisherName = "T&F" },
                new Publisher { Id = 3, PublisherName = "OUP" },
                new Publisher { Id = 3, PublisherName = "Sage" },
                new Publisher { Id = 3, PublisherName = "CUP" },
                new Publisher { Id = 3, PublisherName = "ASCE" },
                new Publisher { Id = 3, PublisherName = "ASME" },
                new Publisher { Id = 3, PublisherName = "Optica" },
                new Publisher { Id = 3, PublisherName = "KnF" },
                new Publisher { Id = 3, PublisherName = "APA" },
                new Publisher { Id = 3, PublisherName = "Others" },

            };
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return _publishers;
        }
    }
}
