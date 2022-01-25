
//拷贝所有项目的资源文件（lua/Json配置文件）从编辑器区拷贝到发布区。

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using System.IO;
using ABFW;


namespace HotUpdateProcess
{
    public class CopyAssetFileToSA 
    {
        //lua
        private static string _LuaDIRPath = Application.dataPath + HotUpdatePathTool.LUA_EDITOR_PATH; //lua编辑目录路径  
        private static string _CopyTargetDIR = PathTools.GetABOutPath() + HotUpdatePathTool.LUA_DEPLOY_PATH; //lua发布目录路径
        //json
        private static string _JsonEditorDIRPath = Application.dataPath + HotUpdatePathTool.JSON_EDITOR_PATH; //Json编辑目录路径
        private static string _JsonTargetDIR = PathTools.GetABOutPath() + HotUpdatePathTool.JSON_DEPLOY_PATH; //Json配置文件发布目录路径


        [MenuItem("HotUpdateProcess/CopyLuaAndJsonToSA")]
        public static void CopyLuaAndJsonToSA()
        {
            CopyLuaFileTo();
            CopyJsonsFileTo();
        }
        public static void CopyLuaFileTo()     // 拷贝lua编辑器目录
        {
            DirectoryInfo dirInfo = new DirectoryInfo(_LuaDIRPath);
            FileInfo[] files = dirInfo.GetFiles();

            if (!Directory.Exists(_CopyTargetDIR))  //创建文件夹
            {
                Directory.CreateDirectory(_CopyTargetDIR);
            }
            foreach (FileInfo infoObj in files)  //开始循环拷贝文件
            {
                File.Copy(infoObj.FullName, _CopyTargetDIR + "/" + infoObj.Name, true);
            }

            Debug.Log("CopyAssetFileToSA.cs/CopyLuaFileTo()/ lua文件已经拷贝的指定区域！");
            AssetDatabase.Refresh();
        }
        
        public static void CopyJsonsFileTo()   // 拷贝Json文件到StreamAsset 目录
        {
            //定义目录与文件结构
            DirectoryInfo dirInfo = new DirectoryInfo(_JsonEditorDIRPath);
            FileInfo[] files = dirInfo.GetFiles();

            //如果发布区文件不存在，则创建
            if (!Directory.Exists(_JsonTargetDIR))
            {
                Directory.CreateDirectory(_JsonTargetDIR);
            }

            //开始循环拷贝文件：Json的编辑相关文件
            foreach (FileInfo jsonEditorFilesObj in files)
            {
                //过滤扩展名称
                if ((jsonEditorFilesObj.Extension==".json") || (jsonEditorFilesObj.Extension == ".Json"))
                {
                    File.Copy(jsonEditorFilesObj.FullName, _JsonTargetDIR + "/" + jsonEditorFilesObj.Name, true);
                }
            }
           
            Debug.Log("CopyAssetFileToSA.cs/CopyJsonsFileTo()/ Json配置文件已经拷贝的指定区域！");
            AssetDatabase.Refresh();
        }
    }
}


