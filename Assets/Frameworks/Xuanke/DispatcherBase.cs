using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Xuanke
{
    public class DispatcherBase<T, P, X> : IDisposable
    where T : new()
    where P : class
    {
        #region ����
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }

        public virtual void Dispose()
        {

        }
        #endregion

        //��ť����¼�ί��ԭ��
        public delegate void OnActionHandler(P p);
        public Dictionary<X, List<OnActionHandler>> dic = new Dictionary<X, List<OnActionHandler>>();

        #region AddEventListener ��Ӽ���
        /// <summary>
        /// ��Ӽ���
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        public void AddEventListener(X key, OnActionHandler handler)
        {
            if (dic.ContainsKey(key))
            {
                dic[key].Add(handler);
            }
            else
            {
                List<OnActionHandler> lstHandler = new List<OnActionHandler>();
                lstHandler.Add(handler);
                dic[key] = lstHandler;
            }
        }
        #endregion

        #region RemoveEventListener �Ƴ�����
        /// <summary>
        /// �Ƴ�����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        public void RemoveEventListener(X key, OnActionHandler handler)
        {
            if (dic.ContainsKey(key))
            {
                List<OnActionHandler> lstHandler = dic[key];
                lstHandler.Remove(handler);
                if (lstHandler.Count == 0)
                {
                    dic.Remove(key);
                }
            }
        }
        #endregion

        #region Dispatch �ɷ�
        /// <summary>
        /// �ɷ�
        /// </summary>
        /// <param name="key"></param>
        /// <param name="p"></param>
        public void Dispatch(X key, P p)
        {
            if (dic.ContainsKey(key))
            {
                List<OnActionHandler> lstHandler = dic[key];
                if (lstHandler != null && lstHandler.Count > 0)
                {
                    for (int i = 0; i < lstHandler.Count; i++)
                    {
                        if (lstHandler[i] != null)
                        {
                            lstHandler[i](p);
                        }
                    }
                }
            }
        }

        public void Dispatch(X key)
        {
            Dispatch(key, null);
        }
        #endregion
    }
}
