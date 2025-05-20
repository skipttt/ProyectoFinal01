using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jetpackForce = 10f;
    public ParticleSystem jetpackEffect;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    public float normalGravity = 1f;
    public float fallGravity = 2.8f;

    [Header("Jetpack Sound")]
    public AudioSource audioSource;
    public AudioClip jetpackSound;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Asegura que el AudioSource no empiece con sonido
        if (audioSource != null)
            audioSource.loop = true;
    }

    void Update()
    {
        bool isJetpackPressed = Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);

        if (isJetpackPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jetpackForce);
            rb.gravityScale = normalGravity;

            if (jetpackEffect != null && !jetpackEffect.isPlaying)
                jetpackEffect.Play();

            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.clip = jetpackSound;
                audioSource.Play();
            }

            if (animator != null)
                animator.SetBool("isFlying", true);
        }
        else
        {
            rb.gravityScale = fallGravity;

            if (jetpackEffect != null && jetpackEffect.isPlaying)
                jetpackEffect.Stop();

            if (audioSource != null && audioSource.isPlaying)
                audioSource.Stop();

            if (animator != null)
                animator.SetBool("isFlying", false);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (animator != null)
            animator.SetBool("landed", isGrounded && !isJetpackPressed);
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

        int currentRunScore = FindObjectOfType<ScoreManager>().GetScore();
        PlayerPrefs.SetInt("CurrentScore", currentRunScore);

        if (currentRunScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currentRunScore);
        }

        SceneManager.LoadScene("GameOver");
    }
}
