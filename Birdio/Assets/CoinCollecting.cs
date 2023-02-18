using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinCollecting : MonoBehaviour
{
    private Vector3 spawnPosition;
    private LogicScript logic;
    public AudioSource Audio;
    public AudioClip coinCollect;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.CoinCollecion);
            logic.addScore(1);
            gameObject.SetActive(false);
            MonoBehaviour camMono = Camera.main.GetComponent<MonoBehaviour>();
            camMono.StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(true);
        transform.position = spawnPosition;
    }

}
