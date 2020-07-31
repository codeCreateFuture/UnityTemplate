using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public static class VideoController{
    /// <summary>  
    /// 获取视频总时长  
    /// </summary>  
    /// <param name="vsp"></param>  
    /// <returns></returns>  
    public static int GetVideoTimeCount(this VideoPlayer vp)
    {
        return (int)( vp.frameCount / vp.frameRate );
    }
    /// <summary>  
    /// 获取视频进度  
    /// </summary>  
    /// <param name="vsp"></param>  
    /// <returns></returns>  
    public static float GetVideoProgression(this VideoPlayer vp)
    {
        return (float)( ( vp.time * vp.frameRate ) / ( vp.frameCount / vp.frameRate ) );
    }

    /// <summary>  
    /// 设置视频进度  
    /// </summary>  
    /// <param name="vp"></param>  
    /// <param name="progression"></param>  
    public static void SetVideoProgression(this VideoPlayer vp, float progression)
    {
        float time = (int)vp.frameCount / vp.frameRate * progression;
        vp.time = time;
        vp.Play();
    }
}
