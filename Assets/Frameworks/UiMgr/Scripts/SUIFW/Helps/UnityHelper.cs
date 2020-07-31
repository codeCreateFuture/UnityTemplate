/***
 * 
 *    Title: "SUIFW" UI框架项目
 *           主题： Unity 帮助脚本
 *    Description: 
 *           功能： 提供程序用户一些常用的功能方法实现，方便程序员快速开发。
 *                  
 *    Date: 2017
 *    Version: 0.1版本
 *    Modify Recoder: 
 *    
 *   
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIFW
{
	public class UnityHelper : MonoBehaviour {
		
		/// <summary>
		/// 查找子节点对象
		/// 内部使用“递归算法”
		/// </summary>
		/// <param name="goParent">父对象</param>
		/// <param name="chiildName">查找的子对象名称</param>
		/// <returns></returns>
		public static Transform FindTheChildNode(GameObject goParent,string chiildName)
		{
			Transform searchTrans = null;                   //查找结果

			searchTrans=goParent.transform.Find(chiildName);
			if (searchTrans==null)
			{
				foreach (Transform trans in goParent.transform)
				{
					searchTrans=FindTheChildNode(trans.gameObject, chiildName);
					if (searchTrans!=null)
					{
						return searchTrans;

					}
				}            
			}
			return searchTrans;
		}


	  
		/// <summary>
		/// 获取子节点（对象）脚本
		/// </summary>
		/// <typeparam name="T">泛型</typeparam>
		/// <param name="goParent">父对象</param>
		/// <param name="childName">子对象名称</param>
		/// <returns></returns>
		public static T GetTheChildNodeComponetScripts<T>(GameObject goParent,string childName) where T:Component
		{
			Transform searchTranformNode = null;            //查找特定子节点

			searchTranformNode = FindTheChildNode(goParent, childName);
			if (searchTranformNode != null)
			{
				return searchTranformNode.gameObject.GetComponent<T>();
			}
			else
			{
				return null;
			}
		}

			 

		/// <summary>
		/// 给子节点添加父对象
		/// </summary>
		/// <param name="parents">父对象的方位</param>
		/// <param name="child">子对象的方法</param>
		public static void AddChildNodeToParentNode(Transform parents, Transform child)
		{
			child.SetParent(parents,false);
			child.localPosition = Vector3.zero;
			child.localScale = Vector3.one;
			child.localEulerAngles = Vector3.zero;
		}


	   
	}
}