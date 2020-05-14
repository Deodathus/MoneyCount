using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.account.dto
{
    public class Account
    {
        private readonly User _user;

        public Account(User user)
        {
            _user = user;
        }

        public User GetUser()
        {
            return _user;
        }
    }
}