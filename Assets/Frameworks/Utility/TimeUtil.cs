using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUtil : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// ����ʱ
	/// </summary>
	/// <param name="time"></param>
	/// <returns></returns>
	public IEnumerator countDown(float time)
	{
		while (time > 0)
		{
			yield return new WaitForSeconds(1);
			print(time);
			time--;
		}
	}
}
