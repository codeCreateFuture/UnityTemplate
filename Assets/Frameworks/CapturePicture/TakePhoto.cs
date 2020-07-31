using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{

    public Camera arcamera;//需要渲染的摄像头  

    public Texture2D _logo;//水印  


    public RawImage img;
    public void ScreenPicture()
    {
        
       img.texture= Capture(arcamera, new Rect(0, 0, Screen.width, Screen.height));
    }

    Texture2D Capture(Camera camera, Rect rect)
    {
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 3);
        camera.targetTexture = rt;
        camera.Render();

        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.ARGB32, false);

        Texture2D _tex = _logo;

        screenShot.ReadPixels(rect, 0, 0);

        //合成水印和Camera渲染的图片  
        for (int i = 0; i < _tex.width; i++)
        {
            for (int j = 0; j < _tex.height; j++)
            {
                if (_tex.GetPixel(i, j).a > 0.5f)
                {
                    screenShot.SetPixel((int)( i + rect.width - _tex.width ), j, _tex.GetPixel(i, j));
                }
            }
        }
        screenShot.Apply();
        camera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Application.persistentDataPath + System.DateTime.Now.ToString("yyyyMdHms")+".png";
        print(filename);
        System.IO.File.WriteAllBytes(filename, bytes);

        return screenShot;
    }


    void OnGUI()
    {
        if (GUILayout.Button("水印", GUILayout.Height(120)))
        {
            ScreenPicture();
        }
    }
}
