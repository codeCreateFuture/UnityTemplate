using UnityEngine;

/// <summary>
/// 行军路线
/// </summary>
public class ArrowGuideMapLine : MonoBehaviour
{
    private Vector3 startPos = Vector3.one;
    private Vector3 endPos = Vector3.one;
    private Vector3 rotation = Vector3.zero;

    private Material material;
    private bool isMove;
    public Vector2 moveDir = new Vector2(0, 0.01f);
    public Vector2 resetOffset = new Vector2(0, 100);


    public Transform startTran;
    public Transform endPosTran;

    void Awake()
    {
        isMove = false;
      
        material = GetComponent<Renderer>().material;
    }

    private void Start()
    {
        SetLine(Vector3.zero, Vector3.one * 10);
    }

    /// <summary>
    /// 设置材质的Offset的属性，让箭头移动起来
    /// </summary>
    private void Update()
    {
        if (isMove)
        {
            if (material.mainTextureOffset == resetOffset)
                material.mainTextureOffset = moveDir;
            material.mainTextureOffset += moveDir;
        }

        if(startPos!=null&&endPosTran!=null)
        {
            SetLine(startTran.position, endPosTran.position);
        }
    }

    public void SetLine(Vector3 startPos, Vector3 endPos)
    {
        this.startPos = startPos;
        this.endPos = endPos;
        transform.localScale = Vector3.one * 0.05f;
        transform.position = startPos;
        transform.eulerAngles = Vector3.zero;

        var scale = transform.localScale;
        var lineLong = CalLineLong() * 2;
        scale.z = scale.z * lineLong;
        transform.localScale = scale;
        rotation.y = CalLineAngle();
        transform.eulerAngles = rotation;
        material.mainTextureScale = new Vector2(1, lineLong);
        transform.Translate(0, 0, lineLong / 4, Space.Self);


        Quaternion targetQuat = Quaternion.LookRotation(endPosTran.position - startTran.position);
        transform.rotation = targetQuat;
        transform.position = (endPosTran.position + startTran.position) * 0.5f;


        isMove = true;
    }

    /// <summary>
    /// 计算行军路线长度
    /// </summary>
    private float CalLineLong()
    {
        return Mathf.Sqrt(Mathf.Pow(startPos.x - endPos.x, 2) + Mathf.Pow(startPos.z - endPos.z, 2));
    }

    /// <summary>
    /// 计算行军路线角度
    /// </summary>
    private float CalLineAngle()
    {
        //斜边长度
        float length = Mathf.Sqrt(Mathf.Pow((startPos.x - endPos.x), 2) + Mathf.Pow((startPos.z - endPos.z), 2));
        //对边比斜边 sin
        float hudu = Mathf.Asin(Mathf.Abs(startPos.z - endPos.z) / length);
        float ag = hudu * 180 / Mathf.PI;

        //第一象限
        if ((endPos.x - startPos.x) >= 0 && (endPos.z - startPos.z >= 0))
            ag = -ag + 90;
        //第二象限
        else if ((endPos.x - startPos.x) <= 0 && (endPos.z - startPos.z >= 0))
            ag = ag - 90;
        //第三象限
        else if ((endPos.x - startPos.x) <= 0 && (endPos.z - startPos.z) <= 0)
            ag = -ag + 270;
        //第四象限
        else if ((endPos.x - startPos.x) >= 0 && (endPos.z - startPos.z) <= 0)
            ag = ag + 90;
        return ag;
    }
}
