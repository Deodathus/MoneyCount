using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.account.dto
{
    public class Account
    {
        private readonly int _id;
        private readonly User _user;
        private int _balance;

        public Account(User user, int balance)
        {
            _user = user;
            _balance = balance;
        }

        public User GetUser()
        {
            return _user;
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}