using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


/// <summary>
/// 全局，系统静态变量定义，可修改
/// </summary>
public class StaticDefine {

    private static int _Version;
    public static int version { get { return _Version; } set { _Version = value; } }

    /// <summary>
    /// 是否播放背景声音  sound是声音 
    /// </summary>
    public static bool isPlayBgSound                          
    {
        get { return Convert.ToBoolean(PlayerPrefs.GetString(ConstDefine.prefs_isPlayBgSound, "true")); }
        set { PlayerPrefs.SetString(ConstDefine.prefs_isPlayBgSound, value.ToString()); }
    }


    /// <summary>
    /// 背景声音大小
    /// </summary>
    public static float bgSoundVolume                        
    {
        get{return PlayerPrefs.GetFloat(ConstDefine.prefs_bgSoundVolume, 1f);}
        set{PlayerPrefs.SetFloat(ConstDefine.prefs_bgSoundVolume, value); }
    }

    //是否播放音效
    public static bool isPlayEffectSound                      
    {
        get { return Convert.ToBoolean(PlayerPrefs.GetString(ConstDefine.prefs_isPlayEffectSound, "true")); }
        set { PlayerPrefs.SetString(ConstDefine.prefs_isPlayEffectSound, value.ToString()); }
    }

    //特效声音大小
    public static float effectSoundVolume                      
    {
        get { return PlayerPrefs.GetFloat(ConstDefine.prefs_effectSoundVolume, 1f);}
        set { PlayerPrefs.SetFloat(ConstDefine.prefs_effectSoundVolume, value);}
    }


    public static string account;                //账号
    static public string password;               //密码



    public static void SetCanvasResolution(float width, float height, float matchWidthOrHeight,Canvas canvas)
    {
        var canvasScaler = canvas.GetComponent<CanvasScaler>();
        canvasScaler.referenceResolution = new Vector2(width, height);
        canvasScaler.matchWidthOrHeight = matchWidthOrHeight;
    }
}
