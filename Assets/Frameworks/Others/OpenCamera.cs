using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCamera : MonoBehaviour {
	private WebCamTexture camTexture;

	public GameObject cameraPlane;

	// Use this for initialization
	void Start () {
		camTexture = new WebCamTexture();
		cameraPlane.GetComponent<MeshRenderer>().material.mainTexture = camTexture;
		camTexture.Play();

	}

	// Update is called once per frame
	void Update () {
		
	}
}
