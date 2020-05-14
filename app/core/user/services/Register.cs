using MoneyCount.app.core.user.contracts.repositories;
using MoneyCount.app.core.user.contracts.services;
using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.user.services
{
    public class Register : IRegister
    {
        private readonly IRepository _repository;

        public Register(IRepository repository)
        {
            _repository = repository;
        }

        public void RegisterUser(User user)
        {
            _repository.Add(user);
        }
    }
}