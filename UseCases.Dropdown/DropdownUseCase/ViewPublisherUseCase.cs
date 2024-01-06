using CoreBusiness.Dropdown;
using Plugins.DataStore.InMemory.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Dropdown.UseCaseInterfaces;

namespace UseCases.Dropdown
{
    public class ViewPublisherUseCase : IViewPublisherUseCase
    {
        private readonly IPublisherRepository _publisherInMemoryRepository;

        public ViewPublisherUseCase(IPublisherRepository publisherInMemoryRepository)
        {
            _publisherInMemoryRepository = publisherInMemoryRepository;
        }

        public List<Publisher> Execute()
        {
            return _publisherInMemoryRepository.GetPublishers();
        }
    }
}
