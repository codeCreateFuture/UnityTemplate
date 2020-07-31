using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class LixiTest : MonoBehaviour {


	UnityAction action;

	Action sysAction;

	Action<string> actionStr;

	// Use this for initialization
	void Start () {

		Debug.Log(AssetConfigsMgr.GetSettingsAssetConfig().appName);
		Debug.Log(AssetConfigsMgr.GetSettingsAssetConfigByResources().isPlayBgMusic);
		Debug.Log(AssetConfigsMgr.GetAssetConfig<SettingsAssetConfig>("SettingsAssetConfig").isPlayBgMusic);

		//Debug.Log(SecurityData.EncryptStr("Lixi"));
		//Debug.Log(SecurityData.DecryptStr("＆ＥＺＥ"));

		//int num = 5;
		//byte by = 0;

		//byte[] datas = Encoding.UTF8.GetBytes("Lixi");
		//foreach( var b in datas)
		//{
		//	Debug.Log(b);

		//}
		//Debug.Log(datas.Length);

		////Debug.Log(CheckInput.IsEnglishCharacter("了大幅度"));
		////Debug.Log(CheckInput.IsEnglishCharacter("fs大df"));
		////Debug.Log(CheckInput.IsEnglishCharacter("fsdf"));
		////Debug.Log(CheckInput.IsEnglishCharacter("了大f幅度"));
		////Debug.Log(CheckInput.IsEnglishCharacter("906188了大幅度006qq.cm"));

		////TimerManager.Instance.AddTimer("lixi", 5, OnFinish);
		//// GameObject obj = new GameObject("Sound", typeof(TimeUtil));

		//// StaticDefine.bgSoundVolume = 0.8f;

		//// Debug.Log(Application.persistentDataPath);
		//// UguiEventListener.Get(gameObject, "Lixi").onPointerClickData += OnClick;

		//actionStr = (str) => { Debug.Log(str); };

		//action = () => { Debug.Log("action"); };
		////sysAction = () => { Debug.Log("sysAction"); };

		//action.InvokeGracefully();
		////sysAction.Invoke();

		//actionStr.InvokeGracefully<string>("fddddddddddd");





		//Debug.Log(PathUtil.GetAppRootPath());
		//Debug.Log(PathUtil.GetIniFilePath());

		//////if(!File.Exists(PathUtil.GetIniFilePath()))
		////

		////}

		//Helper.xmlHelper.CreateXmlDocument(@"D:/" + "menu.xml","book", "1.0","utf-8", "no");

		// Debug.Log(  Helper.xmlHelper.AddNode(@"D:/" + "menu.xml", @"book/First", "Lixi", "李镇西"));

	}

	private void OnClick(GameObject go, object data)
	{
		Debug.Log(data.ToString());
	}

	private void OnFinish()
	{
		Debug.Log("onfinish");
	}

	int number = 0;
  

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(2))
		{
			//TextPopHint.Instance.ShowHint("你是谁：" + number++);
			//TimerManager.Instance.AddTimer("lixi", 5, OnFinish);
			//LixiMgr.TimeMgr.Instance.AddTaskOnce(3, OnFinish);


			////CalculatorTime.Instance.Show(5, OnFinish);
			//WwwItem item = new WwwItem(Application.streamingAssetsPath + "/test.mp4");
			//WwwTools.Instance.AddTask(item);
			//FileUtil.CreateEmpthFile(@"G:\Lixi.txt");
			transform.SetText("LIix");
			EventListener.dispatchEvent("property", null);
			EventListener.dispatchEvent("notProperty", null);
			//Debug.Log( INISetting.GetString("gateIpOrDN", INISetting.SectionName.gateIpOrDN));
		}
	}
}
