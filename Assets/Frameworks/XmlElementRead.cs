using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System;
using UnityEngine;

public class XmlElementRead
{
    private static TextAsset txtAsset = null;
    private static XmlDocument confDoc = null;
    private static XmlNode confRoot = null;
    private static XmlNodeList xnl = null;
    private static XmlElement _element = null;

    public static void LoadXML(string name)
    {
        txtAsset = (TextAsset)Resources.Load("Config/" + name, typeof(TextAsset));
        if (txtAsset == null)
        {
            Debug.Log("Load" + name + "Fail!");
            return;
        }
        confDoc = new XmlDocument();
        confDoc.LoadXml(txtAsset.text);
    }

    public static void UnLoadXML()
    {
        Resources.UnloadAsset(txtAsset);
        txtAsset = null;
        confDoc = null;
        confRoot = null;
        xnl = null;
        _element = null;
    }

    public static void ReadConfig(string name)
    {
        if (confDoc != null)
        {
            confRoot = confDoc.SelectSingleNode("root");
			xnl = confRoot.SelectSingleNode(name).ChildNodes;
        }        
    }

    public static int GetElementCount()
    {
        if (xnl != null)
            return xnl.Count;
        return 0;
    }
    
    public static void ReadElementByIndex(int index)
    {
        if (xnl != null && index < xnl.Count)
        {
            _element = (XmlElement)xnl[index]; 
        }
    }

    public static int ReadInt(string key)
    {
        return Convert.ToInt32(_element.GetElementsByTagName(key).Item(0).InnerText);
    }

    public static string ReadString(string key)
    {
        return _element.GetElementsByTagName(key).Item(0).InnerText.Replace("\\n","\n");
    }

    public static List<int> ReadIntArray(string key)
    {
        List<int> intList = new List<int>();
        string contentStr = _element.GetElementsByTagName(key).Item(0).InnerText;
        if (contentStr != "")
        {
            string[] items = contentStr.Split(new char[]{',', '，'});
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != "")
                {
                    intList.Add(Convert.ToInt32(items[i]));
                }              
            }
        }       
        return intList;
    }

    public static List<string> ReadStringArray(string key)
    {
        List<string> strList = new List<string>();
        string contentStr = _element.GetElementsByTagName(key).Item(0).InnerText;
        if (contentStr != "")
        {
            string[] items = contentStr.Split(new char[] { ',', '，' });
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != "")
                {
                    strList.Add(items[i]);
                }
            }
        }
        return strList;
    }

    public static List<List<int>> ReadBossAI(string key)
    {
        List<List<int>> aiList = new List<List<int>>();
        string str = _element.GetElementsByTagName(key).Item(0).InnerText;
        string[] aiItems = str.Split(';');
        for (int i = 0; i < aiItems.Length; i++)
        {
            List<int> items = new List<int>();
            string[] itemsStr = aiItems[i].Split(':');
            for (int j = 0; j < itemsStr.Length; j++)
            {
                items.Add(Convert.ToInt32(itemsStr[j]));
            }
            aiList.Add(items);
        }
        return aiList;
    }
}
