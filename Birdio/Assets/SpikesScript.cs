using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    PlayerScript player;
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
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.spikesTouched);
            other.gameObject.SetActive(false);
            player.Revive(false);
        }
    }
}
