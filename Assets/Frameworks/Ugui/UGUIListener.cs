using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// creator Lixi
/* 
* ����Ҫ������Ugui�¼��ļ������з�װ__Ugui�����¼�������
* ʹ�÷����� 
	UGUIListener.Get(gameObject).onPointerClick += OnPointerClick;
	private void OnPointerClick(GameObject go)
	{
		Debug.Log("OnPointerClick");
	}
*/

/// <summary>
/// Ugui �¼�����������£�������̧��ͣ����UI�Ϸ����Ƴ�UI�Ϸ�,��קUI�ȵ�
/// ���ﵽ�������¼�������ί�У���Ҫ��ϸ����������
/// public event UguiListenerDelegate onPointerClick;
/// public  UguiListenerDelegate onPointerClick;
/// </summary>
public class UGUIListener : UnityEngine.EventSystems.EventTrigger
{
	

	#region ����
	/// <summary>
	/// ����UI�¼�
	/// </summary>
	public  UguiListenerDelegate onLongPress;
	public UguiListenerDataDelegate onLongPressData;
	public UguiListenerDelegate onLongPressUp;
	public UguiListenerDataDelegate onLongPressUpData;

	public float longDelay = 1f;
	bool isDown = false;
	bool isLongPress = false;
	bool isHolding = false;
	float _lastIsDownTime;
	private PointerEventData _LongPressEventData;

	private void Update()
	{
		if (isDown && !isHolding)
		{
			if (Time.time - _lastIsDownTime > longDelay)
			{
				isLongPress = true;

				if (onLongPress != null) onLongPress(gameObject);
				if (onLongPressData != null) onLongPressData(gameObject, _LongPressEventData);
				_lastIsDownTime = Time.time;
				isHolding = true;
			}
		}
	}

	#endregion

	public static UGUIListener Get(GameObject go)
	{
		UGUIListener listener = go.GetComponent<UGUIListener>();
		if (listener == null) listener = go.AddComponent<UGUIListener>();
		return listener;
	}

	public delegate void UguiListenerDelegate(GameObject go);

	/// <summary>
	/// ���߽���UI�Ϸ��¼�_��ͣ(���õ��)
	/// </summary>
	public  UguiListenerDelegate onPointerEnter;

	/// <summary>
	/// �����Ƴ�UI�Ϸ��¼�(���õ��)
	/// </summary>
	public  UguiListenerDelegate onPointerExit;

	/// <summary>
	/// UI�������¼�
	/// </summary>
	public  UguiListenerDelegate onPointerDown;

	/// <summary>
	/// UI�����º���̧���¼�(��onPointerDown�ǳɶԳ��ֵģ�
	/// </summary>
	public  UguiListenerDelegate onPointerUp;

	/// <summary>
	/// UI����¼�(������º��ui���ƿ��ǲ��ᴥ������¼��ģ�
	/// </summary>
	public  UguiListenerDelegate onPointerClick;

	/// <summary>
	/// 
	/// </summary>
	public  UguiListenerDelegate onInitializePotentialDrag;

	/// <summary>
	/// ��ʼ��ק�¼�
	/// </summary>
	public  UguiListenerDelegate onBeginDrag;

	/// <summary>
	/// ��ק���¼�
	/// </summary>
	public  UguiListenerDelegate onDrag;

	/// <summary>
	/// ��ק�����¼�
	/// </summary>
	public  UguiListenerDelegate onEndDrag;
	public  UguiListenerDelegate onDrop;
	public  UguiListenerDelegate onScroll;
	public  UguiListenerDelegate onUpdateSelected;
	public  UguiListenerDelegate onSelect;
	public  UguiListenerDelegate onDeselect;
	public  UguiListenerDelegate onMove;
	public  UguiListenerDelegate onSubmit;
	public  UguiListenerDelegate onCancel;

	/// <summary>
	/// ���崫����Ӿ�����ϸ�Ĳ������ݵ�ί��
	/// </summary>
	/// <param name="go"></param>
	/// <param name="eventData"></param>
	public delegate void UguiListenerDataDelegate(GameObject go, PointerEventData eventData);
	public delegate void BaseEventDelegate(GameObject go, BaseEventData eventData);
	public delegate void AxisEventDelegate(GameObject go, AxisEventData eventData);

