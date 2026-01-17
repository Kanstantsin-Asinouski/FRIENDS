using System;
using UnityEngine;

[SelectionBase]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float _movingSpeed = 5f;

    private Rigidbody2D _rigidBody;

    private readonly float _minMovingSpeed = 0.1f;
    private bool _isRunning = false;
    private Vector2 _inputVector;

    private void Awake()
    {
        Instance = this;
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameInput.Instance.OnPlayerAttack += GameInput_OnPlayerAttack;
    }

    public void Update()
    {
        _inputVector = GameInput.Instance.GetMovementVector();
    }

    public bool IsRunning()
    {
        return _isRunning;
    }

    public Vector3 GetPlayerPosition()
    {
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerPosition;
    }

    private void GameInput_OnPlayerAttack(object sender, EventArgs e)
    {
        ActiveWeapon.Instance.GetActiveWeapon().Attack();
    }

    private void FixedUpdate()
    {
        NewInputSystem();
    }

    // New input system, PlayerInputActions
    private void NewInputSystem()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        _rigidBody.MovePosition(_rigidBody.position + _inputVector * (_movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(_inputVector.x) > _minMovingSpeed || Mathf.Abs(_inputVector.y) > _minMovingSpeed)
        {
            _isRunning = true;
        }
        else
        {
            _isRunning = false;
        }
    }
}