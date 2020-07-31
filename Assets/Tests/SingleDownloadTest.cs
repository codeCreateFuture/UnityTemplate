using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	public class SingleDownloadTest : MonoBehaviour {
	
		public Slider slider;
		public Text size;
		public Text process;
		LixiUtility.SingleDownload http;
	
		float fileSize = 0;
		float downedSize = 0;
		// Use this for initialization
		void Start () {
			 http = new LixiUtility.SingleDownload();
			http.DownLoad("http://m.billibear.cn/Lixi/test.mp4", Application.streamingAssetsPath, "test.mp4", Finish,DownUpdate);
		}
	
		private void DownUpdate(float arg1, float arg2)
		{
			fileSize = arg2;
		   // Debug.Log(arg2)
			downedSize = arg1;
		}
	
		private void Finish()
		{
			
		}
	
		// Update is called once per frame
		void Update () {
			if (http == null) return;
			slider.value = http.progress;
			process.text = (http.progress*100).ToString("f2")+"%";
			size.text = downedSize.ToString()+"m"+"/"+ fileSize.ToString()+"m";
	
	
		}
	}

