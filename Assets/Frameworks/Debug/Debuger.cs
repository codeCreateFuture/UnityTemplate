using System;
using System.IO;
using UnityEngine;
using System.Reflection;
using System.Diagnostics;

namespace LixiUtility
{



    /// <summary>
    /// Unity 的 Debug 的封装类
    /// </summary>
    public class Debuger
    {
        /// <summary>
        /// 是否输出打印
        /// </summary>
        public static bool EnableLog = true;
        /// <summary>
        /// 是否显示打印时间
        /// </summary>
        public static bool EnableTime = true;
        /// <summary>
        /// 是否储存打印到文本
        /// </summary>
        public static bool EnableSave = false;
        /// <summary>
        /// 是否显示堆栈打印信息
        /// </summary>
        public static bool EnableStack = false;
        /// <summary>
        /// 打印文本保存文件夹路径
        /// </summary>
        public static string LogFileDir = "";
        /// <summary>
        /// 打印文本名称
        /// </summary>
        public static string LogFileName = "";
        /// <summary>
        /// 打印前缀
        /// </summary>
        public static string Prefix = "-> ";
        /// <summary>
        /// 打印文本流
        /// </summary>
        public static StreamWriter LogFileWriter = null;
        /// <summary>
        /// 是否使用Unity打印
        /// </summary>
        public static bool UseUnityEngine = true;

        private static void Internal_Log(string msg, object context = null)
        {
            bool useUnityEngine = Debuger.UseUnityEngine;
            if (useUnityEngine)
            {
                UnityEngine.Debug.Log(msg, (UnityEngine.Object)context);
            }
            else
            {
                Console.WriteLine(msg);
            }
        }

        private static void Internal_LogWarning(string msg, object context = null)
        {
            bool useUnityEngine = Debuger.UseUnityEngine;
            if (useUnityEngine)
            {
                UnityEngine.Debug.LogWarning(msg, (UnityEngine.Object)context);
            }
            else
            {
                Console.WriteLine(msg);
            }
        }

        private static void Internal_LogError(string msg, object context = null)
        {
            bool useUnityEngine = Debuger.UseUnityEngine;
            if (useUnityEngine)
            {
                UnityEngine.Debug.LogError(msg, (UnityEngine.Object)context);
            }
            else
            {
                Console.WriteLine(msg);
            }
        }
        [Conditional("EnableLog")]
        public static void Log(object message)
        {
            message = "<color=#00ff00>" + message + "</color>";
            bool flag = !Debuger.EnableLog;
            if (!flag)
            {
                string str = Debuger.GetLogTime() + message;
                UnityEngine.Debug.Log(Debuger.Prefix + str, null);
                Debuger.LogToFile("[I]" + str, false);
            }
        }
        [Conditional("EnableLog")]
        public static void Log(object message, object context)
        {
            message = "<color=#00ff00>" + message + "</color>";
            bool flag = !Debuger.EnableLog;
            if (!flag)
            {
                string str = Debuger.GetLogTime() + message;
                Debuger.Internal_Log(Debuger.Prefix + str, context);
                Debuger.LogToFile("[I]" + str, false);
            }
        }

