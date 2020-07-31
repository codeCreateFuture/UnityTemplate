using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*  用例一
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TimeTrigger;

public class BillBoard : MonoBehaviour {
    public Text parm;
    public Text log;
    public int setTime = 3;
    public bool loop = true;
    public bool ignore = true;


    //计数锁
    int lockNum = int.MaxValue;

    void Start () {
        parm.text = string.Format("定时【{0}】秒，循环【{1}】，忽略scale【{2}】",setTime,loop.ToString(),ignore.ToString());
        
        Time.timeScale = 0.5f; //设置了timescale

        Timer.AddTimer(setTime, "testignore",loop,ignore).OnUpdated((v)=> 
        {
            int time = Mathf.FloorToInt(v * setTime);
            if (time != lockNum)
            {
                lockNum = time;
                if (time!=0)
                {
                    log.text = time.ToString(); ;
                }
            }
        }).OnCompleted(()=> 
        {
           log.text =  string.Format( "{0}秒定时完成!", setTime);

            TestFunc("dadfaf",9897);
        });
	}

    private void TestFunc(string a,int b)
    {
        Debug.Log(a+":"+b.ToString());
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Timer.PauseTimer("testignore");
        }
        if (Input.GetMouseButtonUp(1))
        {
            Timer.ResumTimer("testignore");
        }
    }
}

 */


/* 用例二
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeTrigger;
/// <summary>
/// 在使用此定时器时，如果回调参数中包含场景游戏对象，且游戏对象总是频繁显示隐藏的，建议同步暂停和恢复运行中的计时器
/// 本例，在游戏对象隐藏时计数暂停，显示则计数恢复 (运行后，自己尝试显示隐藏这个脚本所在的游戏对象并观察输出)
/// </summary>
public class TestPauseAndResum : MonoBehaviour {
    private int lockNum = int.MaxValue;
    private Timer t;
    void Start () {
      t=  Timer.AddTimer(5, "TestForPauseAndResum",true).OnUpdated((v)=> 
        {
            int time = Mathf.FloorToInt(v * 5);
            if (time != lockNum)
            {
                lockNum = time;
                Debug.Log("时间是：" + time);
            }

        }).OnCompleted(()=> 
        {
            Debug.Log("TestForPause_5秒_计时完成！");
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnEnable()
    {
        //if (null!=t)t.IsPause = false; 
        //或者使用这句：
        Timer.ResumTimer("TestForPauseAndResum");

    }
    private void OnDisable()
    {
        //if (null!=t)t.IsPause = true; 
        //或者使用这句：
        Timer.PauseTimer("TestForPauseAndResum");
    }
}

*/


namespace TimeTrigger
{
    public class Timer
    {
        static List<Timer> listTimes = new List<Timer>();
        Action<float> _updateEvent;
        Action _finishEvent;
        /// <summary>
        /// 用户设定的定时时长
        /// </summary>
        private float _time = -1;
        /// <summary>
        /// 是否循环执行
        /// </summary>
        private bool _isLoop;
        /// <summary>
        /// 是否忽略Timescale
        /// </summary>
        private bool _isIgnorTimescale;
        /// <summary>
        /// 用户指定的定时器标志，便于手动清除、暂停、恢复
        /// </summary>
        private string _id;

        private static TimerDriver driver = null;//拿驱动器的引用只是为了初始化驱动器
        /// <summary>
        /// 获得当前时间
        /// </summary>
        private float CurrentTime { get { return _isIgnorTimescale ? Time.realtimeSinceStartup : Time.time; } }

        private float _cachedTime;//缓存时间
        float PassedTime;        //已经过去的时间

        private bool _isFinish = false; //计时器是否结束
        private bool _isPause = false; //计时器是否暂停

        private static bool showLog = true;
        public static bool ShowLog { set { showLog = value; } }//确认是否输出Debug信息
        /// <summary>
        /// 暂停计时器
        /// </summary>
        public bool IsPause
        {
            get { return _isPause; }
            set
            {
                if (value)
                {
                    Pause();
                }
                else
                {
                    Restart();
                }
            }

        }
        /// <summary>
        /// 构造定时器
        /// </summary>
        /// <param name="time">定时时长</param>
        /// <param name="id">定时器标识符</param>
        /// <param name="loop">是否循环</param>
        /// <param name="ignorTimescale">是否忽略TimeScale</param>
        private Timer(float time, string id, bool loop = false, bool ignorTimescale = true)
        {
            if (null == driver) driver = TimerDriver.Get; //初始化Time驱动
            _time = time;
            _isLoop = loop;
            _isIgnorTimescale = ignorTimescale;
            _cachedTime = CurrentTime;
            if (listTimes.Exists((v) => { return v._id == id; }))
            {
                if (showLog) Debug.LogWarningFormat("【TimerTrigger（容错）】:存在相同的标识符【{0}】！", id);
            }
            _id = string.IsNullOrEmpty(id) ? GetHashCode().ToString() : id;//设置辨识标志符

        }

