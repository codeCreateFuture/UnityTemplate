using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AsynLoading
{
    public class TwoScene : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            // LoadingManager.Instance.CloseLoadSence();
            AsynSceneListener.dispatchEvent(AsynSceneEvent.CloseLoadSence, null);
            Debug.Log("twoScene");

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnClick()
        {
            AsynSceneMgr.LoadScene("AsynOne");
        }
    }
}
