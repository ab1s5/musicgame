using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineNoteController : NoteController
{
    bool hit = false;

    void ProcessNote()
    {
        if ((timing - 125 <= time) && (time < timing + 125))
        {
            if ((-angle >= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() - 22.5) && (-angle <= GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle() + 22.5))
            {
                hit = true;
            }
        }
    }
    //IEnumerator shrink()
    //{
    //    for (int i = duration; i > 0; i--)
    //    {
            
    //        yield return new WaitForSeconds(.001f);
    //    }
    //}
}