        /// <summary>  
        /// 暂停计时  
        /// </summary>  
        private void Pause()
        {
            if (_isFinish)
            {
                if (showLog) Debug.LogWarning("【TimerTrigger（容错）】:计时已经结束！");
            }
            else
            {
                _isPause = true;
            }
        }
        /// <summary>  
        /// 继续计时  
        /// </summary>  
        private void Restart()
        {
            if (_isFinish)
            {
                if (showLog) Debug.LogWarning("【TimerTrigger（容错）】:计时已经结束！");
            }
            else
            {
                if (_isPause)
                {
                    _cachedTime = CurrentTime-PassedTime; 
                    _isPause = false;
                }
                else
                {
                    if (showLog) Debug.LogWarning("【TimerTrigger（容错）】:计时并未处于暂停状态！");
                }
            }
        }
        /// <summary>
        /// 刷新定时器
        /// </summary>
        private void Update()
        {
            if (!_isFinish && !_isPause) //运行中
            {
                PassedTime = CurrentTime - _cachedTime;
                // if (null != UpdateEvent) UpdateEvent(Mathf.Clamp01(timePassed / _time));
                 if (null != _updateEvent) _updateEvent(PassedTime);
                if (PassedTime >= _time)
                {
                    if (null != _finishEvent) _finishEvent();
                    if (_isLoop)
                    {
                        _cachedTime = CurrentTime;
                    }
                    else
                    {
                        Stop();
                    }
                }
            }
        }

        /// <summary>
        /// 回收定时器
        /// </summary>
        private void Stop()
        {
            if (listTimes.Contains(this))
            {
                listTimes.Remove(this);
            }
            _time = -1;
            _isFinish = true;
            _isPause = false;
            _updateEvent = null;
            _finishEvent = null;
        }



        #region--------------------------Static Function Extend-------------------------------------
        #region-------------AddEntity---------------
        /// <summary>
        /// 添加定时触发器
        /// </summary>
        /// <param name="time">定时时长</param>
        /// <param name="id">定时器标识符</param>
        /// <param name="loop">是否循环</param>
        /// <param name="ignorTimescale">是否忽略TimeScale</param>
        /// <returns></returns>
        public static Timer AddTimer(float time, string id = "", bool loop = false, bool ignorTimescale = true)
        {
            Timer timer = new Timer(time, id, loop, ignorTimescale);
            listTimes.Add(timer);
            return timer;
        }


        public static Timer AddTime(float time,Action finishEvent,Action<float>updateEvent=null,string id="",bool isLoop=false,bool isIgnorTimeScale=true)
        {
            Timer timer = new Timer(time, id, isLoop, isIgnorTimeScale);
            timer._finishEvent = finishEvent;
            timer._updateEvent = updateEvent;

            listTimes.Add(timer);
            return timer;
        }
        #endregion

        #region-------------UpdateAllTimer---------------
        public static void UpdateAllTimer()
        {
            for (int i = 0; i < listTimes.Count; i++)
            {
                if (null != listTimes[i])
                {
                    
                    listTimes[i].Update();
                }
            }
        }
        #endregion

        #region-------------Pause AND Resum Timer---------------
        /// <summary>
        /// 暂停用户指定的计时触发器
        /// </summary>
        /// <param name="id">指定的标识符</param>
        public static void Pause(string id)
        {
            Timer timer = listTimes.Find((v) => { return v._id == id; });
            if (null != timer)
            {
                timer.Pause();
            }
            else
            {
                if (showLog) Debug.Log("【TimerTrigger（容错）】:定时器已完成触发或无此定时器！---Flag【" + id + "】。");
            }
        }
        /// <summary>
        /// 恢复用户指定的计时触发器
        /// </summary>
        /// <param name="id">指定的标识符</param>
        public static void Resume(string id)
        {
            Timer timer = listTimes.Find((v) => { return v._id == id; });
            if (null != timer)
            {
                timer.Restart();
            }
            else
            {
                if (showLog) Debug.Log("【TimerTrigger（容错）】:定时器已完成触发或无此定时器！---Flag【" + id + "】。");
            }
        }

        /// <summary>
        /// 暂停所有的及时任务
        /// </summary>
        public static void PauseAll()
        {
            for (int i = 0; i < listTimes.Count; i++)
            {
                if (listTimes[i] != null)
                {
                    listTimes[i].Pause();
                }
            }
        }

        public static void ResumeAll()
        {
            for (int i = 0; i < listTimes.Count; i++)
            {
                if (listTimes[i] != null)
                {
                    listTimes[i].Restart();
                }
            }
        }

