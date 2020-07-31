using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Recursion 递归
public static class ExtensionGameObject {

	public static void Reset(this GameObject trans)
	{
		trans.transform.position = Vector3.zero;
		trans.transform.rotation = Quaternion.identity;
		trans.transform.localScale = Vector3.one;
	}

	public static void ResetLocal(this GameObject trans)
	{
		trans.transform.localPosition = Vector3.zero;
		trans.transform.localRotation = Quaternion.identity;
		trans.transform.localScale = Vector3.one;
	}

	public static GameObject Show(this GameObject go)
	{
		go.SetActive(true);
		return go;
	}
	
	public static GameObject Hide(this GameObject go)
	{
		go.SetActive(false);
		return go;
	}

	/// <summary>
	/// 创建指定路径的子节点不允许有同样的根节点  
	/// </summary>
	/// <param name="go"></param>
	/// <param name="pathName"></param>
	/// <returns></returns>
	public static GameObject[] CreateChildInPath(this GameObject go, string pathName)
	{
		GameObject father = go;
		GameObject obj2 = null;
		var list = new List<GameObject>();
		var separator = new char[] { '/' };
		for (var i = 0; i < pathName.Split(separator).Length; i++)
		{
			var str = pathName.Split(separator)[i];

			var childTrans = go.transform.Find(str);
			GameObject item=null;
			if(childTrans==null)
			{
				item = new GameObject(str);
			}else
			{
				item = childTrans.gameObject;
			}
					 
			list.Add(item);
			if (obj2 != null)
			{
				item.transform.SetParent(obj2.transform);
			}
			obj2 = item;
			go = item;
		}
		list[0].transform.SetParent(father.transform);
		
		return list.ToArray();
	}
	/// <summary>
	/// 创建指定路径的子节点允许有同样的根节点
	/// </summary>
	/// <param name="go"></param>
	/// <param name="pathName"></param>
	/// <returns></returns>
	public static GameObject[] CreateChildInPathSameFather(this GameObject go, string pathName)
	{
		GameObject obj2 = null;
		var list = new List<GameObject>();
		var separator = new char[] { '/' };
		for (var i = 0; i < pathName.Split(separator).Length; i++)
		{
			var str = pathName.Split(separator)[i];
			var item = new GameObject(str);
			list.Add(item);
			if (obj2 != null)
			{
				item.transform.SetParent(obj2.transform);
			}
			obj2 = item;
		}
		list[0].transform.SetParent(go.transform);
		return list.ToArray();
	}

	//获取节点层级深度
	public static int Depth(this GameObject go)
	{
		var depth = 0;
		var current = go.transform;
		do
		{
			current = current.transform.parent;
			if (current != null)
			{
				depth++;
			}
		} while (current != null);
		return depth;
	}

	public static GameObject Layer(this GameObject go, int layer)
	{
		go.layer = layer;
		return go;
	}

	//设置当前节点的层
	public static void SetLayer(this GameObject go, LayerMask layer)
	{
		go.layer = layer;
	}

	//按索引递归设置当前和所有子节点的层
	public static void SetLayerRecursion(this GameObject go, LayerMask layer)
	{
		go.layer = layer;
		foreach (Transform child in go.transform)
		{
			SetLayerRecursion(child.gameObject, layer);
		}
	}

	//按索引递归设置当前和所有子节点的层
	public static void SetLyaerRecursion(this GameObject go, int layerIndex)
	{
		go.layer = layerIndex;
		foreach (Transform child in go.transform)
		{
			SetLyaerRecursion(child.gameObject, layerIndex);
		}
	}

	//是存在T组件
	public static bool HasComponent<T>(this GameObject go)where T : Component
	{
		return go.GetComponent<T>() != null;
	}

	//获取根节点
	public static GameObject Root(this GameObject go)
	{
		var current = go;
		GameObject result;
		do
		{
			var trans = current.transform.parent;
			if (trans != null)
			{
				result = trans.gameObject;
				current = trans.gameObject;
			}
			else
			{
				result = current;
				current = null;
			}
		} while (current != null);

		return result == go ? null : result;
	}

