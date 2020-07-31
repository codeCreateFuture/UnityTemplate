using System;
using UnityEngine;
using System.Collections.Generic;


/// <summary>  
/// 状态机中的状态类：以字典的形式保存状态的转换  
/// 1. Reason() 决定触发哪个转换  
/// 2. Act() 决定NPC在当前状态下的行为  
/// </summary>  
public abstract class FSMState
{
    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();  // 状态转换映射  
    protected StateID stateID;                     // 状态ID  
    public StateID ID { get { return stateID; } }  // 获取当前状态ID  

    /// 添加转换  
    public void AddTransition(Transition trans, StateID id)
    {
        // 空值检验  
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSMState ERROR: 不能添加空转换");
            return;
        }

        if (id == StateID.NullStateID)
        {
            Debug.LogError("FSMState ERROR: 不能添加空状态");
            return;
        }

        // 检查是否已经有该转换  
        if (map.ContainsKey(trans))
        {
            Debug.LogError("FSMState ERROR: 状态 " + stateID.ToString() + " 已经包含转换 " + trans.ToString() + "不可添加另一个状态");
            return;
        }

        map.Add(trans, id);
    }

    /// 删除状态转换  
    public void DeleteTransition(Transition trans)
    {
        // 空值检验  
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSMState ERROR: 不能删除空转换");
            return;
        }

        // 检验是否有配对的转换  
        if (map.ContainsKey(trans))
        {
            map.Remove(trans);
            return;
        }
        Debug.LogError("FSMState ERROR: 转换 " + trans.ToString() + " - 状态 " + stateID.ToString() + " 不存在");
    }

    /// 获取下一个状态  
    public StateID GetOutputState(Transition trans)
    {
        // 如果存在转换，返回对应状态  
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }
        return StateID.NullStateID;
    }

    /// 进入状态之前执行  
    public virtual void DoBeforeEntering() { }

    /// 离开状态之前执行  
    public virtual void DoBeforeLeaving() { }

    /// 状态转换条件  
    public abstract void Reason(GameObject player, GameObject npc);

    /// 控制行为  
    public abstract void Act(GameObject player, GameObject npc);

}