using MoneyCount.app.core.contracts.state;

namespace MoneyCount.app.core.user.states.login
{
    public class UnLoggedInState : IState
    {
        public IState GetState()
        {
            return this;
        }
    }
}