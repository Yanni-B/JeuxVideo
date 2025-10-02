using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinScene : MonoBehaviour
{
    // Variables
    [Header("Fichier scène et musiques")]
    public string nextSceneName = "";
    public AudioClip sfxExit;
    private AudioSource audioSource;

    // Fonction qui permet de faire disparaitre le joueur quand il touche à la porte
    void OnTriggerEnter2D(Collider2D other)
    {
        // Quand joueur touche à la porte, désactive la musique de fond et met la musique "winner"
        if(!other.CompareTag("Droop")) return;

        GameObject musiqueManager = GameObject.Find("MusicManager");
        if (musiqueManager != null)
        {
            AudioSource music = musiqueManager.GetComponent<AudioSource>();
            if (music != null) music.Stop();
        }
       
       // Ajoute la musique et fais disparaitre le joueur. 
       if(sfxExit) AudioSource.PlayClipAtPoint(sfxExit, transform.position, 5f);
       other.gameObject.SetActive(false);

       if(!string.IsNullOrEmpty(nextSceneName))
       {
        SceneManager.LoadScene(nextSceneName);
       }
    }
}
