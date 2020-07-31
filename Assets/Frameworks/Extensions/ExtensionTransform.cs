using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionTransform {
	#region 变换
	public static float GetPositionX(this Transform trans)
	{
		return trans.position.x;
	}

	public static float GetPositionY(this Transform trans)
	{
		return trans.position.y;
	}

	public static float GetPositionZ(this Transform trans)
	{
		return trans.position.z;
	}

	public static float GetLocalPositionX(this Transform trans)
	{
		return trans.localPosition.x;
	}

	public static float GetLocalPositionY(this Transform trans)
	{
		return trans.localPosition.y;
	}

	public static float GetLocalPositionZ(this Transform trans)
	{
		return trans.localPosition.z;
	}


	public static void SetPositionX(this Transform trans,float x)
	{
		trans.position = new Vector3(x, trans.position.y, trans.position.z);
	}

	public static void SetPositionY(this Transform trans, float y)
	{
		trans.position = new Vector3(trans.position.x, y, trans.position.z);
	}

	public static void SetPositionZ(this Transform trans, float z)
	{
		trans.position = new Vector3(trans.position.x, trans.position.y,z);
	}



	public static void SetLocalPositionX(this Transform trans, float x)
	{
		trans.localPosition = new Vector3(x, trans.localPosition.y, trans.localPosition.z);
	}

	public static void SetLocalPositionY(this Transform trans, float y)
	{
		trans.localPosition = new Vector3(trans.localPosition.x, y, trans.localPosition.z);
	}

	public static void SetLocalPositionZ(this Transform trans, float z)
	{
		trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, z);
	}


	public static void Reset(this Transform trans)
	{
		trans.position = Vector3.zero;
		trans.rotation = Quaternion.identity;
		trans.localScale = Vector3.one;
	}

	public static void ResetLocal(this Transform trans)
	{
		trans.localPosition = Vector3.zero;
		trans.localRotation = Quaternion.identity;
		trans.localScale = Vector3.one;
	}

	public static void SetEulerAnglesX(this Transform transform, float x)
	{
		transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);
	}

	public static void SetEulerAnglesY(this Transform transform, float y)
	{
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, transform.eulerAngles.z);
	}

	public static void SetEulerAnglesZ(this Transform transform, float z)
	{
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, z);
		
	}

	public static void SetLocalEulerAnglesX(this Transform transform, float x)
	{
		transform.localEulerAngles = new Vector3(x, transform.localEulerAngles.y, transform.localEulerAngles.z);
	}

	public static void SetLocalEulerAnglesY(this Transform transform, float y)
	{
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, y, transform.localEulerAngles.z);
	}

	public static void SetLocalEulerAnglesZ(this Transform transform, float z)
	{
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, z);

	}



	public static void SetLocalScaleX(this Transform transform, float x)
	{
		transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
	}

	public static void SetLocalScaleY(this Transform transform, float y)
	{
		transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z);
	}

	public static void SetLocalScaleZ(this Transform transform, float z)
	{
		transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, z);
	}

	#endregion

	public static Transform FindChildRecursion(this Transform father,string childName)
	{
		Transform resultTrs = null;
		resultTrs = father.Find(childName);
		if (resultTrs == null)
		{
			foreach (Transform trs in father)
			{
				resultTrs = FindChildRecursion(trs, childName);
				if (resultTrs != null)
					return resultTrs;
			}
		}
		return resultTrs;
	}

	public static T FindChildRecursion<T>(this Transform father, string childName) where T : Component
	{
		Transform resultTrs = FindChildRecursion(father, childName);
		if (resultTrs != null)
			return resultTrs.GetComponent<T>();
		return (T)((object)null);
	}

	public static void AddChild(this Transform parent, Transform child)
	{
		child.SetParent(parent, false);
		child.localPosition = Vector3.zero;
		child.localScale = Vector3.one;
		child.localEulerAngles = Vector3.zero;
	}

	

	/// <summary>
	/// 删除子节点
	/// </summary>
	/// <param name="father"></param>
	/// <param name="isDeleteHideChild">隐藏的子物体是否需要删除</param>
	public static void DeleteAllChild(this Transform father, bool isDeleteHideChild=true)
	{
		if (father == null) return;
		foreach (Transform tran in father)
		{
			if (isDeleteHideChild == false)
			{
				if (tran.gameObject.activeSelf == false)
				{
					continue;
				}
			}

			UnityEngine.Object.Destroy(tran.gameObject);


		}
	}

	/// <summary>
	/// 给子节点添加脚本
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="goParent">父对象</param>
	/// <param name="childName">子对象名称</param>
	/// <returns></returns>
	public static T AddChildCompnent<T>(this Transform parent, string childName) where T : Component
	{
		Transform resultTrans = null;                //查找特定节点结果

		//查找特定子节点
		resultTrans = FindChildRecursion(parent, childName);
		//如果查找成功，则考虑如果已经有相同的脚本了，则先删除，否则直接添加。
		if (resultTrans != null)
		{
			//如果已经有相同的脚本了，则先删除
			T[] componentScriptsArray = resultTrans.GetComponents<T>();
			for (int i = 0; i < componentScriptsArray.Length; i++)
			{
				if (componentScriptsArray[i] != null)
				{
					UnityEngine.Object.Destroy(componentScriptsArray[i]);
				}
			}
			return resultTrans.gameObject.AddComponent<T>();
		}
		else
		{
			return null;
		}
		//如果查找不成功，返回Null.
	}

	/// <summary>
	/// 规范化(归一化)大小
	/// </summary>
	/// <param name="source"></param>
	public static void NormalizeSize(this Transform source)
	{
		if (source == null) throw new NullReferenceException();

		source.localPosition = Vector3.zero;
		source.localEulerAngles = Vector3.zero;
		Transform p = source.parent;
		if (p != null)
		{
			Vector3 s = p.lossyScale;
			source.localScale = new Vector3((s.x == 0 ? 0 : 1 / s.x), (s.y == 0 ? 0 : 1 / s.y), (s.z == 0 ? 0 : 1 / s.z));
		}
		else
		{
			source.localScale = Vector3.one;
		}
	}

}
