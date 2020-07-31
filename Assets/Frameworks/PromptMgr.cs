using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using System.Collections;

public class PromptMgr : MonoBehaviour
{

    // Use this for initialization



    public bool isShowPrompt = true;

    static PromptMgr _instance;
    public static PromptMgr Instance { get { return _instance; } }


    Text labelHint;
    Text textBox;
    GameObject panelBox;
    Text textTitle;
    Button buttonSure;
    Button buttonClose;
    void Awake()
    {
        _instance = this;

        labelHint = GameUtility.FindDeepChild<Text>(this.gameObject, "textHint");
        textBox = GameUtility.FindDeepChild<Text>(this.gameObject, "panelBox/textBox");

        panelBox = GameUtility.FindDeepChild(this.gameObject, "panelBox").gameObject;

        textTitle = GameUtility.FindDeepChild<Text>(this.gameObject, "panelBox/titleBg/textTitle");
        buttonSure = GameUtility.FindDeepChild<Button>(this.gameObject, "panelBox/buttonSure");
        buttonClose = GameUtility.FindDeepChild<Button>(this.gameObject, "panelBox/buttonClose");

        panelBox.SetActive(false);
        labelHint.gameObject.SetActive(false);
        DontDestroyOnLoad(this);
    }



    public void ShowPrompt(string message, float showTime = 2f)
    {
        if (isShowPrompt)
        {
            panelBox.SetActive(false);

            labelHint.text = message;
            labelHint.gameObject.SetActive(true);

            StartCoroutine(_showPrompt(showTime));
        }
    }

    IEnumerator _showPrompt(float showTime = 2f)
    {
        yield return new WaitForSeconds(showTime);
        labelHint.gameObject.SetActive(false);
    }



    public void ShowBoxPrompt(string message, string messageTitle = "提示", UnityAction buttonSureHandleCallBack = null, UnityAction buttonCloseCallBack = null)
    {
        if (isShowPrompt)
        {
            labelHint.gameObject.SetActive(false);

            textBox.text = message;
            textTitle.text = messageTitle;

            panelBox.SetActive(true);
            if (buttonSureHandleCallBack != null)
            {
                buttonSure.onClick.AddListener(buttonSureHandleCallBack);
            }
            else
            {
                buttonSure.onClick.AddListener(delegate () { panelBox.SetActive(false); });
            }

            if (buttonCloseCallBack != null)
            {
                buttonClose.onClick.AddListener(buttonCloseCallBack);
            }
            else
            {
                buttonClose.onClick.AddListener(delegate (){ panelBox.SetActive(false); });
            }

            // StartCoroutine(_showPrompt(showTime));
        }
    }

  

    IEnumerator _showBoxPrompt(float showTime = 2f)
    {
        yield return new WaitForSeconds(showTime);
        labelHint.gameObject.SetActive(false);
    }
}
