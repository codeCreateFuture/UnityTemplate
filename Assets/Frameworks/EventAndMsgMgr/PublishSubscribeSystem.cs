using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public delegate void MyAction();
public delegate void MyAction<T1>(T1 t1);
public delegate void MyAction<T1, T2>(T1 t1, T2 t2);
public delegate void MyAction<T1, T2, T3>(T1 t1, T2 t2, T3 t3);
public delegate void MyAction<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4);
public delegate void MyAction<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
public delegate void MyAction<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
public delegate void MyAction<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
public delegate void MyAction<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
public delegate void MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
public delegate void MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10);
public delegate void MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11);
public delegate void MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12);
public delegate void MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13);
public delegate void MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14);
public delegate void MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15);
public delegate void MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16);
public delegate R MyFunc<out R>();
public delegate R MyFunc<T1, out R>(T1 t1);
public delegate R MyFunc<T1, T2, out R>(T1 t1, T2 t2);
public delegate R MyFunc<T1, T2, T3, out R>(T1 t1, T2 t2, T3 t3);
public delegate R MyFunc<T1, T2, T3, T4, out R>(T1 t1, T2 t2, T3 t3, T4 t4);
public delegate R MyFunc<T1, T2, T3, T4, T5, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
public delegate R MyFunc<T1, T2, T3, T4, T5, T6, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
public delegate R MyFunc<T1, T2, T3, T4, T5, T6, T7, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
public delegate R MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
public delegate R MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
public delegate R MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10);
public delegate R MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11);
public delegate R MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12);
public delegate R MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13);
public delegate R MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14);
public delegate R MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15);
public delegate R MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, out R>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16);
public class ProxyPublishData
{
    public string m_EventName;
    public string m_Group;
    public object[] m_Args;
}
/// <summary>
/// 消息系统
/// </summary>
public class PublishSubscribeSystem
{

    private Dictionary<string, Delegate> subscribers_ = new Dictionary<string, Delegate>();
    private class ReceiptInfo
    {
        public string name_;
        public Delegate delegate_;
        public ReceiptInfo() { }
        public ReceiptInfo(string n, Delegate d)
        {
            name_ = n;
            delegate_ = d;
        }
    }

    public object Subscribe(string ev_name, string group, MyAction subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0>(string ev_name, string group, MyAction<T0> subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0, T1>(string ev_name, string group, MyAction<T0, T1> subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0, T1, T2>(string ev_name, string group, MyAction<T0, T1, T2> subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0, T1, T2, T3>(string ev_name, string group, MyAction<T0, T1, T2, T3> subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0, T1, T2, T3, T4>(string ev_name, string group, MyAction<T0, T1, T2, T3, T4> subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0, T1, T2, T3, T4, T5>(string ev_name, string group, MyAction<T0, T1, T2, T3, T4, T5> subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0, T1, T2, T3, T4, T5, T6>(string ev_name, string group, MyAction<T0, T1, T2, T3, T4, T5, T6> subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0, T1, T2, T3, T4, T5, T6, T7>(string ev_name, string group, MyAction<T0, T1, T2, T3, T4, T5, T6, T7> subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0, T1, T2, T3, T4, T5, T6, T7, T8>(string ev_name, string group, MyAction<T0, T1, T2, T3, T4, T5, T6, T7, T8> subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string ev_name, string group, MyAction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string ev_name, string group, MyAction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> subscriber) { return AddSubscriber(ev_name, group, subscriber); }
    public object Subscribe<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string ev_name, string group, MyAction<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> subscriber) { return AddSubscriber(ev_name, group, subscriber); }

    public void Unsubscribe(object receipt)
    {
        ReceiptInfo r = receipt as ReceiptInfo;
        Delegate d;
        if (null != r && subscribers_.TryGetValue(r.name_, out d))
        {
            subscribers_[r.name_] = Delegate.Remove(d, r.delegate_);
        }

    }

    public void Publish(string ev_name, string group, params object[] parameters)
    {
        try
        {

            Delegate d;
            string key = group + '#' + ev_name;

            if (subscribers_.TryGetValue(key, out d))
            {
                if (null == d)
                {
                    subscribers_.Remove(key);
                }
                else
                {
                    d.DynamicInvoke(parameters);
                }
            }
        }
        catch (Exception ex)
        {
            //完蛋了，报错
        }
    }

    private object AddSubscriber(string ev_name, string group, Delegate d)
    {
        Delegate source;
        string key = group + '#' + ev_name;
        if (subscribers_.TryGetValue(key, out source))
        {
            if (null != source)
                source = Delegate.Combine(source, d);
            else
                source = d;
        }
        else
        {
            source = d;
        }
        subscribers_[key] = source;
        return new ReceiptInfo(key, d);
    }


}
