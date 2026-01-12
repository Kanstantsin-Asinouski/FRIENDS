using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;

    private readonly float minMovingSpeed = 0.1f;
    private bool isRunning = false;
    private Vector2 inputVector;

    public bool IsRunning()
    {
        return isRunning;

    }

    public Vector3 GetPlayerPosition()
    {
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerPosition;
    }

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        inputVector = GameInput.Instance.GetMovementVector();
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
        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
}