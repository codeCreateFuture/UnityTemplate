using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class UiTextTipMgr : MonoBehaviour
{

    Queue<UiTipEntity> tipQueue;

    /// <summary>
    /// 上一次显示时间
    /// </summary>
    float preTipTime = 0f;
    /// <summary>
    /// 间隔显示时间
    /// </summary>
    float interval = 0.5f;

    public static UiTextTipMgr Instance;



    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        tipQueue = new Queue<UiTipEntity>();

    }

    /// <summary>
    /// 显示ui提示
    /// </summary>
    /// <param name="content">显示内容</param>
    /// <param name="offsetY">变化高度</param>
    /// <param name="showTime">显示时长</param>
    public void ShowTip(string content, float offsetY = 150f, float showTime = 1f)
    {
        tipQueue.Enqueue(new UiTipEntity()
        {
            content = content,
            offsetY = offsetY,
            showTime = showTime
        });
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time > preTipTime + interval)
        {
            preTipTime = Time.time;

            if (tipQueue.Count > 0)
            {
                UiTipEntity entity = tipQueue.Dequeue();

                if (string.IsNullOrEmpty(entity.content)) return;

                GameObject go = Resources.Load<GameObject>("UiTextTipItem");
                if (go == null)
                {

                    Debug.LogError("路径有问题，请检查！");
                    return;
                }
                go = Instantiate(go);
                SetParent(go.transform, FindObjectOfType<Canvas>().transform);
                go.GetComponent<UiTextTipItem>().SetUi(entity.content, entity.offsetY, entity.showTime);

            }
        }

        if (Input.GetMouseButtonUp(2))
        {
            ShowTip("Lixi", 200f, 2f);
        }

    }

    void SetParent(Transform tran, Transform parent)
    {
        tran.parent = parent;
        tran.localPosition = Vector3.zero;
        tran.localScale = Vector3.one;
        tran.localEulerAngles = Vector3.zero;
    }
}

public class UiTipEntity
{
    /// <summary>
    /// 提示内容
    /// </summary>
    public string content;

    /// <summary>
    /// 显示时长
    /// </summary>
    public float showTime = 1f;

    /// <summary>
    /// 变化高度
    /// </summary>
    public float offsetY = 150f;
}
