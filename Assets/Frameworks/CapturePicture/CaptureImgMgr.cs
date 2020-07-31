using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class CaptureImgMgr : MonoBehaviour {


    /// <summary>
    /// 保存的截图文件名称
    /// </summary>
    string imgFolder = "screenShot";

    /// <summary>
    /// 文件路径
    /// </summary>
    [HideInInspector]
    public string imgPath;


    public static CaptureImgMgr Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
    
        
        Debug.Log(Application.persistentDataPath);
        //初始化路径  
        CreateFolder(imgFolder);

        imgPath = Application.persistentDataPath + "/" + imgFolder + "/";


    }
    /// <summary>
    /// 创建文件夹
    /// </summary>
    /// <param name="folder"></param>
    void CreateFolder(string folder)
    {
        string fullName = Application.persistentDataPath + "/" + folder;
        try
        {
            bool flag = !Directory.Exists(fullName);
            if (flag)
            {
                Directory.CreateDirectory(fullName);
            }
        }
        catch (Exception ex2)
        {
            Debug.Log("create folder failure");
            return;
        }
    }


    #region 测试

    /*
    //相机  
    public Transform CameraTrans;
    //主方法，使用UGUI实现  
    void OnGUI()
    {
        if (GUILayout.Button("截图方式1", GUILayout.Height(30)))
        {
            CaptureByUnity(Application.persistentDataPath + "/" + screenShotFolder + "/"+ System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".jpg");
        }
        if (GUILayout.Button("截图方式2", GUILayout.Height(30)))
        {
            StartCoroutine(captureByRect(new Rect(0, 0, 1024, 768), Application.persistentDataPath + "/" + screenShotFolder + "/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".jpg"));
        }
        if (GUILayout.Button("截图方式3", GUILayout.Height(30)))
        {
            //启用顶视图相机  
            CameraTrans.GetComponent<Camera>().enabled = true;
            //禁用主相机  
            //Camera.main.enabled = false;
            StartCoroutine(captureByCamera(CameraTrans.GetComponent<Camera>(), new Rect(0, 0, 1024, 768), Application.persistentDataPath + "/" + screenShotFolder + "/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".jpg"));
        }
    }

    */

    #endregion

    /// <summary>
    /// 加载本地图片然后给RawImage更换图片
    /// </summary>
    /// <param name="img">RawImage</param>
    /// <param name="url">本地图片路径</param>
    public void LoadTeure(RawImage img,string url)
    {
        StartCoroutine(Load(img, url));
    }

    IEnumerator Load(RawImage img, string url)
    {
        yield return null;
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        www.Dispose();
    }



    /// <summary>
    /// 通过制定的摄像机根据一个Rect类型来截取指定范围的屏幕 
    /// </summary>
    /// <param name="mCamera">指定摄像机</param>
    /// <param name="mRect">截取范围</param>
    /// <param name="mFileName">保存的照片名字</param>
    /// <param name="scussessHandle">成功保存图片后的回调，返回图片完整加载路径</param>
    /// <param name="pictureFormat">图片格式jpg or png</param>
    public void CaptureByCamera(Camera mCamera, Rect mRect, string mFileName, Action<string> scussessHandle = null, string pictureFormat = "jpg")
    {
       // StartCoroutine(captureByCamera(CameraTrans.GetComponent<Camera>(), new Rect(0, 0, 1024, 768), Application.persistentDataPath + "/" + screenShotFolder + "/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".jpg"));
        StartCoroutine(captureByCamera(mCamera, mRect, mFileName, scussessHandle,pictureFormat));
    }

    /// <summary>  
    /// 根据一个Rect类型来截取指定范围的屏幕  
    /// 左下角为(0,0)  
    /// </summary>  
    /// <param name="mFileName">保存的照片名字</param>
    /// <param name="scussessHandle">成功保存图片后的回调，返回图片完整加载路径</param>
    /// <param name="pictureFormat">图片格式jpg or png</param>
    public void  CaptureByRect(Rect mRect, string mFileName,Action<string>scussessHandle=null, string pictureFormat = "jpg")
    {
        StartCoroutine(captureByRect(mRect,mFileName,scussessHandle,pictureFormat));
       // StartCoroutine(captureByRect(mRect, Application.persistentDataPath + "/" + screenShotFolder + "/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".jpg"));
    }


    /// <summary>  
    /// 使用Application类下的CaptureScreenshot()方法实现截图  
    /// 优点：简单，可以快速地截取某一帧的画面、全屏截图  
    /// 缺点：不能针对摄像机截图，无法进行局部截图  
    /// </summary>  
    /// <param name="mFileName">保存的照片名字</param>
    /// <param name="scussessHandle">成功保存图片后的回调，返回图片完整加载路径</param>
    /// <param name="pictureFormat">图片格式jpg or png</param>
    public void CaptureByUnity(string mFileName, Action<string> scussessHandle = null, string pictureFormat = "jpg")
    {
        if (pictureFormat == "png")
        {
            pictureFormat="png";
        }
        else
        {
            pictureFormat = "jpg";
        }
        mFileName = imgPath + mFileName + "." + pictureFormat;
        ScreenCapture.CaptureScreenshot(mFileName, 0);
        if (scussessHandle != null)
        {
            scussessHandle(LocalFilePathToLoadFilePath(mFileName));
        }
            
    }

    /// <summary>
    /// 截屏后加上一张图片合成图片=添加水印
    /// </summary>
    /// <param name="camera">指定摄像机</param>
    /// <param name="rect">指定大小</param>
    /// <param name="mFileName">截图名字</param>
    /// <param name="logo">水印</param>
    /// <param name="scussessHandle">成功保存后的回调，返回截图完整路径</param>
    /// <param name="pictureFormat">保存的图片格式 jpg or png</param>
    public void CaptureByCameraAndLogo(Camera camera, Rect rect, string mFileName, Texture2D logo=null, Action<string> scussessHandle = null, string pictureFormat = "jpg")
    {

        Capture(camera, rect, mFileName, logo, scussessHandle, pictureFormat);
    }


    private IEnumerator captureByRect(Rect mRect, string mFileName, Action<string> scussessHandle = null,string pictureFormat="jpg")
    {
        if (pictureFormat == "png")
        {
            pictureFormat = "png";
        }
        else
        {
            pictureFormat = "jpg";
        }
        mFileName = imgPath + mFileName + "."+pictureFormat;
        //等待渲染线程结束  
        yield return new WaitForEndOfFrame();
        //初始化Texture2D  
        Texture2D mTexture = new Texture2D((int)mRect.width, (int)mRect.height, TextureFormat.RGB24, false);
        //读取屏幕像素信息并存储为纹理数据  
        mTexture.ReadPixels(mRect, 0, 0);
        //应用  
        mTexture.Apply();

        //将图片信息编码为字节信息  
        byte[] bytes;
        if (pictureFormat=="png")
        {
            //将图片信息编码为字节信息  
           bytes = mTexture.EncodeToPNG();
        }else
        {
            bytes = mTexture.EncodeToJPG();
        }
        //保存  
        System.IO.File.WriteAllBytes(mFileName, bytes);

        if (scussessHandle != null)
            scussessHandle(LocalFilePathToLoadFilePath(mFileName));
        //如果需要可以返回截图  
        //return mTexture;  
    }

    private IEnumerator captureByCamera(Camera mCamera, Rect mRect, string mFileName, Action<string> scussessHandle = null,string pictureFormat= "jpg")
    {
        if (pictureFormat == "png")
        {
            pictureFormat = "png";
        }
        else
        {
            pictureFormat = "jpg";
        }
        mFileName = imgPath + mFileName + "." + pictureFormat;
        //等待渲染线程结束  
        yield return new WaitForEndOfFrame();

        //初始化RenderTexture  
        RenderTexture mRender = new RenderTexture((int)mRect.width, (int)mRect.height, 0);
        //设置相机的渲染目标  
        mCamera.targetTexture = mRender;
        //开始渲染  
        mCamera.Render();

        //激活渲染贴图读取信息  
        RenderTexture.active = mRender;

        Texture2D mTexture = new Texture2D((int)mRect.width, (int)mRect.height, TextureFormat.RGB24, false);
        //读取屏幕像素信息并存储为纹理数据  
        mTexture.ReadPixels(mRect, 0, 0);
        //应用  
        mTexture.Apply();

        //释放相机，销毁渲染贴图  
        mCamera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(mRender);


        
        byte[] bytes;
        if (pictureFormat == "png")
        {
            //将图片信息编码为字节信息  
            bytes = mTexture.EncodeToPNG();
        }
        else
        {
            bytes = mTexture.EncodeToJPG();
        }
        //保存  
        System.IO.File.WriteAllBytes(mFileName, bytes);
        Debug.Log(mFileName);

        if (scussessHandle != null)
            scussessHandle(LocalFilePathToLoadFilePath(mFileName));
        //如果需要可以返回截图  
        //return mTexture;  
    }

   

    /// <summary>
    /// 截屏后加上一张图片合成图片，添加水印
    /// </summary>
    /// <param name="camera">需要渲染的摄像机</param>
    /// <param name="rect">截图区域</param>
    /// <param name="logo">水印</param>
    /// <returns></returns>
    Texture2D Capture(Camera camera, Rect rect, string mFileName, Texture2D logo=null, Action<string> scussessHandle = null, string pictureFormat = "jpg")
    {
        if (pictureFormat == "png")
        {
            pictureFormat = "png";
        }
        else
        {
            pictureFormat = "jpg";
        }
        mFileName = imgPath + mFileName + "." + pictureFormat;
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 3);
        camera.targetTexture = rt;
        camera.Render();

        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.ARGB32, false);

        Texture2D _tex = logo;

        screenShot.ReadPixels(rect, 0, 0);

        //合成水印和Camera渲染的图片  
        if(logo!=null)
        {
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
        }
        
        screenShot.Apply();
        camera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(rt);
       

        byte[] bytes;
        if (pictureFormat == "png")
        {
            //将图片信息编码为字节信息  
            bytes = screenShot.EncodeToPNG();
        }
        else
        {
            bytes = screenShot.EncodeToJPG();
        }

        //string filename = Application.persistentDataPath + System.DateTime.Now.ToString("yyyyMdHms") + ".png";
        print(mFileName);
        System.IO.File.WriteAllBytes(mFileName, bytes);

        if (scussessHandle != null)
            scussessHandle(LocalFilePathToLoadFilePath(mFileName));
        return screenShot;
    }


    //  mFileName=mFileName.Replace('/','\\');     //保存的路径要转换成加载路径
    //downloadTexture.url = @"file://"+mFileName;  //加上file://前缀才可以通过www加载
    /// <summary>
    /// 本地文件的路径转换成可以加载的路径
    /// </summary>
    /// <param name="localFilePath"></param>
    /// <returns></returns>
    string LocalFilePathToLoadFilePath(string localFilePath)
    {
        string path = string.Empty;
        path = localFilePath.Replace('/', '\\');
        //path= AddPrefix(path,"file://");  //这样也行
        path = AddPrefix("file:///",path);
        return path;
    }
    //downloadTexture.url = @"file://"+mFileName;  //加上file://前缀才可以通过www加载
     string AddPrefix( string prefix,string oldName)
    {

        return ( prefix + oldName );
    }
}
