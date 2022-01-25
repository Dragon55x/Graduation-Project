/***
 * 
 *    Title:  "lua框架"项目启动脚本
 *                  
 *          
 *            
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaFramework
{
    public class LuaGameStart : MonoBehaviour,HotUpdateProcess.IStartGame
    {
        public void ReceiveInfoStartRuning()
        {
            LuaHelper.GetInstance().DoString("require 'StartGame'");
        }
    }//Class_end
}//namespace_end