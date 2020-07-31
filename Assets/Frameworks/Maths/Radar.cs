using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour
{
    public GameObject target;
    public float speed = 10;
    private float distanceToTarget;
    private bool move = true;

    void Start()
    {
        distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(1))
        {
            Debug.Log("dfsda");
            distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);
            move = true;
            StartCoroutine(Shoot());

        }
    }

    IEnumerator Shoot()
    {

        while (move)
        {
            Vector3 targetPos = target.transform.position;
            //����Ŀ��  (Z�ᳯ��Ŀ��)
            this.transform.LookAt(targetPos);
            //���ݾ���˥�� �Ƕ�
            float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * 45;
            //��ת��Ӧ�ĽǶȣ����Բ�ֵһ���Ƕȣ�Ȼ��ÿ֡��X����ת��
            this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
            //��ǰ����Ŀ���
            float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
            if (currentDist < 0.5f)
            {
                move = false;
            }
            //ƽ�� ������Z���ƶ���
            this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
            yield return null;
        }
    }
}
