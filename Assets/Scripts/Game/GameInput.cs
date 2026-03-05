using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    public static GameInput Instance { get; private set; }

    public event EventHandler OnPlayerAttack;
    public event EventHandler OnPlayerDash;

    private void Awake()
    {
        Instance = this;

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();

        _playerInputActions.Combat.Attack.started += Player_AttackStarted;
        _playerInputActions.Player.Dash.performed += Player_DashPerformed;
    }    

    public Vector2 GetMovementVector()
    {
        return _playerInputActions.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMousePosition()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }

    public void DisableMovement()
    {
        _playerInputActions.Disable();
    }

    private void Player_AttackStarted(InputAction.CallbackContext context)
    {
        OnPlayerAttack?.Invoke(this, EventArgs.Empty);
    }

    private void Player_DashPerformed(InputAction.CallbackContext context)
    {
        OnPlayerDash?.Invoke(this, EventArgs.Empty);
    }
}