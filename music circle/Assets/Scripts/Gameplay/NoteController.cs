using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public int timing;
    public float angle;
    public GameObject hitsound;

    protected int duration;
    protected int time;
    protected float scale;

    protected bool fastJust;
    protected bool processed;

    protected GameObject judgeText;
    // Start is called before the first frame update
    protected void Start()
    {
        duration = Constants.Instance.GetDuration();
        hitsound = GameObject.Find("HitSound");
        judgeText = GameObject.Find("Judge");
        transform.position = new Vector2((float)2.5 * Mathf.Cos(Mathf.Deg2Rad * (angle + 90)), (float)2.5 * Mathf.Sin(Mathf.Deg2Rad * (angle + 90)));
    }

    // Update is called once per frame
    protected void Update()
    {
        if (!processed)
        {
            time = GameObject.Find("GameData").GetComponent<TimeManager>().GetCurrenttime();
            scale = (timing - time) / (float)duration;
            if ((scale < 0) || (scale > 1)) scale = 0;
            transform.localScale = new Vector2(scale, scale);
            ProcessNote();
        }
    }

    protected virtual void ProcessNote()
    {
        float arcAngle = GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle();
        if ((timing - 30 <= time) && (time < timing))
        {
            if ((-angle >= arcAngle - 22.5) && (-angle <= arcAngle + 22.5))
            {
                fastJust = true;
            }
            if ((-angle + 360 >= arcAngle - 22.5) && (-angle + 360 <= arcAngle + 22.5)) // code for 0 <= angle < 22.5
            {
                fastJust = true;
            }
            if ((-angle - 360 >= arcAngle - 22.5) && (-angle - 360 <= arcAngle + 22.5)) // code for 337.5 <= angle < 360
            {
                fastJust = true;
            }
        }
        else if ((timing <= time) && (time < timing + 30))
        {
            if (fastJust || ((-angle >= arcAngle - 22.5) && (-angle <= arcAngle + 22.5)))
            {
                GetJust();
            }
            else if ((-angle + 360 >= arcAngle - 22.5) && (-angle + 360 <= arcAngle + 22.5))
            {
                GetJust();
            }
            else if ((-angle - 360 >= arcAngle - 22.5) && (-angle - 360 <= arcAngle + 22.5))
            {
                GetJust();
            }
        }
        else if ((timing + 30 <= time) && (time < timing + 125))
        {
            if ((-angle >= arcAngle - 22.5) && (-angle <= arcAngle + 22.5))
            {
                GetSlow();
            }
            else if ((-angle + 360 >= arcAngle - 22.5) && (-angle + 360 <= arcAngle + 22.5))
            {
                GetSlow();
            }
            else if ((-angle - 360 >= arcAngle - 22.5) && (-angle - 360 <= arcAngle + 22.5))
            {
                GetSlow();
            }
        }
        else if (time >= timing + 125)
        {
            Debug.Log(arcAngle);
            Debug.Log(angle);
            Debug.Log(fastJust);
            GetMiss();
        }

        //else if ((timing - 30 <= time) && (time < timing)) 
        //{
        //    Debug.Log("check");
        //    Debug.Log(arcAngle);
        //    Debug.Log(angle);
        //    if ((-angle + 360 >= arcAngle - 22.5) && (-angle + 360 <= arcAngle + 22.5))
        //    {
        //        fastJust = true;
        //    }
        //}
        //else if ((timing <= time) && (time < timing + 30))
        //{
        //    if (fastJust || ((-angle + 360 >= arcAngle - 22.5) && (-angle + 360 <= arcAngle + 22.5)))
        //    {
        //        GetJust();
        //    }
        //}
        //else if ((timing + 30 <= time) && (time < timing + 125))
        //{
        //    if ((-angle + 360 >= arcAngle - 22.5) && (-angle + 360 <= arcAngle + 22.5))
        //    {
        //        GetSlow();
        //    }
        //}
    }
    void GetJust()
    {
        hitsound.GetComponent<HitSoundController>().PlayHitSound();
        if (fastJust) Debug.Log("Fast");
        Debug.Log("Just!");
        Constants.Instance.UpJust();
        Constants.Instance.UpCombo();
        processed = true;
        judgeText.GetComponent<JudgeTextController>().ShowText("just");
        StartCoroutine(Bomb(2));
    }

    void GetSlow()
    {
        hitsound.GetComponent<HitSoundController>().PlayHitSound();
        Debug.Log("Slow");
        Constants.Instance.UpSlow();
        Constants.Instance.UpCombo();
        processed = true;
        judgeText.GetComponent<JudgeTextController>().ShowText("slow");
        StartCoroutine(Bomb(1));
    }

    void GetMiss()
    {
        Debug.Log("miss...");
        Constants.Instance.UpMiss();
        Constants.Instance.CutCombo();
        processed = true;
        judgeText.GetComponent<JudgeTextController>().ShowText("miss");
        Destroy(gameObject);
    }

    IEnumerator Bomb(float size)
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        while (color.a > 0f)
        {
            color.a -= 5 * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            transform.localScale = new Vector2(transform.localScale.x + size * 5 * Time.deltaTime, transform.localScale.y + size * 5 * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}
