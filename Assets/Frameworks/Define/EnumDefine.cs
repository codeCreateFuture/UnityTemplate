using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 枚举Enum类型定义
/// </summary>
public class EnumDefine
{
    /// <summary>
    /// 屏幕适配调整
    /// </summary>
    public enum ScreenAdjustT
    {
        Clip = 0,
        Max = 2,
        Min = 0,
        None = -1,
        Scale = 1
    }

    #region 场景
    /// <summary>
    /// 场景枚举定义
    /// </summary>
    public enum SceneName
    {
        Start = 0, //开始场景
        LOGO,  //加载场景
        LOGIN, //登录场景
        MAIN,  //主场景
        BATTLE,//对战场景
    }
    #endregion

    /// <summary>
    /// 资源类型
    /// </summary>
    public enum ResType
    {
        //文本
        TextAsset,
        //音效
        Audio,
        //图片
        Texture,
        //预制
        Prefab,
    }

    public enum ConfigType
    {
        json=0,
        xml,
        txt,
        excel,
    }
}

