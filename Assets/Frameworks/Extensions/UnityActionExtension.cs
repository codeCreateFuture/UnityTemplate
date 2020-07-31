using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public static class UnityActionExtension
{
    public static void Example()
    {
        UnityAction action = () => { };
        UnityAction<int> actionWithInt = num => { };
        UnityAction<int, string> actionWithIntString = (num, str) => { };

        action.InvokeGracefully();
        actionWithInt.InvokeGracefully(1);
        actionWithIntString.InvokeGracefully(1, "str");
    }

    /// <summary>
    ///  ��ȫ����unity ί��
    /// </summary>
    /// <param name="selfAction"></param>
    /// <returns> call succeed</returns>
    public static bool InvokeGracefully(this UnityAction selfAction)
    {
        if (null != selfAction)
        {
            selfAction();
            return true;
        }

        return false;
    }

    /// <summary>
    /// ��ȫ����ί��
    /// </summary>
    /// <param name="selfAction"></param>
    /// <returns></returns>
    public static bool InvokeGracefully(this Action selfAction)
    {
        if (null != selfAction)
        {
            selfAction();
            return true;
        }

        return false;
    }

    /// <summary>
    /// ��ȫ���÷���ί��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selfAction"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool InvokeGracefully<T>(this Action<T> selfAction, T t)
    {
        if (null != selfAction)
        {
            selfAction(t);
            return true;
        }
        return false;
    }

    /// <summary>
    /// ��ȫ����unity ����ί��
    /// </summary>
    /// <param name="selfAction"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool InvokeGracefully<T>(this UnityAction<T> selfAction, T t)
    {
        if (null != selfAction)
        {
            selfAction(t);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Call action
    /// </summary>
    /// <param name="selfAction"></param>
    /// <returns> call succeed</returns>
    public static bool InvokeGracefully<T, K>(this UnityAction<T, K> selfAction, T t, K k)
    {
        if (null != selfAction)
        {
            selfAction(t, k);
            return true;
        }

        return false;
    }

    /// <summary>
    /// �������б���Ԫ��
    /// </summary>
    /// <typeparam name="T">Ԫ������</typeparam>
    /// <param name="list">�б�</param>
    /// <returns></returns>
    public static T GetRandomItem<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count - 1)];
    }


    /// <summary>
    /// ����Ȩֵ����ȡ����
    /// </summary>
    /// <param name="powers"></param>
    /// <returns></returns>
    public static int GetRandomWithPower(this List<int> powers)
    {
        var sum = 0;
        foreach (var power in powers)
        {
            sum += power;
        }

        var randomNum = UnityEngine.Random.Range(0, sum);
        var currentSum = 0;
        for (var i = 0; i < powers.Count; i++)
        {
            var nextSum = currentSum + powers[i];
            if (randomNum >= currentSum && randomNum <= nextSum)
            {
                return i;
            }

            currentSum = nextSum;
        }

       // Log.E("Ȩֵ��Χ�������");
        return -1;
    }

    /// <summary>
    /// ����Ȩֵ��ȡֵ��KeyΪֵ��ValueΪȨֵ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="powersDict"></param>
    /// <returns></returns>
    public static T GetRandomWithPower<T>(this Dictionary<T, int> powersDict)
    {
        var keys = new List<T>();
        var values = new List<int>();

        foreach (var key in powersDict.Keys)
        {
            keys.Add(key);
            values.Add(powersDict[key]);
        }

        var finalKeyIndex = values.GetRandomWithPower();
        return keys[finalKeyIndex];
    }
}