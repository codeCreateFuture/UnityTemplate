using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
/// <summary>
///  描述：处理计时功能，包括计时开始，暂停计时
/// </summary>
public class CalculatorTime : MonoBehaviour {

    public float time_All = 300;//计时的总时间（单位秒）  
    public float time_Left;//剩余时间  
    public bool isPauseTime = false;
    public Text time;

    //计时结束的回调
    Action _timeUp = null;
    bool _isStop = false;
    public static CalculatorTime Instance;
    // Use this for initialization  
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
        time_Left = time_All;
        gameObject.SetActive(false);
    }

    // Update is called once per frame  
    void Update()
    {
        if (!isPauseTime&&!_isStop)
        {
            if (time_Left > 0)
                StartTimer();
            else
            {
                _isStop = true;
                if (_timeUp != null)
                    _timeUp();
            }
        }

    }

    /// <summary>
    /// 显示倒计时
    /// </summary>
    /// <param name="showTime">倒计时的时间</param>
    /// <param name="timeUp">倒计时结束后的回调</param>
    public void Show(float showTime,Action timeUp=null)
    {
        if (showTime <= 0) return;
        gameObject.SetActive(true);
        _isStop = false;
        time_Left = showTime+1;
        if(timeUp!=null)
        {
            _timeUp = timeUp;
        }


    }
    /// <summary>  
        /// 开始计时   
        /// </summary>  
    void StartTimer()
    {
        time_Left -= Time.deltaTime;
        time.text = GetTime(time_Left);

    }
    /// <summary>  
        ///继续游戏，这个暂时加在这里，后期代码重构时加在UIControl中   
        /// </summary>  
    public void ContinueGame()
    {

        isPauseTime = false;
        //Time.timeScale = 1;
    }

    /// <summary>  
        /// 暂停计时  
        /// </summary>  
    public void PauseTimer()
    {
        isPauseTime = true;
        //Time.timeScale = 0;
    }
    /// <summary>  
        /// 获取总的时间字符串  
        /// </summary>  
    string GetTime(float time)
    {
        return GetHour(time)+ GetMinute(time) + GetSecond(time);

    }

    /// <summary>  
        /// 获取小时  
        /// </summary>  
    string GetHour(float time)
    {
        int timer = (int)(time / 3600);
        string timerStr;
        if (timer < 10)
            timerStr = "0" + timer.ToString() + ":";
        else
            timerStr = timer.ToString() + ":";
        return timerStr;
    }
    /// <summary>  
        ///获取分钟   
        /// </summary>  
    string GetMinute(float time)
    {
        int timer = (int)((time % 3600) / 60);
        string timerStr;
        if (timer < 10)
            timerStr = "0" + timer.ToString() + ":";
        else
            timerStr = timer.ToString() + ":";
        return timerStr;
    }
    /// <summary>  
        /// 获取秒  
        /// </summary>  
    string GetSecond(float time)
    {
        int timer = (int)((time % 3600) % 60);
        string timerStr;
        if (timer < 10)
            timerStr = "0" + timer.ToString();
        else
            timerStr = timer.ToString();

        return timerStr;
    } 

}
