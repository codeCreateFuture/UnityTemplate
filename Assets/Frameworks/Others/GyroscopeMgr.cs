using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}

	void Update()
	{

		//use quaternion to store information for view rotation by receiving data from the gyro
		Quaternion rotationalFix = new Quaternion(Input.gyro.attitude.x,        // left right
												Input.gyro.attitude.y,          // up down
												-Input.gyro.attitude.z,         // forward back
												-Input.gyro.attitude.w);        // rotational space in 360 degrees

		//set the local rotation of the camera to the Quaternion value
		this.transform.localRotation = rotationalFix;



	}
}
