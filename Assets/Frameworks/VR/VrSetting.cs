using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
public class VrSetting : MonoBehaviour {

    [SerializeField]
    float _renderScale = 1.5f;
	// Use this for initialization
	void Start () {
        UnityEngine.XR.XRSettings.eyeTextureResolutionScale = _renderScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
