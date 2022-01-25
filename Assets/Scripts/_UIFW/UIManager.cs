
//UI管理器  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ABFW;
using TFW;
using HotUpdateProcess;
using UnityEditor;

namespace UIFW
{
	public class UIManager : MonoBehaviour {
	    private static UIManager _Instance = null;
        
	    private Dictionary<string, string> _DicFormsPaths;  //UI窗体json路径

        private Dictionary<string, BaseUIForm> _DicALLUIForms;      //缓存所有UI窗体

        public Dictionary<string, string> _DicUIFormPaths;  //UIform的本地路径

        public Transform _TraCanvasTransfrom = null;        //UI根节点
                                                            
        private Transform _TraNormal = null;    //全屏幕显示的节点
                                            
        private Transform _TraFixed = null;     //固定显示的节点
                                          
        private Transform _TraPopUp = null;      //弹出节点

        private string _UIFormName = string.Empty;  //UI窗体名称
        
        private BaseUIForm _BaseUIForm = null;      //UI窗体父类
       
        private bool _IsUIRootNodeInitFinish = false;        //UI根窗体初始化完毕

        public static UIManager GetInstance()       // 单例且不可销毁
        {
	        if (_Instance==null)
	        {
	            _Instance = new GameObject("_UIManager").AddComponent<UIManager>();
                DontDestroyOnLoad(_Instance);
            }
	        return _Instance;
	    }
 
	    public void Awake()
	    {
            _DicALLUIForms =new Dictionary<string, BaseUIForm>();           
            _DicFormsPaths=new Dictionary<string, string>();
            _DicUIFormPaths = new Dictionary<string, string>();
        }

        private void Start()
        {
            if (!UpdateResourcesFileFromServer.Local)
            {
                InitUIFormsPathData();        //加载“UI窗体预设”路径数据
                StartCoroutine(InitRootCanvasLoading(InitRootCanvas)); //加载Canvas
            }
            else
            {
                InitUIPathData();
                InitRootCanvas(gameObject);  //加载Canvas
            }
        }


        #region 初始化“UI窗体预设”路径数据
        private void InitUIFormsPathData()
        {
            //json 再SA目录中路径信息
            string strJsonDeployPath = string.Empty;

            strJsonDeployPath = ABFW.PathTools.GetABOutPath() + HotUpdateProcess.HotUpdatePathTool.JSON_DEPLOY_PATH;
            strJsonDeployPath = strJsonDeployPath + "/" + SysDefine.SYS_PATH_UIFORMS_CONFIG_INFO;

            ConfigManagerByJson configMgr = new ConfigManagerByJson(strJsonDeployPath);
            if (configMgr != null)
            {
                _DicFormsPaths = configMgr.JsonConfig;
            }
        }
        #endregion
        #region 加载UI Canvas
        private IEnumerator InitRootCanvasLoading(DelTaskComplete taskComplete)       
        {
            string uiRootFormPaths = string.Empty;  //UI 根窗体路径            
           
            _DicFormsPaths.TryGetValue("RootUIForm", out uiRootFormPaths);  //从UI预设路径集合中，查询UI根窗体的路径

            string[] strTempArray = uiRootFormPaths.Split('|');     //从路径(ab包参数)配置文件中，来合成需要的ab包参数
            ABPara abPara = new ABPara();
            abPara.RootFileName = strTempArray[0];
            abPara.AssetBundleName = strTempArray[1];
            abPara.AssetName = strTempArray[2];

            yield return LoadABAsset(abPara, taskComplete);
        }
        private void InitRootCanvas(UnityEngine.GameObject go)  // （回调函数）初始化Canvas预设上的各主要节点
        {
            //得到UI根节点、全屏节点、固定节点、弹出节点
            _TraCanvasTransfrom = GameObject.FindGameObjectWithTag(SysDefine.SYS_TAG_CANVAS).transform;
            _TraNormal = UnityHelper.FindTheChildNode(_TraCanvasTransfrom.gameObject, SysDefine.SYS_NORMAL_NODE);
            _TraFixed = UnityHelper.FindTheChildNode(_TraCanvasTransfrom.gameObject, SysDefine.SYS_FIXED_NODE);
            _TraPopUp = UnityHelper.FindTheChildNode(_TraCanvasTransfrom.gameObject, SysDefine.SYS_POPUP_NODE);

            //"根UI窗体"在场景转换的时候，不允许销毁
            DontDestroyOnLoad(_TraCanvasTransfrom);
            //UI根窗体初始化完毕
            _IsUIRootNodeInitFinish = true;
        }
        #endregion


