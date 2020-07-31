using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Net;
using System.IO;

public class HttpDownloadTest : MonoBehaviour {

	bool isDone;
	Slider slider;
	public Text text;
	float progress = 0f;


	void Awake()
	{
		Debug.Log(Application.persistentDataPath);
		slider = GameObject.Find("Slider").GetComponent<Slider>();
		//text = GameObject.Find("Text").GetComponent<Text>();
	}

	HttpDownLoad http;
	public string available2 = @"H:/BaiduYunDownload/6.1-6.8/1.mp4";
	public string available = @"http://www.billibear.cn/beargame/LocalRepository/Billibear/ATogether/Draw2Vehicle/d2_policecar55/d2_policecar55.assetbundle.pwd";
	 public	string url = @"http://www.billibear.cn/Lixi/billiAR.mp4";
	public string savePath;

	
	void Start () {
		savePath = Application.streamingAssetsPath;
		http = new HttpDownLoad();
		
		http.DownLoad(url, savePath, OnFinish);
		Debug.Log(url.Substring(url.LastIndexOf("/") + 1));

	}

	void OnDisable()
	{
		print ("OnDisable");
		http.Close();
	}

	void OnFinish()
	{
		
		Debug.Log("download finish !");
		isDone = true;
	}

	void Update()
	{

		slider.value = http.progress;
		text.text = "资源加载中" + (slider.value * 100).ToString("0.00") + "%"; 
		if(isDone)
		{
		
			isDone = false;
			string url = @"file://" + Application.streamingAssetsPath + "/test";
			//StartCoroutine(LoadScene(url));
		}
	}

	IEnumerator LoadScene(string url)
	{
		WWW www = new WWW(url);
		yield return www;
		AssetBundle ab = www.assetBundle;
		SceneManager.LoadScene("Demo2_towers");

	}

}
