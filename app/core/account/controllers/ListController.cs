using System;
using MoneyCount.app.core.account.contracts.services;
using MoneyCount.app.core.account.dto;
using MoneyCount.app.core.account.exceptions;
using MoneyCount.app.core.console;
using MoneyCount.app.core.console.services;

namespace MoneyCount.app.core.account.controllers
{
    public class ListController
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        public void List()
        {
            try
            {
                foreach (Account account in _listService.GetAccountsList())
                {
                    Handler.Write($"ID: {account.GetId()}, User name: {account.GetUser().GetName()}, Balance: {account.GetBalance()}");
                }
            }
            catch (AccountDoesNotExist e)
            {
                TemplateBuilder.AddArgument("message",
                    "You don't have any accounts yet. Press any button to continue.");
                TemplateBuilder.RebuildCurrentTemplate();
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}