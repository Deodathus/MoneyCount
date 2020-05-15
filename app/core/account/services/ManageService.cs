﻿using MoneyCount.app.core.account.contracts.repositories;
using MoneyCount.app.core.account.contracts.services;
using MoneyCount.app.core.account.dto;
using MoneyCount.app.core.user.contracts.repositories;
using MoneyCount.app.core.user.dto;
using MoneyCount.app.core.user.services;

namespace MoneyCount.app.core.account.services
{
    public class ManageService : IManageService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public ManageService(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        public void Add()
        {
            User user = _userRepository.GetUserById(LoginService.LoggedUserId);
            
            Account account = new Account(user, 0);

            _accountRepository.Add(account);
        }
    }
}