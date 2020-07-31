using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace AsynLoading
{
    public class OneScene : MonoBehaviour
    {

        public GameObject LoadingView;
        public AsyncOperation async;
        public void Click()
        {
            AsynSceneMgr.LoadScene("AsynTwo");

        }

        void Start()
        {
            AsynSceneListener.registerEvent(AsynSceneEvent.LoadLoadingView, OnLoadingView);//实例化loadingObj.
            if (!AsynSceneMgr.IsLoadLoadingView)
            {
                AsynSceneMgr.LoadLoadingView();
            }
            AsynSceneListener.dispatchEvent(AsynSceneEvent.CloseLoadSence, null);

        }

        private void OnDestroy()
        {
            AsynSceneListener.deleteEvent(AsynSceneEvent.LoadLoadingView, OnLoadingView);
        }

        /// <summary>
        /// 实例化loading物体
        /// </summary>
        /// <param name="data"></param>
        private void OnLoadingView(object data)
        {
            if (LoadingView == null)
            {
                LoadingView = Instantiate(Resources.Load("LoadingCanvas")) as GameObject;
                LoadingView.name = "LoadingCanvas";
            }
        }


    }
}