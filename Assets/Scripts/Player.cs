using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingBottom;
    [SerializeField] private float paddingLeft;

    private Shooter _shooter;
    private Vector2 _rawInput;
    private Vector2 _minBounds;
    private Vector2 _maxBounds;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        InitializedBounds();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var delta = _rawInput * (moveSpeed * Time.deltaTime);
        var newPosition = new Vector2
        {
            x = Mathf.Clamp(transform.position.x + delta.x, _minBounds.x + paddingLeft, _maxBounds.x - paddingRight),
            y = Mathf.Clamp(transform.position.y + delta.y, _minBounds.y + paddingBottom, _maxBounds.y - paddingTop)
        };
        transform.position = newPosition;
    }

    private void InitializedBounds()
    {
        var mainCamera = Camera.main;
        _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        if (_shooter != null)
        {
            _shooter.isFiring = value.isPressed;
        }
    }
}
