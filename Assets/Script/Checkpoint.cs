using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Vérifie que personnage touche au checkpoint
    // Vérifie que le GameOverManager existe 
    // Appelle méthode SetCheckpoint pour mettre à jour la position du respawn avec la position du checkpoint
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Droop"))
        {
            if(GameOverManager.instance != null)
            {
                GameOverManager.instance.SetCheckpoint(transform.position);
            }
        }
    }
}
