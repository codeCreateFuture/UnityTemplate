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
		Debug.Log("-------��ʼ��ײ------------");
		Debug.Log(coll.gameObject.name);
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		Debug.Log("------������ײ-------------");
		Debug.Log(coll.gameObject.name);
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		Debug.Log("------������ײ-------------");
		Debug.Log(coll.gameObject.name);
	}


	// ��ʼ�Ӵ�
	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("��ʼ�Ӵ�");
		Debug.Log(collider.name);
	}

	// �Ӵ�����
	void OnTriggerExit2D(Collider2D collider)
	{
		Debug.Log("�Ӵ�����");
		Debug.Log(collider.name);
	}

	// �Ӵ�������
	void OnTriggerStay2D(Collider2D collider)
	{
		Debug.Log("�Ӵ�������");
		Debug.Log(collider.name);
	}
}
