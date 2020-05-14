using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.user.contracts.repositories
{
    public interface IRepository
    {
        public void Add(User user);
    }
}