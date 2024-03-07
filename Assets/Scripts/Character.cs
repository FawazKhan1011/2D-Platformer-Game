using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject jumpButton; // Reference to the UI jump button
    public Animator animator;

    private Rigidbody2D rb;
    private bool moveRight;
    private bool moveLeft;

    private bool facingRight = true; // Variable to track the direction the character is facing

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;

        // Add a listener to the jump button
        jumpButton.GetComponent<Button>().onClick.AddListener(Jump);
    }

    void Update()
    {
        // Check if the character is grounded
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        Movement();
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
        // If the character is facing right, flip it when moving left
        if (facingRight)
        {
            Flip();
        }
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
        // If the character is not facing right, flip it when moving right
        if (!facingRight)
        {
            Flip();
        }
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    void Movement()
    {
        float horizontalMove = 0f;

        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }

        // Update the animator parameter for Speed
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

    void Jump()
    {
        // Check if the character is grounded before jumping
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        Debug.Log("Is Grounded: " + isGrounded); // Debugging

        if (isGrounded)
        {
            animator.SetBool("IsJumping", true);
            Debug.Log("IsJump is true");
            StartCoroutine(Jumpstart());
            

            // Start a coroutine to reset IsJumping after a delay
            StartCoroutine(ResetIsJumping());
        }
    }
    IEnumerator Jumpstart()
    {
        yield return new WaitForSeconds(0.3f);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    IEnumerator ResetIsJumping()
    {
        // Wait for the duration of the jump animation
        yield return new WaitForSeconds(1.02f);

        // Reset the IsJumping parameter
        animator.SetBool("IsJumping", false);
        Debug.Log("IsJump is false");
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a small sphere to visualize the ground check position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, 0.1f);
    }

    // Method to flip the character
    void Flip()
    {
        // Switch the direction the character is facing
        facingRight = !facingRight;

        // Flip the character GameObject by flipping its scale
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
