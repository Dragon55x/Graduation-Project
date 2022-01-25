/***
 *  Title: "lua框架"项目 
 *          Lua 帮助类
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;
using ABFW;
using HotUpdateProcess;

namespace LuaFramework
{
    public class LuaHelper 
    {
        //本类静态实例
        private static LuaHelper _Instance;
        //Lua 环境
        private LuaEnv _luaEnv = new LuaEnv();
        //缓存lua文件名称与对应的lua信息。
        private Dictionary<string, byte[]> _DicLuaFileArray = new Dictionary<string, byte[]>();


        private LuaHelper()
        {
            //私有构造函数
            _luaEnv.AddLoader(customLoader);
        }

        public static LuaHelper GetInstance()
        {
            if (_Instance==null)
            {
                _Instance = new LuaHelper();
            }
            return _Instance;
        }

        public LuaEnv GetLuaEnv()
        {
            if (_luaEnv!=null)
            {
                return _luaEnv;
            }
            else {
                Debug.LogError(GetType()+ "/GetLuaEnv()/出现严重错误！   _luaEnv==null!!!   ");
                return null;
            }
        }
        public void DoString(string chunk, string chunkName = "chunk", LuaTable env = null) // 执行lua代码
        {
            _luaEnv.DoString(chunk, chunkName, env);
        }


        /// <summary>
        /// 自定义调取lua文件内容
        /// </summary>
        /// <param name="fileName">lua文件名称</param>
        /// <returns></returns>
        private byte[] customLoader(ref string fileName)
        {
            string luaPath = string.Empty;
            if (!UpdateResourcesFileFromServer.Local)
            {
                //发布区
                luaPath = PathTools.GetABOutPath() + HotUpdatePathTool.LUA_DEPLOY_PATH;
            }
            else
            {
                //编辑区
                luaPath = Application.dataPath + HotUpdatePathTool.LUA_EDITOR_PATH;
            }
      

            //缓存判断处理： 根据lua文件路径，获取lua的内容
            if (_DicLuaFileArray.ContainsKey(fileName))
            {
                //如果在缓存中可以查找成功，则直接返回结果。
                return _DicLuaFileArray[fileName];
            }
            else {
                return ProcessDIR(new DirectoryInfo(luaPath), fileName);
            }
        }

        /// <summary>
        /// 根据lua文件名称，递归取得lua内容信息,且放入缓存集合
        /// </summary>
        /// <param name="fileSysInfo">lua的文件信息</param>
        /// <param name="fileName">查询的lua文件名称</param>
        /// <returns></returns>
        private byte[] ProcessDIR(FileSystemInfo fileSysInfo, string fileName)
        {
            DirectoryInfo dirInfo=fileSysInfo as DirectoryInfo;
            FileSystemInfo[] files=dirInfo.GetFileSystemInfos();

            foreach (FileSystemInfo item in files)
            {
                FileInfo fileInfo = item as FileInfo;
                //表示一个文件夹
                if (fileInfo == null)
                {
                    //递归处理
                    ProcessDIR(item, fileName);
                }
                //表示文件本身
                else {
                    //得到文件本身，去掉后缀
                    string tmpName = item.Name.Split('.')[0];
                    if (item.Extension==".meta" || tmpName!= fileName)
                    {
                        continue;
                    }
                    //读取lua文件内容字节信息
                    byte[] bytes = File.ReadAllBytes(fileInfo.FullName);
                    //添加到缓存集合中
                    _DicLuaFileArray.Add(fileName,bytes);
                    return bytes;
                }

            }
            return null;
        }//ProcessDIR_end
        public void AddBaseLuaUIForm(GameObject go)  //lua 调用 动态添加“BaseLuaUIForm”脚本
        {
            go.AddComponent<BaseLuaUIForm>();
        }
        public void AddBaseLuaUIForm(Transform go)
        {
            go.gameObject.AddComponent<BaseLuaUIForm>();
        }
        public void AddBaseLuaEnemy(GameObject go)  //lua 调用 动态添加“BaseLuaEnemy”脚本
        {
            go.AddComponent<BaseLuaEnemy>();
        }
        public void AddBaseLuaTurret(GameObject go)  //lua 调用 动态添加“BaseLuaTurret”脚本
        {
            go.AddComponent<BaseLuaTurret>();
        }
        public void AddBaseLuaDeABullet(GameObject go)  //lua 调用 动态添加“BaseLuaBulletA”脚本
        {
            go.AddComponent<BaseLuaBulletA>();
        }
    }//Class_end
}


