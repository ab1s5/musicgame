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
    private const int musicCount = 3;

    private int just;
    private int justLine;
    private int slow;
    private int miss;

    private int combo;
    private int maxCombo;

    public int nightmarewoodsRandom;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (musicNumber == 0) musicName = "nightmarewoods";
        else if (musicNumber == 1) musicName = "yee";
        else if (musicNumber == 2) musicName = "wielderbossbgm";
        else if (musicNumber == musicCount) musicNumber = 0;
        else if (musicNumber == -1) musicNumber = musicCount - 1;
    }

    public void RollNightmarewoods()
    {
        nightmarewoodsRandom = Random.Range(0, 100);
    }

    public int GetNightmarewoods()
    {
        return nightmarewoodsRandom;
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
        else if (name == "wielderbossbgm") musicNumber = 2;
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

    public void ResetJudge()
    {
        just = 0;
        justLine = 0;
        slow = 0;
        miss = 0;
        combo = 0;
        maxCombo = 0;
    }
    public void UpJust()
    {
        just++;
    }

    public void UpJustLine()
    {
        justLine++;
    }

    public void UpSlow()
    {
        slow++;
    }

    public void UpMiss()
    {
        miss++;
    }

    public int GetJust()
    {
        return just;
    }

    public int GetJustLine()
    {
        return justLine;
    }

    public int GetSlow()
    {
        return slow;
    }

    public int GetMiss()
    {
        return miss;
    }

    public void UpCombo()
    {
        combo++;
        if (combo > maxCombo) maxCombo = combo;
    }

    public void CutCombo()
    {
        combo = 0;
    }

    public int GetCombo()
    {
        return combo;
    }

    public float GetAccuracy()
    {
        if ((just + justLine + slow + miss) == 0) return 0;
        return ((float)3.0 * (float)justLine + (float)just + (float)0.7 * (float)slow) / (float)(3 * justLine + just + slow + miss);
    }
}
