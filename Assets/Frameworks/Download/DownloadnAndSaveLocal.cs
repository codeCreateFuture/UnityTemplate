using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class DownloadnAndSaveLocal : MonoBehaviour {


	//网络地址  
	private string webUrl;

	//下载本地存储地址  
	private string localUrl;


	//文件  
	FileInfo file;


	public Text downText;

	void Awake()
	{
		Debug.Log(Application.persistentDataPath);
		webUrl = "http://www.billibear.cn/Lixi/billiAR.mp4";
		localUrl = Application.persistentDataPath + "/billiAR.mp4";
		//初始化文件  
		file = new FileInfo(localUrl);
	}

	void Start()
	{
		//Handheld.PlayFullScreenMovie(Url_movie, Color.black, FullScreenMovieControlMode.Hidden);    
		//判断文件是否下载过  
		if (!file.Exists)
		{
			//StartCoroutine(down(webUrl));
			StartCoroutine(DownloadAndSave(webUrl, "billiAR.mp4", DowningHandle));
		}
		else
		{
			//文件存在 直接播放视频  
			print("文件存在 直接播放视频");
		}

	}
	// Update is called once per frame
	void Update () {
		
	}



	#region 第一种下载方法
	void DowningHandle(bool finish,string str)
	{
		downText.text = str;

	}

	/// <summary>  
	/// 下载并保存资源到本地  
	/// </summary>  
	/// <param name="url"></param>  
	/// <param name="name"></param>  
	/// <returns></returns>  
	public static IEnumerator DownloadAndSave(string url, string name, Action<bool, string> Finish = null)
	{
		url = Uri.EscapeUriString(url);
		string Loading = string.Empty;
		bool b = false;
		WWW www = new WWW(url);
		if (www.error != null)
		{
			print("error:" + www.error);
		}
		while (!www.isDone)
		{
			Loading = ( ( (int)( www.progress * 100 ) ) % 100 ) + "%";
			Debug.Log(Loading);
			if (Finish != null)
			{
				Finish(b, Loading);
			}
			yield return 1;
		}
		if (www.isDone)
		{
			Loading = "100%";
			byte[] bytes = www.bytes;
			b = SaveAssets(Application.persistentDataPath, name, bytes);
			if (Finish != null)
			{
				Finish(b, Loading);
			}
		}
	}


	/// <summary>  
	/// 保存资源到本地  
	/// </summary>  
	/// <param name="path"></param>  
	/// <param name="name"></param>  
	/// <param name="info"></param>  
	/// <param name="length"></param>  
	public static bool SaveAssets(string path, string name, byte[] bytes)
	{
		Stream sw;
		FileInfo t = new FileInfo(path + "//" + name);
		if (!t.Exists)
		{
			try
			{
				sw = t.Create();
				sw.Write(bytes, 0, bytes.Length);
				sw.Close();
				sw.Dispose();
				return true;
			}
			catch
			{
				return false;
			}
		}
		else
		{
			return true;
		}
	}

	#endregion


	#region 第二种方法


	string LoadPro;
	IEnumerator down(string url)
	{
		//加载www  
		WWW _www = new WWW(url);
		


		while (!_www.isDone)
		{
			LoadPro = ( ( (int)( _www.progress * 100 ) ) % 100 ) + "%";
			Debug.Log("进度：" + LoadPro);

			
			yield return 1;
		}


		yield return _www;

		if (_www.isDone)
		{
			print("下载完成");
		
			//获取www的字节  
			byte[] bytes = _www.bytes;
			creat(bytes);
		}

	}
	/// <summary>
	/// 删除
	/// </summary>
	public void DeleteFile(string name)
	{
		if (File.Exists(name))
		{
			File.Delete(name);
		  
		}


		if (File.Exists(name))
		{

		   
		}
		else
		{
		  
		}


	}

	//文件的流写入  
	void creat(byte[] bytes)
	{
		Stream str;
		//文件创建  
		str = file.Create();
		//文件写入  
		str.Write(bytes, 0, bytes.Length);
		//关闭并销毁流  
		str.Close();
		str.Dispose();

		//todo 下载完成后需要的操作，显示 
	}
	#endregion
}
