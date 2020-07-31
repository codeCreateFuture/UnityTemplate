/// <summary>
/// Camera follow.
/// this script use for control main camera to follow target(character)
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour {
	
	
	public Transform target; //Target to follow
	public float angle = 15; //Angle camera
	[HideInInspector]
	public float distance = -3.5f; //Distance target
	[HideInInspector]
	public float height = 2.5f; // Height camera

	public List<Material> skyMats = new List<Material> ();
	
	
	//Private variable field
	private Vector3 posCamera;
	private Vector3 angleCam;
	private bool shake;
	void Awake()
	{
	  //  distance = ConfigData.GameVersion == ConfigData.VersionType.VERSION_NFC ? -7.8f : -3.5f;
	   // height = ConfigData.GameVersion == ConfigData.VersionType.VERSION_NFC ? 3f : 2.5f;

		distance =true ? -7.8f : -3.5f;
		height =true? 3f : 2.5f;
	}

	/**
	void LateUpdate(){
		if(target != null){
			if(target.position.z >= 0){
				if(shake == false){
					posCamera.x = Mathf.Lerp(posCamera.x, target.position.x, 5 * Time.deltaTime);
					posCamera.y = Mathf.Lerp(posCamera.y, target.position.y + height, 5 * Time.deltaTime);
					posCamera.z = Mathf.Lerp(posCamera.z, target.position.z + distance, GameAttribute.gameAttribute.speed); //* Time.deltaTime);
					transform.position = posCamera;
					angleCam.x = angle;
					angleCam.y = Mathf.Lerp(angleCam.y, 0, 1 * Time.deltaTime);
					angleCam.z = transform.eulerAngles.z;
					//transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, angleCam, 1 * Time.deltaTime);
				}
			}else{
				if(PatternSystem.instance.loadingComplete == true){
					Vector3 dummy = Vector3.zero;
					posCamera.x = Mathf.Lerp(posCamera.x, 0, 5 * Time.deltaTime);
					posCamera.y = Mathf.Lerp(posCamera.y, dummy.y + height, 5 * Time.deltaTime);
					posCamera.z = dummy.z + distance;
					transform.position = posCamera;
					angleCam.x = angle;
					angleCam.y = transform.eulerAngles.y;
					angleCam.z = transform.eulerAngles.z;
					transform.eulerAngles = angleCam;
				}
			}
		}
	}
	**/

	void LateUpdate(){
		if(target != null){
			//if(target.position.z >= 0){
				if(shake == false){
					if (this.gameObject.name == "PKEnemyCamera")
					{
						posCamera.x = target.position.x;
					}
					else
					{
						//posCamera.x = ConfigData.GameVersion == ConfigData.VersionType.VERSION_NFC ? 0 : target.position.x;
						posCamera.x = true ? 0 : target.position.x;
				}
					
					posCamera.y = target.position.y + height;
					posCamera.z = target.position.z + distance;
					transform.position = posCamera;
				}
			//}else{
			//    if(PatternSystem.instance.loadingComplete == true){
			//        Vector3 dummy = Vector3.zero;
			//        posCamera.x = Mathf.Lerp(posCamera.x, 0, 5 * Time.deltaTime);
			//        posCamera.y = Mathf.Lerp(posCamera.y, dummy.y + height, 5 * Time.deltaTime);
			//        posCamera.z = dummy.z + distance;
			//        transform.position = posCamera;
			//        angleCam.x = angle;
			//        angleCam.y = transform.eulerAngles.y;
			//        angleCam.z = transform.eulerAngles.z;
			//        transform.eulerAngles = angleCam;
			//    }
			//}
		}
	}
	
	
	//Reset camera when charater die
	public void RestartGame(){
		shake = false;
		Vector3 dummy = Vector3.zero;
		posCamera.x = 0;
		posCamera.y = dummy.y + height;
		posCamera.z = dummy.z + distance;
		transform.position = posCamera;
	}
	
	//Shake camera
	public void ActiveShake(){
		shake = true;
		StartCoroutine(ShakeCamera());	
	}
	
	IEnumerator ShakeCamera(){
		float count = 0;
		Vector3 pos = Vector3.zero;;
		while(count <= 0.2f){
			count += 1 * Time.smoothDeltaTime;	
			pos.x = target.position.x + Random.Range(-0.05f,0.05f);
			pos.y = target.position.y+ height + Random.Range(-0.05f,0.05f);
			pos.z = target.position.z + distance + Random.Range(-0.05f,0.05f);
			transform.position = pos;
			yield return 0;
		}
		posCamera.x = target.position.x;
		posCamera.y = target.position.y + height;
		posCamera.z = target.position.z + distance;
		transform.position = posCamera;
		shake = false;
	}

	public void SetSkybox(int index)
	{
		this.gameObject.GetComponent<Skybox> ().material = skyMats [index];
	}
	
}
