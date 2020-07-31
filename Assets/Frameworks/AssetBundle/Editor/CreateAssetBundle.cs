using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateAssetBundle{

    [MenuItem("Tools/CreateAssetBundle(对所有ab资源进行打包)")]
    static void CreateAB()
    {
        string savePath = Application.dataPath + "/../AssetBundle/";

        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
        Debug.Log("创建ab资源， CreateAssetBundle");

        BuildPipeline.BuildAssetBundles(savePath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        Application.OpenURL(savePath);
    }
}
