using DataAccessLibrary.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.Dropdown
{
    public class PublisherUseCase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherUseCase(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public IEnumerable<Publisher> Execute()
        {
            return _publisherRepository.GetPublisher();
        }

    }
}
