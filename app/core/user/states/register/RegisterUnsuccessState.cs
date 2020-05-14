using MoneyCount.app.core.contracts.state;

namespace MoneyCount.app.core.user.states.register
{
    public class RegisterUnsuccessState : IState
    {
        public IState GetState()
        {
            return this;
        }
    }
}