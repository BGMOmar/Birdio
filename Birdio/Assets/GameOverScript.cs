using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public TMP_Text textEnd;
    public AudioSource audio;
    public AudioClip deathSound;
    // Start is called before the first frame update
    public void Setup(string title, bool hasLost) {
        textEnd.text = title;
        gameObject.SetActive(true);
        if (hasLost)
        {
            audio.PlayOneShot(deathSound);
            
        }
       
        Time.timeScale = 0;
    }

    public void SetupOff()
    {
        PlayerScript player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        player.Revive(true);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
