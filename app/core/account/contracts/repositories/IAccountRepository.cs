using MoneyCount.app.core.account.dto;

namespace MoneyCount.app.core.account.contracts.repositories
{
    public interface IAccountRepository
    {
        public void Add(Account account);

        public bool AccountExistsById(int id);

        public Account GetAccountById(int id);

        public void RemoveById(int id);
    }
}