
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * 
 3D������
��Ҫ��������ϼ��� Physics RayCaster ��� 
������������Ҫ��Collider 
��������Ҫһ��EventSystem 
������ű��ϵ���Ҫ�϶�����������ϼ���
*/

[RequireComponent(typeof(RectTransform))]
public class UGUIDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool isDrag = false;
    //ƫ����
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

        //�ж��Ƿ�㵽UIͼƬ�ϵ�ʱ��
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out mouseWorldPosition))
        {
            if (isDrag)
            {
                rect.position = mouseWorldPosition + offset;
            }
            else
            {
                //����ƫ����
                offset = rect.position - mouseWorldPosition;
            }

            //ֱ�Ӹ���position�㵽��ʱ�������
            //rect.position = mouseWorldPosition;
        }
    }
}
