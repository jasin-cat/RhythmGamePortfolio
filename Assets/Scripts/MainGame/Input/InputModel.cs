using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputModel : IDisposable, IInputModel
{
    private GameInput _input = new();
    private Subject<PassDirection> _pass = new();
    public IObservable<PassDirection> Pass => _pass;
    private double _inputTime = 0;
    public double InputTime => _inputTime;

    private IBeatManager _beat;
    public InputModel(BeatManager beat)
    {
        _beat = beat;

        _input.Player.Pass.performed += OnPass;
        _input.Enable();
    }

    public void Dispose()
    {
        _input.Player.Pass.performed -= OnPass;
        _input.Disable();
    }

    private void OnPass(InputAction.CallbackContext context)
    {
        _inputTime = AudioSettings.dspTime - _beat.CurrentTime;

        if(context.ReadValue<Vector2>().x < 0)
        {
            _pass.OnNext(PassDirection.left);
        }
        else
        {
            _pass.OnNext(PassDirection.right);
        }
    }
}