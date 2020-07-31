using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetLoad : MonoBehaviour {

    /// <summary>
    /// ����Unity�ⲿ�ĵ������ļ�
    /// </summary>
    /// <param name="fullPath">�ļ�·��</param>
    /// <returns>�ļ�����</returns>
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
            Debug.Log(fullPath + " :�ļ�������");
        }
        return retStr;
    }

    /// <summary>
    /// �༭ģʽ�¼�����Դunity�ڲ�
    /// </summary>
    /// <typeparam name="T">��Դ·��</typeparam>
    /// <param name="fullPath"></param>
    /// <returns></returns>
    public T  LoadAssetInEditor<T>(string fullPath) where T : UnityEngine.Object
    {
        // string fullPath = string.Format("Assets/Download/UI/UIPrefab/{0}.prefab", assetPath);
        //���ؾ���
        T obj = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(fullPath);
        return obj;

    }

    /// <summary>
    /// ����Resources�ļ����µ���Դ
    /// </summary>
    /// <typeparam name="T">unity����</typeparam>
    /// <param name="path">Resources�µ����·��</param>
    /// <returns></returns>
    public T LoadResource<T>(string path) where T : UnityEngine.Object
    {     
        T TResource = Resources.Load<T>(path);
        if (TResource == null)
        {
            Debug.LogError(GetType() + "/GetInstance()/TResource ��ȡ����Դ�Ҳ��������顣 path=" + path);
        }
        return TResource;
    }
}
