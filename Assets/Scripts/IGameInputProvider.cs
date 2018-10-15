using UniRx;
using UnityEngine;

public interface IGameInputProvider
{
    IObservable<bool> GetAKeyDown();
    IObservable<bool> GetBKeyDown();
    
    IObservable<bool> GetAKeyHold();
    IObservable<Vector2> GetMovement();
}