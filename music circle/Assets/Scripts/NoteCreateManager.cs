using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class NoteCreateManager : MonoBehaviour
{
    public GameObject note;

    private List<int> noteTiming = new List<int>();
    private List<float> noteAngle = new List<float>();
    private int noteCount = 0;

    private int duration = -1;

    // Start is called before the first frame update
    void Start()
    {
        duration = Constants.Instance.GetDuration();

        TextAsset chart = Resources.Load("Charts/nightmarewoods", typeof(TextAsset)) as TextAsset;
        StringReader sr = new StringReader(chart.text);

        string line = sr.ReadLine();
        string[] data;
        
        while (line != null)
        {
            data = line.Split(',');
            noteTiming.Add(Convert.ToInt32(data[0]));
            noteAngle.Add(-Convert.ToSingle(data[1]));
            noteCount += 1;
            line = sr.ReadLine();
        }
        //notecount = 22;
        //notetiming.add(1020);
        //noteangle.add(-30);
        //notetiming.add(1500);
        //noteangle.add(-210);
        //notetiming.add(1900);
        //noteangle.add(-180);
        //notetiming.add(2330);
        //noteangle.add(-270);
        //notetiming.add(2990);
        //noteangle.add(-120);
        //notetiming.add(3340);
        //noteangle.add(-60);
        //notetiming.add(3800);
        //noteangle.add(-210);
        //notetiming.add(3990);
        //noteangle.add(-240);
        //notetiming.add(4310);
        //noteangle.add(-330);
        //notetiming.add(4490);
        //noteangle.add(-300);
        //notetiming.add(4940);
        //noteangle.add(-210);
        //notetiming.add(5410);
        //noteangle.add(-0);
        //notetiming.add(5780);
        //noteangle.add(-90);
        //notetiming.add(6210);
        //noteangle.add(-270);
        //notetiming.add(6260);
        //noteangle.add(-225);
        //notetiming.add(6310);
        //noteangle.add(-180);
        //notetiming.add(6360);
        //noteangle.add(-135);
        //notetiming.add(6410);
        //noteangle.add(-90);
        //notetiming.add(6460);
        //noteangle.add(-45);
        //notetiming.add(6560);
        //noteangle.add(-0);
        //notetiming.add(6610);
        //noteangle.add(-315);
        //notetiming.add(6660);
        //noteangle.add(-270);

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
        GameObject noteCreated = Instantiate(note);
        noteCreated.GetComponent<NoteController>().timing = noteTiming[0];
        noteCreated.GetComponent<NoteController>().angle = noteAngle[0];
        for (int i = 1; i < noteCount; i++)
        {
            yield return new WaitForSeconds((float)0.001 * (noteTiming[i] - noteTiming[i - 1]));
            noteCreated = Instantiate(note);
            noteCreated.GetComponent<NoteController>().timing = noteTiming[i];
            noteCreated.GetComponent<NoteController>().angle = noteAngle[i];
            //latest = noteTiming[i] - duration;
        }
    }
}
