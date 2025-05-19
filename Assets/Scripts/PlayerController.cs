using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jetpackForce = 10f;
    public ParticleSystem jetpackEffect;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //transform.position = new Vector3(0, transform.position.y, transform.position.z);

        bool isJetpackActive = Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);

        if (isJetpackActive)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jetpackForce); // usa velocity, no linearVelocity

            if (jetpackEffect != null && !jetpackEffect.isPlaying)
                jetpackEffect.Play();

            if (animator != null)
                animator.SetBool("isFlying", true);
        }
        else
        {
            if (jetpackEffect != null && jetpackEffect.isPlaying)
                jetpackEffect.Stop();

            if (animator != null)
                animator.SetBool("isFlying", false);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (animator != null)
            animator.SetBool("landed", isGrounded && !isJetpackActive);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Aquí puedes cargar la escena de Game Over o reiniciar
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }

}

