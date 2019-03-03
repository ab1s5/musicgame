using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcMovingController : MonoBehaviour
{
	private Vector3 mousePosition = new Vector3(0, 0);
    private Vector2 center = new Vector2(0, 0);
    private float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        center = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        //Debug.Log(mousePosition);
        angle = Mathf.Rad2Deg * Mathf.Atan2(mousePosition.y - center.y, mousePosition.x - center.x) - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public float GetArcAngle()
    {
        //Debug.Log(angle);
        if (angle <= 0) return -angle;
        else return 360 - angle;
    }
}
