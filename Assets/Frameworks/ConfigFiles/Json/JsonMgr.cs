using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class JsonMgr{
	private void test()
	{
		//example
		//GuideConfig[] objs = ReadJsonFromRes<GuideConfig>("GuideConfig");
		//GuideConfig[] objs2 = ReadJsonToArray<GuideConfig>(Application.dataPath + "/Resources/GuideConfig.json");

	}
	/// <summary>
	/// 从resources文件夹下面读取json文件并转成对象数组
	/// </summary>
	/// <typeparam name="T">对象泛型标志</typeparam>
	/// <param name="jsonFileName">json文件名</param>
	/// <returns></returns>
	public static T[] ReadJsonFromRes<T>(string jsonFileName)
	{
		TextAsset txt = Resources.Load<TextAsset>(jsonFileName);
		if (string.IsNullOrEmpty(txt.text))
		{
			Debug.Log("文件有错或者没有这样的文件：" + jsonFileName);
			return null;
		}
		T[] objs = LitJson.JsonMapper.ToObject<T[]>(txt.text);
		return objs;
	}

	/// <summary>
	/// 读取json文件并转成对象数组
	/// </summary>
	/// <typeparam name="T">对象泛型标志</typeparam>
	/// <param name="jsonFullPath">json文件完整路径</param>
	/// <returns></returns>
	public static T[] ReadJsonToArray<T>(string jsonFullPath)
	{
		// jsonFullPath = Application.dataPath + "/lzx.json";

		if (!System.IO.File.Exists(jsonFullPath))
		{
			Debug.Log("文件有错或者没有这样的文件：" + jsonFullPath);
			return null;
		}
		string jsons = LoadString(jsonFullPath);
		Debug.Log(jsons);

		if (string.IsNullOrEmpty(jsons))
			return null;

		T[] objs = JsonMapper.ToObject<T[]>(jsons);
		return objs;
	}


	/// <summary>
	/// 从resources文件夹下面读取json文件并转成List集合
	/// </summary>
	/// <typeparam name="T">对象泛型标志</typeparam>
	/// <param name="jsonFileName">json文件名</param>
	/// <returns></returns>
	public static List<T> ReadJsonFromResToList<T>(string jsonFileName)
	{
		TextAsset txt = Resources.Load<TextAsset>(jsonFileName);
		if (string.IsNullOrEmpty(txt.text))
		{
			Debug.Log("文件有错或者没有这样的文件：" + jsonFileName);
			return null;
		}
		List<T> objs = LitJson.JsonMapper.ToObject<List<T>>(txt.text);
		return objs;
	}


	/// <summary>
	/// 读取json文件并转成List对象
	/// </summary>
	/// <typeparam name="T">对象泛型标志</typeparam>
	/// <param name="jsonFullPath">json文件完整路径</param>
	/// <returns></returns>
	public static List<T> ReadJsonToList<T>(string jsonFullPath)
	{
		// jsonFullPath = Application.dataPath + "/lzx.json";

		if (!System.IO.File.Exists(jsonFullPath))
		{
			Debug.Log("文件有错或者没有这样的文件：" + jsonFullPath);
			return null;
		}
		string jsons = LoadString(jsonFullPath);
		Debug.Log(jsons);

		if (string.IsNullOrEmpty(jsons))
			return null;

		List<T> objs = JsonMapper.ToObject<List<T>>(jsons);
		return objs;
	}



	/// <summary>
	///  json格式的字符串保存成一个json文件
	/// </summary>
	/// <param name="fileFullPath">Application.dataPath + "/config.json";</param>
	/// <param name="jsonText"></param>
	public static void SaveJson(string fileFullPath, string jsonText)
	{
		//流写入器
		StreamWriter sw;
		//文件信息操作类
		FileInfo info = new FileInfo(fileFullPath);
		//判断路径是否存在
		if (!info.Exists)
		{
			sw = info.CreateText();
		}
		else
		{
			//先删除再创建
			info.Delete();
			sw = info.CreateText();
		}

		sw.WriteLine(jsonText);
		sw.Close();
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="objs"></param>
	/// <param name="key"></param>
	/// <returns></returns>
	public T GetObect<T>(T[] objs,string key)
	{
		T temp = default(T);
		if (objs == null || objs.Length <= 0)
		{
			Debug.LogError("指引配置文件为空！");
			return default(T);
		}
		//foreach (var a in objs)
		//{
		//	if (a.name == key)
		//	{
		//		return a;
		//	}
		//}
		Debug.LogError("配置文件没有这样的key");
		return temp;
	}
	// Update is called once per frame
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

	public void WriteLocal(string text, int offset, string url)
	{
		byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);
		WriteLocal(buffer, offset, url);
	}
	public void WriteLocal(byte[] buffer, int offset, string url)
	{
		//文件流信息
		FileStream fs;
		FileInfo t = new FileInfo(url);
		if (!t.Exists)
		{
			string str = url.Substring(0, url.LastIndexOf("/") + 1);
			if (!Directory.Exists(str))
				Directory.CreateDirectory(str);
			//如果此文件不存在则创建            
		}

		fs = new FileStream(url, FileMode.Create);
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
