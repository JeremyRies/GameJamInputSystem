using UniRx;
using UnityEngine;

namespace Example
{
    public class TopDownMovementModel
    {
        private readonly IGameInputProvider _gameInputProvider;
        private readonly ReactiveProperty<Vector2> _position = new ReactiveProperty<Vector2>(Vector2.zero);

        public TopDownMovementModel(IGameInputProvider gameInputProvider, int playerId)
        {
            _gameInputProvider = gameInputProvider;

            _gameInputProvider.GetAKeyDown().Subscribe(down =>
            {
                Debug.Log("A Button of player " + playerId + " is " + down);
            });
            _gameInputProvider.GetBKeyDown().Subscribe(down =>
            {
                Debug.Log("B Button of player " + playerId + " is " + down);
            });  
            
            _gameInputProvider.GetAKeyHold().Subscribe(hold =>
            {
                Debug.Log("B Button of player " + playerId + " is hold down" + hold);
            });
            _gameInputProvider.GetMovement().Subscribe(dir => { Position.Value += Time.deltaTime * dir; });
        }

        public ReactiveProperty<Vector2> Position
        {
            get { return _position; }
        }
    }
}