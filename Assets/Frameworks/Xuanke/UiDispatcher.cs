using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Xuanke
{
    /* example
     * 
      UIDispatcher.Instance.Dispatch(ConstDefine.UIClassDetailItem_ThemeBtn, new object[] { this });

      UIDispatcher.Instance.Dispatch(ConstDefine.UIStudentMonitor_FinishCallBtn, new object[] { this.gameObject, localVC });
    
    */

    public class UiDispatcher : DispatcherBase<UiDispatcher,object [],string>
    {
        
    }
}