        /// <summary>
        /// Debug.Log 对应封装函数
        /// </summary>
        /// <param name="tag">触发函数对应的类</param>
        /// <param name="message">打印信息</param>
        [Conditional("EnableLog")]
        public static void Log(string tag, string message)
        {
            tag = "<color=#800080ff>" + tag + "</color>";
            message = "<color=#00ff00>" + message + "</color>";
            bool flag = !Debuger.EnableLog;
            if (!flag)
            {
                message = Debuger.GetLogTime(tag, message);
                Debuger.Internal_Log(Debuger.Prefix + message, null);
                Debuger.LogToFile("[I]" + message, false);
            }
        }
        /// <summary>
        /// Debug.Log 对应封装函数
        /// </summary>
        /// <param name="tag">触发函数对应的类</param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        [Conditional("EnableLog")]
        public static void Log(string tag, string format, params object[] args)
        {
            tag = "<color=#800080ff>" + tag + "</color>";
            string message = "<color=#00ff00>" + string.Format(format, args) + "</color>";
            bool flag = !Debuger.EnableLog;
            if (!flag)
            {
                string logText = Debuger.GetLogTime(tag, message);
                Debuger.Internal_Log(Debuger.Prefix + logText, null);
                Debuger.LogToFile("[I]" + logText, false);
            }
        }
        /// <summary>
        /// Debug.LogWarning 对应封装函数
        /// </summary>
        /// <param name="message">打印信息</param>
        [Conditional("EnableLog")]
        public static void LogWarning(object message)
        {
            message = "<color=#ffff00ff>" + message + "</color>";
            string str = Debuger.GetLogTime() + message;
            Debuger.Internal_LogWarning(Debuger.Prefix + str, null);
            Debuger.LogToFile("[W]" + str, false);
        }
        /// <summary>
        /// Debug.LogWarning 对应封装函数
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        [Conditional("EnableLog")]
        public static void LogWarning(object message, object context)
        {
            message = "<color=#ffff00ff>" + message + "</color>";
            string str = Debuger.GetLogTime() + message;
            Debuger.Internal_LogWarning(Debuger.Prefix + str, context);
            Debuger.LogToFile("[W]" + str, false);
        }
        /// <summary>
        /// Debug.LogWarning 对应封装函数
        /// </summary>
        /// <param name="tag">触发函数对应的类</param>
        /// <param name="message">打印信息</param>
        [Conditional("EnableLog")]
        public static void LogWarning(string tag, string message)
        {
            tag = "<color=#800080ff>" + tag + "</color>";
            message = "<color=#ffff00ff>" + message + "</color>";
            message = Debuger.GetLogTime(tag, message);
            Debuger.Internal_LogWarning(Debuger.Prefix + message, null);
            Debuger.LogToFile("[W]" + message, false);
        }
        /// <summary>
        /// Debug.LogWarning 对应封装函数
        /// </summary>
        /// <param name="tag">触发函数对应的类</param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        [Conditional("EnableLog")]
        public static void LogWarning(string tag, string format, params object[] args)
        {
            tag += "<color=#800080ff>" + tag + "</color>";
            string message = "<color=#ffff00ff>" + string.Format(format, args) + "</color>";
            string logText = Debuger.GetLogTime(tag, string.Format(format, args));
            Debuger.Internal_LogWarning(Debuger.Prefix + logText, null);
            Debuger.LogToFile("[W]" + logText, false);
        }
        /// <summary>
        /// Debug.LogError 对应封装函数
        /// </summary>
        /// <param name="message">打印信息</param>
        [Conditional("EnableLog")]
        public static void LogError(object message)
        {
            message = "<color=#ff0000ff>" + message + "</color>";
            string str = Debuger.GetLogTime() + message;
            Debuger.Internal_LogError(Debuger.Prefix + str, null);
            Debuger.LogToFile("[E]" + str, true);
        }
        /// <summary>
        /// Debug.LogError 对应封装函数
        /// </summary>
        /// <param name="message">打印信息</param>
        /// <param name="context"></param>
        [Conditional("EnableLog")]
        public static void LogError(object message, object context)
        {
            message = "<color=#ff0000ff>" + message + "</color>";
            string str = Debuger.GetLogTime() + message;
            Debuger.Internal_LogError(Debuger.Prefix + str, context);
            Debuger.LogToFile("[E]" + str, true);
        }
        /// <summary>
        /// Debug.LogError 对应封装函数
        /// </summary>
        /// <param name="tag">触发函数对应的类</param>
        /// <param name="message">打印信息</param>
        [Conditional("EnableLog")]
        public static void LogError(string tag, string message)
        {
            tag = "<color=#800080ff>" + tag + "</color>";
            message = "<color=#ff0000ff>" + message + "</color>";
            message = Debuger.GetLogTime(tag, message);
            Debuger.Internal_LogError(Debuger.Prefix + message, null);
            Debuger.LogToFile("[E]" + message, true);
        }
        /// <summary>
        /// Debug.LogError 对应封装函数
        /// </summary>
        /// <param name="tag">触发函数对应的类</param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        [Conditional("EnableLog")]
        public static void LogError(string tag, string format, params object[] args)
        {
            tag += "<color=#800080ff>" + tag + "</color>";
            string message = "<color=#ff0000ff>" + string.Format(format, args) + "</color>";
            string logText = Debuger.GetLogTime(tag, string.Format(format, args));
            Debuger.Internal_LogError(Debuger.Prefix + logText, null);
            Debuger.LogToFile("[E]" + logText, true);
        }


