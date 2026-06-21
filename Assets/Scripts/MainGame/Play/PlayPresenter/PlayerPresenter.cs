using UniRx;
using UnityEngine;

public class PlayerPresenter
{
    private PlayerModel _model = new();
    public IPlayerModel Imodel;

    public PlayerPresenter()
    {
        Imodel = _model;
    }
}
