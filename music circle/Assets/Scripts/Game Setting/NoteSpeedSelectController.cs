using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSpeedSelectController : MonoBehaviour
{
    public GameObject speedSlider;
    public int speedToSet;

    public void setSpeed()
    {
        speedSlider.GetComponent<Slider>().value = speedToSet;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
