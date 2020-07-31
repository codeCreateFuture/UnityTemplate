using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 存在的问题是ab镜像没有卸载，需要完善
/// </summary>

public class AssetBundleLoaderMgr : MonoBehaviour {

    AssetBundleManifest manifest;
    /// <summary>
    /// ab包的绝对路径
    /// </summary>
    string assetBundleFullPath;

    /// <summary>
    /// ab资源名称的相对路径（相对于ab包根目录）
    /// </summary>
    string loadAbRelativePathName = "hotdogtruck.asset";

    /// <summary>
    /// ab包的根目录文件名称
    /// </summary>
    string abFolderName = "assetBundle";

    string loadPrefabName = "HotDogTruck";


    void Start()
    {

        assetBundleFullPath = Application.dataPath + "/../" + abFolderName + "/";

        GameObject go = LoadAssetByDependenc<GameObject>(loadAbRelativePathName, loadPrefabName);
        Instantiate(go);

    }

    /// <summary>
    /// 加载assetBundle资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="abName">设置的ab包名称，包括后缀</param>
    /// <param name="prefabName">包含在ab包里面的预制体名称</param>
    /// <returns></returns>
    public T LoadAsset<T>(string abName, string prefabName) where T : UnityEngine.Object
    {
        AssetBundle bundle = AssetBundle.LoadFromFile(assetBundleFullPath + abName);
        return bundle.LoadAsset(prefabName) as T;
    }

    /// <summary>
    /// 通过ab包的依赖项加载ab资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="abName"></param>
    /// <param name="prefabName"></param>
    /// <returns></returns>
    public T LoadAssetByDependenc<T>(string abName, string prefabName) where T : UnityEngine.Object
    {
        AssetBundleManifest manifest = LoadAsset<AssetBundleManifest>(abFolderName, "AssetBundleManifest");
        string[] depArr = manifest.GetAllDependencies(loadAbRelativePathName);
        for (int i = 0; i < depArr.Length; i++)
        {
            Debug.Log(depArr[i]);
            LoadAsset<Object>(depArr[i], depArr[i]);
        }
        AssetBundle bundle = AssetBundle.LoadFromFile(assetBundleFullPath + abName);
        return bundle.LoadAsset(prefabName) as T;
    }
}
