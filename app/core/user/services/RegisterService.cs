using MoneyCount.app.core.user.contracts.repositories;
using MoneyCount.app.core.user.contracts.services;
using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.user.services
{
    public class RegisterService : IRegisterService
    {
        private IUserRepository _userRepository;

        public RegisterService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void SetUserRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(User user)
        {
            _userRepository.Add(user);
        }
    }
}