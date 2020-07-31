using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetConfigsMgr
{

    private const string settingsAssetConfigPath = "Assets/Frameworks/ConfigFiles/Asset/SettingsAssetConfig.asset";

    /// <summary>
    /// �༭��ģʽ�¼��� ͨ��AssetDatabase��
    /// </summary>
    /// <returns></returns>
    public static SettingsAssetConfig GetSettingsAssetConfig()
    {
        SettingsAssetConfig realConfig = AssetDatabase.LoadAssetAtPath<SettingsAssetConfig>(settingsAssetConfigPath);
        return realConfig;
    }

    /// <summary>
    /// ͨ��Resources����أ�SettingsAssetConfig.asset�ļ��������Resources�ļ����²ſ��Զ�ȡ
    /// </summary>
    /// <returns></returns>
    public static SettingsAssetConfig GetSettingsAssetConfigByResources()
    {
        SettingsAssetConfig ret = Resources.Load<SettingsAssetConfig>("SettingsAssetConfig");
        return ret;

    }

    /// <summary>
    /// ���ͷ�����ͨ��Resources�����
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
