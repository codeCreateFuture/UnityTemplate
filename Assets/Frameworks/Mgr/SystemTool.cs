using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 平台
/// </summary>
public enum PlatFormEnum
{
	WINDOWS=0,
	ANDROID,
	IOS
}
/// <summary>
/// 网络状态
/// </summary>
public enum NetWorkEnum
{
	NotNetWork=0,  //没有网络
	WiFi,          //wifi
	Carrier    //移动网络

}
public static class SystemTool {

  static  PlatFormEnum platform = PlatFormEnum.WINDOWS;
	public static PlatFormEnum GetPlatform()
	{
		


#if UNITY_EDITOR
		platform = PlatFormEnum.WINDOWS;
#elif UNITY_IPHONE
	   platform=PlatFormEnum.IOS;
#elif UNITY_ANDROID
	   platform=PlatFormEnum.ANDROID;  
#elif UNITY_STANDALONE_WIN
	   platform=PlatFormEnum.WINDOWS;  
#endif


		return platform;
	}

	/// <summary>
	/// 当前设备的分辨率
	/// </summary>
	/// <returns></returns>
	public static Resolution DeviceResolution()
	{
		return Screen.currentResolution;
	}
	/// <summary>
	/// 窗口的宽
	/// </summary>
	/// <returns></returns>
	public static int ScreenWidth()
	{
		return Screen.width;
	}
	/// <summary>
	/// 窗口高
	/// </summary>
	/// <returns></returns>
	public static int ScreenHeight()
	{
		return Screen.height;
	}

	/// <summary>  
	/// 网络可用  
	/// </summary>  
	public static bool NetAvailable
	{
		get
		{
			return Application.internetReachability != NetworkReachability.NotReachable;
		}
	}

	/// <summary>  
	/// 是否是无线  
	/// </summary>  
	public static bool IsWifi
	{
		get
		{
			return Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
		}
	}

	public static NetWorkEnum GetNetWoker()
	{
		//网络不可用状态
		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			return NetWorkEnum.NotNetWork;    //"网络不可用状态";
		}
		//当用户使用WiFi时    
		else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
		{
			return NetWorkEnum.WiFi; //"当用户使用WiFi或网线时";
		}
		//当用户使用移动网络时    
		else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
		{
			return NetWorkEnum.Carrier;// "当用户使用移动网络时";
		}

		return NetWorkEnum.NotNetWork;
	}


	/// <summary>
	/// 系统时间
	/// </summary>
	/// <returns></returns>
	public static DateTime SystemTime()
	{
		DateTime now = DateTime.Now;
		return now;
		
	}
	/// <summary>
	/// 获取时间
	/// </summary>
	/// <returns></returns>
	public static string SystemTimeToString()
	{
		DateTime now = DateTime.Now;
		return string.Format("{0}:{1}:{2}", now.Hour, now.Minute,now.Second);
		 
	}
	//System.DateTime.Now.ToString("yyyyMdHms")
	public static string SystemTimeFormat(string format= "yyyy-MM-dd HH:mm:ss")
	{
		string formatTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		return formatTime;
	}
	/// <summary>
	/// 获取当前小时
	/// </summary>
	/// <returns></returns>
	public static string SystemHour()
	{
		DateTime now = DateTime.Now;
		return now.Hour.ToString();
	}
   
	public static string SystemMinute()
	{
		DateTime now = DateTime.Now;
		return now.Minute.ToString();
	}

	public static string SystemSecond()
	{
		DateTime now = DateTime.Now;
		return now.Second.ToString();
	}

	public static string SystemYear()
	{
		DateTime now = DateTime.Now;
		return now.Year.ToString();
	}

	public static string SystemMouth()
	{
		DateTime now = DateTime.Now;
		return now.Month.ToString();
	}

	public static string SystemDay()
	{
		DateTime now = DateTime.Now;
		return now.Day.ToString();
	}

	public static string SystemDate()
	{
		DateTime now = DateTime.Now;
		return now.Date.ToString();
	}

	/// <summary>
	/// 当前星期
	/// </summary>
	/// <returns></returns>
	public static string SystemDayOfWeek()
	{
		DateTime now = DateTime.Now;
		return now.DayOfWeek.ToString();
	}
	/// <summary>
	/// 是否是ipad
	/// </summary>
	/// <returns></returns>
	public static bool IsIpad()
	{
		string a = SystemInfo.deviceModel.ToLower().Trim();
	  
		if (a.StartsWith("ipad"))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

    public static string LocalDownloadUrl(string url)
    {
        if(Application.platform==RuntimePlatform.WindowsEditor||
            Application.platform==RuntimePlatform.WindowsPlayer)
        {
            url = "file:///" + url;
        }else if(Application.platform==RuntimePlatform.Android)
        {
            url = "jar:file://" + url;
        }else
        {
            url = "file://" + url;
        }
        return url;
    }

	public static string Info()
	{
		return String.Format("网络状态 :{0} ; 运行平台 :{1} ;\n" +
			"系统时间 :{2} ;星期 ：{3} ;\n" +
			"运行设备分辨率width :{4}- height :{5} ;\n" +
			"运行窗口width :{6}- height :{7}",
			GetNetWoker().ToString(), 
			GetPlatform().ToString(),
			SystemTime(),SystemDayOfWeek(),
			DeviceResolution().width,
			DeviceResolution().height,
			ScreenWidth(),ScreenHeight());
	}

}
