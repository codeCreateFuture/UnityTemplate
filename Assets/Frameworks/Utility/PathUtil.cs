using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathUtil
{

    public static string GetAppRootPath()
    {
        return Application.dataPath + "/../"; //Application.dataPath Editor模式是Assets目录路径,打包后是*_Data目录路径
    }

    public static string GetIniFilePath()
    {
        return Application.dataPath + "/../config.ini"; //Application.dataPath Editor模式是Assets目录路径,打包后是*_Data目录路径
    }

    /// <summary>
    /// 获取某个文件的绝对路径
    /// </summary>
    /// <param name="fileName">文件名称(包含文件后缀名)</param>
    /// <returns></returns>
    public static string GetConfigPath(string fileName)
    {
        DirectoryInfo dir = new DirectoryInfo(Application.dataPath);
        string url = dir.Parent.FullName + "/Configs";
        if (!Directory.Exists(url))
            Directory.CreateDirectory(url);
        return url + "/" + fileName;
    }

}
