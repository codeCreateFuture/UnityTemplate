using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForrowMouseMove : MonoBehaviour {

    public float distance = 20f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)).GetPoint(distance);
        }
    }
}
