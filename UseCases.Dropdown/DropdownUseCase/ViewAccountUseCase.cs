using CoreBusiness.Dropdown;
using Plugins.DataStore.InMemory.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Dropdown.UseCaseInterfaces;

namespace UseCases.Dropdown.DropdownUseCase
{
    public class ViewAccountUseCase : IViewAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;

        public ViewAccountUseCase(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public List<Account> Execute()
        {
            return _accountRepository.GetAccount();
        }
    }
}
