using System.Collections.Generic;
using MoneyCount.app.core.account.dto;

namespace MoneyCount.app.core.account.contracts.repositories
{
    public interface IAccountRepository
    {
        public int GetAccountsCount();
        
        public void Add(Account account);

        public bool AccountExistsById(int id);

        public List<Account> GetAccountsByUserId(int id);

        public void RemoveById(int id);
    }
}