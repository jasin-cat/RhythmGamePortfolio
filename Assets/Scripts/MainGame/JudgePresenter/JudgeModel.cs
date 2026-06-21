using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class JudgeModel : IDisposable, IJudgeModel
{
    private GameInput _input = new();
    private ReactiveProperty<bool> _passLeft = new();
    public ReactiveProperty<bool> PassDirLeft => _passLeft;
    private ReactiveProperty<bool> _passRight = new();
    public ReactiveProperty<bool> PassDirRight => _passRight;
    public JudgeModel()
    {
        _input.Player.Pass.performed += OnPass;
        _input.Enable();
    }

    public void Dispose()
    {
        _input.Player.Pass.performed -= OnPass;
        _input.Disable();

        _passLeft.Dispose();
        _passRight.Dispose();
    }

    private void OnPass(InputAction.CallbackContext context)
    {
        if(context.ReadValue<Vector2>().x < 0)
        {
            _passLeft.Value = true;
            _passRight.Value = false;
        }
        else
        {
            _passRight.Value = true;
            _passLeft.Value = false;
        }
    }
}