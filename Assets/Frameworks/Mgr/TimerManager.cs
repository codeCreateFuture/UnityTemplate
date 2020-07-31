/*
 * @Summary:定时管理器（处理定时任务）
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerManager : MonoBehaviour 
{
	/// <summary>
	/// 全局实例
	/// </summary>
	private static TimerManager _Instance = null;
	
	/// <summary>
	/// 定时器字典
	/// </summary>
	private Dictionary<string, Timer> m_TimerList = new Dictionary<string, Timer>();
	
	/// <summary>
	///   增加队列
	/// </summary>
	private Dictionary<string, Timer> m_AddTimerList = new Dictionary<string, Timer>();
	
	/// <summary>
	///   销毁队列
	/// </summary>
	private List<string> m_DestroyTimerList = new List<string>();
	
	public delegate void TimerManagerHandler();
	
	public delegate void TimerManagerHandlerArgs(params object[] args);
	
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// 全局实例
	/// </summary>
	/// -----------------------------------------------------------------------------
	public static TimerManager Instance
	{
		get
		{
			if (_Instance == null)
			{
				if (_Instance == null)
				{
					//_Instance = FindObjectOfType(typeof(TimerManager)) as TimerManager;
					GameObject obj = new GameObject("TimerManager");

					//obj.hideFlags = HideFlags.HideAndDontSave;

					_Instance = (TimerManager)obj.AddComponent<TimerManager>();
				}
			}
			
			return _Instance;
		}
	}
	
	// Use this for initialization
	void Awake () 
	{
		if (TimerManager.Instance != null && TimerManager.Instance != this)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		
		_Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_DestroyTimerList.Count > 0)
		{
			///>从销毁队列中销毁指定内容
			foreach (string i in m_DestroyTimerList)
			{
				m_TimerList.Remove(i);
			}
			
			//清空
			m_DestroyTimerList.Clear();
		}
		
		if (m_AddTimerList.Count > 0)
		{
			///>从增加队列中增加定时器
			foreach (KeyValuePair<string, Timer> i in m_AddTimerList)
			{
				if (i.Value == null)
				{
					continue;
				}
				
				if (m_TimerList.ContainsKey(i.Key))
				{
					m_TimerList[i.Key] = i.Value;
				}
				else
				{
					m_TimerList.Add(i.Key, i.Value);
				}
			}
			
			//清空
			m_AddTimerList.Clear();
		}
		
		if (m_TimerList.Count > 0)
		{
			//响应定时器
			foreach (Timer timer in m_TimerList.Values)
			{
				if (timer == null)
				{
					return;
				}
				
				timer.Run();
			}
		}
	}
	
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// 增加定时器
	/// </summary>
	/// <param name=""></param>
	/// <returns></returns>
	/// -----------------------------------------------------------------------------
	public bool AddTimer(string key, float duration, TimerManagerHandler handler)
	{
		return Internal_AddTimer(key, TIMER_MODE.NORMAL, duration, handler);
	}
	
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// 增加持续定时器
	/// </summary>
	/// <param name=""></param>
	/// <returns></returns>
	/// -----------------------------------------------------------------------------
	public bool AddTimerRepeat(string key, float duration, TimerManagerHandler handler)
	{
		return Internal_AddTimer(key, TIMER_MODE.REPEAT, duration, handler);
	}
	
	public bool AddTimer(string key, float duration, TimerManagerHandlerArgs handler, params object[] args)
	{
		return Internal_AddTimer(key, TIMER_MODE.NORMAL, duration, handler, args);
	}
	
	public bool AddTimerRepeat(string key, float duration, TimerManagerHandlerArgs handler, params object[] args)
	{
		return Internal_AddTimer(key, TIMER_MODE.REPEAT, duration, handler, args);
	}

	/// -----------------------------------------------------------------------------
	/// <summary>
	/// 增加定时器
	/// </summary>
	/// <param name=""></param>
	/// <returns></returns>
	/// -----------------------------------------------------------------------------
	private bool Internal_AddTimer(string key, TIMER_MODE mode, float duration, TimerManagerHandler handler)
	{
		if (string.IsNullOrEmpty(key))
		{
			return false;
		}

		if (duration < 0.0f)
		{
			return false;
		}

		Timer timer = new Timer(key, mode, Time.time, duration, handler, this);

		if (m_AddTimerList.ContainsKey(key))
		{
			m_AddTimerList[key] = timer;
		}
		else
		{
			m_AddTimerList.Add(key, timer);
		}

		return true;
	}

	private bool Internal_AddTimer(string key, TIMER_MODE mode, float duration, TimerManagerHandlerArgs handler, params object[] args)
	{
		if (string.IsNullOrEmpty(key))
		{
			return false;
		}

		if (duration < 0.0f)
		{
			return false;
		}

		Timer timer = new Timer(key, mode, Time.time, duration, handler, this, args);

		if (m_AddTimerList.ContainsKey(key))
		{
			m_AddTimerList[key] = timer;
		}
		else
		{
			m_AddTimerList.Add(key, timer);
		}

		return true;
	}

	/// <summary>
	/// 暂停带有前缀的所有定时器
	/// </summary>
	/// <param name="prefix"></param>
	public void BreakTimerWithPrefix(string prefix)
	{
		if (m_TimerList != null && m_TimerList.Count > 0)
		{
			string[] arr = new string[m_TimerList.Count];
			m_TimerList.Keys.CopyTo(arr, 0);
			
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i].StartsWith(prefix))
				{
					BreakTimer(arr[i]);
				} 
			}
		}
	}

	/// <summary>
	/// 暂停计时器
	/// </summary>
	public void BreakTimer(string key)
	{
		if (!m_TimerList.ContainsKey(key))
		{
			return;
		}
		
		Timer timer = m_TimerList[key];
		timer.Break();
	}

	/// <summary>
	/// 重启带有前缀的所有定时器
	/// </summary>
	/// <param name="prefix"></param>
	public void ResumeTimerWithPrefix(string prefix)
	{
		if (m_TimerList != null && m_TimerList.Count > 0)
		{
			string[] arr = new string[m_TimerList.Count];
			m_TimerList.Keys.CopyTo(arr, 0);
			
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i].StartsWith(prefix))
				{
					ResumeTimer(arr[i]);
				} 
			}
		}
	}
	
	
	/// <summary>
	/// 重启计时器
	/// </summary>
	public void ResumeTimer(string key)
	{
		if (!m_TimerList.ContainsKey(key))
		{
			return;
		}
		
		Timer timer = m_TimerList[key];
		timer.Resume();
	}

	/// <summary>
	/// 销毁带有前缀的所有定时器
	/// </summary>
	/// <param name="prefix"></param>
	public void ClearTimerWithPrefix(string prefix)
	{
		if (m_TimerList != null && m_TimerList.Count > 0)
		{
			foreach (string timerKey in m_TimerList.Keys)
			{
				if (timerKey.StartsWith(prefix))
				{
					Destroy(timerKey);
				} 
			}
		}
	}
	
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// 销毁指定定时器
	/// </summary>
	/// <param name="key">标识符</param>
	/// <returns></returns>
	/// -----------------------------------------------------------------------------
	public bool Destroy(string key)
	{
		if (!m_TimerList.ContainsKey(key))
		{
			return false;
		}
		
		if (!m_DestroyTimerList.Contains(key))
		{
			m_DestroyTimerList.Add(key);
		}
		
		return true;
	}

	
	public bool IsRunning(string key)
	{
		return m_TimerList.ContainsKey(key);
	}
	
	/// -----------------------------------------------------------------------------
	/// <summary>
	///  定时器模式
	/// </summary>
	/// -----------------------------------------------------------------------------
	private enum TIMER_MODE
	{
		NORMAL,
		REPEAT,
	}

	/// -----------------------------------------------------------------------------
	/// <summary>
	/// 获取指定定时器剩余时间
	/// </summary>
	/// <param name=""></param>
	/// <returns></returns>
	/// -----------------------------------------------------------------------------
	public float GetTimerLeft(string key)
	{
		if (!m_TimerList.ContainsKey(key))
		{
			return 0.0f;
		}
		
		Timer timer = m_TimerList[key];
		return timer.TimeLeft;
	}

	/// <summary>
	/// 获取带有前缀的定时器剩余时间
	/// </summary>
	/// <param name="prefix"></param>
	public float GetTimerLeftWithPrefix(string prefix)
	{
		if (m_TimerList != null && m_TimerList.Count > 0)
		{
			string[] arr = new string[m_TimerList.Count];
			m_TimerList.Keys.CopyTo(arr, 0);
			
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i].StartsWith(prefix))
				{
					return GetTimerLeft(arr[i]);
				} 
			}
		}

		return 0.0f;
	}

	private class Timer
	{
		/// <summary>
		///   名称
		/// </summary>
		private string m_Name;
		
		/// <summary>
		///   模式
		/// </summary>
		private TIMER_MODE m_Mode;
		
		/// <summary>
		///   开始时间
		/// </summary>
		private float m_StartTime;
		
		/// <summary>
		///   时长
		/// </summary>
		private float m_duration;

		/// <summary>
		///  中断
		/// </summary>
		private bool m_Break = false;

		/// <summary>
		///  中断开始时间
		/// </summary>
		private float m_BreakStart;

		/// <summary>
		///  中断开始时间
		/// </summary>
		private float m_BreakDuration = 0;

		/// <summary>
		///   定时器委托
		/// </summary>
		private TimerManagerHandler m_TimerEvent;
		
		private TimerManagerHandlerArgs m_TimerArgsEvent;
		
		private TimerManager m_Manger;
		
		private object[] m_Args = null;
		
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// 开始时间
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		/// -----------------------------------------------------------------------------
		public float StartTime
		{
			get
			{
				return m_StartTime;
			}
			set
			{
				m_StartTime = value;
			}
		}
		
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// 剩余时间
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		/// -----------------------------------------------------------------------------
		public float TimeLeft
		{
			get
			{
				return Mathf.Max(0.0f, m_duration - (Time.time - m_StartTime) + m_BreakDuration);
			}
		}
		
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		/// -----------------------------------------------------------------------------
		public Timer(string name, TIMER_MODE mode, float startTime, float duration, TimerManagerHandler handler, TimerManager manager)
		{
			m_Name = name;
			m_Mode = mode;
			m_StartTime = startTime;
			m_duration = duration;
			m_TimerEvent = handler;
			m_Manger = manager;
		}
		
		public Timer(string name, TIMER_MODE mode, float startTime, float duration, TimerManagerHandlerArgs handler, TimerManager manager, params object[] args)
		{
			m_Name = name;
			m_Mode = mode;
			m_StartTime = startTime;
			m_duration = duration;
			m_TimerArgsEvent = handler;
			m_Manger = manager;
			m_Args = args;
		}
		
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// 运行事件
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		/// -----------------------------------------------------------------------------
		public void Run()
		{
			if (m_Break)
			{
				return;
			}

			if (this.TimeLeft > 0.0f)
			{
				return;
			}
			
			if (this.m_TimerEvent != null)
			{
				this.m_TimerEvent();
			}
			
			if (this.m_TimerArgsEvent != null)
			{
				this.m_TimerArgsEvent(m_Args);
			}
			
			if (m_Mode == TIMER_MODE.NORMAL)
			{
				m_Manger.Destroy(this.m_Name);
			}
			else
			{
				m_StartTime = Time.time;
				m_BreakDuration = 0;
			}
			return;
		}
		
		public void Break()
		{
			if (m_Break)
			{
				return;
			}

			m_Break = true;
			m_BreakStart = Time.time;
		}

		public void Resume()
		{
			if (!m_Break)
			{
				return;
			}

			m_BreakDuration += (Time.time - m_BreakStart);
			m_Break = false;
		}
	}
}
