using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DoubleClick : Button
{

    [Serializable]
    public class DoubleClickEvent : UnityEvent { }
    [SerializeField]
    private DoubleClickEvent _onDoubleClick = new DoubleClickEvent();

    protected override void Awake()
    {
        
    }
    public DoubleClickEvent OnDoubleClick
    {
        get
        {
            return _onDoubleClick;
        }

        set
        {
            _onDoubleClick = value;
        }
    }
    private DateTime m_firstTime;
    private DateTime m_SecondTime;
    private void ResetTime()
    {
        m_firstTime = default(DateTime);
        m_SecondTime = default(DateTime);
    }
    private void Press()
    {
        if (OnDoubleClick != null)
        {
            OnDoubleClick.Invoke();
            Debug.Log("Ë«»÷£¡");
        }
           
        else
            ResetTime();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (m_firstTime.Equals(default(DateTime)))
            m_firstTime = DateTime.Now;
        else
        {
            m_SecondTime = DateTime.Now;
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (!m_firstTime.Equals(default(DateTime)) && !m_SecondTime.Equals(default(DateTime)))
        {
            var intervalTime = m_SecondTime - m_firstTime;
            float milliTime = intervalTime.Seconds * 1000 + intervalTime.Milliseconds;
            if (milliTime < 400)
            {
                Press();
            }
            else
                ResetTime();
        }

    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        ResetTime();
    }
}
