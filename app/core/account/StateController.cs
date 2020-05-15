using MoneyCount.app.core.account.controllers;
using MoneyCount.app.core.config.enums.console;
using MoneyCount.app.core.console.services;
using MoneyCount.app.core.contracts.state;

namespace MoneyCount.app.core.account
{
    public class StateController : IStateController
    {
        public static IState State;
        
        public void Handle(int option)
        {
            TemplateBuilder.BuildTemplate(ConsoleTemplateFile.AccountTemplateFilePath);
            
            switch (option)
            {
                case 1:
                    AccountManageController acm = (AccountManageController) Builder.GetController(typeof(AccountManageController));
                    acm.Add();
                    
                    break;
            }
        }
    }
}