using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StartOtherApp : MonoBehaviour {

    private Process pc;

    void Start()
    {
        StartCoroutine(StartApp());
    }

    IEnumerator StartApp()
    {

        yield return new WaitForSeconds(2);
        pc = Process.Start("C:/Users/Administrator/Desktop/vrTeacher/teacher.exe");
        pc.EnableRaisingEvents = true;
        //�򿪵��ⲿӦ�ó����˳�ʱ����
        pc.Exited += new EventHandler(myProcess_Exited);         
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void myProcess_Exited(object sender, EventArgs e)
    {
#if   UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else

        Application.Quit();
#endif

    }
}
