using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDispatcherTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventDispatcher.AddEventListener<int>("lzx", OnLzx);
		EventDispatcher.AddEventListener<int, string>("student", OnStudent);
		EventDispatcher.AddEventListener<int, string>("student", OnTeacher);
	}

	private void OnTeacher(int arg1, string arg2)
	{
		Debug.Log(string.Format("Teacher age;{0},Teacher name :{1}", arg1,arg2));

	}

	private void OnStudent(int arg1, string arg2)
	{
		Debug.Log(string.Format("age;{0},name :{1}",arg1,arg2));

	}

	private void OnLzx(int obj)
	{
		Debug.Log(obj);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(1))
		{

			EventDispatcher.RemoveEventListener<int, string>("student",OnStudent);


		}
	}

	public void Onclick()
	{
		EventDispatcher.TriggerEvent("student", 78,"lzx");
	}
}