        /// <summary>
        /// 获取打印时间
        /// </summary>
        /// <param name="tag">触发打印信息对应的类或者NAME字段名称</param>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string GetLogTime(string tag, string message)
        {
            string result = "";
            bool enableTime = Debuger.EnableTime;
            if (enableTime)
            {
                result = DateTime.Now.ToString("HH:mm:ss.fff") + " ";
            }
            return result + tag + "::" + message;
        }

        /// <summary>
        /// 获取打印时间
        /// </summary>
        /// <returns></returns>
        private static string GetLogTime()
        {
            string result = "";
            bool enableTime = Debuger.EnableTime;
            if (enableTime)
            {
                result = DateTime.Now.ToString("HH:mm:ss.fff") + " ";
            }
            return result;
        }
        /// <summary>
        /// 序列化打印信息
        /// </summary>
        /// <param name="message">打印信息</param>
        /// <param name="EnableStack">是否开启堆栈打印</param>
        private static void LogToFile(string message, bool EnableStack = false)
        {
            bool flag = !Debuger.EnableSave;
            if (!flag)
            {
                bool flag2 = Debuger.LogFileWriter == null;
                if (flag2)
                {
                    Debuger.LogFileName = DateTime.Now.GetDateTimeFormats('s')[0].ToString();
                    Debuger.LogFileName = Debuger.LogFileName.Replace("-", "_");
                    Debuger.LogFileName = Debuger.LogFileName.Replace(":", "_");
                    Debuger.LogFileName = Debuger.LogFileName.Replace(" ", "");
                    Debuger.LogFileName += ".log";
                    bool flag3 = string.IsNullOrEmpty(Debuger.LogFileDir);
                    if (flag3)
                    {
                        try
                        {
                            bool useUnityEngine = Debuger.UseUnityEngine;
                            if (useUnityEngine)
                            {
                                Debuger.LogFileDir = Application.persistentDataPath + "/DebugerLog/";
                            }
                            else
                            {
                                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                                Debuger.LogFileDir = baseDirectory + "/DebugerLog/";
                            }
                        }
                        catch (Exception ex)
                        {
                            Debuger.Internal_LogError(Debuger.Prefix + "获取 Application.persistentDataPath 报错！" + ex.Message, null);
                            return;
                        }
                    }
                    string path = Debuger.LogFileDir + Debuger.LogFileName;
                UnityEngine.Debug.Log(path);
                    try
                    {
                        bool flag4 = !Directory.Exists(Debuger.LogFileDir);
                        if (flag4)
                        {
                            Directory.CreateDirectory(Debuger.LogFileDir);
                        }
                        Debuger.LogFileWriter = File.AppendText(path);
                        Debuger.LogFileWriter.AutoFlush = true;
                    }
                    catch (Exception ex2)
                    {
                        Debuger.LogFileWriter = null;
                        Debuger.Internal_LogError("LogToCache() " + ex2.Message + ex2.StackTrace, null);
                        return;
                    }
                }
                bool flag5 = Debuger.LogFileWriter != null;
                if (flag5)
                {
                    try
                    {
                        Debuger.LogFileWriter.WriteLine(message);
                        bool flag6 = (EnableStack || Debuger.EnableStack) && Debuger.UseUnityEngine;
                        if (flag6)
                        {
                            Debuger.LogFileWriter.WriteLine(StackTraceUtility.ExtractStackTrace());
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }

}