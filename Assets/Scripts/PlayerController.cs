using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jetpackForce = 10f;
    public ParticleSystem jetpackEffect;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    public float normalGravity = 1f; // Gravedad mientras vuela
    public float fallGravity = 2.8f;   // Gravedad cuando cae

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
        bool isJetpackActive = Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);

        if (isJetpackActive)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jetpackForce); // Corrige linearVelocity a velocity
            rb.gravityScale = normalGravity; // Menor gravedad al volar

            if (jetpackEffect != null && !jetpackEffect.isPlaying)
                jetpackEffect.Play();

            if (animator != null)
                animator.SetBool("isFlying", true);
        }
        else
        {
            rb.gravityScale = fallGravity; // Aumenta gravedad al caer

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
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("GameOver"); // Descomenta si prefieres cargar por nombre
    }
}
