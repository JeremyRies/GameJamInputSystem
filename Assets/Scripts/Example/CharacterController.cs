using UniRx;

namespace Example
{
    public class CharacterController
    {
        private TopDownMovementModel _movementModel;
        private readonly CharacterView _view;

        public CharacterController(TopDownMovementModel movementModel, CharacterView view)
        {
            _movementModel = movementModel;
            _view = view;

            _movementModel.Position.Subscribe(pos => { _view.Position = pos; });
        }
    }
}