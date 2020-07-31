using UnityEngine;
using System.Collections;
using System;

public class TimeManager
{
    private int _systemTimeAtStartup = 0;        //游戏开始时的服务器的时间
    private int _curTimeZone = 0;                //当前时区
    private TimeSpan _timeZoneDelatime = new TimeSpan(0, 0, 0);
    public int systemTime { get { return _systemTimeAtStartup + (int)Time.realtimeSinceStartup; } }  //当前服务器时间
    public int CurTimeZone { set { _curTimeZone = value; _timeZoneDelatime = new TimeSpan(_curTimeZone, 0, 0); } }
    public static TimeManager instance = new TimeManager();

    public TimeManager()
    {
        if (instance != null)
        {
            throw new UnityException("Error: Please use instance to get TimeManager.");
        }
    }

    public void SetSystemTime(int serverSystemTime)
    {
        _systemTimeAtStartup = serverSystemTime - (int)Time.realtimeSinceStartup;
    }

    public DateTime GetNowTime()
    {
        return GetTime(systemTime);
    }

    public DateTime GetTime(int seconds)
    {
        DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0);
        startTime += _timeZoneDelatime;
        DateTime curTime = startTime.AddSeconds(seconds);
        return curTime;
    }

    public int[] CalculateCountDown(int seconds)
    {
        int days = seconds / 86400;
        int hours = (seconds - days * 86400) / 3600;
        int mins = seconds / 60 % 60;
        int sec = seconds % 60;

        return new int[] { days, hours, mins, sec };
    }

    public string ChangeTimeToString(int seconds)
    {
        int h = seconds / 3600;
        int m = (seconds % 3600) / 60;
        int s = seconds % 60;
        return ChangeTimeToString(h, m, s);
    }

    public string ChangeTimeToString(int h, int m, int s)
    {
        string timeStr = "";
        timeStr = string.Format("{0}:{1}:{2}",
           h.ToString().PadLeft(2, '0'),
           m.ToString().PadLeft(2, '0'),
           s.ToString().PadLeft(2, '0'));
        return timeStr;
    }
}
