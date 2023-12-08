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
    public class ViewJournalUseCase : IViewJournalUseCase
    {
        private readonly IJournalRepository _journalInMemoryRepository;

        public ViewJournalUseCase(IJournalRepository journalInMemoryRepository)
        {

            _journalInMemoryRepository = journalInMemoryRepository;
        }

        public List<Journal> Execute()
        {
            return _journalInMemoryRepository.GetJournalId();
        }
    }
}
