using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// Unity 将导入到Sprites文件夹内的图片自动设置类型为Sprite
/// </summary>
public class AutoToSprite : AssetPostprocessor
{
    private void OnPostprocessTexture(Texture2D texture)
    {
        if (assetPath.ToLower().IndexOf("/sprites/") != -1)
        {

            Debug.Log("将导入到Sprites文件夹内的图片自动设置类型为Sprite");
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
