using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通过CreateAssetMenu标注后会出现在Assets资源窗口右键功能选项中
/// </summary>
[CreateAssetMenu(fileName = "SettingsAssetConfig",menuName = "AssetConfigFile/SettingsAssetConfig",order =1)]
public class SettingsAssetConfig : ScriptableObject {

    public string appName = "app的名字";
    public bool isPlayBgMusic = true;
}



