using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[HelpURL("http://www.baidu.com")]
[AddComponentMenu("Learning/Peoplep")]
public class EditorNote : MonoBehaviour
{


    [Header("BaseInfo")]
    [Multiline(5)]
    public string name;

    [Range(-2, 2)]
    public int age;


    [Space(100)]
    [Tooltip("用于设置性别")]
    public string sex;

    [ContextMenu("OutputInfo")]
    void OutputInfoo()
    {
        Debug.Log(name + " " + age);
    }
}
