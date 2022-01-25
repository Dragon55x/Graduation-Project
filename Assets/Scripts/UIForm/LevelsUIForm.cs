
//关卡选择窗体

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFW;

namespace DemoProject
{
    public class LevelsUIForm : BaseUIForm
    {
        private void Awake()
        {
            CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;
        }
    }
}

