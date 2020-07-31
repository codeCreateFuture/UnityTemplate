using LixiUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    LixiUtility.Debuger.EnableSave = true;
		this.LogError("enableSave :" + Debuger.EnableSave);
		this.Log("DebugTest");

		LzxDebug.Log("click object name is " + gameObject.name);


	}

	// Update is called once per frame
	void Update () {
		
	}
}
