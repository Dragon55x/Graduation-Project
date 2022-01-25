/***
 *   系统工具框架
 *           结构体
 *           系统委托
 *           常量
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFW
{
    public struct ABPara       // AB包的参数结构
    {
        //AB包所属根目录名称
        public string RootFileName;
        //AB包名称
        public string AssetBundleName;
        //资源的名称
        public string AssetName;
    }

    /*  委托定义 （UI加载 委托） */
    public delegate void DelTaskComplete(UnityEngine.GameObject obj);
    /*  委托定义 （游戏预制体加载 委托） */
    public delegate void DTComplete(string preName);
    /*  委托定义 （AB包加载 委托） */
    public delegate void DelLoadComplete(string abName);
    public class SysDefine : MonoBehaviour {
       
        /* 路径常量 */
        public const string SYS_PATH_UIFORMS_CONFIG_INFO = "UIFormsConfigInfo.json";
        public const string SYS_PATH_DT_CONFIG_INFO = "DTConfigInfo.json";
        public const string SYS_PATH_CONFIG_INFO = "SysConfigInfo.json";
        public const string SYS_PATH_LAUGUAGE_JSON_CONFIG = "LauguageJSONConfig.json";
        /* 标签常量 */
        public const string SYS_TAG_CANVAS = "_TagCanvas";
        /* 节点常量 */        
        public const string SYS_NORMAL_NODE = "Normal";
        public const string SYS_FIXED_NODE = "Fixed";
        public const string SYS_POPUP_NODE = "PopUp";

    }
}