using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Dropdown;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public class PubisherInMemoryRepository : IPublisherRepository
    {
        private readonly List<Publisher> _publishers;
        public PubisherInMemoryRepository()
        {
            _publishers = new List<Publisher>()
            {
                new Publisher { Id = 1, Name = "Frontiers"},
                new Publisher { Id = 2, Name = "T&F" },
                new Publisher { Id = 3, Name = "OUP" },
                new Publisher { Id = 4, Name = "Sage" },
                new Publisher { Id = 5, Name = "CUP" },
                new Publisher { Id = 6, Name = "ASCE" },
                new Publisher { Id = 7, Name = "ASME" },
                new Publisher { Id = 8, Name = "Optica" },
                new Publisher { Id = 9, Name = "SfN" },
                new Publisher { Id = 10, Name = "NCTM" },
                new Publisher { Id = 11, Name = "APA" },
                new Publisher { Id = 12, Name = "Others" },
            };
        }

        public List<Publisher> GetPublishers()
        {
            return _publishers;
        }
    }
}
