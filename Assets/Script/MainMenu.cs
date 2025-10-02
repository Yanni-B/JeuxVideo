using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Niveau")]
    public string levelToLoad;


   public void StartGame()
   {
    Debug.Log("Bouton Start cliqué !");
    SceneManager.LoadScene(levelToLoad);
   }

   public void Quit()
   {
    Application.Quit();
   }
}
