using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

/*����1��
 * 
   WwwItem item = new WwwItem(LocalUrl(Application.streamingAssetsPath + "/11.mp4"), () =>
            {
                Debug.Log("Onstart");
            },(progress) =>
            {
                Debug.Log(progress);
            },(www)=>
            {
                Debug.Log("Onfinish");

            },()=>
            {
                Debug.Log("OnError");
            }
            );

            WwwTools.Instance.AddTask(item);
 */

/*����2��
* 
WwwItem item = new WwwItem(LocalUrl(Application.streamingAssetsPath + "/11.mp4"), () =>
        {
            Debug.Log("Onstart");
        },(progress) =>
        {
            Debug.Log(progress);
        },(www)=>
        {
            Debug.Log("Onfinish");

        },()=>
        {
            Debug.Log("OnError");
        }
        );

        WwwTools.Instance.AddTask(item);
*/


public class WwwTools : MonoBehaviour {


    public Text txt;
    Queue<WwwItem> allTask;
    static  WwwTools _instance;
    public static WwwTools Instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = FindObjectOfType<WwwTools>() ?? new GameObject(typeof(WwwTools).Name).AddComponent<WwwTools>();
            }
            return _instance;
        }
        
    }
    private void Awake()
    {
        _instance = this;
        allTask = new Queue<WwwItem>();
    }


    bool _isDownloadFinish = true;
    public void AddTask(WwwItem item)
    {
        if (item == null) return;
        allTask.Enqueue(item);
        if(allTask.Count==1&&_isDownloadFinish)
        {
            _isDownloadFinish = false;
            StartCoroutine(Download());
        }
    }

    public static string LocalUrl(string oldUrl)
    {
        if (Application.platform == RuntimePlatform.WindowsEditor ||
           Application.platform == RuntimePlatform.WindowsPlayer)
        {
            oldUrl = "file:///" + oldUrl;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            oldUrl = "jar:file://" + oldUrl;
        }
        else
        {
            oldUrl = "file://" + oldUrl;
        }
        return oldUrl;
    }

    IEnumerator Download()
    {
        while(allTask.Count>0)
        {
            WwwItem item = allTask.Dequeue();     
            yield return item.Download();
        }
        _isDownloadFinish = true;

    }

    //private void Update()
    //{
    //    if(Input.GetMouseButtonUp(1))
    //    {
    //        WwwItem item = new WwwItem(LocalUrl(Application.streamingAssetsPath + "/11.mp4"), () =>
    //        {
    //            Debug.Log("Onstart");
    //        }, (progress) =>
    //        {
    //            Debug.Log(progress);
    //        }, (www) =>
    //        {
    //            Debug.Log("Onfinish");
    //        }, () =>
    //        {
    //            Debug.Log("OnError");
    //        }
    //    );

    //        WwwTools.Instance.AddTask(item);
    //    }
    //}
}


public class WwwItem
{

    Action _downLoadStartEvent;
    Action<WWW> _downLoadFinishEvent;
    Action<float> _downLoadUpdateEvent;
    Action _downLoadErrorEvent;

    string _url = string.Empty;

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="url">����·��</param>
    /// <param name="downloadStartEvent">��ʼ�����¼�</param>
    /// <param name="downLoadUpdateEvent">����ÿ֡�����¼�</param>
    /// <param name="downLoadFinishEvent">��������¼�</param>
    /// <param name="downLoadErrorEvent">���س����¼�</param>
    public WwwItem(string url,Action downloadStartEvent=null, Action<float> downLoadUpdateEvent=null, Action<WWW> downLoadFinishEvent = null, Action downLoadErrorEvent=null)
    {
        _url = url;
        _downLoadStartEvent = downloadStartEvent;
        _downLoadUpdateEvent = downLoadUpdateEvent;
        _downLoadFinishEvent = downLoadFinishEvent;
        _downLoadErrorEvent = downLoadErrorEvent;

    }
    public IEnumerator Download()
    {
        DownloadStart();
        if (_downLoadStartEvent != null) _downLoadStartEvent();
        WWW www = new WWW(_url);

        while (!www.isDone)//��������
        {
            DownloadUpdate( www.progress);
            if (_downLoadUpdateEvent != null) _downLoadUpdateEvent(www.progress);
            yield return null;
        }
        yield return www;
        if (string.IsNullOrEmpty(www.error))//�������
        {
            DownloadFinish(www);
            if (_downLoadFinishEvent != null) _downLoadFinishEvent(www);
        }
        else   //���س���
        {
            DownloadError(this);
            if (_downLoadErrorEvent != null) _downLoadErrorEvent();
        }
        www.Dispose();
    }

    public virtual void DownloadFinish(WWW www)
    {
        Debug.Log("DownloadFinish");
        
    }

    public virtual void DownloadError(WwwItem item)
    {
        Debug.Log("downloadError :"+_url);
    }

    public virtual void DownloadUpdate(float process)
    {
        Debug.Log( process);
    }

    public virtual void DownloadStart()
    {
        Debug.Log("DownloadStart");
    }

}