        #endregion
        #region-------------DelEntity---------------
        /// <summary>
        /// 删除用户指定的计时触发器
        /// </summary>
        /// <param name="id">指定的标识符</param>
        public static void Stop(string id)
        {
            Timer timer = listTimes.Find((v) => { return v._id == id; });
            if (null != timer)
            {
                timer.Stop();
            }
            else
            {
                if (showLog) Debug.Log("【TimerTrigger（容错）】:定时器已完成触发或无此定时器！---Flag【" + id + "】。");
            }
        }
        /// <summary>
        /// 删除用户指定的计时触发器
        /// </summary>
        /// <param name="flag">指定的定时器</param>
        public static void Stop(Timer timer)
        {
            if (listTimes.Contains(timer))
            {
                timer.Stop();
            }
            else
            {
                if (showLog) Debug.Log("【TimerTrigger（容错）】:此定时器已完成触发或无此定时器！");
            }
        }

      

        /// <summary>
        /// 删除用户指定的计时触发器
        /// </summary>
        /// <param name="finishEvent">指定的完成事件(直接赋值匿名函数无效)</param>
        public static void Stop(Action finishEvent)
        {
            Timer timer = listTimes.Find((v) => { return v._finishEvent == finishEvent; });
            if (null != timer)
            {
                timer.Stop();
            }
            else
            {
                if (showLog) Debug.Log("【TimerTrigger（容错）】:定时器已完成触发或无此定时器！---方法名：【" + finishEvent.Method.Name + "】。");
            }
        }
        /// <summary>
        /// 删除用户指定的计时触发器
        /// </summary>
        /// <param name="updateEvent">指定的Update事件(直接赋值匿名函数无效)</param>
        public static void Stop(Action<float> updateEvent)
        {
            Timer timer = listTimes.Find((v) => { return v._updateEvent == updateEvent; });
            if (null != timer)
            {
                timer.Stop();
            }
            else
            {
                if (showLog) Debug.Log("【TimerTrigger（容错）】:定时器已完成触发或无此定时器！---方法名：【" + updateEvent.Method.Name + "】。");
            }
        }

        /// <summary>
        /// 停止或者删除所有的计时任务
        /// </summary>
        public static void StopAll()
        {
            for (int i = 0; i < listTimes.Count; i++)
            {
                if (listTimes[i] != null)
                {
                    listTimes[i].Stop();
                }
            }
        }
        #endregion
        #endregion

        #region-------------AddEvent-------------------
        public Timer Onfinish(Action finishEvent)
        {
            if (null == _finishEvent)
            {
                _finishEvent = finishEvent;
            }
            else
            {
                if (showLog) Debug.Log("【TimerTrigger（容错）】:定时器已注册了_finishEvent事件,请整合！");
            }
            return this;
        }
        public Timer OnUpdate(Action<float> updateEvent)
        {
            if (null == _updateEvent)
            {
                _updateEvent = updateEvent;
            }
            else
            {
                if (showLog) Debug.Log("【TimerTrigger（容错）】:定时器已注册了Update事件，请整合！");
            }
            return this;
        }

        #endregion

        #region ---------------运行中的定时器参数修改-----------
        /// <summary>
        /// 设置运行中的定时器的loop状态
        /// </summary>
        /// <param name="loop"></param>
        public Timer Setloop(bool loop)
        {
            if (!_isFinish)
            {
                _isLoop = loop;
            }
            else
            {
                if (showLog) Debug.Log("【TimerTrigger（容错）】:定时器已失效,设置Loop Fail！");
            }
            return this;
        }

        /// <summary>
        /// 设置运行中的定时器的ignoreTimescale状态
        /// </summary>
        /// <param name="loop"></param>
        public Timer SetIgnoreTimeScale(bool ignoreTimescale)
        {
            if (!_isFinish)
            {
                _isIgnorTimescale = ignoreTimescale;
            }
            else
            {
                if (showLog) Debug.Log("【TimerTrigger（容错）】:定时器已失效，设置IgnoreTimescale Fail！");
            }
            return this;
        }

        #endregion

    }

    public class TimerDriver : MonoBehaviour
    {
        #region 单例
        private static TimerDriver _instance;
        public static TimerDriver Get
        {
            get
            {
                if (null == _instance)
                {
                    _instance = FindObjectOfType<TimerDriver>() ?? new GameObject(typeof(TimerDriver).Name).AddComponent<TimerDriver>();
                }
                return _instance;
            }
            private set { _instance = value; }
        }
        private void Awake()
        {
            _instance = this;
        }
        #endregion
        private void Update()
        {
            Timer.UpdateAllTimer();
        }
    }

}
