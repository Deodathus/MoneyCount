using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.account.dto
{
    public class Account
    {
        private readonly int _id;
        private readonly User _user;
        private readonly int _balance;

        public Account(User user, int balance, int id = default)
        {
            _id = id;
            _user = user;
            _balance = balance;
        }

        public int GetId()
        {
            return _id;
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