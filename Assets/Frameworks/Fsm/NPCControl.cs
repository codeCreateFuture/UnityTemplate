using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NPCControl : MonoBehaviour
{
    public GameObject player;
    public Transform[] path;
    private FsmSystem fsm;


    public float Speed = 10f;

    public void SetTransition(Transition t)
    {
        //�÷��������ı�����״̬����״�壬����״̬�����ڵ�ǰ��״̬��ͨ���Ĺ���״̬��
        //�����ǰ��״̬û������ͨ���Ĺ���״̬������׳�����
        fsm.PerformTransition(t);
    }

    public void Start()
    {
        MakeFSM();
    }

    public void FixedUpdate()
    {
        fsm.CurrentState.Reason(player, gameObject);
        fsm.CurrentState.Act(player, gameObject);
    }


    //NPC������״̬�ֱ�����·����Ѳ�ߺ�׷�����
    //������ڵ�һ��״̬����SawPlayer ����״̬�������ˣ�����ת�䵽ChasePlayer״̬
    //�������ChasePlayer״̬����LostPlayer״̬�������ˣ�����ת�䵽FollowPath״̬

    private void MakeFSM()//����״̬��
    {
        FollowPathState follow = new FollowPathState(path);
        follow.AddTransition(Transition.SawPlayer, StateID.ChasingPlayer);

        ChasePlayerState chase = new ChasePlayerState();
        chase.AddTransition(Transition.LostPlayer, StateID.FollowingPath);

        fsm = new FsmSystem();
        fsm.AddState(follow);//���״̬��״̬������һ����ӵ�״̬����Ϊ��ʼ״̬
        fsm.AddState(chase);
    }
}



