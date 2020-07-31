using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetLoad : MonoBehaviour {

    /// <summary>
    /// 加载Unity外部的的配置文件
    /// </summary>
    /// <param name="fullPath">文件路径</param>
    /// <returns>文件内容</returns>
    public string LoadConfigsFileFromOut(string fullPath)
    {
        string retStr = "";
        if (File.Exists(fullPath))
        {
            using (FileStream fs = new FileStream(fullPath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    retStr = sr.ReadToEnd();
                }
            }
        }else
        {
            Debug.Log(fullPath + " :文件不存在");
        }
        return retStr;
    }

    /// <summary>
    /// 编辑模式下加载资源unity内部
    /// </summary>
    /// <typeparam name="T">资源路径</typeparam>
    /// <param name="fullPath"></param>
    /// <returns></returns>
    public T  LoadAssetInEditor<T>(string fullPath) where T : UnityEngine.Object
    {
        // string fullPath = string.Format("Assets/Download/UI/UIPrefab/{0}.prefab", assetPath);
        //加载镜像
        T obj = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(fullPath);
        return obj;

    }

    /// <summary>
    /// 加载Resources文件夹下的资源
    /// </summary>
    /// <typeparam name="T">unity类型</typeparam>
    /// <param name="path">Resources下的相对路径</param>
    /// <returns></returns>
    public T LoadResource<T>(string path) where T : UnityEngine.Object
    {     
        T TResource = Resources.Load<T>(path);
        if (TResource == null)
        {
            Debug.LogError(GetType() + "/GetInstance()/TResource 提取的资源找不到，请检查。 path=" + path);
        }
        return TResource;
    }
}
