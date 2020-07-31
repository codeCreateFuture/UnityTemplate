
public class Events  {

   



    /**打开主界面的游戏界面*/
    public const string OPEN_MAIN_UI_GAME           	= "OPEN_MAIN_UI_GAME";
    /**打开主界面的管理界面*/
    public const string OPEN_MAIN_UI_MANAGER        	= "OPEN_MAIN_UI_MANAGER";
    /**打开主菜单*/
    public const string OPEN_MAIN_UI                	= "OPEN_MAIN_UI";

    /**网络已经连接*/
    public const string INTERNET_CONNECTED              = "INTERNET_CONNECTED";
    /**网络断开*/
    public const string INTERNET_CLOSE                  = "INTERNET_CLOSE";

    /**服务器出错*/
    public const string SEVER_ERROR                     = "SEVER_ERROR";

	/**打开二级页面的AR界面*/
	public const string OPEN_SECOND_UI_AR             	= "OPEN_SECOND_UI_AR";
	/**打开二级页面的妈妈管理界面*/
	public const string OPEN_SECOND_UI_MOM_MANAGER    	= "OPEN_SECOND_UI_MOM_MANAGER";
	/**打开主二级页面的小熊游戏界面*/
	public const string OPEN_SECOND_UI_XXGAME         	= "OPEN_SECOND_UI_XXGAME";
	/**打开二级页面的每日推送界面*/
	public const string OPEN_SECOND_UI_EVERYDAYPUSH   	= "OPEN_SECOND_UI_EVERYDAYPUSH";
	/**打开二级页面的故事之屋界面*/
	public const string OPEN_SECOND_UI_STORY         	= "OPEN_SECOND_UI_STORY";

	/**妈妈管理页面，键入密码*/
	public const string MON_INPUT_PWD         			= "MON_INPUT_PWD";

	/**故事小屋下一故事**/
	public const string STORY_NEXT_BTN                  = "STORY_NEXT_BTN";
	/**故事小屋上一故事**/
	public const string STORY_LAST_BTN                  = "STORY_LAST_BTN";

    /**开始下载AR卡*/
    public const string ARCORD_DOWNLOAD_START           = "ARCORD_DOWNLOAD_START";
    /**AR卡下载进度*/
    public const string ARCORD_DOWNLOAD_PROGRESS        = "ARCORD_DOWNLOAD_PROGRESS";
    /**AR卡下载完成*/
    public const string ARCORD_DOWNLOAD_COMPLETE        = "ARCORD_DOWNLOAD_COMPLETE";
    /**AR卡下载错误*/
    public const string ARCORD_DOWNLOAD_ERROR           = "ARCORD_DOWNLOAD_ERROR";

    /**开始下载故事*/
    public const string STORY_DOWNLOAD_START            = "STORY_DOWNLOAD_START";
    /**故事下载进度*/
    public const string STORY_DOWNLOAD_PROGRESS         = "STORY_DOWNLOAD_PROGRESS";
    /**故事下载完成*/
    public const string STORY_DOWNLOAD_COMPLETE         = "STORY_DOWNLOAD_COMPLETE";
    /**故事下载错误*/
    public const string STORY_DOWNLOAD_ERROR            = "STORY_DOWNLOAD_ERROR";

    /**下载管理器初始化完成*/
    public const string DOWNLOADMGR_INIT                = "DOWNLOADMGR_INIT";
    /**故事下载完成，传入故事的下标*/
    public const string STORY_NEWCOMPLETE_INDEX         = "STORY_NEWCOMPLETE_INDEX";

    public const string DELETE_STORY_TO_PAGE_MGR        = "DELETE_STORY_TO_PAGE_MGR";

    public const string ADD_STORY_TO_PAGE_MGR           = "ADD_STORY_TO_PAGE_MGR";

    public const string CLICK_STORY_TO_PLAY             = "CLICK_STORY_TO_PLAY";

    public const string CLICK_STORY_TO_PLAY_PREV        = "CLICK_STORY_TO_PLAY_PREV";

    public const string CLICK_STORY_TO_PLAY_NEXT        = "CLICK_STORY_TO_PLAY_NEXT";

    public const string RESOURCE_INIT_LOAD = "RESOURCE_INIT_LOAD";
    public const string RESOURCE_DESTROY = "RESOURCE_DESTROY";

    public const string RESOURCE_PLAY_ISCHINESE = "RESOURCE_PLAY_ISCHINESE";
    public const string RESOURCE_PLAY_SHOUT = "RESOURCE_PLAY_SHOUT";
    public const string RESOURCE_PLAY_BAIKE = "RESOURCE_PLAY_BAIKE";

    public const string ROTATEMODELBYCAMERADIRECTION = "ROTATEMODELBYCAMERADIRECTION";
    public const string ERROR_MESSAGE = "ERROR_MESSAGE";

    public const string IN_RECT = "IN_RECT";
    public const string OUT_RECT = "OUT_RECT";

    public const string GAME_START = "GAME_START";
    public const string GAME_OVER = "GAME_OVER";
}
