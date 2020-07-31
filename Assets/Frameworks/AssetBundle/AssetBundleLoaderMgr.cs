using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���ڵ�������ab����û��ж�أ���Ҫ����
/// </summary>

public class AssetBundleLoaderMgr : MonoBehaviour {

    AssetBundleManifest manifest;
    /// <summary>
    /// ab���ľ���·��
    /// </summary>
    string assetBundleFullPath;

    /// <summary>
    /// ab��Դ���Ƶ����·���������ab����Ŀ¼��
    /// </summary>
    string loadAbRelativePathName = "hotdogtruck.asset";

    /// <summary>
    /// ab���ĸ�Ŀ¼�ļ�����
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
    /// ����assetBundle��Դ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="abName">���õ�ab�����ƣ�������׺</param>
    /// <param name="prefabName">������ab�������Ԥ��������</param>
    /// <returns></returns>
    public T LoadAsset<T>(string abName, string prefabName) where T : UnityEngine.Object
    {
        AssetBundle bundle = AssetBundle.LoadFromFile(assetBundleFullPath + abName);
        return bundle.LoadAsset(prefabName) as T;
    }

    /// <summary>
    /// ͨ��ab�������������ab��Դ
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
