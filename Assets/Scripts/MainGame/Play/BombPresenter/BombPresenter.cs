using UnityEngine;

public class BombPersenter
{
    IBeatManager _Ibeat;
    BombModel _model = new();
    public BombModel Imodel;
    public BombView Iview;

    public BombPersenter(BeatManager beat)
    {
        _Ibeat = beat;
    }
}