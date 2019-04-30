using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeTextController : MonoBehaviour
{
    public GameObject JustText;
    public GameObject SlowText;
    public GameObject MissText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText(string name)
    {
        JustText.SetActive(false);
        SlowText.SetActive(false);
        MissText.SetActive(false);
        if (name == "just")
        {
            JustText.SetActive(true);
        }
        else if (name == "slow")
        {
            SlowText.SetActive(true);
        }
        else if (name == "miss")
        {
            MissText.SetActive(true);
        }
        else
        {
            Debug.Log("no such text");
            Debug.Log(name);
        }
    }
}
