using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    /// <summary>
    /// The distance between the mouse and the player that should not cause input
    /// </summary>
    public float movementDeadzone;
    
    /// <summary>
    /// How long the raycheck should be for landing on the ground
    /// </summary>
    public float raycheckLength = 0.5f;

    /// <summary>
    /// How fast the player moves left and right
    /// </summary>
    public float horizontalMovementSpeed = 5f;
    
    /// <summary>
    /// If the player is on the ground or not
    /// </summary>
    private bool isGrounded = true;
    public bool IsGrounded
    {
        get { return isGrounded; }
    }

    /// <summary>
    /// The amount to deduct from charge when the player jumps
    /// </summary>
    public int chargeCost = 35;

    /// <summary>
    /// The position of the mouse within the world space
    /// </summary>
    private Vector2 mouseWorldPosition;

    /// <summary>
    /// The rigidbody of the player character
    /// </summary>
    private Rigidbody2D rb;

    PlayerAudio playerAudio;
    
    private void Awake()
    {
        Application.targetFrameRate = 30;
        rb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<PlayerAudio>();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        CheckIfGrounded();
    }
    
    private void Update()
    {
        Vector2 v = rb.velocity;
        v.x = 0;
        rb.velocity = v;

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
        RaycastHit2D hit = Physics2D.Linecast(transform.position, (Vector2)transform.position + -Vector2.up * raycheckLength + new Vector2(0, -0.5f), LayerMask.NameToLayer("Environment"));
        Debug.DrawLine(transform.position, (Vector2)transform.position + -Vector2.up * raycheckLength + new Vector2(0, -0.5f), Color.red);

        if (hit)
        {
            if (hit.collider.CompareTag("Environment"))
            {
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
    /// Moves the player left
    /// </summary>
    private void MoveLeft()
    {
        transform.Translate(-Vector2.right * horizontalMovementSpeed * Time.fixedDeltaTime * Mathf.Min(movementDeadzone, Mathf.Abs(mouseWorldPosition.x - transform.position.x)));
    }

    /// <summary>
    /// Moves the player right
    /// </summary>
    private void MoveRight()
    {
        transform.Translate(Vector2.right * horizontalMovementSpeed * Time.fixedDeltaTime * Mathf.Min(movementDeadzone, Mathf.Abs(mouseWorldPosition.x - transform.position.x)));
    }

    /// <summary>
    /// Checks the user for input and performs the representing action
    /// </summary>
    private void CheckInput()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lineRendererPosition = (Vector2)FindObjectOfType<PlayerToMouseLine>().lineRenderer.GetPosition(1);

        if (Input.GetMouseButtonDown(0) && GetComponent<PlayerCharging>().percentageCharged > chargeCost && IsGrounded)
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, raycheckLength, lineRendererPosition - (Vector2)transform.position, Mathf.Abs(Vector2.Distance(transform.position, lineRendererPosition)), LayerMask.NameToLayer("Environment"));

            if (!hit)
            {
                playerAudio.PlayJumpSound();
                transform.position = FindObjectOfType<PlayerToMouseLine>().lineRenderer.GetPosition(1);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                FindObjectOfType<PlayerCharging>().percentageCharged -= chargeCost;
                isGrounded = false;
            }
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
