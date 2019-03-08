using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineParentController : MonoBehaviour
{
    public int timing;
    public GameObject hitsound;

    int time;
    int hitNoteCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        hitsound = GameObject.Find("HitSound");
    }

    // Update is called once per frame
    void Update()
    {
        time = GameObject.Find("GameData").GetComponent<TimeManager>().GetCurrenttime();

        if ((timing <= time) && (time < timing + 125) && hitNoteCount == 2)
        {
            GetLineJust();
        }
        else if (time >= timing + 125)
        {
            GetMiss();
        }
    }

    public void UpNoteCount()
    {
        hitNoteCount++;
    }

    void GetLineJust()
    {
        hitsound.GetComponent<HitSoundController>().PlayHitSound();
        Debug.Log("Line Just!");
        Constants.Instance.UpJustLine();
        Constants.Instance.UpCombo();
        Destroy(gameObject);
    }

    void GetMiss()
    {
        Constants.Instance.UpMiss();
        Constants.Instance.CutCombo();
        Destroy(gameObject);
    }
}
