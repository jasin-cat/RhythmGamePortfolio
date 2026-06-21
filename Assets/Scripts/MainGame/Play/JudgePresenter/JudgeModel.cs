using System;
using UnityEngine;

public class JudgeModel
{
    public JudgeModel()
    {
        
    }

    public JudgeResult Judge(
        double inputTime,
        double targetBeatTime
    )
    {
        double diff = Math.Abs(inputTime - targetBeatTime);

        if(diff <= 0.10)
        {
            return JudgeResult.good;
        }

        return JudgeResult.miss;
    }
}