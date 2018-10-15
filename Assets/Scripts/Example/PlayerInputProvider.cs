using UniRx;
using UnityEngine;

namespace Example
{
    public class PlayerInputProvider : IGameInputProvider
    {
        private readonly ISystemInputProvider _unityInputProvider = new UnityInputProvider();
        private readonly string _prefix;

        public PlayerInputProvider(string prefix)
        {
            _prefix = prefix;
        }

        public IObservable<bool> GetAKeyDown()
        {
            return _unityInputProvider.GetKeyDown(_prefix + "A");
        }
        
        public IObservable<bool> GetBKeyDown()
        {
            return _unityInputProvider.GetKeyDown(_prefix + "B");
        }

        public IObservable<bool> GetAKeyHold()
        {
            return _unityInputProvider.GetKeyHold(_prefix + "A");
        }

        public IObservable<Vector2> GetMovement()
        {
            var xMovement = _unityInputProvider.GetAxis(_prefix + "Horizontal");
            var yMovement = _unityInputProvider.GetAxis(_prefix + "Vertical");

            return xMovement.CombineLatest(yMovement, (x, y) => new Vector2(x, y).normalized);
        }
    }
}
