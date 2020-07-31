using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AsynLoading
{


    public class AsynSceneMgr
    {

        private static List<string> lastScene = new List<string>();
        private static string lastSceneName;
        /**正在加载的场景*/
        public static string loadingScene;
        public static bool IsLoadLoadingView = false;
        public static void LoadScene(string name)
        {
            loadingScene = name;
            lastSceneName = Application.loadedLevelName;
            lastScene.Add(lastSceneName);
            AsynLoading.LoadScene(name);

        }

        /// <summary>
        /// 开始加载场景
        /// </summary>
        public static void StartLoadSence()
        {
            AsynSceneListener.dispatchEvent(AsynSceneEvent.StartLoadSence, new object());
        }

        /// <summary>
        /// 关闭加载场景
        /// </summary>
        public static void CloseLoadSence()
        {
            AsynSceneListener.dispatchEvent(AsynSceneEvent.CloseLoadSence, new object());
        }

        /// <summary>
        /// 实例化异步加载场景界面
        /// </summary>
        public static void LoadLoadingView()
        {
            IsLoadLoadingView = true;
            AsynSceneListener.dispatchEvent(AsynSceneEvent.LoadLoadingView, new object());
        }

        public static void LoadLastScene()
        {
            if (lastScene.Count > 0)
            {
                lastSceneName = Application.loadedLevelName;
                loadingScene = lastScene[lastScene.Count - 1];
                lastScene.RemoveAt(lastScene.Count - 1);
                AsynLoading.LoadScene(loadingScene);
            }

        }

        /// <summary>
        ///获取上一个场景(Scene)
        /// </summary>
        /// <returns></returns>
        public static string GetlastScene()
        {
            return lastSceneName;
        }
    }

    public class AsynSceneListener
    {
        private Hashtable map;
        public delegate void Callback(object target);
        private static AsynSceneListener _instance;
        private static AsynSceneListener instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AsynSceneListener();
                }
                return _instance;
            }
        }


        public AsynSceneListener()
        {
            map = new Hashtable();
        }

        public static void registerEvent(string type, Callback callback)
        {
            lock (instance)
            {
                if (!instance.map.Contains(type))
                {
                    instance.map.Add(type, ArrayList.Synchronized(new ArrayList()));
                }
                ArrayList array = (ArrayList)instance.map[type];
                if (!array.Contains(callback))
                {
                    array.Add(callback);
                }
            }
        }

        public static int deleteEvent(string type, Callback callback)
        {
            lock (instance)
            {
                ArrayList array = null;
                if (instance.map.Contains(type))
                {
                    array = (ArrayList)instance.map[type];
                    array.Remove(callback);
                    if (array.Count == 0)
                    {
                        instance.map.Remove(type);
                    }
                }
                return array == null ? 0 : array.Count;
            }
        }

        public static void dispatchEvent(string type, object data)
        {
            lock (instance)
            {
                if (instance.map.Contains(type))
                {
                    ArrayList array = (ArrayList)instance.map[type];
                    for (int i = 0; i < array.Count; i++)
                    {
                        Callback callback = (Callback)array[i];
                        callback(data);

                    }
                }
            }
        }

    }
    /// <summary>
    /// 异步加载场景事件
    /// </summary>
    public class AsynSceneEvent
    {

        public const string LoadLoadingView = "LoadLoadingView";//实例化异步加载场景界面.（事件）
        public const string StartLoadSence = "StartLoadSence";//开始加载场景.（事件）
        public const string CloseLoadSence = "CloseLoadSence";//结束加载场景.（事件）
        public const string UpdatePregress = "UpdatePregress";  //更新加载场景进度（事件）
    }
}


