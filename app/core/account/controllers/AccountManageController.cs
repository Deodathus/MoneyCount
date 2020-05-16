using System;
using MoneyCount.app.core.account.contracts.services;
using MoneyCount.app.core.console;
using MoneyCount.app.core.console.services;

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

            TemplateBuilder.AddArgument("message", "Account was created.");
            TemplateBuilder.RebuildCurrentTemplate();
        }

        public void DeleteById()
        {
            Handler.Write("Enter account's id you want to delete:");
            int accountId = Convert.ToInt32(Handler.Read());
            Handler.Write("Are you sure you want to delete it?");

            _manageService.DeleteById(accountId);
        }
    }
}