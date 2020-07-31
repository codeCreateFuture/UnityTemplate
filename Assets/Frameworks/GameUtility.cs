
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


//  mFileName=mFileName.Replace('/','\\');     //保存的路径要转换成加载路径
//downloadTexture.url = @"file://"+mFileName;  //加上file://前缀才可以通过www加载

//解决输出中文时乱码的编码是： Unicode -代码页1200

/// <summary>
/// 游戏工具类
/// </summary>
public static class GameUtility
{


	/*
	 * 
	/// <summary>
	/// 查找本游戏物体下的特定名称的子物体系统，并将其返回
	/// </summary>
	/// <param name="_target">要在其中进行查找的父物体</param>
	/// <param name="_childName">待查找的子物体名称，可以是"/"分割的多级名称</param>
	/// <returns></returns>
	public static Transform FindDeepChild(this GameObject _target, string _childName)
	{
		Transform resultTrs = null;
		resultTrs = _target.transform.Find(_childName);
		if (resultTrs == null)
		{
			foreach (Transform trs in _target.transform)
			{
				resultTrs = trs.gameObject.FindDeepChild(_childName);
				if (resultTrs != null)
					return resultTrs;
			}
		}
		return resultTrs;
	}
 
	/// <summary>
	/// 查找本游戏物体下的特定名称的子物体系统的特定组件，并将其返回
	/// </summary>
	/// <param name="_target">要在其中进行查找的父物体</param>
	/// <param name="_childName">待查找的子物体名称，可以是"/"分割的多级名称</param>
	/// <returns>返回找到的符合条件的第一个自物体下的指定组件</returns>
	public static T FindDeepChild<T>(this GameObject _target, string _childName) where T : Component
	{
		Transform resultTrs = _target.FindDeepChild(_childName);
		if (resultTrs != null)
			return resultTrs.gameObject.GetComponent<T>();
		return (T)((object)null);
	}
	/// <summary>
	/// 新建childObjectName命名的游戏物体并将其指定的子系统加入到本系统中
	/// </summary>
	/// <param name="target">要加入到的目标系统</param>
	/// <param name="childObjectName">待加入的子物体名称</param>
	public static Transform AddChild(this Transform target, string childObjectName)
	{
		GameObject go = new GameObject(childObjectName);
		target.AddChild(go.transform);
		return go.transform;
	}
	/// <summary>
	/// 将child指定的子系统加入到本系统中
	/// </summary>
	/// <param name="target">要加入到的目标系统</param>
	/// <param name="child">待加入的系统</param>
	public static void AddChild(this Transform target, Transform child)
	{
		child.SetParent(target);
		child.localScale = Vector3.one;
		child.localPosition = Vector3.zero;
		child.localEulerAngles = Vector3.zero;
 
		ChangeChildLayer(child, target.gameObject.layer);
	}
	/// <summary>
	/// 递归将本系统中的所有子系统的层级都指定为特定层级
	/// </summary>
	/// </summary>
	/// <param name="t">要修改的目标系统</param>
	/// <param name="layer">要指定的层级</param>
	private static void ChangeChildLayer(Transform t, int layer)
	{
		t.gameObject.layer = layer;
		foreach (Transform child in t)
		{
			child.gameObject.layer = layer;
			ChangeChildLayer(child, layer);
		}
	}
*/








	public static IEnumerator Wait(float seconds, Action callback)
	{
		yield return (object)new WaitForSeconds(seconds);
		if (callback != null) callback();
	}


