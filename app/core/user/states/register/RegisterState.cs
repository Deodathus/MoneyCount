using MoneyCount.app.core.contracts.state;

namespace MoneyCount.app.core.user.states.register
{
    public class RegisterState : IState
    {
        public IState GetState()
        {
            return this;
        }
    }
}