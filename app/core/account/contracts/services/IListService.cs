using System.Collections.Generic;
using MoneyCount.app.core.account.dto;

namespace MoneyCount.app.core.account.contracts.services
{
    public interface IListService
    {
        public List<Account> GetAccountsList();
    }
}