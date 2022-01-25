//解AB包管理器
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFW;
using HotUpdateProcess;

namespace ABFW
{
    
    public class AssetBundleMgr:MonoBehaviour
	{
        //本类实例
        private static AssetBundleMgr _Instance;
        //根目录集合
        private Dictionary<string, MultiABMgr> _DicAllRoots = new Dictionary<string, MultiABMgr>();
        //资源初始化
        private static bool init = true;
        //第一关AB包
        public AssetBundle level_oneNav = null;


        //得到本类实例
        public static AssetBundleMgr GetInstance()
        {
            if (_Instance==null)
            {
                _Instance = new GameObject("_AssetBundleMgr").AddComponent<AssetBundleMgr>();
                DontDestroyOnLoad(_Instance);
            }
            return _Instance;
        }

        void Awake()
        {        
            StartCoroutine(ABManifestLoader.GetInstance().LoadMainifestFile());     //加载Manifest清单文件
            OtherAB();       //这块是在加载场景 ，放在软件最开始//
        }

        public IEnumerator LoadAssetBundlePack(string RootDicName, string abName, DelLoadComplete loadAllCompleteHandle)   // 下载AssetBundel 指定包
        {
            while (!ABManifestLoader.GetInstance().IsLoadFinish) //等待Manifest清单文件加载完成
            {
                yield return null;
            }
            //把当前场景加入集合中。
            if (!_DicAllRoots.ContainsKey(RootDicName))
            {
                MultiABMgr multiMgrObj = new MultiABMgr(abName, loadAllCompleteHandle);
                _DicAllRoots.Add(RootDicName, multiMgrObj);
            }
            //调用下一层（“多包管理类”）
            MultiABMgr tmpMultiMgrObj = _DicAllRoots[RootDicName];
            
            //调用“多包管理类”的加载指定AB包。
            yield return tmpMultiMgrObj.LoadAssetBundeler(abName);
        }

        public Object LoadAsset(string scenesName, string abName, string assetName)    // 加载资源   (回调)
        {
            if (_DicAllRoots.ContainsKey(scenesName))
            {
                MultiABMgr multObj = _DicAllRoots[scenesName];
                return multObj.LoadAsset(abName, assetName);
            }
            Debug.LogError(GetType()+ "/LoadAsset()/找不到场景名称，无法加载（AB包中）资源,请检查！  scenesName="+ scenesName);
            return null;
        }
        public void OtherAB()
        {
            string path = ABFW.PathTools.GetABOutPath() + "/sences/";
            AssetBundle.LoadFromFile(path + ("sences.u3d").ToLower());
            level_oneNav = AssetBundle.LoadFromFile(path + ("level_one.ab").ToLower());
            level_oneNav = AssetBundle.LoadFromFile(path + ("level_two.ab").ToLower());
            level_oneNav = AssetBundle.LoadFromFile(path + ("level_three.ab").ToLower());
            level_oneNav = AssetBundle.LoadFromFile(path + ("level_noend.ab").ToLower());

            level_oneNav = AssetBundle.LoadFromFile(path + ("level_one_profiles.ab").ToLower());
            level_oneNav = AssetBundle.LoadFromFile(path + ("level_two_profiles.ab").ToLower());
            level_oneNav = AssetBundle.LoadFromFile(path + ("level_three_profiles.ab").ToLower());
        }
        public void DisposeAllAssets(string scenesName)          // 释放资源
        {
            if (_DicAllRoots.ContainsKey(scenesName))
            {
                MultiABMgr multObj = _DicAllRoots[scenesName];
                multObj.DisposeAllAsset();
            }
            else {
                Debug.LogError(GetType() + "/DisposeAllAssets()/找不到场景名称，无法释放资源，请检查！  scenesName=" + scenesName);
            }
        }  
    }
}


