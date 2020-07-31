using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.VR;
using System.Collections.Generic;

public class translateObj : MonoBehaviour
{
    //用于绑定参照物对象  
    //public Transform target;
    //缩放系数
    public float distance = 10.0f;
    //左右滑动移动速度
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
    //缩放限制系数
    public float yMinLimit = -20;
    public float yMaxLimit = 80;
    //摄像头的位置
    private float x = 0.0f;
    private float y = 0.0f;
    private float x2 = 0.0f;
    private float y2 = 0.0f;
    private float tmpx = 0.0f;
    private float tmpy = 0.0f;
    //记录上一次手机触摸位置判断用户是在左放大还是缩小手势
    private Vector2 oldPosition1;
    private Vector2 oldPosition2;
    private Vector3 oldscale;
    private Camera m_arcamera;
    private bool m_bmoving = false;

    private bool isgetmodel = false;

    private float width;
    private float height;

    private float perTime = 1.0f;
    private float AllTime;

    private Vector3 v3 = Vector3.zero;
    //初始化游戏信息设置

    bool isArPaintModel = false;
    bool isGetArPaintModel = false;    
    void Start()
    {
        oldscale = transform.localScale;
        GameObject obj = GameObject.Find("Camera");
        if (obj != null)
        {
            //LzxDebug.Log("*****找到了ar相机");
            m_arcamera = obj.GetComponent<Camera>();
        }
        width = Screen.width;
        height = Screen.height;

        if(gameObject.name.IndexOf("d3_") == 0)
        {
            isArPaintModel = true;
        }
    }

