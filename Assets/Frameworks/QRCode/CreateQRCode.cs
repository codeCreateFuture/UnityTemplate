using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Antares.QRCode;

public class CreateQRCode : MonoBehaviour {


	public Texture2D qrCodeTex;

	public string qrCodeText;


	public RawImage qrcodeRawImg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnCreateQRCode()
	{
		if (string.IsNullOrEmpty(qrCodeText)) return;
		qrCodeTex= QRCodeProcessor.Encode(qrCodeText, 200, 200, ErrorCorrectionLevel.H, "Dude.. :D");
		qrcodeRawImg.texture = qrCodeTex;
	}
}
