using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EditorUtil : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0))
		{
		  

			MathUtil.IsHitByPercent(-10);
			MathUtil.IsHitByPercent(1000);
		}
	}

	[MenuItem("Tools/EditorUtil/停止运行")]
	public static void StopApplication()
	{
		UnityEditor.EditorApplication.isPlaying = false;
	}

	public float angle = 50f;
	public  float radius = 10f;
	/// <summary>
	/// 绘制扇形
	/// </summary>
	/// <param name="startPos">扇形中心点，起始位置</param>
	/// <param name="gizType"></param>
	[DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
	static void DrawGi(EditorUtil startPos, GizmoType gizType)
	{
		Handles.color = new Color(1, 1, 1, 0.2f);
		var newStart = Quaternion.Euler(new Vector3(0, -startPos.angle / 2, 0)) * startPos.transform.forward;

		Handles.DrawSolidArc(startPos.transform.position, startPos.transform.up, newStart, startPos.angle, startPos.radius);
	}


	[MenuItem("EditorTools/打开持久化文件")]
	public static void OpenPersistentDataPathFile()
	{
		Application.OpenURL("file:///" + Application.persistentDataPath);

		
		// Application.OpenURL(Application.persistentDataPath);  //两个结果一样
		Debug.Log(Application.persistentDataPath);
	}

	[MenuItem("EditorTools/打开资源文件")]
	public static void OpenDataPathFile()
	{
		// Application.OpenURL("file:///" + Application.persistentDataPath);
		Application.OpenURL(Application.dataPath);  //两个结果一样
		Debug.Log(Application.dataPath);
	}

	[MenuItem("EditorTools/打开StreamingAssets文件")]
	public static void OpenStreamingAssetsPathFile()
	{
		// Application.OpenURL("file:///" + Application.persistentDataPath);
		Application.OpenURL(Application.streamingAssetsPath);  //两个结果一样
		Debug.Log(Application.streamingAssetsPath);
	}

	[RuntimeInitializeOnLoadMethod]
	static void RuntimeInitOnLoadMethod()
	{
		Debug.Log("RuntimeInitializeOnLoadMethod :"+"启动编辑器！");
	}
}
