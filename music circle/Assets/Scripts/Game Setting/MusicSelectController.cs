using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelectController : MonoBehaviour
{
    public GameObject[] musics;
    public GameObject taebo;
    public GameObject bodywash;
    // Start is called before the first frame update
    void Start()
    {
        if ((Constants.Instance.GetMusicNumber() >= 1) || (Constants.Instance.GetNightmarewoods() >= 30)) musics[Constants.Instance.GetMusicNumber()].SetActive(true);
        else if (Constants.Instance.GetNightmarewoods() >= 15) bodywash.SetActive(true);
        else taebo.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
