//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2015 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Simple script that shows how to download a remote texture and assign it to be used by a UITexture.
/// </summary>


public class DownloadTexture : MonoBehaviour
{

		//  mFileName=mFileName.Replace('/','\\');     //保存的路径要转换成加载路径
		//downloadTexture.url = @"file://"+mFileName;  //加上file://前缀才可以通过www加载
		//downloadTexture.LoadTexture();
	
	public string url = "http://www.yourwebsite.com/logo.png";
	public string localUrl= @"file://C:\Users\Administrator\Desktop\md5\one.jpg";
	public bool pixelPerfect = true;

	
	private void Start()
	{
	
	}

	IEnumerator Load ()
	{
		yield return null;
		WWW www = new WWW(url);
		yield return www;
		

			 GetComponent<RawImage>().texture=www.texture;
		
			//if (pixelPerfect) ut.MakePixelPerfect();
			//if (pixelPerfect) ut.MakePixelPerfect();
		
		www.Dispose();
	}

	public void  LoadTexture()
	{
		StartCoroutine(Load());
	}

}
