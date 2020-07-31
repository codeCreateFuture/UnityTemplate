using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Recursion �ݹ�
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
	/// ����ָ��·�����ӽڵ㲻������ͬ���ĸ��ڵ�  
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
	/// ����ָ��·�����ӽڵ�������ͬ���ĸ��ڵ�
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

	//��ȡ�ڵ�㼶���
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

	//���õ�ǰ�ڵ�Ĳ�
	public static void SetLayer(this GameObject go, LayerMask layer)
	{
		go.layer = layer;
	}

	//�������ݹ����õ�ǰ�������ӽڵ�Ĳ�
	public static void SetLayerRecursion(this GameObject go, LayerMask layer)
	{
		go.layer = layer;
		foreach (Transform child in go.transform)
		{
			SetLayerRecursion(child.gameObject, layer);
		}
	}

	//�������ݹ����õ�ǰ�������ӽڵ�Ĳ�
	public static void SetLyaerRecursion(this GameObject go, int layerIndex)
	{
		go.layer = layerIndex;
		foreach (Transform child in go.transform)
		{
			SetLyaerRecursion(child.gameObject, layerIndex);
		}
	}

	//�Ǵ���T���
	public static bool HasComponent<T>(this GameObject go)where T : Component
	{
		return go.GetComponent<T>() != null;
	}

	//��ȡ���ڵ�
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

	//����ӽڵ�
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
	/// �����ӽڵ�
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

	//���ӽڵ���ӽű�
	public static T AddChildCompnent<T>(this GameObject go, string childName) where T : Component
	{
		GameObject searchTranform = null;                //�����ض��ڵ���

		//�����ض��ӽڵ�
		searchTranform = FindChild(go, childName);
		//������ҳɹ�����������Ѿ�����ͬ�Ľű��ˣ�����ɾ��������ֱ����ӡ�
		if (searchTranform != null)
		{
			//����Ѿ�����ͬ�Ľű��ˣ�����ɾ��
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
		//������Ҳ��ɹ�������Null.
	}

	//ͨ���ݹ���ӽڵ���ӽű�
	public static T AddChildCompnentRecursion<T>(this GameObject go, string childName) where T : Component
	{
		GameObject searchTranform = null;                //�����ض��ڵ���
		//�����ض��ӽڵ�
		searchTranform = FindChildRecursion(go, childName);
		//������ҳɹ�����������Ѿ�����ͬ�Ľű��ˣ�����ɾ��������ֱ����ӡ�
		if (searchTranform != null)
		{
			//����Ѿ�����ͬ�Ľű��ˣ�����ɾ��
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
		//������Ҳ��ɹ�������Null.
	}

	//ɾ�������ӽڵ�
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
	/// ɾ���ӽڵ�
	/// </summary>
	/// <param name="father"></param>
	/// <param name="isDeleteHideChild">���ص��������Ƿ���Ҫɾ��</param>
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

	//ɾ��ָ���ڵ�
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

	//����������
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

	//�����ӽڵ����
	public static T FindChild<T>(this GameObject go, string childName)
	{
		GameObject trans = FindChild(go, childName);
		if(trans!=null)
		{
			return trans.GetComponent<T>();
		}
		return (T)((object)null);
	}

	//ͨ���ݹ�����ӽڵ�
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


	//ͨ���ݹ�����ӽڵ����
	public static T FindChildRecursion<T>(this GameObject go, string childName) where T : Component
	{
		GameObject childGo =FindChildRecursion(go, childName);
		if (childGo != null)
			return childGo.GetComponent<T>();
		return (T)((object)null);
	}

	//��ȡ��ǰ�ڵ������·��
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

	//����ָ�����ֺ����͵Ľڵ�
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

	//��ȡ��Ϸ����Ĵ�С 
	public static Vector3 GetObjectSize(this GameObject go)
	{
		Vector3 realSize = Vector3.zero;

		Mesh mesh = go.GetComponent<MeshFilter>().mesh;
		if (mesh == null)
		{
			return realSize;
		}
		// ��ģ������Ĵ�С  
		Vector3 meshSize = mesh.bounds.size;
		// ���ķ���  
		Vector3 scale = go.transform.lossyScale;
		// ������Ϸ�е�ʵ�ʴ�С  
		realSize = new Vector3(meshSize.x * scale.x, meshSize.y * scale.y, meshSize.z * scale.z);
		return realSize;
	}

	//���ƶ���
	public static GameObject CopyGameObject(this GameObject go,GameObject from)
	{
		GameObject newObj = GameObject.Instantiate(from);

		newObj.transform.Reset();

		return newObj;
	}
	/// <summary>
	///��ӡ
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
	/// ��֤��ĳ���ű�
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
	/// �淶��(��һ��)��С
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
