using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

	public class LongPressTest : MonoBehaviour {
		public GameObject tip;
		// Use this for initialization
		void Start () {
			//UguiEventListener.Get(gameObject).onLongPress += OnLongPress;
			//UguiEventListener.Get(gameObject).onLongPressUp += OnLongPressUp;
	
			UGUIListener.Get(gameObject).onPointerClick += OnPointerClick;
			UGUIListener.Get(gameObject).onPointerEnter += LongPressTest_onPointerEnter;
			UGUIListener.Get(gameObject).onPointerUp += LongPressTest_onPointerUp;
			UGUIListener.Get(gameObject).onPointerExit += LongPressTest_onPointerExit;
			UGUIListener.Get(gameObject).onPointerDown += LongPressTest_onPointerDown;
	
			//UGUIListener.Get(gameObject).onLongPress += OnLongPress;
			//UGUIListener.Get(gameObject).onLongPressData += OnLongPressData;
	
			//UGUIListener.Get(gameObject).onLongPressUp += LongPressTest_onLongPressUp;
	
			//UGUIListener.Get(gameObject).onLongPressUpData += LongPressTest_onLongPressUpData; 
	
			tip.SetActive(false);
	
		
	
	
		}
	
		void Test(int i,string str)
		{
			Debug.Log(i + " " + str);
		}
	
		void Test2(int i, string str)
		{
			Debug.Log(i+3 + " 2" + str);
		}
	
		private void LongPressTest_onLongPressUpData(GameObject go, PointerEventData eventData)
		{
			Debug.Log("longPress up data    "+eventData.pressPosition);
		}
	
		private void LongPressTest_onLongPressUp(GameObject go)
		{
			Debug.Log("longPress up");
	
		}
	
		private void OnPointerClick(GameObject go)
		{
			Debug.Log("OnPointerClick");
		}
	
		private void LongPressTest_onPointerExit(GameObject go)
		{
			Debug.Log("onPointerExit");
			tip.SetActive(false);
	
	
		}
	
		private void LongPressTest_onPointerEnter(GameObject go)
		{
			Debug.Log("onPointer Enter");
			tip.SetActive(true);
	
	
		}
	
		private void LongPressTest_onPointerUp(GameObject go)
		{
			Debug.Log("onPointerUp");
		}
	
		private void LongPressTest_onPointerDown(GameObject go)
		{
			Debug.Log("pointer down");
		}
	
		private void LongPressTest_onPointerClick(GameObject go)
		{
			Debug.Log("long press");
		}
	
		private void OnPointEnter(GameObject go)
		{
			Debug.Log("��ͣ enter");
		}
	
		private void OnLongPressData(GameObject go, PointerEventData eventData)
		{
			Debug.Log("long press data" + eventData.position);
		}
		  
	
		private void OnPointerDownData(GameObject go, PointerEventData eventData)
		{
			Debug.Log("OnPointerClick"+ eventData.position);
		}
	
		
	
		private void OnLongPressUp(GameObject go)
		{
			Debug.Log("���� ̧��");
	
		}
	
		private void OnLongPress(GameObject go)
		{
			Debug.Log("���� long press");
		}
	
		// Update is called once per frame
		void Update () {
			
		}
	}

