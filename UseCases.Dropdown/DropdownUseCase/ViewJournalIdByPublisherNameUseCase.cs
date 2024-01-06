using CoreBusiness.Dropdown;
using Plugins.DataStore.InMemory.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UseCases.Dropdown.UseCaseInterfaces;

namespace UseCases.Dropdown.DropdownUseCase
{
    public class ViewJournalIdByPublisherNameUseCase : IViewJournalIdByPublisherNameUseCase
    {
        private readonly IJournalRepository _journalRepository;

        public ViewJournalIdByPublisherNameUseCase(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public List<Journal> Execute(string publisherNme)
        {
            return _journalRepository.GetJournalIdByPublisherName(publisherNme);
        }
    }
}
