using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCreateManager : MonoBehaviour
{
    public GameObject note;

    private List<int> noteTiming = new List<int>();
    private List<int> noteAngle = new List<int>();
    private int noteCount;

    private int duration;

    // Start is called before the first frame update
    void Start()
    {
        duration = GameObject.Find("GameData").GetComponent<Constants>().GetDuration();

        noteCount = 22;
        noteTiming.Add(1020);
        noteAngle.Add(-30);
        noteTiming.Add(1500);
        noteAngle.Add(-210);
        noteTiming.Add(1900);
        noteAngle.Add(-180);
        noteTiming.Add(2330);
        noteAngle.Add(-270);
        noteTiming.Add(2990);
        noteAngle.Add(-120);
        noteTiming.Add(3340);
        noteAngle.Add(-60);
        noteTiming.Add(3800);
        noteAngle.Add(-210);
        noteTiming.Add(3990);
        noteAngle.Add(-240);
        noteTiming.Add(4310);
        noteAngle.Add(-330);
        noteTiming.Add(4490);
        noteAngle.Add(-300);
        noteTiming.Add(4940);
        noteAngle.Add(-210);
        noteTiming.Add(5410);
        noteAngle.Add(-0);
        noteTiming.Add(5780);
        noteAngle.Add(-90);
        noteTiming.Add(6210);
        noteAngle.Add(-270);
        noteTiming.Add(6260);
        noteAngle.Add(-225);
        noteTiming.Add(6310);
        noteAngle.Add(-180);
        noteTiming.Add(6360);
        noteAngle.Add(-135);
        noteTiming.Add(6410);
        noteAngle.Add(-90);
        noteTiming.Add(6460);
        noteAngle.Add(-45);
        noteTiming.Add(6560);
        noteAngle.Add(-0);
        noteTiming.Add(6610);
        noteAngle.Add(-315);
        noteTiming.Add(6660);
        noteAngle.Add(-270);

        StartCoroutine("NoteCreate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator NoteCreate()
    {
        int latest = 0;
        yield return new WaitForSeconds((float)0.001 * (noteTiming[0] - duration));
        for (int i = 0; i < noteCount; i++)
        {
            GameObject noteCreated = Instantiate(note);
            noteCreated.GetComponent<NoteController>().timing = noteTiming[i];
            noteCreated.GetComponent<NoteController>().angle = noteAngle[i];
            //latest = noteTiming[i] - duration;
            yield return new WaitForSeconds((float)0.001 * (noteTiming[i+1] - noteTiming[i]));
        }
    }
}
