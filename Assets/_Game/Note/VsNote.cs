using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VsNote : MonoBehaviour
{

    //中文乱码设置 //VS菜单项的工具-->自定义，打开“自定义”对话框，然后选中“命令”选项卡，点击“添加命令”按钮

    string unicode = "//中文乱码设置 //VS菜单项的工具-->自定义，打开“自定义”对话框，然后选中“命令”选项卡，点击“添加命令”按钮" +
        "然后在[文件]种找到[高级保存选项]，点确定，可以" +
         "发现VS菜单栏多了高级保存选项一栏  把编码改成简体中文（GB2312），然后重新编" +
         "译运行，显示就正确了(UTF-8 65001也可以)";

    string setCodeTemplate = "使用番茄插件可以设置 新建代码的模板";

    string setTwoWindows = "拖拽一个代码脚本放到第二个窗口可以多个窗口同时编辑代码，提高效率";

    string codeAnnotation = "代码注释 快捷键：Ctrl+k+C,\n取消注释：ctrl+k+u";

    string codeAlignment = "代码对齐（规整) 快捷键：Ctrl+k+d";

    string hideCodeSection = "显示或隐藏当前代码段快捷键：ctrl+M+M";

    string deleteOneLine = "删除一行 快捷键：ctrl+L";


}
