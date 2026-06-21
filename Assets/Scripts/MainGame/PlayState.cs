using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayState
{
    InputModel _input;
    BeatManager _beat;
    JudgePresenter _judge;
    BombPersenter _bomb;
    List<PlayerPresenter> _players;
    // どのplayerなのか　動かすのはちがうところ
    int playerIndex = 0;
    public void Enter()
    {
        _judge = new(_input);
        _beat.StartMusic();

        _input.Pass
            .Subscribe(dir =>
            {
                var result = _judge.Judge(
                    _input.InputTime, _beat.CurrentTime);
                if(result == JudgeResult.miss)
                {
                    // commandパターンでやる
                    _players[playerIndex].Imodel.DicreaseHP();
                    _bomb.Imodel.Exploded();

                    return;
                }

                _bomb.Iview.Move(dir);
            });

        _beat.OnBeat
            .Subscribe(count =>
            {
                if(count >= 60)
                {
                    _beat.AddBPM(20);
                    _beat.ResetBeatCount();
                }
            });
    }

    public void Exit()
    {
        _beat.Dispose();
    }
}