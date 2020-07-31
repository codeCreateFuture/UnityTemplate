using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class CArrowLockAt : MonoBehaviour
	{
	    public Transform target;    //Ŀ��
	    public Transform self;  //�Լ�
	
	    public float direction; //��ͷ��ת�ķ��򣬻���˵�Ƕȣ�ֻ������ֵ
	    public Vector3 u;   //���˽����������ж������Ƕ������Ǹ�
	
	    float devValue = 10f;   //������Ե����
	    float showWidth;    //��devValue�����������ĵ���Ե�ľ��루���͸ߣ�
	    float showHeight;
	
	    Quaternion originRot;   //��ͷԭ�Ƕ�
	
	    // ��ʼ��
	    void Start()
	    {
	        originRot = transform.rotation;
	        //showWidth = Screen.width / 2 - devValue;
	        //showHeight = Screen.height / 2 - devValue;
	    }
	
	    void Update()
	    {
	        // ÿ֡�����¼���һ�Σ���Ҫ�ǵ���ʹ�÷���
	        showWidth = Screen.width / 2 - devValue;
	        showHeight = Screen.height / 2 - devValue;
	
	        // ���������ͽǶ�
	        Vector3 forVec = self.forward;  //���㱾������ǰ����
	        Vector3 angVec = (target.position - self.position).normalized;  //��������Ŀ������֮���ĵ�λ����
	
	        Vector3 targetVec = Vector3.ProjectOnPlane(angVec - forVec, forVec).normalized; //�ⲽ����Ҫ����������������������һ������������������Ͷ�䵽������xyƽ��
	        Vector3 originVec = self.up;
	
	        direction = Vector3.Dot(originVec, targetVec);  //�ٸ�y���������������Ͳ������������˼�ͷ��Ҫ��ת�ĽǶȺͽǶȵ�����
	        u = Vector3.Cross(originVec, targetVec);
	
	        direction = Mathf.Acos(direction) * Mathf.Rad2Deg;  //ת��Ϊ�Ƕ�
	
	        u = self.InverseTransformDirection(u);  //��������ת��Ϊ����������
	
	        // ������תֵ
	        transform.rotation = originRot * Quaternion.Euler(new Vector3(0f, 0f, direction * (u.z > 0 ? 1 : -1)));
	
	        // ���㵱ǰ��������Ļ�ϵ�λ��
	        Vector2 screenPos = Camera.main.WorldToScreenPoint(target.position);
	
	        //if(Vector3.Dot(forVec, angVec) < 0)
	        // ������Ļ�ڵ�����
	        if (screenPos.x < devValue || screenPos.x > Screen.width - devValue || screenPos.y < devValue || screenPos.y > Screen.height - devValue || Vector3.Dot(forVec, angVec) < 0)
	        {
	            Vector3 result = Vector3.zero;
	            if (direction == 0) //�����Ƕ�0��180ֱ�Ӹ�ֵ������֪��tan90������ʲô����
	            {
	                result.y = showHeight;
	            }
	            else if (direction == 180)
	            {
	                result.y = -showHeight;
	            }
	            else    //��������
	            {
	                // ת���Ƕ�
	                float direction_new = 90 - direction;
	                float k = Mathf.Tan(Mathf.Deg2Rad * direction_new);
	
	                // ����
	                result.x = showHeight / k;
	                if ((result.x > (-showWidth)) && (result.x < showWidth))    // �Ƕ������µױߵ�����
	                {
	                    result.y = showHeight;
	                    if (direction > 90)
	                    {
	                        result.y = -showHeight;
	                        result.x = result.x * -1;
	                    }
	                }
	                else    // �Ƕ������ҵױߵ�����
	                {
	                    result.y = showWidth * k;
	                    if ((result.y > -showHeight) && result.y < showHeight)
	                    {
	                        result.x = result.y / k;
	                    }
	                }
	                if (u.z > 0)
	                    result.x = -result.x;
	            }
	            transform.localPosition = result;
	        }
	        else    // ����Ļ�ڵ�����
	        {
	            transform.position = screenPos;
	        }
	    }
	}
	

