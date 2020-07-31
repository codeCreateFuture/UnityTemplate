﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveToTarget : MonoBehaviour
{
    Transform MyTrans;
    List<Vector3> endPoints;
    float speed = 5;
    float angluarSpeed = 100;

    void Start()
    {
        Debug.unityLogger.logEnabled = false;
        MyTrans = GetComponent<Transform>();
        endPoints = new List<Vector3>();
    }

  public  float test = 10;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MyTrans.rotation= Quaternion.Euler(0, 90f, 0);
            
        }


        if (Input.GetMouseButtonDown(1))
        {
            UpdateControl();
        }
        if (endPoints.Count > 0)
        {
            Vector3 v = endPoints[0] - MyTrans.position;
            var dot = Vector3.Dot(v, MyTrans.right);
            Vector3 next = v.normalized * speed * Time.deltaTime;
            float angle = Vector3.Angle(v, MyTrans.forward);
           
            if (Vector3.SqrMagnitude(v) > 1f)
            {
                float minAngle = Mathf.Min(angle, angluarSpeed * Time.deltaTime);
                //点乘
                if (angle > 1f)
                {

                    Debug.Log(angle);
                   // Debug.Log("dot :"+dot);
                    //transform.Rotate(Vector3.Cross(tank.forward, v.normalized), minAngle);
                    if (dot > 0)
                    {
                        MyTrans.Rotate(new Vector3(0, minAngle, 0));
                    }
                    else
                    {
                        MyTrans.Rotate(new Vector3(0, -minAngle, 0));
                    }
                }
                else
                {
                    MyTrans.LookAt(endPoints[0]);
                    MyTrans.position += next;
                }
            }
            else
            {
                endPoints.RemoveAt(0);
            }

        }
    }
    void UpdateControl()
    {
        //获取屏幕坐标
        Vector3 mousepostion = Input.mousePosition;
        //定义从屏幕
        Ray ray = Camera.main.ScreenPointToRay(mousepostion);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                AddEndPoint(hitInfo.point);
            }
            else
            {
                ReSetEndPoint(hitInfo.point);
            }
            //transform.LookAt(endPoint);
            //transform.Translate(movePoint * 0.1f);
        }

    }
    void AddEndPoint(Vector3 endPoint)
    {
        endPoint.y = MyTrans.position.y;
        endPoints.Add(endPoint);
    }
    void ReSetEndPoint(Vector3 endPoint)
    {
        endPoint.y = MyTrans.position.y;
        endPoints.Clear();
        endPoints.Add(endPoint);
    }


    
}
