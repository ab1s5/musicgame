using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSpeedSetController : MonoBehaviour
{
    public GameObject speedSlider;

    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = (int)speedSlider.GetComponent<Slider>().value;
        Constants.Instance.SetDuration(speed);
    }
}
