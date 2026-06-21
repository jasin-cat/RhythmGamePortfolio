using System;
using UniRx;
using UnityEngine;

public interface IBeatManager
{
    public IObservable<long> OnBeat { get; }
    public double CurrentTime { get; }
    public void StartMusic();
}