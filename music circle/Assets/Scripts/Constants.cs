using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    private static Constants _instance;
    private static GameObject container;

    public static Constants Instance
    {
        get
        {
            if (_instance == null)
            {
                container = new GameObject();
                container.name = "Constants";
                _instance = container.AddComponent(typeof(Constants)) as Constants;
                DontDestroyOnLoad(_instance);

            }
            return _instance;
        }
    }

    public int duration;
    public string musicName;

    private int musicNumber = 0;
    private const int musicCount = 2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (musicNumber == 0) musicName = "nightmarewoods";
        else if (musicNumber == 1) musicName = "yee";
        else if (musicNumber == musicCount) musicNumber = 0;
        else if (musicNumber == -1) musicNumber = musicCount - 1;
    }

    public void SetDuration(int durationtime)
    {
        duration = durationtime;
    }

    public int GetDuration()
    {
        return duration;
    }

    public void SetMusic(int number)
    {
        musicNumber = number;
    }

    public void SetMusic(string name)
    {
        if (name == "nightmarewoods") musicNumber = 0;
        else if (name == "yee") musicNumber = 1;
    }

    public int GetMusicNumber()
    {
        return musicNumber;
    }

    public string GetMusicName()
    {
        return musicName;
    }

    public int GetMusicCount()
    {
        return musicCount;
    }
}
