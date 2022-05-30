using MoveBehaviors;
using Zenject;

namespace Units.Airplanes.Player
{
    public class PlayerAirplane : Airplane
    {
        private IController _controller;

        [Inject]
        private void Init(IController controller)
        {
            _controller = controller;
        }

        protected override IController GetController()
        {
            return _controller;
        }

        protected override IMoveBehavior GetStartMoveBehavior()
        {
            return new First(transform);
        }
    }
}