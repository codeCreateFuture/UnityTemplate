using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{


    // 长按触发时间
    public float delay = 0.5f;

    // 按钮是否是按下状态  
    private bool isDown = false;

    // 记录按下的时间
    private float lastIsDownTime;

  


    void Update()
    {
        // 如果按钮是被按下状态  
        if (isDown)
        {
            // 当前时间 -  按钮最后一次被按下的时间 > 延迟时间0.5秒  
            if (Time.time - lastIsDownTime > delay)
            {
                // 触发长按方法  
                Debug.Log("触发长按事件。。。。");
                // 记录按钮最后一次被按下的时间  
                lastIsDownTime = Time.time;

            }
        }

    }

    // 当按钮被按下后系统自动调用此方法  
    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        lastIsDownTime = Time.time;
    }

    // 当按钮抬起的时候自动调用此方法  
    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }

    // 当鼠标从按钮上离开的时候自动调用此方法  
    public void OnPointerExit(PointerEventData eventData)
    {
        isDown = false;
    }
}
