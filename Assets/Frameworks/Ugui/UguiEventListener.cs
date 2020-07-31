using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class UguiEventListener : EventTrigger {


    #region 长按
    public UIDelegate onLongPress;
   // public UIDelegate onLongPressUp;

    public  float longDelay = 1f;
    bool isDown = false;
    bool isHolding = false;
    float _lastIsDownTime;

    private void Update()
    {
        if(isDown&&!isHolding)
        {
            if(Time.time-_lastIsDownTime>longDelay)
            {
                if (onLongPress != null) onLongPress(gameObject);
                _lastIsDownTime = Time.time;
                isHolding = true;
            }
        }
    }

    #endregion



    #region 变量  
    //带参数是为了方便取得绑定了UI事件的对象  
    public delegate void UIDelegate(GameObject go);
    public delegate void UIDelegateData(GameObject go,object data);



    public event UIDelegate onPointerEnter;
    public event UIDelegate onPointerExit;
    public event UIDelegate onPointerDown;
    public event UIDelegate onPointerUp;

    public event UIDelegate onPointerClick;

    public UIDelegateData onPointerClickData;

   


    public event UIDelegate onInitializePotentialDrag;
    public event UIDelegate onBeginDrag;
    public event UIDelegate onDrag;
    public event UIDelegate onEndDrag;
    public event UIDelegate onDrop;
    public event UIDelegate onScroll;
    public event UIDelegate onUpdateSelected;
    public event UIDelegate onSelect;
    public event UIDelegate onDeselect;
    public event UIDelegate onMove;
    public event UIDelegate onSubmit;
    public event UIDelegate onCancel;
    #endregion

    private object data;
    public static UguiEventListener Get(GameObject go)
    {
        UguiEventListener listener = go.GetComponent<UguiEventListener>();
        if (listener == null) listener = go.AddComponent<UguiEventListener>();
        return listener;
    }

    public static UguiEventListener Get(GameObject go,object data)
    {
        UguiEventListener listener = go.GetComponent<UguiEventListener>();
        
        if (listener == null) listener = go.AddComponent<UguiEventListener>();
        listener.data = data;
        return listener;
    }

    #region 方法  
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (onPointerEnter != null) onPointerEnter(gameObject);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if(isDown)isDown=false;
        if (onPointerExit != null) onPointerExit(gameObject);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        #region longPress
        isDown = true;
        _lastIsDownTime = Time.time;
        #endregion
        if (onPointerDown != null) onPointerDown(gameObject);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        #region 长按
        if(isDown)
        {
           // if (onLongPressUp != null) onLongPressUp(gameObject);

            isDown = false;
            isHolding = false;
        }
        #endregion


        if (onPointerUp != null) onPointerUp(gameObject);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onPointerClick != null) onPointerClick(gameObject);

        if (onPointerClickData != null)      
            onPointerClickData(gameObject, data);
         
    }
    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        if (onInitializePotentialDrag != null) onInitializePotentialDrag(gameObject);
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (onBeginDrag != null) onBeginDrag(gameObject);
    }
    public override void OnDrag(PointerEventData eventData)
    {
        if (onDrag != null) onDrag(gameObject);
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (onEndDrag != null) onEndDrag(gameObject);
    }
    public override void OnDrop(PointerEventData eventData)
    {
        if (onDrop != null) onDrop(gameObject);
    }
    public override void OnScroll(PointerEventData eventData)
    {
        if (onScroll != null) onScroll(gameObject);
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (onUpdateSelected != null) onUpdateSelected(gameObject);
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (onSelect != null) onSelect(gameObject);
    }
    public override void OnDeselect(BaseEventData eventData)
    {
        if (onDeselect != null) onDeselect(gameObject);
    }
    public override void OnMove(AxisEventData eventData)
    {
        if (onMove != null) onMove(gameObject);
    }
    public override void OnSubmit(BaseEventData eventData)
    {
        if (onSubmit != null) onSubmit(gameObject);
    }
    public override void OnCancel(BaseEventData eventData)
    {
        if (onCancel != null) onCancel(gameObject);
    }
    #endregion
}
