using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineNoteController : NoteController
{
    bool hit = false;

    protected override void ProcessNote()
    {
        float arcAngle = GameObject.Find("Arc").GetComponent<ArcMovingController>().GetArcAngle();

        if ((timing - 125 <= time) && (time < timing + 125) && hit == false)
        {
            if ((-angle >= arcAngle - 22.5) && (-angle <= arcAngle + 22.5))
            {
                hit = true;
                gameObject.GetComponentInParent<LineParentController>().UpNoteCount();
            }

            if ((-angle + 360 >= arcAngle - 22.5) && (-angle + 360 <= arcAngle + 22.5))
            {
                hit = true;
                gameObject.GetComponentInParent<LineParentController>().UpNoteCount();
            }
        }
    }
}