using MoneyCount.app.core.contracts.state;
using MoneyCount.app.core.user;

namespace MoneyCount.app.core
{
    public class ApplicationState
    {
        private static IStateController _stateController;

        public static void SetStateController(IStateController stateController)
        {
            _stateController = stateController;
        }

        public static void Handle(int option)
        {
            if (_stateController == null)
            {
                GetDefaultStateController().Handle(option);
            }
            else
            {
                _stateController.Handle(option);
            }
        }

        private static IStateController GetDefaultStateController()
        {
            return (StateController) Builder.GetStateController(typeof(StateController));
        }
    }
}