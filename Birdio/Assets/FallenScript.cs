using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenScript : MonoBehaviour
{
    PlayerScript player;
    GameControllerScript gameController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        gameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Player has fallen
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.falling);
            player.Revive(false);
        }
    }
}
