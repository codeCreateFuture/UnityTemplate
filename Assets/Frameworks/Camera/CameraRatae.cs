using UnityEngine;
using System.Collections;

public class CameraRatae : MonoBehaviour 
{

    public float thetaSpeed = 250.0f;
    public float phiBoundMin = -89f;
    public float phiBoundMax = 89f;
    public float rotateSmoothing = 0.5f;
    public float limitedSpeed = 2f;
    public float delayX = 0.02f;

    private Vector2 euler;

    public Vector3 pivotPoint = new Vector3(0, 1, 0);
    public Vector3 distanceVec = new Vector3(0, 0, 9);

    private Quaternion targetRot;

    private Rect inputBounds;
    public Rect paramInputBounds = new Rect(0, 0, 1, 1);

    private float offsetX = 0;
    private bool isRight;

	void Start () 
    {
        Vector3 angle = transform.eulerAngles;
        euler.x = angle.x;
        euler.y = angle.y;

        targetRot = transform.rotation;
	}
	
	void Update () 
    {
        inputBounds.x = GetComponent<Camera>().pixelWidth * paramInputBounds.x;
        inputBounds.y = GetComponent<Camera>().pixelHeight * paramInputBounds.y;
        inputBounds.width = GetComponent<Camera>().pixelWidth * paramInputBounds.width;
        inputBounds.height = GetComponent<Camera>().pixelHeight * paramInputBounds.height;

#if UNITY_EDITOR

        if (Input.GetMouseButton(1) && inputBounds.Contains(Input.mousePosition))
        {
            float dx = Input.GetAxis("Mouse X");
            dx = dx * thetaSpeed * 0.02f;
            if (dx > 0)
            {
                isRight = true;
            }
            else if (dx < 0)
            {
                isRight = false;
            }
            if (dx > 0 && dx > limitedSpeed)
            {
                euler.y += limitedSpeed;
                offsetX = limitedSpeed;
            }
            else if (dx < 0 && dx < -limitedSpeed)
            {
                euler.y += -limitedSpeed;
                offsetX = -limitedSpeed;
            }
            else
            {
                euler.y += dx;
                offsetX = dx;
            }
            targetRot = Quaternion.Euler(euler.x, euler.y, 0);
        }
        else
        {
            if (isRight)
            {
                if (offsetX > 0)
                {
                    euler.y += offsetX;
                    targetRot = Quaternion.Euler(euler.x, euler.y, 0);
                    offsetX -= delayX;
                }
            }
            else
            {
                if (offsetX < 0)
                {
                    euler.y += offsetX;
                    targetRot = Quaternion.Euler(euler.x, euler.y, 0);
                    offsetX += delayX;
                }
            }
        }
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float dx = Input.GetAxis("Mouse X");
            dx = dx * thetaSpeed * 0.02f;
            if (dx > 0)
            {
                isRight = true;
            }
            else if (dx < 0)
            {
                isRight = false;
            }
            if (dx > 0 && dx > limitedSpeed)
            {
                euler.y += limitedSpeed;
                offsetX = limitedSpeed;
            }
            else if (dx < 0 && dx < -limitedSpeed)
            {
                euler.y += -limitedSpeed;
                offsetX = -limitedSpeed;
            }
            else
            {
                euler.y += dx;
                offsetX = dx;
            }
            targetRot = Quaternion.Euler(euler.x, euler.y, 0);
        }
        else
        {
            if (isRight)
            {
                if (offsetX > 0)
                {
                    euler.y += offsetX;
                    targetRot = Quaternion.Euler(euler.x, euler.y, 0);
                    offsetX -= delayX;
                }
            }
            else
            {
                if (offsetX < 0)
                {
                    euler.y += offsetX;
                    targetRot = Quaternion.Euler(euler.x, euler.y, 0);
                    offsetX += delayX;
                }
            }
        }
#endif
	}

    public void FixedUpdate()        //每帧根据摄像机中线点位置不同重新定位摄像机的旋转和坐标
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSmoothing);
        transform.position = pivotPoint - transform.rotation * distanceVec;
    }

    public void StopRotate() {
        Vector3 angle = transform.eulerAngles;
        euler.x = angle.x;
        euler.y = angle.y;
        offsetX = 0;
        targetRot = transform.rotation;
    }

    static float ClampAngle(float angle, float min, float max)        //控制旋转角度不超过360
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
