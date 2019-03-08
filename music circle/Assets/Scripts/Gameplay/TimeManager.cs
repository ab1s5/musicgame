using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float time = -2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0) time += Time.deltaTime;
        //print(time);

        GameSceneTransitionController sceneTransition = GameObject.Find("SceneTransition").GetComponent<GameSceneTransitionController>();
        if (Constants.Instance.GetMusicName() == "nightmarewoods" && time > 70) sceneTransition.GoToScene();
        else if (Constants.Instance.GetMusicName() == "yee" && time > 9) sceneTransition.GoToScene();
        else if (Constants.Instance.GetMusicName() == "wielderbossbgm" && time > 80) sceneTransition.GoToScene();
        else if (Constants.Instance.GetMusicName() == "forthetop" && time > 97) sceneTransition.GoToScene();
        else if (Constants.Instance.GetMusicName() == "winter" && time > 125) sceneTransition.GoToScene();
    }

    public int GetCurrenttime()
    {
        return (int)(time * 1000);
    }
}
