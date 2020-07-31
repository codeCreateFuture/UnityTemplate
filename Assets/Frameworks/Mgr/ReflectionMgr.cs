using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

public static class ReflectionMgr{

	public static string GetAssemblyName()
	{
		return Assembly.GetExecutingAssembly().GetName().Name;
	}

	
	public static UnityEngine.Object CreateUnityObject(string typeName)
	{
		UnityEngine.Object obj=(UnityEngine.Object)Assembly.Load(GetAssemblyName()).CreateInstance(typeName);
		return obj;
	}

	/// <summary>
	/// ͨ������(�ַ���)����һ�������Ķ���,��Ҫ������򼯵����ƣ������������ռ�
	/// </summary>
	/// <param name="typeName"></param>
	/// <returns></returns>
	public static System.Object CreateCSharpObject(string typeName)
	{
		System.Object obj = (System.Object)Assembly.Load(GetAssemblyName()).CreateInstance(typeName);
		return obj;
	}

   

	public static System.Object CreateCSharpObjectNoParas(string typeName)
	{
		Type type = Type.GetType(typeName);
		ConstructorInfo construct = type.GetConstructor(System.Type.EmptyTypes); 
		return (System.Object)construct.Invoke(null);
	}
}
