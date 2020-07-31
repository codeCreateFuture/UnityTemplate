using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CoolGame
{
    public enum WindowID
    {
        WindowID_Invaild = 0,
        WindowID_Rank,          // 排行榜界面
        WindowID_Rank_Detail,   // 排行榜详情界面
        WindowID_Rank_OwnDetail,
        WindowID_Level,
        WindowID_LevelDetail,
        WindowID_Matching,
        WindowID_MatchResult,
        WindowID_MatchPause,
        WindowID_Skill,
        WindowID_MainMenu,
        WindowID_TopBar,
        WindowID_MessageBox,
        WindowID_Matching_Wuxian,
        WindowID_Matching_Houzidao,
        WindowID_Matching_Kapai,
        WindowID_Matching_Normal,
        WindowID_Matching_Zhanche,
        WindowID_Matching_Zhanche_Boss,
        WindowID_Matching_PK,
        WindowID_Friend,
        WindowID_AddFriend,
        WindowID_FriendRequest,
        WindowID_FriendMsg,
        WindowID_FriendRisk,
        WindowID_Risk,
        WindowID_Achievement,
        WindowID_Shop,
        WindowID_PK,
        WindowID_FriendLand,
        WindowID_Task,
        WindowID_Mission_Confirm,
        WindowID_CarPlace,
        WindowID_CarModify,
        WindowID_SkillInlay,
        WindowID_SkillUpgrade,
        WindowID_Setup,
        WindowID_Manul_Input,
        WindowID_Sign_Up,
        WindowID_Login_Btn,
        WindowID_Login,
        WindowID_Login_MessageBox,
        WindowID_Activate,
        WindowID_SETNickname,
        WindowID_Activity,
        WindowID_Mail,
        WindowID_Mail_Content,
        WindowID_Relive,
        WindowID_Drill,
        WindowID_Show_GetRewards,
        WindowID_Friend_PK_Select,
        WindowID_Friend_PK_Request
    }

    public enum UIWindowType
    {
        Normal,    // 可推出界面(UIMainMenu,UIRank等)
        Fixed,     // 固定窗口(UITopBar等)
        PopUp,     // 模式窗口
    }

    public enum UIWindowShowMode
    {
        DoNothing,
        HideOther,     // 闭其他界面
        NeedBack,      // 点击返回按钮关闭当前,不关闭其他界面(需要调整好层级关系)
        NoNeedBack,    // 关闭TopBar,关闭其他界面,不加入backSequence队列
    }

    public enum UIWindowColliderMode
    {
        None,      // 显示该界面不包含碰撞背景
        Normal,    // 碰撞透明背景
        WithBg,    // 碰撞非透明背景
    }

    public class UIResourceDefine
    {
        public static Dictionary<WindowID, string> windowPrefabPath = new Dictionary<WindowID, string>() 
        { 
            { WindowID.WindowID_Rank, "UIRank" },
            { WindowID.WindowID_Level, "UILevelWindow" },
            { WindowID.WindowID_MainMenu, "UIMainMenu" },
            { WindowID.WindowID_TopBar, "UITopBar" },
            { WindowID.WindowID_MessageBox, "UIMessageBox" },
            { WindowID.WindowID_LevelDetail, "UILevelDetailWindow" },
            { WindowID.WindowID_Matching, "UIMatching" },
            { WindowID.WindowID_MatchResult, "UIMatchResult" },
            { WindowID.WindowID_Skill, "UISkill" },
            { WindowID.WindowID_Achievement, "UIAchievement" },
            { WindowID.WindowID_Matching_Wuxian, "UIMatching_Wuxian" },
            { WindowID.WindowID_Matching_Houzidao, "UIMatching_Houzidao" },
            { WindowID.WindowID_Matching_Kapai, "UIMatching_Kapai" },
            { WindowID.WindowID_Matching_Normal, "UIMatching_Normal" },
            { WindowID.WindowID_Matching_Zhanche, "UIMatching_Zhanche" },
            { WindowID.WindowID_Matching_Zhanche_Boss, "UIMatching_Zhanche_Boss" },
            { WindowID.WindowID_Friend, "UIFriend" },
            { WindowID.WindowID_FriendRequest, "UIFriendRequest" },
            { WindowID.WindowID_FriendMsg, "UIFriendMsg" },
            { WindowID.WindowID_FriendRisk, "UIFriendRisk" },
            { WindowID.WindowID_Risk, "UIRisk" },
            { WindowID.WindowID_PK, "UIPK" },
            { WindowID.WindowID_FriendLand, "UIFriendLand" },
            { WindowID.WindowID_Shop, "UIShop" },
            { WindowID.WindowID_MatchPause, "UIMatchPause"},
            { WindowID.WindowID_Task, "UITask"},
            { WindowID.WindowID_Mission_Confirm, "UIMissionConfirm"},
            { WindowID.WindowID_CarPlace, "UICarPlace"},
            { WindowID.WindowID_AddFriend, "UIAddFriend"},
            { WindowID.WindowID_CarModify, "UICarModify"},
            { WindowID.WindowID_SkillInlay, "UISkillInlay"},
            { WindowID.WindowID_SkillUpgrade, "UISkillUpgrade"},
            { WindowID.WindowID_Setup, "UISetup"},
            { WindowID.WindowID_Manul_Input, "UIManuleInput"},
            { WindowID.WindowID_Login, "UILogin"},
            { WindowID.WindowID_Login_Btn, "UILoginBtn"},
            { WindowID.WindowID_Sign_Up, "UISignUp"},
            { WindowID.WindowID_Login_MessageBox, "UILoginMessageBox"},
            { WindowID.WindowID_Activate, "UIActivation"},
            { WindowID.WindowID_Matching_PK , "UIMatching_PK"},
			{ WindowID.WindowID_SETNickname, "UISetNicName"},
            { WindowID.WindowID_Activity, "UIActivity"},
            { WindowID.WindowID_Mail, "UIMail"},
            { WindowID.WindowID_Mail_Content, "UIMailContent"},
            { WindowID.WindowID_Relive, "UIRelive"},
            { WindowID.WindowID_Drill, "UIDrill"},
            { WindowID.WindowID_Show_GetRewards, "UIShowGetRewards"},
            { WindowID.WindowID_Friend_PK_Select, "UIFriendPKSelect"},
            { WindowID.WindowID_Friend_PK_Request, "UIFriendPKRequest" }
        };

        public static string UIPrefabPath = "UIResources/UIPrefabs/";
    }
}