    void Update()
    {
       
        
        
        //if(UICamera.hoveredObject!=null)
        //{
        //    return;
        //}
        
        //此处在实际中需要删除掉一个
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButton(0))
            {

                


                //LzxDebug.Log("mouse down");
                Vector3 vec3 = new Vector3(0, 0, 0);
                Vector3 difvalue = Vector3.zero;
                vec3 = Input.mousePosition;
                vec3 = ClampVector(vec3);
                //LzxDebug.Log(vec3);
                Ray Mray = m_arcamera.ScreenPointToRay(vec3);
                Vector3 v = CalPlaneLineIntersectPoint(new Vector3(0, 0, -1), new Vector3(0, 0, 0), Mray.direction, Mray.origin);
                //LzxDebug.Log("v " + v);
                RaycastHit Mhit;
             
                if (Physics.Raycast(Mray, out Mhit))
                {
                    if (Mhit.transform.gameObject.tag == "animation")
                    {
                        if (!isgetmodel)
                        {
                            AllTime += Time.deltaTime;
                            if (AllTime > perTime)
                            {
                                isgetmodel = true;
                                v3 = v - Mhit.transform.position;
                                distance += 2.0f;
                                isGetArPaintModel = true;
                            }else
                            {
                                isGetArPaintModel = false;
                            }
                        }
                    }
                    else {
                        AllTime = 0;
                    }
                }
                else
                {
                    AllTime = 0;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (isgetmodel)
                {
                    distance -= 2.0f;
                }
                isgetmodel = false;
                AllTime = 0;
            }
            if (isgetmodel)
            {
                if(isArPaintModel==false)
                { 
                Vector3 nvec3 = Input.mousePosition;
                nvec3 = ClampVector(nvec3);
                Ray nMray = m_arcamera.ScreenPointToRay(nvec3);
                Vector3 nv = CalPlaneLineIntersectPoint(new Vector3(0, 0, -1), new Vector3(0, 0, 0), nMray.direction, nMray.origin);
                transform.position = nv - v3;
                }
            }
            if (Input.GetMouseButton(0) && !isgetmodel)
            {
                float x1 = 0.0f;
                float y1 = 0.0f;
                x1 = Input.GetAxis("Mouse X") * xSpeed * 0.04f;
                y1 = Input.GetAxis("Mouse Y") * ySpeed * 0.04f;
                if (Mathf.Abs(x1) > 1.0f && Mathf.Abs(x1 - tmpx) > 0.01f && Mathf.Abs(tmpx) > 0.01f && Mathf.Abs(x1) > Mathf.Abs(y1))
                {
                    x += x1;
                }
                if (Mathf.Abs(y1) > 1.0f && Mathf.Abs(x1 - tmpy) > 0.01f && Mathf.Abs(tmpy) > 0.01f && Mathf.Abs(y1) > Mathf.Abs(x1))
                {
                    y -= y1;
                }
                tmpx = x1;
                tmpy = y1;
            }
        }
        //判断触摸数量为单点触摸  
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                tmpx = 0.0f;
                tmpy = 0.0f;
                Vector3 vec3 = new Vector3(0, 0, 0);
                vec3 = Input.mousePosition;
                //LzxDebug.Log(vec3);
                Ray Mray = m_arcamera.ScreenPointToRay(vec3);
                Vector3 p = CalPlaneLineIntersectPoint(new Vector3(0, 0, -1), new Vector3(0, 0, 0), Mray.direction, Mray.origin);
                RaycastHit Mhit;
                if (Physics.Raycast(Mray, out Mhit))
                {
                    if (Mhit.transform.gameObject.tag == "animation")
                    {
                        if (!isgetmodel)
                        {
                            AllTime += Time.deltaTime;
                            if (AllTime > perTime)
                            {
                                isgetmodel = true;
                                distance += 2.0f;
                                isGetArPaintModel = true;
                            }
                            else
                            {
                                isGetArPaintModel = false;
                            }
                        }
                    }
                    else
                    {
                        AllTime = 0;
                        LzxDebug.Log("碰到的模型不是需要的");
                    }
                }
                else
                {
                    AllTime = 0;
                    LzxDebug.Log("没碰到模型");
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (isgetmodel)
                    distance -= 2.0f;
                isgetmodel = false;
                AllTime = 0;
            }
            //触摸类型为移动触摸
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (isgetmodel)
                {
                    if(isArPaintModel==false)
                    { 
                    Vector3 nvec3 = Input.mousePosition;
                    nvec3 = ClampVector(nvec3);
                    LzxDebug.Log(nvec3);

                    Ray nMray = m_arcamera.ScreenPointToRay(nvec3);
                    Vector3 nv = CalPlaneLineIntersectPoint(new Vector3(0, 0, -1), new Vector3(0, 0, 0), nMray.direction, nMray.origin);
                    LzxDebug.Log(nv);
                    transform.position = nv;
                    }
                }
                else
                {
                    float x1 = 0.0f;
                    float y1 = 0.0f;
                    //根据触摸点计算X与Y位置
                    x1 = Input.GetAxis("Mouse X") * xSpeed * 0.04f;
                    y1 = Input.GetAxis("Mouse Y") * ySpeed * 0.04f;
                    //这里需要增加一个冗余值的判断，减小误旋转量
                    if (Mathf.Abs(x1) > 2.0f && Mathf.Abs(x1 - tmpx) > 0.01f && Mathf.Abs(tmpx) > 0.01f && Mathf.Abs(x1) > Mathf.Abs(y1))
                    {
                        x += x1;
                    }
                    else if (Mathf.Abs(y1) > 2.0f && Mathf.Abs(x1 - tmpy) > 0.01f && Mathf.Abs(tmpy) > 0.01f && Mathf.Abs(y1) > Mathf.Abs(x1))
                    {
                        y -= y1;
                    }
                    tmpx = x1;
                    tmpy = y1;
                }
            }
        }
        if (Input.touchCount > 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                oldPosition1 = Vector2.zero;
                oldPosition2 = Vector2.zero;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                var tempPosition1 = Input.GetTouch(0).position;
                var tempPosition2 = Input.GetTouch(1).position; 
                if (!isEnlarge(oldPosition1, oldPosition2, tempPosition1, tempPosition2))
                {
                    if (distance > 3)
                    {
                        distance -= 0.2f;
                    }
                }
                else
                {
                    if (distance < 18.5)
                    {
                        distance += 0.2f;
                    }
                }
                //备份上一次触摸点的位置，用于对比  
                oldPosition1 = tempPosition1;
                oldPosition2 = tempPosition2;
            }
        }
    }

    Vector3 ClampVector(Vector3 vec)
    {
        float xmin = width/8;
        float xmax = width - width/8;

        float ymin = height/6;
        float ymax = height - height/6;

        return new Vector3(Mathf.Clamp(vec.x,xmin,xmax),Mathf.Clamp(vec.y,ymin,ymax),vec.z);
    }

    bool isEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    {
        //函数传入上一次触摸两点的位置与本次触摸两点的位置计算出用户的手势  
        var leng1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        var leng2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
        if (leng1 < leng2)
        {
            //放大手势
            return true;
        }
        else
        {
            //缩小手势  
            return false;
        }
    }

    Vector3 CalPlaneLineIntersectPoint(Vector3 planeVector, Vector3 planePoint,
                                Vector3 lineVector, Vector3 linePoint
                                )
    {
        Vector3 resultPoint;
        float vpt;
        float t;
        vpt = planeVector.x * lineVector.x + planeVector.y * lineVector.y + planeVector.z * lineVector.z;
        if (vpt == 0)
        {
            resultPoint.x = -1;
            resultPoint.y = -1;
            resultPoint.z = -1;
        }
        else
        {
            t = ((planePoint.x - linePoint.x) * planeVector.x + (planePoint.y - linePoint.y) * planeVector.y + (planePoint.z - linePoint.z) * planeVector.z) / vpt;
            resultPoint.x = linePoint.x + lineVector.x * t;
            resultPoint.y = linePoint.y + lineVector.y * t;
            resultPoint.z = linePoint.z + lineVector.z * t;
        }
        return resultPoint;
    }

    void LateUpdate()
    {
        if (x != 0.0f || y != 0.0f)
        {
            x2 += (-x);
            y2 += (-y);
            if ((-y2) >= -20.0f && (-y2) <= 90.0f)
            {
                //transform.Rotate(new Vector3(-y, 0, 0), Space.World);
                //if (GameManage.instance.GetIsMirror())
                if (true)
                {
                    transform.Rotate(new Vector3(0, x, 0), Space.Self);
                }
                else
                {
                    transform.Rotate(new Vector3(0, -x, 0), Space.Self);
                }
            }
            else if ((-y2) > 90.0f)
            {
                y2 = -90.0f;
            }
            else if ((-y2) < -20.0f)
            {
                y2 = 20.0f;
            }
            x = 0;
            y = 0;
        }
        var scale = new Vector3(oldscale.x * distance / 10, oldscale.y * distance / 10, oldscale.z * distance / 10);
        transform.localScale = scale;
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }


    int firstMouseDown = 0;
    IEnumerator OnMouseDown()
    {
        LzxDebug.Log("OnMouseDown " + gameObject.name + " isArPaintModel " + isArPaintModel + " isgetmodel " + isgetmodel + "isGetArPaintModel  " + isGetArPaintModel);
        if (isArPaintModel)
        { 

        Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z));

        Debug.Log("mousePosition " + Input.mousePosition);

        //当鼠标左键按下时  
        while (Input.GetMouseButton(0))
        {

            LzxDebug.Log("while OnMouseDown  GetMouseButton" + gameObject.name + " isArPaintModel " + isArPaintModel + " isgetmodel " + isgetmodel + "isGetArPaintModel  " + isGetArPaintModel);

            if (isGetArPaintModel)
            { 
            
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z);
            
            Vector3 CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            //CurPosition就是物体应该的移动向量赋给transform的position属性        
            transform.position = CurPosition;
            
            
            }
            yield return new WaitForFixedUpdate();
        }
        }

    }

    bool close = false;
   
}
