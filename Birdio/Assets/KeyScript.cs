using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    PlayerScript player;
    public Image key;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.keyPickUp);
            player.hasKey = true;
            gameObject.SetActive(false);
            key.gameObject.SetActive(true);
            
        }
    }
}
