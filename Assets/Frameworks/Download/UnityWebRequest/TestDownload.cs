﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//测试下载
public class TestDownload : MonoBehaviour {

    //网络上的资源支持断点续传
    string url1 = "http://dldir1.qq.com/qqfile/qq/TIM2.0.0/22317/TIM2.0.0.exe";
    string url2 = "http://sqdd.myapp.com/myapp/qqteam/tim/down/tim.apk";

    //经测试，无法对本地文件进行断点续传，如果暂停后继续下载，会把暂停前下载的数据量累加到总的文件数据中；只有不暂停直至下载完成才会获取完整文件
    //string url1 = "file://E:/Test.apk";
    //string url2 = "file://E:/Test.rar";

    public Text textUrl1;
    public Text textProgress1;
    public Text textUrl2;
    public Text textProgress2;
    
    private void Start()
    {
        //前端显示资源路径
        textUrl1.text = "URL1:\n" + url1;
        textUrl2.text = "URL2:\n" + url2;
       
    }

    //开始下载url1
    public void StartDownload1()
    {
        string[] URLStr = url1.Split('/');
        string FileName = URLStr[URLStr.Length - 1];
        _DownloadHandler handler = DownlaodFile._Instance.StartDownload(url1, Application.dataPath + "/../" + FileName);
        if (handler == null)
            return;
        handler.RegisteProgressBack(Progress1);

        handler.RegisteReceiveTotalLengthBack(Total);
        handler.RegisteCompleteBack(Complete);
    }

    //开始下载url2
    public void StartDownload2()
    {
        string[] URLStr = url2.Split('/');
        string FileName = URLStr[URLStr.Length - 1];
        _DownloadHandler handler = DownlaodFile._Instance.StartDownload(url2, Application.dataPath + "/../" + FileName);
        if (handler == null)
            return;
        handler.RegisteProgressBack(Progress2);

        handler.RegisteReceiveTotalLengthBack(Total);
        handler.RegisteCompleteBack(Complete);
    }

    //停止下载url1
    public void StopDownload1()
    {
        DownlaodFile._Instance.StopDownload(url1);
    }

    //停止下载url2
    public void StopDownload2()
    {
        DownlaodFile._Instance.StopDownload(url2);
    }


    #region 回调

    //完成下载
    private void Complete(string path)
    {
        Debug.Log("下载完成，文件路径=>" + path);
    }

    //文件总大小
    private void Total(int length)
    {
        Debug.Log("要下载的文件总大小=>" + length + "字节");
    }

    //下载进度1
    private void Progress1(float progress)
    {
        textProgress1.text = "进度:" + (progress * 100).ToString("0.00") + "%";
    }

    //下载进度2
    private void Progress2(float progress)
    {
        textProgress2.text = "进度:" + (progress * 100).ToString("0.00") + "%";
    }

    #endregion

}