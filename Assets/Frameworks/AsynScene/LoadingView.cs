using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
namespace AsynLoading
{
    public class LoadingView : MonoBehaviour
    {

        Text _loadingTip;
        Text _percentTip;
        Slider _loadingSlider;
        GameObject _panelLoading;
        private bool isLoad;


        void Awake()
        {
            Init();
            DontDestroyOnLoad(gameObject);
            AsynSceneListener.registerEvent(AsynSceneEvent.StartLoadSence, StartLoadSence);//开始加载场景（事件）.
            AsynSceneListener.registerEvent(AsynSceneEvent.CloseLoadSence, CloseLoadSence);//关闭加载场景（事件）.
            AsynSceneListener.registerEvent(AsynSceneEvent.UpdatePregress, OnUpdatePregress);//关闭加载场景（事件）.

        }

        void Init()
        {
            _panelLoading = transform.Find("panelLoading").gameObject;
            _loadingTip = _panelLoading.transform.Find("loadingTip").GetComponent<Text>();
            _percentTip = _panelLoading.transform.Find("percentTip").GetComponent<Text>();
            _loadingSlider = _panelLoading.transform.Find("loadingSlider").GetComponent<Slider>();
            _panelLoading.SetActive(false);
            GetComponent<Canvas>().sortingOrder =10000;

        }

        private void OnUpdatePregress(object target)
        {
            float percent = (float)target;
            _loadingSlider.value = percent;
            _percentTip.text = (percent * 100).ToString() + "%";
        }

        void OnDestory()
        {

            AsynSceneListener.deleteEvent(AsynSceneEvent.StartLoadSence, StartLoadSence);
            AsynSceneListener.deleteEvent(AsynSceneEvent.CloseLoadSence, CloseLoadSence);
            AsynSceneListener.deleteEvent(AsynSceneEvent.UpdatePregress, OnUpdatePregress);

        }


        //开始加载场景.
        public void StartLoadSence(object data)
        {
            _percentTip.text = "";
            _loadingTip.text = "";
            _panelLoading.SetActive(true);
            isLoad = true;
            _loadingTip.text = "正在载入场景.......";
        }

        //关闭加载场景.
        public void CloseLoadSence(object data)
        {
            isLoad = false;
            _loadingTip.text = "";
            _percentTip.text = "";
           _panelLoading.SetActive(false);
            _loadingSlider.value = 0f;
        }

    }
}
