using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public int timing;
    public float angle;

    private int duration;
    private int time;
    private float scale;
    // Start is called before the first frame update
    void Start()
    {
        duration = Constants.Instance.GetDuration();
        
        transform.position = new Vector2((float)2.5 * Mathf.Cos(Mathf.Deg2Rad * (angle + 90)), (float)2.5 * Mathf.Sin(Mathf.Deg2Rad * (angle + 90)));
    }

    // Update is called once per frame
    void Update()
    {
        time = GameObject.Find("GameData").GetComponent<TimeManager>().GetCurrenttime();
        //print(time);
        scale = (timing - time) / (float)duration;
        if (scale < 0) scale = 0;
        transform.localScale = new Vector2(scale, scale);

        if ((timing - 25 <= time) && (time < timing + 25))
        {
            if ((-angle >= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() - 22.5) && (-angle <= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() + 22.5))
            {
                GetJust();
                Destroy(gameObject);
            }
        }
        else if ((timing + 25 <= time) && (time < timing + 125))
        {
            if ((-angle >= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() - 22.5) && (-angle <= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() + 22.5))
            {
                GetSlow();
                Destroy(gameObject);
            }
        }
        else if (time >= timing + 125)
        {
            GetMiss();
            Destroy(gameObject);
        }

    }

    void GetJust()
    {
        Debug.Log("Just!");
    }

    void GetSlow()
    {
        Debug.Log("Slow");
    }

    void GetMiss()
    {
        Debug.Log("miss...");
    }
    //IEnumerator shrink()
    //{
    //    for (int i = duration; i > 0; i--)
    //    {
            
    //        yield return new WaitForSeconds(.001f);
    //    }
    //}
}
