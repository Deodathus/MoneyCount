using MoneyCount.app.core.user.contracts.repositories;
using MoneyCount.app.core.user.contracts.services;
using MoneyCount.app.core.user.dto;
using MoneyCount.app.core.user.states.login;

namespace MoneyCount.app.core.user.services
{
    public class LoginService : ILoginService
    {
        public static int LoggedUserId;
        
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool UserExists(string name)
        {
            return _userRepository.UserExistsByName(name);
        }

        public bool CheckPassword(string name, string password)
        {
            User user = _userRepository.GetUserByName(name);

            return user.CheckPassword(password);
        }

        public void LogIn(string name, string password)
        {
            User user = _userRepository.GetUserByName(name);

            LoggedUserId = user.GetId();
            
            StateController.State = new LoggedInState();
        }
    }
}