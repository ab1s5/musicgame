using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDelayManager : MonoBehaviour
{
    public GameObject musicObject;
    public float invokeTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", invokeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()
    {
        gameObject.GetComponent<TimeManager>().enabled = true;
        gameObject.GetComponent<NoteCreateManager>().enabled = true;
        musicObject.SetActive(true);
    }
}
