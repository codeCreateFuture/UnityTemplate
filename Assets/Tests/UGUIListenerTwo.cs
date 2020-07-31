using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;



/// <summary>
/// * 对游戏项目中需要交互的UI事件的监听进行封装即UI监听器
/// * 事件：点击，按下，长按，抬起，停留在UI上方，移出UI上方,拖拽UI等等
/// </summary>
	public class UGUIListenerTwo : UnityEngine.EventSystems.EventTrigger
	{
	    /// 
	    /// 定义委托1：只需传入目标监听UI对象即可
	    /// 
	    /// 
	    public delegate void VoidDelegate(GameObject ob);
	    /// 
	    /// 定义委托2：不仅需要传入目标监听UI对象，还需要传更加具体详细的操作数据
	    /// 一般不常用
	    /// 
	    /// 
	    /// 
	    public delegate void DelegatePointer(GameObject ob, PointerEventData eventData);
	
	    /// 
	    /// 声明委托：UI点击事件
	    /// 
	    public VoidDelegate onClick;
	    public DelegatePointer onClickData;
	
	    /// 
	    /// 声明委托：UI被按下事件
	    /// 
	    public VoidDelegate onDown;
	    public DelegatePointer onDownData;
	
	    /// 
	    /// 声明委托：UI被按下后又抬起事件
	    /// 
	    public VoidDelegate onUp;
	    public DelegatePointer onUpData;
	
	    /// 
	    /// 声明委托：进入UI上方事件
	    /// 
	    public VoidDelegate onEnter;
	    public DelegatePointer onEnterData;
	
	    /// 
	    /// 声明委托：移出UI上方事件
	    /// 
	    public VoidDelegate onExit;
	    public DelegatePointer onExitData;
	
	    /// 
	    /// 声明委托：长按UI事件
	    /// 
	    public VoidDelegate onLongPress;
	    public DelegatePointer onLongPressData;
	
	    /// 
	    /// 声明委托：长按UI后抬起事件
	    /// 
	    public VoidDelegate onLongPressUp;
	    public DelegatePointer onLongPressUpData;
	
	    // 延迟时间
	    private float delay = 0.5f;
	    // 按钮是否是按下状态
	    private bool isDown = false;
	    private bool isHolding = false;
	    // 按钮最后一次是被按住状态时候的时间
	    private float lastIsDownTime;
	    private PointerEventData _tmpLongPressEventData;
	
	    /// 
	    /// 声明委托：关于拖拽UI的：开始拖拽，拖拽中，拖拽结束事件
	    /// 
	    public DelegatePointer onBeginDragData;
	    public DelegatePointer onDragData;
	    public DelegatePointer onEndDragData;
	
	    //public VoidDelegate onSelect;
	    //public VoidDelegate onUpdateSelect;
	
	
	    void Update()
	    {
	        // 如果按钮是被按下状态
	        if (isDown && !isHolding)
	        {
	            // 当前时间 -  按钮最后一次被按下的时间 > 延迟时间delay秒
	            if (Time.time - lastIsDownTime > delay)
	            {
	                // 触发长按方法
	                if (onLongPress != null) onLongPress(gameObject);
	                if (onLongPressData != null) onLongPressData(gameObject, _tmpLongPressEventData);
	
	                // 记录按钮最后一次被按下的时间
	                lastIsDownTime = Time.time;
	                isHolding = true;
	            }
	        }
	    }
	
	    /// 
	    /// UI监听器的构造函数：对UI添加上监听器
	    /// 
	    /// 
	    /// 
	    static public UGUIListenerTwo Get(GameObject ob)
	    {
	        UGUIListenerTwo listener = ob.GetComponent<UGUIListenerTwo>();
	        if (listener == null) listener = ob.AddComponent<UGUIListenerTwo>();
	        return listener;
	    }
	
	
	    /// 
	    /// 注册委托：UI点击事件
	    /// 
	    /// 
	    public override void OnPointerClick(PointerEventData eventData)
	    {
	        if (onClick != null) onClick(gameObject);
	        if (onClickData != null) onClickData(gameObject, eventData);
	    }
	
	
	    /// 
	    /// 注册委托：按下UI事件
	    /// 
	    /// 
	    public override void OnPointerDown(PointerEventData eventData)
	    {
	        //设定并记录下按下UI时刻的相关状态信息（为按下UI操作事件，衍生出来的长按UI操作做准备）
	        isDown = true;
	        lastIsDownTime = Time.time;
	        _tmpLongPressEventData = eventData;
	
	        if (onDown != null) onDown(gameObject);
	        if (onDownData != null) onDownData(gameObject, eventData);
	    }
	
	    /// 
	    /// 注册委托：进入UI上方事件
	    /// 
	    /// 
	    public override void OnPointerEnter(PointerEventData eventData)
	    {
	        if (onEnter != null) onEnter(gameObject);
	        if (onEnterData != null) onEnterData(gameObject, eventData);
	    }
	
	    /// 
	    /// 注册委托：进入UI后又移出UI上方事件
	    /// 
	    /// 
	    public override void OnPointerExit(PointerEventData eventData)
	    {
	        if (onExit != null) onExit(gameObject);
	        if (onExitData != null) onExitData(gameObject, eventData);
	    }
	
	    /// 
	    /// 注册委托：
	    /// 1.按下UI后，抬起事件
	    /// 2.长按UI后，抬起事件
	    /// 
	    /// 
	    public override void OnPointerUp(PointerEventData eventData)
	    {
	        if (isDown == true)
	        {
	            if (onLongPressUp != null) onLongPressUp(gameObject);
	            if (onLongPressUpData != null) onLongPressUpData(gameObject, eventData);
	            isDown = false;
	            isHolding = false;
	        }
	
	        if (onUp != null) onUp(gameObject);
	        if (onUpData != null) onUpData(gameObject, eventData);
	    }
	
	    /// 
	    /// 注册委托：开始拖拽UI
	    /// 
	    /// 
	    public override void OnBeginDrag(PointerEventData eventData)
	    {
	        if (onBeginDragData != null) onBeginDragData(gameObject, eventData);
	    }
	    /// 
	    /// 注册委托：UI拖拽中
	    /// 
	    /// 
	    public override void OnDrag(PointerEventData eventData)
	    {
	        if (onDragData != null) onDragData(gameObject, eventData);
	    }
	    /// 
	    ///注册委托：UI拖拽结束
	    /// 
	    /// 
	    public override void OnEndDrag(PointerEventData eventData)
	    {
	        if (onEndDragData != null) onEndDragData(gameObject, eventData);
	    }
	
	
	    //public override void OnSelect(BaseEventData eventData)
	    //{
	    //    if (onSelect != null) onSelect(gameObject);
	    //}
	    //public override void OnUpdateSelected(BaseEventData eventData)
	    //{
	    //    if (onUpdateSelect != null) onUpdateSelect(gameObject);
	    //}
	}

