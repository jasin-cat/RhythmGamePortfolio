using System;
using UniRx;
using UnityEngine;

public class BeatManager : IBeatManager, IDisposable
{
    private AudioSource _source;
    private AudioClip _startClip;
    private AudioClip _nomalClip;
    private double _startDspTime = 0;
    private double _currentTime;
    public double CurrentTime => _currentTime;
    private double _nextBeatTime = 0;
    public double NextBeatTime => _nextBeatTime;
    private double _interval;
    private double _bpm = 60;
    private long _beatCount = 0;
    private Subject<long> _onBeat = new();
    // longがcountでそれに応じて爆発するかどうかを決める
    public IObservable<long> OnBeat => _onBeat;
    private IDisposable _disposable;
    private bool _isStartMusic = false;

    public BeatManager(
        AudioSource source,
        AudioClip startClip,
        AudioClip nomalClip
    )
    {
        _source = source;
        _startClip = startClip;
        _nomalClip = nomalClip;

        SetBPM(_bpm);
    }

    public void AddBPM(double add)
    {
        SetBPM(_bpm + add);
    }

    private void SetBPM(double bpm)
    {
        _bpm = bpm;
        _interval = 60.0 / _bpm;
        _nextBeatTime = _currentTime + _interval;
    }

    public void ResetBeatCount()
    {
        _beatCount = 0;
    }

    public void StartMusic()
    {
        if(_isStartMusic) return;

        _isStartMusic = true;

        _startDspTime = AudioSettings.dspTime;

        _disposable = 
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    _currentTime =
                        AudioSettings.dspTime - _startDspTime;

                    while( _nextBeatTime <= _currentTime)
                    {
                        _beatCount++;
                        _nextBeatTime += _interval;
                        _onBeat.OnNext(_beatCount);

                        if(_beatCount % 4 == 0)
                        {
                            _source.PlayOneShot(_startClip);
                            continue;
                        }

                        _source.PlayOneShot(_nomalClip);
                    }
                });
    }

    public void Dispose()
    {
        _disposable.Dispose();
    }
}