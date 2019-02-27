using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        //print(time);
    }

    public int GetCurrenttime()
    {
        return (int)(time * 1000);
    }
}
