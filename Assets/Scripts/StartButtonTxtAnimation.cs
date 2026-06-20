using TMPro;
using UnityEngine;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine.InputSystem;
using UnityEditor.ShaderGraph.Internal;

public class StartButtonTxtAnimation : MonoBehaviour
{
    [SerializeField]
    float _animDuration = 1.5f;
    [SerializeField]
    float _animCancelDuration = 1f;
    [SerializeField]
    float _animFrom = 1.0f;
    [SerializeField]
    float _animTo = 1.5f;
    MotionHandle _textAnimHandle;

    public void ReStart()
    {
        if(_textAnimHandle.IsActive()) _textAnimHandle.Cancel();
        this.gameObject.SetActive(true);

        _textAnimHandle = LMotion
            .Create(from: _animFrom, to: _animTo, duration: _animDuration)
            .WithLoops(loops: -1, loopType: LoopType.Yoyo)
            .WithOnCancel(() =>
            {
                LMotion.Create(from: this.transform.localScale, to: Vector3.one, duration: _animCancelDuration)
                    .WithOnComplete(() =>
                    {
                        this.gameObject.SetActive(false);
                    })
                    .BindToLocalScale(this.transform);
            })
            .BindToLocalScaleXYZ(this.transform);
    }

    public void Canceled()
    {
        _textAnimHandle.Cancel();
    }


}
