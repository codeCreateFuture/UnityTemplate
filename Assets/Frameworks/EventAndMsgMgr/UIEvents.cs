using UnityEngine;
using System;
using System.Collections;

public class UIEvents
{
  //  public EventHandler downLoadFaild;
   



    public static bool showAdvert = true;

    #region ar画框

    public const string SetArPaintModelToCameraCenter = "SetArPaintModelToCameraCenter";//设置ar画框模型到摄像机中心
    public const string ARSCENE_RECORDINGVOICERESULT = "ARSCENE_RECORDINGVOICERESULT"; //录音返回结果，返回的结果是控制动画
    public const string StartReconder = "StartReconder";                               //开始录音
    public const string RECOGNITIONPICTURELOST = "RECOGNITIONPICTURELOST";             //ar画框添加陀螺仪脚本

    public const string RECOGNITIONPICTUREFOUND = "RECOGNITIONPICTUREFOUND";            //ar画框删除陀螺仪脚本
    public const string HUAKUANG_ACTIVE = "HUAKUANG_ACTIVE";            //ar画框删除陀螺仪脚本
    public const string START_RECORDER = "START_RECORDER";            //ar画框删除陀螺仪脚本
    #endregion


    public const string Is_FaceScane = "Is_FaceScane";  //是否在扫描封面
    public const string GAME_PROMPT = "GAME_PROMPT";//弹出提示框.
    public const string SET_LOADING_OBJ = "SET_LOADING_OBJ";//实例化loadingObj.
    public const string CHANGE_BG = "跟换背景图片";//跟换背景图片.
    public const string CHANGE_GENRRAL_BG = "CHANGE_GENRRAL_BG";//跟换成正常背景.

    public const string START_LOAD_CONFIG = "START_LOAD_CONFIG"; //开始加载配置和UI.
    public const string CLOSE_LOAD_CONFIG = "CLOSE_LOAD_CONFIG";//结束加载配置和UI.
    public const string START_LOAD_SENCE = "START_LOAD_SENCE";//开始加载场景.
    public const string CLOSE_LOAD_SENVE = "CLOSE_LOAD_SENVE";//结束加载场景.
    public const string START_UPDATE_ASSET = "START_UPDATE_ASSET";//开始更新资源.
    public const string CLOSE_UPDATE_ASSET = "CLOSE_UPDATE_ASSET";//结束跟新资源.

    public const string CAMERA_SHOT = "CAMERA_SHOT";//拍照.
    public const string END_CAMERA_SHOT = "END_CAMERA_SHOT";//拍照结束时.
    public const string CLOSE_CAMERA_SHOT = "CLOSE_CAMERA_SHOT";//关闭相框.
    public const string INIT_CAMERA_SHOT = "INIT_CAMERA_SHOT";//初始化相机拍照.

    public const string SHARE_SHOW = "SHARE_SHOW";//打开分享面板.
    public const string SHARE_HIDE = "SHARE_HIDE";//隐藏分享面板.
    public const string SHARE_WECHAT_FRIENT = "SHARE_WECHAT_FRIENT";//微信分享给朋友.
    public const string SHARE_WECHAT_ZONE = "SHARE_WECHAT_ZONE";//微信分享到朋友圈.
    public const string SHARE_UPLOAD_SUCCESS = "SHARE_UPLOAD_SUCCESS";//上传图片成功.
    public const string SHARE_UPLOAD_FAILED = "SHARE_UPLOAD_FAILED";//上传图片失败.

    public const string SET_BOOK_NAME = "SET_BOOK_NAME";//设置识别图的名字.
    public const string ARUI_INIT = "ARUI_INIT";//初始化arui.
    public const string DOWN_PANEL_ACTIVE = "DOWN_PANEL_ACTIVE";//设置downPanel的显示和隐藏.
    public const string DOWN_IDENTIFY = "DOWN_IDENTIFY";//下载或者加载识别图.
    public const string DOWN_MODEL = "DOWN_MODEL";//下载模型.
    public const string DOWN_ALL_ASSET = "DOWN_ALL_ASSET";//下载所有资源.
    public const string DOWN_IDENTIFY_PROGRESS = "DOWN_IDENTIFY_PROGRESS";//设置识别图进度条的显示和隐藏.
    public const string DOWN_MODEL_PROGRESS = "DOWN_MODEL_PROGRESS";//设置模型进度条的显示和隐藏.
    public const string SET_WAIT_ACTIVE = "SET_WAIT_ACTIVE";//设置模型下载时等待图标的显示和隐藏.
    public const string CAMERA_DEVICE_CHANGE = "CAMERA_DEVICE_CHANGE";//切换摄像头.
    public const string SACN_FACE = "SACN_FACE";//扫描封面.
    public const string TEXT_STATE = "TEXT_STATE";//设置文本的显示和隐藏.
    public const string BAIKE_STATE = "BAIKE_STATE";//设置百科按钮的显示和隐藏.
    public const string MODEL_DOING_PROGRESS = "MODEL_DOING_PROGRESS";//显示单个模型下载时的百分比.

    public const string SETTING_SHOW_TEXT = "SETTING_SHOW_TEXT";//设置是否显示文本.
    public const string SETTING_CHINESE = "SETTING_CHINESE";//判断是否显示中文.
    public const string SETTING_AUDIO_BG = "SETTING_AUDIO_BG";//设置背景音乐.
    public const string SETTING_ADUIO_ALL = "SETTING_ADUIO_ALL";//设置所有音乐.

    public const string PREVIOUS_TEX = "PREVIOUS_TEX";//切换上一张图片.
    public const string NEXT_TEX = "NEXT_TEX";//切换下一张图片.

    public const string UPDATE_IDENTIFY = "UPDATE_IDENTIFY";//更新书本资源


}
