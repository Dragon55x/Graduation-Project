 
//  读取AssetBundle 依赖关系清单文件。（Windows.Manifest）

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABFW
{
    public class ABManifestLoader 
    {
        //本类实例
        private static ABManifestLoader _Instance;
        //Assetbundle (清单文件) 系统类
        private AssetBundleManifest _ManifestObj;
        //AssetBundle 清单文件的路径
        private string _StrManifestPath;
        //读取AB清单文件的AssetBundel 
        private AssetBundle _ABReadManifest;
        //是否加载（Manifest ）完成
        private bool _IsLoadFinish;
        /*  只读属性*/
        public bool IsLoadFinish
        {
            get { return _IsLoadFinish; }
        }

        private ABManifestLoader()  //构造函数
        {
            //确定清单文件WWW下载路径
            _StrManifestPath = PathTools.GetWWWPath() + "/" + PathTools.GetPlatformName();
            _ManifestObj = null;
            _ABReadManifest = null;
            _IsLoadFinish = false;
        }

        public static ABManifestLoader GetInstance()        // 获取本类实例
        {
            if (_Instance==null)
            {
                _Instance = new ABManifestLoader();
            }
            return _Instance;
        }
     
        public IEnumerator LoadMainifestFile()       //加载Manifest 清单文件
        {
            using (WWW www=new WWW(_StrManifestPath))
            {
                yield return www;                      //yiled return 后面可以跟一个WWW类,当下载完成该WWW类的时候,继续向下面的代码执行
                if (www.progress >= 1)
                {
                    //加载完成，获取AssetBundle 实例
                    AssetBundle abObj = www.assetBundle;
                    if (abObj != null)
                    {
                        _ABReadManifest = abObj;
                        //读取清单文件资源。（读取到系统类的实例中。）
                        _ManifestObj = _ABReadManifest.LoadAsset("AssetBundleManifest") as AssetBundleManifest; 
                        //本次加载与读取清单文件完毕。
                        _IsLoadFinish = true;
                    }
                    else {
                        Debug.Log(GetType()+ "/LoadMainifestFile()/WWW下载出错，请检查！ _StrManifestPath="+ _StrManifestPath+"  错误信息： "+www.error);  
                    }
                }
            }
        }

        public string[] RetrivalDependce(string abName)             // 获取AssetBundleManifest（系统类) 指定包名称依赖项
        {
            if (_ManifestObj!=null && !string.IsNullOrEmpty(abName))
            {
                return _ManifestObj.GetAllDependencies(abName);
            }
            return null;
        }
    }
}


