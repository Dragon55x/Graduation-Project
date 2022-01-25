/***
 * 
 *    UI框架： AssetBunde 资源调用帮助脚本
 *    封装ABFW框架中关于资源调用API，帮助类。
 *   
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFW;
using ABFW;   //导入AB框架命名空间

namespace ABFW
{
    public class ABLoadAppearance : MonoBehaviour    //实现传进来ABPara，即可把资源加载保存住
    {
        //本类实例
        private static ABLoadAppearance _Instance;
        //AB包跟目录名称
        private string _RootFileName = string.Empty;
        //AB包的名称
        private string _AssetBundleName = string.Empty;
        //AB包中资源的名称
        private string _AssetName = string.Empty;
        //是否包资源加载完毕
        private bool _IsLoadFinish = false;
        
        //克隆出来的UI预设
        private UnityEngine.Object _CloneUIPrefab = null;
        //不克隆的防御塔预设
        private UnityEngine.Object _GamePrefab = null;
        
        public bool IsLoadFinish   //属性
        {
            get { return _IsLoadFinish; }
        }

        //得到本类的实例
        public static ABLoadAppearance GetInstance()
        {
            if (_Instance==null)
            {
                _Instance = new GameObject("_ABLoadAssetHelper").AddComponent<ABLoadAppearance>();
                DontDestroyOnLoad(_Instance);
            }
            return _Instance;
        }
        
        #region 加载UI   UImanager调用
        public void LoadAssetBundleUIPack(ABPara abPara)      // UI 调用AB框架 加载ab包 然后回调加载资源      
        {
            //判断一下是不是同一个主AB包加载
            if ((abPara.RootFileName == _RootFileName)  && (abPara.AssetBundleName==_AssetBundleName))
            {
                _AssetName = abPara.AssetName;
                LoadABAssetUIComplete(""); 
            }
            else {
                _RootFileName = abPara.RootFileName;
                _AssetBundleName = abPara.AssetBundleName;
                _AssetName = abPara.AssetName;
                StartCoroutine(AssetBundleMgr.GetInstance().LoadAssetBundlePack(_RootFileName, _AssetBundleName, LoadABAssetUIComplete));  // 下载AssetBundel 指定包
            }
        }

        private void LoadABAssetUIComplete(string abName)      // （回调函数） 调用AB包中的UI资源
        {
            UnityEngine.Object tmpObj = null;
            tmpObj=AssetBundleMgr.GetInstance().LoadAsset(_RootFileName, _AssetBundleName, _AssetName);  
            if (tmpObj!=null)
            {
                _CloneUIPrefab = Instantiate(tmpObj); 
            }
            _IsLoadFinish = true;
        }

        public UnityEngine.Object GetCloneUIPrefab()     //   UI    得到克隆预设
        {
            if (_CloneUIPrefab!=null)
            {
                _IsLoadFinish = false;
                return _CloneUIPrefab;
            }
            return null;
        }
        #endregion

        #region 加载预制体    DefenseManager调用
        public void LoadAssetBundlePack(ABPara abPara)      // 调用AB框架预制体ab包
        {
            //仅仅是加载相同AB包中的不同资源
            if ((abPara.RootFileName == _RootFileName) && (abPara.AssetBundleName == _AssetBundleName))
            {
                _AssetName = abPara.AssetName;
                LoadABAssetComplete("");
            }
            else
            {
                _RootFileName = abPara.RootFileName;
                _AssetBundleName = abPara.AssetBundleName;
                _AssetName = abPara.AssetName;
                StartCoroutine(AssetBundleMgr.GetInstance().LoadAssetBundlePack(_RootFileName, _AssetBundleName, LoadABAssetComplete));  // 下载AssetBundel 指定包
            }
        }

        private void LoadABAssetComplete(string abName)      // （回调函数） 调用AB包中的预制体资源
        {
            UnityEngine.Object tmpObj = null;
            tmpObj = AssetBundleMgr.GetInstance().LoadAsset(_RootFileName, _AssetBundleName, _AssetName);  
            if (tmpObj != null)
            {
                _GamePrefab = tmpObj;
            }
            _IsLoadFinish = true;
        }
        public UnityEngine.Object GetPrefab()            // 得到预制体对应的预制体
        {
            if (_GamePrefab != null)
            {
                _IsLoadFinish = false;
                return _GamePrefab;
            }
            return null;
        }
        
        #endregion
    }
}