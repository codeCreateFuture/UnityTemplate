using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyUiMgr : MonoBehaviour {


    public static EasyUiMgr Instance;
    private void Awake()
    {
        Instance = this;
        Init();
        DontDestroyOnLoad(gameObject);


    }

   


    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }
    private Dictionary<string, BasePanel> panelDict;    //储存实例化面板的字典    
    private Stack<BasePanel> panelStack;    //储存面板的栈    

    /// <summary>    
    /// 获取面板    
    /// </summary>    
    private BasePanel GetPanel(string panelPath)
    {
        BasePanel panel;
        panelDict.TryGetValue(panelPath, out panel);
        if (panel == null)
        {
            GameObject insObj = GameObject.Instantiate(Resources.Load(panelPath)) as GameObject;
            
            if (insObj == null) { Debug.LogError("没有有效的路径：  " + panelPath); }

            insObj.transform.SetParent(CanvasTransform, false);
            BasePanel basePanel = insObj.GetComponent<BasePanel>();
            panelDict.Add(panelPath, basePanel);
            return basePanel;
        }
        else
        {
            return panel;
        }
    }

    /// <summary>    
    /// 初始化对应的字典和栈    
    /// </summary>    
    private void Init()
    {
        if (panelDict ==null )
            panelDict = new Dictionary<string, BasePanel>();
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();
    }

    /// <summary>    
    /// 入栈，显示面板    
    /// </summary>    
    /// <param name="panelPath"> 面板的路径 </param>    
    public void PushPanel(string panelPath)
    {
       
        if (panelStack.Count > 0)
        {
          
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }
        BasePanel panel = GetPanel(panelPath);
        panel.OnEnter();
        panelStack.Push(panel);
     

    }

   

    /// <summary>    
    /// 出栈，移除面板    
    /// </summary>    
    public void PopToLastPanel()
    {
      

        if (panelStack.Count <= 0) return;

        if(panelStack.Count==1)
        {
            Debug.LogError("最后一个面板，不能出栈！");
            return;
        }
        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();
        if (panelStack.Count <= 0) return;
        BasePanel nextPanel = panelStack.Peek();
        nextPanel.OnResume();
    }
    private void OnDestroy()
    {
        if (panelDict.Count >= 1)
            panelDict.Clear();
        if (panelStack.Count >= 1)
            panelStack.Clear();
    }

    #region 扩展

    /// <summary>
    /// 隐藏所有面板
    /// </summary>
    private void PopAllPanel()
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();
        if (panelStack.Count <= 0) return;
        //关闭栈里面所有页面的显示
        while (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Pop();
            topPanel.OnExit();
        }
    }


    /// <summary>
    /// 隐藏当前面板
    /// </summary>
    private void PopCurrentPanel()
    {
       
        if (panelStack.Count <= 0) return;
        //关闭栈顶页面的显示
        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();
    }


    /// <summary>
    /// 关闭页面并显示新的页面
    /// </summary>
    /// <param name="panelType"></param>
    /// <param name="isPopCurrentPanel">true时, 关闭当前页面; false时, 关闭所有页面</param>
    public void PushPanel(string panelPath, bool isPopCurrentPanel)
    {
        if (isPopCurrentPanel)
        {
            PopCurrentPanel();
        }
        else
        {
            PopAllPanel();
        }
        PushPanel(panelPath);
    }


    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("scene index :" + level);
    }

    #endregion
}
