using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UnityInputProvider : ISystemInputProvider
{
    private readonly Dictionary<string, ReactiveProperty<bool>> _keyDownSubscriptions 
        = new Dictionary<string, ReactiveProperty<bool>>();
    
    private readonly Dictionary<string, ReactiveProperty<bool>> _keyUpSubscriptions 
        = new Dictionary<string, ReactiveProperty<bool>>();
    
    private readonly Dictionary<string, ISubject<bool>> _keyHoldSubscriptions 
        = new Dictionary<string, ISubject<bool>>();
    
    private readonly Dictionary<string, ISubject<float>> _axisSubscriptions 
        = new Dictionary<string, ISubject<float>>();
    
    public UnityInputProvider()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            foreach (var keyDownSubscription in _keyDownSubscriptions)
            {
                keyDownSubscription.Value.Value = Input.GetButtonDown(keyDownSubscription.Key);
            }

            foreach (var keyUpSubscription in _keyUpSubscriptions)
            {
                keyUpSubscription.Value.Value = Input.GetButtonUp((keyUpSubscription.Key));
            }
            
            foreach (var holdSubscription in _keyHoldSubscriptions)
            {
                holdSubscription.Value.OnNext(Input.GetButton((holdSubscription.Key)));
            }
            
            foreach (var axisSubscription in _axisSubscriptions)
            {
                axisSubscription.Value.OnNext(Input.GetAxis((axisSubscription.Key)));
            }
        });
    }
    
    public IObservable<bool> GetKeyDown(string keyCode)
    {
        var keyDown = new ReactiveProperty<bool>();
        _keyDownSubscriptions.Add(keyCode, keyDown);

        return keyDown;
    }
    
    public IObservable<bool> GetKeyUp(string keyCode)
    {
        var keyUp = new ReactiveProperty<bool>();
        _keyUpSubscriptions.Add(keyCode, keyUp);

        return keyUp;
    }
    
    public IObservable<bool> GetKeyHold(string keyCode)
    {
        var keyUp = new Subject<bool>();
        _keyHoldSubscriptions.Add(keyCode, keyUp);

        return keyUp;
    }

    public IObservable<float> GetAxis(string axisName)
    {
        var axis = new Subject<float>();
        _axisSubscriptions.Add(axisName,axis);

        return axis;
    }
}