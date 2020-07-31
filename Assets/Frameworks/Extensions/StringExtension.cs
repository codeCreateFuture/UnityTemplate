using System.Collections;
using System.Collections.Generic;

public static class StringExtension{
    /// <summary>
    /// 返回a-b区间的字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="aStr"></param>
    /// <param name="bStr"></param>
    /// <returns></returns>
    public static string BetweenAToB(this string str, string aStr, string bStr)
    {
        if (aStr.IndexOf(bStr, 0) != -1)
            return "";
        int aStrIndex = str.IndexOf(aStr, 0);
        int bStrIndex = str.IndexOf(bStr, aStrIndex + 1);
        if (aStrIndex == -1 || bStrIndex == -1)
            return "";
        return str.Substring(aStrIndex + aStr.Length, bStrIndex - aStrIndex - aStr.Length);
    }

    public static string LineTogether(this string head,params string [] args)
    {
        return string.Format(head, args);
    }

}