	public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)
	{

		yield return new WaitForSeconds(delaySeconds);
		if (action != null) action();

	}
	/// <summary>
	/// 查找子节点
	/// </summary>
	public static Transform FindDeepChild(GameObject _target, string _childName)
	{
		Transform resultTrs = null;
		resultTrs = _target.transform.Find(_childName);
		if (resultTrs == null)
		{
			foreach (Transform trs in _target.transform)
			{
				resultTrs = GameUtility.FindDeepChild(trs.gameObject, _childName);
				if (resultTrs != null)
					return resultTrs;
			}
		}
		return resultTrs;
	}

	/// <summary>
	/// 删除子节点
	/// </summary>
	/// <param name="father"></param>
	/// <param name="isDeleteHideChild">隐藏的子物体是否需要删除</param>
	public static void DeleteChild(Transform father, bool isDeleteHideChild)
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
	/// 查找子节点脚本
	/// </summary>
	public static T FindDeepChild<T>(GameObject _target, string _childName) where T : Component
	{
		Transform resultTrs = GameUtility.FindDeepChild(_target, _childName);
		if (resultTrs != null)
			return resultTrs.gameObject.GetComponent<T>();
		return (T)((object)null);
	}
	/// <summary>
	/// 修改子节点Layer  NGUITools.SetLayer();
	/// </summary>
	public static void ChangeChildLayer(Transform t, int layer)
	{
		if (null != t)
		{
			t.gameObject.layer = layer;
			for (int i = 0; i < t.childCount; ++i)
			{
				Transform child = t.GetChild(i);
				child.gameObject.layer = layer;
				ChangeChildLayer(child, layer);
			}
		}
	}


	/// <summary>
	/// 添加子节点
	/// </summary>
	public static void AddChildToTarget(Transform target, Transform child)
	{
		if (child != null && target != null)
		{
			child.parent = target;
			child.localScale = Vector3.one;
			child.localPosition = Vector3.zero;
			child.localEulerAngles = Vector3.zero;

			ChangeChildLayer(child, target.gameObject.layer);
		}
	}
	/// <summary>
	/// 创建子物体
	/// </summary>
	/// <param name="parent"></param>
	/// <param name="child"></param>
	/// <returns></returns>
	public static GameObject CreateChild(GameObject parent, GameObject child)
	{
		GameObject newObj = GameObject.Instantiate(child);

		newObj.transform.parent = parent.transform;

		newObj.transform.localPosition = Vector3.zero;
		newObj.transform.localRotation = Quaternion.identity;
		newObj.transform.localScale = Vector3.one;

		return newObj;
	}



	/// <summary>
	/// 某个点在物体的哪个方向(面)上
	/// </summary>
	/// <param name="raycastHitGameObject">射线检测到的物体</param>
	/// <param name="hitPoint">射线与物体交叉的位置</param>
	/// <returns></returns>
	public static Vector3 GetDirect(GameObject raycastHitGameObject, Vector3 hitPoint)
	{

		//转换为物体本身的坐标
		Vector3 _localPos = raycastHitGameObject.transform.InverseTransformPoint(hitPoint).normalized;
		Vector3 localPos = new Vector3(Mathf.Abs(_localPos.x), Mathf.Abs(_localPos.y), Mathf.Abs(_localPos.z));
		if (localPos.x >= localPos.y && localPos.x >= localPos.z)
		{
			_localPos = new Vector3(_localPos.x > 0 ? 1 : -1, 0, 0);
		}
		else if (localPos.y > localPos.x && localPos.y >= localPos.z)
		{
			_localPos = new Vector3(0, _localPos.y > 0 ? 1 : -1, 0);
		}
		else
		{
			_localPos = new Vector3(0, 0, _localPos.z > 0 ? 1 : -1);
		}
		return _localPos;
	}

	/// <summary>
	/// 规范化(归一化)大小
	/// </summary>
	/// <param name="go"></param>
	public static void NormalizeSize(GameObject go)
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


	/// <summary>
	/// 取得方法的名字
	/// </summary>
	public static void MethodName()
	{
		Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
	}


	static public void ScaleParticleSystem(this Transform root, Vector3 scale)
	{
		ScaleParticleSystemRecursivelyInternal(root, scale);
	}

	static public void ScaleParticleSystemRecursivelyInternal(this Transform root, Vector3 scale)
	{
		ParticleSystem particleSystem = root.GetComponent<ParticleSystem>();

		if (particleSystem != null)
		{
			particleSystem.startSize *= scale.x;
			particleSystem.startSpeed *= scale.x;
		}

		foreach (Transform child in root)
		{
			ScaleParticleSystemRecursivelyInternal(child, scale);
		}
	}

	static public bool TryParseColor(string val, out Color clr)
	{
		clr = Color.black;

		val = val.Replace('\"', ' ');
		val = val.Trim();

		string[] splits = val.Split(',');

		if (splits.Length != 4)
			return false;

		try
		{
			clr.r = float.Parse(splits[0]);
			clr.g = float.Parse(splits[1]);
			clr.b = float.Parse(splits[2]);
			clr.a = float.Parse(splits[3]);
		}
		catch
		{
			return false;
		}

		return true;
	}

	static public bool TryParseVector2(string val, out Vector2 vec2)
	{
		vec2 = Vector2.zero;

		val = val.Replace('\"', ' ');
		val = val.Trim();

		string[] splits = val.Split(',');

		if (splits.Length != 2)
			return false;

		try
		{
			vec2.x = float.Parse(splits[0]);
			vec2.y = float.Parse(splits[1]);
		}
		catch
		{
			return false;
		}

		return true;
	}

	static public bool TryParseVector3(string val, out Vector3 vec3)
	{
		vec3 = Vector3.zero;

		val = val.Replace('\"', ' ');
		val = val.Trim();

		string[] splits = val.Split(',');

		if (splits.Length != 3)
			return false;

		try
		{
			vec3.x = float.Parse(splits[0]);
			vec3.y = float.Parse(splits[1]);
			vec3.z = float.Parse(splits[2]);
		}
		catch
		{
			return false;
		}

		return true;
	}

	static public bool TryParseVector4(string val, out Vector4 vec4)
	{
		vec4 = Vector4.zero;

		val = val.Replace('\"', ' ');
		val = val.Trim();

		string[] splits = val.Split(',');

		if (splits.Length != 4)
			return false;

		try
		{
			vec4.x = float.Parse(splits[0]);
			vec4.y = float.Parse(splits[1]);
			vec4.z = float.Parse(splits[2]);
			vec4.w = float.Parse(splits[3]);
		}
		catch
		{
			return false;
		}

		return true;
	}

	static public bool TryParseQuaternion(string val, out Quaternion quat)
	{
		quat = Quaternion.identity;

		val = val.Replace('\"', ' ');
		val = val.Trim();

		string[] splits = val.Split(',');

		if (splits.Length != 4)
			return false;

		try
		{
			quat.x = float.Parse(splits[0]);
			quat.y = float.Parse(splits[1]);
			quat.z = float.Parse(splits[2]);
			quat.w = float.Parse(splits[3]);
		}
		catch
		{
			return false;
		}

		return true;
	}



	public static void SetActive(GameObject target, bool bActive)
	{
#if (!UNITY_3_5)
		target.SetActive(bActive);
#else
		target.active = bActive;
#endif
	}

	public static Material ChangeMeshMaterial(Transform t, Material newMat)
	{
		MeshRenderer[] ren = t.GetComponentsInChildren<MeshRenderer>(true);
		Material reMat = null;
		for (int n = 0; n < ren.Length; n++)
		{
			reMat = ren[n].material;
			ren[n].material = newMat;
		}
		return reMat;
	}


	public static void ChangeSkinnedMeshColor(Transform t, Color color)
	{
		SkinnedMeshRenderer[] ren = t.GetComponentsInChildren<SkinnedMeshRenderer>(true);
		for (int n = 0; n < ren.Length; n++)
			ren[n].material.color = color;
	}

	public static void ChangeMeshColor(Transform t, Color color)
	{
		MeshRenderer[] ren = t.GetComponentsInChildren<MeshRenderer>(true);
		for (int n = 0; n < ren.Length; n++)
			ren[n].material.color = color;
	}

	public static void ChangeSkinnedMeshAlpha(Transform t, float alpha)
	{
		SkinnedMeshRenderer[] ren = t.GetComponentsInChildren<SkinnedMeshRenderer>(true);
		for (int n = 0; n < ren.Length; n++)
		{
			Color al = ren[n].material.color;
			al.a = alpha;
			ren[n].material.color = al;
		}
	}

	public static void ChangeMeshAlpha(Transform t, float alpha)
	{
		MeshRenderer[] ren = t.GetComponentsInChildren<MeshRenderer>(true);
		for (int n = 0; n < ren.Length; n++)
		{
			Color al = ren[n].material.color;
			al.a = alpha;
			ren[n].material.color = al;
		}
	}

	public static void ChangeLayerWithChild(GameObject rootObj, int nLayer)
	{
		if (rootObj == null)
			return;
		rootObj.layer = nLayer;
		for (int n = 0; n < rootObj.transform.childCount; n++)
			ChangeLayerWithChild(rootObj.transform.GetChild(n).gameObject, nLayer);
	}

	public static void GetMeshInfo(GameObject selObj, bool bInChildren, out int nVertices, out int nTriangles, out int nMeshCount)
	{
		Component[] skinnedMeshes;
		Component[] meshFilters;

		nVertices = 0;
		nTriangles = 0;
		nMeshCount = 0;

		if (selObj == null)
			return;

		if (bInChildren)
		{
			skinnedMeshes = selObj.GetComponentsInChildren(typeof(SkinnedMeshRenderer));
			meshFilters = selObj.GetComponentsInChildren(typeof(MeshFilter));
		}
		else
		{
			skinnedMeshes = selObj.GetComponents(typeof(SkinnedMeshRenderer));
			meshFilters = selObj.GetComponents(typeof(MeshFilter));
		}

		ArrayList totalMeshes = new ArrayList(meshFilters.Length + skinnedMeshes.Length);

		for (int meshFiltersIndex = 0; meshFiltersIndex < meshFilters.Length; meshFiltersIndex++)
		{
			MeshFilter meshFilter = (MeshFilter)meshFilters[meshFiltersIndex];
			totalMeshes.Add(meshFilter.sharedMesh);
		}

		for (int skinnedMeshIndex = 0; skinnedMeshIndex < skinnedMeshes.Length; skinnedMeshIndex++)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)skinnedMeshes[skinnedMeshIndex];
			totalMeshes.Add(skinnedMeshRenderer.sharedMesh);
		}

		for (int i = 0; i < totalMeshes.Count; i++)
		{
			Mesh mesh = (Mesh)totalMeshes[i];
			if (mesh != null)
			{
				nVertices += mesh.vertexCount;
				nTriangles += mesh.triangles.Length / 3;
				nMeshCount++;
			}
		}
	}

	public static void GetMeshInfo(Mesh mesh, out int nVertices, out int nTriangles, out int nMeshCount)
	{
		nVertices = 0;
		nTriangles = 0;
		nMeshCount = 0;

		if (mesh == null)
			return;

		if (mesh != null)
		{
			nVertices += mesh.vertexCount;
			nTriangles += mesh.triangles.Length / 3;
			nMeshCount++;
		}
	}

	public static void InitWorldScale(Transform dst)
	{
		// (System.Single.IsInfinity(dst.lossyScale.x)
		dst.localScale = new Vector3(1, 1, 1);
		dst.localScale = new Vector3((dst.lossyScale.x == 0 ? 1 : 1 / dst.lossyScale.x),
									  (dst.lossyScale.y == 0 ? 1 : 1 / dst.lossyScale.y),
									  (dst.lossyScale.z == 0 ? 1 : 1 / dst.lossyScale.z));
	}

	public static void CopyLossyToLocalScale(Vector3 srcLossyScale, Transform dst)
	{
		// error dst.lossyScale.x == 0
		dst.localScale = new Vector3(1, 1, 1);
		dst.localScale = new Vector3((dst.lossyScale.x == 0 ? srcLossyScale.x : srcLossyScale.x / (dst.lossyScale.x)),
									 (dst.lossyScale.y == 0 ? srcLossyScale.y : srcLossyScale.y / (dst.lossyScale.y)),
									 (dst.lossyScale.z == 0 ? srcLossyScale.z : srcLossyScale.z / (dst.lossyScale.z)));
	}


