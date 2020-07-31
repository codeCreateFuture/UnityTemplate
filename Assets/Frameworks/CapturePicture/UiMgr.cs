using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMgr : MonoBehaviour {

	public RawImage img;
	public string url;

	public Texture2D tex;
	public Camera camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			
			//CaptureMgr.Instance.CaptureByRect(new Rect(50, 50, 1000, 1000), System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"), OnScussess);
			//CaptureMgr.Instance.CaptureByCamera(camera,new Rect(0, 0, 1024, 768), System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"), OnScussess);
			CaptureImgMgr.Instance.CaptureByCameraAndLogo(Camera.main,new Rect(0, 0, 1024, 768), System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"), null, OnScussess2,"png");
			//CaptureImgMgr.Instance.CaptureByCameraAndLogo(Camera.main,new Rect(0, 0, 1024, 768), System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"), tex, OnScussess,"png");
		}
		if(Input.GetMouseButtonDown(1))
		{
			CaptureImgMgr.Instance.CaptureByUnity(System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"), OnScussess,"png");
			
		}
		if (Input.GetMouseButtonDown(2))
		{
			// CaptureMgr.Instance.CaptureByUnity(System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"), OnScussess, "jpg");
			//CaptureImgMgr.Instance.CaptureByRect(new Rect(0, 0, 1024, 768),System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"), OnScussess, "png");
			CaptureImgMgr.Instance.CaptureByCamera(camera,new Rect(0, 0, 1920, 1080), System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"), OnScussess, "png");
			Debug.Log("2");

		}

		
	}

	void OnScussess(string picName)
	{
		Debug.Log(picName);
		StartCoroutine(Load(picName));
	}


	void OnScussess2(string picName)
	{

	//	CaptureImgMgr.Instance.LoadTeureUIPanelPath(img, picName);
	}


	IEnumerator Load(string url)
	{
		yield return null;
		WWW www = new WWW(url);
		yield return www;
		img.texture = www.texture;
		www.Dispose();
	}


	public void OnClick()
	{
		StartCoroutine(Load(url));
	}
}
