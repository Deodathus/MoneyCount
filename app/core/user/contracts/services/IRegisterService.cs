using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.user.contracts.services
{
    public interface IRegisterService
    {
        public void RegisterUser(User user);
    }
}