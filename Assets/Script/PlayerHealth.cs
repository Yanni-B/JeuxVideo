using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    // Variables
    [Header("Santé")]
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [Header("UI")]
    public HealthBar healthBar; 


    [Header("Musique")]
    public AudioClip sfxMort;
    private AudioSource audioSource;

    public static PlayerHealth instance;


    // Vérifie si une autre instance de la classe existe déjà. 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHearth dans la scène"); 
            return;
        }
        instance = this;
        audioSource = GetComponent<AudioSource>();
        // Vérification si la musique existe ou pas. 
        // Si existe pas, ajoute la musique dans le gameObject. 
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Barre de vie et points de vie au début de la partie. 
   public void ResetHealth()
    {
        currentHealth = maxHealth;
        if(healthBar != null)
        {
            healthBar.SetMaxHealth(currentHealth);
        }
    }

    void Update()
    {
    
    }

    // Fonction pour que le joueur récupère des vies. 
    public void HealPlayer(int value)
    {
        if((currentHealth + value) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += value;
        }
        healthBar?.SetHealth(currentHealth);

    }

    // Appliquer des dégâts
    public void TakeDamage(int value)
    {
        if (value <= 0) return;

        currentHealth = Mathf.Clamp(currentHealth - value, 0, maxHealth);
        healthBar?.SetHealth(currentHealth);

        // vérifier si joueur est toujours vivant. 
        // Si en bas de 0 PV, active la fonction MORT(). 
        if(currentHealth <= 0)
        {
            Mort();
            return;
        }

        Debug.Log("Dégâts appliqués : " + value + ", Vie actuelle : " + currentHealth);
    }

    // Fonction qui permet au joueur de mourir + animation mort.
    // Arrete la musique de fond quand le joueur meurt et active la musique DeadPlayer
    public void Mort()
    {
        Debug.Log("Le joueur est éliminé");

        GameObject musiqueManager = GameObject.Find("MusicManager");
        if (musiqueManager != null)
        {
            AudioSource music = musiqueManager.GetComponent<AudioSource>();
            if (music != null) music.Stop();
        }


        if (sfxMort != null)
        {
            audioSource.PlayOneShot(sfxMort, 1f);
        }

        // Quand le joueur meurt, désactive les mouvements
        // Active l'animation
        PlayerMove.instance.enabled = false;
        PlayerMove.instance.animator.SetTrigger("Mort");

        GameOverManager.instance.JoueurMort();

    }

}


// Source : https://youtu.be/uItHgxjEOIQ?si=Xwb9zglt2hrkDhkQ