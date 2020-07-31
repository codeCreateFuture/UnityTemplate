using UnityEngine;
using System.Collections;

public class DontDel : MonoBehaviour {


    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
