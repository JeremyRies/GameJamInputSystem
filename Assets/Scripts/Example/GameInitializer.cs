using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private CharacterView _characterView;

        private WaitForEndOfFrame _waitForEndOfFrame;
        private readonly List<string> _deviceInputPrefix = new List<string>
        {
            "kb_", "xb_1_", "xb_2_"
            //keyboard Xbox1 Xbox2
        };

        IEnumerator Start()
        {

            int playerId = 1;
            
            foreach (var devicePrefix in _deviceInputPrefix)
            {
                IGameInputProvider gameInputProvider = new PlayerInputProvider(devicePrefix);
                var topDownMovement = new TopDownMovementModel(gameInputProvider, playerId);
                var view = Instantiate(_characterView);
                var charController = new CharacterController(topDownMovement, view);

                playerId++;
            }


            _waitForEndOfFrame = new WaitForEndOfFrame();
            yield return _waitForEndOfFrame;
        }

     
    }
}



