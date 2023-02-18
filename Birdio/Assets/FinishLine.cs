using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    PlayerScript player;
    GameControllerScript gameController;
    public GameObject gameBgMusic;
    BackgroundMusic bgAudio;
    // Start is called before the first frame update
    void Start()
    {
        bgAudio = gameBgMusic.GetComponent<BackgroundMusic>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        gameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && player.hasKey)
        {
            bgAudio.isOn = false;
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.winning);
            gameController.gameOverRun("YOU WIN !!");
        }
    }
}
