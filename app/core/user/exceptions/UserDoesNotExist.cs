using System;

namespace MoneyCount.app.core.user.exceptions
{
    public class UserDoesNotExist : Exception
    {
        public UserDoesNotExist(string message): base(message)
        { }
    }
}