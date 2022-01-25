
// 游戏中上端信息显示窗体  

using System.Collections;
using System.Collections.Generic;
using UIFW;
using ABFW;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DemoProject
{
    public class GameInfoUIForm : BaseUIForm
    {

        void Awake()
        {
            //窗体性质
            CurrentUIType.UIForms_Type = UIFormType.Fixed;  //固定在主窗体上面显示
            CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;   //隐藏其他窗体
        }

    }
}