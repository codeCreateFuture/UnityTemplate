using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MathUtil {

    /// <summary>
    /// 输⼊入百分比返回是否命中概率
    /// </summary>
    /// <param name="percent"></param>
    /// <returns></returns>
    public static bool IsHitByPercent(float percent)
    {
        percent = Mathf.Clamp(percent, 0, 100);
        return Random.Range(0, 100) <= percent;
    }


    /// <summary>
    /// 随机取出数组中的一个值
    /// </summary>
    /// <param name="arrays"></param>
    /// <returns></returns>
    public static object GetRandomValueFromArray(object []arrays)
    {
        return arrays[Random.Range(0, arrays.Length)];
    }

    /// <summary>
    /// 从若干个值中随机取出⼀一个值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    public static T GetRandomValueFrom<T>(params T[] values)
    {
        return values[Random.Range(0, values.Length)];
    }

#if UNITY_EDITOR
    [MenuItem("Tools/MathUtil/概率函数")]
    private static void MenuClick()
    {
        Debug.Log(IsHitByPercent(50));
    }
    

#endif
}
