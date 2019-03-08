using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Constants.Instance.GetMusicName() == "wielderbossbgm") transform.localScale = new Vector2(1, 1);
        else transform.localScale = new Vector2(0, 0);
    }
}
