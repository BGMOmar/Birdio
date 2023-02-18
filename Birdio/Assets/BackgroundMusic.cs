using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audio;
    public bool isOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOn)
        {
            audio.Pause();
        }
        else
        {
            audio.UnPause();
        }
    }

    
}
