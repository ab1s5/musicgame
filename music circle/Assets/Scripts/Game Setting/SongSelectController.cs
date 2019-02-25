using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShiftSong(int increment)
    {
        Constants.Instance.SetMusic(Constants.Instance.GetMusicNumber() + increment);
    }
}
