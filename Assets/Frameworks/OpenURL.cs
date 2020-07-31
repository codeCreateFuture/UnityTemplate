using UnityEngine;
using System.Collections;

public class OpenURL : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	/// <summary>
				/// 用射线检查单击的物体
				/// </summary>
				if(Input.GetMouseButtonDown(0))
				{
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线
						RaycastHit hitInfo;
						if(Physics.Raycast(ray,out hitInfo))
						{
								//Debug.DrawLine(ray.origin,hitInfo.point);//划出射线，只有在scene视图中才能看到
								GameObject gameObj = hitInfo.collider.gameObject;
								LzxDebug.Log("click object name is " + gameObj.name);
								// 打开面板，TweenPosition执行
								if (gameObj.name == "ShiPin01")
								{
								
										//Application.OpenURL("http://www.163.com/");
										Application.ExternalEval("window.open('yksp_view.html','newwindow','height=470, width=630, toolbar =no, menubar=no, scrollbars=no, resizable=no, location=no, status=no');"); 
										
								}else if(gameObj.name == "ShiPin02"){

										// 函数名， 参数
										Application.ExternalCall("openwin", "yksp_view.html");
								}
						}
				}
	}
}
