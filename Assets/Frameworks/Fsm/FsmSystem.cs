using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 为过渡加入枚举标签
/// 不要修改第一个标签，NullTransition会在FSMSytem类中使用
/// </summary>
public enum Transition
{
    NullTransition = 0, // Use this transition to represent a non-existing transition in your system
    //用这个过度来代表你的系统中不存在的状态
    SawPlayer,//这里配合NPCControl添加两个NPC的过渡
    LostPlayer,
}

/// <summary>
/// 状态id
/// 为状态加入枚举标签
/// 不要修改第一个标签，NullStateID会在FSMSytem中使用 
/// </summary>
public enum StateID
{
    NullStateID = 0, // Use this ID to represent a non-existing State in your syste
    //使用这个ID来代表你系统中不存在的状态ID    
    ChasingPlayer,//这里配合NPCControl添加两个状态
    FollowingPath,

}


/// <summary>
///状态机类：包含状态列表
/// 该类便是有限状态机类
/// 它持有者NPC的状态集合并且有添加，删除状态的方法，以及改变当前正在执行的状态
/// </summary>
/// <summary>  
/// 状态机类：包含状态列表  
/// 1. 删除状态  
/// 2. 改变当前状态  
/// </summary>  
public class FsmSystem
{
    private List<FSMState> states;  // 状态列表  

    // 在状态机中改变当前状态的唯一途径是通过转换，当前状态不可直接改变  
    private StateID currentStateID;
    public StateID CurrentStateID { get { return currentStateID; } }
    private FSMState currentState;
    public FSMState CurrentState { get { return currentState; } }

    

    public FsmSystem()
    {
        states = new List<FSMState>();
    }

    /// 添加状态  
    public void AddState(FSMState s)
    {
        // 空值检验  
        if (s == null)
        {
            Debug.LogError("FSM ERROR: 不可添加空状态");
        }

        // 当所添加状态为初始状态  
        if (states.Count == 0)
        {
            states.Add(s);
            currentState = s;
            currentStateID = s.ID;
            return;
        }

        // 遍历状态列表，若不存在该状态，则添加  
        foreach (FSMState state in states)
        {
            if (state.ID == s.ID)
            {
                Debug.LogError("FSM ERROR: 无法添加状态 " + s.ID.ToString() + " 因为该状态已存在");
                return;
            }
        }
        states.Add(s);
    }

    /// 删除状态  
    public void DeleteState(StateID id)
    {
        // 空值检验  
        if (id == StateID.NullStateID)
        {
            Debug.LogError("FSM ERROR: 状态ID 不可为空ID");
            return;
        }

        // 遍历并删除状态  
        foreach (FSMState state in states)
        {
            if (state.ID == id)
            {
                states.Remove(state);
                return;
            }
        }
        Debug.LogError("FSM ERROR: 无法删除状态 " + id.ToString() + ". 状态列表中不存在");
    }

    /// 执行转换过渡  
    public void PerformTransition(Transition trans)
    {
        // 空值检验  
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSM ERROR: 转换不可为空");
            return;
        }

        // 获取当前状态ID  
        StateID id = currentState.GetOutputState(trans);
        if (id == StateID.NullStateID)
        {
            Debug.LogError("FSM ERROR: 状态 " + currentStateID.ToString() + " 不存在目标状态 " +
                           " - 转换： " + trans.ToString());
            return;
        }

        // 更新当前状态ID 与 当前状态        
        currentStateID = id;
        foreach (FSMState state in states)
        {
            if (state.ID == currentStateID)
            {
                // 执行当前状态后处理  
                currentState.DoBeforeLeaving();

                currentState = state;

                // 执行当前状态前处理  
                currentState.DoBeforeEntering();
                break;
            }
        }
    }
}