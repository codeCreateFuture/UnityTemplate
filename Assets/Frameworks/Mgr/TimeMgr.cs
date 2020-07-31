using System.Collections.Generic;
using UnityEngine;
//作者：Lixi  phone:15920152189
namespace LixiMgr
{
    public delegate void TimeTaskDelegate();

    /// <summary>
    /// 定时任务管理器
    /// </summary>
    public class TimeMgr : MonoBehaviour
    {
        /// <summary>
        /// 定时任务列表
        /// </summary>
        private List<TimeTask> taskList = new List<TimeTask>();

        private static TimeMgr _timeInstance;
        public static TimeMgr Instance
        {
            get
            {
                if (_timeInstance == null)
                {
                    _timeInstance = FindObjectOfType(typeof(TimeMgr)) as TimeMgr;
                    if (_timeInstance == null)
                    {
                        GameObject obj = new GameObject("TimeMgr");

                        //obj.hideFlags = HideFlags.HideAndDontSave;

                        _timeInstance = (TimeMgr)obj.AddComponent<TimeMgr>();
                    }
                    return _timeInstance;
                }
                return _timeInstance;
            }
        }

        void Awake()
        {
            // DontDestroyOnLoad(this.gameObject);
            if (_timeInstance == null)
                _timeInstance = this as TimeMgr;
        }


        /// <summary>
        /// 添加只执行一次的定时任务
        /// </summary>
        /// <param name="timeDelay">延时执行时间间隔</param>
        /// <param name="timeTaskCallback">执行回调</param>
        public void AddTaskOnce(float timeDelay, TimeTaskDelegate timeTaskCallback)
        {
            AddTask(new TimeTask(timeDelay, timeTaskCallback));
        }

        /// <summary>
        /// 添加重复定时任务
        /// </summary>
        /// <param name="timeDelay">延时执行时间间隔</param>
        /// <param name="timeTaskCallback">执行回调</param>
        /// <param name="repeatRate">重复间隔</param>
        public void AddRepeatTask(float timeDelay, TimeTaskDelegate timeTaskCallback, float repeatRate)
        {
            AddTask(new TimeTask(timeDelay, timeTaskCallback, repeatRate));
        }


        /// <summary>
        /// 添加定时任务
        /// </summary>
        /// <param name="timeDelay">延时执行时间间隔</param>
        /// <param name="repeat">是否可以重复执行</param>
        /// <param name="timeTaskCallback">执行回调</param>
        public void AddTask(float timeDelay, TimeTaskDelegate timeTaskCallback, bool repeat)
        {
            AddTask(new TimeTask(timeDelay, timeTaskCallback, repeat));

        }
        /// <summary>
        /// 添加定时任务
        /// </summary>
        /// <param name="timeDelay">延时执行时间间隔</param>
        /// <param name="timeTaskCallback">执行回调</param>
        public void AddTask(float timeDelay, TimeTaskDelegate timeTaskCallback)
        {
            AddTask(new TimeTask(timeDelay, timeTaskCallback));
        }


        /// <summary>
        /// 添加定时任务
        /// </summary>
        /// <param name="timeDelay">延时执行时间间隔</param>
        /// <param name="timeTaskCallback">执行回调</param>
        /// <param name="repeat">是否重复</param>
        /// <param name="repeatRate">重复间隔</param>
        public void AddTask(float timeDelay, TimeTaskDelegate timeTaskCallback, bool repeat, float repeatRate)
        {
            AddTask(new TimeTask(timeDelay, timeTaskCallback, repeat, repeatRate));
        }
        /// <summary>
        /// 添加定时任务
        /// </summary>
        /// <param name="timeDelay">延时执行时间间隔</param>
        /// <param name="timeTaskCallback">执行回调</param>
        /// <param name="repeatRate">重复间隔</param>
        public void AddTask(float timeDelay, TimeTaskDelegate timeTaskCallback, float repeatRate)
        {
            AddTask(new TimeTask(timeDelay, timeTaskCallback, repeatRate));
        }
       


        public void AddTask(TimeTask taskToAdd)
        {
            if (taskList.Contains(taskToAdd) || taskToAdd == null) return;
            taskList.Add(taskToAdd);
        }

