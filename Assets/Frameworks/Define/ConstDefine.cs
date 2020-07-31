using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 常量定义，不可修改
/// </summary>
public class ConstDefine {

    #region 事件模板  某个事件加入前缀标志区分（代表）属于某个UI窗口的事件 学生管理页面
    //Btn事件
    public const string UIStudentManager_BackClassManagerBtn = "UIStudentManager_BackClassManagerBtn";
    public const string UIStudentManager_EditBtn = "UIStudentManager_EditBtn";
  
    //Item Btn事件
    public const string UIStudentManagerItem_ModifBtn = "UIStudentManagerItem_ModifBtn";
    public const string UIStudentManagerItem_DelBtn = "UIStudentManagerItem_DelBtn";
    //Pop Btn事件
    public const string UIStudentManagerPopView_ConfirmBtn = "UIStudentManagerPopView_ConfirmBtn";
    public const string UIStudentManagerPopView_CancelBtn = "UIStudentManagerPopView_CancelBtn";
    //Pop Msg
    public const string UIStudentManagerPopMsg = "删除学生会同步删除该学生作品!";
    //Scroll
    public const string UIStudentManager_ChangeScroll = "UIStudentManager_ChangeScroll";
    //开始导入事件
    public const string UIStudentManager_StartImport = "UIStudentManager_StartImport";
    #endregion



    /// <summary>
    /// 持久化账号
    /// </summary>
    public const string account = "account";
    /// <summary>
    /// 持久化密码
    /// </summary>
    public const string password = "password";

    /// <summary>
    /// 背景声音名字
    /// </summary>
    public const string bgSoundName = "bgSound";

    /// <summary>
    /// ui点击音频名字
    /// </summary>
    public const string uiClickSoundName = "uiClickSound";


    public const string prefs_isPlayBgSound = "prefs_isPlayBgSound";             // 持久化 是否播放背景音乐
    public const string prefs_isPlayEffectSound = "prefs_isPlayEffectSound";     // 持久化 是否播放特效声音
    public const string prefs_bgSoundVolume = "prefs_bgSoundVolume";             //持久化 背景音乐 大小
    public const string prefs_effectSoundVolume = "prefs_effectSoundVolume";     //持久化 特效声音 大小

}
