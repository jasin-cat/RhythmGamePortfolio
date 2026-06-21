using System;
using UnityEngine;

public interface IInputModel
{
    public IObservable<PassDirection> Pass { get; }
    public double InputTime { get; }
}