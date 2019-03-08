using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccDecimalTextController : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string converted = string.Format("{0:#.##}", 100 * Constants.Instance.GetAccuracy());
        text.text = converted + "%";
    }
}
