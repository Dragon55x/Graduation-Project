using UIFW;
using TFW;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ABFW;
using HotUpdateProcess;
using UnityEditor;

namespace PFW
{
    public class DefenseManager : MonoBehaviour
    {
        private static DefenseManager _Instance = null;

        //游戏预制体路径(key：防御塔预设名称，value：表示防御塔预设路径)
        public Dictionary<string, string> _DicDefensesPaths;
        //缓存所有游戏预制体
        public Dictionary<string, UnityEngine.Object> _DicALLDTForms;
        //游戏预制体实例
        private UnityEngine.Object goPrefab = null;


        public static DefenseManager GetInstance()   //LUA DefenseListUIForm 调用
        {
            if (_Instance == null)
            {
                _Instance = new GameObject("_DefenseManager").AddComponent<DefenseManager>();
                DontDestroyOnLoad(_Instance);
            }
            return _Instance;
        }
        public void Awake()
        {
            //字段初始化
            _DicALLDTForms = new Dictionary<string, UnityEngine.Object>();
            _DicDefensesPaths = new Dictionary<string, string>();
            
        }
        void Start()
        {
            if (!UpdateResourcesFileFromServer.Local)
            {
                //初始化“游戏预制体预设”路径数据
                InitDefensesPathData();
                //把所有的游戏预制体都加载出来
                StartCoroutine(InitRootCanvasLoading(_DicDefensesPaths, DICgoPrefab));
            }
#if UNITY_EDITOR
            else
            {
                //本地资源
                Local_InitDefensesPathData();
                StartCoroutine(InitLocalLoading(_DicDefensesPaths));
            }
#endif
        }

        private IEnumerator InitRootCanvasLoading(Dictionary<string,string> DTPaths, DTComplete taskComplete)// 从JSON读好的路径，初始化加载游戏预制体
        {
            foreach (var item in DTPaths)
            {
                //从路径(ab包参数)配置文件中，来合成需要的ab包参数
                string[] strTempArray = item.Value.Split('|');
                ABPara abPara = new ABPara();
                abPara.RootFileName = strTempArray[0];
                abPara.AssetBundleName = strTempArray[1];
                abPara.AssetName = strTempArray[2];
                //调用AB框架ab包
                ABLoadAppearance.GetInstance().LoadAssetBundlePack(abPara);
                //AB包是否调用完成
                while (!ABLoadAppearance.GetInstance().IsLoadFinish)
                {
                    yield return null;
                }
                goPrefab = ABLoadAppearance.GetInstance().GetPrefab();
                
                string pName = goPrefab.name;
                
                //委托调用
                taskComplete.Invoke(pName);    
            }
        }
        private void DICgoPrefab(string preName)            //委托 回调函数
        {
            _DicALLDTForms.Add(preName, goPrefab);
        }
     
        private void InitDefensesPathData()         // 初始化“游戏预制体”路径数据
        {
            
            string strJsonDeployPath = string.Empty;
            strJsonDeployPath = ABFW.PathTools.GetABOutPath() + HotUpdateProcess.HotUpdatePathTool.JSON_DEPLOY_PATH;
            strJsonDeployPath = strJsonDeployPath + "/" + SysDefine.SYS_PATH_DT_CONFIG_INFO;                    //json 路径

            ConfigManagerByJson configMgr = new ConfigManagerByJson(strJsonDeployPath);   //调用Json 配置文件管理器 new时自动读好文件，并可读
            if (configMgr != null)
            {
                _DicDefensesPaths = configMgr.JsonConfig;   
            }
        }

        public UnityEngine.GameObject PrefabAB(string DTname)    // lua 调用  通过名字作为key，返回游戏预制体
        {
            
            UnityEngine.Object DefenseTower = null;
            _DicALLDTForms.TryGetValue(DTname, out DefenseTower);

            UnityEngine.GameObject DTPre = (UnityEngine.GameObject)DefenseTower;
            return DTPre;
        }

        public void checkABDIC()    //查询所有游戏预制体
        {
            foreach (var item in _DicALLDTForms)
            {
                Debug.Log(item.Key+"    "+item.Value);
            }
        }

        private void Local_InitDefensesPathData()         // 初始化本地“游戏预制体”路径数据
        {
            string strJsonDeployPath = string.Empty;
            strJsonDeployPath = ABFW.PathTools.GetABResourcesPath() + "/LocalDefenseConfigInfo.json";                    //json 路径

            ConfigManagerByJson configMgr = new ConfigManagerByJson(strJsonDeployPath);   //调用Json 配置文件管理器 new时自动读好文件，并可读
            if (configMgr != null)
            {
                _DicDefensesPaths = configMgr.JsonConfig;
            }
        }
        #if UNITY_EDITOR
        private IEnumerator InitLocalLoading(Dictionary<string, string> DTPaths)// 从JSON读好的路径，初始化加载游戏预制体
        {
            foreach (var item in DTPaths)
            {
                string refRoad = item.Value;
                //var goPrefab = Resources.Load<GameObject>(refRoad);
                var goPrefab = AssetDatabase.LoadAssetAtPath("Assets/" + "AB_Resources/" + refRoad, typeof(GameObject)) as GameObject;
                string pName = goPrefab.name;
                //委托调用
                _DicALLDTForms.Add(pName, goPrefab);
            }
            yield return null;
        }
        #endif
    }
}

