namespace MoneyCount.app.core.user.contracts.services
{
    public interface ILoginService
    {
        public void LogIn(string name, string password);

        public bool UserExists(string name);

        public bool CheckPassword(string name, string password);
    }
}