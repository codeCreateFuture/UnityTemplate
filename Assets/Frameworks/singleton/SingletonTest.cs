﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTest : MonoSingleton<SingletonTest> {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Test()
	{
		Debug.Log("singleTest");
	}
}
