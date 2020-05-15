using MoneyCount.app.core.config.enums.console;
using MoneyCount.app.core.contracts.state;
using MoneyCount.app.core.user.controllers;
using MoneyCount.app.core.user.states.login;

namespace MoneyCount.app.core.user
{
    public class StateController : IStateController
    {
        public static IState State;

        public StateController()
        {
            State = new UnLoggedInState();
        }

        public void Handle(int option)
        {
            if (State is UnLoggedInState)
            {
                UnLoggedHandle(option);
            } else if (State is LoggedInState)
            {
                LoggedHandle(option);
            }
        }

        private void UnLoggedHandle(int option)
        {
            switch (option)
            {
                case 1:
                    LoginController lc = (LoginController) Builder.GetController(typeof(LoginController));
                    lc.Do();
                    
                    break;
                case 2:
                    RegisterController rc = (RegisterController) Builder.GetController(typeof(RegisterController));
                    rc.Do();

                    break;
            }
        }

        private void LoggedHandle(int option)
        {
            switch (option)
            {
                case 1:
                    ApplicationState.SetStateController((account.StateController) Builder.GetStateController(typeof(account.StateController)));
                    TemplateBuilder.BuildTemplate(ConsoleTemplateFile.AccountTemplateFilePath);
                    
                    break;
            }
        }
    }
}