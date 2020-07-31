using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyUiMgrStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EasyUiMgr.Instance.PushPanel(UIPanelPath.EasyUiMgrTest);

	  
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(2))
		{
			EasyUiMgr.Instance.PopToLastPanel();
			LixiMgr.TimeMgr.Instance.AddTaskOnce(1, Finish);
		}
		if (Input.GetMouseButtonDown(1))
		{

			LixiMgr.TimeMgr.Instance.RemoveTask(Finish);
			
		}
	}

	private void Finish()
	{
		Debug.Log("finish");
	}
}
