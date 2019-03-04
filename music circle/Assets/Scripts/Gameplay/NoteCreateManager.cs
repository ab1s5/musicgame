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
    private List<string> noteColor = new List<string>();
    private int noteCount = 0;

    private int duration = -1;

    // Start is called before the first frame update
    void Start()
    {
        duration = Constants.Instance.GetDuration();

        TextAsset chart = null;
        if (Constants.Instance.GetMusicNumber() == 0)
        {
            chart = Resources.Load("Charts/nightmarewoods", typeof(TextAsset)) as TextAsset;
        }
        else if (Constants.Instance.GetMusicNumber() == 1)
        {
            chart = Resources.Load("Charts/yee", typeof(TextAsset)) as TextAsset;
        }
        else if (Constants.Instance.GetMusicNumber() == 2)
        {
            chart = Resources.Load("Charts/wielderbossbgm", typeof(TextAsset)) as TextAsset;
        }
        StringReader sr = new StringReader(chart.text);

        string line = sr.ReadLine();
        string[] data;
        
        while (line != null)
        {
            data = line.Split(',');
            noteTiming.Add(Convert.ToInt32(data[0]));
            noteAngle.Add(-Convert.ToSingle(data[1]));
            noteColor.Add(data[2]);
            noteCount += 1;
            line = sr.ReadLine();
        }

        //StartCoroutine("NoteCreate");
        NoteCreate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //IEnumerator NoteCreate()
    //{
    //    //int latest = 0;
    //    yield return new WaitForSeconds((float)0.001 * (noteTiming[0] - duration));
    //    GameObject noteCreated = Instantiate(note);
    //    noteCreated.GetComponent<NoteController>().timing = noteTiming[0];
    //    noteCreated.GetComponent<NoteController>().angle = noteAngle[0];
    //    for (int i = 1; i < noteCount; i++)
    //    {
    //        yield return new WaitForSeconds((float)0.001 * (noteTiming[i] - noteTiming[i - 1]));
    //        noteCreated = Instantiate(note);
    //        noteCreated.GetComponent<NoteController>().timing = noteTiming[i];
    //        noteCreated.GetComponent<NoteController>().angle = noteAngle[i];
    //        //latest = noteTiming[i] - duration;
    //    }
    //}

    void NoteCreate()
    {
        for (int i = 0; i < noteCount; i++)
        {
            if ((i != noteCount - 1) && (noteTiming[i] == noteTiming[i + 1]))
            {
                GameObject lineParent = new GameObject("line");
                LineParentController lpc = lineParent.AddComponent<LineParentController>();
                lpc.timing = noteTiming[i];
                
                GameObject noteCreated1 = Instantiate(note);
                noteCreated1.transform.SetParent(lineParent.transform);
                LineNoteController lnc1 = noteCreated1.AddComponent<LineNoteController>();
                lnc1.timing = noteTiming[i];
                lnc1.angle = noteAngle[i];

                GameObject noteCreated2 = Instantiate(note);
                noteCreated2.transform.SetParent(lineParent.transform);
                LineNoteController lnc2 = noteCreated2.AddComponent<LineNoteController>();
                lnc2.timing = noteTiming[i];
                lnc2.angle = noteAngle[i + 1];
                
                i++;
            }
            else
            {
                GameObject noteCreated = Instantiate(note);
                NoteController nc = noteCreated.AddComponent<NoteController>();
                nc.timing = noteTiming[i];
                nc.angle = noteAngle[i];
                SetNoteColor(noteCreated, noteColor[i]);
            }
        }
    }

    void SetNoteColor(GameObject note, string color)
    {
        Color notecolor = note.GetComponent<SpriteRenderer>().color;
        if (color == "r") note.GetComponent<SpriteRenderer>().color = Color.red;
        else if (color == "b") note.GetComponent<SpriteRenderer>().color = Color.blue;
        else if (color == "y") note.GetComponent<SpriteRenderer>().color = Color.yellow;
        else if (color == "g") note.GetComponent<SpriteRenderer>().color = Color.green;
        else if (color == "m") note.GetComponent<SpriteRenderer>().color = Color.magenta;
        else if (color == "x") note.GetComponent<SpriteRenderer>().color = Color.gray;
    }
}
