using UnityEngine;

public class AcidKill : MonoBehaviour
{

    // Valeur
    [Header("Valeur")]
    [Tooltip("Tag du volume d'acide")]
    public string acidTag = "Droop";

    [Tooltip("Dégâts instantanés à l'entrée")]
    public int damageOnEnter = 100;

    [Tooltip("Dégâts par seconde tant qu'on reste dedans")]
    public int damagePerSecond = 0;

    private PlayerHealth playerHealth;

    void Start()
    {
        // Cherche directement le PlayerHealth dans la scène pour mettre des dégats
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        if (playerHealth == null)
            Debug.LogWarning("PlayerHealth non trouvé !");
    }

// Fonction qui permet d'appliquer des dégats quand le personnage entre en contact avec le trigger
   void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Trigger avec : " + other.name + ", tag : " + other.tag);
    if (!other.CompareTag(acidTag)) return;

    //Appelle le script pour infliger des dégats
    var health = other.GetComponent<PlayerHealth>();
    if (health != null)
    {
        health.TakeDamage(damageOnEnter);
        Debug.Log("Dégâts appliqués via AcidKill !");
    }
}


// Applique des dégats continus
    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag(acidTag) || playerHealth == null) return;

        // dégâts par seconde
        // Vérifie le temps écoulé depuis le dernier update et arrondit à l'entier supérieur pour être le plus précis possible
        playerHealth.TakeDamage(Mathf.CeilToInt(damagePerSecond * Time.deltaTime));
    }
}
