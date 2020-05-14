using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.user.contracts.repositories
{
    public interface IUserRepository
    {
        public void Add(User user);
        
        public bool UserExistsByName(string name);

        public User GetUserByName(string name);

        public User GetUserById(int id);
    }
}