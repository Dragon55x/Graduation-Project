
using System.Collections;
using System.Collections.Generic;
using UIFW;
using UnityEngine;

namespace DemoProject
{
    public class StoryUIForm : BaseUIForm                        //故事背景
    {

        public void Awake()
        {
            
            //窗体的性质
            CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;

            ////注册进入主城的事件
            //RigisterButtonObjectEvent("BtnConfirm",
            //    () =>
            //    {
            //        OpenUIForm(ProConst.MAIN_CITY_UIFORM);
            //        OpenUIForm(ProConst.HERO_INFO_UIFORM);
            //    }

            //    );

            //RigisterButtonObjectEvent("BtnClose",
            //    () =>
            //    {
            //        OpenUIForm(ProConst.LOGON_FROMS,true);
            //    }
            //    );
        }
    }
}