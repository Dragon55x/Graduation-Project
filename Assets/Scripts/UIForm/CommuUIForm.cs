
//公告窗体

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFW;

namespace DemoProject
{
    public class CommuUIForm : BaseUIForm
    {
        private void Awake()
        {
            //窗体性质
            CurrentUIType.UIForms_Type = UIFormType.PopUp;  //弹出窗体    
        }
    }
}

