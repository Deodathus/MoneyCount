using MoneyCount.app.core.contracts.state;
using MoneyCount.app.core.user.controllers;

namespace MoneyCount.app.core.user
{
    public class StateController : IStateController
    {
        public IState State;
        
        public void Handle(int option)
        {
            switch (option)
            {
                case 2:
                    RegisterController rc = (RegisterController) Builder.GetController(typeof(RegisterController));
                    rc.Do();

                    break;
            }
        }
    }
}