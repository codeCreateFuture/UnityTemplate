using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class TestTwo : MonoBehaviour {
	
	    // Use this for initialization
	
	
	    public int number = 10;
	
	
	
		void Start () {
	        EventListener.registerEvent("property", Ondata);
	        EventListener.registerEvent("notProperty", OnNotProperty);
	    }
	
	    private void OnNotProperty(object target)
	    {
	        Debug.Log("not property");
	    }
	
	    private void Ondata(object target)
	    {
	        number++;
	        Debug.Log(number);
	    }
	
	    // Update is called once per frame
	    void Update () {
			
		}
	}

