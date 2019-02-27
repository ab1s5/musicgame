using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHitSound()
    {
        gameObject.GetComponent<AudioSource>().enabled = true;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
