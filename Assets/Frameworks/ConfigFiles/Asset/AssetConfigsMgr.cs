using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetConfigsMgr
{

    private const string settingsAssetConfigPath = "Assets/Frameworks/ConfigFiles/Asset/SettingsAssetConfig.asset";

    /// <summary>
    /// 编辑器模式下加载 通过AssetDatabase类
    /// </summary>
    /// <returns></returns>
    public static SettingsAssetConfig GetSettingsAssetConfig()
    {
        SettingsAssetConfig realConfig = AssetDatabase.LoadAssetAtPath<SettingsAssetConfig>(settingsAssetConfigPath);
        return realConfig;
    }

    /// <summary>
    /// 通过Resources类加载，SettingsAssetConfig.asset文件必须放在Resources文件夹下才可以读取
    /// </summary>
    /// <returns></returns>
    public static SettingsAssetConfig GetSettingsAssetConfigByResources()
    {
        SettingsAssetConfig ret = Resources.Load<SettingsAssetConfig>("SettingsAssetConfig");
        return ret;

    }

    /// <summary>
    /// 泛型方法：通过Resources类加载
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public static T GetAssetConfig<T>(string path)where T:UnityEngine.Object
    {
        T  ret = Resources.Load<T>(path);
        return ret;
    }

    public static T GetAssetConfigInEditor<T>(string fullPath) where T:UnityEngine.Object
    {
        T ret = AssetDatabase.LoadAssetAtPath<T>(fullPath);
        return ret;
    }
}
