using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// creator Lixi
/* 
* 对需要交互的Ugui事件的监听进行封装__Ugui各类事件监听器
* 使用方法： 
	UGUIListener.Get(gameObject).onPointerClick += OnPointerClick;
	private void OnPointerClick(GameObject go)
	{
		Debug.Log("OnPointerClick");
	}
*/

/// <summary>
/// Ugui 事件：点击，按下，长按，抬起，停留在UI上方，移出UI上方,拖拽UI等等
/// 这里到底是用事件还是用委托，需要仔细考量，斟酌
/// public event UguiListenerDelegate onPointerClick;
/// public  UguiListenerDelegate onPointerClick;
/// </summary>
public class UGUIListener : UnityEngine.EventSystems.EventTrigger
{
	

	#region 长按
	/// <summary>
	/// 长按UI事件
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
	/// 射线进入UI上方事件_悬停(不用点击)
	/// </summary>
	public  UguiListenerDelegate onPointerEnter;

	/// <summary>
	/// 射线移出UI上方事件(不用点击)
	/// </summary>
	public  UguiListenerDelegate onPointerExit;

	/// <summary>
	/// UI被按下事件
	/// </summary>
	public  UguiListenerDelegate onPointerDown;

	/// <summary>
	/// UI被按下后又抬起事件(跟onPointerDown是成对出现的）
	/// </summary>
	public  UguiListenerDelegate onPointerUp;

	/// <summary>
	/// UI点击事件(如果按下后从ui上移开是不会触发这个事件的）
	/// </summary>
	public  UguiListenerDelegate onPointerClick;

	/// <summary>
	/// 
	/// </summary>
	public  UguiListenerDelegate onInitializePotentialDrag;

	/// <summary>
	/// 开始拖拽事件
	/// </summary>
	public  UguiListenerDelegate onBeginDrag;

	/// <summary>
	/// 拖拽中事件
	/// </summary>
	public  UguiListenerDelegate onDrag;

	/// <summary>
	/// 拖拽结束事件
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
	/// 定义传入更加具体详细的操作数据的委托
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
		#region 长按
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
		#region 长按
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