        /// <summary>
        /// 移除定时任务
        /// </summary>
        /// <param name="taskToRemove">回调函数</param>
        /// <returns></returns>
        public void RemoveTask(TimeTaskDelegate taskToRemove)
        {
            if (taskList.Count == 0 || taskToRemove == null) return;
            List<TimeTask> tempRemove = new List<TimeTask>();
            for (int i = 0; i < taskList.Count; i++)
            {
                TimeTask item = taskList[i];
                if (item.TimeTaskCallBack == taskToRemove)
                    tempRemove.Add(item);
            }

            if (tempRemove.Count == 0 || tempRemove == null) return;
            for (int i = 0; i < tempRemove.Count; i++)
            {
                taskList.Remove(tempRemove[i]);
            }
            tempRemove.Clear();

        }

        /// <summary>
        /// 移除所有定时任务
        /// </summary>
        public void RemoveAllTask()
        {
            taskList.Clear();
        }

        void FixedUpdate()
        {
            Tick();

        }
        private List<TimeTask> removekList = new List<TimeTask>();
        /// <summary>
        /// 执行定时任务
        /// </summary>
        private void Tick()
        {


            if (taskList == null) return;
            for (int i = 0; i < removekList.Count; i++)
            {
                taskList.Remove(removekList[i]);
            }
            removekList.Clear();

            foreach (TimeTask task in taskList)
            {
                task.TimeDelay -= Time.deltaTime;
                if (task.TimeDelay <= 0)
                {
                    task.TimeTaskCallBack();
                    task.TimeDelay = task.RepeatRate;
                    if (!task.IsRepeat)
                    {
                        removekList.Add(task);
                        return;
                    }

                    //如果设置的重复循环的值太小则不执行重复
                    if (task.IsRepeat && task.RepeatRate < Time.deltaTime)
                    {
                        Debug.LogError("重复间隔太小 ：" + task.RepeatRate);
                        removekList.Add(task);
                    }

                }

            }
        }
    }

    /// <summary>
    /// 定时任务封装类
    /// </summary>
    public class TimeTask
    {
      
        private float _timeDelay;
        private float _timeDelayRepeat;
        private bool _repeat;
        private TimeTaskDelegate _timeTaskCallBack;

        /// <summary>
        /// 延迟时间
        /// </summary>
        public float TimeDelay { get { return _timeDelay; } set { _timeDelay = value; } }
        /// <summary>
        /// 重复间隔
        /// </summary>
        public float RepeatRate { get { return _timeDelayRepeat; } }
        /// <summary>
        /// 是否重复
        /// </summary>
        public bool IsRepeat { get { return _repeat; } set { _repeat = value; } }
        public TimeTaskDelegate TimeTaskCallBack { get { return _timeTaskCallBack; } }

        /// <summary>
        /// 定时任务
        /// </summary>
        /// <param name="timeDelay">延迟时间</param>
        /// <param name="timeTaskCallBack">定时任务回调函数</param>
        /// <param name="repeat">是否重复</param>
        public TimeTask(float timeDelay, TimeTaskDelegate timeTaskCallBack, bool repeat) : this(timeDelay, timeTaskCallBack, repeat, 0.02f) { }

        /// <summary>
        /// 定时任务
        /// </summary>
        /// <param name="timeDelay">延迟时间</param>
        /// <param name="timeTaskCallBack">定时任务回调函数</param>
        /// <param name="repeat">是否重复</param>
        /// <param name="rate">重复间隔</param>
        public TimeTask(float timeDelay, TimeTaskDelegate timeTaskCallBack, bool repeat = false, float rate = 0.02f)
        {
            _timeDelay = timeDelay;
            _timeDelayRepeat = rate;
            _repeat = repeat;
            _timeTaskCallBack = timeTaskCallBack;
        }

        /// <summary>
        /// 定时任务
        /// </summary>
        /// <param name="timeDelay">延迟时间</param>
        /// <param name="timeTaskCallBack">定时任务回调函数</param>
        public TimeTask(float timeDelay, TimeTaskDelegate timeTaskCallBack) : this(timeDelay, timeTaskCallBack, false) { }

        /// <summary>
        /// 定时任务
        /// </summary>
        /// <param name="timeDelay">延迟时间</param>
        /// <param name="timeTaskCallBack">定时任务回调函数</param>
        /// <param name="repeatRate">重复间隔</param>
        public TimeTask(float timeDelay, TimeTaskDelegate timeTaskCallBack, float repeatRate) : this(timeDelay, timeTaskCallBack, true, repeatRate) { }
    }
}