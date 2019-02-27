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
            GameObject noteCreated = Instantiate(note);
            noteCreated.GetComponent<NoteController>().timing = noteTiming[i];
            noteCreated.GetComponent<NoteController>().angle = noteAngle[i];
        }
    }
}
