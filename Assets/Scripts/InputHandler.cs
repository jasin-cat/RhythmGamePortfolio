using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler
{
    private GameInput _input = new();
    private ReactiveProperty<bool> _isStart = new(false);
    public IReadOnlyReactiveProperty<bool> IsStart => _isStart;

    public void Init()
    {
        _input.Start.StartSpace.performed += OnStart;
        _input.Enable();
    }

    public void Disable()
    {
        _input.Start.StartSpace.performed -= OnStart;
        _input.Disable();
    }

    void OnStart(InputAction.CallbackContext context)
    {
        _input.Start.StartSpace.performed -= OnStart;
        _input.Disable();

        _isStart.Value = true;
    }
}