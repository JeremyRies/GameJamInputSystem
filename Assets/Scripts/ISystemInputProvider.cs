using UniRx;
using UnityEngine;

public interface ISystemInputProvider
{
    IObservable<bool> GetKeyDown(string keyCode);
    IObservable<bool> GetKeyUp(string keyCode);
    IObservable<bool> GetKeyHold(string keyCode);

    IObservable<float> GetAxis(string axisName);
}