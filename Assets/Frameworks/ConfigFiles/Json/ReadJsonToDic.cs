using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class ReadJsonToDic{

   
    Dictionary<string, Dictionary<string, string>> configDict;

    public  ReadJsonToDic(string url)
    {
        configDict = new Dictionary<string, Dictionary<string, string>>();
        TextAsset textAsset = Resources.Load<TextAsset>(url);
        JsonData data = JsonMapper.ToObject(textAsset.text);
        int JdCount = data.Count;
        for (int i = 0; i < JdCount; i++)
        {
            JsonData jdk = data[i];
            List<string> jdKeys = new List<string>(jdk.Keys);
            int jdkCount = jdKeys.Count;
            if (jdKeys.Contains("id"))
            {
                string idKey = jdk["id"].ToString();
                if (!configDict.ContainsKey(idKey))
                {
                    configDict[idKey] = new Dictionary<string, string>();
                }
                Dictionary<string, string> valueDict = configDict[idKey];
                for (int j = 0; j < jdkCount; j++)
                {
                    JsonData jd = jdk[jdKeys[j]];
                    valueDict[jdKeys[j]] = jd == null ? null : jd.ToString();

                }
            }
        }


    }

    public Dictionary<string, string>GetDictItem(int dictIndex)
    {
        List<string> keys = new List<string>(configDict.Keys);
        if (dictIndex >= 0 && dictIndex < configDict.Count)
        {
            string id = keys[dictIndex];
            if (string.IsNullOrEmpty(id))
                return null;
            if (configDict.ContainsKey(id))
            {
                return configDict[id];
            }
        }
        return null;
    }

    public Dictionary<string, string> GetDictItem(string id)
    {
        if (string.IsNullOrEmpty(id))
            return null;
        if (configDict.ContainsKey(id))
        {
            return configDict[id];
        }
        Debug.LogError(id + "-is null:" + configDict.Count);
       
        return null;
    }
}
