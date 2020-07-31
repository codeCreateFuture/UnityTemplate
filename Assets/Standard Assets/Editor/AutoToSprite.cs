using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// Unity �����뵽Sprites�ļ����ڵ�ͼƬ�Զ���������ΪSprite
/// </summary>
public class AutoToSprite : AssetPostprocessor
{
    private void OnPostprocessTexture(Texture2D texture)
    {
        if (assetPath.ToLower().IndexOf("/sprites/") != -1)
        {

            Debug.Log("�����뵽Sprites�ļ����ڵ�ͼƬ�Զ���������ΪSprite");
        }
            //    TextureImporter textureImporter = (TextureImporter)assetImporter;
            //    textureImporter.textureType = TextureImporterType.Sprite;
            //    textureImporter.spriteImportMode = SpriteImportMode.Single;
            //    textureImporter.alphaIsTransparency = true;
            //    textureImporter.mipmapEnabled = false;
            //}
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.textureType = TextureImporterType.Sprite;
        textureImporter.spriteImportMode = SpriteImportMode.Single;
        textureImporter.alphaIsTransparency = true;
        textureImporter.mipmapEnabled = false;
    }
}
