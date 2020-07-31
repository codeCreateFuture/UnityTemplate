using UnityEngine;
using System.Collections;

public class translateobject : MonoBehaviour {

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
    public float x = 0.0f;
    public float y = 0.0f;

    public float x2 = 0.0f;
    public float y2 = 0.0f;

    public float tmpx = 0.0f;
    public float tmpy = 0.0f;

    //记录上一次手机触摸位置判断用户是在左放大还是缩小手势  
    private Vector2 oldPosition1;
    private Vector2 oldPosition2;
    private Vector3 oldscale;

    //初始化游戏信息设置  
    void Start()
    {
        //var angles = transform.eulerAngles;
        //LzxDebug.Log(transform.eulerAngles);
        //x = angles.y;
        //y = angles.x+180;
        oldscale = transform.localScale;
        // Make the rigid body not change rotation  
        //if (GetComponent<Rigidbody>())
           // GetComponent<Rigidbody>().freezeRotation = true;
        //LzxDebug.Log("!!!!!!!!!!!!!!!!!!!!!!yes");
    }

    void Update()
    {
        //if (!GameManage.instance.CanTranslateModel())
        //{
        //   // return;
        //}
        //此处在实际中需要删除掉一个
        if (Input.GetMouseButton(0))
        {
            //LzxDebug.Log("touch");
            //根据触摸点计算X与Y位置
            float x1 = 0.0f;
            float y1 = 0.0f;
            //根据触摸点计算X与Y位置
            x1 = Input.GetAxis("Mouse X") * xSpeed * 0.04f;
            y1 = Input.GetAxis("Mouse Y") * ySpeed * 0.04f;

            //这里需要增加一个冗余值的判断，减小误旋转量
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

        //判断触摸数量为单点触摸  
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                tmpx = 0.0f;
                tmpy = 0.0f;
            }
            //触摸类型为移动触摸
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                float x1 = 0.0f;
                float y1 = 0.0f;
                //根据触摸点计算X与Y位置
                x1= Input.GetAxis("Mouse X") * xSpeed * 0.04f;
                y1= Input.GetAxis("Mouse Y") * ySpeed * 0.04f;

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

        //判断触摸数量为多点触摸
        if (Input.touchCount > 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                oldPosition1 = Vector2.zero;
                oldPosition2 = Vector2.zero;
            }
            //前两只手指触摸类型都为移动触摸  
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                //计算出当前两点触摸点的位置  
                var tempPosition1 = Input.GetTouch(0).position;
                var tempPosition2 = Input.GetTouch(1).position;
                //函数返回真为放大，返回假为缩小  
                if (!isEnlarge(oldPosition1, oldPosition2, tempPosition1, tempPosition2))
                {
                    //放大系数超过3以后不允许继续放大  
                    //这里的数据是根据我项目中的模型而调节的，大家可以自己任意修改  
                    if (distance > 3)
                    {
                        distance -= 0.5f;
                    }
                }
                else
                {
                    //缩小洗漱返回18.5后不允许继续缩小  
                    //这里的数据是根据我项目中的模型而调节的，大家可以自己任意修改  
                    if (distance < 18.5)
                    {
                        distance += 0.5f;
                    }
                }
                //备份上一次触摸点的位置，用于对比  
                oldPosition1 = tempPosition1;
                oldPosition2 = tempPosition2;
            }
        }
    }

    //函数返回真为放大，返回假为缩小  
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

    //Update方法一旦调用结束以后进入这里算出重置摄像机的位置  
    void LateUpdate()
    {
        //y = ClampAngle(y, yMinLimit, yMaxLimit);
        //var rotation = Quaternion.Euler(-y, x, 0);
        //rotation = new Quaternion(rotation.x-0.7f,rotation.y+0.7f,rotation.z,rotation.w+1.4f);

        //transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
        if (x != 0.0f || y != 0.0f)
        {
            //LzxDebug.Log("rotate");
             transform.Rotate(new Vector3(0,-x,0), Space.World);
             x = 0;
             y = 0;
        }
       
        //LzxDebug.Log(rotation);
        var scale = new Vector3(oldscale.x * distance / 10, oldscale.y * distance / 10, oldscale.z * distance / 10);
       // transform.rotation = rotation;
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
}
