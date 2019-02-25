using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongNameTextController : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Constants.Instance.GetMusicName() == "nightmarewoods") text.text = "Nightmare Woods";
        else if (Constants.Instance.GetMusicName() == "yee") text.text = "Yee";
    }
}
