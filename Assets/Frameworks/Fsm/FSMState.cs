using System;
using UnityEngine;
using System.Collections.Generic;


/// <summary>  
/// ״̬���е�״̬�ࣺ���ֵ����ʽ����״̬��ת��  
/// 1. Reason() ���������ĸ�ת��  
/// 2. Act() ����NPC�ڵ�ǰ״̬�µ���Ϊ  
/// </summary>  
public abstract class FSMState
{
    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();  // ״̬ת��ӳ��  
    protected StateID stateID;                     // ״̬ID  
    public StateID ID { get { return stateID; } }  // ��ȡ��ǰ״̬ID  

    /// ���ת��  
    public void AddTransition(Transition trans, StateID id)
    {
        // ��ֵ����  
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSMState ERROR: ������ӿ�ת��");
            return;
        }

        if (id == StateID.NullStateID)
        {
            Debug.LogError("FSMState ERROR: ������ӿ�״̬");
            return;
        }

        // ����Ƿ��Ѿ��и�ת��  
        if (map.ContainsKey(trans))
        {
            Debug.LogError("FSMState ERROR: ״̬ " + stateID.ToString() + " �Ѿ�����ת�� " + trans.ToString() + "���������һ��״̬");
            return;
        }

        map.Add(trans, id);
    }

    /// ɾ��״̬ת��  
    public void DeleteTransition(Transition trans)
    {
        // ��ֵ����  
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSMState ERROR: ����ɾ����ת��");
            return;
        }

        // �����Ƿ�����Ե�ת��  
        if (map.ContainsKey(trans))
        {
            map.Remove(trans);
            return;
        }
        Debug.LogError("FSMState ERROR: ת�� " + trans.ToString() + " - ״̬ " + stateID.ToString() + " ������");
    }

    /// ��ȡ��һ��״̬  
    public StateID GetOutputState(Transition trans)
    {
        // �������ת�������ض�Ӧ״̬  
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }
        return StateID.NullStateID;
    }

    /// ����״̬֮ǰִ��  
    public virtual void DoBeforeEntering() { }

    /// �뿪״̬֮ǰִ��  
    public virtual void DoBeforeLeaving() { }

    /// ״̬ת������  
    public abstract void Reason(GameObject player, GameObject npc);

    /// ������Ϊ  
    public abstract void Act(GameObject player, GameObject npc);

}