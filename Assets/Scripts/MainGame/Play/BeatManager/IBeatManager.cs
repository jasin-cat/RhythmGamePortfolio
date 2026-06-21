using UniRx;
using UnityEngine;

public interface IBeatManager
{
    public double CurrentBeat { get; }
    public ReactiveProperty<bool> IsBeatTime { get; }
}