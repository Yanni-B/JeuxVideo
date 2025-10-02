using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionVie : MonoBehaviour
{

    [Header("Point de vie")]
    public int healthPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth.instance.HealPlayer(healthPoints);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


// Source : https://youtu.be/uItHgxjEOIQ?si=Xwb9zglt2hrkDhkQ