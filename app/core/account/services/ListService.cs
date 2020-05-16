using System.Collections.Generic;
using MoneyCount.app.core.account.contracts.repositories;
using MoneyCount.app.core.account.contracts.services;
using MoneyCount.app.core.account.dto;
using MoneyCount.app.core.user.services;

namespace MoneyCount.app.core.account.services
{
    public class ListService : IListService
    {
        private IAccountRepository _accountRepository;

        public ListService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IAccountRepository GetAccountRepository()
        {
            return _accountRepository;
        }

        public void SetAccountRepository(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public List<Account> GetAccountsList()
        {
            Account account = _accountRepository.GetAccountByUserId(LoginService.LoggedUserId);

            List<Account> accounts = new List<Account> {account};

            return accounts;
        }
    }
}