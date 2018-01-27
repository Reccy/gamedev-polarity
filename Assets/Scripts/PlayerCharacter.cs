using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    /// <summary>
    /// The distance between the mouse and the player that should not cause input
    /// </summary>
    public float movementDeadzone;

    /// <summary>
    /// Maximum speed for the player in the air
    /// </summary>
    public float maxAirSpeed;

    /// <summary>
    /// How fast the player should accelerate in the air
    /// </summary>
    public float airAcceleration;

    /// <summary>
    /// How long the raycheck should be for landing on the ground
    /// </summary>
    public float raycheckLength = 0.5f;

    /// <summary>
    /// How fast the player moves left and right
    /// </summary>
    public float horizontalMovementSpeed = 5f;

    /// <summary>
    /// The current speed of the player in the air
    /// </summary>
    private float currentAirSpeed;

    /// <summary>
    /// If the player is on the ground or not
    /// </summary>
    private bool isGrounded = true;
    public bool IsGrounded
    {
        get { return isGrounded; }
    }

    /// <summary>
    /// The position of the mouse within the world space
    /// </summary>
    private Vector2 mouseWorldPosition;
    
    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        CheckIfGrounded();

        if (!isGrounded)
            Fall();
    }
    
    private void Update()
    {
        CheckInput();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col);
    }

    /// <summary>
    /// Checks if the player is grounded
    /// </summary>
    private void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, (Vector2)transform.position + -Vector2.up * raycheckLength, LayerMask.NameToLayer("Player"));
        Debug.DrawLine(transform.position, (Vector2)transform.position + -Vector2.up * raycheckLength, Color.red);

        if (hit)
        {
            Debug.Log(hit.collider.tag);

            if (hit.collider.CompareTag("Environment"))
            {
                currentAirSpeed = 0;
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = false;
        }
    }

    /// <summary>
    /// Fall according to the laws of gravity
    /// </summary>
    private void Fall()
    {
        currentAirSpeed += airAcceleration * Time.fixedDeltaTime;
        currentAirSpeed = Mathf.Min(currentAirSpeed, maxAirSpeed);
        transform.Translate(-Vector2.up * currentAirSpeed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Moves the player left
    /// </summary>
    private void MoveLeft()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, (Vector2)transform.position + -Vector2.right * raycheckLength, LayerMask.NameToLayer("Player"));
        Debug.DrawLine(transform.position, (Vector2)transform.position + -Vector2.right * raycheckLength, Color.red);

        if (!hit || !hit.collider.CompareTag("Environment"))
        {
            transform.Translate(-Vector2.right * horizontalMovementSpeed * Time.fixedDeltaTime * Mathf.Min(movementDeadzone, Mathf.Abs(mouseWorldPosition.x - transform.position.x)));
        }

    }

    /// <summary>
    /// Moves the player right
    /// </summary>
    private void MoveRight()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, (Vector2)transform.position + Vector2.right * raycheckLength, LayerMask.NameToLayer("Player"));
        Debug.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * raycheckLength, Color.red);

        if (!hit || !hit.collider.CompareTag("Environment"))
        {
            transform.Translate(Vector2.right * horizontalMovementSpeed * Time.fixedDeltaTime * Mathf.Min(movementDeadzone, Mathf.Abs(mouseWorldPosition.x - transform.position.x)));
        }
    }

    /// <summary>
    /// Checks the user for input and performs the representing action
    /// </summary>
    private void CheckInput()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            transform.position = mouseWorldPosition;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            isGrounded = false;
        }
        
        if (mouseWorldPosition.x > transform.position.x)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }
}
