using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;
    

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    private Rigidbody2D rb;

    private float x;
    private bool jump = false;

    public static PlayerMove instance;



    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène"); 
            return;
        }
        instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(x));

        if (x > 0f) spriteRenderer.flipX = false;
        if (x < 0f) spriteRenderer.flipX = true;

        // Déclenche le saut si on appuie sur Flèche Haut et qu'on n'est pas en plein air
        if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            jump = true;
            audioSource.PlayOneShot(sfxJump);
             if (sfxJump != null)
        {
            audioSource.PlayOneShot(sfxJump, 1f);
        }
        }

        animator.SetBool("jump", Mathf.Abs(rb.velocity.y) > 0.01f);
        animator.SetBool("Attack", Input.GetKey(KeyCode.Space));
    }

    void FixedUpdate()
    {
        // Déplacement horizontal via Rigidbody
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

        // Saut
        if (jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = false;
        }
    }
}
