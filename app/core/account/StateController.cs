using System;
using MoneyCount.app.core.contracts.state;

namespace MoneyCount.app.core.account
{
    public class StateController : IStateController
    {
        public static IState State;
        
        public void Handle(int option)
        {
            
        }
    }
}