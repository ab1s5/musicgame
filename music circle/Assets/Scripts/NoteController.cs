using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public int timing;
    public float angle;
    public GameObject hitsound;

    private int duration;
    private int time;
    private float scale;

    private bool fastJust;
    // Start is called before the first frame update
    void Start()
    {
        duration = Constants.Instance.GetDuration();
        hitsound = GameObject.Find("HitSound");
        transform.position = new Vector2((float)2.5 * Mathf.Cos(Mathf.Deg2Rad * (angle + 90)), (float)2.5 * Mathf.Sin(Mathf.Deg2Rad * (angle + 90)));
    }

    // Update is called once per frame
    void Update()
    {
        time = GameObject.Find("GameData").GetComponent<TimeManager>().GetCurrenttime();
        scale = (timing - time) / (float)duration;
        if ((scale < 0) || (scale > 1)) scale = 0;
        transform.localScale = new Vector2(scale, scale);

        if ((timing - 25 <= time) && (time < timing))
        {
            if ((-angle >= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() - 22.5) && (-angle <= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() + 22.5))
            {
                fastJust = true;
            }
        }
        else if ((timing <= time) && (time < timing + 25))
        {
            if (fastJust || ((-angle >= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() - 22.5) && (-angle <= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() + 22.5)))
            {
                GetJust();
            }
        }
        else if ((timing + 25 <= time) && (time < timing + 125))
        {
            if ((-angle >= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() - 22.5) && (-angle <= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() + 22.5))
            {
                GetSlow();
            }
        }
        else if (time >= timing + 125)
        {
            GetMiss();
        }
    }

    void GetJust()
    {
        hitsound.GetComponent<HitSoundController>().PlayHitSound();
        Debug.Log("Just!");
        Destroy(gameObject);
    }

    void GetSlow()
    {
        hitsound.GetComponent<HitSoundController>().PlayHitSound();
        Debug.Log("Slow");
        Destroy(gameObject);
    }

    void GetMiss()
    {
        Debug.Log("miss...");
        Destroy(gameObject);
    }
    //IEnumerator shrink()
    //{
    //    for (int i = duration; i > 0; i--)
    //    {
            
    //        yield return new WaitForSeconds(.001f);
    //    }
    //}
}
