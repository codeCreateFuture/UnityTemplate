using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 某个物体与此物体保持在同一水平上并且朝向此物体
/// </summary>

public class KeepLevelAndLookAt : MonoBehaviour {

    public float Distance = 5f;   //距离
    public Transform target;      //看向这里的物体
    public Vector3 OffsetPos = Vector3.zero; //偏移量
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Vector3 dir = transform.forward;
        dir = new Vector3(dir.x, 0, dir.z);
        target.position = transform.position + dir.normalized * Distance + OffsetPos;
        target.LookAt(transform);


        Debug.DrawLine(transform.position, transform.forward * 20, Color.black);
        Debug.DrawLine(transform.position, dir * 20, Color.red);
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("position " + transform.position);
            Debug.Log("Localposition " + transform.localPosition);
            Debug.Log("Formard " + transform.forward);
        }
    }
}
