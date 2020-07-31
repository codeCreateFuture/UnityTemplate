#define MyDefine

using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


#if (UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
using UnityEngine.SceneManagement;
#endif

public class Precompile : MonoBehaviour {
	public  const int num = 10;
	private string platform = string.Empty;
	// Use this for initialization
	void Start () {
		MyDefine();
	}

	void DebugPlatformMesaage()
	{
	   
#if UNITY_EDITOR
		platform = "hi,大家好,我是在unity编辑模式下";
#elif UNITY_XBOX360
	   platform="hi，大家好,我在XBOX360平台";
#elif UNITY_IPHONE
	   platform="hi，大家好,我是IPHONE平台";
#elif UNITY_ANDROID
	   platform="hi，大家好,我是ANDROID平台";
#elif UNITY_STANDALONE_OSX
	   platform="hi，大家好,我是OSX平台";
#elif UNITY_STANDALONE_WIN
	   platform="hi，大家好,我是Windows平台";
#endif
		Debug.Log("Current Platform:" + platform);
	}

	string ScriptingDefineSymbolsTip = "PlayerSetting/OtherSettings/ScriptingDefineSymbolsTip 设置,使用分号区分开";
	string customMsg = "没有预编译";

	void ScriptingDefineSymbols()
	{
#if CUSTOM_ITF
		customMsg = "我自定义了预编译";
#endif
		Debug.Log(ScriptingDefineSymbolsTip+" "+customMsg);
	}

	/// <summary>
	/// 代码改宏定义
	/// </summary>
	/// <param name="logType"></param>
	public static void SetDefineSymbols(string logType)
	{
		BuildTargetGroup targetGroup = BuildTargetGroup.Android;
		string ori = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);
		string debugType = "Debuger_" + logType;

		List<string> defineSymbols = new List<string>(ori.Split(';'));
		for (int i = 0; i < defineSymbols.Count; ++i)
		{
			if (defineSymbols[i] == debugType)
			{
				Debug.LogFormat("========== debuglog {0}", logType);
				return;
			}
			if (defineSymbols[i].StartsWith("Debuger_"))
			{
				defineSymbols[i] = debugType;
				debugType = null;
				break;
			}
		}
		if (debugType != null)
		{
			defineSymbols.Add(debugType);
		}
		PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, string.Join(";", defineSymbols.ToArray()));
		Debug.LogFormat("========== debuglog {0}", logType);
	}

	[MenuItem("Editor/Define/MyDefine")]
	public static void  MyDefine()
	{
		Debug.Log("#define 定义要放在文件的最开头");
		string myDefine = "没有定义MyDefine";
#if MyDefine
		myDefine = "有定义MyDefine";
#endif
		Debug.Log(myDefine);
	}
	}
