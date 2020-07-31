using UnityEngine;
using System.Collections;

public class MoveSpring : MonoBehaviour
{
    //摄像机绕屏幕中心旋转缩放平移脚本

    public float thetaSpeed = 250.0f;
    public float phiSpeed = 120.0f;
    public float moveSpeed = 10.0f;
    public float zoomSpeed = 30.0f;

    public float phiBoundMin = -89f;
    public float phiBoundMax = 89f;
    public bool useMoveBounds = true;
    public float moveBounds = 100f;

    public float rotateSmoothing = 0.5f;
    public float moveSmoothing = 0.7f;

    public float distance = 2.0f;
    private Vector2 euler;

    private Quaternion targetRot;
    private Vector3 targetLookAt;
    private float targetDist;
    private Vector3 distanceVec = new Vector3(0, 0, 0);

    private Transform target;
    private Rect inputBounds;
    public Rect paramInputBounds = new Rect(0, 0, 1, 1);

    public Vector3 pivotPoint = new Vector3(0, 2, 0);

    public void Start()
    {
        Vector3 angles = transform.eulerAngles;        //获取摄像机欧拉角
        euler.x = angles.y;
        euler.y = angles.x;
        //unity only returns positive euler angles but we need them in -90 to 90
        euler.y = Mathf.Repeat(euler.y + 180f, 360f) - 180f;

        GameObject go = new GameObject("_FreeCameraTarget");
        go.hideFlags = HideFlags.HideAndDontSave | HideFlags.HideInInspector;
        target = go.transform;


        target.position = pivotPoint;
        targetDist = (transform.position - target.position).magnitude;

        targetRot = transform.rotation;
        targetLookAt = target.position;
    }

    public void Update()
    {
        //NOTE: mouse coordinates have a bottom-left origin, camera top-left
        inputBounds.x = GetComponent<Camera>().pixelWidth * paramInputBounds.x;
        inputBounds.y = GetComponent<Camera>().pixelHeight * paramInputBounds.y;
        inputBounds.width = GetComponent<Camera>().pixelWidth * paramInputBounds.width;
        inputBounds.height = GetComponent<Camera>().pixelHeight * paramInputBounds.height;

        if (target && inputBounds.Contains(Input.mousePosition))
        {
            float dx = Input.GetAxis("Mouse X");
            float dy = Input.GetAxis("Mouse Y");

            bool click1 = Input.GetMouseButton(1);
            bool click2 = Input.GetMouseButton(2);


            if (click2)                //按下鼠标中键，改变摄像机观察中心点位置
            {
                dx = dx * moveSpeed * 0.005f * targetDist;
                dy = dy * moveSpeed * 0.005f * targetDist;
                targetLookAt -= transform.up * dy + transform.right * dx;
                if (useMoveBounds)
                {
                    targetLookAt.x = Mathf.Clamp(targetLookAt.x, -moveBounds, moveBounds);
                    targetLookAt.y = Mathf.Clamp(targetLookAt.y, -moveBounds, moveBounds);
                    targetLookAt.z = Mathf.Clamp(targetLookAt.z, -moveBounds, moveBounds);
                }
            }

            else if (click1)        //按下鼠标右键旋转
            {
                dx = dx * thetaSpeed * 0.02f;
                dy = dy * phiSpeed * 0.02f;
                euler.x += dx;
                euler.y -= dy;
                euler.y = ClampAngle(euler.y, phiBoundMin, phiBoundMax);
                targetRot = Quaternion.Euler(euler.y, euler.x, 0);
            }

            targetDist -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * 0.5f;
            targetDist = Mathf.Max(0.1f, targetDist);
        }
    }

    public void FixedUpdate()        //每帧根据摄像机中线点位置不同重新定位摄像机的旋转和坐标
    {
        distance = moveSmoothing * targetDist + (1 - moveSmoothing) * distance;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSmoothing);
        target.position = Vector3.Lerp(target.position, targetLookAt, moveSmoothing);
        distanceVec.z = distance;
        transform.position = target.position - transform.rotation * distanceVec;
    }

    static float ClampAngle(float angle, float min, float max)        //控制旋转角度不超过360
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
