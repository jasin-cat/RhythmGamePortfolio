using System;
using UniRx;
using UnityEngine;

public class BeatManager : IBeatManager
{
    private double _currentBeat = 0;
    public double CurrentBeat => _currentBeat;
    private float _bpm = 120f;
    private double _interval;
    private ReactiveProperty<bool> _isBeatTime = new(false);
    public ReactiveProperty<bool> IsBeatTime => _isBeatTime;

    public void SetBPM(float bpm)
    {
        _bpm = bpm;
        _interval = 60.0f / bpm;
    }

    private void StartMusic()
    {
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                while( _currentBeat <= AudioSettings.dspTime)
                {
                    _currentBeat += _interval;
                    _isBeatTime.Value = true;
                }
            });
    }
}