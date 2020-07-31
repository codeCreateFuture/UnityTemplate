using UnityEngine;
using System.Collections;
using Assets;
using System.Reflection;
using UnityHelper;
using System;


interface PeoPle
{
	void Eat();
}
class Man:PeoPle
{
   

	public void Eat()
	{
		Debug.Log("男人");
	}
}

class Women : PeoPle
{


	public void Eat()
	{
		Debug.Log("女人");
	}
}

public class Main : MonoBehaviour
{
	string name = "lix";
	public GameObject obj;

	Main t;

	// Use this for initialization
	void Start () {

		Debug.Log(ReflectionMgr.GetAssemblyName());

		PeoPle ren =(PeoPle) ReflectionMgr.CreateCSharpObjectNoParas("Man");
		ren.Eat();

		ren= (PeoPle)ReflectionMgr.CreateCSharpObjectNoParas("Women");
		ren.Eat();

		//LongPressTest lixi = ReflectionMgr.CreateUnityObject("LongPressTest") as LongPressTest;
		//Debug.Log(lixi.gameObject.name);
	//	Debug.Log(lixi == null);

		t = this;
		
		MessageHandler.Instance.BuildMessage("Myfunction", MyFunction);
		ClassA clsa = new ClassA();

		GameObjectCreator.CreateChild(obj);

		Type cc = t.GetType();

		
		Debug.Log(cc.Name);
		Debug.Log(cc.FullName);
		Debug.Log(cc.Assembly);
		Debug.Log(cc.Namespace);

		Debug.Log(typeof(Main).Assembly.GetName().Name);
		Debug.Log(Assembly.GetExecutingAssembly().GetName().Name);
		Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

		


	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			MessageHandler.Instance.Execute("Myfunction");
		}
	}

	void MyFunction()
	{
		Debug.Log("MyFunction");
	}
}
