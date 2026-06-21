using UniRx;
using UnityEngine;


public class JudgePresenter
{
    IInputModel _Iinput;
    JudgeModel _model;
    public JudgePresenter(IInputModel input)
    {
        _Iinput = input;
    }

    public JudgeResult Judge(
        double inputTime,
        double targetBeatTime
    )
    {
        return _model.Judge(inputTime, targetBeatTime);
    }


}