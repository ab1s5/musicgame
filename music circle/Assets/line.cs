using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector2(-10, 1));
        lineRenderer.SetPosition(0, new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
