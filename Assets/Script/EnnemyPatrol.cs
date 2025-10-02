using UnityEngine;
 
[RequireComponent(typeof(Rigidbody2D))]
public class EnnemyPatrol : MonoBehaviour
{

    // Valeurs
    [Header("Directions")]
    public Transform leftPoint, rightPoint;

    [Header("Données de l'ennemie")]
    public float speed = 2f;
    public int touchDamage = 1;


    private bool toRight = true;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
 
    //Appelle les composants
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        // animator = GetComponent<Animator>();
    }
 
 // Gérer mouvements horizontal
 // Permet de changer de direction arrivé à un point précis
 // Point A à point B. <->
   void FixedUpdate()
{
    float dir = toRight ? 1f : -1f;
    rb.velocity = new Vector2(dir * speed, rb.velocity.y);
    sr.flipX = !toRight;

    if (toRight && transform.position.x >= rightPoint.position.x)
        toRight = false;
    else if (!toRight && transform.position.x <= leftPoint.position.x)
        toRight = true;
}

    // Inflige des dégats  au joueur  avec le script PlayerHealth
    void OnTriggerEnter2D(Collider2D col)
{
    if (col.CompareTag("Droop"))
    {
        var hp = col.GetComponent<PlayerHealth>();
        if (hp) hp.TakeDamage(touchDamage);
    }
}
}
