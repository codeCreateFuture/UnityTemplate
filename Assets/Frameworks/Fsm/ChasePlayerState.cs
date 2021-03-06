using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 巡逻状态
/// </summary>
public class ChasePlayerState : FSMState
{
    //构造函数装填自己
    public ChasePlayerState()
    {
        stateID = StateID.ChasingPlayer;
      
    }

    public override void DoBeforeEntering()
    {
        Debug.Log("进入ChasePlayerState状态之前执行--------");
    }

    public override void DoBeforeLeaving()
    {
        Debug.Log("离开ChasePlayerState状态之前执行 ---------");
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        // If the player has gone 30 meters away from the NPC, fire LostPlayer transition
        if (Vector3.Distance(npc.transform.position, player.transform.position) >= 3)
            npc.GetComponent<NPCControl>().SetTransition(Transition.LostPlayer);
    }

    public override void Act(GameObject player, GameObject npc)
    {
        // Follow the path of waypoints
        // Find the direction of the player         
        Vector3 vel = npc.GetComponent<Rigidbody>().velocity;
        Vector3 moveDir = player.transform.position - npc.transform.position;

        // Rotate towards the waypoint
        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,
                                                  Quaternion.LookRotation(moveDir),
                                                  5 * Time.deltaTime);
        npc.transform.eulerAngles = new Vector3(0, npc.transform.eulerAngles.y, 0);

        vel = moveDir.normalized * 10;

        // Apply the new Velocity
        npc.GetComponent<Rigidbody>().velocity = vel;
    }

} // ChasePlayerState