	//添加子节点
	public static void AddChild(this GameObject go, GameObject childGo)
	{
		Transform child = childGo.transform;
		if (child != null && go != null)
		{
			child.parent = go.transform;
			child.localScale = Vector3.one;
			child.localPosition = Vector3.zero;
			child.localEulerAngles = Vector3.zero;
		}
	}

	/// <summary>
	/// 创建子节点
	/// </summary>
	/// <param name="parent"></param>
	/// <param name="child"></param>
	/// <returns></returns>
	public static GameObject CreateChild(this GameObject parent, GameObject childPrefab)
	{
		GameObject newObj = GameObject.Instantiate(childPrefab);

		newObj.transform.parent = parent.transform;

		newObj.ResetLocal();

		return newObj;
	}

	//给子节点添加脚本
	public static T AddChildCompnent<T>(this GameObject go, string childName) where T : Component
	{
		GameObject searchTranform = null;                //查找特定节点结果

		//查找特定子节点
		searchTranform = FindChild(go, childName);
		//如果查找成功，则考虑如果已经有相同的脚本了，则先删除，否则直接添加。
		if (searchTranform != null)
		{
			//如果已经有相同的脚本了，则先删除
			T[] componentScriptsArray = searchTranform.GetComponents<T>();
			for (int i = 0; i < componentScriptsArray.Length; i++)
			{
				if (componentScriptsArray[i] != null)
				{
				   UnityEngine.Object.Destroy(componentScriptsArray[i]);
				}
			}
			return searchTranform.gameObject.AddComponent<T>();
		}
		else
		{
			return null;
		}
		//如果查找不成功，返回Null.
	}

	//通过递归给子节点添加脚本
	public static T AddChildCompnentRecursion<T>(this GameObject go, string childName) where T : Component
	{
		GameObject searchTranform = null;                //查找特定节点结果
		//查找特定子节点
		searchTranform = FindChildRecursion(go, childName);
		//如果查找成功，则考虑如果已经有相同的脚本了，则先删除，否则直接添加。
		if (searchTranform != null)
		{
			//如果已经有相同的脚本了，则先删除
			T[] componentScriptsArray = searchTranform.GetComponents<T>();
			for (int i = 0; i < componentScriptsArray.Length; i++)
			{
				if (componentScriptsArray[i] != null)
				{
					UnityEngine.Object.Destroy(componentScriptsArray[i]);
				}
			}
			return searchTranform.gameObject.AddComponent<T>();
		}
		else
		{
			return null;
		}
		//如果查找不成功，返回Null.
	}

	//删除所有子节点
	public static void DeleteAllChild(this GameObject go)
	{
		Transform  trans = go.transform;
		for (var i = 0; i < trans.childCount; i++)
		{
			var child = trans.GetChild(i).gameObject;
			UnityEngine.Object.Destroy(child);
		}
	}


