using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomGesture : MonoBehaviour {

    private Touch oldTouch1;  //�ϴδ�����1(��ָ1)
    private Touch oldTouch2;  //�ϴδ�����2(��ָ2)


    public float scaleFactor = 0.1f;
    public float heightFactor = 0.1f;
    public GameObject cube;
    void Update()
    {
#if UNITY_EDITOR
        EditorUpdate();
#else
   PhoneUpdate();
#endif

    }

    Vector3 oldPos1;  
    Vector3 oldPos2;

    public bool isPress = false;
    void EditorUpdate()
    {
       
        if (Input.GetMouseButtonDown(0)&& isTriggle)
        {
           // Debug.Log("GetMouseButtonDown");
            isPress = true;
           // Debug.Log(Input.mousePosition);

            oldPos1 = Input.mousePosition;
            oldPos2 = Camera.main.WorldToScreenPoint(cube.GetComponent<Transform>().position);
        }


        if (Input.GetMouseButton(0)& isTriggle)
        {
            if (!isPress) return;


            //��㴥��, �Ŵ���С
            Vector3 newTouch1 = Input.mousePosition;
            Vector3 newTouch2 = Camera.main.WorldToScreenPoint(cube.GetComponent<Transform>().position);
            //��2��տ�ʼ�Ӵ���Ļ, ֻ��¼����������
            //if (newTouch2.phase == TouchPhase.Began)
            //{
            //    oldTouch2 = newTouch2;
            //    oldTouch1 = newTouch1;
            //    return;
            //}
            //�����ϵ����������µ��������룬���Ҫ�Ŵ�ģ�ͣ���СҪ����ģ��
           // float oldDistance = Vector2.Distance(oldPos1, oldPos2);
            //float newDistance = Vector2.Distance(newTouch1, newTouch2);

            float oldDistance = oldPos1.x - oldPos2.x;
            float newDistance = newTouch1.x - newTouch2.x;
            //��������֮�Ϊ����ʾ�Ŵ����ƣ� Ϊ����ʾ��С����
            float offset = newDistance - oldDistance;

            Debug.Log("oldDistance=" + oldDistance);
            Debug.Log("newDistance=" + newDistance);

            Debug.Log("offset="+offset);
            //�Ŵ����ӣ� һ�����ذ� 0.01������(100�ɵ���)
            float tempScaleFactor = offset *scaleFactor;

            float oldHeight = oldPos1.y - oldPos2.y;
            float newHeight = newTouch1.y - newTouch2.y;
            float heightOffset = newHeight - oldHeight;
            float tempHeightFactor = heightOffset * heightFactor;

            if(Mathf.Abs(offset) > Mathf.Abs(heightOffset))
            {
                Vector3 localScale = transform.localScale;
                Vector3 scale = new Vector3(localScale.x + tempScaleFactor,
                    localScale.y + tempScaleFactor,
                    localScale.z + tempScaleFactor);
                //��ʲô����½�������
                if (scale.x >= 0.05f && scale.y >= 0.05f && scale.z >= 0.05f)
                {
                    cube.GetComponent<Transform>().localScale = scale;
                }
            }else
            {
                Vector3 temPos = cube.GetComponent<Transform>().position;
                cube.GetComponent<Transform>().position = new Vector3(temPos.x, temPos.y + tempHeightFactor, temPos.z);
            }

            //��ס���µĴ����㣬�´�ʹ��
            oldPos1 = newTouch1;
            oldPos2 = newTouch2;
        }


        if (Input.GetMouseButtonUp(1))
        {
            isPress = false;
        }



    }

    bool isTriggle = false;
    private void OnMouseDown()
    {
        Debug.Log("mouseDown");
        isTriggle = true;
    }
    private void OnMouseUp()
    {
        Debug.Log("mouse up");
        isTriggle = false;
    }

    void PhoneUpdate()
    {
        //û�д��������Ǵ�����Ϊ0
        if (Input.touchCount <= 0)
        {
            return;
        }
        //��㴥��, �Ŵ���С
        Touch newTouch1 = Input.GetTouch(0);
        Touch newTouch2 = Input.GetTouch(1);
        //��2��տ�ʼ�Ӵ���Ļ, ֻ��¼����������
        if (newTouch2.phase == TouchPhase.Began)
        {
            oldTouch2 = newTouch2;
            oldTouch1 = newTouch1;
            return;
        }
        //�����ϵ����������µ��������룬���Ҫ�Ŵ�ģ�ͣ���СҪ����ģ��
        float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
        float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);
        //��������֮�Ϊ����ʾ�Ŵ����ƣ� Ϊ����ʾ��С����
        float offset = newDistance - oldDistance;
        //�Ŵ����ӣ� һ�����ذ� 0.01������(100�ɵ���)
        float scaleFactor = offset / 100f;
        Vector3 localScale = transform.localScale;
        Vector3 scale = new Vector3(localScale.x + scaleFactor,
            localScale.y + scaleFactor,
            localScale.z + scaleFactor);
        //��ʲô����½�������
        if (scale.x >= 0.05f && scale.y >= 0.05f && scale.z >= 0.05f)
        {
            transform.localScale = scale;
        }
        //��ס���µĴ����㣬�´�ʹ��
        oldTouch1 = newTouch1;
        oldTouch2 = newTouch2;
    }
}
