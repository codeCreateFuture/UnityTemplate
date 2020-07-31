#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.

using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;

public class ScreenshotManager  : MonoBehaviour{
	
	public static event Action ScreenshotFinishedSaving;
	public static event Action ImageFinishedSaving;
	
	#if UNITY_IPHONE
	
	[DllImport("__Internal")]
	private static extern bool saveToGallery( string path );
	
	#endif
	
	public static IEnumerator Save(string filepath, string albumName = "Billibear", bool callback = false)
	{
		LzxDebug.Log("save1");
		bool photoSaved = false;
		
		
		
		#if UNITY_IPHONE
		
			if(Application.platform == RuntimePlatform.IPhonePlayer) 
			{
				LzxDebug.Log("iOS platform detected");
				
				
		
				//Application.CaptureScreenshot(screenshotFilename);
				
				while(!photoSaved) 
				{/////
						photoSaved = saveToGallery( filepath );
					
					yield return new WaitForSeconds(.5f);
				}
			
				//UnityEngine.iOS.Device.SetNoBackupFlag( iosPath );
				UnityEngine.iOS.Device.SetNoBackupFlag(filepath);
			
			} else {
			
				//Application.CaptureScreenshot(screenshotFilename);
			
			}
			
#elif UNITY_ANDROID

		if (Application.platform == RuntimePlatform.Android) 
			{
				LzxDebug.Log("Android platform detected");
				string path = Application.persistentDataPath + filepath;
				string pathonly = Path.GetDirectoryName(path);
				Directory.CreateDirectory(pathonly);
			   // Application.CaptureScreenshot(filepath);
				
				AndroidJavaClass obj = new AndroidJavaClass("com.ryanwebb.androidscreenshot.MainActivity");
				
				while(!photoSaved) 
				{
					photoSaved = obj.CallStatic<bool>("scanMedia", path);
				
					yield return new WaitForSeconds(.5f);
				}
		
			} else {

				//Application.CaptureScreenshot(filepath);
		
			}
		#else
			
			while(!photoSaved) 
			{
				yield return new WaitForSeconds(.5f);
		
				LzxDebug.Log("Screenshots only available in iOS/Android mode!");
			
				photoSaved = true;
			}
		
		#endif
		
		if(callback)
			ScreenshotFinishedSaving();
	}
	
	
	public static IEnumerator SaveExisting(string filePath, bool callback = false)
	{
		bool photoSaved = false;
		
		LzxDebug.Log("Save existing file to gallery " + filePath);

		#if UNITY_IPHONE
		
			if(Application.platform == RuntimePlatform.IPhonePlayer) 
			{
				LzxDebug.Log("iOS platform detected");
				
				while(!photoSaved) 
				{
					photoSaved = saveToGallery( filePath );
					
					yield return new WaitForSeconds(.5f);
				}
			
				UnityEngine.iOS.Device.SetNoBackupFlag( filePath );
			}
			
		#elif UNITY_ANDROID	
				
			if(Application.platform == RuntimePlatform.Android) 
			{
				LzxDebug.Log("Android platform detected");

				AndroidJavaClass obj = new AndroidJavaClass("com.ryanwebb.androidscreenshot.MainActivity");
				
				while(!photoSaved) 
				{
					photoSaved = obj.CallStatic<bool>("scanMedia", filePath);
					yield return new WaitForSeconds(.5f);
				}
			
			}
		
		#else
			
			while(!photoSaved) 
			{
				yield return new WaitForSeconds(.5f);
		
				LzxDebug.Log("Save existing file only available in iOS/Android mode!");

				photoSaved = true;
			}
		
		#endif
		
		if(callback)
			ImageFinishedSaving();
	}
	
	public static int ScreenShotNumber 
	{
		set { PlayerPrefs.SetInt("screenShotNumber", value); }
	
		get { return PlayerPrefs.GetInt("screenShotNumber"); }
	}
 
	public static Texture2D CaptureCamera(Camera camera, string filename)
	{
		RenderTexture rt = new RenderTexture((int)Screen.width, (int)Screen.height, 0);
		// 临时设置相关相机的targetTexture为rt, 并手动渲染相关相机  
		camera.targetTexture = rt;
		camera.Render();
		// 激活这个rt, 并从中中读取像素。  
		RenderTexture.active = rt;
		Texture2D screenShot = new Texture2D((int)Screen.width, (int)Screen.height, TextureFormat.RGB24, false);
		Rect rect = new Rect(0.0f,0.0f,Screen.width,Screen.height);
		screenShot.ReadPixels(rect, 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素  
		screenShot.Apply();
		camera.targetTexture = null;
		RenderTexture.active = null;
		GameObject.Destroy(rt);
		// 最后将这些纹理数据，成一个png图片文件  
		byte[] bytes = screenShot.EncodeToPNG();
		System.IO.File.WriteAllBytes(filename, bytes);
		LzxDebug.Log(string.Format("截屏了一张照片: {0}", filename));
		return screenShot;
	}
	public static Texture2D CaptureCamera(string filename)
	{
		Texture2D screenShot = new Texture2D((int)Screen.width - 10, (int)Screen.height - 10, TextureFormat.RGB24, false);
		LzxDebug.Log(Screen.height + "  " + Screen.height);
		Rect rect = new Rect(5.0f, 5.0f, Screen.width, Screen.height);
		screenShot.ReadPixels(rect, 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素
		screenShot.Apply();
		TextureUtility.ScalePoint(screenShot, Screen.width, Screen.height);
		byte[] bytes = screenShot.EncodeToJPG();
		LzxDebug.Log(" " + screenShot.width + " " + screenShot.height);
		System.IO.File.WriteAllBytes(filename, bytes);
		LzxDebug.Log(string.Format("截屏了一张照片: {0}", filename));

		return screenShot;
	} 

}
