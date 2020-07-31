using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColloderOrTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log("-------开始碰撞------------");
		Debug.Log(coll.gameObject.name);
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		Debug.Log("------正在碰撞-------------");
		Debug.Log(coll.gameObject.name);
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		Debug.Log("------结束碰撞-------------");
		Debug.Log(coll.gameObject.name);
	}


	// 开始接触
	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("开始接触");
		Debug.Log(collider.name);
	}

	// 接触结束
	void OnTriggerExit2D(Collider2D collider)
	{
		Debug.Log("接触结束");
		Debug.Log(collider.name);
	}

	// 接触持续中
	void OnTriggerStay2D(Collider2D collider)
	{
		Debug.Log("接触持续中");
		Debug.Log(collider.name);
	}
}
