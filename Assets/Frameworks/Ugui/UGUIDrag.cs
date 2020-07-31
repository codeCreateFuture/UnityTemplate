
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * 
 3D物体上
需要在摄像机上加入 Physics RayCaster 组件 
另外物体上需要有Collider 
场景中需要一个EventSystem 
将上面脚本拖到需要拖动的物体对象上即可
*/

[RequireComponent(typeof(RectTransform))]
public class UGUIDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool isDrag = false;
    //偏移量
    private Vector3 offset = Vector3.zero;

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = false;
        SetDragObjPostion(eventData);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
        SetDragObjPostion(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SetDragObjPostion(eventData);
    }



    void SetDragObjPostion(PointerEventData eventData)
    {
        RectTransform rect = this.GetComponent<RectTransform>();
        Vector3 mouseWorldPosition;

        //判断是否点到UI图片上的时候
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out mouseWorldPosition))
        {
            if (isDrag)
            {
                rect.position = mouseWorldPosition + offset;
            }
            else
            {
                //计算偏移量
                offset = rect.position - mouseWorldPosition;
            }

            //直接赋予position点到的时候回跳动
            //rect.position = mouseWorldPosition;
        }
    }
}
