using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Ϊ���ɼ���ö�ٱ�ǩ
/// ��Ҫ�޸ĵ�һ����ǩ��NullTransition����FSMSytem����ʹ��
/// </summary>
public enum Transition
{
    NullTransition = 0, // Use this transition to represent a non-existing transition in your system
    //������������������ϵͳ�в����ڵ�״̬
    SawPlayer,//�������NPCControl�������NPC�Ĺ���
    LostPlayer,
}

/// <summary>
/// ״̬id
/// Ϊ״̬����ö�ٱ�ǩ
/// ��Ҫ�޸ĵ�һ����ǩ��NullStateID����FSMSytem��ʹ�� 
/// </summary>
public enum StateID
{
    NullStateID = 0, // Use this ID to represent a non-existing State in your syste
    //ʹ�����ID��������ϵͳ�в����ڵ�״̬ID    
    ChasingPlayer,//�������NPCControl�������״̬
    FollowingPath,

}


/// <summary>
///״̬���ࣺ����״̬�б�
/// �����������״̬����
/// ��������NPC��״̬���ϲ�������ӣ�ɾ��״̬�ķ������Լ��ı䵱ǰ����ִ�е�״̬
/// </summary>
/// <summary>  
/// ״̬���ࣺ����״̬�б�  
/// 1. ɾ��״̬  
/// 2. �ı䵱ǰ״̬  
/// </summary>  
public class FsmSystem
{
    private List<FSMState> states;  // ״̬�б�  

    // ��״̬���иı䵱ǰ״̬��Ψһ;����ͨ��ת������ǰ״̬����ֱ�Ӹı�  
    private StateID currentStateID;
    public StateID CurrentStateID { get { return currentStateID; } }
    private FSMState currentState;
    public FSMState CurrentState { get { return currentState; } }

    

    public FsmSystem()
    {
        states = new List<FSMState>();
    }

    /// ���״̬  
    public void AddState(FSMState s)
    {
        // ��ֵ����  
        if (s == null)
        {
            Debug.LogError("FSM ERROR: ������ӿ�״̬");
        }

        // �������״̬Ϊ��ʼ״̬  
        if (states.Count == 0)
        {
            states.Add(s);
            currentState = s;
            currentStateID = s.ID;
            return;
        }

        // ����״̬�б��������ڸ�״̬�������  
        foreach (FSMState state in states)
        {
            if (state.ID == s.ID)
            {
                Debug.LogError("FSM ERROR: �޷����״̬ " + s.ID.ToString() + " ��Ϊ��״̬�Ѵ���");
                return;
            }
        }
        states.Add(s);
    }

    /// ɾ��״̬  
    public void DeleteState(StateID id)
    {
        // ��ֵ����  
        if (id == StateID.NullStateID)
        {
            Debug.LogError("FSM ERROR: ״̬ID ����Ϊ��ID");
            return;
        }

        // ������ɾ��״̬  
        foreach (FSMState state in states)
        {
            if (state.ID == id)
            {
                states.Remove(state);
                return;
            }
        }
        Debug.LogError("FSM ERROR: �޷�ɾ��״̬ " + id.ToString() + ". ״̬�б��в�����");
    }

    /// ִ��ת������  
    public void PerformTransition(Transition trans)
    {
        // ��ֵ����  
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSM ERROR: ת������Ϊ��");
            return;
        }

        // ��ȡ��ǰ״̬ID  
        StateID id = currentState.GetOutputState(trans);
        if (id == StateID.NullStateID)
        {
            Debug.LogError("FSM ERROR: ״̬ " + currentStateID.ToString() + " ������Ŀ��״̬ " +
                           " - ת���� " + trans.ToString());
            return;
        }

        // ���µ�ǰ״̬ID �� ��ǰ״̬        
        currentStateID = id;
        foreach (FSMState state in states)
        {
            if (state.ID == currentStateID)
            {
                // ִ�е�ǰ״̬����  
                currentState.DoBeforeLeaving();

                currentState = state;

                // ִ�е�ǰ״̬ǰ����  
                currentState.DoBeforeEntering();
                break;
            }
        }
    }
}