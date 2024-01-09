using CoreBusiness.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemory.Dropdown
{
    public class AccountInMemoryRepository : IAccountRepository
    {
        private readonly List<Account> _account;
        public AccountInMemoryRepository()
        {
            _account = new List<Account>()
            {
                new Account { Id = 1, Name = "Frontiers"},
                new Account { Id = 2, Name = "T&F"},
                new Account { Id = 3, Name = "OUP" },
                new Account { Id = 4, Name = "Sage" },
                new Account { Id = 5, Name = "CUP" },
                new Account { Id = 6, Name = "ASCE" },
                new Account { Id = 7, Name = "ASME" },
                new Account { Id = 8, Name = "Optica" },
                new Account { Id = 9, Name = "KnF" },
                new Account { Id = 10, Name = "APA" },
                new Account { Id = 11, Name = "Others"}
            };
        }

        public List<Account> GetAccount()
        {
            return _account;
        }
    }
}
