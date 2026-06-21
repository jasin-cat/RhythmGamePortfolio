using UniRx;
using UnityEngine;

public interface IJudgeModel
{
    public ReactiveProperty<bool> PassDirLeft { get; }
    public ReactiveProperty<bool> PassDirRight { get; }
}