	public  UguiListenerDataDelegate onPointerEnterData;
	public  UguiListenerDataDelegate onPointerExitData;
	public  UguiListenerDataDelegate onPointerDownData;
	public  UguiListenerDataDelegate onPointerUpData;
	public  UguiListenerDataDelegate onPointerClickData;
	public  UguiListenerDataDelegate onInitializePotentialDragData;
	public  UguiListenerDataDelegate onBeginDragData;
	public  UguiListenerDataDelegate onDragData;
	public  UguiListenerDataDelegate onEndDragData;
	public  UguiListenerDataDelegate onDropData;
	public  UguiListenerDataDelegate onScrollData;
	public  BaseEventDelegate onUpdateSelectedData;
	public  BaseEventDelegate onSelectData;
	public  BaseEventDelegate onDeselectData;
	public  AxisEventDelegate onMoveData;
	public  BaseEventDelegate onSubmitData;
	public  BaseEventDelegate onCancelData;

	public override void OnBeginDrag(PointerEventData eventData)
	{
		if (onBeginDrag != null) onBeginDrag(gameObject);
		if (onBeginDragData != null) onBeginDragData(gameObject,eventData);

	}

	public override void OnCancel(BaseEventData eventData)
	{
		if (onCancel != null) onCancel(gameObject);
		if (onCancelData != null) onCancelData(gameObject,eventData);


	}

	public override void OnDeselect(BaseEventData eventData)
	{
		if (onDeselect != null) onDeselect(gameObject);
		if (onDeselectData != null) onDeselectData(gameObject, eventData);

	}

	public override void OnDrag(PointerEventData eventData)
	{
		if (onDrag != null) onDrag(gameObject);
		if (onDragData != null) onDragData(gameObject, eventData);

	}

	public override void OnDrop(PointerEventData eventData)
	{
		if (onDrop != null) onDrop(gameObject);
		if (onDropData != null) onDropData(gameObject, eventData);

	}

	public override void OnEndDrag(PointerEventData eventData)
	{
		if (onEndDrag != null) onEndDrag(gameObject);
		if (onEndDragData != null) onEndDragData(gameObject, eventData);

	}

	public override void OnInitializePotentialDrag(PointerEventData eventData)
	{
		if (onInitializePotentialDrag != null) onInitializePotentialDrag(gameObject);
		if (onInitializePotentialDragData != null) onInitializePotentialDragData(gameObject, eventData);

	}

	public override void OnMove(AxisEventData eventData)
	{
		if (onMove != null) onMove(gameObject);
		if (onMoveData != null) onMoveData(gameObject, eventData);

	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (onPointerClick != null) onPointerClick(gameObject);
		if (onPointerClickData != null) onPointerClickData(gameObject, eventData);

	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		#region ����
		isDown = true;
		_lastIsDownTime = Time.time;
		_LongPressEventData = eventData;

		#endregion

		if (onPointerDown != null) onPointerDown(gameObject);
		if (onPointerDownData != null) onPointerDownData(gameObject, eventData);

	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		if (onPointerEnter != null) onPointerEnter(gameObject);
		if (onPointerEnterData != null) onPointerEnterData(gameObject, eventData);

	}

	public override void OnPointerExit(PointerEventData eventData)
	{

		if (onPointerExit != null) onPointerExit(gameObject);
		if (onPointerExitData != null) onPointerExitData(gameObject, eventData);

		if (isDown) isDown = false;
		isLongPress = false;
		isHolding = false;

	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		#region ����
		if (isDown)
		{
			isDown = false;
			isHolding = false;
			if(isLongPress)
			{
				if (onLongPressUp != null)     onLongPressUp(gameObject);
				if (onLongPressUpData != null) onLongPressUpData(gameObject, eventData);
				isLongPress = false;
			}
		}
		#endregion

		if (onPointerUp != null) onPointerUp(gameObject);
		if (onPointerUpData != null) onPointerUpData(gameObject, eventData);

	}

	public override void OnScroll(PointerEventData eventData)
	{
		if (onScroll != null) onScroll(gameObject);
		if (onScrollData != null) onScrollData(gameObject, eventData);

	}

	public override void OnSelect(BaseEventData eventData)
	{
		if (onSelect != null) onSelect(gameObject);
		if (onSelectData != null) onSelectData(gameObject, eventData);

	}

	public override void OnSubmit(BaseEventData eventData)
	{
		if (onSubmit != null) onSubmit(gameObject);
		if (onSubmitData != null) onSubmitData(gameObject, eventData);

	}

	public override void OnUpdateSelected(BaseEventData eventData)
	{
		if (onUpdateSelected != null) onUpdateSelected(gameObject);
		if (onUpdateSelectedData != null) onUpdateSelectedData(gameObject,eventData);

	}
}
