using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class BehaviourRegistMsg : MonoBehaviour {

    List<MsgRecord> mMsgRecorder = new List<MsgRecord>();
    private class MsgRecord
    {
        private static readonly Stack<MsgRecord> mMsgRecordPool = new
        Stack<MsgRecord>();
        public static MsgRecord Allocate(string msgName, System.Action<object>onMsgReceived)
        {
            MsgRecord retMsgRecord = null;
            retMsgRecord = mMsgRecordPool.Count > 0 ? mMsgRecordPool.Pop(): new MsgRecord();
            retMsgRecord.Name = msgName;
            retMsgRecord.OnMsgReceived = onMsgReceived;
            return retMsgRecord;
        }
        public void Recycle()
        {
            Name = null;
            OnMsgReceived = null;
            mMsgRecordPool.Push(this);
        }
        public string Name;
        public System.Action<object> OnMsgReceived;
    }
    protected void RegisterMsg(string msgName, System.Action<object>onMsgReceived)
    {
       // EventListener.registerEvent(msgName, onMsgReceived);
      //  mMsgRecorder.Add(MsgRecord.Allocate(msgName, onMsgReceived));
    }
    private void OnDestroy()
    {
        OnBeforeDestroy();
        foreach (var msgRecord in mMsgRecorder)
        {
           // EventListener.deleteEvent(msgRecord.Name, msgRecord.OnMsgReceived);
            msgRecord.Recycle();
        }
        mMsgRecorder.Clear();
    }
    protected abstract void OnBeforeDestroy();
}