        #region AB加载并打开
        public void ShowUIForms(string uiFormName)          // 打开UI窗体  lua调用
        {
            StartCoroutine(ShowUIForm(uiFormName));
            
        }
       
        public IEnumerator ShowUIForm(string uiFormName)  //打开UI窗体 
        {
            if (!UpdateResourcesFileFromServer.Local)
            {
                //Logon是lua自动加载，所以需先等待UI根窗体初始化完毕
                while (!_IsUIRootNodeInitFinish)
                {
                    yield return null;
                }
                LoadFormsToAllUIFormsCatch(uiFormName); //根据UI窗体的名称，加载到缓存集合中,且窗体已经加载到层级试图的相应位置（隐藏）
                                                        //等待UI窗体对象被赋值
                while (_BaseUIForm == null)
                {
                    yield return null;
                }
            }
#if UNITY_EDITOR
            else  //本地
            {
                while (!_IsUIRootNodeInitFinish)
                {
                    yield return null;
                }
                _BaseUIForm = ShowLocal(uiFormName);
               
            }
#endif
            //根据不同的UI窗体的显示模式，分别作不同的加载处理

            switch (_BaseUIForm.CurrentUIType.UIForms_ShowMode)
            {
                case UIFormShowMode.Normal:                 //“普通显示”窗口模式
                    OpenNormal(uiFormName);     
                    break;
                case UIFormShowMode.HideOther:              //“隐藏其他”窗口模式
                    OpenAndHideOther(uiFormName);
                    break;
                default:
                    break;
            }
            _BaseUIForm = null;
        }
        private void LoadFormsToAllUIFormsCatch(string uiFormsName) //检查是否加载过？ YES 则读字典 _BaseUIForm  ；NO 则读取路径获取ABPara 进行加载、然后回调确定层级
        {
            BaseUIForm baseUIResult = null;                 
            _DicALLUIForms.TryGetValue(uiFormsName, out baseUIResult);  

            if (baseUIResult == null)                 
            {
                 string strUIFormPaths = null;                  
                _UIFormName = uiFormsName;
                _DicFormsPaths.TryGetValue(uiFormsName, out strUIFormPaths);    //根据UI窗体名称，得到对应的加载路径
                if (!string.IsNullOrEmpty(strUIFormPaths))
                {
                    string[] strTempArray = strUIFormPaths.Split('|');
                    ABPara abPara = new ABPara();
                    abPara.RootFileName = strTempArray[0];
                    abPara.AssetBundleName = strTempArray[1];
                    abPara.AssetName = strTempArray[2];
                    //初始化加载Canvas 预设
                    StartCoroutine(LoadABAsset(abPara, LoadUIForm_Process));
                }         
            }
            else
            {
                _BaseUIForm = baseUIResult;
            }
        }
        private void LoadUIForm_Process(UnityEngine.GameObject goCloneUIPrefab)  //设置“UI窗体”的位置
        {
            BaseUIForm baseUIForm = null;   
            if (_TraCanvasTransfrom != null && goCloneUIPrefab != null)
            {
                baseUIForm = goCloneUIPrefab.GetComponent<BaseUIForm>();
                _BaseUIForm = baseUIForm;

                switch (baseUIForm.CurrentUIType.UIForms_Type)
                {
                    case UIFormType.Normal:                 //普通窗体节点
                        goCloneUIPrefab.transform.SetParent(_TraNormal, false);
                        break;
                    case UIFormType.Fixed:                  //固定窗体节点
                        goCloneUIPrefab.transform.SetParent(_TraFixed, false);
                        break;
                    case UIFormType.PopUp:                  //弹出窗体节点
                        goCloneUIPrefab.transform.SetParent(_TraPopUp, false);
                        break;
                    default:
                        break;
                }
                goCloneUIPrefab.SetActive(false);
                _DicALLUIForms.Add(_UIFormName, baseUIForm);
            }
            else
            {
                Debug.Log("_TraCanvasTransfrom==null Or goCloneUIPrefabs==null!! ,Plese Check!, 参数uiFormName=" + _UIFormName);
            }
        }
        private void OpenNormal(string uiFormName)      
        {
            BaseUIForm UIFromDIC;              //从“所有窗体集合”中得到的窗体

            _DicALLUIForms.TryGetValue(uiFormName, out UIFromDIC);
            if (UIFromDIC != null)
            {
                UIFromDIC.Display();        
            }
        }
        private void OpenAndHideOther(string strUIName)     // 隐藏其他窗体
        {
            BaseUIForm baseUIForm;                          //UI窗体
            foreach (BaseUIForm baseUI in _DicALLUIForms.Values)//把所有窗体都隐藏。
            {
                baseUI.CloseUI();
            }
            _DicALLUIForms.TryGetValue(strUIName, out baseUIForm);
             baseUIForm.Display();
        }
        private IEnumerator LoadABAsset(ABPara abPara, DelTaskComplete taskComplete)    // 使用 桥梁BFW中ABLoadAssetHelper 加载
        {
            //调用AB框架ab包
            ABLoadAppearance.GetInstance().LoadAssetBundleUIPack(abPara);
            //AB包是否调用完成
            while (!ABLoadAppearance.GetInstance().IsLoadFinish)
            {
                yield return null;
            }
            //得到（克隆）的UI预设
            UnityEngine.GameObject goCloneUIPrefab = (UnityEngine.GameObject)ABLoadAppearance.GetInstance().GetCloneUIPrefab();
            //委托调用
            taskComplete.Invoke(goCloneUIPrefab);
        }
        #endregion

