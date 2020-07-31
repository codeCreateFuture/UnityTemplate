﻿using System;
using System.Diagnostics;
using System.Reflection;
namespace LixiUtility
{


 /// <summary>
    /// 自定义Debuger类的扩展类
    /// </summary>
    public static class DebugerExtension
    {
        /// <summary>
        /// Debug.Log扩展，用法与Debug.Log相符
        /// </summary>
        /// <param name="obj">触发函数对应的类</param>
        /// <param name="message">打印信息</param>
        [Conditional("EnableLog")]
        public static void Log(this object obj, string message)
        {
            bool flag = !Debuger.EnableLog;
            if (!flag)
            {
                Debuger.Log(DebugerExtension.GetLogTag(obj), message);
            }
        }
        /// <summary>
        /// Debug.Log扩展，用法与Debug.Log相符
        /// </summary>
        /// <param name="obj">触发函数对应的类</param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        [Conditional("EnableLog")]
        public static void Log(this object obj, string format, params object[] args)
        {
            bool flag = !Debuger.EnableLog;
            if (!flag)
            {
                string message = string.Format(format, args);
                Debuger.Log(DebugerExtension.GetLogTag(obj), message);
            }
        }
        /// <summary>
        /// Debug.LogWarning扩展，用法与Debug.LogWarning相符
        /// </summary>
        /// <param name="obj">触发函数对应的类</param>
        /// <param name="message">打印信息</param>
        [Conditional("EnableLog")]
        public static void LogWarning(this object obj, string message)
        {
            Debuger.LogWarning(DebugerExtension.GetLogTag(obj), message);
        }
        /// <summary>
        /// Debug.LogWarning扩展，用法与Debug.LogWarning相符
        /// </summary>
        /// <param name="obj">触发函数对应的类</param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        [Conditional("EnableLog")]
        public static void LogWarning(this object obj, string format, params object[] args)
        {
            string message = string.Format(format, args);
            Debuger.LogWarning(DebugerExtension.GetLogTag(obj), message);
        }
        /// <summary>
        /// Debug.LogError扩展，用法与Debug.LogError相符
        /// </summary>
        /// <param name="obj">触发函数对应的类</param>
        /// <param name="message">打印信息</param>
        [Conditional("EnableLog")]
        public static void LogError(this object obj, string message)
        {
            Debuger.LogError(DebugerExtension.GetLogTag(obj), message);
        }
        /// <summary>
        /// Debug.LogError扩展，用法与Debug.LogError相符
        /// </summary>
        /// <param name="obj">触发函数对应的类</param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        [Conditional("EnableLog")]
        public static void LogError(this object obj, string format, params object[] args)
        {
            string message = string.Format(format, args);
            Debuger.LogError(DebugerExtension.GetLogTag(obj), message);
        }

        /// <summary>
        /// 获取调用打印的类名称或者标记有NAME的字段 
        /// 有NAME字段的，触发类名称用NAME字段对应的赋值
        /// 没有用类的名称代替
        /// </summary>
        /// <param name="obj">触发Log对应的类</param>
        /// <returns></returns>
        private static string GetLogTag(object obj)
        {
            FieldInfo field = obj.GetType().GetField("NAME");
            bool flag = field != null;
            string result;
            if (flag)
            {
                result = (string)field.GetValue(obj);
            }
            else
            {
                result = obj.GetType().Name;
            }
            return result;
        }
    }
}