using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;


    // Fonction qui initialise barre de vie
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Met à jour la barre de vie (Gagner ou perdre)
    // Perdre -> Script dans PlayerHealth.cs
    // Gagner -> Script dans PotionVie.cs 
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}


// Source : https://youtu.be/Jcuaxz-ahDQ?si=VIp4VRHdr2cZugch