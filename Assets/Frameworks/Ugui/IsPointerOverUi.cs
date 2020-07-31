using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IsPointerOverUi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
		{
#if UNITY_ANDROID || UNITY_IPHONE
			if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#else
			if (EventSystem.current.IsPointerOverGameObject())
#endif

				Debug.Log("当前触摸在UI上");
			else
				Debug.Log("当前没有触摸在UI上");
		}
	}

}
