using System.Collections.Generic;
using UnityEngine;
//���ߣ�Lixi  phone:15920152189
namespace LixiMgr
{
    public delegate void TimeTaskDelegate();

    /// <summary>
    /// ��ʱ���������
    /// </summary>
    public class TimeMgr : MonoBehaviour
    {
        /// <summary>
        /// ��ʱ�����б�
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
        /// ���ִֻ��һ�εĶ�ʱ����
        /// </summary>
        /// <param name="timeDelay">��ʱִ��ʱ����</param>
        /// <param name="timeTaskCallback">ִ�лص�</param>
        public void AddTaskOnce(float timeDelay, TimeTaskDelegate timeTaskCallback)
        {
            AddTask(new TimeTask(timeDelay, timeTaskCallback));
        }

        /// <summary>
        /// ����ظ���ʱ����
        /// </summary>
        /// <param name="timeDelay">��ʱִ��ʱ����</param>
        /// <param name="timeTaskCallback">ִ�лص�</param>
        /// <param name="repeatRate">�ظ����</param>
        public void AddRepeatTask(float timeDelay, TimeTaskDelegate timeTaskCallback, float repeatRate)
        {
            AddTask(new TimeTask(timeDelay, timeTaskCallback, repeatRate));
        }


        /// <summary>
        /// ��Ӷ�ʱ����
        /// </summary>
        /// <param name="timeDelay">��ʱִ��ʱ����</param>
        /// <param name="repeat">�Ƿ�����ظ�ִ��</param>
        /// <param name="timeTaskCallback">ִ�лص�</param>
        public void AddTask(float timeDelay, TimeTaskDelegate timeTaskCallback, bool repeat)
        {
            AddTask(new TimeTask(timeDelay, timeTaskCallback, repeat));

        }
        /// <summary>
        /// ��Ӷ�ʱ����
        /// </summary>
        /// <param name="timeDelay">��ʱִ��ʱ����</param>
        /// <param name="timeTaskCallback">ִ�лص�</param>
        public void AddTask(float timeDelay, TimeTaskDelegate timeTaskCallback)
        {
            AddTask(new TimeTask(timeDelay, timeTaskCallback));
        }


        /// <summary>
        /// ��Ӷ�ʱ����
        /// </summary>
        /// <param name="timeDelay">��ʱִ��ʱ����</param>
        /// <param name="timeTaskCallback">ִ�лص�</param>
        /// <param name="repeat">�Ƿ��ظ�</param>
        /// <param name="repeatRate">�ظ����</param>
        public void AddTask(float timeDelay, TimeTaskDelegate timeTaskCallback, bool repeat, float repeatRate)
        {
            AddTask(new TimeTask(timeDelay, timeTaskCallback, repeat, repeatRate));
        }
        /// <summary>
        /// ��Ӷ�ʱ����
        /// </summary>
        /// <param name="timeDelay">��ʱִ��ʱ����</param>
        /// <param name="timeTaskCallback">ִ�лص�</param>
        /// <param name="repeatRate">�ظ����</param>
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
        /// �Ƴ���ʱ����
        /// </summary>
        /// <param name="taskToRemove">�ص�����</param>
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
        /// �Ƴ����ж�ʱ����
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
        /// ִ�ж�ʱ����
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

                    //������õ��ظ�ѭ����ֵ̫С��ִ���ظ�
                    if (task.IsRepeat && task.RepeatRate < Time.deltaTime)
                    {
                        Debug.LogError("�ظ����̫С ��" + task.RepeatRate);
                        removekList.Add(task);
                    }

                }

            }
        }
    }

    /// <summary>
    /// ��ʱ�����װ��
    /// </summary>
    public class TimeTask
    {
      
        private float _timeDelay;
        private float _timeDelayRepeat;
        private bool _repeat;
        private TimeTaskDelegate _timeTaskCallBack;

        /// <summary>
        /// �ӳ�ʱ��
        /// </summary>
        public float TimeDelay { get { return _timeDelay; } set { _timeDelay = value; } }
        /// <summary>
        /// �ظ����
        /// </summary>
        public float RepeatRate { get { return _timeDelayRepeat; } }
        /// <summary>
        /// �Ƿ��ظ�
        /// </summary>
        public bool IsRepeat { get { return _repeat; } set { _repeat = value; } }
        public TimeTaskDelegate TimeTaskCallBack { get { return _timeTaskCallBack; } }

        /// <summary>
        /// ��ʱ����
        /// </summary>
        /// <param name="timeDelay">�ӳ�ʱ��</param>
        /// <param name="timeTaskCallBack">��ʱ����ص�����</param>
        /// <param name="repeat">�Ƿ��ظ�</param>
        public TimeTask(float timeDelay, TimeTaskDelegate timeTaskCallBack, bool repeat) : this(timeDelay, timeTaskCallBack, repeat, 0.02f) { }

        /// <summary>
        /// ��ʱ����
        /// </summary>
        /// <param name="timeDelay">�ӳ�ʱ��</param>
        /// <param name="timeTaskCallBack">��ʱ����ص�����</param>
        /// <param name="repeat">�Ƿ��ظ�</param>
        /// <param name="rate">�ظ����</param>
        public TimeTask(float timeDelay, TimeTaskDelegate timeTaskCallBack, bool repeat = false, float rate = 0.02f)
        {
            _timeDelay = timeDelay;
            _timeDelayRepeat = rate;
            _repeat = repeat;
            _timeTaskCallBack = timeTaskCallBack;
        }

        /// <summary>
        /// ��ʱ����
        /// </summary>
        /// <param name="timeDelay">�ӳ�ʱ��</param>
        /// <param name="timeTaskCallBack">��ʱ����ص�����</param>
        public TimeTask(float timeDelay, TimeTaskDelegate timeTaskCallBack) : this(timeDelay, timeTaskCallBack, false) { }

        /// <summary>
        /// ��ʱ����
        /// </summary>
        /// <param name="timeDelay">�ӳ�ʱ��</param>
        /// <param name="timeTaskCallBack">��ʱ����ص�����</param>
        /// <param name="repeatRate">�ظ����</param>
        public TimeTask(float timeDelay, TimeTaskDelegate timeTaskCallBack, float repeatRate) : this(timeDelay, timeTaskCallBack, true, repeatRate) { }
    }
}