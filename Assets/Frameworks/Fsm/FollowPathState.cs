using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 跟随
/// </summary>
public class FollowPathState : FSMState
{
    private int currentWayPoint;
    private Transform[] waypoints;

    //构造函数装填自己
    public FollowPathState(Transform[] wp)
    {
        waypoints = wp;
        currentWayPoint = 0;
        stateID = StateID.FollowingPath;//别忘设置自己的StateID
    }

    public override void DoBeforeEntering()
    {
        Debug.Log("进入FollowPathState状态之前执行--------");
       // currentWayPoint = 0;
    }

    public override void DoBeforeLeaving()
    {
        Debug.Log("离开FollowPathState状态之前执行---------");
    }

    //重写动机方法
    public override void Reason(GameObject player, GameObject npc)
    {
        // If the Player passes less than 15 meters away in front of the NPC
        RaycastHit hit;
        if (Physics.Raycast(npc.transform.position, npc.transform.forward, out hit, 35F))
        {
            Debug.Log("与玩家的距离少于35");
            if (hit.transform.gameObject.tag == "Player")
            {
                Debug.Log("看到玩家 转换状态");
                npc.GetComponent<NPCControl>().SetTransition(Transition.SawPlayer);
            }

        }
    }

    //重写表现方法
    public override void Act(GameObject player, GameObject npc)
    {
        // Follow the path of waypoints
        // Find the direction of the current way point 
        Vector3 vel = npc.GetComponent<Rigidbody>().velocity;
        Vector3 moveDir = waypoints[currentWayPoint].position - npc.transform.position;

        if (moveDir.magnitude < 1)
        {
            currentWayPoint++;
            if (currentWayPoint >= waypoints.Length)
            {
                currentWayPoint = 0;
            }
        }
        else
        {
            vel = moveDir.normalized * npc.GetComponent<NPCControl>().Speed;

            // Rotate towards the waypoint
            npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,
                                                      Quaternion.LookRotation(moveDir),
                                                      5 * Time.deltaTime);
            npc.transform.eulerAngles = new Vector3(0, npc.transform.eulerAngles.y, 0);

        }

        // Apply the Velocity
        npc.GetComponent<Rigidbody>().velocity = vel;
    }

} // FollowPathState
