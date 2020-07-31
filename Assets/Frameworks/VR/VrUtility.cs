using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VrUtility : MonoBehaviour {


    public void SetUIToForward(Transform cam, Transform ui, float distance = 5f, float height = 5f)
     {
        Vector3 pos = cam.position + cam.forward * distance;
        Quaternion q = Quaternion.LookRotation(cam.forward);
        ui.position = new Vector3(pos.x,height, pos.z);
        ui.rotation = new Quaternion(0, q.y, 0, q.w);
    }

    /// <summary>
    /// vr的多个Canvas下的交互射线穿透问题
    /// </summary>
    /// <param name="gr"></param>
    public void BlockUiRaycast(Transform canvasTran)
    {
        GraphicRaycaster gr = canvasTran.GetComponent<GraphicRaycaster>();
        if (!gr)
        {
            gr.blockingObjects = GraphicRaycaster.BlockingObjects.All;
        }
    }
	
}
