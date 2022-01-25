/***
 *          框架主流程：第1层： WWW 加载AssetBundle 
 *          SingleABLoader(string abName,DelLoadComplete loadComplete)
 *          单个AB包，加载 并存储
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFW;
namespace ABFW
{
	public class SingleABLoader             //: System.IDisposable
	{
        //委托：
        private DelLoadComplete _LoadCompleteHandle;
        //AssetBundle 名称
        private string _ABName;
        //AssetBundle 下载路径
        private string _ABDownLoadPath;
        //缓存容器集合
        private Hashtable _Ht;
        //当前Assetbundle 
        private AssetBundle _CurrentAssetBundle;
        //Assetbundle 集合
        private Dictionary<string,AssetBundle> AssetBundles;//用于判断是否加载当前AB包
        //构造函数
        public SingleABLoader(string abName,DelLoadComplete loadComplete)
        {
            _Ht = new Hashtable();
            _ABName = abName;
            AssetBundles = new Dictionary<string, AssetBundle>();
            //委托初始化
            _LoadCompleteHandle = loadComplete;
            //AB包下载路径（初始化）
            _ABDownLoadPath = PathTools.GetWWWPath() + "/" + _ABName;
        }
        public IEnumerator LoadAssetBundle()          //加载AssetBundle 资源包
        {
            using (WWW www=new WWW(_ABDownLoadPath))    //加载本地路径
            {
                yield return www;
                //WWW下载AB包完成
                if (www.progress>=1)
                {
                    AssetBundle abObj;
                    if (AssetBundles.ContainsKey(_ABDownLoadPath))
                    {
                         abObj = AssetBundles[_ABDownLoadPath];
                    }
                    else
                    {
                        abObj = www.assetBundle;//获取AssetBundle的实例
                        abObj.LoadAllAssets();
                        AssetBundles.Add(_ABDownLoadPath, abObj);
                    }
                    if (abObj!=null)
                    {
                        //得到AB包
                        _CurrentAssetBundle=abObj;
                        //AssetBundle 下载完毕，调用委托
                        if (_LoadCompleteHandle!=null)
                        {
                            _LoadCompleteHandle(_ABName);
                        }
                    }
                    else {
                        Debug.LogError(GetType()+ "/LoadAssetBundle()/WWW 下载出错，请检查！ AssetBundle URL: "+ _ABDownLoadPath+" 错误信息： "+www.error);
                    }
                }
            }//using_end            
        }    
        public UnityEngine.Object LoadAsset(string assetName)   // 加载资源（回调）
        {
            if (_Ht.Contains(assetName))
            {
                return _Ht[assetName] as UnityEngine.Object;
            }
            //正式加载
            UnityEngine.Object tmpTResource = _CurrentAssetBundle.LoadAsset<UnityEngine.Object>(assetName);
            if (tmpTResource != null)
            {
                _Ht.Add(assetName, tmpTResource);
            }
            return tmpTResource;
        }


        public void DisposeTrue()  // 释放当前AssetBundle资源包,且卸载所有资源
        {
            _CurrentAssetBundle.Unload(true);
        }

    }
}


