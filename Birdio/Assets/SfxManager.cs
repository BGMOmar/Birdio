using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip CoinCollecion;
    public AudioClip keyPickUp;
    public AudioClip spikesTouched;
    public AudioClip falling;
    public AudioClip winning;
    public static SfxManager sfxInstance;

    
    void Start()
    {
        
    }

    private void Awake()
    {
        sfxInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
