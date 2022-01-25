/***
 *           主流程（3层）：(一个根目录中)多个AssetBundle 包管理
 *              1： 获取AB包之间的依赖与引用关系。
 *              2： 管理AssetBundle包之间的自动连锁（递归）加载机制
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFW;

namespace ABFW
{
	public class MultiABMgr
	{
        //引用： "单个AB包加载实现类"
        private SingleABLoader _CurrentSinglgABLoader;
        //AB包缓存集合
        private Dictionary<string, SingleABLoader> _DicSingleABLoaderCache;
        //当前AssetBundle 名称
        private string _CurrentABName;
        //AB包与对应依赖关系集合
        private Dictionary<string, ABRelation> _DicABRelation;
        //委托： 所有AB包加载完成。
        private DelLoadComplete _LoadAllABPackageCompleteHandel;

        public MultiABMgr(string abName,DelLoadComplete loadAllABPackCompleteHandle)    // 构造函数
        {
            _CurrentABName = abName;
            _DicSingleABLoaderCache = new Dictionary<string, SingleABLoader>();
            _DicABRelation = new Dictionary<string, ABRelation>();
            _LoadAllABPackageCompleteHandel = loadAllABPackCompleteHandle;
        }
        private void CompleteLoadAB(string abName)      // 完成指定AB包调用
        {
            Debug.Log(GetType() + "/当前完成abName: " + abName + " 包的加载");

            if (abName.Equals(_CurrentABName))    //对根目录第一个加载的AB包进行实例化
            {
                if (_LoadAllABPackageCompleteHandel!=null)
                {
                    _LoadAllABPackageCompleteHandel(abName);
                }
            }
        }
        public IEnumerator LoadAssetBundeler(string abName)     // 加载AB包以及依赖项AB包
        {
            //AB包关系的建立--  加载预制体包，主包是预制体，有两个材质包依赖，且有相同贴图依赖，这时第二个材质包，不需要继续分析了
            if (!_DicABRelation.ContainsKey(abName))
            {
                ABRelation abRelationObj = new ABRelation(abName);
                _DicABRelation.Add(abName, abRelationObj);
            }
            ABRelation tmpABRelationObj = _DicABRelation[abName];
            //把即将加载的包存起来

            //得到指定AB包所有的依赖关系（查询Manifest清单文件）
            string[] strDependeceArray = ABManifestLoader.GetInstance().RetrivalDependce(abName);
            foreach (string item_Depence in strDependeceArray)
            {
                //添加“依赖”项
                tmpABRelationObj.AddDependence(item_Depence);
                //加载依赖项的“依赖”项    （递归调用）
                if (_DicABRelation.ContainsKey(item_Depence))
                {
                    yield return null;  //该依赖项已经加载过了
                }
                else
                {
                    yield return LoadAssetBundeler(item_Depence);
                }          
            }
            //加载此包的依赖包

            //真正加载AB包
            if (_DicSingleABLoaderCache.ContainsKey(abName))
            {
                yield return _DicSingleABLoaderCache[abName].LoadAssetBundle();
            }
            else {
                _CurrentSinglgABLoader = new SingleABLoader(abName, CompleteLoadAB);
                _DicSingleABLoaderCache.Add(abName, _CurrentSinglgABLoader);
                yield return _CurrentSinglgABLoader.LoadAssetBundle();
            }
        }
      
        public UnityEngine.Object LoadAsset(string abName, string assetName)   // 获取资源  （回调）
        {
            return _DicSingleABLoaderCache[abName].LoadAsset(assetName);
            
        }
        public void DisposeAllAsset()           // 释放本根目录中所有的资源
        {
            try
            {
                //逐一释放所有加载过的AssetBundel 包中的资源
                foreach (SingleABLoader item_sABLoader in _DicSingleABLoaderCache.Values)
                {
                    item_sABLoader.DisposeTrue();
                }
            }
            finally
            {
                _DicSingleABLoaderCache.Clear();
                _DicSingleABLoaderCache = null;

                //释放其他对象占用资源
                _DicABRelation.Clear();
                _DicABRelation = null;
                _CurrentABName = null;
                
                _LoadAllABPackageCompleteHandel = null;
                //强制垃圾收集
                System.GC.Collect();
            }
        }
    }
}


