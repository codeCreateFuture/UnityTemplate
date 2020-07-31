using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 物体在屏幕内来回弹
/// </summary>
public class SpringInScreenBorder : MonoBehaviour {



    public float speed = 5f;
    void Start()
    {
        Debug.Log("屏幕宽：" + Screen.width + "高：" + Screen.height);//获取屏幕的长和宽
        Vector2 screenPos = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));//世界坐标(0,0,0)，一般可以用transform.position获取->屏幕坐标

        //屏幕坐标->世界坐标
        Debug.Log(screenPos.x + "," + screenPos.y);
        Vector3 worldPos1 = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Debug.Log(worldPos1.x + "," + worldPos1.y + "," + worldPos1.z);
        Vector3 worldPos2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -Camera.main.transform.position.z));
        Debug.Log(worldPos2.x + "," + worldPos2.y + "," + worldPos2.z);

    }


    // Update is called once per frame
    void Update()
    {
        UpdatePosition();

    }

    public Vector3 velocity=new Vector3(3,2,0);
    void UpdatePosition()
    {
        Vector3 temp=  transform.position + velocity;

        transform.position = Vector3.Lerp(transform.position, temp, speed*Time.deltaTime);


        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);//世界坐标(0,0,0)，一般可以用transform.position获取->屏幕坐标

        if (screenPos.x <= 0 || screenPos.x > Screen.width)
        {
            //side wall
            velocity.x = Mathf.Abs(velocity.x) * -Mathf.Sign(transform.position.x);
            //Music.QuantizePlay(GetComponent<AudioSource>());
        }
        if (screenPos.y >= Screen.height || screenPos.y <= 0)
        {
            //roof
            velocity.y = Mathf.Abs(velocity.y) * -Mathf.Sign(transform.position.y);
            //Music.QuantizePlay(GetComponent<AudioSource>(), 7);
        }
        //else if (transform.position.y <= -Field.FieldLength)
        //{
        //	//floor
        //	//Music.SeekToSection("GameOver");
        //}
    }
}
