
//路径常量

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HotUpdateProcess
{
	public class HotUpdatePathTool
	{
 
        //Json
        public const string JSON_EDITOR_PATH = "/Conf_Resources"; //Json编辑区
        public const string JSON_DEPLOY_PATH = "/Configurations"; //发布区

        //lua
        public const string LUA_EDITOR_PATH = "/Scripts/LuaScripts";  //lua编辑区
        public const string LUA_DEPLOY_PATH = "/LUA";                       //发布区
        
        public const string SERVER_URL = "http://10.0.11.134:8088/UpdateAssets/";  //HTTP 服务器链接地址

        public const string PROJECT_VERIFY_FILE = "/ProjectVerifyFile";  //校验文件
        
        public const string RECEIVE_INFO_START_RUNING = "ReceiveInfoStartRuning"; //接受方法常量

    }
}


