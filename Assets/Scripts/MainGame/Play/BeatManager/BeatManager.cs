using System;
using UniRx;
using UnityEngine;

public class BeatManager
{
    private double _beatTime;
    private double _interval;
    private Action _onBeat;
    public Action OnBeat 
    {
        get => _onBeat;
        set
        {
            if(_onBeat is not null)
                value = _onBeat;

            _onBeat = value;
        }
    }

    private void StartMusic()
    {
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                while( _beatTime <= AudioSettings.dspTime)
                {
                    _beatTime += _interval;
                    _onBeat?.Invoke();
                }
            });
    }
}