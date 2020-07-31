using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// 设置命名空间名字 窗口
/// </summary>
public class SetNamespaceWindow_editor : EditorWindow
{

    private readonly static string namespaceEditorPrefs = "namespaceEditorPrefs";

    public static string namespaceName
    {
        get
        {
            var retNamespace = EditorPrefs.GetString(namespaceEditorPrefs, "DefaultNamespace");

            return string.IsNullOrEmpty(retNamespace) ? "DefaultNamespace" : retNamespace;
        }
        set { EditorPrefs.SetString(namespaceEditorPrefs, value); }

        //unity 2018.4.8版本 set => EditorPrefs.SetString(namespaceEditorPrefs, value);
    }

    [MenuItem("编辑器扩展/set Namespace name %t")]
    static void Open()
    {
        var window = GetWindow<SetNamespaceWindow_editor>();
        _name = namespaceName;
        window.Show();
    }

    static string _name;
    private void OnGUI()
    {
       
        GUILayout.BeginHorizontal();
        GUILayout.Label("set namespace name:");
        _name = GUILayout.TextField(_name);
        GUILayout.EndHorizontal();
    }

    private void OnDestroy()
    {     
        namespaceName = _name;

        Debug.Log(string.Format("设置的命名空间的名字是：{0} ", namespaceName));
    }
}
