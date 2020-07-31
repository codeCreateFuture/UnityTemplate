
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


//Application.persistentDataPath=C:/Users/Administrator/AppData/LocalLow/DefaultCompany/UnityTemplate
//public string httpUrl = "http://www.yourwebsite.com/logo.png";
//public string localUrl = @"file://C:\Users\Administrator\Desktop\md5\one.jpg";

/*

string filepath = Application.dataPath + "/StreamingAssets" + "/my.xml";
#elif UNITY_IPHONE
string filepath = Application.dataPath + "/Raw" + "/my.xml";
#elif UNITY_ANDROID
string filepath = "jar:file://" + Application.dataPath + "!/assets/" + "/my.xml;
#endif

*/


public class PathTools
	{
	


		//  mFileName=mFileName.Replace('/','\\');     //保存的路径要转换成加载路径
		//downloadTexture.url = @"file://"+mFileName;  //加上file://前缀才可以通过www加载


		/* 路径常量 */
		public const string AB_RESOURCES = "AB_Res";

		/* 路径方法 */
		/// <summary>
		/// 得到AB资源的输入目录
		/// </summary>
		/// <returns></returns>
		public static string GetABResourcesPath()
		{
			return Application.dataPath + "/"+ AB_RESOURCES;
		}

		/// <summary>
		/// 获取AB输出路径
		/// 算法：
		///     1： 平台(PC/移动端)路径。
		///     2： 平台的名称
		/// </summary>
		public static string GetABOutPath()
		{
			return GetPlatformPath() + "/" + GetPlatformName();
		}

		/// <summary>
		/// 获取平台的路径
		/// </summary>
		/// <returns></returns>
		private static string GetPlatformPath()
		{
			string strReturnPlatformPath = string.Empty;


			switch (Application.platform)
			{
				case RuntimePlatform.WindowsPlayer:
				case RuntimePlatform.WindowsEditor:
					strReturnPlatformPath = Application.streamingAssetsPath;
					break;
				case RuntimePlatform.IPhonePlayer:
				case RuntimePlatform.Android:
					strReturnPlatformPath = Application.persistentDataPath;
					break;      
				default:
					break;
			}

			return strReturnPlatformPath;
		}

		/// <summary>
		/// 获取平台的名称
		/// </summary>
		/// <returns></returns>
		public static string GetPlatformName()
		{
			string strReturnPlatformName = string.Empty;

			switch (Application.platform)
			{
				case RuntimePlatform.WindowsPlayer:
				case RuntimePlatform.WindowsEditor:
					strReturnPlatformName = "Windows";
					break;
				case RuntimePlatform.IPhonePlayer:
					strReturnPlatformName = "Iphone";
					break;
				case RuntimePlatform.Android:
					strReturnPlatformName = "Android";
					break;
				default:
					break;
			}

			return strReturnPlatformName;
		}

		//  mFileName=mFileName.Replace('/','\\');     //保存的路径要转换成加载路径
		//downloadTexture.url = @"file://"+mFileName;  //加上file://前缀才可以通过www加载
		public static string LocalFilePathToLoadFilePath(string localFilePath)
		{
			string path = string.Empty ;
			path= localFilePath.Replace('/', '\\');
			//path= AddPrefix(path,"file://");  //这样也行
			path= AddPrefix(path,"file:///");
		return path;
		}
		//downloadTexture.url = @"file://"+mFileName;  //加上file://前缀才可以通过www加载
		public static string AddPrefix(string oldName, string prefix)
		{
			
			return ( prefix + oldName );
		}

		/// <summary>
		/// 获取WWW协议下载（AB包）路径
		/// </summary>
		/// <returns></returns>
		public static string GetWWWPath()
		{
			//返回路径字符串
			string strReturnWWWPath = string.Empty;

			switch (Application.platform)
			{
				//Windows 主平台
				case RuntimePlatform.WindowsPlayer:
				case RuntimePlatform.WindowsEditor:
					strReturnWWWPath = "file://" + GetABOutPath();
					break;
				//Android 平台
				case RuntimePlatform.Android:
					strReturnWWWPath = "jar:file://" + GetABOutPath();
					break;
				//IPhone平台
				case RuntimePlatform.IPhonePlayer:
					strReturnWWWPath = GetABOutPath()+"/Raw/";
					break;
				default:
					break;
			}

			return strReturnWWWPath;
		}

	
	//string fullName = Application.persistentDataPath + "/" + folder + "/";

	/// <summary>
	/// 在某路径下创建文件夹
	/// </summary>
	/// <param name="where">路径</param>
	/// <param name="folder">文件夹</param>
	public static void CreateFolder(string path, string folder)
	{
		string fullName = path+ "/" + folder + "/";
		try
		{
			bool flag = !Directory.Exists(fullName);
			if (flag)
			{
				Directory.CreateDirectory(fullName);
			}
		}
		catch (Exception ex2)
		{
			Debug.Log("create folder failure");
			return;
		}
	}

	


}



