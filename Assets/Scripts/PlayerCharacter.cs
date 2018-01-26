using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    
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
    /// The current speed of the player in the air
    /// </summary>
    private float currentAirSpeed;

    /// <summary>
    /// If the player is on the ground or not
    /// </summary>
    private bool isGrounded = true;
    
    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
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
    /// Fall according to the laws of gravity
    /// </summary>
    private void Fall()
    {
        currentAirSpeed += airAcceleration * Time.fixedDeltaTime;
        currentAirSpeed = Mathf.Min(currentAirSpeed, maxAirSpeed);
        transform.Translate(-Vector2.up * currentAirSpeed * Time.fixedDeltaTime);

        RaycastHit2D hit = Physics2D.Linecast(transform.position, (Vector2)transform.position + -Vector2.up * raycheckLength, LayerMask.NameToLayer("Player"));
        Debug.DrawLine(transform.position, (Vector2)transform.position + -Vector2.up * raycheckLength, Color.red);

        if (hit)
        {
            Debug.Log(hit.collider.tag);
            
            
            if (hit.collider.CompareTag("Environment"))
            {
                Debug.Log(hit.collider.tag);
                currentAirSpeed = 0;
                isGrounded = true;
            }
        }
    }

    /// <summary>
    /// Checks the user for input and performs the representing action
    /// </summary>
    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            isGrounded = false;
        }
    }
}
