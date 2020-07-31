using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuiltOnClick : MonoBehaviour {

	public Button btnCancle;
	// Use this for initialization
	void Start()
	{
	   
		btnCancle.onClick.AddListener(() => Debug.Log("lambda no {}"));
		btnCancle.onClick.AddListener(() => { Debug.Log("lambda"); });
		btnCancle.onClick.AddListener(OnClick);
		btnCancle.onClick.AddListener(delegate () { Debug.Log("delegate"); });


        UguiEventListener.Get(btnCancle.gameObject).onPointerClick += (ni) => {
            Debug.Log(ni.name);
        };

        UguiEventListener.Get(btnCancle.gameObject).onPointerClick += (GameObject go) =>
         {
             Debug.Log(go.name);
         };




    }

    void ClickGo(GameObject go)
    {

    }

	void OnClick()
	{
		Debug.Log("onClick");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
