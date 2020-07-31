using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��������Ļ�����ص�
/// </summary>
public class SpringInScreenBorder : MonoBehaviour {



    public float speed = 5f;
    void Start()
    {
        Debug.Log("��Ļ��" + Screen.width + "�ߣ�" + Screen.height);//��ȡ��Ļ�ĳ��Ϳ�
        Vector2 screenPos = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));//��������(0,0,0)��һ�������transform.position��ȡ->��Ļ����

        //��Ļ����->��������
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


        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);//��������(0,0,0)��һ�������transform.position��ȡ->��Ļ����

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
