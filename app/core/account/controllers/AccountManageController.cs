using System.Collections.Generic;
using MoneyCount.app.core.account.contracts.services;

namespace MoneyCount.app.core.account.controllers
{
    public class AccountManageController
    {
        private readonly IManageService _manageService;

        public AccountManageController(IManageService manageService)
        {
            _manageService = manageService;
        }

        public void Add()
        {
            _manageService.Add();
            
            Dictionary<string, object> args = new Dictionary<string, object>();
        }
    }
}