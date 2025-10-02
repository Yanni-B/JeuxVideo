using UnityEngine;
using TMPro; // si tu utilises TextMeshPro

public class GameOverUI : MonoBehaviour
{
    [Header("Référence UI")]
    public GameObject gameOverText; // Texte ou panel "Game Over"

    void Start()
    {
        if (gameOverText != null)
            gameOverText.SetActive(false); // caché au départ
    }

    public void ShowGameOver()
    {
        if (gameOverText != null)
            gameOverText.SetActive(true);

        // Met le jeu en pause
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Remet le temps à la normale et recharge la scène
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
