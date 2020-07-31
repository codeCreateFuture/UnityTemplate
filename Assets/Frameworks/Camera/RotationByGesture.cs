using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationByGesture : MonoBehaviour {
    public Camera ca;
    private Quaternion q;

    private Vector3 mousePos;
    private Vector3 preMousePos;
    private Vector3 modelPos;

    public Vector3 localEluer;

    private bool IsSelect = false;
    private float RotateAngle;

    private float angle;

    public Transform target1;

    // Use this for initialization
    void Start()
    {
        modelPos = ca.WorldToScreenPoint(target1.transform.position);
        angle = localEluer.z;
        target1.transform.localEulerAngles = localEluer;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            IsSelect = true;
            preMousePos = mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && IsSelect)
        {
            IsSelect = true;
            mousePos = Input.mousePosition;
            RotateAngle = Vector3.Angle(preMousePos - modelPos, mousePos - modelPos);
            //print (RotateAngle);

            if (RotateAngle == 0)
            {
                preMousePos = mousePos;
            }
            else
            {
                q = Quaternion.FromToRotation(preMousePos - modelPos, mousePos - modelPos);
                float k = q.z > 0 ? 1 : -1;
                localEluer.z += k * RotateAngle;

                Debug.Log(localEluer.x);

                angle = localEluer.z = Mathf.Clamp(localEluer.z, -36000, 36000);

                target1.transform.localEulerAngles = localEluer;
                preMousePos = mousePos;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            IsSelect = false;
        }
    }
}
