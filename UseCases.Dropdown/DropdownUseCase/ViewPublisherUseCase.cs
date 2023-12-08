using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Dropdown.DataStorePluginInterfaces;
using UseCases.Dropdown.UseCaseInterfaces;

namespace UseCases.Dropdown.DropdownUseCase
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