        #if UNITY_EDITOR
        #region 本地加载
        public BaseUIForm ShowLocal(string uiFormName)      //打开窗体 lua调用
        {
            BaseUIForm bUI;
            if (!_DicALLUIForms.ContainsKey(uiFormName))
            {
                _UIFormName = uiFormName;
                string refRoad;
                _DicUIFormPaths.TryGetValue(uiFormName, out refRoad);
                
                //var obj = Resources.Load<GameObject>(refRoad);
                var obj = AssetDatabase.LoadAssetAtPath("Assets/"+"AB_Resources/"+ refRoad, typeof(GameObject)) as GameObject;
                Debug.Log("Assets/" + "AB_Resources/" + refRoad);
                GameObject Localobj = GameObject.Instantiate(obj);  
                Localobj.SetActive(false);
                 bUI = Localobj.GetComponent<BaseUIForm>();
                _DicALLUIForms.Add(_UIFormName, bUI);
                switch (bUI.CurrentUIType.UIForms_Type)
                {
                    case UIFormType.Normal:                 //普通窗体节点
                        Localobj.transform.SetParent(_TraNormal, false);
                        break;
                    case UIFormType.Fixed:                  //固定窗体节点
                        Localobj.transform.SetParent(_TraFixed, false);
                        break;
                    case UIFormType.PopUp:                  //弹出窗体节点
                        Localobj.transform.SetParent(_TraPopUp, false);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                bUI = _DicALLUIForms[uiFormName];
            }
            return bUI;
        }

        #endregion

        #endif
        #region 关闭窗体
        public void CloseUIForms(string uiFormName)      //关闭窗体 lua调用
        {
            BaseUIForm baseUIForm;                          //窗体基类
            _DicALLUIForms.TryGetValue(uiFormName, out baseUIForm);
            baseUIForm.CloseUI();    
        }
        #endregion

        private void InitUIPathData()         // 初始化“游戏预制体”路径数据
        {
            string strJsonDeployPath = string.Empty;
            strJsonDeployPath = ABFW.PathTools.GetABResourcesPath() + "/LocalUIConfigInfo.json";

            ConfigManagerByJson configMgr = new ConfigManagerByJson(strJsonDeployPath);   //调用Json 配置文件管理器 new时自动读好文件，并可读
            if (configMgr != null)
            {
                _DicUIFormPaths = configMgr.JsonConfig;
            }
          
        }
    }
    #region 窗体类型枚举
    public enum UIFormType   // UI窗体（位置）类型
    {
        //普通窗体
        Normal,
        //固定窗体                              
        Fixed,
        //弹出窗体
        PopUp
    }

    public enum UIFormShowMode  // UI窗体的显示类型
    {
        //普通
        Normal,
        //隐藏其他
        HideOther
    }
    #endregion

}