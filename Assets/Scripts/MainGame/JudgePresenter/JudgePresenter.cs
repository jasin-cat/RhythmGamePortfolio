using UniRx;
using UnityEngine;


public class JudgePresenter
{
    JudgeModel _model = new();
    public IJudgeModel Imodel;

    public JudgePresenter()
    {
        Imodel = _model;
    }
}