#if Ngui

	/// <summary>
	/// 根据最小depth设置目标所有Panel深度，从小到大
	/// </summary>
	/// 
	private class CompareSubPanels : IComparer<UIPanel>
		{
			public int Compare(UIPanel left, UIPanel right)
			{
				return left.depth - right.depth;
			}
		}
		/// <summary>
		/// 设置obj最小的depth
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="depth"></param>
		public static void SetTargetMinPanel(GameObject obj, int depth)
		{
			List<UIPanel> lsPanels = GetPanelSorted(obj, true);
			if (lsPanels != null)
			{
				int i = 0;
				while (i < lsPanels.Count)
				{
					lsPanels[i].depth = depth + i;
					i++;
				}
			}
		}

		/// <summary>
		/// 获得指定目标最大depth值
		/// </summary>
		public static int GetMaxTargetDepth(GameObject obj, bool includeInactive = false)
		{
			int minDepth = -1;
			List<UIPanel> lsPanels = GetPanelSorted(obj, includeInactive);
			if(lsPanels != null)
				return lsPanels[lsPanels.Count - 1].depth;
			return minDepth;
		}

		/// <summary>
		/// 返回最大或者最小Depth界面
		/// </summary>
		public static GameObject GetPanelDepthMaxMin(GameObject target, bool maxDepth, bool includeInactive)
		{
			List<UIPanel> lsPanels = GetPanelSorted(target, includeInactive);
			if(lsPanels != null)
			{
				if (maxDepth)
					return lsPanels[lsPanels.Count - 1].gameObject;
				else
					return lsPanels[0].gameObject;
			}
			return null;
		}

		private static List<UIPanel> GetPanelSorted(GameObject target, bool includeInactive = false)
		{
			UIPanel[] panels = target.transform.GetComponentsInChildren<UIPanel>(includeInactive);
			if (panels.Length > 0)
			{
				List<UIPanel> lsPanels = new List<UIPanel>(panels);
				lsPanels.Sort(new CompareSubPanels());
				return lsPanels;
			}
			return null;
		}

	   

	  

		/// <summary>
		/// 给目标添加Collider背景
		/// </summary>
		public static void AddColliderBgToTarget(GameObject target, string maskName, UIAtlas altas, bool isTransparent)
		{
			// 添加UIPaneldepth最小上面
			// 保证添加的Collider放置在屏幕中间
			Transform windowBg = GameUtility.FindDeepChild(target, "WindowBg");
			if (windowBg == null)
			{
				GameObject targetParent = GetPanelDepthMaxMin(target, false, true);
				if (targetParent == null)
					targetParent = target;

				windowBg = (new GameObject("WindowBg")).transform;
				AddChildToTarget(targetParent.transform, windowBg);
			}

			Transform bg = GameUtility.FindDeepChild(target, "WindowColliderBg(Cool)");
			if (bg == null)
			{
				// add sprite or widget to ColliderBg gameobject
				UIWidget widget = null;
				if (!isTransparent)
					widget = NGUITools.AddSprite(windowBg.gameObject, altas, maskName);
				else
					widget = NGUITools.AddWidget<UIWidget>(windowBg.gameObject);

				widget.name = "WindowColliderBg(Cool)";
				bg = widget.transform;
				
				// fill the screen
				UIStretch stretch = bg.gameObject.AddComponent<UIStretch>();
				stretch.style = UIStretch.Style.Both;
				// set relative size bigger
				stretch.relativeSize = new Vector2(1.5f, 1.5f);

				// set a lower depth
				widget.depth = -5;

				// set alpha
				widget.alpha = 0.6f;

				// add collider
				NGUITools.AddWidgetCollider(bg.gameObject);

			}
		}
#endif
}
