using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringOperate {

	//截取最后某个字符串后面的字符
	public static string GetLastSplitChat(string old,string split)
	{
		return old.Substring(old.LastIndexOf(split) + 1);

	}

	public static string CreateStr(char ar,int count)
	{
		return new string(ar, count);
	}
}
