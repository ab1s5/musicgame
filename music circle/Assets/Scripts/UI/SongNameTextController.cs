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
        else if (Constants.Instance.GetMusicName() == "wielderbossbgm") text.text = "Wielder Boss BGM\n~           Original ~\ncomposed by d6";
        else if (Constants.Instance.GetMusicName() == "forthetop") text.text = "For The Top";
        else if (Constants.Instance.GetMusicName() == "winter") text.text = "Winter 1st mvt.";
    }
}
