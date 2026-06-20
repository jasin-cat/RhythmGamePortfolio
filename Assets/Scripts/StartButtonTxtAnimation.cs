using TMPro;
using UnityEngine;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine.InputSystem;

public class StartButtonTxtAnimation : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    MotionHandle _textAnimHandle;

    void OnEnable()
    {
        _textAnimHandle = LMotion
            .Create(from: 0.5f, to: 1.5f, duration: 1f)
            .WithLoops(loops: -1, loopType: LoopType.Yoyo)
            .WithOnCancel(() =>
            {
                LMotion.Create(from: text.transform.localScale, to: Vector3.zero, duration: 0.5f)
                    .WithOnCancel(() =>
                    {
                        text.gameObject.SetActive(false);
                    })
                    .BindToLocalScale(text.transform);
            })
            .BindToLocalScaleXYZ(text.transform);
    }

    public void Canceled()
    {
        _textAnimHandle.Cancel();
    }


}
