using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/// <summary>
/// 1. "/":斜杠 unity使用"/"来定义路径
/// 2."\":反斜杠 windows系统使用"\"来定义文件路径  也是转义字符的符号,"\n"：代表的意义是换行
/// </summary>

public class FileUtil{


    /// <summary>
    /// 创建目录
    /// </summary>
    /// <param name="filePath">需要创建的目录路径</param>
    public static void CreateDirectory(string filePath)
    {
        if (!string.IsNullOrEmpty(filePath))
        {
            string dirName = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
        }
    }

    /// <summary>
    /// 创建文件
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="bytes">文件内容</param>
    public static void CreatFile(string filePath, byte[] bytes)
    {
        FileInfo file = new FileInfo(filePath);
        Stream stream = file.Create();

        stream.Write(bytes, 0, bytes.Length);

        stream.Close();
        stream.Dispose();
    }



	/// <summary>
	/// 某个路径下创建文件夹
	/// </summary>
	/// <param name="path">需要创建文件夹的路径</param>
	/// <param name="folderName">文件夹名称</param>
	/// <returns></returns>
	public static string CreateFolder(string path, string folderName)
	{     
	   string fullPath= path + "\\" + folderName;
		if (!Directory.Exists(fullPath))
		{
			Directory.CreateDirectory(fullPath);
			return path;
		}
		return path;
	}

	/// <summary>
	/// 创建文件夹
	/// </summary>
	/// <param name="folderFullPath">文件夹的绝对路径</param>
	/// <returns></returns>
	public static string CreateFolder(string folderFullPath)
	{
		if (!Directory.Exists(folderFullPath))
		{
			Directory.CreateDirectory(folderFullPath);
			return folderFullPath;
		}
		return folderFullPath;
	}

	/// <summary>
	/// 加载文件数据成字符串
	/// </summary>
	/// <param name="fullFilePath">文件的绝对路径</param>
	/// <returns></returns>
	public static string LoadFile(string fullFilePath)
	{       
		string str = "";
		if (File.Exists(fullFilePath))
		{
			using (FileStream fs = new FileStream(fullFilePath, FileMode.Open))
			{
				using (StreamReader sr = new StreamReader(fs))
				{
					str = sr.ReadToEnd();
				}
			}
		}else
		{
			Debug.Log("文件不存在 ：" + fullFilePath);
		}
		return str;
	}

	/// <summary>
	/// 递归遍历某个路径下的所有文件和文件夹
	/// </summary>
	/// <param name="filePath"></param>
	public void ReadFileRecursion(string filePath)
	{	   
		DirectoryInfo d = new DirectoryInfo(filePath);
		FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
		foreach (FileSystemInfo fsinfo in fsinfos)
		{
			if (fsinfo is DirectoryInfo)     //判断是否为文件夹
			{
				Debug.Log(fsinfo.FullName);
				ReadFileRecursion(fsinfo.FullName);//递归调用
			}
			else
			{		 
					Debug.Log(fsinfo.FullName);//输出文件的全部路径
			}
		}
	}

	/// <summary>
	/// 创建一个空的文件
	/// </summary>
	/// <param name="url">文件的绝对路径+文件名称</param>
	public static void CreateEmpthFile(string url)
	{
		FileStream fs = new FileStream(url, FileMode.Create);
		fs.Dispose();
	}

	/// <summary>
	/// windows下的路径转换成Unity下的路径
	/// </summary>
	/// <param name="path"></param>
	/// <returns></returns>
	public static string ToUnityPath(string path)
	{
		string newPath=path.Replace('\\', '/');
		return newPath;
	}
	/// <summary>
	/// 转成windows系统下的路径
	/// </summary>
	/// <param name="path"></param>
	/// <returns></returns>
	public static string ToWindowsPath(string path)
	{
		if (string.IsNullOrEmpty(path)) return null;
		return path.Replace('/', '\\');
	}

	public static void WriteBytesToLocal(string unityFullPath,byte[] bytes)
	{
		unityFullPath = unityFullPath.Replace('\\', '/');
		System.IO.File.WriteAllBytes(unityFullPath, bytes);
	}


	public static bool ExistFile(string fileFullPath)
	{
	  return  System.IO.File.Exists(fileFullPath);
	   
	}

	/// <summary>
	/// 文件数据转化成字符串
	/// </summary>
	/// <param name="Path"></param>
	/// <returns></returns>
	public static string LoadString(string Path)
	{
		string LoadStr = System.Text.Encoding.UTF8.GetString(Loadbytes(Path));
		return LoadStr;
	}
	public static byte[] Loadbytes(string Path)
	{
		FileStream fs = File.OpenRead(Path);
		byte[] bytes = new byte[fs.Length];
		fs.Read(bytes, 0, bytes.Length);

		// 设置当前流的位置为流的开始   
		fs.Seek(0, SeekOrigin.Begin);
		fs.Dispose();
		fs.Close();
		return bytes;
	}


	/// <summary>
	/// 字符串写入到本地文件
	/// </summary>
	/// <param name="text">字符</param>
	/// <param name="offset"></param>
	/// <param name="url">本地文件绝对路径</param>
	/// <param name="ReWrite"></param>
	public static void WriteLocal(string text, int offset, string url, bool ReWrite = true)
	{
		byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);
		WriteLocal(buffer, offset, url, ReWrite);
	}
	public static void WriteLocal(byte[] buffer, int offset, string url, bool ReWrite = true)
	{
		//文件流信息
		FileStream fs;
		FileInfo t = new FileInfo(url);
		if (!t.Exists)
		{
			string str = url.Substring(0, url.LastIndexOf("/") + 1);
			if (!Directory.Exists(str))
				Directory.CreateDirectory(str);

		}

		fs = new FileStream(url, FileMode.Create);

		if (!ReWrite)
		{
			fs.Seek(0, SeekOrigin.End);
		}

		// fs = new FileStream(url, FileMode.Append,FileAccess.Write);
		// fs.Position = fs.Length;
		//以行的形式写入信息
		fs.Write(buffer, offset, buffer.Length);
		//关闭流
		fs.Close();
		//销毁流
		fs.Dispose();
	}
}
