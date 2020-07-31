using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyUiMgrTestPanel :BasePanel {

    [SerializeField]
    private Button missileButton;
    [SerializeField]
    private Button satelliteButton;
    [SerializeField]
    private Button spaceportButton;

    private void Start()
    {
        missileButton.onClick.AddListener(OnClickMissileButton);
        satelliteButton.onClick.AddListener(OnClickSatelliteButton);
        spaceportButton.onClick.AddListener(OnClickSpaceportButton);
    }

    /// <summary>    
    /// 点击导弹按钮    
    /// </summary>    
    private void OnClickMissileButton()
    {
        Debug.Log("导弹");
    }

    /// <summary>    
    /// 点击卫星按钮    
    /// </summary>    
    private void OnClickSatelliteButton()
    {
        Debug.Log("卫星");
        EasyUiMgr.Instance.PopToLastPanel();
    }

    /// <summary>    
    /// 点击空间站按钮    
    /// </summary>    
    private void OnClickSpaceportButton()
    {
        EasyUiMgr.Instance.PushPanel(UIPanelPath.EasyUiMgrTestTwo);
    }

    public override void OnPause()
    {
        canvasGroup.alpha = 0;
        Debug.Log("onpause");
    }

    public override void OnResume()
    {
        canvasGroup.alpha = 1;
    }
}
