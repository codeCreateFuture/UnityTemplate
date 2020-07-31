using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

/// <summary>
/// 删除某个文件夹下脚本的命名空间namespace
/// 
/// 存在的问题
/// 1.某个类哪怕没有命名空间但是有"namespace "字样 也会进行处理
/// </summary>
public class DeleteNamespace_editor : ScriptableWizard
{
    //ScriptableWizard类的公有变量都会显示在窗口面板上
    public string folder = "Assets/";

    static float windowWidth = 500f;
    static float windowHeight = 500f;

    void OnEnable()
    {

        if (Selection.activeObject != null)
        {
            string dirPath = AssetDatabase.GetAssetOrScenePath(Selection.activeObject);
            if (File.Exists(dirPath))
            {
                dirPath = dirPath.Substring(0, dirPath.LastIndexOf("/"));
            }
            folder = dirPath;
        }
    }

    [MenuItem("编辑器扩展/Delete Namespace", false, 10)]
    static void CreateWizard()
    {
        DeleteNamespace_editor editor = ScriptableWizard.DisplayWizard<DeleteNamespace_editor>("Delete Namespace", "删除脚本命名空间", "取消");
        editor.minSize = new Vector2(windowWidth, windowHeight);
    }

    public void OnWizardCreate()
    {
        //save settting

        if (!string.IsNullOrEmpty(folder))
        {

            Debug.Log(Path.GetFullPath(".") + ":" + Path.DirectorySeparatorChar);
            List<string> filesPaths = new List<string>();
            filesPaths.AddRange(
                Directory.GetFiles(Path.GetFullPath(".") + Path.DirectorySeparatorChar + folder, "*.cs", SearchOption.AllDirectories)
            );

            int currentLineIndex = 0;
            int namespaceLineIndex = 0;
            int counter = -1;
            foreach (string filePath in filesPaths)
            {

                EditorUtility.DisplayProgressBar("delete Namespace", filePath, counter / (float)filesPaths.Count);
                counter++;

                string contents = File.ReadAllText(filePath);

                string result = "";
                bool havsNS = contents.Contains("namespace ");
                if (!havsNS) return;



                using (TextReader reader = new StringReader(contents))
                {


                    while (reader.Peek() != -1)
                    {
                        string line = reader.ReadLine();
                        currentLineIndex++;

                        if (line.Contains("namespace "))
                        {
                            namespaceLineIndex = currentLineIndex;
                            continue;
                        }

                        //处理namespace 和{不在同一行的问题
                        if (namespaceLineIndex != 0)
                        {
                            if ((namespaceLineIndex + 1) == currentLineIndex)
                            {
                                if (line.Contains("{"))
                                {
                                    if (line.IndexOf("{") == 0)
                                    {
                                        line = line.Remove(0, 1);
                                    }
                                }
                            }
                        }

                        int tabStrIndex = line.IndexOf("\t");
                        if (tabStrIndex == 0)
                        {

                            line = line.Remove(0, 1);//去掉制表符("\t") 制表符占一位
                        }

                        result += line + "\n";



                    }
                    reader.Close();
                }

                int lastIndex = result.LastIndexOf('}');
                result = result.Remove(lastIndex, 1);
                File.WriteAllText(filePath, result);
            }


            EditorUtility.ClearProgressBar();
            AssetDatabase.Refresh();
        }
    }
}
