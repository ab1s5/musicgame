using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSpeedTextController : MonoBehaviour
{
    public GameObject speedSlider;
    private Text text;

    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = (int)speedSlider.GetComponent<Slider>().value;
        text.text = speed.ToString() + " ms";
    }
}