	/// <summary>
	/// 删除子节点
	/// </summary>
	/// <param name="father"></param>
	/// <param name="isDeleteHideChild">隐藏的子物体是否需要删除</param>
	public static void DeleteAllChild(this GameObject father, bool isDeleteHideChild = true)
	{
		if (father == null) return;
		foreach (Transform tran in father.transform)
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

	//删除指定节点
	public static bool RemoveChild(this GameObject go,string childName)
	{
	  
		Transform trans = go.transform;
		for (var i = 0; i < trans.childCount; i++)
		{
			var child = trans.GetChild(i).gameObject;
			if(childName==child.name)
			{
				UnityEngine.Object.Destroy(child);
				return true;
			}    
		}
		return false;

		
	}

	//查找子物体
	public static GameObject FindChild(this GameObject go, string childName)
	{
		if (string.IsNullOrEmpty(childName)) return null;

		Transform trans = go.transform;
		for (var i = 0; i < trans.childCount; i++)
		{
			var child = trans.GetChild(i).gameObject;
			if (childName == child.name)
			{
				return child;
			}
		}
		return null;
	}

	//查找子节点组件
	public static T FindChild<T>(this GameObject go, string childName)
	{
		GameObject trans = FindChild(go, childName);
		if(trans!=null)
		{
			return trans.GetComponent<T>();
		}
		return (T)((object)null);
	}

	//通过递归查找子节点
	public static GameObject FindChildRecursion(this GameObject go, string childName)
	{
		Transform resultTrs = go.transform.Find(childName);
		GameObject child = null;
		if (resultTrs == null)
		{
			foreach (Transform trs in go.transform)
			{
				child = FindChildRecursion(trs.gameObject, childName);
				if (child != null)
					return child;
			}
			return null;
			
		}
		else
		{
			return resultTrs.gameObject;
		}

	}


	//通过递归查找子节点组件
	public static T FindChildRecursion<T>(this GameObject go, string childName) where T : Component
	{
		GameObject childGo =FindChildRecursion(go, childName);
		if (childGo != null)
			return childGo.GetComponent<T>();
		return (T)((object)null);
	}

	//获取当前节点的完整路径
	public static string Path(this GameObject gameObject)
	{
		var path = "/" + gameObject.name;
		while (gameObject.transform.parent != null)
		{
			gameObject = gameObject.transform.parent.gameObject;
			path = "/" + gameObject.name + path;
		}
		return path;
	}

	//搜索指定名字和类型的节点
	public static T  FindComponent<T>(this GameObject gameObject, string searchName) where T : Component
	{
		var gos = gameObject.GetComponentsInChildren<T>(true);
		var length = gos.Length;
		for (var i = 0; i < length; i++)
		{
			var local = gos[i];
			if (searchName == local.name)
			{
				return local;
			}
		}
		return null;
	}

	//获取游戏对象的大小 
	public static Vector3 GetObjectSize(this GameObject go)
	{
		Vector3 realSize = Vector3.zero;

		Mesh mesh = go.GetComponent<MeshFilter>().mesh;
		if (mesh == null)
		{
			return realSize;
		}
		// 它模型网格的大小  
		Vector3 meshSize = mesh.bounds.size;
		// 它的放缩  
		Vector3 scale = go.transform.lossyScale;
		// 它在游戏中的实际大小  
		realSize = new Vector3(meshSize.x * scale.x, meshSize.y * scale.y, meshSize.z * scale.z);
		return realSize;
	}

	//复制对象
	public static GameObject CopyGameObject(this GameObject go,GameObject from)
	{
		GameObject newObj = GameObject.Instantiate(from);

		newObj.transform.Reset();

		return newObj;
	}
	/// <summary>
	///打印
	/// </summary>
	/// <param name="go"></param>
	/// <param name="message"></param>
	public static void Log(this GameObject go, object message)
	{
		Debug.Log(message);
	}


	public static RectTransform GetRectTransform(this GameObject go)
	{
		return go.transform as RectTransform;
	}

	/// <summary>
	/// 保证有某个脚本
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="go"></param>
	/// <returns></returns>
	public static T EnsureComponent<T>(this GameObject go)where T : Component
	{
		T result = go.GetComponent<T>();

		if (result == null)
			result = go.AddComponent<T>();

		return result;
	}

	/// <summary>
	/// 规范化(归一化)大小
	/// </summary>
	/// <param name="go"></param>
	public static void NormalizeSize(this GameObject go)
	{
		if (go == null) throw new NullReferenceException();
		go.transform.localPosition = Vector3.zero;
		go.transform.localEulerAngles = Vector3.zero;
		Transform p = go.transform.parent;
		if (p != null)
		{
			Vector3 s = p.lossyScale;
			go.transform.localScale = new Vector3((s.x == 0 ? 0 : 1 / s.x), (s.y == 0 ? 0 : 1 / s.y), (s.z == 0 ? 0 : 1 / s.z));
		}
		else
		{
			go.transform.localScale = Vector3.one;
		}
	}
}
