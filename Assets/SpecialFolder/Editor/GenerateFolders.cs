using UnityEngine;
using System.Collections;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GenerateFolders : MonoBehaviour
{
	#if UNITY_EDITOR
	[MenuItem("Tools/CreateBasicFolder #&_b")]
	private  static void CreateBasicFolder()
	{
		GenerateFolder();
		Debug.Log("Folders Created");
	}

	[MenuItem("Tools/CreateALLFolder")]
	private static void CreateAllFolder()
	{
		GenerateFolder(1);
		Debug.Log("Folders Created");
	}


	private static void GenerateFolder(int flag = 0)
	{   
		// 文件路径
		string prjPath = Application.dataPath + "/";
		Directory.CreateDirectory(prjPath + "lzx/Audio");
		Directory.CreateDirectory(prjPath + "lzx/Prefabs");
		Directory.CreateDirectory(prjPath + "lzx/Materials");        
		Directory.CreateDirectory(prjPath + "lzx/Resources");
		Directory.CreateDirectory(prjPath + "lzx/Scripts");        
		Directory.CreateDirectory(prjPath + "lzx/Textures");
		Directory.CreateDirectory(prjPath + "lzx/Scenes");

		if (1== flag)
		{
			Directory.CreateDirectory(prjPath + "Meshes");
			Directory.CreateDirectory(prjPath + "Shaders");
			Directory.CreateDirectory(prjPath + "GUI");
		}

		AssetDatabase.Refresh();
	}


	#endif


}