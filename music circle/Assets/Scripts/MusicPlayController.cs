using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayController : MonoBehaviour
{
    private AudioSource audio;
    private GameObject gameData;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        gameData = GameObject.Find("GameData");
    }

    // Update is called once per frame
    void Update()
    {
        gameData.GetComponent<TimeManager>().time = audio.time;
    }
}
