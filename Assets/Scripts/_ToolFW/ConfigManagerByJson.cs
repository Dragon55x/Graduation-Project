/***
 *  Json 配置文件管理器 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;  //文件读写命名空间

namespace TFW
{
	public class ConfigManagerByJson //: IConfigManager
	{
	    private static Dictionary<string, string> _JsonConfig;

	    public Dictionary<string, string> JsonConfig   //只读属性： 得到应用设置（键值对集合）
        {
	        get { return _JsonConfig; }     
	    }
     
        // 构造函数
	    public ConfigManagerByJson(string jsonPath)
	    {
            _JsonConfig = new Dictionary<string, string>();
            InitAndAnalysisJson(jsonPath);        //初始化解析Json 数据，加载到（_JsonConfig）集合。
        }

        
        //根据路径解析Json 数据，加载到字典
	    private void InitAndAnalysisJson(string jsonPath)
        {
            //解析Json 配置文件
            string strReadContent = System.IO.File.ReadAllText(jsonPath);
            KeyValuesInfo keyvalueInfoObj = JsonUtility.FromJson<KeyValuesInfo>(strReadContent);
            
            //数据加载到AppSetting 集合中
            foreach (KeyValuesNode nodeInfo in keyvalueInfoObj.ConfigInfo)
            {
                _JsonConfig.Add(nodeInfo.Key,nodeInfo.Value);
            }
        }
	}
    
    [Serializable]
    class KeyValuesInfo
    {
        //配置信息
        public List<KeyValuesNode> ConfigInfo = null;
    }

    [Serializable]
    class KeyValuesNode
    {
        //键
        public string Key = null;
        //值
        public string Value = null;
    }
}