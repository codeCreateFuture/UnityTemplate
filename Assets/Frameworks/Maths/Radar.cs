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
            //朝向目标  (Z轴朝向目标)
            this.transform.LookAt(targetPos);
            //根据距离衰减 角度
            float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * 45;
            //旋转对应的角度（线性插值一定角度，然后每帧绕X轴旋转）
            this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
            //当前距离目标点
            float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
            if (currentDist < 0.5f)
            {
                move = false;
            }
            //平移 （朝向Z轴移动）
            this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
            yield return null;
        }
    }
}
