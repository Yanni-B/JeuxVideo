using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Header("UI GameOver")]
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private Vector3 lastCheckpointPosition;
    private GameObject player;


    // Vérifie qu'il n'y a qu'une seule instance
    // Si autre instance existe, affiche message
    // Sinon, permet accès global
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Plus d'une instance de GameOverManager !");
            return;
        }
        instance = this;
    }

    // Cherche joueur
    // Initialise le dernier checkpoint avec position du joueur
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Droop"); 
        if(player != null)
        {
            lastCheckpointPosition = player.transform.position; 
        }
    }

    // Met à jour la dernière position du checkpoint
    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpointPosition = position;
    }

    // Active menu quand joueur meurt
    public void JoueurMort()
    {
        gameOverUI.SetActive(true);
    }

    // Action quand on appuie sur le bouton retry
    // Cache le menu
    // Replace le joueur au dernier checkpoint
    // S'assure que joueur est visible dans la caméra
    // Réactive script mouvement joueur & réinitialise l'animation Mort et remet animation Idle pour que joueur apparaisse
    // Remet point de vie au max
    // Rédémarre la musique parce que sinon elle revient pas
    public void RetryButton()
{
    gameOverUI.SetActive(false);

    if(player != null)
    {
        player.transform.position = new Vector3(lastCheckpointPosition.x, lastCheckpointPosition.y, 0f);

        PlayerMove.instance.enabled = true;
        PlayerMove.instance.animator.ResetTrigger("Mort");
        PlayerMove.instance.animator.Play("Idle"); // ou ton état par défaut

        PlayerHealth.instance.ResetHealth();

        GameObject musiqueManager = GameObject.Find("MusicManager");
        if(musiqueManager != null)
        {
            AudioSource music = musiqueManager.GetComponent<AudioSource>();
            if(music != null) music.Play();
        }
    }
}


}
